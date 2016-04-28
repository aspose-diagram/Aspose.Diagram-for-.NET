using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_with_Masters
{
    public class GetMasterbyID
    {
        public static void Run()
        {
            //ExStart:GetMasterbyID
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Master();

            // Call the diagram constructor to load diagram from a VDX file
            Diagram diagram = new Diagram(dataDir + "RetrieveMasterInfo.vdx");

            // Set master id
            int masterid = 2;
            // Get master object by id
            Master master = diagram.Masters.GetMaster(masterid);

            Console.WriteLine("Master ID : " + master.ID);
            Console.WriteLine("Master Name : " + master.Name);
            Console.WriteLine("Master Name : " + master.UniqueID);
            //ExEnd:GetMasterbyID
        }
    }
}
