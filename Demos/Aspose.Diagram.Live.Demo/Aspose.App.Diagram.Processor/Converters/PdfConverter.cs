using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Diagram;

namespace Aspose.App.Diagram.Processor
{
    public class PdfConverter : AbstractConverter
    {
        protected override List<string> SaveDocument(Aspose.Diagram.Diagram diagram, SaveOpts saveOpts, string filePath)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                diagram.Save(stream, SaveFileFormat.PDF);
                stream.Position = 0;
                var pdf = new Aspose.Pdf.Document(stream);
                pdf.Save(Path.ChangeExtension(filePath, saveOpts.PdfSaveFileFormat.ToString().ToLower()), saveOpts.PdfSaveFileFormat);
            }
            return null;
        }
    }
}
