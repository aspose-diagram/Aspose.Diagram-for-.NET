using Aspose.Diagram;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.OLE_Objects
{
    public class ManipulateObjects
    {
        public static void Run()
        {
            // ExStart:ManipulateObjects
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_OLEObjects();

            // Load a Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // Get page of the Visio diagram by name
            Aspose.Diagram.Page page = diagram.Pages.GetPage("Page-1");
            // Get shape of the Visio diagram by ID
            Aspose.Diagram.Shape OLE_Shape = page.Shapes.GetShape(2);

            // Filter shapes by type Foreign
            if (OLE_Shape.Type == Aspose.Diagram.TypeValue.Foreign)
            {
                if (OLE_Shape.ForeignData.ForeignType == ForeignType.Object)
                {
                    Stream Ole_stream = new MemoryStream(OLE_Shape.ForeignData.ObjectData);
                    // Get format of the OLE file object
                    Aspose.Words.FileFormatInfo info = Aspose.Words.FileFormatUtil.DetectFileFormat(Ole_stream);
                    if (info.LoadFormat == Aspose.Words.LoadFormat.Doc || info.LoadFormat == Aspose.Words.LoadFormat.Docx)
                    {
                        // Modify an OLE object
                        var doc = new Aspose.Words.Document(new MemoryStream(OLE_Shape.ForeignData.ObjectData));
                        doc.Range.Replace("testing", "Aspose", false, true);
                        MemoryStream outStream = new MemoryStream();
                        doc.Save(outStream, Aspose.Words.SaveFormat.Docx);
                        // Save back an OLE object
                        OLE_Shape.ForeignData.ObjectData = outStream.ToArray();
                    }
                }
            }
            // Save Visio diagram
            diagram.Save(dataDir + "ManipulateObjects_out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:ManipulateObjects
        }
    }
}
