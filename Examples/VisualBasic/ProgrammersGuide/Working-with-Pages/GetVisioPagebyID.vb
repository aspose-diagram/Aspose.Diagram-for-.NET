Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class GetVisioPagebyID
    Public Shared Sub Run()
        'ExStart:GetVisioPagebyID
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_VisioPages()

        ' Call the diagram constructor to load diagram from a VDX file
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' Set page id
        Dim pageid As Integer = 2
        ' Get page object by id
        Dim page2 As Page = diagram.Pages.GetPage(pageid)
        'ExEnd:GetVisioPagebyID
    End Sub
End Class
