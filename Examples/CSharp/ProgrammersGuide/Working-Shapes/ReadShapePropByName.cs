using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_Shapes
{
    public class ReadShapePropByName
    {
        public static void Run()
        {
            //ExStart:ReadShapePropByName
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // call a Diagram class constructor to load the VSDX diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // get page by name
            Page page = diagram.Pages.GetPage("Page-3");

            foreach (Aspose.Diagram.Shape shape in page.Shapes)
            {
                if (shape.Name == "Process1")
                {
                    Prop property = shape.Props.GetProp("Name1");
                    Console.WriteLine(property.Label.Value + ": " + property.Value.Val);
                }
            }
            //ExEnd:ReadShapePropByName
        }
    }
}
