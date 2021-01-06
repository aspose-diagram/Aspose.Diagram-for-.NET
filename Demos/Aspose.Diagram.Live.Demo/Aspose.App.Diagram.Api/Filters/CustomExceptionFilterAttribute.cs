using Aspose.App.Diagram.Infrastructure;
using Aspose.App.Diagram.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Aspose.App.Diagram.Api.Filters
{
    public class CustomExceptionFilterAttribute : System.Web.Http.Filters.ExceptionFilterAttribute
    {
        public override void OnException(System.Web.Http.Filters.HttpActionExecutedContext actionExecutedContext)
        {
            var sessionId = AppHttpContentHelper.GetRequestStringProperty(actionExecutedContext.Request, AppHttpContentHelper.SessionIdKey);
            var action = actionExecutedContext.Request.RequestUri.PathAndQuery;
            NLogger.Error(actionExecutedContext.Exception, sessionId, action);
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(
                   System.Net.HttpStatusCode.BadRequest, CreateExceptionResponse(actionExecutedContext.Exception, sessionId,action));
        }

        private BaseResponse CreateExceptionResponse(Exception ex,string sessionId,string action)
        {
            var response = new BaseResponse()
            {
                SessionId = sessionId,
                Action = action,
                Code = 400,
                Message = ex.Message,
            };

            return response;
        }
    }
}