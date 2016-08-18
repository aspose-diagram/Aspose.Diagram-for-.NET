using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Load_Save_Convert
{
    public class ExportToXAML
    {
        public static void Run()
        {
            // ExStart:ExportToXAML
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();
            // Load diagram
            Diagram diagram = new Diagram(dataDir + "ExportToXAML.vsd");
            // Save diagram
            diagram.Save(dataDir + "Output.xaml", SaveFileFormat.XAML);
            // ExEnd:ExportToXAML
        }
    }
}
