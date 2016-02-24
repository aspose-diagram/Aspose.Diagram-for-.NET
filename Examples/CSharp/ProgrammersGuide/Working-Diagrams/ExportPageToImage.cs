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
    public class ExportPageToImage
    {
        public static void Run()
        {
            //ExStart:ExportPageToImage
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Diagrams();

            Diagram diagram = new Diagram(dataDir + "ExportPageToImage.vsd");

            //Save diagram as PNG
            ImageSaveOptions options = new ImageSaveOptions(SaveFileFormat.PNG);

            // Save one page only, by page index
            options.PageIndex = 0;

            //Save resultant Image file
            diagram.Save(dataDir + "output.png", options);
            //ExEnd:ExportPageToImage
        }
    }
}