using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_with_Window_Elements
{
    public class AddSupportOfVisualAids
    {
        public static void Run() 
        {
            // ExStart:AddSupportOfVisualAids
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WindowElements();

            // load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // get window object by index
            Window window = diagram.Windows[0];
            // check dynamic grid option
            window.DynamicGridEnabled = BOOL.True;
            // check connection points option
            window.ShowConnectionPoints = BOOL.True;
            
            // save visio drawing
            diagram.Save(dataDir + "AddSupportOfVisualAids_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:AddSupportOfVisualAids
        }
    }
}
