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

            // load a Visio diagram
            Diagram diagram = new Diagram(dataDir + "SetLineData.vsd");
            // get the page by its name
            Aspose.Diagram.Page page1 = diagram.Pages.GetPage("Page-1");
            // get shape by its ID
            Aspose.Diagram.Shape shape = page1.Shapes.GetShape(1);
            // set line dash type by index
            shape.Line.LinePattern.Value = 4;
            // set line weight, defualt in PT
            shape.Line.LineWeight.Value = 2;
            // set color of the shape's line
            shape.Line.LineColor.Ufe.F = "RGB(95,108,53)";
            // set line rounding, default in inch
            shape.Line.Rounding.Value = 0.3125;
            // set line caps
            shape.Line.LineCap.Value = BOOL.True;
            // set line color transparency in percent
            shape.Line.LineColorTrans.Value = 50;

            /* add arrows to the connector or curve shapes */
            // select arrow type by index
            shape.Line.BeginArrow.Value = 4;
            shape.Line.EndArrow.Value = 4;
            // set arrow size 
            shape.Line.BeginArrowSize.Value = ArrowSizeValue.Large;
            shape.Line.BeginArrowSize.Value = ArrowSizeValue.Large;

            // save the Visio
            diagram.Save(dataDir + "SetLineData_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:SetLineData
        }
    }
}