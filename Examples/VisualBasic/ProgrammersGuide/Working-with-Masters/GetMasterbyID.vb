Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class GetMasterbyID
    Public Shared Sub Run()
        'ExStart:GetMasterbyID
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Master()

        ' Call the diagram constructor to load diagram from a VDX file
        Dim diagram As New Diagram(dataDir & Convert.ToString("RetrieveMasterInfo.vdx"))

        ' Set master id
        Dim masterid As Integer = 2
        ' Get master object by id
        Dim master As Master = diagram.Masters.GetMaster(masterid)

        Console.WriteLine("Master ID : " & master.ID)
        Console.WriteLine("Master Name : " & master.Name)
        Console.WriteLine("Master Name : " & master.UniqueID.ToString())
        'ExEnd:GetMasterbyID
    End Sub
End Class
