//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Diagram. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Diagram;
using Aspose.Diagram.Saving;

namespace ExportDiagramToSWFWithoutViewer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //instantiate Diagram Object and open VSD file
            Diagram diagram = new Diagram(dataDir + "drawing.vsd");

            //Instantiate the Save Options
            SWFSaveOptions options = new SWFSaveOptions();

            //Set Save format as SWF
            options.SaveFormat = SaveFileFormat.SWF;

            // Exclude the embedded viewer
            options.ViewerIncluded = false;

            //Save the resultant SWF file
            diagram.Save(dataDir + "Output.swf", SaveFileFormat.SWF);

        }
    }
}