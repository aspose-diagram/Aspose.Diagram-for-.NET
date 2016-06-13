Imports VisualBasic
Imports Aspose.Diagram
Imports System
Imports System.IO

Public Class SaveVisioDiagram
    Public Shared Sub Run()
        ' ExStart:SaveVisioDiagram
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_LoadSaveConvert()
        ' load an existing Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' save diagram using the direct path
        diagram.Save(dataDir & Convert.ToString("SaveVisioDiagram_Out.vsdx"), SaveFileFormat.VSDX)

        Dim stream As New MemoryStream()
        ' save diagram in the stream
        diagram.Save(stream, SaveFileFormat.VSDX)
        ' ExEnd:SaveVisioDiagram
    End Sub

End Class
