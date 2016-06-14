using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.ProgrammersGuide.Working_with_External_Data_Sources
{
    public class EditDataConAndRefreshRecords
    {
        public static void Run()
        {
            // ExStart:EditDataConAndRefreshRecords
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_ExternalDataSources();

            // load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsd");
            // set connecting string
            diagram.DataConnections[0].ConnectionString = "Data Source=MyServer;Initial Catalog=MyDB;Integrated Security=True";
            // set command
            diagram.DataConnections[0].Command = "SELECT * from Project with(nolock)";
            // refresh all record sets
            diagram.Refresh();
            // save Visio diagram
            diagram.Save(dataDir + "EditDataConAndRefreshRecords_Out.vdx", SaveFileFormat.VDX);
            // ExEnd:EditDataConAndRefreshRecords
        }
    }
}
