
Imports Aspose.Diagram
Imports System

Public Class VisioShapeProtection
    Public Shared Sub Run()
        ' ExStart:VisioShapeProtection
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Protection()

        ' Load diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("ProtectAndUnprotect.vsd"))
        ' Get page by name
        Dim page As Page = diagram.Pages.GetPage("Flow 1")
        ' Get shape by ID
        Dim shape As Shape = page.Shapes.GetShape(1)

        ' Set protections
        shape.Protection.LockAspect.Value = BOOL.True
        shape.Protection.LockBegin.Value = BOOL.True
        shape.Protection.LockCalcWH.Value = BOOL.True
        shape.Protection.LockCrop.Value = BOOL.True
        shape.Protection.LockCustProp.Value = BOOL.True
        shape.Protection.LockDelete.Value = BOOL.True
        shape.Protection.LockEnd.Value = BOOL.True
        shape.Protection.LockFormat.Value = BOOL.True
        shape.Protection.LockFromGroupFormat.Value = BOOL.True
        shape.Protection.LockGroup.Value = BOOL.True
        shape.Protection.LockHeight.Value = BOOL.True
        shape.Protection.LockMoveX.Value = BOOL.True
        shape.Protection.LockMoveY.Value = BOOL.True
        shape.Protection.LockRotate.Value = BOOL.True
        shape.Protection.LockSelect.Value = BOOL.True
        shape.Protection.LockTextEdit.Value = BOOL.True
        shape.Protection.LockThemeColors.Value = BOOL.True
        shape.Protection.LockThemeEffects.Value = BOOL.True
        shape.Protection.LockVtxEdit.Value = BOOL.True
        shape.Protection.LockWidth.Value = BOOL.True

        ' Save diagram
        diagram.Save(dataDir & Convert.ToString("VisioShapeProtection_Out.vdx"), SaveFileFormat.VDX)
        ' ExEnd:VisioShapeProtection
    End Sub
End Class
