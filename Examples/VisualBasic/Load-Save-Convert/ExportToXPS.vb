Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram

Namespace Diagrams
    Public Class ExportToXPS
        Public Shared Sub Run()
            ' ExStart:ExportToXPS
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_LoadSaveConvert()

            ' Open VSD diagram
            Dim diagram As New Diagram(dataDir & "ExportToXPS.vsd")

            ' Save diagram to XPS format
            diagram.Save(dataDir & "Output.xps", SaveFileFormat.XPS)
            ' ExEnd:ExportToXPS
        End Sub
    End Class
End Namespace