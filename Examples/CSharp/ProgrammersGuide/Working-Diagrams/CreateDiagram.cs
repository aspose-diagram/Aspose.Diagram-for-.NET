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
    public class CreateDiagram
    {
        public static void Run()
        {
            //ExStart:CreateDiagram
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Diagrams();

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            Diagram diagram = new Diagram();
            diagram.Save(dataDir + "Diagram1.vdx", SaveFileFormat.VDX);
            //ExEnd:CreateDiagram
        }
    }
}