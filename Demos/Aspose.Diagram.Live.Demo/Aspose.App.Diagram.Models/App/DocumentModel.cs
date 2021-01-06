using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.App.Diagram.Models.App
{
    public class DocumentModel
    {
        public DocumentModel() {
        }

        public DocumentModel(string filePath)
        {
            this.FilePath = filePath;
            this.FileName = Path.GetFileName(filePath);
        }
        public string FileName { get; set; }

        public string FilePath { get; set; }

    }
}
