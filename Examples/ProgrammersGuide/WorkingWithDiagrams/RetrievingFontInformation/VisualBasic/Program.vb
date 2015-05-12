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
Imports System

Namespace RetrievingFontInformation
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Call the diagram constructor to load diagram from a VSD file
			Dim vdxDiagram As New Diagram(dataDir & "Drawing1.vsd")

			For Each font As Aspose.Diagram.Font In vdxDiagram.Fonts
				'Display information about the fonts
				Console.WriteLine(font.Name)
			Next font

		End Sub
	End Class
End Namespace