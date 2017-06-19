using Aspose.Diagram.Saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.OS_Fonts_Location
{
    class NotificationofMissingFonts
    {
        public static void Run()
        {
            // ExStart:NotificationofMissingFonts
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Intro();

            // load the document to render.
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            
            // initialize PdfSaveOptions object
            PdfSaveOptions saveOp = new PdfSaveOptions();
            // create a new class implementing IWarningCallback which collect any warnings produced during drawing save.
            HandleDocumentWarnings callback = new HandleDocumentWarnings();
            saveOp.WarningCallback = callback;

            // pass the save options along with the save path to the save method.
            diagram.Save(dataDir + "NotificationofMissingFonts_Out.pdf", saveOp);

            // ExEnd:NotificationofMissingFonts
        }

    }
}
