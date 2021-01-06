using Aspose.App.Diagram.Api.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Aspose.App.Diagram.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Filters.Add(new CustomExceptionFilterAttribute());
            GlobalConfiguration.Configuration.Filters.Add(new CustomActionFilterAttribute());

            DiagramConfig.RegisterGlobalDiagram();
        }
    }
}
