//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Diagram. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Diagram;

namespace UpdatingShapeText
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Call the diagram constructor to load diagram from a VDX file
            Diagram vdxDiagram = new Diagram(dataDir + "Drawing1.vsd");

            //Find a particular shape and update its text
            foreach (Aspose.Diagram.Shape shape in vdxDiagram.Pages[0].Shapes)
            {
                if (shape.NameU.ToLower() == "process" && shape.ID == 1)
                {
                    shape.Text.Value.Clear();
                    shape.Text.Value.Add(new Txt("New Text"));
                }
            }
            vdxDiagram.Save(dataDir + "output.vdx", SaveFileFormat.VDX);

        }
    }
}