
Imports Aspose.Diagram
Imports System

Public Class VerifyConnectedOrGluedShapes
    Public Shared Sub Run()
        ' ExStart:VerifyConnectedOrGluedShapes
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' Call a Diagram class constructor to load the VSD diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' Set two shape ids
        Dim ShapeIdOne As Long = 15
        Dim ShapeIdTwo As Long = 16

        ' Get Visio page by name
        Dim page As Page = diagram.Pages.GetPage("Page-3")

        ' Get Visio shapes by ids
        Dim ShapedOne As Shape = page.Shapes.GetShape(ShapeIdOne)
        Dim ShapedTwo As Shape = page.Shapes.GetShape(ShapeIdTwo)

        ' Determine whether shapes are connected
        Dim connected As Boolean = ShapedOne.IsConnected(ShapedTwo)
        Console.WriteLine("Shapes are connected: " & connected)

        ' Determine whether shapes are glued
        Dim glued As Boolean = ShapedOne.IsGlued(ShapedTwo)
        Console.WriteLine("Shapes are Glued: " & glued)
        ' ExEnd:VerifyConnectedOrGluedShapes
    End Sub
End Class
