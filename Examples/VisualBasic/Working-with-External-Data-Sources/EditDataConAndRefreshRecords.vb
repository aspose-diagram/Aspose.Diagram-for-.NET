Imports Aspose.Diagram
Imports System
Public Class EditDataConAndRefreshRecords
    Public Shared Sub Run()
        ' ExStart:EditDataConAndRefreshRecords
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_ExternalDataSources()

        ' Load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsd"))
        ' Set connecting string
        diagram.DataConnections(0).ConnectionString = "Data Source=MyServer;Initial Catalog=MyDB;Integrated Security=True"
        ' Set command
        diagram.DataConnections(0).Command = "SELECT * from Project with(nolock)"
        ' Refresh all record sets
        diagram.Refresh()
        ' Save Visio diagram
        diagram.Save(dataDir & Convert.ToString("EditDataConAndRefreshRecords_out.vdx"), SaveFileFormat.VDX)
        ' ExEnd:EditDataConAndRefreshRecords
    End Sub
End Class
