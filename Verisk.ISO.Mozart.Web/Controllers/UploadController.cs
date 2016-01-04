using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using Verisk.ISO.Mozart.Web.Models;

namespace Verisk.ISO.Mozart.Web.Controllers
{
	public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
	{
		public CustomMultipartFormDataStreamProvider(string path) : base(path)
		{ }

		public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
		{
			var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? headers.ContentDisposition.FileName : "NoName";
			return name.Replace("\"", string.Empty); //this is here because Chrome submits files in quotation marks which get treated as part of the filename and get escaped
		}
	}


	public class FileDesc
	{
		public string Name
		{ get; set; }
		public string Path
		{ get; set; }
		public long Size
		{ get; set; }

		public FileDesc(string n, string p, long s)
		{
			Name = n;
			Path = p;
			Size = s;
		}
	}


	public class UploadController : ApiController
	{

		public Task<IEnumerable<FileDesc>> Post()
		{
			var folderName = "uploads";
			var PATH = System.Web.HttpContext.Current.Server.MapPath("~/" + folderName);
			var rootUrl = Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.AbsolutePath, String.Empty);
			if(Request.Content.IsMimeMultipartContent())
			{
				var streamProvider = new CustomMultipartFormDataStreamProvider(PATH);
				var task = Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith<IEnumerable<FileDesc>>(t =>
				{

					if(t.IsFaulted || t.IsCanceled)
					{
						throw new HttpResponseException(HttpStatusCode.InternalServerError);
					}

					var fileInfo = streamProvider.FileData.Select(i =>
					{
						var info = new FileInfo(i.LocalFileName);
						return new FileDesc(info.Name, rootUrl + "/" + folderName + "/" + info.Name, info.Length / 1024);
					});
					return fileInfo;
				});

				return task;
			}
			else
			{
				throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
			}
		}

		public HttpResponseMessage GetFilesBySearchText(string searchText)
		{
			string searchString = searchText.ToLower();
            MongoClient client = new MongoClient("mongodb://localhost");			
			MongoDatabase database = client.GetServer().GetDatabase("test");			
			List<Form> forms = database.GetCollection("forms").AsQueryable<Form>()
										.Where(o => o.FormTitle.ToLower().Contains(searchString) 
												|| o.FileName.ToLower().Contains(searchString)
												|| o.FileContent.ToLower().Contains(searchString)
												|| o.ManualRules.ToLower().Contains(searchString)
											  ).ToList();

			HttpResponseMessage httpResponseMessage = Request.CreateResponse<List<Form>>(HttpStatusCode.OK, forms);
			return httpResponseMessage;
		}

		public HttpResponseMessage GetFileByObjectId(string objectId)
		{
			MongoClient client = new MongoClient("mongodb://localhost");
			MongoDatabase database = client.GetServer().GetDatabase("test");			
			Form form = database.GetCollection("forms").AsQueryable<Form>()
				                                       .Where(o => o.FileId == objectId)
													   .FirstOrDefault();

			ObjectId fileId = new ObjectId(form.FileId);
			MongoGridFSFileInfo file = database.GridFS.FindOne(Query.EQ("_id", fileId));
			using(var stream = file.OpenRead())
			{
				byte[] bytes = new byte[stream.Length];
				stream.Read(bytes, 0, (int)stream.Length);

				HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
				httpResponseMessage.Content = new ByteArrayContent(bytes);
				httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
				httpResponseMessage.StatusCode = HttpStatusCode.OK;
				return httpResponseMessage;
			}
		}

	}
}