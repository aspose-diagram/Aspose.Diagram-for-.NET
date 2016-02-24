'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Diagram. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Diagram
Imports System

Namespace VisualBasic.Shapes
    Public Class RetrieveShapeInfo
        Public Shared Sub Run()
            'ExStart:RetrieveShapeInfo
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Shapes()

            'Load diagram
            Dim vsdDiagram As New Diagram(dataDir & "RetrieveShapeInfo.vsd")

            For Each shape As Aspose.Diagram.Shape In vsdDiagram.Pages(0).Shapes
                'Display information about the shapes
                Console.WriteLine(Constants.vbLf & "Shape ID : " & shape.ID)
                Console.WriteLine("Name : " & shape.Name)
                Console.WriteLine("Master Shape : " & shape.Master.Name)
            Next shape
            'ExEnd:RetrieveShapeInfo
        End Sub
    End Class
End Namespace