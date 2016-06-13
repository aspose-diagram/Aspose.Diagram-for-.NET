using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_with_Print
{
    public class PrintDiagramVisXPSPrinterAPI
    {
        public static void Run() 
        {
            // ExStart:PrintDiagramVisXPSPrinterAPI
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Print();

            // load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            
            // Specify the name of the printer you want to print to.
            const string printerName = @"\\COMPANY\Brother MFC-885CW Printer";

            // Print the document.
            XpsPrintHelper.Print(diagram, printerName, "My Test Job", true);
            // ExEnd:PrintDiagramVisXPSPrinterAPI
        }
    }
}
