using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.App.Diagram.Pages.PageModels
{
    public class FileFormatModel
    {
        public FileFormatModel(FileFormat fileFormat)
        {
            this.Name = fileFormat.name;
            this.URL = fileFormat.fileFormatComUrl;
            this.Description = fileFormat.description;
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public string URL { get; set; }
    }

    public class FileFormat
    {
        public string fileFormatComUrl { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string extension { get; set; }
    }
}