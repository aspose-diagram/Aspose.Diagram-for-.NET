Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class BySpecificPrinter
    Public Shared Sub Run()
        'ExStart:BySpecificPrinter
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Print()

        ' load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' call the print method to print whole Diagram using the printer name
        diagram.Print("LaserJet1100")
        'ExEnd:BySpecificPrinter
    End Sub
End Class
