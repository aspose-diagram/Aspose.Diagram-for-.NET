Imports Aspose.Diagram
Imports System
Public Class GetVisioPagebyName
    Public Shared Sub Run()
        ' ExStart:GetVisioPagebyName
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_VisioPages()

        ' Call the diagram constructor to load diagram from a VDX file
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' Set page name
        Dim pageName As String = "Flow 2"
        ' Get page object by name
        Dim page2 As Page = diagram.Pages.GetPage(pageName)
        ' ExEnd:GetVisioPagebyName
    End Sub
End Class
