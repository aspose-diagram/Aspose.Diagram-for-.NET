using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.App.Diagram.Models.Response
{
    public class BaseResponse: BaseModel
    {
        public int Code { get; set; } = 200;

        public string Message { get; set; }

        public string Action { set; get; }
    }
}