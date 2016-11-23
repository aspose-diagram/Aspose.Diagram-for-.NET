using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_External_Data_Sources
{
    public class EditDataConAndRefreshRecords
    {
        public static void Run()
        {
            // ExStart:EditDataConAndRefreshRecords
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_ExternalDataSources();

            // Load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsd");
            // Set connecting string
            diagram.DataConnections[0].ConnectionString = "Data Source=MyServer;Initial Catalog=MyDB;Integrated Security=True";
            // Set command
            diagram.DataConnections[0].Command = "SELECT * from Project with(nolock)";
            // Refresh all record sets
            diagram.Refresh();
            // Save Visio diagram
            diagram.Save(dataDir + "EditDataConAndRefreshRecords_out.vdx", SaveFileFormat.VDX);
            // ExEnd:EditDataConAndRefreshRecords
        }
    }
}
