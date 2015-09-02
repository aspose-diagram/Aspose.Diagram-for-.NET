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
            // Load diagram
            Diagram diagram = new Diagram(@"E:\Aspose\Aspose Vs VSTO\Aspose.Diagram Vs VSTO Visio v1.1\Sample Files\Drawing1.vsd");

            // Add comment
            diagram.Pages[0].AddComment(7.205905511811023, 3.880708661417323, "test@");

            // Save diagram
            diagram.Save(@"E:\Aspose\Aspose Vs VSTO\Aspose.Diagram Vs VSTO Visio v1.1\Sample Files\Output.vdx", SaveFileFormat.VDX);
        }
    }
}
