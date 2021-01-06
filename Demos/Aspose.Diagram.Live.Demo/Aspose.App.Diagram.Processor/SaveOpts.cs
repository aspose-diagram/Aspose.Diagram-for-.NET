using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.App.Diagram.Processor
{
    public class SaveOpts
    {
        public bool IsBridge { get; set; }
        public Aspose.Diagram.SaveFileFormat DiagramSaveFileFormat { get; set; }

        public Aspose.Pdf.SaveFormat PdfSaveFileFormat { get; set; }
    }
}
