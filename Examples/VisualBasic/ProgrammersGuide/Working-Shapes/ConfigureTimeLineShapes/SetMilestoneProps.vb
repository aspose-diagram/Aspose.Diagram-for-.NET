
Imports Aspose.Diagram
Imports System

Public Class SetMilestoneProps
    Public Shared Sub Run()
        ' ExStart:SetMilestoneProps
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' Load diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("DrawingTimeLine.vsdx"))
        Dim shapeid As Integer = 22
        ' Get timeline shape
        Dim milestone As Shape = diagram.Pages.GetPage("Page-1").Shapes.GetShape(shapeid)

        ' Initialize MilestoneHelper object
        Dim milestoneHelper As Aspose.Diagram.MilestoneHelper = New MilestoneHelper(milestone)

        ' Set milestone date
        milestoneHelper.MilestoneDate = New DateTime(2014, 10, 21)
        ' Set date format
        milestoneHelper.DateFormat = 21
        ' Set auto update flag
        milestoneHelper.IsAutoUpdate = True
        ' Set milestone type
        milestoneHelper.Type = 6

        ' Save to VDX format
        diagram.Save(dataDir & Convert.ToString("SetMilestoneProps_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:SetMilestoneProps
    End Sub
End Class
