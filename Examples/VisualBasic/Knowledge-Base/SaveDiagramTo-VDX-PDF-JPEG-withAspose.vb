Imports Aspose.Diagram
Imports System
Public Class SaveDiagramTo_VDX_PDF_JPEG_withAspose
    Public Shared Sub Run()
        ' ExStart:SaveDiagramTo_VDX_PDF_JPEG_withAspose
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_KnowledgeBase()

        ' Load an exiting Visio diagram
        Dim vsdDiagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsd"))

        ' Save the diagram as VDX
        vsdDiagram.Save(dataDir & Convert.ToString("SaveDiagramToVDXwithAspose_out.vdx"), SaveFileFormat.VDX)

        ' Save as PDF
        vsdDiagram.Save(dataDir & Convert.ToString("SaveDiagramToPDFwithAspose_out.pdf"), SaveFileFormat.PDF)

        ' Save as JPEG
        vsdDiagram.Save(dataDir & Convert.ToString("SaveDiagramToJPGwithAspose_out.jpg"), SaveFileFormat.JPEG)
        ' ExEnd:SaveDiagramTo_VDX_PDF_JPEG_withAspose
    End Sub
End Class
