using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Layers
{
    public class RetrieveAllLayers
    {
        public static void Run() 
        {
            // ExStart:RetrieveAllLayers
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Layers();

            // load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // get Visio page
            Aspose.Diagram.Page page = diagram.Pages.GetPage("Page-1");

            // iterate through the layers
            foreach (Layer layer in page.PageSheet.Layers)
            {
                Console.WriteLine("Name: " + layer.Name.Value);
                Console.WriteLine("Visibility: " + layer.Visible.Value);
                Console.WriteLine("Status: " + layer.Status.Value);
            }
            // ExEnd:RetrieveAllLayers
        }
    }
}
