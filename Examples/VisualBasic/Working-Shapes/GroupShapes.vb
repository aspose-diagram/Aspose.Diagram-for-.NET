Imports Aspose.Diagram
Imports System
Public Class GroupShapes
    Public Shared Sub Run()
        ' ExStart:GroupShapes
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' Load a Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' Get page by name
        Dim page As Page = diagram.Pages.GetPage("Page-3")

        ' Initialize an array of shapes
        Dim ss As Aspose.Diagram.Shape() = New Aspose.Diagram.Shape(2) {}

        ' Extract and assign shapes to the array
        ss(0) = page.Shapes.GetShape(15)
        ss(1) = page.Shapes.GetShape(16)
        ss(2) = page.Shapes.GetShape(17)

        ' Mark array shapes as group
        page.Shapes.Group(ss)

        ' Save visio diagram
        diagram.Save(dataDir & Convert.ToString("GroupShapes_out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:GroupShapes
    End Sub
End Class
