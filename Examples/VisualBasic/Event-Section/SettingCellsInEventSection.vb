Imports Aspose.Diagram
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Event_Section
    Public Class SettingCellsInEventSection
        Public Shared Sub Run()
            ' ExStart:SettingCellsInEventSection
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_EventSection()

            ' Load diagram
            Dim diagram As New Diagram(dataDir & "TestTemplate.vsdm")
            ' Get page
            Dim page As Aspose.Diagram.Page = diagram.Pages.GetPage(0)
            ' Get shape id
            Dim shapeId As Long = page.AddShape(3.0, 3.0, 0.36, 0.36, "Square")
            ' Get shape
            Dim shape As Aspose.Diagram.Shape = page.Shapes.GetShape(shapeId)

            ' Set event cells in the ShapeSheet
            shape.[Event].EventXFMod.Ufe.F = "CALLTHIS(""ThisDocument.ShowAlert"")"
            shape.[Event].EventDblClick.Ufe.F = "CALLTHIS(""ThisDocument.ShowAlert"")"
            shape.[Event].EventDrop.Ufe.F = "CALLTHIS(""ThisDocument.ShowAlert"")"
            shape.[Event].EventMultiDrop.Ufe.F = "CALLTHIS(""ThisDocument.ShowAlert"")"
            shape.[Event].TheText.Ufe.F = "CALLTHIS(""ThisDocument.ShowAlert"")"
            shape.[Event].TheData.Ufe.F = "CALLTHIS(""ThisDocument.ShowAlert"")"

            ' Save diagram
            diagram.Save(dataDir & "SettingCellsInEventSection_out.vsdm", SaveFileFormat.VSDM)
            ' ExEnd:SettingCellsInEventSection
        End Sub
    End Class
End Namespace

