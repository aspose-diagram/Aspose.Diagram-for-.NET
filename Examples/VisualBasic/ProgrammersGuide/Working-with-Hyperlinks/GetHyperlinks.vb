Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class GetHyperlinks
    Public Shared Sub Run()
        'ExStart:GetHyperlinks
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Hyperlinks()

        ' load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' get page by name
        Dim page As Page = diagram.Pages.GetPage("Page-1")
        ' get shape by ID
        Dim shape As Shape = page.Shapes.GetShape(1)
        ' iterate through the hyperlinks
        For Each hyperlink As Aspose.Diagram.Hyperlink In shape.Hyperlinks
            Console.WriteLine("Address: " + hyperlink.Address.Value)
            Console.WriteLine("Sub Address: " + hyperlink.SubAddress.Value)
            Console.WriteLine("Description: " + hyperlink.Description.Value)
        Next
        'ExEnd:GetHyperlinks
    End Sub
End Class
