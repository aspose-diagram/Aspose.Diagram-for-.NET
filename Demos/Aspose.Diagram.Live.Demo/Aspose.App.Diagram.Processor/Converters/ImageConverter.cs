using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Diagram;
using Aspose.Diagram.Saving;

namespace Aspose.App.Diagram.Processor
{
    public class ImageConverter : AbstractConverter
    {
        protected override List<string> SaveDocument(Aspose.Diagram.Diagram diagram, SaveOpts saveOpts, string filePath)
        {
            var pageCount = diagram.Pages.Count;
            if (pageCount <= 1)
            {
                diagram.Save(filePath, saveOpts.DiagramSaveFileFormat);
                return null;
            }
            else
            {
                ImageSaveOptions saveOptions = new ImageSaveOptions(saveOpts.DiagramSaveFileFormat);
                var clilds = new List<string>();
                for (int index = 0; index < pageCount; index++)
                {
                    var page = diagram.Pages[index];
                    var dir = Path.GetDirectoryName(filePath);
                    var childPath = Path.Combine(dir, $"{Path.GetFileNameWithoutExtension(filePath)}_{page.Name.FormatPageName()}{Path.GetExtension(filePath)}");
                    saveOptions.PageIndex = index;
                    diagram.Save(childPath, saveOptions);
                    clilds.Add(childPath);
                }
                return clilds;
            }
        }
    }
}
