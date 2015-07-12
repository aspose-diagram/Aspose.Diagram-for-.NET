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

Namespace VisualBasic.Diagrams
    Public Class ExportToXPS
        Public Shared Sub Run()
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Diagrams()

            'Open VSD file
            Dim diagram As New Diagram(dataDir & "ExportToXPS.vsd")

            'Save diagram to XPS format
            diagram.Save(dataDir & "Output.xps", SaveFileFormat.XPS)


        End Sub
    End Class
End Namespace