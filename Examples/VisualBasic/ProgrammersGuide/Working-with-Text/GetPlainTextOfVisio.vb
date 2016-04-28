Imports VisualBasic
Imports Aspose.Diagram
Imports System
Imports System.Text.RegularExpressions

Public Class GetPlainTextOfVisio
    'ExStart:GetPlainTextOfVisio
    Shared text As String = ""
    Public Shared Sub Run()
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_ShapeText()
        ' load diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' get Visio diagram page
        Dim page As Aspose.Diagram.Page = diagram.Pages.GetPage("Page-1")

        ' iterate through the shapes
        For Each shape As Aspose.Diagram.Shape In page.Shapes
            ' extract plain text from the shape
            GetShapeText(shape)
        Next
        ' display extracted text
        Console.WriteLine(text)
    End Sub
    Private Shared Sub GetShapeText(shape As Aspose.Diagram.Shape)
        ' filter shape text
        If shape.Text.Value.Text <> "" Then
            text += Regex.Replace(shape.Text.Value.Text, "\<.*?>", "")
        End If

        ' for image shapes
        If shape.Type = TypeValue.Foreign Then
            text += (shape.Name)
        End If

        ' for group shapes
        If shape.Type = TypeValue.Group Then
            For Each subshape As Aspose.Diagram.Shape In shape.Shapes
                GetShapeText(subshape)
            Next
        End If
    End Sub
    'ExEnd:GetPlainTextOfVisio
End Class
