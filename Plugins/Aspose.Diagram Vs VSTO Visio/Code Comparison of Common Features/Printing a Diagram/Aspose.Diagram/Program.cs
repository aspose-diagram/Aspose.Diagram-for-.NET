using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.Diagram
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"E:\Aspose\Aspose Vs VSTO\Aspose.Diagram Vs VSTO Visio v1.1\Sample Files\demo.vsd";
            //Load the diagram
            Diagram diagram = new Diagram(FilePath);

            //Call the print method to print whole Diagram to the default printer
            diagram.Print();

            //Call the print method to print whole Diagram to the desired printer
            diagram.Print("LaserJet1100");

            PrinterSettings settings = new PrinterSettings();
            settings.PrinterName = "LaserJet1100";
            //Call the print method to print whole Diagram to the desired printer and set document name in print job
            diagram.Print(settings, "Job name while printing with Aspose.Diagram");
        }
    }
}
