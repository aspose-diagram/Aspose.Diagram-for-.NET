using Aspose.Diagram;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Diagram.ActiveXControls;

namespace Aspose.Diagram.Examples.CSharp.Visio_ActiveX_Controls
{
    public class RetrieveActiveXControl
    {
        public static void Run()
        {
            // ExStart:RetrieveActiveXControl
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_VisioActiveXControls();
            // Load and get a Visio page by name
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsd");            
            Page page = diagram.Pages.GetPage("Page-1");
            // Get a shape by ID
            Shape shape = page.Shapes.GetShape(1);
            // Get an ActiveX control
            CommandButtonActiveXControl cbac = (CommandButtonActiveXControl)shape.ActiveXControl;
            // Set width, height and caption of the command button control
            cbac.Width = 4;           
            cbac.Height = 4;           
            cbac.Caption = "Test Button";
            // Save diagram
            diagram.Save(dataDir + "RetrieveActiveXControl_out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:RetrieveActiveXControl
        }
    }
}
