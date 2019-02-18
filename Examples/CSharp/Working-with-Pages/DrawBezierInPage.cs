using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Pages
{
    public class DrawBezierInPage
    {
        public static void Run()
        {
            // ExStart:DrawBezierInPage
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_VisioPages();
            // Load diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            //Initiazlie a new PointF[]
            PointF[] ps = new PointF[] { new PointF(1, 1), new PointF(2, 2), new PointF(3.79949292203676f, 0) };
            //Draw brezier in diagram
            diagram.Pages[0].DrawBezier(1, 1, 2, 2, ps);
            // Save diagram
            diagram.Save(dataDir + "DrawBezierInPage_out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:DrawBezierInPage
        }
    }
}
