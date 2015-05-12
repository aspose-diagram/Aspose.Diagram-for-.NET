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

Namespace SettingFillData
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Call the diagram constructor to load diagram from a VSD file
			Dim vdxDiagram As New Diagram(dataDir & "Drawing1.vsd")

			'Find a particular shape and update its XForm
			For Each shape As Aspose.Diagram.Shape In vdxDiagram.Pages(0).Shapes
				If shape.NameU.ToLower() = "rectangle" AndAlso shape.ID = 1 Then
					shape.Fill.FillBkgnd.Value = vdxDiagram.Pages(1).Shapes(0).Fill.FillBkgnd.Value
					shape.Fill.FillForegnd.Value = "#ebf8df"
				End If
			Next shape
			vdxDiagram.Save(dataDir & "output.vdx", SaveFileFormat.VDX)


		End Sub
	End Class
End Namespace