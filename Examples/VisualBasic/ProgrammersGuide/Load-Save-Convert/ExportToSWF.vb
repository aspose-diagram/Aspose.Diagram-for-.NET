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
            Try
                ' ExStart:ExportToSWF
                ' The path to the documents directory.
                Dim dataDir As String = RunExamples.GetDataDir_Diagrams()
                ' load diagram
                Dim diagram As New Diagram(dataDir & "ActvDir.vsd")
                ' save diagram
                ' ExEnd:ExportToSWF
                diagram.Save(dataDir & "Output_Out.swf", SaveFileFormat.SWF)
            Catch ex As System.Exception
                System.Console.WriteLine("This example will only work if you apply a valid Aspose License. You can purchase full license or get 30 day temporary license from http://www.aspose.com/purchase/default.aspx.")
            End Try
        End Sub
    End Class
End Namespace