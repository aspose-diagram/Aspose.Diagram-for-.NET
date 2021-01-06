using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Aspose.App.Diagram.Pages
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapPageRoute(
               "AsposeToolsViewerAppRoute",
               "diagram/view/{foldername}",
               "~/Diagram/ViewerApp/Default.aspx"
           );

            routes.MapPageRoute(
               "AsposeToolsEditorAppRoute",
               "diagram/edit/{foldername}/{filename}",
               "~/Diagram/EditorApp/editor.html"
           );

            routes.MapPageRoute(
               "AsposeToolsEditorNewAppRoute",
               "diagram/edit/",
               "~/Diagram/EditorApp/editor.html"
           );

            routes.MapRoute(
              name: "DiagramFileFormatRoute",
              url: "{controller}/{action}/{fileformat}",
              defaults: new { controller = "diagram", action = "Index" }
          );

            routes.MapRoute(
             name: "DiagramRoute",
             url: "{controller}/{action}",
             defaults: new { controller = "diagram", action = "Index" }
         );
        }
    }
}
