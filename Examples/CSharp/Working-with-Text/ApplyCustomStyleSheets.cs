using System.IO;
using Aspose.Diagram;
namespace Aspose.Diagram.Examples.CSharp.Shapes
{
    public class ApplyCustomStyleSheets
    {
        public static void Run()
        {
            // ExStart:ApplyCustomStyleSheets
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_ShapeText();

            // Load diagram
            Diagram vsdDiagram = new Diagram(dataDir + "ApplyCustomStyleSheets.vsd");
            // Get page by name
            Page page = vsdDiagram.Pages.GetPage("Flow 1");

            Shape sourceShape = null;
            // Find the shape to apply the style
            foreach (Aspose.Diagram.Shape shape in page.Shapes)
            {
                if (shape.Name == "Process")
                {
                    sourceShape = shape;
                    break;
                }
            }

            StyleSheet customStyleSheet = null;

            // Find the required style sheet
            foreach (StyleSheet styleSheet in vsdDiagram.StyleSheets)
            {
                if (styleSheet.Name == "Basic")
                {
                    customStyleSheet = styleSheet;
                    break;
                }
            }

            if (sourceShape != null && customStyleSheet != null)
            {
                // Apply text style
                sourceShape.TextStyle = customStyleSheet;
                // Apply fill style
                sourceShape.FillStyle = customStyleSheet;
                // Apply line style
                sourceShape.LineStyle = customStyleSheet;
            }

            // Save changed diagram as VDX
            vsdDiagram.Save(dataDir + "ApplyCustomStyleSheets_Out.vdx", SaveFileFormat.VDX);
            // ExEnd:ApplyCustomStyleSheets
 
        }
    }
}