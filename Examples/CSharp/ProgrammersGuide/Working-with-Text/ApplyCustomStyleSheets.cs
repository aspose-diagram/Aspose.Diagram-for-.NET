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
    public class ApplyCustomStyleSheets
    {
        public static void Run()
        {
            //ExStart:ApplyCustomStyleSheets
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_ShapeText();

            //Load diagram
            Diagram vsdDiagram = new Diagram(dataDir + "ApplyCustomStyleSheets.vsd");
            // get page by name
            Page page = vsdDiagram.Pages.GetPage("Flow 1");

            Shape sourceShape = null;
            // find the shape to apply the style
            foreach (Aspose.Diagram.Shape shape in page.Shapes)
            {
                if (shape.Name == "Process")
                {
                    sourceShape = shape;
                    break;
                }
            }

            StyleSheet customStyleSheet = null;

            //Find the required style sheet
            foreach (StyleSheet styleSheet in vsdDiagram.StyleSheets)
            {
                if (styleSheet.Name == "Basic")
                {
                    customStyleSheet = styleSheet;
                    break;
                }
            }

            if (sourceShape != null && customStyleSheet != null)
            {
                //Apply text style
                sourceShape.TextStyle = customStyleSheet;
                //Apply fill style
                sourceShape.FillStyle = customStyleSheet;
                //Apply line style
                sourceShape.LineStyle = customStyleSheet;
            }

            //Save changed diagram as VDX
            vsdDiagram.Save(dataDir + "ApplyCustomStyleSheets_Out.vdx", SaveFileFormat.VDX);
            //ExEnd:ApplyCustomStyleSheets
 
        }
    }
}