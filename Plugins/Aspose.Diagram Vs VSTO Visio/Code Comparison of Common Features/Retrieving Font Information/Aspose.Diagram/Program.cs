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

            foreach (Aspose.Diagram.Font font in vdxDiagram.Fonts)
            {
                //Display information about the fonts
                Console.WriteLine(font.Name);
            }
        }
    }
}
