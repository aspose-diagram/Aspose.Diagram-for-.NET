using Aspose.App.Diagram.Api.Services;
using Aspose.App.Diagram.Infrastructure;
using Aspose.App.Diagram.Processor;
using Aspose.Diagram;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Aspose.App.Diagram.Api.Controllers
{
    public class ViewerController : BaseApiController
    {
        private readonly static string ViewDirectory = AppConfig.SourceRootDirectory;
        ///<Summary>
        /// DocumentPages method to get document pages
        ///</Summary>
        [HttpGet]
        [ActionName("DocumentPages")]
        public HttpResponseMessage DocumentPages(string file, string folderName, int currentPage)
        {
            var sessionId = folderName;
            HttpResponseMessage response = new HttpResponseMessage();
            List<string> output = GetDocumentPages(file, folderName, currentPage);
            response.Content = new StringContent(JsonConvert.SerializeObject(output));
            return response;
        }

        ///<Summary>
		/// PageImage method to get page image
		///</Summary>
		[HttpGet]
        [ActionName("PageImage")]
        public HttpResponseMessage PageImage(string imagePath)
        {
            return GetImageFromPath(Path.Combine(ViewDirectory,imagePath));
        }

        private HttpResponseMessage GetImageFromPath(string imagePath)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            System.Drawing.Image image = System.Drawing.Image.FromStream(fileStream);
            MemoryStream memoryStream = new MemoryStream();


            image.Save(memoryStream, ImageFormat.Jpeg);
            result.Content = new ByteArrayContent(memoryStream.ToArray());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            fileStream.Close();

            return result;
        }


        private List<string> GetDocumentPages(string file, string folderName, int currentPage)
        {
            List<string> lstOutput = new List<string>();
            string outfileName = "page_{0}";
            string relativePath = folderName + "/" + outfileName;
            //string outPath = ViewDirectory + relativePath;

            currentPage = currentPage - 1;
            Directory.CreateDirectory(ViewDirectory + folderName);
            string imagePath = string.Format(relativePath, currentPage) + ".png";
            if (System.IO.File.Exists(ViewDirectory + imagePath) && currentPage > 0)
            {
                lstOutput.Add(imagePath);
                return lstOutput;
            }

            int i = currentPage;

            var filename = ViewDirectory + folderName + "/" + file;
            // Load the document from disk.
            Aspose.Diagram.Diagram diagram = DiagramFactory.Build(filename, folderName);
            Aspose.Diagram.Saving.ImageSaveOptions options = new Aspose.Diagram.Saving.ImageSaveOptions(SaveFileFormat.PNG);
            options.PageCount = 1;
            // Save each page of the document as image.
            options.PageIndex = currentPage;
            diagram.Save(ViewDirectory + imagePath, options);
            lstOutput.Add(diagram.Pages.Count.ToString());
            lstOutput.Add(imagePath);

            return lstOutput;
        }
    }
}
