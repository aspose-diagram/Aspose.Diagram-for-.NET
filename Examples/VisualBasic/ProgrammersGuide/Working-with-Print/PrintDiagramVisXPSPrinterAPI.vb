Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class PrintDiagramVisXPSPrinterAPI
    Public Shared Sub Run()
        'ExStart:PrintDiagramVisXPSPrinterAPI
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Print()

        ' load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' Specify the name of the printer you want to print to.
        Const printerName As String = "\\COMPANY\Brother MFC-885CW Printer"

        ' Print the document.
        XpsPrintHelper.Print(diagram, printerName, "My Test Job", True)
        'ExEnd:PrintDiagramVisXPSPrinterAPI
    End Sub
End Class
