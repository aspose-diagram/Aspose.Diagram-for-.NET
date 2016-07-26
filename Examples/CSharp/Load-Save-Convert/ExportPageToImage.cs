
using System.IO;
using Aspose.Diagram;
using Aspose.Diagram.Saving;

namespace Aspose.Diagram.Examples.CSharp.Diagrams
{
    public class ExportPageToImage
    {
        public static void Run()
        {
            // ExStart:ExportPageToImage
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();
            // load diagram
            Diagram diagram = new Diagram(dataDir + "ExportPageToImage.vsd");

            // Save diagram as PNG
            ImageSaveOptions options = new ImageSaveOptions(SaveFileFormat.PNG);

            // Save one page only, by page index
            options.PageIndex = 0;

            // Save resultant Image file
            diagram.Save(dataDir + "ExportPageToImage_Out.png", options);
            // ExEnd:ExportPageToImage
        }
    }
}