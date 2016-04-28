using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide
{
    public class SpecifyFontLocation
    {
        public static void Run()
        {
            //ExStart:SpecifyFontLocation
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Intro();

            String[] fontDirs = new String[] { "C:\\MyFonts\\", "D:\\Misc\\Fonts\\" };
            //Load the Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            //setting the custom font directories
            diagram.FontDirs = fontDirs;

            //saving Visio diagram in PDF format
            diagram.Save(dataDir + "SetFontsFolders_Out.pdf", SaveFileFormat.PDF);
            //ExEnd:SpecifyFontLocation
        }
    }
}
