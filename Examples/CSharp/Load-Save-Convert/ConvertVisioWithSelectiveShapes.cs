using Aspose.Diagram.Saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Load_Save_Convert
{
    public class ConvertVisioWithSelectiveShapes
    {
        public static void Run()
        {
            // ExStart:ConvertVisioWithSelectiveShapes
            // the path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();

            // call the diagram constructor to load diagram from a VSD file
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // create an instance SVG save options class
            SVGSaveOptions options = new SVGSaveOptions();
            ShapeCollection shapes = options.Shapes;

            // get shapes by page index and shape ID, and then add in the shape collection object
            shapes.Add(diagram.Pages[0].Shapes.GetShape(1));
            shapes.Add(diagram.Pages[0].Shapes.GetShape(2));

            // save Visio drawing
            diagram.Save(dataDir + "SelectiveShapes_out.svg", options);
            // ExEnd:ConvertVisioWithSelectiveShapes
        }
    }
}
