Imports Aspose.Diagram
Imports System
Public Class GetLibraryVersion
    Public Shared Sub Run()
        ' ExStart:GetLibraryVersion
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Intro()

        ' Build path of an existing diagram
        Dim visioDrawing As String = dataDir & Convert.ToString("Drawing1.vsdx")

        ' Call the diagram constructor to load diagram from a VDX file
        Dim diagram As New Diagram(visioDrawing)

        ' Display Visio version and document modification time at different stages
        Console.WriteLine("Visio Instance Version : " + diagram.Version)
        Console.WriteLine("Full Build Number Created : " + diagram.DocumentProps.BuildNumberCreated)
        Console.WriteLine("Full Build Number Edited : " + diagram.DocumentProps.BuildNumberEdited)
        Console.WriteLine("Date Created : " + diagram.DocumentProps.TimeCreated.ToString())
        Console.WriteLine("Date Last Edited : " + diagram.DocumentProps.TimeEdited.ToString())
        Console.WriteLine("Date Last Printed : " + diagram.DocumentProps.TimePrinted.ToString())
        Console.WriteLine("Date Last Saved : " + diagram.DocumentProps.TimeSaved.ToString())
        ' ExEnd:GetLibraryVersion
    End Sub
End Class
