'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Diagram. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////
Imports System.IO

Imports Aspose.Diagram

Namespace RetrievingPageInformation
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Call the diagram constructor to load diagram from a VDX file
			Dim vdxDiagram As New Diagram(dataDir & "drawing.vdx")

			For Each page As Aspose.Diagram.Page In vdxDiagram.Pages
				'Checks if current page is a background page
				If page.Background = Aspose.Diagram.BOOL.True Then
					'Display information about the background page
					Console.WriteLine("Background Page ID : " & page.ID)
					Console.WriteLine("Background Page Name : " & page.Name)
				Else
					'Display information about the foreground page
					Console.WriteLine(vbLf & "Page ID : " & page.ID)
					Console.WriteLine("Universal Name : " & page.NameU)
					Console.WriteLine("ID of the Background Page : " & page.BackPage)
				End If
			Next page

			Console.ReadLine()
		End Sub
	End Class
End Namespace