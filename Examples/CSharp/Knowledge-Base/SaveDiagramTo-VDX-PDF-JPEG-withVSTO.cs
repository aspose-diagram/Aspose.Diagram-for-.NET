using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Visio = Microsoft.Office.Interop.Visio;

namespace Aspose.Diagram.Examples.CSharp.Knowledge_Base
{
    public class SaveDiagramTo_VDX_PDF_JPEG_withVSTO
    {
        public static void Run() 
        {
            // ExStart:SaveDiagramTo_VDX_PDF_JPEG_withVSTO
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_KnowledgeBase();

            // Create Visio Application Object
            Visio.Application vsdApp = new Visio.Application();

            // Make Visio Application Invisible
            vsdApp.Visible = false;

            // Create a document object and load a diagram
            Visio.Document vsdDoc = vsdApp.Documents.Open(dataDir + "Drawing1.vsd");

            // Save the VDX diagram
            vsdDoc.SaveAs(dataDir + "SaveDiagramToVDXwithVSTO_Out.vdx");

            // Save as PDF file
            vsdDoc.ExportAsFixedFormat(Visio.VisFixedFormatTypes.visFixedFormatPDF,
                dataDir + "SaveDiagramToPDFwithVSTO_Out.pdf", Visio.VisDocExIntent.visDocExIntentScreen,
                Visio.VisPrintOutRange.visPrintAll, 1, vsdDoc.Pages.Count, false, true,
                true, true, true, System.Reflection.Missing.Value);

            Visio.Page vsdPage = vsdDoc.Pages[1];

            // Save as JPEG Image
            vsdPage.Export(dataDir + "SaveDiagramToJPGwithVSTO_Out.jpg");

            // Quit Visio Object
            vsdApp.Quit();
            // ExEnd:SaveDiagramTo_VDX_PDF_JPEG_withVSTO
        }
    }
}
