using System.IO;
using Aspose.Diagram;
namespace Aspose.Diagram.Examples.CSharp.Diagrams
{
    public class ReadDiagramFile
    {
        public static void Run()
        {
            // ExStart:ReadDiagramFile
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Diagrams();

            // Call the diagram constructor to load diagram from a VSD stream
            FileStream st = new FileStream(dataDir + "ReadDiagramFile.vsd", FileMode.Open);
            // Load diagram
            Diagram vsdDiagram = new Diagram(st);
            // Get pages count
            System.Console.WriteLine("Total Pages:" + vsdDiagram.Pages.Count);

            st.Close();
            // ExEnd:ReadDiagramFile
        }
    }
}