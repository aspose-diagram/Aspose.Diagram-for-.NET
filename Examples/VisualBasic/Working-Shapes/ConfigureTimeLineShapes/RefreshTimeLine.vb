Imports Aspose.Diagram
Imports System
Public Class RefreshTimeLine
    Public Shared Sub Run()
        ' ExStart:RefreshTimeLine

        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' Load diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("DrawingTimeLine.vsdx"))

        Dim shapeid As Integer = 1
        ' Get timeline shape
        Dim timeline As Shape = diagram.Pages.GetPage("Page-1").Shapes.GetShape(shapeid)

        ' Initialize TimeLineHlper object
        Dim timelineHelper As New TimeLineHelper(timeline)

        ' Set start time
        timelineHelper.TimePeriodStart = New DateTime(2014, 12, 21)
        ' Set end time
        timelineHelper.TimePeriodFinish = New DateTime(2015, 2, 19)

        ' Set date format
        timelineHelper.DateFormatForBE = 21

        'revive milestones on the timeline
        timelineHelper.RefreshTimeLine()

        ' Save to VDX format
        diagram.Save(dataDir & Convert.ToString("RefreshTimeLine_out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:RefreshTimeLine
    End Sub
End Class
