Imports System
Imports Aspose.Diagram
Public Class SpecifyFontLocation
    Public Shared Sub Run()
        ' ExStart:SpecifyFontLocation
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Intro()

        Dim fontDirs As String() = New String() {"C:\MyFonts\", "D:\Misc\Fonts\"}
        ' Load the Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' Setting the custom font directories
        diagram.FontDirs = fontDirs

        ' Saving Visio diagram in PDF format
        diagram.Save(dataDir & Convert.ToString("SetFontsFolders_out.pdf"), SaveFileFormat.PDF)
        ' ExEnd:SpecifyFontLocation
    End Sub
End Class
