using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.App.Diagram.Api.Services
{
    public class AppSession
    {
        public static string CreateSessionId() {
            return Guid.NewGuid().ToString();
        }
    }
}