Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class SetPrintJobAndPrinterName
    Public Shared Sub Run()
        'ExStart:PrintDiagramVisXPSPrinterAPI
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Print()

        ' load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' call the print method to print whole Diagram using the printer name and set document name in the print job
        diagram.Print("LaserJet1100", "Job name while printing with Aspose.Diagram")
        'ExEnd:PrintDiagramVisXPSPrinterAPI
    End Sub
End Class
