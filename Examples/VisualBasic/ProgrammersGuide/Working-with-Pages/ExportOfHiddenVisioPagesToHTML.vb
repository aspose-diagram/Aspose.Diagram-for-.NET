Imports VisualBasic
Imports Aspose.Diagram
Imports System
Imports Aspose.Diagram.Saving

Public Class ExportOfHiddenVisioPagesToHTML
    Public Shared Sub Run()
        'ExStart:ExportOfHiddenVisioPagesToHTML
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Intro()

        ' load an existing Visio
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' get a particular page
        Dim page As Page = diagram.Pages.GetPage("Flow 2")
        ' set Visio page visiblity
        page.PageSheet.PageProps.UIVisibility.Value = BOOL.[False]

        ' initialize PDF save options
        Dim options As New HTMLSaveOptions()
        ' set export option of hidden Visio pages
        options.ExportHiddenPage = False

        'Save the Visio diagram
        diagram.Save(dataDir & Convert.ToString("ExportOfHiddenVisioPagesToHTML_Out.html"), options)
        'ExEnd:ExportOfHiddenVisioPagesToHTML
    End Sub
End Class
