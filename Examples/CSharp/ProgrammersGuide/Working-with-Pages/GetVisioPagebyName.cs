using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.ProgrammersGuide.Working_with_Pages
{
    public class GetVisioPagebyName
    {
        public static void Run()
        {
            // ExStart:GetVisioPagebyName
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_VisioPages();

            // Call the diagram constructor to load diagram from a VSDX file
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // Set page name
            string pageName = "Flow 2";
            // Get page object by name
            Page page2 = diagram.Pages.GetPage(pageName);
            // ExEnd:GetVisioPagebyName
        }
    }
}
