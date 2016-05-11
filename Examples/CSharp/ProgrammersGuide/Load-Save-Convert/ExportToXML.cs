//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Diagram. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Diagram;

namespace CSharp.Diagrams
{
    public class ExportToXML
    {
        public static void Run()
        {
            //ExStart:ExportToXML
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();
            
            /* 1. Exporting VSDX to VDX */
            //Call the diagram constructor to load diagram from a VSD file
            Diagram diagram = new Diagram(dataDir + "ExportToXML.vsd");

            //Save input VSD as VDX
            diagram.Save(dataDir + "ExportToXML_Out.vdx", SaveFileFormat.VDX);

            /* 2. Exporting from VSD to VSX */
            // Call the diagram constructor to load diagram from a VSD file
            
            //Save input VSD as VSX
            diagram.Save(dataDir + "ExportToXML_Out.vsx", SaveFileFormat.VSX);
            
            /* 3. Export VSD to VTX */
            //Save input VSD as VTX
            diagram.Save(dataDir + "ExportToXML_Out.vtx", SaveFileFormat.VTX);
            //ExEnd:ExportToXML
        }
    }
}