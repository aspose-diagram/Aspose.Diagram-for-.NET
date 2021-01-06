using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Aspose.App.Diagram.Api.Services
{
    public class AppConfig
    {
        public static string SourceRootDirectory;
        public static string ExportRootDirectory;
        public static string ReportRootDirectory;
        public static string FontRootDirectory;

        static AppConfig() {
            SourceRootDirectory= ConfigurationManager.AppSettings["SourceRootDirectory"];
            ExportRootDirectory = ConfigurationManager.AppSettings["ExportRootDirectory"];
            ReportRootDirectory = ConfigurationManager.AppSettings["ReportRootDirectory"];
            FontRootDirectory = ConfigurationManager.AppSettings["FontRootDirectory"];
        }
    }
}