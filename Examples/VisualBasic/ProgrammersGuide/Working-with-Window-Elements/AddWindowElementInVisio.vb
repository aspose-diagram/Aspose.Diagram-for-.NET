Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class AddWindowElementInVisio
    Public Shared Sub Run()
        'ExStart:AddWindowElementInVisio
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_WindowElements()

        ' load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' initialize window object
        Dim window As New Window()
        ' set window state
        window.WindowState = WindowStateValue.Maximized
        ' set window height
        window.WindowHeight = 500
        ' set window width
        window.WindowWidth = 500
        ' set window type
        window.WindowType = WindowTypeValue.Stencil
        ' add window object
        diagram.Windows.Add(window)

        ' save in any supported format
        diagram.Save(dataDir & Convert.ToString("AddWindowElementInVisio_Out.vsdx"), SaveFileFormat.VSDX)
        'ExEnd:AddWindowElementInVisio
    End Sub
End Class
