using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Window_Elements
{
    public class AddWindowElementInVisio
    {
        public static void Run() 
        {
            // ExStart:AddWindowElementInVisio
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WindowElements();

            // Load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // Initialize window object
            Window window = new Window();
            // Set window state
            window.WindowState = WindowStateValue.Maximized;
            // Set window height
            window.WindowHeight = 500;
            // Set window width
            window.WindowWidth = 500;
            // Set window type
            window.WindowType = WindowTypeValue.Stencil;
            // Add window object
            diagram.Windows.Add(window);

            // Save in any supported format
            diagram.Save(dataDir + "AddWindowElementInVisio_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:AddWindowElementInVisio
        }
    }
}
