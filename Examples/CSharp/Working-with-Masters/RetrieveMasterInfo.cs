using System.IO;
using Aspose.Diagram;
using System;
namespace Aspose.Diagram.Examples.CSharp.Diagrams
{
    public class RetrieveMasterInfo
    {
        public static void Run()
        {
            // ExStart:RetrieveMasterInfo
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Master();

            // Call a Diagram class constructor to load the VDX diagram
            Diagram vdxDiagram = new Diagram(dataDir + "RetrieveMasterInfo.vdx");

            foreach (Aspose.Diagram.Master master in vdxDiagram.Masters)
            {
                // Display information about the masters
                Console.WriteLine("\nMaster ID : " + master.ID);
                Console.WriteLine("Master Name : " + master.Name);
            }
            
            Console.ReadLine();
            // ExEnd:RetrieveMasterInfo
        }
    }
}