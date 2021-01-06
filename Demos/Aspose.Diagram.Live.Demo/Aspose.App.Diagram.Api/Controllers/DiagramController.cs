using Aspose.App.Diagram.Infrastructure;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Aspose.App.Diagram.Api.Controllers
{
    public class DiagramController : BaseApiController
    {
        [HttpGet]
        public string Index()
        {
            var sessionId = NewSession();
            return "Hello Diagram App!"+ sessionId;
        }
    }
}
