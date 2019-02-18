using System.Drawing;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Pages
{
    public class DrawPolylineInPage
    {
        public static void Run()
        {
            // ExStart:DrawPolylineInPage
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_VisioPages();
            // Load diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            
            //Initiazlie a new PointF[]
            PointF[] ps = new PointF[] { new PointF(1, 1), new PointF(2, 2), new PointF(3.79949292203676f, 0) };
            //Draw polyline in page
            diagram.Pages[0].DrawPolyline(1, 1, 2, 2, ps);

            // Save diagram
            diagram.Save(dataDir + "DrawPolylineInPage_out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:DrawPolylineInPage
        }
    }
}
