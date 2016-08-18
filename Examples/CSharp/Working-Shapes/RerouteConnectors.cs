using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_Shapes
{
    public class RerouteConnectors
    {
        public static void Run()
        {
            // ExStart:RerouteConnectors
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // Call a Diagram class constructor to load the VSDX diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // Get page by name
            Page page = diagram.Pages.GetPage("Page-3");

            // Get a particular connector shape
            Shape shape = page.Shapes.GetShape(18);
            // Set reroute option
            shape.Layout.ConFixedCode.Value = ConFixedCodeValue.NeverReroute;

            // Save Visio diagram
            diagram.Save(dataDir + "RerouteConnectors_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:RerouteConnectors
        }
    }
}
