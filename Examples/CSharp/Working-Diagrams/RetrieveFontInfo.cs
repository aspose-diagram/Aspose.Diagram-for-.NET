using System.IO;
using Aspose.Diagram;
using System;

namespace Aspose.Diagram.Examples.CSharp.Diagrams
{
    public class RetrieveFontInfo
    {
        public static void Run()
        {
            // ExStart:RetrieveFontInfo
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Diagrams();

            // Call the diagram constructor to load diagram from a VSD file
            Diagram vdxDiagram = new Diagram(dataDir + "RetrieveFontInfo.vsd");

            foreach (Aspose.Diagram.Font font in vdxDiagram.Fonts)
            {
                // Display information about the fonts
                Console.WriteLine(font.Name);
            }
            // ExEnd:RetrieveFontInfo
        }
    }
}