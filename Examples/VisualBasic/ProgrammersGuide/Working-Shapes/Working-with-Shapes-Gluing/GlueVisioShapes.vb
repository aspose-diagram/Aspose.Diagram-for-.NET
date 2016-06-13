Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class GlueVisioShapes
    Public Shared Sub Run()
        ' ExStart:GlueVisioShapes
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' Load diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' Get a particular page
        Dim page As Page = diagram.Pages.GetPage("Page-1")
        ' set shape id
        Dim shape1_ID As Long = 7
        Dim shape2_ID As Long = 494
        ' Glue shapes
        page.GlueShapes(shape1_ID, Aspose.Diagram.Manipulation.ConnectionPointPlace.Center, shape2_ID)

        ' Save diagram
        diagram.Save(dataDir & Convert.ToString("GlueVisioShapes_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:GlueVisioShapes
    End Sub
End Class
