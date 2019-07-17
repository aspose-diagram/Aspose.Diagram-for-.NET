using Aspose.Diagram;
using Aspose.Diagram.Saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Load_Save_Convert.VisioSaveOptions
{
    public class UsePDFSaveOptions
    {
        public static void Run()
        {
            // ExStart:UsePDFSaveOptions
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();

            // Call the diagram constructor to load diagram from a VSDX file
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // Options when saving a diagram into the PDF format
            PdfSaveOptions options = new PdfSaveOptions();

            // Discard saving background pages of the Visio diagram
            options.SaveForegroundPagesOnly = true;

            // Specify the quality of JPEG compression for images (if JPEG compression is used). Default is 95.
            options.JpegQuality = 100;

            // Specify default font name
            options.DefaultFont = "Arial";

            // Conformance level for generated PDF document.
            options.Compliance = PdfCompliance.Pdf15;

            // Load the certificate from disk.
            // The other constructor overloads can be used to load certificates from different locations.
            X509Certificate2 cert = new X509Certificate2(dataDir + "certificate.pfx", "12345");
            // Sets a digital signature details. If not set, then no signing will be performed.
            options.DigitalSignatureDetails = new PdfDigitalSignatureDetails(cert, "Test Signing", "Aspose Office", DateTime.Now, PdfDigitalSignatureHashAlgorithm.Sha512);

            // Set encription details
            PdfEncryptionDetails encriptionDetails = new PdfEncryptionDetails("user password", "Owner Password", PdfEncryptionAlgorithm.RC4_128);
            options.EncryptionDetails = encriptionDetails;
            // Sets the number of pages to render in PDF.
            options.PageCount = 2;
            // Sets the 0-based index of the first page to render. Default is 0.
            options.PageIndex = 0;

            // Set page size
            PageSize pgSize = new PageSize(PaperSizeFormat.A1);
            options.PageSize = pgSize;
            // Save in any supported file format
            diagram.Save(dataDir + "UsePDFSaveOptions_out.pdf", options);
            // ExEnd:UsePDFSaveOptions
        }
        /// <summary>
        /// This method is supported by version 19.7 or greater.
        /// </summary>
        public static void SplitMultiPages()
        {
            // ExStart:SplitMultiPages
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();
            // Call the diagram constructor to load diagram from a VSDX file
            Diagram diagram = new Diagram(dataDir + "Network Diagram_start.vsdx");
            // Initialize PdfSaveOptions
            Aspose.Diagram.Saving.PdfSaveOptions options = new Aspose.Diagram.Saving.PdfSaveOptions();
            // set split multipages option
            options.SplitMultiPages = true;
            // save in PDF format
            diagram.Save(dataDir + "SplitMultiPages.pdf", options);
            // ExEnd:SplitMultiPages
        }
        public static void PageSavingCallback()
        {
            // ExStart:SplitMultiPages
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();
            // Call the diagram constructor to load diagram from a VSDX file
            Diagram diagram = new Diagram(dataDir + "Network Diagram_start.vsdx");
            // Initialize PdfSaveOptions
            Aspose.Diagram.Saving.PdfSaveOptions options = new Aspose.Diagram.Saving.PdfSaveOptions();
            // set PageSavingCallback option
            options.PageSavingCallback = new TestDiagramPageSavingCallback();
            // save in PDF format
            diagram.Save(dataDir + "PageSavingCallback.pdf", options);
            // ExEnd:SplitMultiPages

        }
        public class TestDiagramPageSavingCallback : Aspose.Diagram.Saving.IPageSavingCallback
        {
            public void PageStartSaving(Aspose.Diagram.Saving.PageStartSavingArgs args)
            {
                Console.WriteLine("Start saving diagram page {0} of pages {1}", args.PageIndex + 1, args.PageCount);
            }
            public void PageEndSaving(Aspose.Diagram.Saving.PageEndSavingArgs args)
            {
                Console.WriteLine("End saving diagram page {0} of pages {1}", args.PageIndex + 1, args.PageCount);
                //don't output pages after page index 8.
                if (args.PageIndex >= 8)
                {
                    args.HasMorePages = false;
                }
            }
        }
    }
}
