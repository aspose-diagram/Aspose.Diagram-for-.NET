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
    Public Class VisioDiagramProtection
        Public Shared Sub Run()
            ' ExStart:VisioDiagramProtection
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Protection()

            ' Load diagram
            Dim diagram As New Diagram(dataDir & "ProtectAndUnprotect.vsd")

            diagram.DocumentSettings.ProtectBkgnds = BOOL.True
            diagram.DocumentSettings.ProtectMasters = BOOL.True
            diagram.DocumentSettings.ProtectShapes = BOOL.True
            diagram.DocumentSettings.ProtectStyles = BOOL.True
            ' save diagram
            diagram.Save(dataDir & "VisioDiagramProtection_Out.vdx", SaveFileFormat.VDX)
            ' ExEnd:VisioDiagramProtection
        End Sub
    End Class
End Namespace