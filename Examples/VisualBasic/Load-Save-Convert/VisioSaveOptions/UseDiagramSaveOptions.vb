Imports Aspose.Diagram
Imports Aspose.Diagram.Saving
Imports System
Public Class UseDiagramSaveOptions
    Public Shared Sub Run()
        ' ExStart:UseDiagramSaveOptions
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_LoadSaveConvert()

        ' Call the diagram constructor to a VSDX diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' Options when saving a diagram into Visio format
        Dim options As New DiagramSaveOptions(SaveFileFormat.VSDX)

        ' Summary:
        '     When characters in the diagram are unicode and not be set with correct font
        '     value or the font is not installed locally, they may appear as block,
        '     image or XPS.  Set the DefaultFont such as MingLiu or MS Gothic to show these
        '     characters.
        options.DefaultFont = "MS Gothic"

        ' Summary:
        '     Defines whether need enlarge page to fit drawing content or not.
        ' Remarks:
        '     Default value is false.
        options.AutoFitPageToDrawingContent = True

        diagram.Save(dataDir & Convert.ToString("UseDiagramSaveOptions_out.vsdx"), options)
        ' ExEnd:UseDiagramSaveOptions
    End Sub
End Class
