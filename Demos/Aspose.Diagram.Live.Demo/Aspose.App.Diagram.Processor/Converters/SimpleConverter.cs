using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Diagram;

namespace Aspose.App.Diagram.Processor
{
    public class SimpleConverter : AbstractConverter
    {
        protected override List<string> SaveDocument(Aspose.Diagram.Diagram diagram, SaveOpts saveOpts, string filePath)
        {
            diagram.Save(filePath, saveOpts.DiagramSaveFileFormat);
            return null;
        }
    }
}
