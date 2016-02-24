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
    public class ReadDiagramFile
    {
        public static void Run()
        {
            //ExStart:ReadDiagramFile
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Diagrams();

            //Call the diagram constructor to load diagram from a VSD stream
            FileStream st = new FileStream(dataDir + "ReadDiagramFile.vsd", FileMode.Open);

            Diagram vsdDiagram = new Diagram(st);

            System.Console.WriteLine("Total Pages:" + vsdDiagram.Pages.Count);

            st.Close();
            //ExEnd:ReadDiagramFile
        }
    }
}