using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_Shapes.Working_with_Icons_and_Pictures
{
    public class GetShapeIcon
    {
        public static void Run()
        {
            // ExStart:GetShapeIcon
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // Load stencil file to a diagram object
            Diagram stencil = new Diagram(dataDir + "Timeline.vss");
            // Get master
            Master master = stencil.Masters.GetMaster(1);

            using (System.IO.MemoryStream stream = new System.IO.MemoryStream(master.Icon))
            {
                // Load memory stream into bitmap object
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(stream);
                // Save as png format
                bitmap.Save(dataDir + "MasterIcon_Out.png", System.Drawing.Imaging.ImageFormat.Png);
            }
            // ExEnd:GetShapeIcon
        }
    }
}
