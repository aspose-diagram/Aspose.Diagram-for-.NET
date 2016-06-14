Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram

Namespace Diagrams
    Public Class CreateDiagram
        Public Shared Sub Run()
            ' ExStart:CreateDiagram
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Diagrams()

            ' Create directory if it is not already present.
            Dim IsExists As Boolean = System.IO.Directory.Exists(dataDir)
            If (Not IsExists) Then
                System.IO.Directory.CreateDirectory(dataDir)
            End If

            Dim diagram As New Diagram()
            diagram.Save(dataDir & "CreateDiagram_Out.vsdx", SaveFileFormat.VSDX)
            ' ExEnd:CreateDiagram
        End Sub
    End Class
End Namespace