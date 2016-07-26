Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram

Namespace Diagrams
    Public Class VisioDiagramProtection
        Public Shared Sub Run()
            ' ExStart:VisioDiagramProtection
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Protection()

            ' Load diagram
            Dim diagram As New Diagram(dataDir & "ProtectAndUnprotect.vsd")

            diagram.DocumentSettings.ProtectBkgnds = BOOL.True
            diagram.DocumentSettings.ProtectMasters = BOOL.True
            diagram.DocumentSettings.ProtectShapes = BOOL.True
            diagram.DocumentSettings.ProtectStyles = BOOL.True
            ' save diagram
            diagram.Save(dataDir & "VisioDiagramProtection_Out.vdx", SaveFileFormat.VDX)
            ' ExEnd:VisioDiagramProtection
        End Sub
    End Class
End Namespace