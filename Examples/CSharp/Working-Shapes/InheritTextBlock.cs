using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_Shapes
{
    public class InheritTextBlock
    {
        public static void Run()
        {
            // ExStart:InheritTextBlock
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // Call a Diagram class constructor to load the VSDX diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // Get page by name
            Page page = diagram.Pages.GetPage("Page-3");

            foreach (Aspose.Diagram.Shape shape in page.Shapes)
            {
		            Aspose.Diagram.TextBlock textblock = shape.InheritTextBlock;
		            Console.WriteLine(textblock.TopMargin.Value);
		            Console.WriteLine(textblock.BottomMargin.Value);
		            Console.WriteLine(textblock.RightMargin.Value);
		            Console.WriteLine(textblock.LeftMargin.Value);
		            Console.WriteLine(textblock.TextDirection.Value);
            }
            // ExEnd:InheritTextBlock
        }
    }
}
