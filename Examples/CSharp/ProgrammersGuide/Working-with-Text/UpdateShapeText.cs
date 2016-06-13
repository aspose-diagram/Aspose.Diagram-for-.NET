//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Diagram. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Diagram;

namespace CSharp.Shapes
{
    public class UpdateShapeText
    {
        public static void Run()
        {
            // ExStart:UpdateShapeText
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_ShapeText();

            // Call the diagram constructor to load diagram from a VDX file
            Diagram diagram = new Diagram(dataDir + "UpdateShapeText.vsd");
            // get page by name
            Page page = diagram.Pages.GetPage("Flow 1");
            // Find a particular shape and update its text
            foreach (Aspose.Diagram.Shape shape in page.Shapes)
            {
                if (shape.NameU.ToLower() == "process" && shape.ID == 1)
                {
                    shape.Text.Value.Clear();
                    shape.Text.Value.Add(new Txt("New Text"));
                }
            }
            // save diagram
            diagram.Save(dataDir + "UpdateShapeText_Out.vdx", SaveFileFormat.VDX);
            // ExEnd:UpdateShapeText
        }
    }
}