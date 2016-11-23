Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram

Namespace Diagrams
    Public Class ExportToImage
        Public Shared Sub Run()
            ' ExStart:ExportToImage
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_LoadSaveConvert()

            ' Call the diagram constructor to load a VSD diagram
            Dim diagram As New Diagram(dataDir & "ExportToImage.vsd")

            ' Save Image file
            diagram.Save(dataDir & "ExportToImage_out.png", SaveFileFormat.PNG)
            ' ExEnd:ExportToImage
        End Sub
    End Class
End Namespace