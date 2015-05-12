'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Diagram. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////
Imports System.IO

Imports Aspose.Diagram

Namespace ExportDiagramToPDF
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Call the diagram constructor to load diagram from a VSD file
			Dim diagram As New Diagram(dataDir & "Drawing1.vsd")

			Dim pdfStream As New MemoryStream()
			diagram.Save(pdfStream, SaveFileFormat.PDF)

			Dim pdfFileStream As New FileStream(dataDir & "Drawing1.pdf", FileMode.Create, FileAccess.Write)
			pdfStream.WriteTo(pdfFileStream)
			pdfFileStream.Close()

			pdfStream.Close()

			' Display Status.
			System.Console.WriteLine("Conversion from vsd to pdf performed successfully.")
		End Sub
	End Class
End Namespace