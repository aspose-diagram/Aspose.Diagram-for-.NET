using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_Shapes
{
    public class RetrieveTheParentShape
    {
        public static void Run()
        {
            // ExStart:RetrieveTheParentShape
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();
            // Call a Diagram class constructor to load the VSD diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // get a sub-shape by page name, group shape ID, and then sub-shape ID
            Shape shape = diagram.Pages.GetPage("Page-3").Shapes.GetShape(13).Shapes.GetShape(2);
            Shape parentShape = shape.ParentShape;
            Console.WriteLine("Parent Shape's Properties:");
            Console.WriteLine("Shape ID: " + parentShape.ID);
            Console.WriteLine("Shape Name: " + parentShape.Name);
            Console.WriteLine("Shape Type: " + parentShape.Type);
            // ExEnd:RetrieveTheParentShape
        }
    }
}
