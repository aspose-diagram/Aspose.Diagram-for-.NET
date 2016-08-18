using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Hyperlinks
{
    public class GetHyperlinks
    {
        public static void Run()
        {
            // ExStart:GetHyperlinks
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Hyperlinks();

            // Load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // Get page by name
            Page page = diagram.Pages.GetPage("Page-1");
            // Get shape by ID
            Shape shape = page.Shapes.GetShape(1);
            // Iterate through the hyperlinks
            foreach (Aspose.Diagram.Hyperlink hyperlink in shape.Hyperlinks)
            {
                Console.WriteLine("Address: " + hyperlink.Address.Value);
                Console.WriteLine("Sub Address: " + hyperlink.SubAddress.Value);
                Console.WriteLine("Description: " + hyperlink.Description.Value);
            }       
            // ExEnd:GetHyperlinks
        }
    }
}
