
Imports Aspose.Diagram
Imports System
Imports System.IO

Public Class ReplaceShapePicture
    Public Shared Sub Run()
        ' ExStart:ReplaceShapePicture
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' Call a Diagram class constructor to load the VSD diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("ExtractAllImagesFromPage.vsd"))
        ' Convert image into bytes array
        Dim imageBytes As Byte() = File.ReadAllBytes(dataDir & Convert.ToString("Picture.png"))

        ' Enter page index i.e. 0 for first one
        For Each shape As Shape In diagram.Pages(0).Shapes
            ' Filter shapes by type Foreign
            If shape.Type = Aspose.Diagram.TypeValue.Foreign Then
                Using stream As New System.IO.MemoryStream(shape.ForeignData.Value)
                    'replace picture shape
                    shape.ForeignData.Value = imageBytes
                End Using
            End If
        Next

        ' Save diagram
        diagram.Save(dataDir & Convert.ToString("ReplaceShapePicture_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:ReplaceShapePicture
    End Sub
End Class
