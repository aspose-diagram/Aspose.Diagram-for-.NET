using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Window_Elements
{
    public class DisplayGridsRulersGuidesAndPageBreaks
    {
        public static void Run() 
        {
            // ExStart:DisplayGridsRulersGuidesAndPageBreaks
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WindowElements();

            // Load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // Get window object by index
            Window window = diagram.Windows[0];
            // Set visibility of grid
            window.ShowGrid = BOOL.True;
            // Set visibility of guides
            window.ShowGuides = BOOL.True;
            // Set visibility of rulers
            window.ShowRulers = BOOL.True;
            // Set visibility of page breaks
            window.ShowPageBreaks = BOOL.True;

            // Save diagram
            diagram.Save(dataDir + "DisplayGridsRulersGuidesAndPageBreaks_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:DisplayGridsRulersGuidesAndPageBreaks
        }
    }
}
