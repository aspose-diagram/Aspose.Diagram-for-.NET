Imports Aspose.Diagram
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System
Public Class InsertTextShape
    Public Shared Sub Run()
        ' ExStart:InsertTextShape
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_ShapeText()

        ' Create a new diagram
        Dim diagram As New Diagram()
        ' Set parameters and add text to a Visio page
        Dim PinX As Double = 1, PinY As Double = 1, Width As Double = 1, Height As Double = 1
        diagram.Pages(0).AddText(PinX, PinY, Width, Height, "Test text")
        ' Save diagram 
        diagram.Save(dataDir & Convert.ToString("InsertTextShape_out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:InsertTextShape
    End Sub
End Class

