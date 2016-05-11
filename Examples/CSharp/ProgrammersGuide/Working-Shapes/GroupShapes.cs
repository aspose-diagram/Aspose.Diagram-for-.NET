using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_Shapes
{
    public class GroupShapes
    {
        public static void Run()
        {
            //ExStart:GroupShapes
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // load a Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // get page by name
            Page page = diagram.Pages.GetPage("Page-3");

            // Initialize an array of shapes
            Aspose.Diagram.Shape[] ss = new Aspose.Diagram.Shape[3];

            // extract and assign shapes to the array
            ss[0] = page.Shapes.GetShape(15);
            ss[1] = page.Shapes.GetShape(16);
            ss[2] = page.Shapes.GetShape(17);

            // mark array shapes as group
            page.Shapes.Group(ss);

            // save visio diagram
            diagram.Save(dataDir + "GroupShapes_Out.vsdx", SaveFileFormat.VSDX);
            //ExEnd:GroupShapes
        }
    }
}
