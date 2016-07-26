Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram

Namespace Diagrams
    Public Class ExportToHTML
        Public Shared Sub Run()
            ' ExStart:ExportToHTML
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_LoadSaveConvert()
            ' load diagram
            Dim diagram As New Diagram(dataDir & "ExportToHTML.vsd")
            ' save diagra in the HTML format
            diagram.Save(dataDir & "ExportToHTML_Out.html", SaveFileFormat.HTML)
            ' ExEnd:ExportToHTML
        End Sub
    End Class
End Namespace