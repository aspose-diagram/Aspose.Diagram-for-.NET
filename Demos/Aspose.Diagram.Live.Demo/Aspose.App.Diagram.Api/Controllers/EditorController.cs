using Aspose.App.Diagram.Api.Models;
using Aspose.App.Diagram.Api.Services;
using Aspose.App.Diagram.Infrastructure;
using Aspose.App.Diagram.Models.App;
using Aspose.App.Diagram.Processor;
using EditorHandler.Models;
using EditorHandler.Vsdx;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace Aspose.App.Diagram.Api.Controllers
{
    public class EditorController : BaseApiController
    {
        private VsdxService _service = new VsdxService();
        private VsdxZip _zip = new VsdxZip();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Import")]
        public Result Import()
        {
            var sessionId = NewSession();
            var file = HttpContext.Current.Request.Files[0];
            var filePath = CreateTempFile(file.FileName, sessionId);
            file.SaveAs(filePath);
            return ImportFile(filePath, sessionId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Open")]
        public Result Open([FromBody]FileInfoRequest fileInfo)
        {
            var sessionId = fileInfo.FolderName;
            var action = $"Editor Open";
            var filePath = GetTempFile(fileInfo.FolderName, System.Web.HttpUtility.UrlDecode(fileInfo.FileName));
            return ImportFile(filePath, sessionId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appVsdx"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Export")]
        public HttpResponseMessage Export([FromBody]AppVsdxAdapter appVsdx)
        {
            var sessionId = NewSession();
            string outputType = "";
            if (string.IsNullOrWhiteSpace(appVsdx.filename)) {
                appVsdx.filename = "drawing";
            }
            var fileNameWithOutExtension = Path.GetFileNameWithoutExtension(appVsdx.filename);
            var filePath = CreateTempFile(fileNameWithOutExtension + ".vsdx", sessionId);
            var fileDirectory = Path.GetDirectoryName(filePath);
            var outPath = "";
            using (FileStream stream = File.Create(filePath))
            {
                _service.fileName = fileNameWithOutExtension;
                _service.addPagesXML(appVsdx.pagesName, appVsdx.images, appVsdx.pageLayers, appVsdx.modelsAttr, appVsdx.pagesXml);
                _service.createVsdxSkeleton(appVsdx.pagesName);
                _service.Zip(_service.fileName, stream);

                outputType = Path.GetExtension(appVsdx.filename).Replace(".", "");
                if (string.IsNullOrWhiteSpace(outputType)) {
                    outputType = appVsdx.format;
                }

                var document = new DocumentModel()
                {
                    FileName = fileNameWithOutExtension + ".vsdx",
                    FilePath = filePath
                };
                var result = ConvertProcessor.Convert(new ProcessorModel(sessionId, outputType, document, AppStorage.GetExportRoot(sessionId)));
                outPath = result.FilePath;

                HttpResponseMessage response = new HttpResponseMessage();
                response.Content = new StreamContent(File.OpenRead(outPath));
                response.Content.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                response.Content.Headers.ContentDisposition.FileName = System.Web.HttpUtility.UrlEncode(Path.GetFileName(outPath), System.Text.Encoding.UTF8);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                return response;
            }
        }

        private Result ImportFile(string filePath, string sessionId)
        {
            string xml = "";
            if (Path.GetExtension(filePath) != ".vsdx")
            {
                Aspose.Diagram.Diagram diagram = new Aspose.Diagram.Diagram(filePath);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    diagram.Save(memoryStream, Aspose.Diagram.SaveFileFormat.VSDX);
                    memoryStream.Position = 0;
                    xml = _zip.ReadXml(memoryStream);
                }
            }
            else
            {
                using (Stream stream = File.OpenRead(filePath))
                {
                    xml = _zip.ReadXml(stream);
                }
            }
            return ResultFactory.buildSuccessResult("Success", xml, sessionId);
        }

        private string CreateTempFile(string fileName, string sessionId)
        {
            var fileDirectory = Path.Combine(AppConfig.SourceRootDirectory, sessionId);
            Directory.CreateDirectory(fileDirectory);
            var filePath = Path.Combine(fileDirectory, fileName);
            return filePath;
        }

        private string GetTempFile(string folderName, string fileName)
        {
            return Path.Combine(AppConfig.SourceRootDirectory, folderName, fileName);
        }
    }
}
