
Imports Aspose.Diagram
Imports System

Public Class GetGluedConnectors
    Public Shared Sub Run()
        ' ExStart:GetGluedConnectors
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' Call a Diagram class constructor to load the VSD diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("RetrieveShapeInfo.vsd"))
        ' Get shape by an ID
        Dim shape As Shape = diagram.Pages(0).Shapes.GetShape(90)
        ' Get all glued 1D shapes
        Dim gluedShapeIds As Long() = shape.GluedShapes(GluedShapesFlags.GluedShapesAll1D, Nothing, Nothing)

        ' Display shape ID and name
        For Each id As Long In gluedShapeIds
            shape = diagram.Pages(0).Shapes.GetShape(id)
            Console.WriteLine("ID: " & shape.ID & "\t\t Name: " & shape.Name)
        Next
        ' ExEnd:GetGluedConnectors
    End Sub
End Class
