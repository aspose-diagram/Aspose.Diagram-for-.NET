Imports Aspose.Diagram
Imports System


Public Class CopyVisioPage
    Public Shared Sub Run()
        ' ExStart:CopyVisioPage
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_VisioPages()

        ' initialize the new visio diagram
        Dim NewDigram As New Diagram()

        ' load source diagram
        Dim dgm As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' add all masters from the source Visio diagram
        For Each master As Master In dgm.Masters
            NewDigram.Masters.Add(master)
        Next

        ' get page object
        Dim SrcPage As Aspose.Diagram.Page = dgm.Pages.GetPage("Page-1")
        ' Set name
        SrcPage.Name = "new page"

        ' it calculates max page id
        Dim max As Integer = 0
        If NewDigram.Pages.Count <> 0 Then
            max = NewDigram.Pages(0).ID
        End If

        For i As Integer = 1 To NewDigram.Pages.Count - 1
            If max < NewDigram.Pages(i).ID Then
                max = NewDigram.Pages(i).ID
            End If
        Next

        ' set max page ID 
        Dim MaxPageId As Integer = max
        ' Set page ID
        SrcPage.ID = MaxPageId + 1

        ' add page from the source diagram
        NewDigram.Pages.Add(SrcPage)
        ' remove first empty page
        NewDigram.Pages.Remove(NewDigram.Pages(0))
        ' save diagram
        NewDigram.Save(dataDir & Convert.ToString("CopyVisioPage_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:CopyVisioPage
    End Sub
End Class
