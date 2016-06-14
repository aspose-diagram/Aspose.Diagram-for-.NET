Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram

Namespace Shapes
    Public Class SetFillData
        Public Shared Sub Run()
            ' ExStart:SetFillData
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Shapes()

            ' Call the diagram constructor to load diagram from a VSD file
            Dim vdxDiagram As New Diagram(dataDir & "SetFillData.vsd")

            ' Find a particular shape and update its XForm
            For Each shape As Aspose.Diagram.Shape In vdxDiagram.Pages(0).Shapes
                If shape.NameU.ToLower() = "rectangle" AndAlso shape.ID = 1 Then
                    shape.Fill.FillBkgnd.Value = vdxDiagram.Pages(1).Shapes(0).Fill.FillBkgnd.Value
                    shape.Fill.FillForegnd.Value = "#ebf8df"
                End If
            Next shape
            ' save diagram
            vdxDiagram.Save(dataDir & "SetFillData_Out.vsdx", SaveFileFormat.VDX)
            ' ExEnd:SetFillData
        End Sub
    End Class
End Namespace