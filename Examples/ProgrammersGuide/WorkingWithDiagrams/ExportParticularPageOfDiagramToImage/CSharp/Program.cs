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

namespace ExportParticularPageOfDiagramToImage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            Diagram diagram = new Diagram(dataDir + "Drawing1.vsd");

            //Save diagram as PNG
            ImageSaveOptions options = new ImageSaveOptions(SaveFileFormat.PNG);

            // Save one page only, by page index
            options.PageIndex = 0;

            //Save resultant Image file
            diagram.Save(dataDir + "output.png", options);

        }
    }
}