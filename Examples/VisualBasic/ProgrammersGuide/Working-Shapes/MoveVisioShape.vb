Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class MoveVisioShape
    Public Shared Sub Run()
        'ExStart:MoveVisioShape
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' call a Diagram class constructor to load the VSDX diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' get page by name
        Dim page As Page = diagram.Pages.GetPage("Page-3")
        ' get shape by id
        Dim shape As Shape = page.Shapes.GetShape(16)
        ' move shape from its position, it adds values in coordinates
        shape.Move(1, 1)

        ' save diagram
        diagram.Save(dataDir & Convert.ToString("MoveVisioShape_Out.vsdx"), SaveFileFormat.VSDX)
        'ExEnd:MoveVisioShape
    End Sub
End Class
