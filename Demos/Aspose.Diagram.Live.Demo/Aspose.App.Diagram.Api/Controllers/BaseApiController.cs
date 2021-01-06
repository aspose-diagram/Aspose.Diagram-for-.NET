using Aspose.App.Diagram.Api.Filters;
using Aspose.App.Diagram.Api.Services;
using Aspose.App.Diagram.Infrastructure;
using Aspose.App.Diagram.Models.App;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Aspose.App.Diagram.Api.Controllers
{
    [EnableCors(origins: "*", methods: "*", headers: "*")]
    public class BaseApiController : ApiController
    {
        protected string NewSession()
        {
            object sessionObj = null;
            Request.Properties.TryGetValue(AppHttpContentHelper.SessionIdKey, out sessionObj);
            if (sessionObj != null)
            {
                return sessionObj.ToString();
            }
            else
            {
                var sessionId = AppSession.CreateSessionId();
                return sessionId;
            }
        }

        protected async Task<DocumentModel[]> UploadFiles(string sessionId)
        {
            try
            {
                var storagePath = AppStorage.GetSessionRoot(sessionId);
                var uploadProvider = new MultipartFormDataStreamProviderSafe(storagePath);
                await Request.Content.ReadAsMultipartAsync(uploadProvider);
                if (uploadProvider.FileData == null || uploadProvider.FileData.Count == 0)
                {
                    throw new AppException(sessionId, "Files upload fail");
                }
                return uploadProvider.FileData.Select(file => new DocumentModel
                {
                    FileName = Path.GetFileName(file.LocalFileName),
                    FilePath = file.LocalFileName,
                }).ToArray();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
