using Aspose.Diagram;
using Aspose.Diagram.Saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_Diagrams
{
    public class AutoFitShapesInVisio
    {
        public static void Run()
        {
            // ExStart:AutoFitShapesInVisio
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Diagrams();

            // Load a Visio diagram
            Diagram diagram = new Diagram(dataDir + "BFlowcht.vsdx");

            // Use saving options
            DiagramSaveOptions options = new DiagramSaveOptions(SaveFileFormat.VSDX);
            // Set Auto fit page property
            options.AutoFitPageToDrawingContent = true;

            // Save Visio diagram
            diagram.Save(dataDir + "AutoFitShapesInVisio_out.vsdx", options);
            // ExEnd:AutoFitShapesInVisio
        }
    }
}
