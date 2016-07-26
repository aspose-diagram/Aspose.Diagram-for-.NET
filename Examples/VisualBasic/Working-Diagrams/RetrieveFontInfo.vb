Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram
Imports System

Namespace Diagrams
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