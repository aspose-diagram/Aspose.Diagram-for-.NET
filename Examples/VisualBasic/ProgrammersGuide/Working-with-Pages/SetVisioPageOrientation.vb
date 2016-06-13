Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class SetVisioPageOrientation
    Public Shared Sub Run()
        ' ExStart:SetVisioPageOrientation
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_VisioPages()

        ' initialize the new visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' get Visio page
        Dim page As Aspose.Diagram.Page = diagram.Pages.GetPage("Flow 1")
        ' page orientation
        page.PageSheet.PrintProps.PrintPageOrientation.Value = PrintPageOrientationValue.Landscape
        ' save Visio
        diagram.Save(dataDir & Convert.ToString("SetPageOrientation_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:SetVisioPageOrientation
    End Sub
End Class
