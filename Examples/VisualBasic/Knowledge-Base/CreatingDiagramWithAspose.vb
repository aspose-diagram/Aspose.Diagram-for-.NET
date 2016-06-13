Imports Aspose.Diagram
Imports System
Imports VisualBasic

Public Class CreatingDiagramWithAspose
    Public Shared Sub Run()
        ' ExStart:CreatingDiagramWithAspose
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_KnowledgeBase()

        ' Create a new diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Basic Shapes.vss"))

        ' Add a new rectangle shape
        Dim shapeId As Long = diagram.AddShape(4.25, 5.5, 2, 1, "Rectangle", 0)
        Dim shape As Shape = diagram.Pages(0).Shapes.GetShape(shapeId)
        shape.Text.Value.Add(New Txt("Rectangle text."))

        ' Add a new star shape
        shapeId = diagram.AddShape(2.0, 5.5, 2, 2, "Star 7", 0)
        shape = diagram.Pages(0).Shapes.GetShape(shapeId)
        shape.Text.Value.Add(New Txt("Star text."))

        ' Add a new hexagon shape
        shapeId = diagram.AddShape(7.0, 5.5, 2, 2, "Hexagon", 0)
        shape = diagram.Pages(0).Shapes.GetShape(shapeId)
        shape.Text.Value.Add(New Txt("Hexagon text."))

        ' Save the new diagram
        diagram.Save(dataDir & Convert.ToString("CreatingDiagramWithAspose_Out.vdx"), SaveFileFormat.VDX)
        ' ExEnd:CreatingDiagramWithAspose
    End Sub
End Class
