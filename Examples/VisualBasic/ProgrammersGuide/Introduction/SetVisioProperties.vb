Imports Aspose.Diagram
Imports System
Imports VisualBasic

Public Class SetVisioProperties
    Public Shared Sub Run()
        ' ExStart:SetVisioProperties

        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Intro()

        ' build path of an existing diagram
        Dim visioDrawing As String = dataDir & Convert.ToString("Drawing1.vsdx")

        ' Call the diagram constructor to load diagram from a VSDX file
        Dim diagram As New Diagram(visioDrawing)

        ' Set some summary information about the diagram
        diagram.DocumentProps.Creator = "Ijaz"
        diagram.DocumentProps.Company = "Aspose"
        diagram.DocumentProps.Category = "Drawing 2D"
        diagram.DocumentProps.Manager = "Sergey Polshkov"
        diagram.DocumentProps.Title = "Aspose Title"
        diagram.DocumentProps.TimeCreated = DateTime.Now
        diagram.DocumentProps.Subject = "Visio Diagram"
        diagram.DocumentProps.Template = "Aspose Template"

        ' Write the updated file to the disk in VSDX file format
        diagram.Save(dataDir & Convert.ToString("SetVisioProperties_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:SetVisioProperties
    End Sub
End Class
