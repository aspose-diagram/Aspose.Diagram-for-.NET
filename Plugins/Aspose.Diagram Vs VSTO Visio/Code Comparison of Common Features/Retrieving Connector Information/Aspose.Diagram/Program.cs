using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.Diagram
{
    class Program
    {
        static void Main(string[] args)
        {
            //Call the diagram constructor to load diagram from a VDX file
            Diagram vdxDiagram = new Diagram(@"E:\Aspose\Aspose Vs VSTO\Aspose.Diagram Vs VSTO Visio v1.1\Sample Files\Drawing1.vdx");

            foreach (Aspose.Diagram.Connect connector in vdxDiagram.Pages[1].Connects)
            {
                //Display information about the Connectors
                Console.WriteLine("\nFrom Shape ID : " + connector.FromSheet);
                Console.WriteLine("To Shape ID : " + connector.ToSheet);
            }

            Console.ReadLine();
        }
    }
}
