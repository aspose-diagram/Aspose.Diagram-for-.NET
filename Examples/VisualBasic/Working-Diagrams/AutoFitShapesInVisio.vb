
Imports Aspose.Diagram
Imports System
Imports Aspose.Diagram.Saving

Public Class AutoFitShapesInVisio
    Public Shared Sub Run()
        ' ExStart:AutoFitShapesInVisio
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Diagrams()

        ' load a Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("BFlowcht.vsdx"))

        ' use saving options
        Dim options As New DiagramSaveOptions(SaveFileFormat.VSDX)
        ' set Auto fit page property
        options.AutoFitPageToDrawingContent = True

        ' save Visio diagram
        diagram.Save(dataDir & Convert.ToString("AutoFitShapesInVisio_Out.vsdx"), options)
        ' ExEnd:AutoFitShapesInVisio
    End Sub
End Class
