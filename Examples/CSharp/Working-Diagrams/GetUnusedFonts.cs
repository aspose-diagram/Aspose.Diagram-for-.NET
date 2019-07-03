using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_Diagrams
{
    public class GetUnusedFonts
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Diagrams();

            // Call the diagram constructor to load diagram from a VSD file
            Diagram vdxDiagram = new Diagram(dataDir + "Sample_UnusedFonts.vsdx");

            // Get Unused Fonts 
            StyleSheetCollection unused = vdxDiagram.GetUnusedStyles();

            // Display unused fonts count 
            Console.WriteLine(unused.Count);
            // ExEnd:1
        }
    }
}
