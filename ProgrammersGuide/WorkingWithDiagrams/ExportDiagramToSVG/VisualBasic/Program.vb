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

Namespace ExportDiagramToSVG
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			' Call the diagram constructor to load diagram from a VSD file
			Dim diagram As New Diagram(dataDir & "Drawing1.vsd")

			'Save SVG Output file
			diagram.Save(dataDir & "Output.svg", SaveFileFormat.SVG)

		End Sub
	End Class
End Namespace