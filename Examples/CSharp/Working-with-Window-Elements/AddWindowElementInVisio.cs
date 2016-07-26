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

            // load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // initialize window object
            Window window = new Window();
            // set window state
            window.WindowState = WindowStateValue.Maximized;
            // set window height
            window.WindowHeight = 500;
            // set window width
            window.WindowWidth = 500;
            // set window type
            window.WindowType = WindowTypeValue.Stencil;
            // add window object
            diagram.Windows.Add(window);

            // save in any supported format
            diagram.Save(dataDir + "AddWindowElementInVisio_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:AddWindowElementInVisio
        }
    }
}
