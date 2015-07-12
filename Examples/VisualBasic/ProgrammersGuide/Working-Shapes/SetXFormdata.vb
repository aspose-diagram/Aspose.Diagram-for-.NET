'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Diagram. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Diagram

Namespace VisualBasic.Shapes
    Public Class SetXFormdata
        Public Shared Sub Run()
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Shapes()

            'Call the diagram constructor to load diagram from a VDX file
            Dim vdxDiagram As New Diagram(dataDir & "SetXFormdata.vsd")

            'Find a particular shape and update its XForm
            For Each shape As Aspose.Diagram.Shape In vdxDiagram.Pages(0).Shapes
                If shape.NameU.ToLower() = "process" AndAlso shape.ID = 1 Then
                    shape.XForm.PinX.Value = 5
                    shape.XForm.PinY.Value = 5
                End If
            Next shape
            vdxDiagram.Save(dataDir & "output.vdx", SaveFileFormat.VDX)

        End Sub
    End Class
End Namespace