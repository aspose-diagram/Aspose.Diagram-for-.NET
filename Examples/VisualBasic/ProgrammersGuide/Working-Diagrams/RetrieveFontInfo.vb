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
Imports System

Namespace VisualBasic.Diagrams
    Public Class RetrieveFontInfo
        Public Shared Sub Run()
            ' ExStart:RetrieveFontInfo
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Diagrams()

            ' Call the diagram constructor to load diagram from a VSD file
            Dim vdxDiagram As New Diagram(dataDir & "RetrieveFontInfo.vsd")

            For Each font As Aspose.Diagram.Font In vdxDiagram.Fonts
                ' Display information about the fonts
                Console.WriteLine(font.Name)
            Next font
            ' ExEnd:RetrieveFontInfo
        End Sub
    End Class
End Namespace