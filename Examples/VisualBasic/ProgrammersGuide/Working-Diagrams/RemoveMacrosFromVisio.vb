Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class RemoveMacrosFromVisio
    Public Shared Sub Run()
        ' ExStart:RemoveMacrosFromVisio
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Diagrams()

        ' load a Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' remove all macros
        diagram.VbProjectData = Nothing

        ' Save diagram
        diagram.Save(dataDir & Convert.ToString("RemoveMacrosFromVisio_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:RemoveMacrosFromVisio
    End Sub
End Class
