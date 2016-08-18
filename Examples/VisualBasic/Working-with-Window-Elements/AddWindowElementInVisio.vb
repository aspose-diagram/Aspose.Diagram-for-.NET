
Imports Aspose.Diagram
Imports System

Public Class AddWindowElementInVisio
    Public Shared Sub Run()
        ' ExStart:AddWindowElementInVisio
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_WindowElements()

        ' Load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' Initialize window object
        Dim window As New Window()
        ' Set window state
        window.WindowState = WindowStateValue.Maximized
        ' Set window height
        window.WindowHeight = 500
        ' Set window width
        window.WindowWidth = 500
        ' Set window type
        window.WindowType = WindowTypeValue.Stencil
        ' Add window object
        diagram.Windows.Add(window)

        ' Save in any supported format
        diagram.Save(dataDir & Convert.ToString("AddWindowElementInVisio_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:AddWindowElementInVisio
    End Sub
End Class
