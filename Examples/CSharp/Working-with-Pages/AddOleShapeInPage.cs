using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Pages
{
    public class AddOleShapeInPage
    {
        public static void Run()
        {
            // ExStart:AddOleShapeInPage
            Diagram diagram = new Diagram();

            // Get page object by index 
            Aspose.Diagram.Page page0 = diagram.Pages[0];
            // set pinX, pinY, width and height 
            double pinX = 2, pinY = 2, width = 4, hieght = 3;

            // Import ole as Visio shape word
            page0.AddShape(pinX, pinY, width, hieght, new FileStream("imageword.emf", FileMode.OpenOrCreate), new FileStream("1.doc", FileMode.OpenOrCreate));

            // excel
            page0.AddShape(1, 1, 2, 2, new FileStream("imageexcel.emf", FileMode.OpenOrCreate), new FileStream("1.xlsx", FileMode.OpenOrCreate));

            byte[] image = CopyStreamToByteArray("image.emf");
            MemoryStream imageStream = new MemoryStream(image);

            byte[] ole = CopyStreamToByteArray("embeddedPPT.ppt");
            MemoryStream oleStream = new MemoryStream(ole);
            //ppt
            Aspose.Diagram.FileFormatInfo fi = Aspose.Diagram.FileFormatUtil.DetectFileFormat(oleStream);
            page0.AddShape(pinX, pinY, width, hieght, new FileStream("imagepptx.emf", FileMode.OpenOrCreate), new FileStream("2.pptx", FileMode.OpenOrCreate));

            page0.AddShape(pinX, pinY, width, hieght, imageStream, oleStream);

            // Save Visio diagram 
            diagram.Save("out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:AddOleShapeInPage
        }
    }
}
