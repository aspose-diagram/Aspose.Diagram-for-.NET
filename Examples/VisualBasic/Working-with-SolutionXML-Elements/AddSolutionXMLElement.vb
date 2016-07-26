
Imports Aspose.Diagram
Imports System

Public Class AddSolutionXMLElement
    Public Shared Sub Run()
        ' ExStart:AddSolutionXMLElement
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_SolutionXML()

        ' load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' initialize SolutionXML object
        Dim solXML As New SolutionXML()
        ' set name
        solXML.Name = "Solution XML"
        ' set xml value
        solXML.XmlValue = "XML Value"
        ' add SolutionXML element
        diagram.SolutionXMLs.Add(solXML)

        ' save Visio diagram
        diagram.Save(dataDir & Convert.ToString("AddSolutionXMLElement_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:AddSolutionXMLElement
    End Sub
End Class
