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
    Public Class ReadDiagramFile
        Public Shared Sub Run()
            'ExStart:ReadDiagramFile
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Diagrams()

            'Call the diagram constructor to load diagram from a VSD stream
            Dim st As New FileStream(dataDir & "ReadDiagramFile.vsd", FileMode.Open)

            Dim vsdDiagram As New Diagram(st)

            System.Console.WriteLine("Total Pages:" & vsdDiagram.Pages.Count)

            st.Close()
            'ExEnd:ReadDiagramFile
        End Sub
    End Class
End Namespace