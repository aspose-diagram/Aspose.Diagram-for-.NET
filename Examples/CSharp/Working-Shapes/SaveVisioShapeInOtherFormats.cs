using Aspose.Diagram;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_Shapes
{
    public class SaveVisioShapeInOtherFormats
    {
        public static void Run()
        {
            // ExStart:SaveVisioShapeInOtherFormats
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // Call a Diagram class constructor to load the VSDX diagram
            Diagram srcVisio = new Diagram(dataDir + "Drawing1.vsdx");

            double shapeWidth = 0;
            double shapeHeight = 0;

            // Get Visio page
            Aspose.Diagram.Page srcPage = srcVisio.Pages.GetPage("Page-3");
            // Remove background page
            srcPage.BackPage = null;

            // Get hash table of shapes, it holds id and name
            Hashtable remShapes = new Hashtable();
            // Hashtable<Long, String> remShapes = new Hashtable<Long, String>();
            foreach (Aspose.Diagram.Shape shape in srcPage.Shapes)
                // For the normal shape
                remShapes.Add(shape.ID, shape.Name);

            // Iterate through the hash table
            foreach (DictionaryEntry shapeEntry in remShapes)
            {
                long key = (long)shapeEntry.Key;
                string val = (string)shapeEntry.Value;
                Aspose.Diagram.Shape shape = srcPage.Shapes.GetShape(key);
                // Check of the shape name
                if (val.Equals("GroupShape1"))
                {
                    // Move shape to the origin corner
                    shapeWidth = shape.XForm.Width.Value;
                    shapeHeight = shape.XForm.Height.Value;
                    shape.MoveTo(shapeWidth * 0.5, shapeHeight * 0.5);
                    // Trim page size
                    srcPage.PageSheet.PageProps.PageWidth.Value = shapeWidth;
                    srcPage.PageSheet.PageProps.PageHeight.Value = shapeHeight;
                }
                else
                {
                    // Remove shape from the Visio page and hash table
                    srcPage.Shapes.Remove(shape);
                }
            }
            remShapes.Clear();

            // Specify saving options
            Aspose.Diagram.Saving.PdfSaveOptions opts = new Aspose.Diagram.Saving.PdfSaveOptions();
            // Set page count to save
            opts.PageCount = 1;
            // Set starting index of the page
            opts.PageIndex = 1;
            // Save it
            srcVisio.Save(dataDir + "SaveVisioShapeInOtherFormats_Out.pdf", opts);
            // ExEnd:SaveVisioShapeInOtherFormats
        }
    }
}
