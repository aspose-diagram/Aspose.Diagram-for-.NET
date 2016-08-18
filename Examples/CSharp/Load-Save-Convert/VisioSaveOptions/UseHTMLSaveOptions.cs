using Aspose.Diagram;
using Aspose.Diagram.Saving;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Load_Save_Convert.VisioSaveOptions
{
    public class UseHTMLSaveOptions
    {
        public static void Run()
        {
            // ExStart:UseHTMLSaveOptions
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();

            // Call the diagram constructor to a VSDX diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // Options when saving a diagram into the HTML format
            HTMLSaveOptions options = new HTMLSaveOptions();

            // Summary:
            //     value or the font is not installed locally, they may appear as a block,
            //     set the DefaultFont such as MingLiu or MS Gothic to show these
            //     characters.
            options.DefaultFont = "MS Gothic";
            // Sets the number of pages to render in HTML.
            options.PageCount = 2;
            // Sets the 0-based index of the first page to render. Default is 0.
            options.PageIndex = 0;

            // Set page size
            PageSize pgSize = new PageSize(PaperSizeFormat.A1);
            options.PageSize = pgSize;
            // Discard saving background pages of the Visio diagram
            options.SaveForegroundPagesOnly = true;

            // Specify whether to include the toolbar or not. Default value is true.
            options.SaveToolBar = false;
            // Set title of the HTML document
            options.Title = "Title goes here";

            // Save in any supported file format
            diagram.Save(dataDir + "UseHTMLSaveOptions_Out.html", options);

            // Save resultant HTML directly to a stream
            MemoryStream stream = new MemoryStream();
            diagram.Save(stream, SaveFileFormat.HTML);
            // ExEnd:UseHTMLSaveOptions
        }
    }
}
