//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Diagram. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Diagram;
using Aspose.Diagram.Saving;

namespace CSharp.Diagrams
{
    public class ExportToSWFWithoutViewer
    {
        public static void Run()
        {
            //ExStart:ExportToSWFWithoutViewer
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Diagrams();

            //instantiate Diagram Object and open VSD file
            Diagram diagram = new Diagram(dataDir + "ExportToSWFWithoutViewer.vsd");

            //Instantiate the Save Options
            SWFSaveOptions options = new SWFSaveOptions();

            //Set Save format as SWF
            options.SaveFormat = SaveFileFormat.SWF;

            // Exclude the embedded viewer
            options.ViewerIncluded = false;

            //Save the resultant SWF file
            diagram.Save(dataDir + "Output.swf", SaveFileFormat.SWF);
            //ExEnd:ExportToSWFWithoutViewer
        }
    }
}