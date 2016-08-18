using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Text
{
    public class GetPlainTextOfVisio
    {
        // ExStart:GetPlainTextOfVisio
        static string text = "";
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_ShapeText();
            // Load diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // Get Visio diagram page
            Aspose.Diagram.Page page = diagram.Pages.GetPage("Page-1");

            // Iterate through the shapes
            foreach (Aspose.Diagram.Shape shape in page.Shapes)
            {
                // Extract plain text from the shape
                GetShapeText(shape);
            }
            // Display extracted text
            Console.WriteLine(text);
        }
        private static void GetShapeText(Aspose.Diagram.Shape shape)
        {
            // Filter shape text
            if (shape.Text.Value.Text != "")
                text += Regex.Replace(shape.Text.Value.Text, "\\<.*?>", "");

            // For image shapes
            if (shape.Type == TypeValue.Foreign)
                text += (shape.Name);

            // For group shapes
            if (shape.Type == TypeValue.Group)
                foreach (Aspose.Diagram.Shape subshape in shape.Shapes)
                {
                    GetShapeText(subshape);
                }
        }
        // ExEnd:GetPlainTextOfVisio
    }
}
