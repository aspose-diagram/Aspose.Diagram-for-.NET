Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class RetrieveWindowElementsOfDiagram
    Public Shared Sub Run()
        'ExStart:RetrieveWindowElementsOfDiagram
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_WindowElements()

        ' load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' iterate through the window elements
        For Each window As Window In diagram.Windows
            Console.WriteLine("ID: " & window.ID)
            Console.WriteLine("Type: " & window.WindowType)
            Console.WriteLine("Window height: " & window.WindowHeight)
            Console.WriteLine("Window width: " & window.WindowWidth)
            Console.WriteLine("Window state: " & window.WindowState)
        Next
        'ExEnd:RetrieveWindowElementsOfDiagram
    End Sub
End Class
