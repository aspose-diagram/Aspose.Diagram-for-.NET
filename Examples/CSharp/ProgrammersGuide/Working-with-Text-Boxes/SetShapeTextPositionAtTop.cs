using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_with_Text_Boxes
{
    public class SetShapeTextPositionAtTop
    {
        public static void Run() 
        {
            // ExStart:SetShapeTextPositionAtTop
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_ShapeTextBoxData();

            // load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // get shape
            long shapeid = 1;
            Shape shape = diagram.Pages.GetPage("Page-1").Shapes.GetShape(shapeid);

            // set text position at the top,
            // TxtLocPinY = "TxtHeight*0" and TxtPinY = "Height*1"
            shape.TextXForm.TxtLocPinY.Value = 0;
            shape.TextXForm.TxtPinY.Value = shape.XForm.Height.Value;

            // set orientation angle
            double angleDeg = 0;
            double angleRad = (Math.PI / 180) * angleDeg;
            shape.TextXForm.TxtAngle.Value = angleRad;

            // save Visio diagram in the local storage
            diagram.Save(dataDir + "SetShapeTextPositionAtTop_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:SetShapeTextPositionAtTop
        }
    }
}
