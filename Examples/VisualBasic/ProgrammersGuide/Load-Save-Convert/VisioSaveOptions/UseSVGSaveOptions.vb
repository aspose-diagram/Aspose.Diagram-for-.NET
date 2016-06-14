
Imports Aspose.Diagram
Imports Aspose.Diagram.Saving
Imports System

Public Class UseSVGSaveOptions
    Public Shared Sub Run()
        ' ExStart:UseSVGSaveOptions
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_LoadSaveConvert()

        ' Call the diagram constructor to load diagram from a VSD file
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        Dim options As New SVGSaveOptions()

        ' Summary:
        '     value or the font is not installed locally, they may appear as a block,
        '     set the DefaultFont such as MingLiu or MS Gothic to show these
        '     characters.
        options.DefaultFont = "MS Gothic"
        ' sets the 0-based index of the first page to render. Default is 0.
        options.PageIndex = 0

        ' set page size
        Dim pgSize As New PageSize(PaperSizeFormat.A1)
        options.PageSize = pgSize

        diagram.Save(dataDir & Convert.ToString("UseSVGSaveOptions_Out.svg"), options)
        ' ExEnd:UseSVGSaveOptions
    End Sub
End Class
