using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Print
{
    public class SetPrintJobAndPrinterName
    {
        public static void Run() 
        {
            // ExStart:SetPrintJobAndPrinterName
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Print();

            // load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // call the print method to print whole Diagram using the printer name and set document name in the print job
            diagram.Print("LaserJet1100", "Job name while printing with Aspose.Diagram");
            // ExEnd:SetPrintJobAndPrinterName
        }
    }
}
