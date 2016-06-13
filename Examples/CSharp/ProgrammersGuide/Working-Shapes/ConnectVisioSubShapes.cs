using Aspose.Diagram;
using Aspose.Diagram.Manipulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_Shapes
{
    public class ConnectVisioSubShapes
    {
        public static void Run()
        {
            // ExStart:ConnectVisioSubShapes
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // set sub shape ids
            long shapeFromId = 2;
            long shapeToId = 4;

            // load diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // access a particular page
            Page page = diagram.Pages.GetPage("Page-3");
           
            // initialize connector shape
            Shape shape = new Shape();
            shape.Line.EndArrow.Value = 4;
            shape.Line.LineWeight.Value = 0.01388;

            // add shape
            long connecter1Id = diagram.AddShape(shape, "Dynamic connector", page.ID);
            // connect sub-shapes
            page.ConnectShapesViaConnector(shapeFromId, ConnectionPointPlace.Right, shapeToId, ConnectionPointPlace.Left, connecter1Id);
            // save Visio drawing
            diagram.Save(dataDir + "ConnectVisioSubShapes_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:ConnectVisioSubShapes
        }
    }
}
