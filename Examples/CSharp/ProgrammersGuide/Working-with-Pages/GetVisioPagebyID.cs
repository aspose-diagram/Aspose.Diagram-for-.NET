using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.ProgrammersGuide.Working_with_Pages
{
    public class GetVisioPagebyID
    {
        public static void Run()
        {
            // ExStart:GetVisioPagebyID
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_VisioPages();

            // Call the diagram constructor to load diagram from a VDX file
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // Set page id
            int pageid = 2;
            // Get page object by id
            Page page2 = diagram.Pages.GetPage(pageid);
            // ExEnd:GetVisioPagebyID
        }
    }
}
