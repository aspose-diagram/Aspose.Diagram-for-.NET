Imports VisualBasic
Imports Aspose.Diagram
Imports System.IO
Imports System

Public Class ExportHTMLinStream
    Public Shared Sub Run()
        ' ExStart:ExportHTMLinStream
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_LoadSaveConvert()
        ' load diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("ExportToHTML.vsd"))
        ' save resultant HTML directly to a stream
        Dim stream As New MemoryStream()
        diagram.Save(stream, SaveFileFormat.HTML)
        ' ExEnd:ExportHTMLinStream
    End Sub
End Class
