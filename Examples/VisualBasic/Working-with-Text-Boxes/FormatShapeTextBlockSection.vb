
Imports Aspose.Diagram
Imports System

Public Class FormatShapeTextBlockSection
    Public Shared Sub Run()
        ' ExStart:FormatShapeTextBlockSection
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_ShapeTextBoxData()

        ' Load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' Get the page by its name
        Dim page1 As Aspose.Diagram.Page = diagram.Pages.GetPage("Page-1")
        ' Get shape by its ID
        Dim shape As Aspose.Diagram.Shape = page1.Shapes.GetShape(1)
        ' Set orientation angle
        Dim margin As New DoubleValue(4, MeasureConst.PT)

        ' Set left, right, top and bottom margins of the shape' S text block
        shape.TextBlock.LeftMargin = margin
        shape.TextBlock.RightMargin = margin
        shape.TextBlock.TopMargin = margin
        shape.TextBlock.BottomMargin = margin
        ' Set the text direction
        shape.TextBlock.TextDirection.Value = TextDirectionValue.Vertical
        ' Set the text alignment
        shape.TextBlock.VerticalAlign.Value = VerticalAlignValue.Middle
        ' Set the text block background color
        shape.TextBlock.TextBkgnd.Ufe.F = "RGB(95,108,53)"
        ' Set the background color transparency in percent
        shape.TextBlock.TextBkgndTrans.Value = 50
        ' Set the distance between default tab stops for the selected shape.
        shape.TextBlock.DefaultTabStop.Value = 2

        ' Save Visio
        diagram.Save(dataDir & Convert.ToString("FormatShapeTextBlockSection_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:FormatShapeTextBlockSection
    End Sub
End Class
