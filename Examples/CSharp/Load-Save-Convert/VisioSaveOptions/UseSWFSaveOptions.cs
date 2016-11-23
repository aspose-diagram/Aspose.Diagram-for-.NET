using Aspose.Diagram;
using Aspose.Diagram.Saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Load_Save_Convert.VisioSaveOptions
{
    public class UseSWFSaveOptions
    {
        public static void Run()
        {
            // ExStart:UseSWFSaveOptions
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();

            // Call the diagram constructor to load diagram from a VSD file
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            SWFSaveOptions options = new SWFSaveOptions();

            // Summary:
            //     value or the font is not installed locally, they may appear as a block,
            //     set the DefaultFont such as MingLiu or MS Gothic to show these
            //     characters.
            options.DefaultFont = "MS Gothic";

            // Sets the number of pages to render in SWF.
            options.PageCount = 2;

            // Sets the 0-based index of the first page to render. Default is 0.
            options.PageIndex = 0;
            // Discard saving background pages of the Visio diagram
            options.SaveForegroundPagesOnly = true;
            // Specify whether the generated SWF document should include the integrated document viewer or not.
            options.ViewerIncluded = true;

            diagram.Save(dataDir + "UseSWFSaveOptions_out.swf", options);
            // ExEnd:UseSWFSaveOptions
        }
    }
}
