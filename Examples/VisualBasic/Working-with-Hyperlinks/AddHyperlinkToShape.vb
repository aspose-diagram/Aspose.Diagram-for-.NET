
Imports Aspose.Diagram
Imports System

Public Class AddHyperlinkToShape
    Public Shared Sub Run()
        ' ExStart:AddHyperlinkToShape
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Hyperlinks()

        ' Load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' Get page by name
        Dim page As Page = diagram.Pages.GetPage("Page-1")
        ' Get shape by ID
        Dim shape As Shape = page.Shapes.GetShape(2)

        ' Initialize Hyperlink object
        Dim hyperlink As New Hyperlink()
        ' Set address value
        hyperlink.Address.Value = "http://www.google.com/"
        ' Set sub address value
        hyperlink.SubAddress.Value = "Sub address here"
        ' Set description value
        hyperlink.Description.Value = "Description here"
        ' Set name
        hyperlink.Name = "MyHyperLink"

        ' Add hyperlink to the shape
        shape.Hyperlinks.Add(hyperlink)
        ' Save diagram to local space
        diagram.Save(dataDir & Convert.ToString("AddHyperlinkToShape_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:AddHyperlinkToShape
    End Sub
End Class
