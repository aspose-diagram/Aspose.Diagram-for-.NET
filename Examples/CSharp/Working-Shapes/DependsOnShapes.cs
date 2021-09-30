using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_Shapes
{
    public class DependsOnShapes
    {
        public static void Run()
        {
            // ExStart:DependsOnShapes
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // Call a Diagram class constructor to load the VSDX diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // Get page by name
            Page page = diagram.Pages.GetPage("Page-3");

            foreach (Aspose.Diagram.Shape shape in page.Shapes)
            {
	            long[] shapeids = shape.DependsOnShapes();
	            int count = 0;
	            Console.WriteLine("Depends On");
	            foreach (long id in shapeids)
	            {
	                count++;
	                Console.WriteLine("\t" + count + ")\tID: " + id);
	            }
            }
            // ExEnd:DependsOnShapes
        }
    }
}
