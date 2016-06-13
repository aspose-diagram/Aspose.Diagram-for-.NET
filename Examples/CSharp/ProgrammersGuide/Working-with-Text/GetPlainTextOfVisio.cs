using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharp.ProgrammersGuide.Working_with_Text
{
    public class GetPlainTextOfVisio
    {
        // ExStart:GetPlainTextOfVisio
        static string text = "";
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_ShapeText();
            // load diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // get Visio diagram page
            Aspose.Diagram.Page page = diagram.Pages.GetPage("Page-1");

            // iterate through the shapes
            foreach (Aspose.Diagram.Shape shape in page.Shapes)
            {
                // extract plain text from the shape
                GetShapeText(shape);
            }
            // display extracted text
            Console.WriteLine(text);
        }
        private static void GetShapeText(Aspose.Diagram.Shape shape)
        {
            // filter shape text
            if (shape.Text.Value.Text != "")
                text += Regex.Replace(shape.Text.Value.Text, "\\<.*?>", "");

            // for image shapes
            if (shape.Type == TypeValue.Foreign)
                text += (shape.Name);

            // for group shapes
            if (shape.Type == TypeValue.Group)
                foreach (Aspose.Diagram.Shape subshape in shape.Shapes)
                {
                    GetShapeText(subshape);
                }
        }
        // ExEnd:GetPlainTextOfVisio
    }
}
