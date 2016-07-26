using System.IO;
using Aspose.Diagram;
using System;

namespace Aspose.Diagram.Examples.CSharp.Shapes
{
    public class RetrieveShapeInfo
    {
        public static void Run()
        {
            // ExStart:RetrieveShapeInfo
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // Load diagram
            Diagram vsdDiagram = new Diagram(dataDir + "RetrieveShapeInfo.vsd");

            foreach (Aspose.Diagram.Shape shape in vsdDiagram.Pages[0].Shapes)
            {
                // Display information about the shapes
                Console.WriteLine("\nShape ID : " + shape.ID);
                Console.WriteLine("Name : " + shape.Name);
                Console.WriteLine("Master Shape : " + shape.Master.Name);
            }
            // ExEnd:RetrieveShapeInfo
        }
    }
}