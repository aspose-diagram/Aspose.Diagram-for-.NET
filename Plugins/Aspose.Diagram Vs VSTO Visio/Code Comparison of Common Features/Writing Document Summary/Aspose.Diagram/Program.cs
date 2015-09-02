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

            //Set some summary information about the diagram
            vdxDiagram.DocumentProps.Creator = "Ijaz";
            vdxDiagram.DocumentProps.Company = "Aspose";
            vdxDiagram.DocumentProps.Category = "Drawing 2D";
            vdxDiagram.DocumentProps.Manager = "Sergey Polshkov";
            vdxDiagram.DocumentProps.Title = "Aspose Title";
            vdxDiagram.DocumentProps.TimeCreated = DateTime.Now;
            vdxDiagram.DocumentProps.Subject = "Visio Diagram";
            vdxDiagram.DocumentProps.Template = "Aspose Template";

            //Write the updated file to the disk in VDX file format
            vdxDiagram.Save(@"E:\Aspose\Aspose Vs VSTO\Aspose.Diagram Vs VSTO Visio v1.1\Sample Files\output.vdx", SaveFileFormat.VDX);
        }
    }
}
