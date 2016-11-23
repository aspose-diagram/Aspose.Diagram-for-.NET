Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram

Namespace Diagrams
    Public Class ExportToXML
        Public Shared Sub Run()
            ' ExStart:ExportToXML
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_LoadSaveConvert()

            ' 1.
            ' Exporting VSD to VDX
            ' Call the diagram constructor to load diagram from a VSD file
            Dim diagram As New Diagram(dataDir & "ExportToXML.vsd")

            ' Save input VSD as VDX
            diagram.Save(dataDir & "ExportToXML_out.vdx", SaveFileFormat.VDX)

            ' 2.
            ' Exporting from VSD to VSX
            ' Call the diagram constructor to load diagram from a VSD file

            ' Save input VSD as VSX
            diagram.Save(dataDir & "ExportToXML_out.vsx", SaveFileFormat.VSX)

            ' 3.
            ' Export VSD to VTX
            ' Save input VSD as VTX
            diagram.Save(dataDir & "ExportToXML_out.vtx", SaveFileFormat.VTX)
            ' ExEnd:ExportToXML
        End Sub
    End Class
End Namespace