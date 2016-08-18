using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Protection
{
    public class VisioShapeProtection
    {
        public static void Run() 
        {
            // ExStart:VisioShapeProtection
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Protection();

            // Load diagram
            Diagram diagram = new Diagram(dataDir + "ProtectAndUnprotect.vsd");
            // Get page by name
            Page page = diagram.Pages.GetPage("Flow 1");
            // Get shape by ID
            Shape shape = page.Shapes.GetShape(1);

            // Set protections
            shape.Protection.LockAspect.Value = BOOL.True;
            shape.Protection.LockBegin.Value = BOOL.True;
            shape.Protection.LockCalcWH.Value = BOOL.True;
            shape.Protection.LockCrop.Value = BOOL.True;
            shape.Protection.LockCustProp.Value = BOOL.True;
            shape.Protection.LockDelete.Value = BOOL.True;
            shape.Protection.LockEnd.Value = BOOL.True;
            shape.Protection.LockFormat.Value = BOOL.True;
            shape.Protection.LockFromGroupFormat.Value = BOOL.True;
            shape.Protection.LockGroup.Value = BOOL.True;
            shape.Protection.LockHeight.Value = BOOL.True;
            shape.Protection.LockMoveX.Value = BOOL.True;
            shape.Protection.LockMoveY.Value = BOOL.True;
            shape.Protection.LockRotate.Value = BOOL.True;
            shape.Protection.LockSelect.Value = BOOL.True;
            shape.Protection.LockTextEdit.Value = BOOL.True;
            shape.Protection.LockThemeColors.Value = BOOL.True;
            shape.Protection.LockThemeEffects.Value = BOOL.True;
            shape.Protection.LockVtxEdit.Value = BOOL.True;
            shape.Protection.LockWidth.Value = BOOL.True;
            
            // Save diagram
            diagram.Save(dataDir + "VisioShapeProtection_Out.vdx", SaveFileFormat.VDX);
            // ExEnd:VisioShapeProtection
        }
    }
}
