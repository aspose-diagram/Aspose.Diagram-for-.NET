using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_Shapes
{
    public class ChangeShapeSize
    {
        public static void Run()
        {
            //ExStart:ChangeShapeSize
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // call a Diagram class constructor to load the VSDX diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // get page by name
            Page page = diagram.Pages.GetPage("Page-1");
            // get shape by id
            Shape shape = page.Shapes.GetShape(796);
            // alter the size of Shape
            shape.SetWidth(2 * shape.XForm.Width.Value);
            shape.SetHeight(2 * shape.XForm.Height.Value);
            // save diagram
            diagram.Save(dataDir + "ChangeShapeSize_Out.vsdx", SaveFileFormat.VSDX);
            //ExEnd:ChangeShapeSize
        }
    }
}
