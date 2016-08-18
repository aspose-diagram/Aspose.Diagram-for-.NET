
Imports Aspose.Diagram
Imports System

Public Class RerouteConnectors
    Public Shared Sub Run()
        ' ExStart:RerouteConnectors
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' Call a Diagram class constructor to load the VSDX diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' Get page by name
        Dim page As Page = diagram.Pages.GetPage("Page-3")

        ' Get a particular connector shape
        Dim shape As Shape = page.Shapes.GetShape(18)
        ' Set reroute option
        shape.Layout.ConFixedCode.Value = ConFixedCodeValue.NeverReroute

        ' Save Visio diagram
        diagram.Save(dataDir & Convert.ToString("RerouteConnectors_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:RerouteConnectors
    End Sub
End Class
