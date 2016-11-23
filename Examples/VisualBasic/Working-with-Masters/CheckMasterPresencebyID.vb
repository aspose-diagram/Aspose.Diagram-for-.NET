Imports Aspose.Diagram
Imports System
Public Class CheckMasterPresencebyID
    Public Shared Sub Run()
        ' ExStart:CheckMasterPresencebyID
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Master()

        ' Call the diagram constructor to load diagram from a VDX file
        Dim diagram As New Diagram(dataDir & Convert.ToString("Basic Shapes.vss"))

        ' Set master id
        Dim masterid As Integer = 2
        ' Check master by id
        Dim isPresent As Boolean = diagram.Masters.IsExist(2)

        Console.WriteLine("Master Presence : " & isPresent)
        ' ExEnd:CheckMasterPresencebyID
    End Sub
End Class
