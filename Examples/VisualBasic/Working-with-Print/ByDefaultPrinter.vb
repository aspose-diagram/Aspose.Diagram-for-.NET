Imports Aspose.Diagram
Imports System
Public Class ByDefaultPrinter
    Public Shared Sub Run()
        ' ExStart:ByDefaultPrinter
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Print()

        ' Load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' Call the print method to print whole Diagram using the default printer
        diagram.Print()
        ' ExEnd:ByDefaultPrinter
    End Sub
End Class
