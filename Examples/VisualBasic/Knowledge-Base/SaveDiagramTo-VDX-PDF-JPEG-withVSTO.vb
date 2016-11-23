Imports System
Imports Visio = Microsoft.Office.Interop.Visio
Public Class SaveDiagramTo_VDX_PDF_JPEG_withVSTO
    Public Shared Sub Run()
        ' ExStart:SaveDiagramTo_VDX_PDF_JPEG_withVSTO
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_KnowledgeBase()

        ' Create Visio Application Object
        Dim vsdApp As New Visio.Application()

        ' Make Visio Application Invisible
        vsdApp.Visible = False

        ' Create a document object and load a diagram
        Dim vsdDoc As Visio.Document = vsdApp.Documents.Open(dataDir & Convert.ToString("Drawing1.vsd"))

        ' Save the VDX diagram
        vsdDoc.SaveAs(dataDir & Convert.ToString("SaveDiagramToVDXwithVSTO_out.vdx"))

        ' Save as PDF file
        vsdDoc.ExportAsFixedFormat(Visio.VisFixedFormatTypes.visFixedFormatPDF, dataDir & Convert.ToString("SaveDiagramToPDFwithVSTO_out.pdf"), Visio.VisDocExIntent.visDocExIntentScreen, Visio.VisPrintOutRange.visPrintAll, 1, vsdDoc.Pages.Count, _
            False, True, True, True, True, System.Reflection.Missing.Value)

        Dim vsdPage As Visio.Page = vsdDoc.Pages(1)

        ' Save as JPEG Image
        vsdPage.Export(dataDir & Convert.ToString("SaveDiagramToJPGwithVSTO_out.jpg"))

        ' Quit Visio Object
        vsdApp.Quit()
        ' ExEnd:SaveDiagramTo_VDX_PDF_JPEG_withVSTO
    End Sub
End Class
