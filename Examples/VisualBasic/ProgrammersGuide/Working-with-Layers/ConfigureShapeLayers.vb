Imports System
Imports Aspose.Diagram
Imports VisualBasic

Public Class ConfigureShapeLayers
    Public Shared Sub Run()
        ' ExStart:ConfigureShapeLayers
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Layers()

        ' load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' get page by name
        Dim page As Page = diagram.Pages.GetPage("Page-1")

        ' iterate through the shapes
        For Each shape As Aspose.Diagram.Shape In page.Shapes
            If shape.Name.ToLower() = "shape1" Then
                ' Add shape1 in first two layers. Here "0;1" are indexes of the layers
                Dim layer As LayerMem = shape.LayerMem
                layer.LayerMember.Value = "0;1"
            ElseIf shape.Name.ToLower() = "shape2" Then
                'Remove shape2 from all the layers
                Dim layer As LayerMem = shape.LayerMem
                layer.LayerMember.Value = ""
            ElseIf shape.Name.ToLower() = "shape3" Then
                ' Add shape3 in first layer. Here "0" is index of the first layer
                Dim layer As LayerMem = shape.LayerMem
                layer.LayerMember.Value = "0"
            End If
        Next
        ' save diagram
        diagram.Save(dataDir & Convert.ToString("ConfigureShapeLayers_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:ConfigureShapeLayers
    End Sub
End Class
