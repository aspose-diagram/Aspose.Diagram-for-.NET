using Aspose.App.Diagram.Api.Services;
using Aspose.App.Diagram.Infrastructure;
using Aspose.App.Diagram.Models.App;
using Aspose.App.Diagram.Models.Response;
using Aspose.App.Diagram.Processor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Aspose.App.Diagram.Api.Controllers
{
    public class ConversionController : BaseApiController
    {
        [HttpPost]
        [ActionName("Convert")]
        public async Task<DocumentActionResponse> Convert(string outputType)
        {
            var sessionId = NewSession();
            var documents = await UploadFiles(sessionId);
            var result = ConvertProcessor.Convert(new ProcessorModel(sessionId, outputType, documents, AppStorage.GetExportRoot(sessionId)));
            var downloadData = new DocumenDownloadInfo(result.FileName, Path.GetDirectoryName(result.FilePath).Replace(AppConfig.ExportRootDirectory, ""));
            return new DocumentActionResponse() { Data = downloadData, SessionId = sessionId };
        }
    }
}
