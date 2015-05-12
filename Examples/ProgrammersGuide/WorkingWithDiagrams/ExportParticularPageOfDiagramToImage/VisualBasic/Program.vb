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
Imports Aspose.Diagram.Saving

Namespace ExportParticularPageOfDiagramToImage
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			Dim diagram As New Diagram(dataDir & "Drawing1.vsd")

			'Save diagram as PNG
			Dim options As New ImageSaveOptions(SaveFileFormat.PNG)

			' Save one page only, by page index
			options.PageIndex = 0

			'Save resultant Image file
			diagram.Save(dataDir & "output.png", options)

		End Sub
	End Class
End Namespace