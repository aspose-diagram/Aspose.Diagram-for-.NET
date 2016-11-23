Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram
Imports System

Namespace Diagrams
    Public Class RetrieveConnectorInfo
        Public Shared Sub Run()
            ' ExStart:RetrieveConnectorInfo
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Diagrams()

            ' Call the diagram constructor to load diagram from a VSD file
            Dim vdxDiagram As New Diagram(dataDir & "RetrieveConnectorInfo.vsd")

            For Each connector As Aspose.Diagram.Connect In vdxDiagram.Pages(0).Connects
                ' Display information about the Connectors
                Console.WriteLine(Constants.vbLf & "From Shape ID : " & connector.FromSheet)
                Console.WriteLine("To Shape ID : " & connector.ToSheet)
            Next connector
            ' ExEnd:RetrieveConnectorInfo

        End Sub
    End Class
End Namespace