Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram

Namespace Shapes
    Public Class UpdateShapeText
        Public Shared Sub Run()
            ' ExStart:UpdateShapeText
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_ShapeText()

            ' Call the diagram constructor to load diagram from a VDX file
            Dim vdxDiagram As New Diagram(dataDir & "UpdateShapeText.vsd")

            ' Find a particular shape and update its text
            For Each shape As Aspose.Diagram.Shape In vdxDiagram.Pages(0).Shapes
                If shape.NameU.ToLower() = "process" AndAlso shape.ID = 1 Then
                    shape.Text.Value.Clear()
                    shape.Text.Value.Add(New Txt("New Text"))
                End If
            Next shape
            ' Save diagram
            vdxDiagram.Save(dataDir & "UpdateShapeText_Out.vdx", SaveFileFormat.VDX)
            ' ExEnd:UpdateShapeText
        End Sub
    End Class
End Namespace