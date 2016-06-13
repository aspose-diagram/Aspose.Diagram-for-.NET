using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_with_Pages
{
    public class SetVisioPageOrientation
    {
        public static void Run()
        {
            // ExStart:SetVisioPageOrientation
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_VisioPages();

            // initialize the new visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // get Visio page
            Aspose.Diagram.Page page = diagram.Pages.GetPage("Flow 1");
            // page orientation
            page.PageSheet.PrintProps.PrintPageOrientation.Value = PrintPageOrientationValue.Landscape;
            // save Visio
            diagram.Save(dataDir + "SetPageOrientation_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:SetVisioPageOrientation
        }
    }
}
