Imports Aspose.Diagram
Imports System
Public Class AddLayer
    Public Shared Sub Run()
        ' ExStart:AddLayer
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Layers()

        ' Load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' Get Visio page
        Dim page As Aspose.Diagram.Page = diagram.Pages.GetPage("Page-1")

        ' Initialize a new Layer class object
        Dim layer As New Layer()
        ' Set Layer name
        layer.Name.Value = "Layer1"
        ' Set Layer Visibility
        layer.Visible.Value = BOOL.True
        ' Set the color checkbox of Layer
        layer.IsColorChecked = BOOL.True
        ' Add Layer to the particular page sheet
        page.PageSheet.Layers.Add(layer)

        ' Get shape by ID
        Dim shape As Shape = page.Shapes.GetShape(3)
        ' Assign shape to this new Layer
        shape.LayerMem.LayerMember.Value = layer.IX.ToString()
        ' Save diagram
        diagram.Save(dataDir & Convert.ToString("AddLayer_out.vsdx"), SaveFileFormat.VSDX)

        ' ExEnd:AddLayer
    End Sub
End Class
