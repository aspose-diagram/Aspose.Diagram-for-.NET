using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_with_Layers
{
    public class AddLayer
    {
        public static void Run() 
        {
            // ExStart:AddLayer
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Layers();

            // load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // get Visio page
            Aspose.Diagram.Page page = diagram.Pages.GetPage("Page-1");

            // initialize a new Layer class object
            Layer layer = new Layer();
            // set Layer name
            layer.Name.Value = "Layer1";
            // set Layer Visibility
            layer.Visible.Value = BOOL.True;
            // add Layer to the particular page sheet
            page.PageSheet.Layers.Add(layer);

            // get shape by ID
            Shape shape = page.Shapes.GetShape(3);
            // assign shape to this new Layer
            shape.LayerMem.LayerMember.Value = layer.IX.ToString();
            // save diagram
            diagram.Save(dataDir + "AddLayer_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:AddLayer

        }
    }
}
