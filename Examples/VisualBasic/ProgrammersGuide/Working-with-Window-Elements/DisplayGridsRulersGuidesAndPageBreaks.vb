
Imports Aspose.Diagram
Imports System

Public Class DisplayGridsRulersGuidesAndPageBreaks
    Public Shared Sub Run()
        ' ExStart:DisplayGridsRulersGuidesAndPageBreaks
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_WindowElements()

        ' load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' get window object by index
        Dim window As Window = diagram.Windows(0)
        ' set visibility of grid
        window.ShowGrid = BOOL.True
        ' set visibility of guides
        window.ShowGuides = BOOL.True
        ' set visibility of rulers
        window.ShowRulers = BOOL.True
        ' set visibility of page breaks
        window.ShowPageBreaks = BOOL.True

        ' save diagram
        diagram.Save(dataDir & Convert.ToString("DisplayGridsRulersGuidesAndPageBreaks_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:DisplayGridsRulersGuidesAndPageBreaks
    End Sub
End Class
