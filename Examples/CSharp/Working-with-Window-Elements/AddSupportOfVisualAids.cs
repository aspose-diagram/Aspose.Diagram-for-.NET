using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Window_Elements
{
    public class AddSupportOfVisualAids
    {
        public static void Run() 
        {
            // ExStart:AddSupportOfVisualAids
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WindowElements();

            // Load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // Get window object by index
            Window window = diagram.Windows[0];
            // Check dynamic grid option
            window.DynamicGridEnabled = BOOL.True;
            // Check connection points option
            window.ShowConnectionPoints = BOOL.True;
            
            // Save visio drawing
            diagram.Save(dataDir + "AddSupportOfVisualAids_out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:AddSupportOfVisualAids
        }
    }
}
