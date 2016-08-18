using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Print
{
    public class BySpecificPrinter
    {
        public static void Run()
        {
            // ExStart:BySpecificPrinter
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Print();

            // Load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // Call the print method to print whole Diagram using the printer name
            diagram.Print("LaserJet1100");
            // ExEnd:BySpecificPrinter
        }
    }
}
