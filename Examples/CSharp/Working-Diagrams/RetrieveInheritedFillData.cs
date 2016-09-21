using System.IO;
using Aspose.Diagram;
using System;

namespace Aspose.Diagram.Examples.CSharp.Diagrams
{
    public class RetrieveInheritedFillData
    {
        public static void Run()
        {
            // ExStart:RetrieveInheritedFillData
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Diagrams();

            // Call the diagram constructor to load a VSDX diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // Get page by ID
            Page page = diagram.Pages.GetPage("Page-1");
            // Get shape by ID
            Shape shape = page.Shapes.GetShape(1);
            // Get the fill formatting values
            Console.WriteLine(shape.InheritFill.FillBkgnd.Value);
            Console.WriteLine(shape.InheritFill.FillForegnd.Value);
            Console.WriteLine(shape.InheritFill.FillPattern.Value);
            Console.WriteLine(shape.InheritFill.ShapeShdwObliqueAngle.Value);
            Console.WriteLine(shape.InheritFill.ShapeShdwOffsetX.Value);
            Console.WriteLine(shape.InheritFill.ShapeShdwOffsetY.Value);
            Console.WriteLine(shape.InheritFill.ShapeShdwScaleFactor.Value);
            Console.WriteLine(shape.InheritFill.ShapeShdwType.Value);
            Console.WriteLine(shape.InheritFill.ShdwBkgnd.Value);
            Console.WriteLine(shape.InheritFill.ShdwBkgndTrans.Value);
            Console.WriteLine(shape.InheritFill.ShdwForegnd.Value);
            Console.WriteLine(shape.InheritFill.ShdwForegndTrans.Value);
            Console.WriteLine(shape.InheritFill.ShdwPattern.Value);
            // ExEnd:RetrieveInheritedFillData
        }
    }
}