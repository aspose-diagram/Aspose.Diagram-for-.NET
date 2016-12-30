using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Shape_Gradient_Fill_Data
{
    public class ModifyShapeGradientFillData
    {
        public static void Run()
        {
            // ExStart:ModifyShapeGradientFillData
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_ShapeGradientFillData();
            // Load the Visio diagram
            Diagram diagram = new Diagram(dataDir + "ShapewithGradientFill.vsdx");
            // get page by name
            Aspose.Diagram.Page page = diagram.Pages.GetPage("Page-1");
            // get shape by ID
            Aspose.Diagram.Shape shape = page.Shapes.GetShape(1);
            // get the gradient fill properties
            GradientFill gradientfill = shape.Fill.GradientFill;
            // get the gradient stops
            GradientStopCollection stops = gradientfill.GradientStops;
            // get the gradient stop by index
            GradientStop stop = stops[0];
            // set gradient stop properties
            stop.Color.Ufe.F = "";
            stop.Position.Value = 0.5;
            gradientfill.GradientDir.Value = (int)GradientFillDir.RectangleFromBottomRight;
            gradientfill.GradientAngle.Value = 0.7853981633974501;
            // save the Visio drawing
            diagram.Save(dataDir + "ShapewithGradientFill_out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:ModifyShapeGradientFillData
        }
    }
}
