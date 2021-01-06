using System;
using System.Data;
using System.Configuration;
using System.Web;

/// <summary>
/// Summary description for Configuration
/// </summary>
namespace Aspose.App.Diagram.Pages.Config
{
    public static class AppConfiguration
    {
        public static string PageUrl;
        public static string ApiUrl;

        static AppConfiguration()
        {
            PageUrl = ConfigurationManager.AppSettings["PageUrl"];
            ApiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        }
    }
}
