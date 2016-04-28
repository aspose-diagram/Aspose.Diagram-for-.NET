Imports Aspose.Diagram
Imports VisualBasic
Imports System

Public Class ApplyFontOnText
    Public Shared Sub Run()
        'ExStart:ApplyFontOnText
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_ShapeText()

        ' load diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' get page by name
        Dim page As Page = diagram.Pages.GetPage("Page-1")
        ' get shape by ID
        Dim shape As Shape = page.Shapes.GetShape(1)
        ' clear shape text values and chars
        shape.Text.Value.Clear()
        shape.Chars.Clear()

        ' mark character run and add text
        shape.Text.Value.Add(New Cp(0))
        shape.Text.Value.Add(New Txt("TextStyle_Regular\n"))
        shape.Text.Value.Add(New Cp(1))
        shape.Text.Value.Add(New Txt("TextStyle_Bold_Italic\n"))
        shape.Text.Value.Add(New Cp(2))
        shape.Text.Value.Add(New Txt("TextStyle_Underline_Italic\n"))
        shape.Text.Value.Add(New Cp(3))
        shape.Text.Value.Add(New Txt("TextStyle_Bold_Italic_Underline"))

        ' add formatting characters
        shape.Chars.Add(New Aspose.Diagram.Char())
        shape.Chars.Add(New Aspose.Diagram.Char())
        shape.Chars.Add(New Aspose.Diagram.Char())
        shape.Chars.Add(New Aspose.Diagram.Char())

        'set properties e.g. color, font, size and style etc.
        shape.Chars(0).IX = 0
        shape.Chars(0).Color.Value = "#FF0000"
        shape.Chars(0).Font.Value = 4
        shape.Chars(0).Size.Value = 0.22
        shape.Chars(0).Style.Value = StyleValue.Undefined

        'set properties e.g. color, font, size and style etc.
        shape.Chars(1).IX = 1
        shape.Chars(1).Color.Value = "#FF00FF"
        shape.Chars(1).Font.Value = 4
        shape.Chars(1).Size.Value = 0.22
        shape.Chars(1).Style.Value = StyleValue.Bold Or StyleValue.Italic

        'set properties e.g. color, font, size and style etc.
        shape.Chars(2).IX = 2
        shape.Chars(2).Color.Value = "#00FF00"
        shape.Chars(2).Font.Value = 4
        shape.Chars(2).Size.Value = 0.22
        shape.Chars(2).Style.Value = StyleValue.Underline Or StyleValue.Italic

        'set properties e.g. color, font, size and style etc.
        shape.Chars(3).IX = 3
        shape.Chars(3).Color.Value = "#3333FF"
        shape.Chars(3).Font.Value = 4
        shape.Chars(3).Size.Value = 0.22
        shape.Chars(3).Style.Value = StyleValue.Bold Or StyleValue.Italic Or StyleValue.Underline
        ' save diagram
        diagram.Save(dataDir & Convert.ToString("ApplyFontOnText_Out.vsdx"), SaveFileFormat.VSDX)
        'ExEnd:ApplyFontOnText
    End Sub
End Class
