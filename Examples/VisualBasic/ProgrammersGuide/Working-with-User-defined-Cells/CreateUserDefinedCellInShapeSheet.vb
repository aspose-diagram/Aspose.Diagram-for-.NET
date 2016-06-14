
Imports Aspose.Diagram
Imports System

Public Class CreateUserDefinedCellInShapeSheet
    Public Shared Sub Run()
        ' ExStart:CreateUserDefinedCellInShapeSheet
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_UserDefinedCells()

        ' load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' get page by name
        Dim page As Page = diagram.Pages.GetPage("Page-1")
        ' get shape by id
        Dim shape As Shape = page.Shapes.GetShape(2)

        ' initialize user object
        Dim user As New User()
        user.Name = "UserDefineCell"
        user.Value.Val = "800"
        ' add user-defined cell
        shape.Users.Add(user)

        ' save diagram
        diagram.Save(dataDir & Convert.ToString("CreateUserDefinedCellInShapeSheet_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:CreateUserDefinedCellInShapeSheet
    End Sub
End Class
