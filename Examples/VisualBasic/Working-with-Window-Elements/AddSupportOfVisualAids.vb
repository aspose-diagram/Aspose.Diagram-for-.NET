Imports Aspose.Diagram
Imports System
Public Class AddSupportOfVisualAids
    Public Shared Sub Run()
        ' ExStart:AddSupportOfVisualAids
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_WindowElements()

        ' Load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' Get window object by index
        Dim window As Window = diagram.Windows(0)
        ' Check dynamic grid option
        window.DynamicGridEnabled = BOOL.True

        ' Check connection points option
        window.ShowConnectionPoints = BOOL.True

        ' Save visio drawing
        diagram.Save(dataDir & Convert.ToString("AddSupportOfVisualAids_out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:AddSupportOfVisualAids
    End Sub
End Class
