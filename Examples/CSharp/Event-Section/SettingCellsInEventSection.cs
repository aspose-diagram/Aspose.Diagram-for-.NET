using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Event_Section
{
    public class SettingCellsInEventSection
    {
        public static void Run()
        {
            // ExStart:SettingCellsInEventSection
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_EventSection();

            // Load diagram
            Diagram diagram = new Diagram(dataDir + "TestTemplate.vsdm");
            // Get page
            Aspose.Diagram.Page page = diagram.Pages.GetPage(0);
            // Get shape id
            long shapeId = page.AddShape(3.0, 3.0, 0.36, 0.36, "Square");
            // Get shape
            Aspose.Diagram.Shape shape = page.Shapes.GetShape(shapeId);

            // Set event cells in the ShapeSheet
            shape.Event.EventXFMod.Ufe.F = "CALLTHIS(\"ThisDocument.ShowAlert\")";
            shape.Event.EventDblClick.Ufe.F = "CALLTHIS(\"ThisDocument.ShowAlert\")";
            shape.Event.EventDrop.Ufe.F = "CALLTHIS(\"ThisDocument.ShowAlert\")";
            shape.Event.EventMultiDrop.Ufe.F = "CALLTHIS(\"ThisDocument.ShowAlert\")";
            shape.Event.TheText.Ufe.F = "CALLTHIS(\"ThisDocument.ShowAlert\")";
            shape.Event.TheData.Ufe.F = "CALLTHIS(\"ThisDocument.ShowAlert\")";

            // Save diagram
            diagram.Save(dataDir + "SettingCellsInEventSection_out.vsdm", SaveFileFormat.VSDM);
            // ExEnd:SettingCellsInEventSection
        }
    }
}
