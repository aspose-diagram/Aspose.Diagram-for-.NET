'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Diagram. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Diagram

Namespace VisualBasic.Diagrams
    Public Class ExportToPDF
        Public Shared Sub Run()
            'ExStart:ExportToPDF
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Diagrams()

            'Call the diagram constructor to load a VSD diagram
            Dim diagram As New Diagram(dataDir & "ExportToPDF.vsd")

            Dim pdfStream As New MemoryStream()
            diagram.Save(pdfStream, SaveFileFormat.PDF)

            Dim pdfFileStream As New FileStream(dataDir & "ExportToPDF_Out.pdf", FileMode.Create, FileAccess.Write)
            pdfStream.WriteTo(pdfFileStream)
            pdfFileStream.Close()

            pdfStream.Close()

            ' Display Status.
            System.Console.WriteLine("Conversion from vsd to pdf performed successfully.")
            'ExEnd:ExportToPDF
        End Sub
    End Class
End Namespace