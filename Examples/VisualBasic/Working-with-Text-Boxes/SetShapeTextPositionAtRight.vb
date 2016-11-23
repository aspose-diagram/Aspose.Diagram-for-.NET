Imports Aspose.Diagram
Imports System
Public Class SetShapeTextPositionAtRight
    Public Shared Sub Run()
        ' ExStart:SetShapeTextPositionAtRight
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_ShapeTextBoxData()

        ' Load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' Get shape
        Dim shapeid As Long = 1
        Dim shape As Shape = diagram.Pages.GetPage("Page-1").Shapes.GetShape(shapeid)

        ' Set text position at the right,
        ' TxtLocPinX = "TxtWidth*0" and TxtPinX = "Width*1"
        shape.TextXForm.TxtLocPinX.Value = 0
        shape.TextXForm.TxtPinX.Value = shape.XForm.Width.Value
        ' Set orientation angle
        Dim angleDeg As Double = 0
        Dim angleRad As Double = (Math.PI / 180) * angleDeg
        shape.TextXForm.TxtAngle.Value = angleRad

        ' Save Visio diagram in the local storage
        diagram.Save(dataDir & Convert.ToString("SetShapeTextPositionAtRight_out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:SetShapeTextPositionAtRight
    End Sub
End Class
