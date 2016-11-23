Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram

Namespace Shapes
    Public Class SetXFormdata
        Public Shared Sub Run()
            ' ExStart:SetXFormdata
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Shapes()

            ' Call the diagram constructor to load diagram from a VDX file
            Dim vdxDiagram As New Diagram(dataDir & "SetXFormdata.vsd")

            ' Find a particular shape and update its XForm
            For Each shape As Aspose.Diagram.Shape In vdxDiagram.Pages(0).Shapes
                If shape.NameU.ToLower() = "process" AndAlso shape.ID = 1 Then
                    shape.XForm.PinX.Value = 5
                    shape.XForm.PinY.Value = 5
                End If
            Next shape
            vdxDiagram.Save(dataDir & "SetXFormdata_out.vsdx", SaveFileFormat.VSDX)
            ' ExEnd:SetXFormdata
        End Sub
    End Class
End Namespace