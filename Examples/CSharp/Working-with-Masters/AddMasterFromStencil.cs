using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Masters
{
    public class AddMasterFromStencil
    {
        public static void Run()
        {
            // ExStart:AddMasterFromStencil
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Master();

            // Load diagram
            Diagram diagram = new Diagram();

            // Load stencil to a stream
            string templateFileName = dataDir + "NetApp-FAS-series.vss";
            Stream stream = new FileStream(templateFileName, FileMode.Open);

            // Add master with stencil file path and master id
            string masterName = "FAS80xx rear empty";
            diagram.AddMaster(templateFileName, 2);

            // Add master with stencil file path and master name
            diagram.AddMaster(templateFileName, masterName);

            // Add master with stencil file stream and master id
            diagram.AddMaster(stream, 2);

            // adds master to diagram from source diagram
            Diagram src = new Diagram(templateFileName);
            diagram.AddMaster(src, masterName);

            // Add master with stencil file stream and master id
            diagram.AddMaster(stream, masterName);

            // Adds shape with defined PinX and PinY.
            diagram.AddShape(2.0, 2.0, masterName, 0);
            diagram.AddShape(6.0, 6.0, masterName, 0);

            // Adds shape with defined PinX,PinY,Width and Height.
            diagram.AddShape(7.0, 3.0, 1.5, 1.5, masterName, 0);
            // ExEnd:AddMasterFromStencil
        }
    }
}
