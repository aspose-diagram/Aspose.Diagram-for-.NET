Imports Aspose.Diagram
Imports System.IO
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Aspose.Words.Replacing
Public Class ManipulateObjects
    Public Shared Sub Run()
        ' ExStart:ManipulateObjects
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_OLEObjects()

        ' Load a Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' Get page of the Visio diagram by name
        Dim page As Aspose.Diagram.Page = diagram.Pages.GetPage("Page-1")
        ' Get shape of the Visio diagram by ID
        Dim OLE_Shape As Aspose.Diagram.Shape = page.Shapes.GetShape(2)

        ' Filter shapes by type Foreign
        If OLE_Shape.Type = Aspose.Diagram.TypeValue.Foreign Then
            If OLE_Shape.ForeignData.ForeignType = ForeignType.[Object] Then
                Dim Ole_stream As Stream = New MemoryStream(OLE_Shape.ForeignData.ObjectData)
                ' Get format of the OLE file object
                Dim info As Aspose.Words.FileFormatInfo = Aspose.Words.FileFormatUtil.DetectFileFormat(Ole_stream)
                If info.LoadFormat = Aspose.Words.LoadFormat.Doc OrElse info.LoadFormat = Aspose.Words.LoadFormat.Docx Then
                    ' Modify an OLE object
                    Dim doc = New Aspose.Words.Document(New MemoryStream(OLE_Shape.ForeignData.ObjectData))
                    doc.Range.Replace("testing", "Aspose", New FindReplaceOptions())
                    Dim outStream As New MemoryStream()
                    doc.Save(outStream, Aspose.Words.SaveFormat.Docx)
                    ' Save back an OLE object
                    OLE_Shape.ForeignData.ObjectData = outStream.ToArray()
                End If
            End If
        End If
        ' Save Visio diagram
        diagram.Save(dataDir & Convert.ToString("ManipulateObjects_out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:ManipulateObjects
    End Sub
End Class

