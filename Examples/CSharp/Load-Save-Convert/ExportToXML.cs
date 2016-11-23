using System.IO;
using Aspose.Diagram;
namespace Aspose.Diagram.Examples.CSharp.Diagrams
{
    public class ExportToXML
    {
        public static void Run()
        {
            // ExStart:ExportToXML
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();
            
            /* 1. Exporting VSDX to VDX */
            // Call the diagram constructor to load diagram from a VSD file
            Diagram diagram = new Diagram(dataDir + "ExportToXML.vsd");

            // Save input VSD as VDX
            diagram.Save(dataDir + "ExportToXML_out.vdx", SaveFileFormat.VDX);

            /* 2. Exporting from VSD to VSX */
            // Call the diagram constructor to load diagram from a VSD file
            
            // Save input VSD as VSX
            diagram.Save(dataDir + "ExportToXML_out.vsx", SaveFileFormat.VSX);
            
            /* 3. Export VSD to VTX */
            // Save input VSD as VTX
            diagram.Save(dataDir + "ExportToXML_out.vtx", SaveFileFormat.VTX);
            // ExEnd:ExportToXML
        }
    }
}