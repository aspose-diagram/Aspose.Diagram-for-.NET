using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_Shapes
{
    public class SetConnectorAppearance
    {
        public static void Run()
        {
            // ExStart:SetConnectorAppearance
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // call a Diagram class constructor to load the VSD diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsd");

            // Get a particular page
            Page page = diagram.Pages.GetPage("Page-3");
            // Get a dynamic connector type shape by id
            Shape shape = page.Shapes.GetShape(18);
            // set dynamic connector appearance
            shape.SetConnectorsType(ConnectorsTypeValue.StraightLines);

            // Saving Visio diagram
            diagram.Save(dataDir + "SetConnectorAppearance_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:SetConnectorAppearance
        }
    }
}
