using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_Shapes
{
    public class VerifyConnectedOrGluedShapes
    {
        public static void Run()
        {
            // ExStart:VerifyConnectedOrGluedShapes
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // call a Diagram class constructor to load the VSD diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // set two shape ids
            long ShapeIdOne = 15;
            long ShapeIdTwo = 16;

            // get Visio page by name
            Page page = diagram.Pages.GetPage("Page-3");

            // get Visio shapes by ids
            Shape ShapedOne = page.Shapes.GetShape(ShapeIdOne);
            Shape ShapedTwo = page.Shapes.GetShape(ShapeIdTwo);

            // determine whether shapes are connected
            bool connected = ShapedOne.IsConnected(ShapedTwo);
            Console.WriteLine("Shapes are connected: " + connected);

            // determine whether shapes are glued
            bool glued = ShapedOne.IsGlued(ShapedTwo);
            Console.WriteLine("Shapes are Glued: " + glued);
            // ExEnd:VerifyConnectedOrGluedShapes
        }
    }
}
