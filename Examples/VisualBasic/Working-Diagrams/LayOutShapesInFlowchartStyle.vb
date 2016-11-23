Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram
Imports Aspose.Diagram.AutoLayout

Namespace Diagrams
    Public Class LayOutShapesInFlowchartStyle
        Public Shared Sub Run()
            ' ExStart:LayOutShapesInFlowchartStyle
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Diagrams()

            Dim fileName As String = "LayOutShapesInFlowchartStyle.vdx"
            Dim diagram As New Diagram(dataDir & fileName)

            Dim flowChartOptions As New LayoutOptions()
            flowChartOptions.LayoutStyle = LayoutStyle.FlowChart
            flowChartOptions.SpaceShapes = 1.0F
            flowChartOptions.EnlargePage = True

            flowChartOptions.Direction = LayoutDirection.BottomToTop
            diagram.Layout(flowChartOptions)
            diagram.Save(dataDir & "sample_btm_top.vdx", SaveFileFormat.VDX)

            diagram = New Diagram(dataDir & fileName)
            flowChartOptions.Direction = LayoutDirection.TopToBottom
            diagram.Layout(flowChartOptions)
            diagram.Save(dataDir & "sample_top_btm.vdx", SaveFileFormat.VDX)

            diagram = New Diagram(dataDir & fileName)
            flowChartOptions.Direction = LayoutDirection.LeftToRight
            diagram.Layout(flowChartOptions)
            diagram.Save(dataDir & "sample_left_right.vdx", SaveFileFormat.VDX)

            diagram = New Diagram(dataDir & fileName)
            flowChartOptions.Direction = LayoutDirection.RightToLeft
            diagram.Layout(flowChartOptions)
            diagram.Save(dataDir & "sample_right_left.vdx", SaveFileFormat.VDX)
            ' ExEnd:LayOutShapesInFlowchartStyle
        End Sub
    End Class
End Namespace