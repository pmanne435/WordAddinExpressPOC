using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System.Text;
using System.Xml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Verisk.ISO.Mozart.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult GetAllForms()
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase database = server.GetDatabase("test");
            MongoCollection collection = database.GetCollection("forms");

            List<Form> forms = collection.FindAllAs<Form>().ToList<Form>();
            return Json(new { data = forms }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult GetFileDownloadObjectId(string objectIdValue)
        {
            FileContentResult fileContentResult = null;
            try
            {
                MongoClient client = new MongoClient("mongodb://localhost");
                MongoServer server = client.GetServer();
                MongoDatabase database = server.GetDatabase("test");
                MongoCollection collection = database.GetCollection("forms");
                // ObjectId id = new ObjectId(objectIdValue);
                List<Form> employees = collection.AsQueryable<Form>().Where(o => o.FileId == objectIdValue).ToList();
                foreach (var emp in employees)
                {
                    ObjectId fileId = new ObjectId(emp.FileId);
                    MongoGridFSFileInfo file = database.GridFS.FindOne(MongoDB.Driver.Builders.Query.EQ("_id", fileId));
                    using (var stream = file.OpenRead())
                    {
                        var bytes = new byte[stream.Length];
                        stream.Read(bytes, 0, (int)stream.Length);
                        Employee objemp = new Employee();
                        objemp.Data = bytes;
                        MemoryStream memoryStream = new MemoryStream(bytes);
                        byte[] bytesInStream = memoryStream.ToArray(); // simpler way of converting to array
                        fileContentResult = File(bytesInStream, "application/msword", emp.FileName);
                    }
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
            return fileContentResult;
        }

        [HttpPost]
        public ActionResult UploadAllFiles(Form form)
        {
            string FilePath = string.Empty;
            try
            {
                StringBuilder docTextFormat = new StringBuilder();
                string fileType = string.Empty;
                var file2 = Request.Files.Count;
                var formDetails = Request.Form;
                foreach (string fileTemp in Request.Files)
                {
                    var fileContent = Request.Files[fileTemp];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        var contentLength = fileContent.ContentLength;
                        fileType = fileContent.FileName;
                        var inputStream = fileContent.InputStream;
                        var bytes = new byte[contentLength];
                        inputStream.Read(bytes, 0, contentLength);
                        MemoryStream memStream = new MemoryStream(bytes); // for text format
                        MemoryStream memStream1 = new MemoryStream(bytes); // For stream format - TODO: need to check 

                        //**************************Getting the data from memory stream to string format ************************************////
                        string newDirectory = Server.MapPath("~/Upload/");
                        if (!Directory.Exists(newDirectory))
                        {
                            Directory.CreateDirectory(newDirectory);
                        }
                        FilePath = newDirectory + fileType;
                        var fileStream = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Write);
                        memStream.CopyTo(fileStream);

                        fileStream.Flush();
                        fileStream.Close();
                        fileStream.Dispose();
                         
                        Stream docstream = System.IO.File.Open(FilePath, FileMode.Open);
                        WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(docstream, true);
                        Body body = wordprocessingDocument.MainDocumentPart.Document.Body;
                         
                        string openxmlContent = body.InnerText;
                        string formmatedText = body.InnerXml;
                        wordprocessingDocument.Close();
                        docstream.Close();
                        // Read the Document Comments and storing into MongoDB
                        List<Comments> listComments  = GetCommentsFromDocument(FilePath);
                       
                        /**** Connect to mongo DB to upload the document and object ****/
                        MongoClient client = new MongoClient("mongodb://localhost");
                        MongoServer server = client.GetServer();
                        MongoDatabase database = server.GetDatabase("test");
                        MongoCollection collection = database.GetCollection("forms");
                        var formEntity = new Form
                        {
                            FileName = fileContent.FileName,
                            FormNumber = form.FormNumber,
                            FormTitle = form.FormTitle,
                            Tags = form.Tags,
                            ManualRules = form.ManualRules,
                            FileContent = openxmlContent,
                            Comments = listComments
                        };
                        MongoGridFSFileInfo gfsi = database.GridFS.Upload(memStream1, fileContent.FileName);
                        BsonDocument photoMetadata = new BsonDocument { { "FileName", fileContent.FileName }, { "Type", fileContent.ContentType } };
                        database.GridFS.SetMetadata(gfsi, photoMetadata);
                        formEntity.FileId = gfsi.Id.AsObjectId.ToString();
                        collection.Insert(formEntity);

                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (System.IO.File.Exists(FilePath))
                {
                    System.IO.File.Delete(FilePath);
                }
            }
            return View("Index");
        }

        private List<Comments> GetCommentsFromDocument(string fileName)
        {
            List<Comments> listComments = new List<Comments>();
            using (WordprocessingDocument wordDoc =
                WordprocessingDocument.Open(fileName, false))
            {
                WordprocessingCommentsPart commentsPart =
                    wordDoc.MainDocumentPart.WordprocessingCommentsPart;

                if (commentsPart != null && commentsPart.Comments != null)
                {
                    foreach (Comment comment in commentsPart.Comments.Elements<Comment>()) 
                    {
                        Comments eachComment = new Comments();
                        eachComment.Text = comment.InnerText;
                        eachComment.Commenter = comment.Author;
                        listComments.Add(eachComment);
                    }
                    
                }
            }
            return listComments;
        }
    }
}