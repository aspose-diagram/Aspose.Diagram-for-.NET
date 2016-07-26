using System.IO;
using Aspose.Diagram;
namespace Aspose.Diagram.Examples.CSharp.Diagrams
{
    public class ExportToSVG
    {
        public static void Run()
        {
            // ExStart:ExportToSVG
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();

            // Call the diagram constructor to load a VSD diagram
            Diagram diagram = new Diagram(dataDir + "ExportToSVG.vsd");

            // Save SVG Output file
            diagram.Save(dataDir + "Output.svg", SaveFileFormat.SVG);
            // ExEnd:ExportToSVG
        }
    }
}