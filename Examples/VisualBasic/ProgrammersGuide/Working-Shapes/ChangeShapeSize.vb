
Imports Aspose.Diagram
Imports System

Public Class ChangeShapeSize
    Public Shared Sub Run()
        ' ExStart:ChangeShapeSize
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' call a Diagram class constructor to load the VSDX diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' get page by name
        Dim page As Page = diagram.Pages.GetPage("Page-1")
        ' get shape by id
        Dim shape As Shape = page.Shapes.GetShape(796)
        ' alter the size of Shape
        shape.SetWidth(2 * shape.XForm.Width.Value)
        shape.SetHeight(2 * shape.XForm.Height.Value)
        ' save diagram
        diagram.Save(dataDir & Convert.ToString("ChangeShapeSize_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:ChangeShapeSize
    End Sub
End Class
