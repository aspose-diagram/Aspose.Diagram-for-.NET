using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_with_Text_Boxes
{
    public class FormatShapeTextBlockSection
    {
        public static void Run() 
        {
            // ExStart:FormatShapeTextBlockSection
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_ShapeTextBoxData();
            
            // load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // get the page by its name
            Aspose.Diagram.Page page1 = diagram.Pages.GetPage("Page-1");
            // get shape by its ID
            Aspose.Diagram.Shape shape = page1.Shapes.GetShape(1);
            // set orientation angle
            DoubleValue margin = new DoubleValue(4, MeasureConst.PT);

            // set left, right, top and bottom margins of the shape's text block
            shape.TextBlock.LeftMargin = margin;
            shape.TextBlock.RightMargin = margin;
            shape.TextBlock.TopMargin = margin;
            shape.TextBlock.BottomMargin = margin;
            // set the text direction
            shape.TextBlock.TextDirection.Value = TextDirectionValue.Vertical;
            // set the text alignment
            shape.TextBlock.VerticalAlign.Value = VerticalAlignValue.Middle;
            // set the text block background color
            shape.TextBlock.TextBkgnd.Ufe.F = "RGB(95,108,53)";
            // set the background color transparency in percent
            shape.TextBlock.TextBkgndTrans.Value = 50;
            // set the distance between default tab stops for the selected shape.
            shape.TextBlock.DefaultTabStop.Value = 2;

            // save Visio
            diagram.Save(dataDir + "FormatShapeTextBlockSection_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:FormatShapeTextBlockSection
        }
    }
}
