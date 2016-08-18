Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram

Namespace Diagrams
    Public Class ExportToSWF
        Public Shared Sub Run()
            Try
                ' ExStart:ExportToSWF
                ' The path to the documents directory.
                Dim dataDir As String = RunExamples.GetDataDir_Diagrams()
                ' Load diagram
                Dim diagram As New Diagram(dataDir & "ActvDir.vsd")
                ' Save diagram
                ' ExEnd:ExportToSWF
                diagram.Save(dataDir & "Output_Out.swf", SaveFileFormat.SWF)
            Catch ex As System.Exception
                System.Console.WriteLine("This example will only work if you apply a valid Aspose License. You can purchase full license or get 30 day temporary license from http://www.aspose.com/purchase/default.aspx.")
            End Try
        End Sub
    End Class
End Namespace