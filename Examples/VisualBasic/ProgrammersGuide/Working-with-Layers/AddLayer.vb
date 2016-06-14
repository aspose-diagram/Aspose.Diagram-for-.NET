
Imports Aspose.Diagram
Imports System

Public Class AddLayer
    Public Shared Sub Run()
        ' ExStart:AddLayer
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Layers()

        ' load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' get Visio page
        Dim page As Aspose.Diagram.Page = diagram.Pages.GetPage("Page-1")

        ' initialize a new Layer class object
        Dim layer As New Layer()
        ' set Layer name
        layer.Name.Value = "Layer1"
        ' set Layer Visibility
        layer.Visible.Value = BOOL.True
        ' add Layer to the particular page sheet
        page.PageSheet.Layers.Add(layer)

        ' get shape by ID
        Dim shape As Shape = page.Shapes.GetShape(3)
        ' assign shape to this new Layer
        shape.LayerMem.LayerMember.Value = layer.IX.ToString()
        ' save diagram
        diagram.Save(dataDir & Convert.ToString("AddLayer_Out.vsdx"), SaveFileFormat.VSDX)

        ' ExEnd:AddLayer
    End Sub
End Class
