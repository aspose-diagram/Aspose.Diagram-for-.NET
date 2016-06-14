
Imports Aspose.Diagram
Imports System

Public Class GetAllConnectedShapes
    Public Shared Sub Run()
        ' ExStart:GetAllConnectedShapes
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' call a Diagram class constructor to load the VSDX diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' get shape by id
        Dim shape As Shape = diagram.Pages.GetPage("Page-3").Shapes.GetShape(16)
        ' get connected shapes
        Dim connectedShapeIds As Long() = shape.ConnectedShapes(ConnectedShapesFlags.ConnectedShapesAllNodes, Nothing)

        For Each id As Long In connectedShapeIds
            shape = diagram.Pages.GetPage("Page-3").Shapes.GetShape(id)
            Console.WriteLine("ID: " & shape.ID & "\t\t Name: " & shape.Name)
        Next
        ' ExEnd:GetAllConnectedShapes
    End Sub
End Class
