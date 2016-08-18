
Imports Aspose.Diagram
Imports System

Public Class RotateVisioShape
    Public Shared Sub Run()
        ' ExStart:RotateVisioShape
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' Call a Diagram class constructor to load the VSDX diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' Get page by name
        Dim page As Page = diagram.Pages.GetPage("Page-3")
        ' Get shape by id
        Dim shape As Shape = page.Shapes.GetShape(16)

        ' Add a shape and set the angle
        shape.SetAngle(190)

        ' Save diagram
        diagram.Save(dataDir & Convert.ToString("RotateVisioShape_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:RotateVisioShape
    End Sub
End Class
