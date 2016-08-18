using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_Shapes
{
    public class ReadAllShapeProps
    {
        public static void Run()
        {
            // ExStart:ReadAllShapeProps
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // Call a Diagram class constructor to load the VSDX diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // Get page by name
            Page page = diagram.Pages.GetPage("Page-3");

            foreach (Aspose.Diagram.Shape shape in page.Shapes)
            {
                if (shape.Name == "Process1")
                {
                    foreach (Prop property in shape.Props)
                    {
                        Console.WriteLine(property.Label.Value + ": " + property.Value.Val);
                    }
                    break;
                }
            }
            // ExEnd:ReadAllShapeProps
        }
    }
}
