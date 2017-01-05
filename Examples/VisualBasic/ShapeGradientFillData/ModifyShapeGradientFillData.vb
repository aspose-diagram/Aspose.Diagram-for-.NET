Public Class ModifyShapeGradientFillData
    Public Shared Sub Run()
        ' ExStart:ModifyShapeGradientFillData
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_ShapeGradientFillData()

        ' Load the Visio diagram
        Dim diagram As New Diagram(dataDir + "ShapewithGradientFill.vsdx")
        ' get page by name
        Dim page As Aspose.Diagram.Page = diagram.Pages.GetPage("Page-1")
        ' get shape by ID
        Dim shape As Aspose.Diagram.Shape = page.Shapes.GetShape(1)
        ' get the gradient fill properties
        Dim gradientfill As GradientFill = shape.Fill.GradientFill
        ' get the gradient stops
        Dim stops As GradientStopCollection = gradientfill.GradientStops
        ' get the gradient stop by index
        Dim [stop] As GradientStop = stops(0)

        ' set gradient stop properties
        [stop].Color.Ufe.F = ""
        [stop].Position.Value = 0.5
        gradientfill.GradientDir.Value = CInt(GradientFillDir.RectangleFromBottomRight)
        gradientfill.GradientAngle.Value = 0.78539816339745
        ' save the Visio drawing
        diagram.Save(dataDir + "ShapewithGradientFill_out.vsdx", SaveFileFormat.VSDX)
        ' ExEnd:ModifyShapeGradientFillData
    End Sub
End Class
