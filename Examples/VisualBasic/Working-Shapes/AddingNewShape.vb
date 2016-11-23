Imports System
Imports Aspose.Diagram
Public Class AddingNewShape
    Public Shared Sub Run()
        ' ExStart:AddingNewShape
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' Load a diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' Get page by name
        Dim page As Page = diagram.Pages.GetPage("Page-2")

        ' Add master with stencil file path and master id
        Dim masterName As String = "Rectangle"
        ' Add master with stencil file path and master name
        diagram.AddMaster(dataDir & Convert.ToString("Basic Shapes.vss"), masterName)

        ' Page indexing starts from 0
        Dim PageIndex As Integer = 1
        Dim width As Double = 2, height As Double = 2, pinX As Double = 4.25, pinY As Double = 4.5
        ' Add a new rectangle shape
        Dim rectangleId As Long = diagram.AddShape(pinX, pinY, width, height, masterName, PageIndex)

        ' Set shape properties 
        Dim rectangle As Shape = page.Shapes.GetShape(rectangleId)
        rectangle.XForm.PinX.Value = 5
        rectangle.XForm.PinY.Value = 5
        rectangle.Type = TypeValue.Shape
        rectangle.Text.Value.Add(New Txt("Aspose Diagram"))
        rectangle.TextStyle = diagram.StyleSheets(3)
        rectangle.Line.LineColor.Value = "#ff0000"
        rectangle.Line.LineWeight.Value = 0.03
        rectangle.Line.Rounding.Value = 0.1
        rectangle.Fill.FillBkgnd.Value = "#ff00ff"
        rectangle.Fill.FillForegnd.Value = "#ebf8df"

        diagram.Save(dataDir & Convert.ToString("AddShape_out.vsdx"), SaveFileFormat.VSDX)
        Console.WriteLine("Shape has been added.")
        ' ExEnd:AddingNewShape
    End Sub
End Class
