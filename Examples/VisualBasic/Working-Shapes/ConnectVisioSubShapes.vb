Imports Aspose.Diagram
Imports Aspose.Diagram.Manipulation
Imports System
Public Class ConnectVisioSubShapes
    Public Shared Sub Run()
        ' ExStart:ConnectVisioSubShapes
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' Set sub shape ids
        Dim shapeFromId As Long = 2
        Dim shapeToId As Long = 4

        ' Load diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' Access a particular page
        Dim page As Page = diagram.Pages.GetPage("Page-3")

        ' Initialize connector shape
        Dim shape As New Shape()
        shape.Line.EndArrow.Value = 4
        shape.Line.LineWeight.Value = 0.01388

        ' Add shape
        Dim connecter1Id As Long = diagram.AddShape(shape, "Dynamic connector", page.ID)
        ' Connect sub-shapes
        page.ConnectShapesViaConnector(shapeFromId, ConnectionPointPlace.Right, shapeToId, ConnectionPointPlace.Left, connecter1Id)
        ' Save Visio drawing
        diagram.Save(dataDir & Convert.ToString("ConnectVisioSubShapes_out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:ConnectVisioSubShapes
    End Sub
End Class
