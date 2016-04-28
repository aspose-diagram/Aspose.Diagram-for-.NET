using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_Shapes
{
    public class AddingNewShape
    {
        public static void Run()
        {
            //ExStart:AddingNewShape
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            //Load a diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // get page by name
            Page page = diagram.Pages.GetPage("Page-2");

            // Add master with stencil file path and master id
            string masterName = "Rectangle";
            // Add master with stencil file path and master name
            diagram.AddMaster(dataDir + "Basic Shapes.vss", masterName);
            
            // page indexing starts from 0
            int PageIndex = 1;
            double width = 2, height = 2, pinX = 4.25, pinY = 4.5;
            //Add a new rectangle shape
            long rectangleId = diagram.AddShape(pinX, pinY, width, height, masterName, PageIndex);
            
            // set shape properties 
            Shape rectangle = page.Shapes.GetShape(rectangleId);
            rectangle.XForm.PinX.Value = 5;
            rectangle.XForm.PinY.Value = 5;
            rectangle.Type = TypeValue.Shape;
            rectangle.Text.Value.Add(new Txt("Aspose Diagram"));
            rectangle.TextStyle = diagram.StyleSheets[3];
            rectangle.Line.LineColor.Value = "#ff0000";
            rectangle.Line.LineWeight.Value = 0.03;
            rectangle.Line.Rounding.Value = 0.1;
            rectangle.Fill.FillBkgnd.Value = "#ff00ff";
            rectangle.Fill.FillForegnd.Value = "#ebf8df";

            diagram.Save(dataDir + "AddShape_Out.vsdx", SaveFileFormat.VSDX);
            Console.WriteLine("Shape has been added.");
            //ExEnd:AddingNewShape
        }
    }
}
