using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_Shapes
{
    public class RotateVisioShape
    {
        public static void Run()
        {
            // ExStart:RotateVisioShape
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // Call a Diagram class constructor to load the VSDX diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // Get page by name
            Page page = diagram.Pages.GetPage("Page-3");
            // Get shape by id
            Shape shape = page.Shapes.GetShape(16);

            // Add a shape and set the angle
            shape.SetAngle(190);

            // Save diagram
            diagram.Save(dataDir + "RotateVisioShape_out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:RotateVisioShape
        }
    }
}
