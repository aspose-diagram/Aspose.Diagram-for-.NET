
Imports Aspose.Diagram
Imports System

Public Class SetShapeTextPositionAtLeft
    Public Shared Sub Run()
        ' ExStart:SetShapeTextPositionAtLeft
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_ShapeTextBoxData()

        ' load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' get shape
        Dim shapeid As Long = 1
        Dim shape As Shape = diagram.Pages.GetPage("Page-1").Shapes.GetShape(shapeid)

        ' set text position at the left,
        ' TxtLocPinX = "TxtWidth*1" and TxtPinX = "Width*0"
        shape.TextXForm.TxtLocPinX.Value = shape.TextXForm.TxtWidth.Value
        shape.TextXForm.TxtPinX.Value = 0
        ' set orientation angle
        Dim angleDeg As Double = 0
        Dim angleRad As Double = (Math.PI / 180) * angleDeg
        shape.TextXForm.TxtAngle.Value = angleRad

        ' save Visio diagram in the local storage
        diagram.Save(dataDir & Convert.ToString("SetShapeTextPositionAtLeft_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:SetShapeTextPositionAtLeft
    End Sub
End Class
