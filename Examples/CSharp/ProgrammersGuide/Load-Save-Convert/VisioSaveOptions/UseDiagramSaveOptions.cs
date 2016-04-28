using Aspose.Diagram;
using Aspose.Diagram.Saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Load_Save_Convert.VisioSaveOptions
{
    public class UseDiagramSaveOptions
    {
        public static void Run()
        {
            //ExStart:UseDiagramSaveOptions
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();

            // call the diagram constructor to a VSDX diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // Options when saving a diagram into Visio format
            DiagramSaveOptions options = new DiagramSaveOptions(SaveFileFormat.VSDX);

            // Summary:
            //     When characters in the diagram are unicode and not be set with correct font
            //     value or the font is not installed locally, they may appear as block,
            //     image or XPS.  Set the DefaultFont such as MingLiu or MS Gothic to show these
            //     characters.
            options.DefaultFont = "MS Gothic";

            // Summary:
            //     Defines whether need enlarge page to fit drawing content or not.
            // Remarks:
            //     Default value is false.
            options.AutoFitPageToDrawingContent = true;

            diagram.Save(dataDir + "UseDiagramSaveOptions_Out.vsdx", options);
            //ExEnd:UseDiagramSaveOptions
        }
    }
}
