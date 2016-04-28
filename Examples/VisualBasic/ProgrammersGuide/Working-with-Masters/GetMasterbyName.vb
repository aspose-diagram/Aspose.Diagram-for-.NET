Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class GetMasterbyName
    Public Shared Sub Run()
        'ExStart:GetMasterbyName
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Master()

        ' Call the diagram constructor to load diagram from a VDX file
        Dim diagram As New Diagram(dataDir & Convert.ToString("Basic Shapes.vss"))

        ' Set master name
        Dim masterName As String = "Circle"
        ' Get master object by name
        Dim master As Master = diagram.Masters.GetMasterByName(masterName)

        Console.WriteLine("Master ID : " & master.ID)
        Console.WriteLine("Master Name : " & master.Name)
        Console.WriteLine("Master Name : " & master.UniqueID.ToString())
        'ExEnd:GetMasterbyName
    End Sub
End Class
