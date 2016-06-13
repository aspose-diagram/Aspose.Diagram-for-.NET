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

Namespace VisualBasic.Diagrams
    Public Class ExportToImage
        Public Shared Sub Run()
            ' ExStart:ExportToImage
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_LoadSaveConvert()

            ' call the diagram constructor to load a VSD diagram
            Dim diagram As New Diagram(dataDir & "ExportToImage.vsd")

            ' Save Image file
            diagram.Save(dataDir & "ExportToImage_Out.png", SaveFileFormat.PNG)
            ' ExEnd:ExportToImage
        End Sub
    End Class
End Namespace