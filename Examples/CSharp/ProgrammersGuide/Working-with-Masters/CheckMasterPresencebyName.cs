using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.ProgrammersGuide.Working_with_Masters
{
    public class CheckMasterPresencebyName
    {
        public static void Run() 
        {
            // ExStart:CheckMasterPresencebyName
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Master();

            // Call the diagram constructor to load diagram from a VDX file
            Diagram diagram = new Diagram(dataDir + "Basic Shapes.vss");

            // Set master name
            string masterName = "VNXe3100 Storage Processor Rear";
            // check master object by name
            bool isPresent = diagram.Masters.IsExist(masterName);

            Console.WriteLine("Master Presence : " + isPresent);
            // ExEnd:CheckMasterPresencebyName
        }
    }
}
