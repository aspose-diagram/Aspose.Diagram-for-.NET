
Imports Aspose.Diagram
Imports System
Imports System.Drawing.Drawing2D

Public Class CalculateCenterOfSubShapes
    Public Shared Sub Run()
        ' ExStart:CalculateCenterOfSubShapes
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' Load Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' Get a group shape by ID and page index is 0
        Dim shape As Shape = diagram.Pages(0).Shapes.GetShape(795)
        ' Get a sub-shape of the group shape by id
        Dim subShape As Shape = shape.Shapes.GetShape(794)

        Dim m As New Matrix()
        ' Apply the translation vector
        m.Translate(-CSng(subShape.XForm.LocPinX.Value), -CSng(subShape.XForm.LocPinY.Value))
        ' Set the elements of that matrix to a rotation
        m.Rotate(CSng(subShape.XForm.Angle.Value))
        ' Apply the translation vector
        m.Translate(CSng(subShape.XForm.PinX.Value), CSng(subShape.XForm.PinY.Value))

        ' Get pinx and piny
        Dim pinx As Double = m.OffsetX
        Dim piny As Double = m.OffsetY
        ' Calculate the sub-shape pinx and piny
        Dim resultx As Double = shape.XForm.PinX.Value - shape.XForm.LocPinX.Value - pinx
        Dim resulty As Double = shape.XForm.PinY.Value - shape.XForm.LocPinY.Value - piny
        ' ExEnd:CalculateCenterOfSubShapes
    End Sub
End Class
