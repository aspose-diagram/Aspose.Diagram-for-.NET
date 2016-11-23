Imports Aspose.Diagram
Imports System
Public Class SetPrintJobAndPrinterName
    Public Shared Sub Run()
        ' ExStart:SetPrintJobAndPrinterName
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Print()

        ' Load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' Call the print method to print whole Diagram using the printer name and set document name in the print job
        diagram.Print("LaserJet1100", "Job name while printing with Aspose.Diagram")
        ' ExEnd:SetPrintJobAndPrinterName
    End Sub
End Class
