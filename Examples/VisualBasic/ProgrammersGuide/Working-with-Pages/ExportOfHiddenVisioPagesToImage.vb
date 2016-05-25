Imports VisualBasic
Imports Aspose.Diagram
Imports Aspose.Diagram.Saving
Imports System

Public Class ExportOfHiddenVisioPagesToImage
    Public Shared Sub Run()
        Try
            'ExStart:ExportOfHiddenVisioPagesToImage
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Intro()

            ' load an existing Visio
            Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
            ' get a particular page
            Dim page As Page = diagram.Pages.GetPage("Flow 2")
            ' set Visio page visiblity
            page.PageSheet.PageProps.UIVisibility.Value = BOOL.[False]

            ' initialize PDF save options
            Dim options As New ImageSaveOptions(SaveFileFormat.JPEG)
            ' set export option of hidden Visio pages
            options.ExportHiddenPage = False

            'Save the Visio diagram
            diagram.Save(dataDir & Convert.ToString("ExportOfHiddenVisioPagesToImage_Out.jpeg"), options)
            'ExEnd:ExportOfHiddenVisioPagesToImage
        Catch ex As System.Exception
            System.Console.WriteLine("This example will only work if you apply a valid Aspose License. You can purchase full license or get 30 day temporary license from http://www.aspose.com/purchase/default.aspx.")
        End Try
    End Sub
End Class
