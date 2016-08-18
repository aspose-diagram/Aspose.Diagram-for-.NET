using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace Aspose.Diagram.Examples.CSharp.Introduction
{
    public class DetectVisioFileFormat
    {
        public static void Run() 
        {
            // ExStart:DetectVisioFileFormat
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Intro();

            // Load an existing Visio file in the stream
            FileStream st = new FileStream(dataDir + "Drawing1.vsdx", FileMode.Open);

            // Detect file format using the direct file path
            FileFormatInfo info = FileFormatUtil.DetectFileFormat(dataDir + "Drawing1.vsdx");

            // Detect file format using the direct file path
            FileFormatInfo infoFromStream = FileFormatUtil.DetectFileFormat(st);

            // Get the detected file format
            Console.WriteLine("The spreadsheet format is: " + info.FileFormatType);
            
            // Get the detected file format from the file stream
            Console.WriteLine("The spreadsheet format is (from the file stream): " + info.FileFormatType);
            // ExEnd:DetectVisioFileFormat
        }
    }
}
