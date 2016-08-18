Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram

Namespace Diagrams
    Public Class ExportToSVG
        Public Shared Sub Run()
            ' ExStart:ExportToSVG
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_LoadSaveConvert()

            ' Call the diagram constructor to load a VSD diagram
            Dim diagram As New Diagram(dataDir & "ExportToSVG.vsd")

            ' Save diagram in the SVG format
            diagram.Save(dataDir & "ExportToSVG_Out.svg", SaveFileFormat.SVG)
            ' ExEnd:ExportToSVG
        End Sub
    End Class
End Namespace