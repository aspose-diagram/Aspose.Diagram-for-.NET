using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Aspose.App.Diagram.Api.Services
{
    public class AppStorage
    {
        public static string GetSessionRoot(string sessionId)
        {
            var path = Path.Combine(AppConfig.SourceRootDirectory, sessionId);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public static string GetSourceRoot(string sessionId)
        {
            var path = Path.Combine(AppConfig.SourceRootDirectory, sessionId);
            return path;
        }

        public static string GetExportRoot(string sessionId)
        {
            return Path.Combine(AppConfig.ExportRootDirectory, GetDocumentRoot(sessionId));
        }

        public static string GetDocumentRoot(string sessionId) {
            return Path.Combine(sessionId, "documents");
        }

        public static string GetExportPath(string sessionId, string fileName)
        {
            return Path.Combine(AppConfig.ExportRootDirectory, sessionId, Path.GetFileNameWithoutExtension(fileName));
        }
    }
}