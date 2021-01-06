using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.App.Diagram.Infrastructure
{
    public class NLogger
    {
        protected static NLog.Logger AppLogger = NLog.LogManager.GetLogger("AppLogger");

        public static void Info(string info)
        {
            AppLogger.Info(info);
        }

        public static void Error(Exception ex,string sessionId,string action)
        {
            AppLogger.Error($"[sessionId:{sessionId}][action:{action}]{ex.Message}");
        }

        public static void Debug(string message)
        {
            AppLogger.Debug(message);
        }

        public static void InternalServerError(Exception ex)
        {
            var AppLogger = LogManager.GetLogger("InternalServerErrorLogger");
            AppLogger.Error($"[{ex.Message}]-{ex.StackTrace}");
        }
    }
}
