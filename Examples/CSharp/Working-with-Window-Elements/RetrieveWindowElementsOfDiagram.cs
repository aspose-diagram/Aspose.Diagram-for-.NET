using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Window_Elements
{
    public class RetrieveWindowElementsOfDiagram
    {
        public static void Run() 
        {
            // ExStart:RetrieveWindowElementsOfDiagram
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WindowElements();

            // load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // iterate through the window elements
            foreach (Window window in diagram.Windows)
            {
                Console.WriteLine("ID: " + window.ID);
                Console.WriteLine("Type: " + window.WindowType);
                Console.WriteLine("Window height: " + window.WindowHeight);
                Console.WriteLine("Window width: " + window.WindowWidth);
                Console.WriteLine("Window state: " + window.WindowState);
            }
            // ExEnd:RetrieveWindowElementsOfDiagram
        }
    }
}
