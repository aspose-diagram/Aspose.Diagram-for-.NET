using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Masters
{
    public class CheckMasterPresencebyID
    {
        public static void Run() 
        {
            // ExStart:CheckMasterPresencebyID
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Master();

            // Call the diagram constructor to load diagram from a VDX file
            Diagram diagram = new Diagram(dataDir + "Basic Shapes.vss");

            // check master by id
            bool isPresent = diagram.Masters.IsExist(2);

            Console.WriteLine("Master Presence : " + isPresent);
            // ExEnd:CheckMasterPresencebyID
        }
    }
}
