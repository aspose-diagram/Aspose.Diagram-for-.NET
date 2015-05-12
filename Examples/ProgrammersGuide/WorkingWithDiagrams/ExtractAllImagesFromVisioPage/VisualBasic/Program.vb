'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Diagram. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////
Imports System.IO

Imports Aspose.Diagram

Namespace ExtractAllImagesFromVisioPage
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Call the diagram constructor to load diagram from a VSD file
			Dim diagram As New Diagram(dataDir & "drawing.vsd")

			'enter page index i.e. 0 for first one
			For Each shape As Shape In diagram.Pages(0).Shapes
				'Filter shapes by type Foreign
				If shape.Type = Aspose.Diagram.TypeValue.Foreign Then
					Using stream As New System.IO.MemoryStream(shape.ForeignData.Value)
						'Load memory stream into bitmap object
						Dim bitmap As New System.Drawing.Bitmap(stream)

						' save bmp here
						bitmap.Save(dataDir & "Image" & shape.ID & ".bmp")
					End Using
				End If
			Next shape
		End Sub
	End Class
End Namespace