using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_Shapes.Working_with_Icons_and_Pictures
{
    public class InsertImageInVisio
    {
        public static void Run()
        {
            // ExStart:InsertImageInVisio
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // Create a new diagram
            Diagram diagram = new Diagram();

            // Get page object by index
            Page page0 = diagram.Pages[0];
            // Set pinX, pinY, width and height
            double pinX = 2, pinY = 2, width = 4, hieght = 3;

            // Import Bitmap image as Visio shape
            page0.AddShape(pinX, pinY, width, hieght, new FileStream(dataDir + "image.bmp", FileMode.OpenOrCreate));

            // Save Visio diagram
            diagram.Save(dataDir + "InsertImageInVisio_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:InsertImageInVisio
        }
    }
}
