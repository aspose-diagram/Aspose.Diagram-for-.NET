using Aspose.App.Diagram.Api.Services;
using Aspose.App.Diagram.Infrastructure;
using Aspose.App.Diagram.Models.App;
using Aspose.App.Diagram.Models.Response;
using Aspose.App.Diagram.Processor;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace Aspose.App.Diagram.Api.Controllers
{
    public class StorageController : BaseApiController
    {

        [HttpPost]
        public async Task<UploadFileResponse> Upload(HttpRequestMessage request)
        {
            var sessionId = NewSession();
            var documents = await UploadFiles(sessionId);
            if (documents.Count() != 1)
            {
                throw new AppException(sessionId, "The file count must be 1");
            }
            var file = documents.Single();
            return new UploadFileResponse()
            {
                Code = 200,
                Data = new UploadResult(file.FileName, sessionId),
                SessionId = sessionId,
            };
        }

        [HttpGet]
        public HttpResponseMessage Download(string file,string folder)
        {
            var filePath = Path.Combine(AppConfig.ExportRootDirectory, folder, file);
            if (!System.IO.File.Exists(filePath))
                throw new FileNotFoundException();

            return DownloadFile(file, filePath);
        }

        private HttpResponseMessage DownloadFile(string file, string filePath)
        {
            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None, bufferSize: 4096, useAsync: true);

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(stream)
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = file
            };
            return result;
        }

        [HttpGet]
        public HttpResponseMessage ConvertDownload(string file, string folder,string outputType)
        {
            var sessionId = NewSession();
            var filePath = Path.Combine(AppStorage.GetSourceRoot(folder), file);
            var documents = new DocumentModel[] {
                new DocumentModel(filePath)
            };
            var result = ConvertProcessor.Convert(new ProcessorModel(sessionId, outputType, documents, AppStorage.GetExportRoot(sessionId)));

            return DownloadFile(result.FileName,result.FilePath);
        }
    }
}
