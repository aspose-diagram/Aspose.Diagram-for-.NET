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

            //Display Visio version and document modification time at different stages
            Console.WriteLine("Visio Instance Version : " + vdxDiagram.Version);
            Console.WriteLine("Full Build Number Created : " + vdxDiagram.DocumentProps.BuildNumberCreated);
            Console.WriteLine("Full Build Number Edited : " + vdxDiagram.DocumentProps.BuildNumberEdited);
            Console.WriteLine("Date Created : " + vdxDiagram.DocumentProps.TimeCreated);
            Console.WriteLine("Date Last Edited : " + vdxDiagram.DocumentProps.TimeEdited);
            Console.WriteLine("Date Last Printed : " + vdxDiagram.DocumentProps.TimePrinted);
            Console.WriteLine("Date Last Saved : " + vdxDiagram.DocumentProps.TimeSaved);

            Console.ReadLine();
        }
    }
}
