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

Namespace ProtectAndUnprotectDiagrams
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Load diagram
			Dim diagram As New Diagram(dataDir & "Drawing1.vsd")

			diagram.DocumentSettings.ProtectBkgnds = BOOL.True
			diagram.DocumentSettings.ProtectMasters = BOOL.True
			diagram.DocumentSettings.ProtectShapes = BOOL.True
			diagram.DocumentSettings.ProtectStyles = BOOL.True

			diagram.Save(dataDir & "output.vdx", SaveFileFormat.VDX)
		End Sub
	End Class
End Namespace