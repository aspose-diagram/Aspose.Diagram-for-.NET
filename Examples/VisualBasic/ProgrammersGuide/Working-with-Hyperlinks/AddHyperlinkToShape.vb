Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class AddHyperlinkToShape
    Public Shared Sub Run()
        'ExStart:AddHyperlinkToShape
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Hyperlinks()

        ' load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' get page by name
        Dim page As Page = diagram.Pages.GetPage("Page-1")
        ' get shape by ID
        Dim shape As Shape = page.Shapes.GetShape(2)

        'initialize Hyperlink object
        Dim hyperlink As New Hyperlink()
        'set address value
        hyperlink.Address.Value = "http://www.google.com/"
        'set sub address value
        hyperlink.SubAddress.Value = "Sub address here"
        'set description value
        hyperlink.Description.Value = "Description here"
        'set name
        hyperlink.Name = "MyHyperLink"

        'add hyperlink to the shape
        shape.Hyperlinks.Add(hyperlink)
        'save diagram to local space
        diagram.Save(dataDir & Convert.ToString("AddHyperlinkToShape_Out.vsdx"), SaveFileFormat.VSDX)
        'ExEnd:AddHyperlinkToShape
    End Sub
End Class
