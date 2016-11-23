Imports Aspose.Diagram
Imports System
Public Class AddSolutionXMLElement
    Public Shared Sub Run()
        ' ExStart:AddSolutionXMLElement
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_SolutionXML()

        ' Load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' Initialize SolutionXML object
        Dim solXML As New SolutionXML()
        ' Set name
        solXML.Name = "Solution XML"
        ' Set xml value
        solXML.XmlValue = "XML Value"
        ' Add SolutionXML element
        diagram.SolutionXMLs.Add(solXML)

        ' Save Visio diagram
        diagram.Save(dataDir & Convert.ToString("AddSolutionXMLElement_out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:AddSolutionXMLElement
    End Sub
End Class
