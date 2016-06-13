Imports VisualBasic
Imports Aspose.Diagram
Imports System
Imports System.Drawing.Drawing2D

Public Class CalculateCenterOfSubShapes
    Public Shared Sub Run()
        ' ExStart:CalculateCenterOfSubShapes
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' load Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' get a group shape by ID and page index is 0
        Dim shape As Shape = diagram.Pages(0).Shapes.GetShape(795)
        ' get a sub-shape of the group shape by id
        Dim subShape As Shape = shape.Shapes.GetShape(794)

        Dim m As New Matrix()
        ' apply the translation vector
        m.Translate(-CSng(subShape.XForm.LocPinX.Value), -CSng(subShape.XForm.LocPinY.Value))
        ' set the elements of that matrix to a rotation
        m.Rotate(CSng(subShape.XForm.Angle.Value))
        ' apply the translation vector
        m.Translate(CSng(subShape.XForm.PinX.Value), CSng(subShape.XForm.PinY.Value))

        ' get pinx and piny
        Dim pinx As Double = m.OffsetX
        Dim piny As Double = m.OffsetY
        ' calculate the sub-shape pinx and piny
        Dim resultx As Double = shape.XForm.PinX.Value - shape.XForm.LocPinX.Value - pinx
        Dim resulty As Double = shape.XForm.PinY.Value - shape.XForm.LocPinY.Value - piny
        ' ExEnd:CalculateCenterOfSubShapes
    End Sub
End Class
