
Imports Aspose.Diagram
Imports System


Public Class RetrieveUserDefinedCells
    Public Shared Sub Run()
        ' ExStart:RetrieveUserDefinedCells
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_UserDefinedCells()
        Dim count As Integer = 0
        ' load diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' Iterate through pages
        For Each objPage As Aspose.Diagram.Page In diagram.Pages
            ' Iterate through shapes
            For Each objShape As Aspose.Diagram.Shape In objPage.Shapes
                Console.WriteLine(objShape.NameU)
                ' Iterate through user-defined cells
                For Each objUserField As Aspose.Diagram.User In objShape.Users
                    count += 1
                    Console.WriteLine(count.ToString() + " - Name: " + objUserField.NameU + " Value: " + objUserField.Value.Val + " Prompt: " + objUserField.Prompt.Value)
                Next
            Next
        Next
        ' ExEnd:RetrieveUserDefinedCells            
    End Sub
End Class
