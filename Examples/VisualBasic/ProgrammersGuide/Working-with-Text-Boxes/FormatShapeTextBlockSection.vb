Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class FormatShapeTextBlockSection
    Public Shared Sub Run()
        ' ExStart:FormatShapeTextBlockSection
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_ShapeTextBoxData()

        ' load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' get the page by its name
        Dim page1 As Aspose.Diagram.Page = diagram.Pages.GetPage("Page-1")
        ' get shape by its ID
        Dim shape As Aspose.Diagram.Shape = page1.Shapes.GetShape(1)
        ' set orientation angle
        Dim margin As New DoubleValue(4, MeasureConst.PT)

        ' set left, right, top and bottom margins of the shape' S text block
        shape.TextBlock.LeftMargin = margin
        shape.TextBlock.RightMargin = margin
        shape.TextBlock.TopMargin = margin
        shape.TextBlock.BottomMargin = margin
        ' set the text direction
        shape.TextBlock.TextDirection.Value = TextDirectionValue.Vertical
        ' set the text alignment
        shape.TextBlock.VerticalAlign.Value = VerticalAlignValue.Middle
        ' set the text block background color
        shape.TextBlock.TextBkgnd.Ufe.F = "RGB(95,108,53)"
        ' set the background color transparency in percent
        shape.TextBlock.TextBkgndTrans.Value = 50
        ' set the distance between default tab stops for the selected shape.
        shape.TextBlock.DefaultTabStop.Value = 2

        ' save Visio
        diagram.Save(dataDir & Convert.ToString("FormatShapeTextBlockSection_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:FormatShapeTextBlockSection
    End Sub
End Class
