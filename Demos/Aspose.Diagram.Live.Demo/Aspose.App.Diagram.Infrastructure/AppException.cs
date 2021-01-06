using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.App.Diagram.Infrastructure
{
    public class AppException:Exception
    {
        public string SessionId;

        public AppException(string sessionId, string message) : base(message)
        {
            this.SessionId = sessionId;
        }
    }
}
