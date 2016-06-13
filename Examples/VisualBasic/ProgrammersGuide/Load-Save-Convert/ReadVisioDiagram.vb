Imports VisualBasic
Imports System.IO
Imports Aspose.Diagram
Imports System

Public Class ReadVisioDiagram
    Public Shared Sub Run()
        ' ExStart:ReadVisioDiagram
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_LoadSaveConvert()

        ' call the diagram constructor to load a VSD stream
        Dim st As New FileStream(dataDir & Convert.ToString("Drawing1.vsdx"), FileMode.Open)
        Dim vsdDiagram As New Diagram(st)
        st.Close()

        ' call the diagram constructor to load a VDX diagram
        Dim vdxDiagram As New Diagram(dataDir & Convert.ToString("Drawing1.vdx"))

        ' * Call diagram constructor to load a VSS stencil
        ' * providing load file format
        Dim vssDiagram As New Diagram(dataDir & Convert.ToString("Basic.vss"), LoadFileFormat.VSS)

        '* Call diagram constructor to load diagram from a VSX file
        '* providing load options
        Dim loadOptions As New LoadOptions(LoadFileFormat.VSX)
        Dim vsxDiagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsx"), loadOptions)
        ' ExEnd:ReadVisioDiagram
    End Sub
End Class
