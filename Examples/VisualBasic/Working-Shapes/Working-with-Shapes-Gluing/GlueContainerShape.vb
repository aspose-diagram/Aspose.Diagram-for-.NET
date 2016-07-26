
Imports Aspose.Diagram
Imports System

Public Class GlueContainerShape
    Public Shared Sub Run()
        ' ExStart:GlueContainerShape
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' Load diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' Get a particular page
        Dim page As Page = diagram.Pages.GetPage("Page-1")

        ' The ID of shape which is glue from Aspose.Diagram.Shape.
        Dim shapeFromId As Long = 779
        ' The location on the first connection index where to glue
        Dim shapeToBeginConnectionIndex As Integer = 72
        ' The location on the end connection index where to glue
        Dim shapeToEndConnectionIndex As Integer = 73
        ' The ID of shape where to glue to Aspose.Diagram.Shape.
        Dim shapeToId As Long = 743

        ' Glue shapes in container
        page.GlueShapesInContainer(shapeFromId, shapeToBeginConnectionIndex, shapeToEndConnectionIndex, shapeToId)

        ' Glue shapes in container using connection name
        ' page.GlueShapesInContainer(fasId, "U05L", "U05R", cabinetId1);

        ' Save diagram
        diagram.Save(dataDir & Convert.ToString("GlueContainerShape_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:GlueContainerShape
    End Sub
End Class
