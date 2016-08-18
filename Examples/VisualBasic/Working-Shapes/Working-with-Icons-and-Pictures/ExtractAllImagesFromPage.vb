Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram
Imports System

Namespace Diagrams
    Public Class ExtractAllImagesFromPage
        Public Shared Sub Run()
            ' ExStart:ExtractAllImagesFromPage
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Shapes()

            ' Call the diagram constructor to load diagram from a VSD file
            Dim diagram As New Diagram(dataDir & "ExtractAllImagesFromPage.vsd")

            ' Enter page index i.e. 0 for first one
            For Each shape As Shape In diagram.Pages(0).Shapes
                ' Filter shapes by type Foreign
                If shape.Type = Aspose.Diagram.TypeValue.Foreign Then
                    Using stream As New System.IO.MemoryStream(shape.ForeignData.Value)
                        ' Load memory stream into bitmap object
                        Dim bitmap As New System.Drawing.Bitmap(stream)

                        ' Save bmp here
                        bitmap.Save(dataDir & "ExtractAllImages" & shape.ID & ".bmp")
                    End Using
                End If
            Next shape
            ' ExEnd:ExtractAllImagesFromPage
        End Sub
    End Class
End Namespace