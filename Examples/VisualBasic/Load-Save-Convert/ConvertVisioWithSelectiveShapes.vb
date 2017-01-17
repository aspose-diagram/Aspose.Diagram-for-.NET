Imports System
Imports Aspose.Diagram.Saving

Public Class ConvertVisioWithSelectiveShapes
    Public Shared Sub Run()
        ' ExStart:ConvertVisioWithSelectiveShapes
        ' the path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_LoadSaveConvert()

        ' call the diagram constructor to load diagram from a VSD file
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' create an instance SVG save options class
        Dim options As New SVGSaveOptions()
        Dim shapes As ShapeCollection = options.Shapes

        ' get shapes by page index and shape ID, and then add in the shape collection object
        shapes.Add(diagram.Pages(0).Shapes.GetShape(1))
        shapes.Add(diagram.Pages(0).Shapes.GetShape(2))

        ' save Visio drawing
        diagram.Save(dataDir & Convert.ToString("SelectiveShapes_out.svg"), options)
        ' ExEnd:ConvertVisioWithSelectiveShapes
    End Sub
End Class
