Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram
Imports System

Namespace Shapes
    Public Class SetLineData
        Public Shared Sub Run()
            ' ExStart:SetLineData
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Shapes()

            ' Load a Visio diagram
            Dim diagram As New Diagram(dataDir & Convert.ToString("SetLineData.vsd"))
            ' Get the page by its name
            Dim page1 As Aspose.Diagram.Page = diagram.Pages.GetPage("Page-1")
            ' Get shape by its ID
            Dim shape As Aspose.Diagram.Shape = page1.Shapes.GetShape(1)
            ' Set line dash type by index
            shape.Line.LinePattern.Value = 4
            ' Set line weight, defualt in PT
            shape.Line.LineWeight.Value = 2
            ' Set color of the shape' S line
            shape.Line.LineColor.Ufe.F = "RGB(95,108,53)"
            ' Set line rounding, default in inch
            shape.Line.Rounding.Value = 0.3125
            ' Set line caps
            shape.Line.LineCap.Value = BOOL.True
            ' Set line color transparency in percent
            shape.Line.LineColorTrans.Value = 50

            ' Add arrows to the connector or curve shapes 

            ' Select arrow type by index
            shape.Line.BeginArrow.Value = 4
            shape.Line.EndArrow.Value = 4
            ' Set arrow size 
            shape.Line.BeginArrowSize.Value = ArrowSizeValue.Large
            shape.Line.BeginArrowSize.Value = ArrowSizeValue.Large

            ' Save the Visio
            diagram.Save(dataDir & Convert.ToString("SetLineData_out.vsdx"), SaveFileFormat.VSDX)
            ' ExEnd:SetLineData
        End Sub
    End Class
End Namespace