using System.IO;
using Aspose.Diagram;

namespace Aspose.Diagram.Examples.CSharp.Diagrams
{
    public class ExportToImage
    {
        public static void Run()
        {
            // ExStart:ExportToImage
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();

            // Call the diagram constructor to load a VSD diagram
            Diagram diagram = new Diagram(dataDir + "ExportToImage.vsd");

            // Save Image file
            diagram.Save(dataDir + "ExportToImage_out.png", SaveFileFormat.PNG);
            // ExEnd:ExportToImage
        }
    }
}