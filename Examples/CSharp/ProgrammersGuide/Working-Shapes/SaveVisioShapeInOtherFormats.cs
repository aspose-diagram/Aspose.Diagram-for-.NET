using Aspose.Diagram;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_Shapes
{
    public class SaveVisioShapeInOtherFormats
    {
        public static void Run()
        {
            // ExStart:SaveVisioShapeInOtherFormats
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // call a Diagram class constructor to load the VSDX diagram
            Diagram srcVisio = new Diagram(dataDir + "Drawing1.vsdx");

            double shapeWidth = 0;
            double shapeHeight = 0;

            // get Visio page
            Aspose.Diagram.Page srcPage = srcVisio.Pages.GetPage("Page-3");
            // remove background page
            srcPage.BackPage = null;

            // get hash table of shapes, it holds id and name
            Hashtable remShapes = new Hashtable();
            // Hashtable<Long, String> remShapes = new Hashtable<Long, String>();
            foreach (Aspose.Diagram.Shape shape in srcPage.Shapes)
                // for the normal shape
                remShapes.Add(shape.ID, shape.Name);

            // iterate through the hash table
            foreach (DictionaryEntry shapeEntry in remShapes)
            {
                long key = (long)shapeEntry.Key;
                string val = (string)shapeEntry.Value;
                Aspose.Diagram.Shape shape = srcPage.Shapes.GetShape(key);
                // check of the shape name
                if (val.Equals("GroupShape1"))
                {
                    // move shape to the origin corner
                    shapeWidth = shape.XForm.Width.Value;
                    shapeHeight = shape.XForm.Height.Value;
                    shape.MoveTo(shapeWidth * 0.5, shapeHeight * 0.5);
                    // trim page size
                    srcPage.PageSheet.PageProps.PageWidth.Value = shapeWidth;
                    srcPage.PageSheet.PageProps.PageHeight.Value = shapeHeight;
                }
                else
                {
                    // remove shape from the Visio page and hash table
                    srcPage.Shapes.Remove(shape);
                }
            }
            remShapes.Clear();

            // specify saving options
            Aspose.Diagram.Saving.PdfSaveOptions opts = new Aspose.Diagram.Saving.PdfSaveOptions();
            // set page count to save
            opts.PageCount = 1;
            // set starting index of the page
            opts.PageIndex = 1;
            // save it
            srcVisio.Save(dataDir + "SaveVisioShapeInOtherFormats_Out.pdf", opts);
            // ExEnd:SaveVisioShapeInOtherFormats
        }
    }
}
