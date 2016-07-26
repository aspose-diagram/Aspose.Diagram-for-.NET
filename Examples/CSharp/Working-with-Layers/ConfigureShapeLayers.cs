using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Layers
{
    public class ConfigureShapeLayers
    {
        public static void Run()
        {
            // ExStart:ConfigureShapeLayers
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Layers();

            // load a source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // get page by name
            Page page = diagram.Pages.GetPage("Page-1");

            // iterate through the shapes
            foreach (Aspose.Diagram.Shape shape in page.Shapes)
            {
                if (shape.Name.ToLower() == "shape1")
                {
                    // Add shape1 in first two layers. Here "0;1" are indexes of the layers
                    LayerMem layer = shape.LayerMem;
                    layer.LayerMember.Value = "0;1";
                }
                else if (shape.Name.ToLower() == "shape2")
                {
                    // Remove shape2 from all the layers
                    LayerMem layer = shape.LayerMem;
                    layer.LayerMember.Value = "";
                }
                else if (shape.Name.ToLower() == "shape3")
                {
                    // Add shape3 in first layer. Here "0" is index of the first layer
                    LayerMem layer = shape.LayerMem;
                    layer.LayerMember.Value = "0";
                }
            }
            // save diagram
            diagram.Save(dataDir + "ConfigureShapeLayers_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:ConfigureShapeLayers
        }
    }
}
