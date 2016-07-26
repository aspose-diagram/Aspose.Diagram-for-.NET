using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_Shapes
{
    public class GetAllConnectedShapes
    {
        public static void Run()
        {
            // ExStart:GetAllConnectedShapes
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // call a Diagram class constructor to load the VSDX diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // get shape by id
            Shape shape = diagram.Pages.GetPage("Page-3").Shapes.GetShape(16);
            // get connected shapes
            long[] connectedShapeIds = shape.ConnectedShapes(ConnectedShapesFlags.ConnectedShapesAllNodes, null);

            foreach (long id in connectedShapeIds)
            {
                shape = diagram.Pages.GetPage("Page-3").Shapes.GetShape(id);
                Console.WriteLine("ID: " + shape.ID + "\t\t Name: " + shape.Name);
            }
            // ExEnd:GetAllConnectedShapes
        }
    }
}
