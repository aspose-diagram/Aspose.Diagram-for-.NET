using Aspose.App.Diagram.Api.Services;
using Aspose.App.Diagram.Infrastructure;
using Aspose.App.Diagram.Models.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Script.Serialization;

namespace Aspose.App.Diagram.Api.Filters
{
    /// <summary>
    /// AOP action interceptor
    /// </summary>
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {

        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var requestId= Guid.NewGuid().ToString().Replace("-","");
            var sessionId = Guid.NewGuid().ToString();
            actionContext.Request.Properties[AppHttpContentHelper.EnterTimeKey] = DateTime.Now.ToBinary();
            actionContext.Request.Properties[AppHttpContentHelper.RequestIdKey] = requestId;
            actionContext.Request.Properties[AppHttpContentHelper.SessionIdKey] = sessionId;
            NLogger.Debug($"[{requestId}][sessionId:{sessionId}]{actionContext.Request.RequestUri.ToString()}");
            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }

        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            var requestId = AppHttpContentHelper.GetRequestStringProperty(actionExecutedContext.Request, AppHttpContentHelper.RequestIdKey);
            var enterTime = AppHttpContentHelper.GetRequestDateTimetProperty(actionExecutedContext.Request, AppHttpContentHelper.EnterTimeKey);
            var costTime = (DateTime.Now - enterTime).TotalSeconds;
            string responseJson = GetResponseJson(actionExecutedContext);
            NLogger.Debug($"[{Math.Round(costTime, 2)}s][{requestId}]Response:{responseJson}");
            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }

        private string GetResponseJson(HttpActionExecutedContext actionExecutedContext)
        {
            var responseJson = "";
            if (actionExecutedContext.Response != null)
            {
                if (actionExecutedContext.Response.Content is ByteArrayContent || IsFileFromHeader(actionExecutedContext.Response))
                {
                    responseJson = "File";
                }
                else
                {
                    responseJson = GetResponseValues(actionExecutedContext);
                }
            }

            return responseJson;
        }

        private string GetResponseValues(HttpActionExecutedContext actionExecutedContext)
        {
            var httpResponse = actionExecutedContext.Response;
            if (httpResponse.Content != null && httpResponse.Content.Headers != null && httpResponse.Content.Headers.ContentType.MediaType != null)
            {
                if (!httpResponse.Content.Headers.ContentType.MediaType.Equals("application/json"))
                {
                    return "";
                }
            }
            Stream stream = actionExecutedContext.Response.Content.ReadAsStreamAsync().Result;
            Encoding encoding = Encoding.UTF8;

            var reader = new StreamReader(stream, encoding);
            string result = reader.ReadToEnd();

            stream.Position = 0;

            if (result.Length > 5000) {
                return "response body too large to display";
            }
            return result;
        }

        private bool IsFileFromHeader(HttpResponseMessage httpResponse)
        {
            if (httpResponse.Content != null && httpResponse.Content.Headers != null&& httpResponse.Content.Headers.ContentType.MediaType!=null)
            {
                return httpResponse.Content.Headers.ContentType.MediaType.Equals("application/octet-stream");
            }
            return false;
        }
    }
}
