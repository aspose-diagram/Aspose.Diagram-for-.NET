using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_Shapes
{
    public class CalculateCenterOfSubShapes
    {
        public static void Run()
        {
            // ExStart:CalculateCenterOfSubShapes
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // load Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // get a group shape by ID and page index is 0
            Shape shape = diagram.Pages[0].Shapes.GetShape(795);
            // get a sub-shape of the group shape by id
            Shape subShape = shape.Shapes.GetShape(794);

            Matrix m = new Matrix();
            // apply the translation vector
            m.Translate(-(float)subShape.XForm.LocPinX.Value, -(float)subShape.XForm.LocPinY.Value);
            // set the elements of that matrix to a rotation
            m.Rotate((float)subShape.XForm.Angle.Value);
            // apply the translation vector
            m.Translate((float)subShape.XForm.PinX.Value, (float)subShape.XForm.PinY.Value);

            // get pinx and piny
            double pinx = m.OffsetX;
            double piny = m.OffsetY;
            // calculate the sub-shape pinx and piny
            double resultx = shape.XForm.PinX.Value - shape.XForm.LocPinX.Value - pinx;
            double resulty = shape.XForm.PinY.Value - shape.XForm.LocPinY.Value - piny;
            // ExEnd:CalculateCenterOfSubShapes
        }
    }
}
