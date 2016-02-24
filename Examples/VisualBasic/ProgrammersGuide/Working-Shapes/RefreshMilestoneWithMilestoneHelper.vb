'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Diagram. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Diagram
Imports System

Namespace VisualBasic.Shapes
    Public Class RefreshMilestoneWithMilestoneHelper
        Public Shared Sub Run()
            'ExStart:RefreshMilestoneWithMilestoneHelper
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Shapes()

            'Modify time line
            Dim startDate As New DateTime(2015, 8, 1)

            Dim endDate As New DateTime(2016, 6, 1)

            Dim fisYear As DateTime = startDate

            Dim pageName As String = "Page-1"

            'Load a diagram
            Dim diagram As New Diagram(dataDir & "input.vdx")

            'Get page
            Dim page As Aspose.Diagram.Page = diagram.Pages.GetPage(pageName)

            Dim timelineId As Long = 1

            Dim timeline As Shape = diagram.Pages.GetPage(pageName).Shapes.GetShape(timelineId)

            Dim xpos As Double = timeline.XForm.PinX.Value

            Dim ypos As Double = timeline.XForm.PinY.Value

            ' Add milestone
            Dim milestoneMasterName As String = "2 triangle milestone"

            'Add Master
            diagram.AddMaster(dataDir & "Timeline.vss", milestoneMasterName)

            'Add Shape in Visio diagram using AddShape method
            Dim milestoneShapeId As Long = diagram.AddShape(xpos, ypos, milestoneMasterName, 0)

            'Get the shape based on ID
            Dim milestone As Shape = page.Shapes.GetShape(milestoneShapeId)

            'Instantiate MilestoneHelper object
            Dim milestoneHelper As New MilestoneHelper(milestone)

            'Set Milestone Date
            milestoneHelper.MilestoneDate = New DateTime(2015, 8, 1)

            'Set IsAutoUpdate to true
            milestoneHelper.IsAutoUpdate = True

            'RefreshMilesone of timeline shape
            milestoneHelper.RefreshMilestone(timeline)

            diagram.Save(dataDir & "output.vdx", SaveFileFormat.VDX)
            'ExEnd:RefreshMilestoneWithMilestoneHelper
        End Sub
    End Class
End Namespace