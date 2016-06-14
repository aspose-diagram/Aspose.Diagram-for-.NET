Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram

Namespace Diagrams
    Public Class ReadDiagramFile
        Public Shared Sub Run()
            ' ExStart:ReadDiagramFile
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Diagrams()

            ' call the diagram constructor to load a VSD stream
            Dim st As New FileStream(dataDir & "ReadDiagramFile.vsd", FileMode.Open)
            ' load diagram
            Dim vsdDiagram As New Diagram(st)
            ' get pages count
            System.Console.WriteLine("Total Pages:" & vsdDiagram.Pages.Count)

            st.Close()
            ' ExEnd:ReadDiagramFile
        End Sub
    End Class
End Namespace