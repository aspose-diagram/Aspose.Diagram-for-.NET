
using System.IO;
using System;
using Aspose.Diagram;

namespace Aspose.Diagram.Examples.CSharp.Diagrams
{
    public class CreateDiagram
    {
        public static void Run()
        {
            // ExStart:CreateDiagram
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Diagrams();

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);
            // initialize a new Visio
            Diagram diagram = new Diagram();
            dataDir = dataDir + "CreateDiagram_Out.vsdx";
            // save in the VSDX format
            diagram.Save(dataDir, SaveFileFormat.VSDX);
            // ExEnd:CreateDiagram
            Console.WriteLine("\nDiagram created successfully.\nFile saved at " + dataDir);
        }
    }
}