using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_Shapes.Working_with_Shapes_Gluing
{
    public class GetGluedConnectors
    {
        public static void Run()
        {
            //ExStart:GetGluedConnectors
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // call a Diagram class constructor to load the VSD diagram
            Diagram diagram = new Diagram(dataDir + "RetrieveShapeInfo.vsd");
            // get shape by an ID
            Shape shape = diagram.Pages[0].Shapes.GetShape(90);
            // get all glued 1D shapes
            long[] gluedShapeIds = shape.GluedShapes(GluedShapesFlags.GluedShapesAll1D, null, null);

            // display shape ID and name
            foreach (long id in gluedShapeIds)
            {
                shape = diagram.Pages[0].Shapes.GetShape(id);
                Console.WriteLine("ID: " + shape.ID + "\t\t Name: " + shape.Name);
            }
            //ExEnd:GetGluedConnectors
        }
    }
}
