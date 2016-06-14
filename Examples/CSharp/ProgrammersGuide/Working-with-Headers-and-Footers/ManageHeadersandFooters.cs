using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.ProgrammersGuide.Working_with_Headers_and_Footers
{
    public class ManageHeadersandFooters
    {
        public static void Run() 
        {
            // ExStart:ManageHeadersandFooters
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_HeadersAndFooters();

            // load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // add page number at the right corner of header
            diagram.HeaderFooter.HeaderRight = "&p";

            // set text at the center
            diagram.HeaderFooter.HeaderCenter = "Center of the header";

            // set text at the left side
            diagram.HeaderFooter.HeaderLeft = "Left of the header";

            // add text at the right corner of footer
            diagram.HeaderFooter.FooterRight = "Right of the footer";

            // set text at the center
            diagram.HeaderFooter.FooterCenter = "Center of the footer";

            // set text at the left side
            diagram.HeaderFooter.FooterLeft = "Left of the footer";

            // set header & footer color
            diagram.HeaderFooter.HeaderFooterColor = Color.AliceBlue;

            // set text font properties
            diagram.HeaderFooter.HeaderFooterFont.Italic = BOOL.True;
            diagram.HeaderFooter.HeaderFooterFont.Underline = BOOL.False;

            // save Visio diagram
            diagram.Save(dataDir + "ManageHeadersandFooters_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:ManageHeadersandFooters
        }
    }
}
