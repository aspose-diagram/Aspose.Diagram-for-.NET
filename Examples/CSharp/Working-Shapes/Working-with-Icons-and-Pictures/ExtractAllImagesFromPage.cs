using System.IO;
using Aspose.Diagram;
using System;
namespace Aspose.Diagram.Examples.CSharp.Diagrams
{
    public class ExtractAllImagesFromPage
    {
        public static void Run()
        {
            // ExStart:ExtractAllImagesFromPage
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // Call a Diagram class constructor to load a VSD diagram
            Diagram diagram = new Diagram(dataDir + "ExtractAllImagesFromPage.vsd");

            // Enter page index i.e. 0 for first one
            foreach (Shape shape in diagram.Pages[0].Shapes)
            {
                // Filter shapes by type Foreign
                if (shape.Type == Aspose.Diagram.TypeValue.Foreign)
                {
                    using (System.IO.MemoryStream stream = new System.IO.MemoryStream(shape.ForeignData.Value))
                    {
                        // Load memory stream into bitmap object
                        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(stream);

                        // Save bmp here
                        bitmap.Save(dataDir + "ExtractAllImages" + shape.ID + "_Out.bmp");
                    }
                }
            }
            // ExEnd:ExtractAllImagesFromPage
        }
    }
}