Imports Aspose.Diagram
Imports Aspose.Diagram.Saving
Imports System
Public Class UseSWFSaveOptions
    Public Shared Sub Run()
        ' ExStart:UseSWFSaveOptions
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_LoadSaveConvert()

        ' Call the diagram constructor to load diagram from a VSD file
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        Dim options As New SWFSaveOptions()

        ' Summary:
        '     value or the font is not installed locally, they may appear as a block,
        '     set the DefaultFont such as MingLiu or MS Gothic to show these
        '     characters.
        options.DefaultFont = "MS Gothic"

        ' Sets the number of pages to render in SWF.
        options.PageCount = 2

        ' Sets the 0-based index of the first page to render. Default is 0.
        options.PageIndex = 0
        ' Discard saving background pages of the Visio diagram
        options.SaveForegroundPagesOnly = True
        ' Specify whether the generated SWF document should include the integrated document viewer or not.
        options.ViewerIncluded = True

        diagram.Save(dataDir & Convert.ToString("UseSWFSaveOptions_out.swf"), options)
        ' ExEnd:UseSWFSaveOptions
    End Sub
End Class
