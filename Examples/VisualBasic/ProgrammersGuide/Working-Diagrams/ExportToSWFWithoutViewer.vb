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
Imports Aspose.Diagram.Saving

Namespace VisualBasic.Diagrams
    Public Class ExportToSWFWithoutViewer
        Public Shared Sub Run()
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Diagrams()

            'instantiate Diagram Object and open VSD file
            Dim diagram As New Diagram(dataDir & "ExportToSWFWithoutViewer.vsd")

            'Instantiate the Save Options
            Dim options As New SWFSaveOptions()

            'Set Save format as SWF
            options.SaveFormat = SaveFileFormat.SWF

            ' Exclude the embedded viewer
            options.ViewerIncluded = False

            'Save the resultant SWF file
            diagram.Save(dataDir & "Output.swf", SaveFileFormat.SWF)

        End Sub
    End Class
End Namespace