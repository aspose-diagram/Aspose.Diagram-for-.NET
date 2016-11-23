Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram

Namespace Diagrams
    Public Class ExportToPDF
        Public Shared Sub Run()
            ' ExStart:ExportToPDF
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_LoadSaveConvert()

            ' Call the diagram constructor to load a VSD diagram
            Dim diagram As New Diagram(dataDir & "ExportToPDF.vsd")

            Dim pdfStream As New MemoryStream()
            diagram.Save(pdfStream, SaveFileFormat.PDF)

            Dim pdfFileStream As New FileStream(dataDir & "ExportToPDF_out.pdf", FileMode.Create, FileAccess.Write)
            pdfStream.WriteTo(pdfFileStream)
            pdfFileStream.Close()

            pdfStream.Close()

            ' Display Status.
            System.Console.WriteLine("Conversion from vsd to pdf performed successfully.")
            ' ExEnd:ExportToPDF
        End Sub
    End Class
End Namespace