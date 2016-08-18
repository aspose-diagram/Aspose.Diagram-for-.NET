using System.IO;
using Aspose.Diagram;
namespace Aspose.Diagram.Examples.CSharp.Shapes
{
    public class SetLineData
    {
        public static void Run()
        {
            // ExStart:SetLineData
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // Load a Visio diagram
            Diagram diagram = new Diagram(dataDir + "SetLineData.vsd");
            // Get the page by its name
            Aspose.Diagram.Page page1 = diagram.Pages.GetPage("Page-1");
            // Get shape by its ID
            Aspose.Diagram.Shape shape = page1.Shapes.GetShape(1);
            // Set line dash type by index
            shape.Line.LinePattern.Value = 4;
            // Set line weight, defualt in PT
            shape.Line.LineWeight.Value = 2;
            // Set color of the shape's line
            shape.Line.LineColor.Ufe.F = "RGB(95,108,53)";
            // Set line rounding, default in inch
            shape.Line.Rounding.Value = 0.3125;
            // Set line caps
            shape.Line.LineCap.Value = BOOL.True;
            // Set line color transparency in percent
            shape.Line.LineColorTrans.Value = 50;

            /* add arrows to the connector or curve shapes */
            // Select arrow type by index
            shape.Line.BeginArrow.Value = 4;
            shape.Line.EndArrow.Value = 4;
            // Set arrow size 
            shape.Line.BeginArrowSize.Value = ArrowSizeValue.Large;
            shape.Line.BeginArrowSize.Value = ArrowSizeValue.Large;

            // Save the Visio
            diagram.Save(dataDir + "SetLineData_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:SetLineData
        }
    }
}