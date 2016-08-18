using Aspose.Diagram;
using Aspose.Diagram.Saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Load_Save_Convert.VisioSaveOptions
{
    public class UseSVGSaveOptions
    {
        public static void Run()
        {
            // ExStart:UseSVGSaveOptions
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();

            // Call the diagram constructor to load diagram from a VSD file
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            SVGSaveOptions options = new SVGSaveOptions();

            // Summary:
            //     value or the font is not installed locally, they may appear as a block,
            //     set the DefaultFont such as MingLiu or MS Gothic to show these
            //     characters.
            options.DefaultFont = "MS Gothic";
            // Sets the 0-based index of the first page to render. Default is 0.
            options.PageIndex = 0;

            // Set page size
            PageSize pgSize = new PageSize(PaperSizeFormat.A1);
            options.PageSize = pgSize;

            diagram.Save(dataDir + "UseSVGSaveOptions_Out.svg", options);
            // ExEnd:UseSVGSaveOptions
        }
    }
}
