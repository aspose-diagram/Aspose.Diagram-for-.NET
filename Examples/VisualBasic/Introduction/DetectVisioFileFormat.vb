Imports System.IO
Imports System
Imports Aspose.Diagram
Public Class DetectVisioFileFormat
    Public Shared Sub Run()
        ' ExStart:DetectVisioFileFormat
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Intro()

        ' Load an existing Visio file in the stream
        Dim st As New FileStream(dataDir & Convert.ToString("Drawing1.vsdx"), FileMode.Open)

        ' Detect file format using the direct file path
        Dim info As FileFormatInfo = FileFormatUtil.DetectFileFormat(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' Detect file format using the direct file path
        Dim infoFromStream As FileFormatInfo = FileFormatUtil.DetectFileFormat(st)

        ' Get the detected file format
        Console.WriteLine("The spreadsheet format is: " & info.FileFormatType)

        ' Get the detected file format from the file stream
        Console.WriteLine("The spreadsheet format is (from the file stream): " & info.FileFormatType)
        ' ExEnd:DetectVisioFileFormat
    End Sub
End Class
