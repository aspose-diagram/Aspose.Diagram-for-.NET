using System.IO;
using Aspose.Diagram;
namespace Aspose.Diagram.Examples.CSharp.Diagrams
{
    public class ExportToXPS
    {
        public static void Run()
        {
            // ExStart:ExportToXPS
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Diagrams();

            // Open a VSD file
            Diagram diagram = new Diagram(dataDir + "LayOutShapesInCompactTreeStyle.vdx");

            // Save diagram to an XPS format
            diagram.Save(dataDir + "Output.xps", SaveFileFormat.XPS);
            // ExEnd:ExportToXPS
        }
    }
}