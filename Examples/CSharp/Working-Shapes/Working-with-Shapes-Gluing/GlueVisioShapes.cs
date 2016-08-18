using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_Shapes.Working_with_Shapes_Gluing
{
    public class GlueVisioShapes
    {
        public static void Run()
        {
            // ExStart:GlueVisioShapes
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // Load diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // Get a particular page
            Page page = diagram.Pages.GetPage("Page-1");
            // Set shape id
            long shape1_ID = 7;
            long shape2_ID = 494;
            // Glue shapes
            page.GlueShapes(shape1_ID, Aspose.Diagram.Manipulation.ConnectionPointPlace.Center, shape2_ID);

            // Save diagram
            diagram.Save(dataDir + "GlueVisioShapes_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:GlueVisioShapes
        }
    }
}
