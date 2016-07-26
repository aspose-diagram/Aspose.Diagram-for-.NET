Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram

Namespace Shapes
    Public Class ApplyCustomStyleSheets
        Public Shared Sub Run()
            ' ExStart:ApplyCustomStyleSheets
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_ShapeText()

            ' Load diagram
            Dim vsdDiagram As New Diagram(dataDir & "ApplyCustomStyleSheets.vsd")

            Dim sourceShape As Shape = Nothing

            ' Find the shape that you want to apply style to
            For Each shape As Aspose.Diagram.Shape In vsdDiagram.Pages(0).Shapes
                If shape.Name = "Process" Then
                    sourceShape = shape
                    Exit For
                End If
            Next shape

            Dim customStyleSheet As StyleSheet = Nothing

            ' Find the required style sheet
            For Each styleSheet As StyleSheet In vsdDiagram.StyleSheets
                If styleSheet.Name = "Basic" Then
                    customStyleSheet = styleSheet
                    Exit For
                End If
            Next styleSheet

            If sourceShape IsNot Nothing AndAlso customStyleSheet IsNot Nothing Then
                ' Apply text style
                sourceShape.TextStyle = customStyleSheet
                ' Apply fill style
                sourceShape.FillStyle = customStyleSheet
                ' Apply line style
                sourceShape.LineStyle = customStyleSheet
            End If

            ' Save changed diagram as VDX
            vsdDiagram.Save(dataDir & "ApplyCustomStyleSheets_Out.vdx", SaveFileFormat.VDX)
            ' ExEnd:ApplyCustomStyleSheets

        End Sub
    End Class
End Namespace