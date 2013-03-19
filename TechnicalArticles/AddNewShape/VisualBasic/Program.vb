'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Diagram. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////
Imports System.IO

Imports Aspose.Diagram

Namespace AddNewShape
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Load a diagram
			Dim diagram As New Diagram(dataDir & "\Drawing1.vsd")

			'Get first page
			If diagram.Pages.Count = 0 Then
				' Display Status.
				System.Console.WriteLine("The diagram does not contain pages.")
				Return
			End If
			Dim page0 As Page = diagram.Pages(0)
			'Get the rectangle master
			Dim masterRectangle As Master = Nothing
			For Each master As Master In diagram.Masters
				If master.Name = "Rectangle" Then
					masterRectangle = master
					Exit For
				End If
			Next master
			If masterRectangle Is Nothing Then
				' Display Status.
				System.Console.WriteLine("The diagram does not contain rectangle's master.")
				Return
			End If
			'Get the next shape ID
			Dim nextID As Long = -1L
			For Each page As Page In diagram.Pages
				For Each shape As Shape In page.Shapes
					Dim temp As Long = GetMaxShapeID(shape)
					If temp > nextID Then
						nextID = temp
					End If
				Next shape
			Next page
			nextID += 1

			'Set shape properties and add it in the shapes' collection
			Dim rectangle As New Shape()
			rectangle.Master = masterRectangle
			rectangle.MasterShape = masterRectangle.Shapes(0)
			rectangle.ID = nextID
			rectangle.XForm.PinX.Value = 5
			rectangle.XForm.PinY.Value = 5
			rectangle.Type = TypeValue.Shape
			rectangle.Text.Value.Add(New Txt("Aspose Diagram"))
			rectangle.TextStyle = diagram.StyleSheets(3)
			'rectangle.Line.LineColor.Value = page0.Shapes[1].Fill.FillForegnd.Value;
			rectangle.Line.LineWeight.Value = 0.03041666666666667
			rectangle.Line.Rounding.Value = 0.1
			rectangle.Fill.FillBkgnd.Value = page0.Shapes(0).Fill.FillBkgnd.Value
			rectangle.Fill.FillForegnd.Value = "#ebf8df"
			page0.Shapes.Add(rectangle)

			diagram.Save(dataDir & "\output.vdx", SaveFileFormat.VDX)

			' Display Status.
			System.Console.WriteLine("Shape has been added successfully.")
		End Sub

		Private Shared Function GetMaxShapeID(ByVal shape As Shape) As Long
			Dim max As Long = shape.ID
			For Each child As Shape In shape.Shapes
				Dim temp As Long = GetMaxShapeID(child)
				If temp > max Then
					max = temp
				End If
			Next child
			Return max
		End Function
	End Class
End Namespace