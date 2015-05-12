'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Diagram. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Diagram

Namespace ReadingDiagramFile
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Call the diagram constructor to load diagram from a VSD stream
			Dim st As New FileStream(dataDir & "Drawing1.vsd", FileMode.Open)

			Dim vsdDiagram As New Diagram(st)

			System.Console.WriteLine("Total Pages:" & vsdDiagram.Pages.Count)

			st.Close()

		End Sub
	End Class
End Namespace