
using System.IO;
using System;
using Aspose.Diagram;
using Aspose.Diagram.Vba;

namespace Aspose.Diagram.Examples.CSharp.Diagrams
{
    public class ModifyVBAModule
    {
        public static void Run()
        {
            // ExStart:ModifyVBAModule
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Diagrams();

            // Load an existing Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdm", LoadFileFormat.VSDM);
            // Extract VBA project
            Aspose.Diagram.Vba.VbaProject v = diagram.VbaProject;
            // Iterate through the modules and modify VBA module code
            foreach (VbaModule module in diagram.VbaProject.Modules)
            {
                string code = module.Codes;
                if (code.Contains("This is test message."))
                    code = code.Replace("This is test message.", "This is Aspose.Diagram message.");
                module.Codes = code;
            }
            // Save the Visio diagram
            diagram.Save(dataDir + "ModifyVBAModule_out.vssm", SaveFileFormat.VSSM);
            // ExEnd:ModifyVBAModule           
        }
    }
}