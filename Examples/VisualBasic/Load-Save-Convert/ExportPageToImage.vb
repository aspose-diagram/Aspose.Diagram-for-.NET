Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram
Imports Aspose.Diagram.Saving

Namespace Diagrams
    Public Class ExportPageToImage
        Public Shared Sub Run()
            ' ExStart:ExportPageToImage
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_LoadSaveConvert()
            ' Load diagram
            Dim diagram As New Diagram(dataDir & "ExportPageToImage.vsd")

            ' Save diagram as PNG
            Dim options As New ImageSaveOptions(SaveFileFormat.PNG)

            ' Save one page only, by page index
            options.PageIndex = 0

            ' Save resultant Image file
            diagram.Save(dataDir & "ExportPageToImage_out.png", options)
            ' ExEnd:ExportPageToImage
        End Sub
    End Class
End Namespace