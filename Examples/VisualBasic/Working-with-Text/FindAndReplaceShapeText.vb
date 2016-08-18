
Imports Aspose.Diagram
Imports System.Collections.Generic
Imports System

Public Class FindAndReplaceShapeText
    Public Shared Sub Run()
        ' ExStart:FindAndReplaceShapeText
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_ShapeText()

        ' Prepare a collection old and new text
        Dim replacements As New Dictionary(Of String, String)()
        replacements.Add("[[CompanyName]]", "Research Society of XYZ")
        replacements.Add("[[EmployeeName]]", "James Bond")
        replacements.Add("[[SubjectTitle]]", "The affect of the internet on social behavior in the industrialize world")
        replacements.Add("[[TimePeriod]]", DateTime.Now.AddYears(-1).ToString("dd/MMMM/yyyy") + " -- " + DateTime.Now.ToString("dd/MMMM/yyyy"))
        replacements.Add("[[SubmissionDate]]", DateTime.Now.AddDays(-7).ToString("dd/MMMM/yyyy"))
        replacements.Add("[[AmountReq]]", "$100,000")
        replacements.Add("[[DateApproved]]", DateTime.Now.AddDays(1).ToString("dd/MMMM/yyyy"))

        ' Load diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("FindReplaceText.vsdx"))
        ' Get page by name
        Dim page As Page = diagram.Pages.GetPage("Page-1")

        ' Iterate through the shapes of a page
        For Each shape As Shape In page.Shapes
            For Each kvp As KeyValuePair(Of String, String) In replacements
                For Each txt As FormatTxt In shape.Text.Value
                    Dim tx As Txt = TryCast(txt, Txt)
                    If tx IsNot Nothing AndAlso tx.Text.Contains(kvp.Key) Then
                        ' Find and replace text of a shape
                        tx.Text = tx.Text.Replace(kvp.Key, kvp.Value)
                    End If
                Next
            Next
        Next
        ' Save the diagram
        diagram.Save(dataDir & Convert.ToString("FindAndReplaceShapeText_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:FindAndReplaceShapeText
    End Sub
End Class
