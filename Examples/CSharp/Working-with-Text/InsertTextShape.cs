using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Text
{
    public class InsertTextShape
    {
        public static void Run()
        {
            // ExStart:InsertTextShape
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_ShapeText();

            // Create a new diagram
            Diagram diagram = new Diagram();
            // Set parameters and add text to a Visio page
            double PinX = 1, PinY = 1, Width = 1, Height = 1;                  
            diagram.Pages[0].AddText(PinX, PinY, Width, Height, "Test text");
            // Save diagram 
            diagram.Save(dataDir + "InsertTextShape_out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:InsertTextShape
        }
    }
}
