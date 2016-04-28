Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class EditPageLevelCommentInVisio
    Public Shared Sub Run()
        'ExStart:EditPageLevelCommentInVisio
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_VisioComments()

        ' load Visio
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' get collection of the annotations
        Dim annotations As AnnotationCollection = diagram.Pages.GetPage("Page-1").PageSheet.Annotations

        ' iterate through the annotations
        For Each annotation As Annotation In annotations
            Dim comment As String = annotation.Comment.Value
            comment += "Updation mark"
            annotation.Comment.Value = comment
        Next
        ' save Visio
        diagram.Save(dataDir & Convert.ToString("EditComment_Out.vsdx"), SaveFileFormat.VSDX)
        'ExEnd:EditPageLevelCommentInVisio
    End Sub
End Class
