
Imports Aspose.Diagram
Imports System

Public Class ReadAllShapeProps
    Public Shared Sub Run()
        ' ExStart:ReadAllShapeProps
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' call a Diagram class constructor to load the VSDX diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' get page by name
        Dim page As Page = diagram.Pages.GetPage("Page-3")

        For Each shape As Aspose.Diagram.Shape In page.Shapes
            If shape.Name = "Process1" Then
                For Each [property] As Prop In shape.Props
                    Console.WriteLine([property].Label.Value + ": " + [property].Value.Val)
                Next
                Exit For
            End If
        Next
        ' ExEnd:ReadAllShapeProps
    End Sub
End Class
