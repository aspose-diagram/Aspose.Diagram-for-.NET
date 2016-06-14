
Imports Aspose.Diagram
Imports System

Public Class ExportToXAML
    Public Shared Sub Run()
        ' ExStart:ExportToXAML
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_LoadSaveConvert()
        ' load diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("ExportToXAML.vsd"))
        ' save diagram in the XAML format
        diagram.Save(dataDir & Convert.ToString("Output.xaml"), SaveFileFormat.XAML)
        ' ExEnd:ExportToXAML
    End Sub
End Class
