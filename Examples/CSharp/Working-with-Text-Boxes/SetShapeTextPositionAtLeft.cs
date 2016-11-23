using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Text_Boxes
{
    public class SetShapeTextPositionAtLeft
    {
        public static void Run() 
        {
            // ExStart:SetShapeTextPositionAtLeft
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_ShapeTextBoxData();

            // Load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // Get shape
            long shapeid = 1;
            Shape shape = diagram.Pages.GetPage("Page-1").Shapes.GetShape(shapeid);

            // Set text position at the left,
            // TxtLocPinX = "TxtWidth*1" and TxtPinX = "Width*0"
            shape.TextXForm.TxtLocPinX.Value = shape.TextXForm.TxtWidth.Value;
            shape.TextXForm.TxtPinX.Value = 0;
            // Set orientation angle
            double angleDeg = 0;
            double angleRad = (Math.PI / 180) * angleDeg;
            shape.TextXForm.TxtAngle.Value = angleRad;

            // Save Visio diagram in the local storage
            diagram.Save(dataDir + "SetShapeTextPositionAtLeft_out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:SetShapeTextPositionAtLeft
        }
    }
}
