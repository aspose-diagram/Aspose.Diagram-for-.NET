Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class ConfigureTimeLine
    Public Shared Sub Run()
        'ExStart:ConfigureTimeLine
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' Load diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("DrawingTimeLine.vsdx"))
        Dim shapeid As Integer = 1
        ' Get timeline shape
        Dim timeline As Shape = diagram.Pages.GetPage("Page-1").Shapes.GetShape(shapeid)

        ' Initialize TimeLineHlper object
        Dim timelineHelper As Aspose.Diagram.TimeLineHelper = New TimeLineHelper(timeline)

        ' Set start time
        timelineHelper.TimePeriodStart = New DateTime(2014, 12, 21)
        ' Set end time
        timelineHelper.TimePeriodFinish = New DateTime(2015, 2, 19)

        ' Set date format
        'timelineHelper.DateFormatForBE = 21;
        ' Set date format for intm of timeline shape   
        'timelineHelper.DateFormatForIntm = 21;

        ' Or

        ' Set date format string for start and finish of timeline shape
        timelineHelper.DateFormatStringForBE = "yyyy-MM-dd"
        ' Set date format string for intm of timeline shape
        timelineHelper.DateFormatStringForIntm = "yyyy-MM-dd"

        ' Save to VDX format
        diagram.Save(dataDir & Convert.ToString("ConfigureTimeLine_Out.vsdx"), SaveFileFormat.VSDX)
        'ExEnd:ConfigureTimeLine
    End Sub
End Class
