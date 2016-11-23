Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram
Imports Aspose.Diagram.Saving

Namespace Diagrams
    Public Class ExportToSWFWithoutViewer
        Public Shared Sub Run()
            Try
                ' ExStart:ExportToSWFWithoutViewer
                ' The path to the documents directory.
                Dim dataDir As String = RunExamples.GetDataDir_Diagrams()

                ' Instantiate Diagram Object and open VSD file
                Dim diagram As New Diagram(dataDir & "ExportToSWFWithoutViewer.vsd")

                ' Instantiate the Save Options
                Dim options As New SWFSaveOptions()

                ' Set Save format as SWF
                options.SaveFormat = SaveFileFormat.SWF

                ' Exclude the embedded viewer
                options.ViewerIncluded = False

                ' Save the resultant SWF file
                diagram.Save(dataDir & "ExportToSWFWithoutViewer_out.swf", SaveFileFormat.SWF)
                ' ExEnd:ExportToSWFWithoutViewer
            Catch ex As System.Exception
                System.Console.WriteLine("This example will only work if you apply a valid Aspose License. You can purchase full license or get 30 day temporary license from http://www.aspose.com/purchase/default.aspx.")
            End Try
        End Sub
    End Class
End Namespace