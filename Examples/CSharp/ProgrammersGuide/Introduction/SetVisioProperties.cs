using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.ProgrammersGuide.Introduction
{
    public class SetVisioProperties
    {
        public static void Run()
        {
            // ExStart:SetVisioProperties
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Intro();

            // build path of an existing diagram
            string visioDrawing = dataDir + "Drawing1.vsdx";

            // Call the diagram constructor to load diagram from a VSDX file
            Diagram diagram = new Diagram(visioDrawing);

            // Set some summary information about the diagram
            diagram.DocumentProps.Creator = "Ijaz";
            diagram.DocumentProps.Company = "Aspose";
            diagram.DocumentProps.Category = "Drawing 2D";
            diagram.DocumentProps.Manager = "Sergey Polshkov";
            diagram.DocumentProps.Title = "Aspose Title";
            diagram.DocumentProps.TimeCreated = DateTime.Now;
            diagram.DocumentProps.Subject = "Visio Diagram";
            diagram.DocumentProps.Template = "Aspose Template";

            // Write the updated file to the disk in VSDX file format
            diagram.Save(dataDir + "SetVisioProperties_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:SetVisioProperties
        }
    }
}
