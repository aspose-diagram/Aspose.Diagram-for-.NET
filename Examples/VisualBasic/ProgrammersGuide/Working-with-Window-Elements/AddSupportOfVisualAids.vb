Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class AddSupportOfVisualAids
    Public Shared Sub Run()
        'ExStart:AddSupportOfVisualAids
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_WindowElements()

        ' load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' get window object by index
        Dim window As Window = diagram.Windows(0)
        ' check dynamic grid option
        window.DynamicGridEnabled = BOOL.True

        ' check connection points option
        window.ShowConnectionPoints = BOOL.True

        ' save visio drawing
        diagram.Save(dataDir & Convert.ToString("AddSupportOfVisualAids_Out.vsdx"), SaveFileFormat.VSDX)
        'ExEnd:AddSupportOfVisualAids
    End Sub
End Class
