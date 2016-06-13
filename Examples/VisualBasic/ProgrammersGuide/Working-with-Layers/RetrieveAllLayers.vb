Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class RetrieveAllLayers
    Public Shared Sub Run()
        ' ExStart:RetrieveAllLayers
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Layers()

        ' load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' get Visio page
        Dim page As Aspose.Diagram.Page = diagram.Pages.GetPage("Page-1")

        ' iterate through the layers
        For Each layer As Layer In page.PageSheet.Layers
            Console.WriteLine("Name: " & layer.Name.Value)
            Console.WriteLine("Visibility: " & layer.Visible.Value)
            Console.WriteLine("Status: " & layer.Status.Value)
        Next
        ' ExEnd:RetrieveAllLayers
    End Sub
End Class
