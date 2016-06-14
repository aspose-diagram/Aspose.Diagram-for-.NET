using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.ProgrammersGuide.Working_with_Text
{
    public class ApplyFontOnText
    {
        public static void Run()
        {
            // ExStart:ApplyFontOnText
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_ShapeText();

            // load diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // get page by name
            Page page = diagram.Pages.GetPage("Page-1");
            // get shape by ID
            Shape shape = page.Shapes.GetShape(1);
            // clear shape text values and chars
            shape.Text.Value.Clear();
            shape.Chars.Clear();

            // mark character run and add text
            shape.Text.Value.Add(new Cp(0));
            shape.Text.Value.Add(new Txt("TextStyle_Regular\n"));
            shape.Text.Value.Add(new Cp(1));
            shape.Text.Value.Add(new Txt("TextStyle_Bold_Italic\n"));
            shape.Text.Value.Add(new Cp(2));
            shape.Text.Value.Add(new Txt("TextStyle_Underline_Italic\n"));
            shape.Text.Value.Add(new Cp(3));
            shape.Text.Value.Add(new Txt("TextStyle_Bold_Italic_Underline"));

            // add formatting characters
            shape.Chars.Add(new Aspose.Diagram.Char());
            shape.Chars.Add(new Aspose.Diagram.Char());
            shape.Chars.Add(new Aspose.Diagram.Char());
            shape.Chars.Add(new Aspose.Diagram.Char());

            // Set properties e.g. color, font, size and style etc.
            shape.Chars[0].IX = 0;
            shape.Chars[0].Color.Value = "#FF0000";
            shape.Chars[0].Font.Value = 4;
            shape.Chars[0].Size.Value = 0.22;
            shape.Chars[0].Style.Value = StyleValue.Undefined;

            // Set properties e.g. color, font, size and style etc.
            shape.Chars[1].IX = 1;
            shape.Chars[1].Color.Value = "#FF00FF";
            shape.Chars[1].Font.Value = 4;
            shape.Chars[1].Size.Value = 0.22;
            shape.Chars[1].Style.Value = StyleValue.Bold | StyleValue.Italic;

            // Set properties e.g. color, font, size and style etc.
            shape.Chars[2].IX = 2;
            shape.Chars[2].Color.Value = "#00FF00";
            shape.Chars[2].Font.Value = 4;
            shape.Chars[2].Size.Value = 0.22;
            shape.Chars[2].Style.Value = StyleValue.Underline | StyleValue.Italic;

            // Set properties e.g. color, font, size and style etc.
            shape.Chars[3].IX = 3;
            shape.Chars[3].Color.Value = "#3333FF";
            shape.Chars[3].Font.Value = 4;
            shape.Chars[3].Size.Value = 0.22;
            shape.Chars[3].Style.Value = StyleValue.Bold | StyleValue.Italic | StyleValue.Underline;
            // save diagram
            diagram.Save(dataDir + "ApplyFontOnText_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:ApplyFontOnText
        }
    }
}
