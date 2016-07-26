Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram
Imports System

Namespace Diagrams
    Public Class RetrieveMasterInfo
        Public Shared Sub Run()
            ' ExStart:RetrieveMasterInfo
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Master()

            ' Call the diagram constructor to load diagram from a VDX file
            Dim vdxDiagram As New Diagram(dataDir & "RetrieveMasterInfo.vdx")

            For Each master As Aspose.Diagram.Master In vdxDiagram.Masters
                ' Display information about the masters
                Console.WriteLine(Constants.vbLf & "Master ID : " & master.ID)
                Console.WriteLine("Master Name : " & master.Name)
            Next master

            Console.ReadLine()
            ' ExEnd:RetrieveMasterInfo
        End Sub
    End Class
End Namespace