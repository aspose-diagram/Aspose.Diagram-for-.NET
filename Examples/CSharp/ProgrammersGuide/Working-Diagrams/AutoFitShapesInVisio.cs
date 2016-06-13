using Aspose.Diagram;
using Aspose.Diagram.Saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_Diagrams
{
    public class AutoFitShapesInVisio
    {
        public static void Run()
        {
            // ExStart:AutoFitShapesInVisio
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Diagrams();

            // load a Visio diagram
            Diagram diagram = new Diagram(dataDir + "BFlowcht.vsdx");

            // use saving options
            DiagramSaveOptions options = new DiagramSaveOptions(SaveFileFormat.VSDX);
            // set Auto fit page property
            options.AutoFitPageToDrawingContent = true;

            // save Visio diagram
            diagram.Save(dataDir + "AutoFitShapesInVisio_Out.vsdx", options);
            // ExEnd:AutoFitShapesInVisio
        }
    }
}
