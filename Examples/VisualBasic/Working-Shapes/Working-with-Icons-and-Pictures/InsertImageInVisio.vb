
Imports Aspose.Diagram
Imports System.IO
Imports System

Public Class InsertImageInVisio
    Public Shared Sub Run()
        ' ExStart:InsertImageInVisio
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' Create a new diagram
        Dim diagram As New Diagram()

        ' Get page object by index
        Dim page0 As Page = diagram.Pages(0)
        ' Set pinX, pinY, width and height
        Dim pinX As Double = 2, pinY As Double = 2, width As Double = 4, hieght As Double = 3

        ' Import Bitmap image as Visio shape
        page0.AddShape(pinX, pinY, width, hieght, New FileStream(dataDir & Convert.ToString("image.bmp"), FileMode.OpenOrCreate))

        ' Save Visio diagram
        diagram.Save(dataDir & Convert.ToString("InsertImageInVisio_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:InsertImageInVisio
    End Sub
End Class
