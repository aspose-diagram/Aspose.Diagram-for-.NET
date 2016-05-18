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
    Public Class ExportToSWF
        Public Shared Sub Run()
            'ExStart:ExportToSWF
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Diagrams()
            ' load a VSD diagram
            Dim diagram As New Diagram(dataDir & "ExportToSWFWithoutViewer.vsd")
            ' save diagram in the SWF format
            diagram.Save(dataDir & "ExportToSWF_Out.swf", SaveFileFormat.SWF)
            'ExEnd:ExportToSWF
        End Sub
    End Class
End Namespace