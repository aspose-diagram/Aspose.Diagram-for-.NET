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
    Public Class ExportToXML
        Public Shared Sub Run()
            'ExStart:ExportToXML
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Diagrams()

            ' 1.
            ' Exporting VSD to VDX
            'Call the diagram constructor to load diagram from a VSD file
            Dim diagram As New Diagram(dataDir & "ExportToXML.vsd")

            'Save input VSD as VDX
            diagram.Save(dataDir & "ExportToXML_Out.vdx", SaveFileFormat.VDX)

            ' 2.
            ' Exporting from VSD to VSX
            ' Call the diagram constructor to load diagram from a VSD file

            'Save input VSD as VSX
            diagram.Save(dataDir & "ExportToXML_Out.vsx", SaveFileFormat.VSX)

            ' 3.
            ' Export VSD to VTX
            'Save input VSD as VTX
            diagram.Save(dataDir & "ExportToXML_Out.vtx", SaveFileFormat.VTX)
            'ExEnd:ExportToXML
        End Sub
    End Class
End Namespace