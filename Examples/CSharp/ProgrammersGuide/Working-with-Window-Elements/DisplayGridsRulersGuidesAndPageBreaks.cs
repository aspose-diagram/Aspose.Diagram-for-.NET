using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_with_Window_Elements
{
    public class DisplayGridsRulersGuidesAndPageBreaks
    {
        public static void Run() 
        {
            // ExStart:DisplayGridsRulersGuidesAndPageBreaks
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WindowElements();

            // load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // get window object by index
            Window window = diagram.Windows[0];
            // set visibility of grid
            window.ShowGrid = BOOL.True;
            // set visibility of guides
            window.ShowGuides = BOOL.True;
            // set visibility of rulers
            window.ShowRulers = BOOL.True;
            // set visibility of page breaks
            window.ShowPageBreaks = BOOL.True;

            // save diagram
            diagram.Save(dataDir + "DisplayGridsRulersGuidesAndPageBreaks_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:DisplayGridsRulersGuidesAndPageBreaks
        }
    }
}
