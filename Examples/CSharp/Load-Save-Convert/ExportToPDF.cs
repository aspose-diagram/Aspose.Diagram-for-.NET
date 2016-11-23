using System.IO;
using Aspose.Diagram;

namespace Aspose.Diagram.Examples.CSharp.Diagrams
{
    public class ExportToPDF
    {
        public static void Run()
        {
            // ExStart:ExportToPDF
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();

            // Call the diagram constructor to load a VSD diagram
            Diagram diagram = new Diagram(dataDir + "ExportToPDF.vsd");

            MemoryStream pdfStream = new MemoryStream();
            // Save diagram
            diagram.Save(pdfStream, SaveFileFormat.PDF);

            // Create a PDF file
            FileStream pdfFileStream = new FileStream(dataDir + "ExportToPDF_out.pdf", FileMode.Create, FileAccess.Write);
            pdfStream.WriteTo(pdfFileStream);
            pdfFileStream.Close();

            pdfStream.Close();

            // Display Status.
            System.Console.WriteLine("Conversion from vsd to pdf performed successfully.");
            // ExEnd:ExportToPDF
        }
    }
}