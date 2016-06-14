
Imports Aspose.Diagram
Imports System

Public Class SaveDiagramTo_VDX_PDF_JPEG_withAspose
    Public Shared Sub Run()
        ' ExStart:SaveDiagramTo_VDX_PDF_JPEG_withAspose
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_KnowledgeBase()

        ' load an exiting Visio diagram
        Dim vsdDiagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsd"))

        ' Save the diagram as VDX
        vsdDiagram.Save(dataDir & Convert.ToString("SaveDiagramToVDXwithAspose_Out.vdx"), SaveFileFormat.VDX)

        ' Save as PDF
        vsdDiagram.Save(dataDir & Convert.ToString("SaveDiagramToPDFwithAspose_Out.pdf"), SaveFileFormat.PDF)

        ' Save as JPEG
        vsdDiagram.Save(dataDir & Convert.ToString("SaveDiagramToJPGwithAspose_Out.jpg"), SaveFileFormat.JPEG)
        ' ExEnd:SaveDiagramTo_VDX_PDF_JPEG_withAspose
    End Sub
End Class
