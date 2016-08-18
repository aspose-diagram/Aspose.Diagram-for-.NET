
Imports Aspose.Diagram
Imports System

Public Class CheckMasterPresencebyName
    Public Shared Sub Run()
        ' ExStart:CheckMasterPresencebyName
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Master()

        ' Call the diagram constructor to load diagram from a VDX file
        Dim diagram As New Diagram(dataDir & Convert.ToString("Basic Shapes.vss"))

        ' Set master name
        Dim masterName As String = "VNXe3100 Storage Processor Rear"
        ' Check master object by name
        Dim isPresent As Boolean = diagram.Masters.IsExist(masterName)

        Console.WriteLine("Master Presence : " & isPresent)
        ' ExEnd:CheckMasterPresencebyName
    End Sub
End Class
