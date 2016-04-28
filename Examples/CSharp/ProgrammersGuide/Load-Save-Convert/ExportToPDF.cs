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
    public class ExportToPDF
    {
        public static void Run()
        {
            //ExStart:ExportToPDF
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();

            //Call the diagram constructor to load a VSD diagram
            Diagram diagram = new Diagram(dataDir + "ExportToPDF.vsd");

            MemoryStream pdfStream = new MemoryStream();
            // save diagram
            diagram.Save(pdfStream, SaveFileFormat.PDF);

            // create a PDF file
            FileStream pdfFileStream = new FileStream(dataDir + "ExportToPDF_Out.pdf", FileMode.Create, FileAccess.Write);
            pdfStream.WriteTo(pdfFileStream);
            pdfFileStream.Close();

            pdfStream.Close();

            // Display Status.
            System.Console.WriteLine("Conversion from vsd to pdf performed successfully.");
            //ExEnd:ExportToPDF
        }
    }
}