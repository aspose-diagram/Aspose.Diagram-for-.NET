using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_with_Hyperlinks
{
    public class GetHyperlinks
    {
        public static void Run()
        {
            //ExStart:GetHyperlinks
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Hyperlinks();

            // load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // get page by name
            Page page = diagram.Pages.GetPage("Page-1");
            // get shape by ID
            Shape shape = page.Shapes.GetShape(1);
            // iterate through the hyperlinks
            foreach (Aspose.Diagram.Hyperlink hyperlink in shape.Hyperlinks)
            {
                Console.WriteLine("Address: " + hyperlink.Address.Value);
                Console.WriteLine("Sub Address: " + hyperlink.SubAddress.Value);
                Console.WriteLine("Description: " + hyperlink.Description.Value);
            }       
            //ExEnd:GetHyperlinks
        }
    }
}
