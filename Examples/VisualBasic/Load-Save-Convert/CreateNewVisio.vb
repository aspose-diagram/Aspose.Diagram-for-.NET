Imports Aspose.Diagram

Imports System

Public Class CreateNewVisio
    Public Shared Sub Run()
        ' ExStart:CreateNewVisio
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_LoadSaveConvert()

        ' Initialize a Diagram class
        Dim diagram As New Diagram()

        ' Save diagram in the VSDX format
        diagram.Save(dataDir & Convert.ToString("CreateNewVisio_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:CreateNewVisio
    End Sub
End Class
