Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram
Imports System

Namespace Shapes
    Public Class RetrieveShapeInfo
        Public Shared Sub Run()
            ' ExStart:RetrieveShapeInfo
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Shapes()

            ' Load diagram
            Dim vsdDiagram As New Diagram(dataDir & "RetrieveShapeInfo.vsd")

            For Each shape As Aspose.Diagram.Shape In vsdDiagram.Pages(0).Shapes
                ' Display information about the shapes
                Console.WriteLine(Constants.vbLf & "Shape ID : " & shape.ID)
                Console.WriteLine("Name : " & shape.Name)
                Console.WriteLine("Master Shape : " & shape.Master.Name)
            Next shape
            ' ExEnd:RetrieveShapeInfo
        End Sub
    End Class
End Namespace