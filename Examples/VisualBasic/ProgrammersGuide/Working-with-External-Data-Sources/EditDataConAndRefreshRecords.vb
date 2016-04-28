Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class EditDataConAndRefreshRecords
    Public Shared Sub Run()
        'ExStart:EditDataConAndRefreshRecords
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_ExternalDataSources()

        ' load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsd"))
        ' set connecting string
        diagram.DataConnections(0).ConnectionString = "Data Source=MyServer;Initial Catalog=MyDB;Integrated Security=True"
        ' set command
        diagram.DataConnections(0).Command = "SELECT * from Project with(nolock)"
        ' refresh all record sets
        diagram.Refresh()
        ' save Visio diagram
        diagram.Save(dataDir & Convert.ToString("EditDataConAndRefreshRecords_Out.vdx"), SaveFileFormat.VDX)
        'ExEnd:EditDataConAndRefreshRecords
    End Sub
End Class
