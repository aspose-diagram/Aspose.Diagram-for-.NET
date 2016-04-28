using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_Diagrams
{
    public class RemoveMacrosFromVisio
    {
        public static void Run()
        {
            //ExStart:RemoveMacrosFromVisio
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Diagrams();

            // load a Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // remove all macros
            diagram.VbProjectData = null;

            // Save diagram
            diagram.Save(dataDir + "RemoveMacrosFromVisio_Out.vsdx", SaveFileFormat.VSDX);
            //ExEnd:RemoveMacrosFromVisio
        }
    }
}
