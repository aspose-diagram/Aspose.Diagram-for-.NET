Imports VisualBasic
Imports Aspose.Diagram
Imports Aspose.Diagram.Saving
Imports System

Public Class ExportOfHiddenVisioPagesToXPS
    Public Shared Sub Run()
        'ExStart:ExportOfHiddenVisioPagesToXPS
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Intro()

        ' load an existing Visio
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' get a particular page
        Dim page As Page = diagram.Pages.GetPage("Flow 2")
        ' set Visio page visiblity
        page.PageSheet.PageProps.UIVisibility.Value = BOOL.[False]

        ' initialize PDF save options
        Dim options As New XPSSaveOptions()
        ' set export option of hidden Visio pages
        options.ExportHiddenPage = False

        'Save the Visio diagram
        diagram.Save(dataDir & Convert.ToString("ExportOfHiddenVisioPagesToXPS_Out.xps"), options)
        'ExEnd:ExportOfHiddenVisioPagesToXPS
    End Sub
End Class
