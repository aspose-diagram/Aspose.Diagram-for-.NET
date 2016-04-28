Imports Aspose.Diagram
Imports System
Imports VisualBasic

Public Class InsertBlankPageInVisio
    Public Shared Sub Run()
        'ExStart:InsertBlankPageInVisio
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_VisioPages()

        ' Load diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' it calculates max page id
        Dim max As Integer = 0
        If diagram.Pages.Count <> 0 Then
            max = diagram.Pages(0).ID
        End If

        For i As Integer = 1 To diagram.Pages.Count - 1
            If max < diagram.Pages(i).ID Then
                max = diagram.Pages(i).ID
            End If
        Next

        ' set max page ID
        Dim MaxPageId As Integer = max

        ' Initialize a new page object
        Dim newPage As New Page()
        ' Set name
        newPage.Name = "new page"
        ' Set page ID
        newPage.ID = MaxPageId + 1

        ' Or try the Page constructor
        ' Page newPage = new Page(MaxPageId + 1);

        ' Add a new blank page
        diagram.Pages.Add(newPage)

        ' Save diagram
        diagram.Save(dataDir & Convert.ToString("InsertBlankPage_Out.vsdx"), SaveFileFormat.VSDX)
        'ExEnd:InsertBlankPageInVisio
    End Sub
End Class
