using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_with_Print
{
    public class ByDefaultPrinter
    {
        public static void Run() 
        {
            //ExStart:ByDefaultPrinter
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Print();

            // load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // call the print method to print whole Diagram using the default printer
            diagram.Print();
            //ExEnd:ByDefaultPrinter
        }
    }
}
