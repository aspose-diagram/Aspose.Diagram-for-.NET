using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Layers
{
    public class AddLayer
    {
        public static void Run() 
        {
            // ExStart:AddLayer
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Layers();

            // Load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // Get Visio page
            Aspose.Diagram.Page page = diagram.Pages.GetPage("Page-1");

            // Initialize a new Layer class object
            Layer layer = new Layer();
            // Set Layer name
            layer.Name.Value = "Layer1";
            // Set Layer Visibility
            layer.Visible.Value = BOOL.True;
            // Set the color checkbox of Layer
            layer.IsColorChecked = BOOL.True;
            // Add Layer to the particular page sheet
            page.PageSheet.Layers.Add(layer);

            // Get shape by ID
            Shape shape = page.Shapes.GetShape(3);
            // Assign shape to this new Layer
            shape.LayerMem.LayerMember.Value = layer.IX.ToString();
            // Save diagram
            diagram.Save(dataDir + "AddLayer_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:AddLayer

        }
    }
}
