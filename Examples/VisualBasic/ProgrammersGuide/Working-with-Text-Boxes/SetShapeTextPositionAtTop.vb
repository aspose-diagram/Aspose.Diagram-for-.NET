Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class SetShapeTextPositionAtTop
    Public Shared Sub Run()
        ' ExStart:SetShapeTextPositionAtTop
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_ShapeTextBoxData()

        ' load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' get shape
        Dim shapeid As Long = 1
        Dim shape As Shape = diagram.Pages.GetPage("Page-1").Shapes.GetShape(shapeid)

        ' set text position at the top,
        ' TxtLocPinY = "TxtHeight*0" and TxtPinY = "Height*1"
        shape.TextXForm.TxtLocPinY.Value = 0
        shape.TextXForm.TxtPinY.Value = shape.XForm.Height.Value

        ' set orientation angle
        Dim angleDeg As Double = 0
        Dim angleRad As Double = (Math.PI / 180) * angleDeg
        shape.TextXForm.TxtAngle.Value = angleRad

        ' save Visio diagram in the local storage
        diagram.Save(dataDir & Convert.ToString("SetShapeTextPositionAtTop_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:SetShapeTextPositionAtTop
    End Sub
End Class
