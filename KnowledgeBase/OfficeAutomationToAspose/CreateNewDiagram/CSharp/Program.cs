//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Diagram. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Diagram;

namespace CreateNewDiagram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            string visioStencil = dataDir + "Basic Shapes.vss";
            // Create a new diagram.
            Diagram diagram = new Diagram(visioStencil);

            //Add a new rectangle shape
            long shapeId = diagram.AddShape(
                4.25, 5.5, 2, 1, @"Rectangle", 0);
            Shape shape = diagram.Pages[0].Shapes.GetShape(shapeId);
            shape.Text.Value.Add(new Txt(@"Rectangle text."));

            //Add a new star shape
            shapeId = diagram.AddShape(
                2.0, 5.5, 2, 2, @"Star 7", 0);
            shape = diagram.Pages[0].Shapes.GetShape(shapeId);
            shape.Text.Value.Add(new Txt(@"Star text."));

            //Add a new hexagon shape
            shapeId = diagram.AddShape(
                7.0, 5.5, 2, 2, @"Hexagon", 0);
            shape = diagram.Pages[0].Shapes.GetShape(shapeId);
            shape.Text.Value.Add(new Txt(@"Hexagon text."));

            //Save the new diagram
            diagram.Save(dataDir + "Drawing1.vdx", SaveFileFormat.VDX);

            // Display Status.
            System.Console.WriteLine("Diagram created and saved successfully.");
        }
    }
}