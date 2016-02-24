'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Diagram. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Diagram

Namespace VisualBasic.Diagrams
    Public Class CreateDiagram
        Public Shared Sub Run()
            'ExStart:CreateDiagram
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Diagrams()

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            Dim diagram As New Diagram()
            diagram.Save(dataDir & "Diagram1.vdx", SaveFileFormat.VDX)
            'ExEnd:CreateDiagram
        End Sub
    End Class
End Namespace