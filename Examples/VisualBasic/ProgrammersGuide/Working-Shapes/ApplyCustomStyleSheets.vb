'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Diagram. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Diagram

Namespace VisualBasic.Shapes
    Public Class ApplyCustomStyleSheets
        Public Shared Sub Run()
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Shapes()

            'Load diagram
            Dim vsdDiagram As New Diagram(dataDir & "ApplyCustomStyleSheets.vsd")

            Dim sourceShape As Shape = Nothing

            'Find the shape that you want to apply style to
            For Each shape As Aspose.Diagram.Shape In vsdDiagram.Pages(0).Shapes
                If shape.Name = "Process" Then
                    sourceShape = shape
                    Exit For
                End If
            Next shape

            Dim customStyleSheet As StyleSheet = Nothing

            'Find the required style sheet
            For Each styleSheet As StyleSheet In vsdDiagram.StyleSheets
                If styleSheet.Name = "Basic" Then
                    customStyleSheet = styleSheet
                    Exit For
                End If
            Next styleSheet

            If sourceShape IsNot Nothing AndAlso customStyleSheet IsNot Nothing Then
                'Apply text style
                sourceShape.TextStyle = customStyleSheet
                'Apply fill style
                sourceShape.FillStyle = customStyleSheet
                'Apply line style
                sourceShape.LineStyle = customStyleSheet
            End If

            'Save changed diagram as VDX
            vsdDiagram.Save(dataDir & "output.vdx", SaveFileFormat.VDX)


        End Sub
    End Class
End Namespace