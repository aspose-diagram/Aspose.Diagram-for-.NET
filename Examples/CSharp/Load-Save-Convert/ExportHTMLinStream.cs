using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Load_Save_Convert
{
    public class ExportHTMLinStream
    {
        public static void Run()
        {
            // ExStart:ExportHTMLinStream
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();
            // Load diagram
            Diagram diagram = new Diagram(dataDir + "ExportToHTML.vsd");
            // Save resultant HTML directly to a stream
            MemoryStream stream = new MemoryStream();
            diagram.Save(stream, SaveFileFormat.HTML);
            // ExEnd:ExportHTMLinStream
        }
    }
}
