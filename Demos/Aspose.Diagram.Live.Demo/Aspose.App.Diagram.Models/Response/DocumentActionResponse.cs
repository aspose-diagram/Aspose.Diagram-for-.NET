using Aspose.App.Diagram.Models.App;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Aspose.App.Diagram.Models.Response
{
    public class DocumentActionResponse : BaseResponse
    {
        public DocumenDownloadInfo Data { get; set; }
    }

    public class DocumenDownloadInfo {
        public DocumenDownloadInfo(string fileName,string folderName)
        {
            this.FileName = fileName;
            this.FolderName = folderName;
        }

        public string FileName { get; set; }
        public string FolderName { get; set; }
    }
}