
Imports Aspose.Diagram
Imports System

Public Class GroupShapes
    Public Shared Sub Run()
        ' ExStart:GroupShapes
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' load a Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' get page by name
        Dim page As Page = diagram.Pages.GetPage("Page-3")

        ' Initialize an array of shapes
        Dim ss As Aspose.Diagram.Shape() = New Aspose.Diagram.Shape(2) {}

        ' extract and assign shapes to the array
        ss(0) = page.Shapes.GetShape(15)
        ss(1) = page.Shapes.GetShape(16)
        ss(2) = page.Shapes.GetShape(17)

        ' mark array shapes as group
        page.Shapes.Group(ss)

        ' save visio diagram
        diagram.Save(dataDir & Convert.ToString("GroupShapes_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:GroupShapes
    End Sub
End Class
