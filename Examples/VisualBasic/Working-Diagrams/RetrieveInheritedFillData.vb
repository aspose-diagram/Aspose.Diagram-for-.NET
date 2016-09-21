Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram
Imports System

Namespace Diagrams
    Public Class RetrieveInheritedFillData
        Public Shared Sub Run()
            ' ExStart:RetrieveInheritedFillData
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_Diagrams()

            ' Call the diagram constructor to load a VSDX diagram
            Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

            ' Get page by ID
            Dim page As Page = diagram.Pages.GetPage("Page-1")
            ' Get shape by ID
            Dim shape As Shape = page.Shapes.GetShape(1)
            ' Get the fill formatting values
            Console.WriteLine(shape.InheritFill.FillBkgnd.Value)
            Console.WriteLine(shape.InheritFill.FillForegnd.Value)
            Console.WriteLine(shape.InheritFill.FillPattern.Value)
            Console.WriteLine(shape.InheritFill.ShapeShdwObliqueAngle.Value)
            Console.WriteLine(shape.InheritFill.ShapeShdwOffsetX.Value)
            Console.WriteLine(shape.InheritFill.ShapeShdwOffsetY.Value)
            Console.WriteLine(shape.InheritFill.ShapeShdwScaleFactor.Value)
            Console.WriteLine(shape.InheritFill.ShapeShdwType.Value)
            Console.WriteLine(shape.InheritFill.ShdwBkgnd.Value)
            Console.WriteLine(shape.InheritFill.ShdwBkgndTrans.Value)
            Console.WriteLine(shape.InheritFill.ShdwForegnd.Value)
            Console.WriteLine(shape.InheritFill.ShdwForegndTrans.Value)
            Console.WriteLine(shape.InheritFill.ShdwPattern.Value)
            ' ExEnd:RetrieveInheritedFillData
        End Sub
    End Class
End Namespace
