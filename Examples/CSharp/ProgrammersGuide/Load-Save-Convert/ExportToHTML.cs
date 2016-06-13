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
    public class ExportToHTML
    {
        public static void Run()
        {
            // ExStart:ExportToHTML
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();
            // load diagram
            Diagram diagram = new Diagram(dataDir + "ExportToHTML.vsd");
            // save diagram
            diagram.Save(dataDir + "outputVSDtoHTML.html", SaveFileFormat.HTML);
            // ExEnd:ExportToHTML
        }
    }
}