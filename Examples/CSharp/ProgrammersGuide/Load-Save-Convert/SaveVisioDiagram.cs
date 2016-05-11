using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Load_Save_Convert
{
    public class SaveVisioDiagram
    {
        public static void Run() 
        {
            //ExStart:SaveVisioDiagram
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();
            // load an existing Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // save diagram using the direct path
            diagram.Save(dataDir + "SaveVisioDiagram_Out.vsdx", SaveFileFormat.VSDX);

            MemoryStream stream = new MemoryStream();
            // save diagram in the stream
            diagram.Save(stream, SaveFileFormat.VSDX);
            //ExEnd:SaveVisioDiagram
        }
    }
}
