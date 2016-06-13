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
    public class ExportToSVG
    {
        public static void Run()
        {
            // ExStart:ExportToSVG
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();

            // Call the diagram constructor to load a VSD diagram
            Diagram diagram = new Diagram(dataDir + "ExportToSVG.vsd");

            // Save SVG Output file
            diagram.Save(dataDir + "Output.svg", SaveFileFormat.SVG);
            // ExEnd:ExportToSVG
        }
    }
}