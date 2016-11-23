using Aspose.Diagram;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Diagram.ActiveXControls;

namespace Aspose.Diagram.Examples.CSharp.Visio_ActiveX_Controls
{
    public class InsertActiveXControl
    {
        public static void Run()
        {
            // ExStart:InsertActiveXControl
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_VisioActiveXControls();
            // Instantiate Diagram Object
            Diagram diagram = new Diagram();
            // Insert an ActiveX control
            diagram.Pages[0].AddActiveXControl(ControlType.Image, 1, 1, 1, 1);
            // Save diagram
            diagram.Save(dataDir + "InsertActiveXControl_out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:InsertActiveXControl
        }
    }
}
