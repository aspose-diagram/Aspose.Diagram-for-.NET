using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_Shapes
{
    public class InheritProps
    {
        public static void Run()
        {
            // ExStart:InheritProps
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // Call a Diagram class constructor to load the VSDX diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // Get page by name
            Page page = diagram.Pages.GetPage("Page-3");

            foreach (Aspose.Diagram.Shape shape in page.Shapes)
            {
                foreach (Aspose.Diagram.Prop prop in shape.InheritProps)
                {
                    Console.WriteLine(prop.Name);
                    Console.WriteLine(prop.Label.Value);
                    Console.WriteLine(prop.Prompt.Value);
                    Console.WriteLine(prop.Type.Value.ToString());
                    Console.WriteLine(prop.Value.Val);
                    Console.WriteLine(prop.Format.Value);
                }
            }
            // ExEnd:InheritProps
        }
    }
}
