using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Masters
{
    public class GetMasterbyName
    {
        public static void Run()
        {
            // ExStart:GetMasterbyName
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Master();

            // Call the diagram constructor to load diagram from a VDX file
            Diagram diagram = new Diagram(dataDir + "Basic Shapes.vss");

            // Set master name
            string masterName = "Circle";
            // Get master object by name
            Master master = diagram.Masters.GetMasterByName(masterName);

            Console.WriteLine("Master ID : " + master.ID);
            Console.WriteLine("Master Name : " + master.Name);
            Console.WriteLine("Master Name : " + master.UniqueID);
            // ExEnd:GetMasterbyName
        }
    }
}
