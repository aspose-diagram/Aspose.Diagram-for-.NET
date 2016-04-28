using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Load_Save_Convert
{
    public class CreateNewVisio
    {
        public static void Run()
        {
            //ExStart:CreateNewVisio
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();

            // initialize a Diagram class
            Diagram diagram = new Diagram();

            // save diagram in the VSDX format
            diagram.Save(dataDir + "CreateNewVisio_Out.vsdx", SaveFileFormat.VSDX);
            //ExEnd:CreateNewVisio
        }
    }
}
