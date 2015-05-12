//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Diagram. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Diagram;

namespace AddNewShape
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Load a diagram
            Diagram diagram = new Diagram(dataDir + "\\Drawing1.vsd");

            //Get first page
            if (diagram.Pages.Count == 0)
            {
                // Display Status.
                System.Console.WriteLine("The diagram does not contain pages.");
                return;
            }
            Page page0 = diagram.Pages[0];
            //Get the rectangle master
            Master masterRectangle = null;
            foreach (Master master in diagram.Masters)
                if (master.Name == "Rectangle")
                {
                    masterRectangle = master;
                    break;
                }
            if (masterRectangle == null)
            {
                // Display Status.
                System.Console.WriteLine("The diagram does not contain rectangle's master.");
                return;
            }
            //Get the next shape ID
            long nextID = -1L;
            foreach (Page page in diagram.Pages)
                foreach (Shape shape in page.Shapes)
                {
                    long temp = GetMaxShapeID(shape);
                    if (temp > nextID)
                        nextID = temp;
                }
            nextID++;

            //Set shape properties and add it in the shapes' collection
            Shape rectangle = new Shape();
            rectangle.Master = masterRectangle;
            rectangle.MasterShape = masterRectangle.Shapes[0];
            rectangle.ID = nextID;
            rectangle.XForm.PinX.Value = 5;
            rectangle.XForm.PinY.Value = 5;
            rectangle.Type = TypeValue.Shape;
            rectangle.Text.Value.Add(new Txt("Aspose Diagram"));
            rectangle.TextStyle = diagram.StyleSheets[3];
            //rectangle.Line.LineColor.Value = page0.Shapes[1].Fill.FillForegnd.Value;
            rectangle.Line.LineWeight.Value = 0.03041666666666667;
            rectangle.Line.Rounding.Value = 0.1;
            rectangle.Fill.FillBkgnd.Value = page0.Shapes[0].Fill.FillBkgnd.Value;
            rectangle.Fill.FillForegnd.Value = "#ebf8df";
            page0.Shapes.Add(rectangle);

            diagram.Save(dataDir + "\\output.vdx", SaveFileFormat.VDX);
            
            // Display Status.
            System.Console.WriteLine("Shape has been added successfully.");
        }

        private static long GetMaxShapeID(Shape shape)
        {
            long max = shape.ID;
            foreach (Shape child in shape.Shapes)
            {
                long temp = GetMaxShapeID(child);
                if (temp > max)
                    max = temp;
            }
            return max;
        }
    }
}