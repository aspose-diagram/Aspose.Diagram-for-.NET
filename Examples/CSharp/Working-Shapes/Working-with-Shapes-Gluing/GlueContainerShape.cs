using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_Shapes.Working_with_Shapes_Gluing
{
    public class GlueContainerShape
    {
        public static void Run()
        {
            // ExStart:GlueContainerShape
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // Load diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // Get a particular page
            Page page = diagram.Pages.GetPage("Page-1");

            // The ID of shape which is glue from Aspose.Diagram.Shape.
            long shapeFromId = 779;
            // The location on the first connection index where to glue
            int shapeToBeginConnectionIndex = 72;
            // The location on the end connection index where to glue
            int shapeToEndConnectionIndex = 73;
            // The ID of shape where to glue to Aspose.Diagram.Shape.
            long shapeToId = 743;

            // Glue shapes in container
            page.GlueShapesInContainer(shapeFromId, shapeToBeginConnectionIndex, shapeToEndConnectionIndex, shapeToId);

            // Glue shapes in container using connection name
            // page.GlueShapesInContainer(fasId, "U05L", "U05R", cabinetId1);

            // Save diagram
            diagram.Save(dataDir + "GlueContainerShape_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:GlueContainerShape
        }
    }
}
