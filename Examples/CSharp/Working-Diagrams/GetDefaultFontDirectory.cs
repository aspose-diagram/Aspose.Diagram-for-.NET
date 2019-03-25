using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_Diagrams
{
    public class GetDefaultFontDirectory
    {
        public static void Run()
        {
            // ExStart:GetDefaultFontDirectory
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Diagrams();

            // Call the diagram constructor to load diagram from a VSD file
            Diagram vdxDiagram = new Diagram(dataDir + "RetrieveFontInfo.vsd");
           
            // Display font default directory
            Console.WriteLine(vdxDiagram.GetDefaultFontDir());
            // ExEnd:GetDefaultFontDirectory
        }
    }
}
