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
    Public Class ExportToHTML
        Public Shared Sub Run()
            ' ExStart:ExportToHTML
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_LoadSaveConvert()
            ' load diagram
            Dim diagram As New Diagram(dataDir & "ExportToHTML.vsd")
            ' save diagra in the HTML format
            diagram.Save(dataDir & "ExportToHTML_Out.html", SaveFileFormat.HTML)
            ' ExEnd:ExportToHTML
        End Sub
    End Class
End Namespace