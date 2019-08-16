using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Pages
{
    class DrawSplineInPage
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_VisioPages();
            // Load diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            //Initiazlie a new PointF[]
            PointF[] ps = new PointF[] { new PointF(0, 0.3270758925347308f),
                             new PointF(0.2926845121364643f, 0.3581517392187368f),
                             new PointF(0.6526026522346893f, 0.4640748257705201f),
                             new PointF(1f, 0.327075892534732f) };
            //Draw brezier in diagram
            diagram.Pages[0].DrawSpline(1, 1, 2, 2, ps);
            // Save diagram
            diagram.Save(dataDir + "DrawSplineInPage.vsdx", SaveFileFormat.VSDX);
            // ExEnd:1
        }
    }
}
