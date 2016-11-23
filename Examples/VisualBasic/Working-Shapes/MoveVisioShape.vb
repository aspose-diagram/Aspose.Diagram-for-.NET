Imports Aspose.Diagram
Imports System
Public Class MoveVisioShape
    Public Shared Sub Run()
        ' ExStart:MoveVisioShape
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' Call a Diagram class constructor to load the VSDX diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' Get page by name
        Dim page As Page = diagram.Pages.GetPage("Page-3")
        ' Get shape by id
        Dim shape As Shape = page.Shapes.GetShape(16)
        ' Move shape from its position, it adds values in coordinates
        shape.Move(1, 1)

        ' Save diagram
        diagram.Save(dataDir & Convert.ToString("MoveVisioShape_out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:MoveVisioShape
    End Sub
End Class
