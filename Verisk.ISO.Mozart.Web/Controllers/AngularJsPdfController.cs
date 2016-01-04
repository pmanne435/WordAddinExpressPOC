using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using System.IO;
using System.Text;
using Aspose.Words;

namespace Verisk.ISO.Mozart.Web.Controllers
{
    public class AngularJsPdfController : Controller
    {
        // GET: AngularJsPdf
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GeneratePDFViewer(string objectIdValue)
        {
            var data = new List<object>();
            string FilePath = string.Empty;
            string pdfFilePath = string.Empty;
            string fileType = string.Empty;
            try
            {
                byte[] bytesInStream = null;
                MongoClient client1 = new MongoClient("mongodb://localhost");
                MongoServer server = client1.GetServer();
                MongoDatabase database = server.GetDatabase("test");
                MongoCollection collection = database.GetCollection("forms");
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
                        bytesInStream = memoryStream.ToArray(); // simpler way of converting to array
                        string newDirectory = Server.MapPath("~/Upload/");
                        if (!Directory.Exists(newDirectory))
                        {
                            Directory.CreateDirectory(newDirectory);
                        }
                        FilePath = newDirectory + emp.FileName;
                        var fileStream = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Write);
                        memoryStream.CopyTo(fileStream);
                        fileStream.Flush();
                        fileStream.Close();
                        fileStream.Dispose();
                        /**** Start of using Aspose to generate PDF for DocX file****/
                        // The path to the documents directory.
                        string dataDir = FilePath;
                        Aspose.Words.Document doc = new Aspose.Words.Document(dataDir);
                        doc.Save(dataDir + ".pdf");
                        /**** End of closing Pdf conversion using docx ****/
                        pdfFilePath = "/Upload/" + emp.FileName + ".pdf";
                       
                        data.Add(new { path = pdfFilePath, name = emp.FileName });
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
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}