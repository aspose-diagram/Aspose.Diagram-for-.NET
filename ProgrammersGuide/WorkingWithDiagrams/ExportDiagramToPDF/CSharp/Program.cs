//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Diagram. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Diagram;

namespace ExportDiagramToPDF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Call the diagram constructor to load diagram from a VSD file
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsd");

            MemoryStream pdfStream = new MemoryStream();
            diagram.Save(pdfStream, SaveFileFormat.PDF);

            FileStream pdfFileStream = new FileStream(dataDir + "Drawing1.pdf", FileMode.Create, FileAccess.Write);
            pdfStream.WriteTo(pdfFileStream);
            pdfFileStream.Close();

            pdfStream.Close();

            // Display Status.
            System.Console.WriteLine("Conversion from vsd to pdf performed successfully.");
        }
    }
}