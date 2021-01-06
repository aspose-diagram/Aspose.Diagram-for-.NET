using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Aspose.App.Diagram.Api.Filters
{
    public class AppHttpContentHelper
    {
        public static readonly string EnterTimeKey = "AppEnterTime";
        public static readonly string RequestIdKey = "AppRequestId";
        public static readonly string SessionIdKey = "AppSessionId";

        internal static string GetRequestStringProperty(HttpRequestMessage Request,string key) {
            object obj = null;
            string value = null;
            Request.Properties.TryGetValue(key, out obj);
            if (obj != null)
            {
                value = obj.ToString();
            }
            return value;
        }

        internal static DateTime GetRequestDateTimetProperty(HttpRequestMessage Request, string key)
        {
            object obj = null;
            DateTime value = DateTime.Now;
            Request.Properties.TryGetValue(key, out obj);
            if (obj != null)
            {
                value = DateTime.FromBinary(Convert.ToInt64(obj));
            }
            return value;
        }
    }
}