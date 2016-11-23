using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_Shapes.Working_with_Icons_and_Pictures
{
    public class ReplaceShapePicture
    {
        public static void Run()
        {
            // ExStart:ReplaceShapePicture
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // Call a Diagram class constructor to load the VSD diagram
            Diagram diagram = new Diagram(dataDir + "ExtractAllImagesFromPage.vsd");
            // Convert image into bytes array
            byte[] imageBytes = File.ReadAllBytes(dataDir + "Picture.png");

            // Enter page index i.e. 0 for first one
            foreach (Shape shape in diagram.Pages[0].Shapes)
            {
                // Filter shapes by type Foreign
                if (shape.Type == Aspose.Diagram.TypeValue.Foreign)
                {
                    using (System.IO.MemoryStream stream = new System.IO.MemoryStream(shape.ForeignData.Value))
                    {
                        // Replace picture shape
                        shape.ForeignData.Value = imageBytes;
                    }
                }
            }

            // Save diagram
            diagram.Save(dataDir + "ReplaceShapePicture_out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:ReplaceShapePicture
        }
    }
}
