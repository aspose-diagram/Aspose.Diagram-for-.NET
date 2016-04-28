Imports VisualBasic
Imports Aspose.Diagram
Imports Aspose.Diagram.Saving
Imports System

Public Class ExportOfHiddenVisioPagesToSVG
    Public Shared Sub Run()
        'ExStart:ExportOfHiddenVisioPagesToSVG
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Intro()

        ' load an existing Visio
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' get a particular page
        Dim page As Page = diagram.Pages.GetPage("Flow 2")
        ' set Visio page visiblity
        page.PageSheet.PageProps.UIVisibility.Value = BOOL.[False]

        ' initialize PDF save options
        Dim options As New SVGSaveOptions()
        ' set export option of hidden Visio pages
        options.ExportHiddenPage = False

        'Save the Visio diagram
        diagram.Save(dataDir & Convert.ToString("ExportOfHiddenVisioPagesToSVG_Out.svg"), options)
        'ExEnd:ExportOfHiddenVisioPagesToSVG
    End Sub
End Class
