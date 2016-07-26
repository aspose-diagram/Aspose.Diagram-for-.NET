using System.IO;
using Aspose.Diagram;
using System;
namespace Aspose.Diagram.Examples.CSharp.Diagrams
{
    public class RetrieveConnectorInfo
    {
        public static void Run()
        {
            // ExStart:RetrieveConnectorInfo
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Diagrams();

            // Call the diagram constructor to load diagram from a VSD file
            Diagram vdxDiagram = new Diagram(dataDir + "RetrieveConnectorInfo.vsd");

            foreach (Aspose.Diagram.Connect connector in vdxDiagram.Pages[0].Connects)
            {
                // Display information about the Connectors
                Console.WriteLine("\nFrom Shape ID : " + connector.FromSheet);
                Console.WriteLine("To Shape ID : " + connector.ToSheet);
            }
            // ExEnd:RetrieveConnectorInfo
        }
    }
}