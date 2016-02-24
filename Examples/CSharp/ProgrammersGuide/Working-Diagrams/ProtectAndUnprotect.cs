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
    public class ProtectAndUnprotect
    {
        public static void Run()
        {
            //ExStart:ProtectAndUnprotect
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Diagrams();

            //Load diagram
            Diagram diagram = new Diagram(dataDir + "ProtectAndUnprotect.vsd");

            diagram.DocumentSettings.ProtectBkgnds = BOOL.True;
            diagram.DocumentSettings.ProtectMasters = BOOL.True;
            diagram.DocumentSettings.ProtectShapes = BOOL.True;
            diagram.DocumentSettings.ProtectStyles = BOOL.True;

            diagram.Save(dataDir + "output.vdx", SaveFileFormat.VDX);
            //ExEnd:ProtectAndUnprotect
        }
    }
}