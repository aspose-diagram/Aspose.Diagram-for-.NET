Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class AddPageLevelCommentInVisio
    Public Shared Sub Run()
        'ExStart:AddPageLevelCommentInVisio
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_VisioComments()

        ' Load diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' Add comment
        diagram.Pages(0).AddComment(7.20590551181102, 3.88070866141732, "test@")

        ' Save diagram
        diagram.Save(dataDir & Convert.ToString("AddComment_Out.vsdx"), SaveFileFormat.VSDX)
        'ExEnd:AddPageLevelCommentInVisio
    End Sub
End Class
