using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_Shapes
{
    class Apply3DRotationEffects
    {
        public static void Run()
        {
            // ExStart:Apply3DRotationEffects
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // load diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // get shape by ID and page name
            Shape shape = diagram.Pages.GetPage("Page-1").Shapes.GetShape(796);

            // set 3D rotation properties
            shape.ThreeDFormat.RotationXAngle.Value = 2.61;
            shape.ThreeDFormat.RotationYAngle.Value = 2.61;
            shape.ThreeDFormat.RotationZAngle.Value = 3;
            shape.ThreeDFormat.RotationType.Value = RotationTypeValue.ObliqueFromBottomLeft;
            shape.ThreeDFormat.Perspective.Value = 0;
            shape.ThreeDFormat.DistanceFromGround.Value = 0;
            shape.ThreeDFormat.KeepTextFlat.Value = BOOL.True;

            // save drawing
            diagram.Save(dataDir + "Apply3DRotationEffects_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:Apply3DRotationEffects
        }
    }
}