using System.IO;
using Aspose.Diagram;
namespace Aspose.Diagram.Examples.CSharp.Diagrams
{
    public class VisioDiagramProtection
    {
        public static void Run()
        {
            // ExStart:VisioDiagramProtection
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Protection();

            // Load diagram
            Diagram diagram = new Diagram(dataDir + "ProtectAndUnprotect.vsd");

            diagram.DocumentSettings.ProtectBkgnds = BOOL.True;
            diagram.DocumentSettings.ProtectMasters = BOOL.True;
            diagram.DocumentSettings.ProtectShapes = BOOL.True;
            diagram.DocumentSettings.ProtectStyles = BOOL.True;
            // save diagram
            diagram.Save(dataDir + "VisioDiagramProtection_Out.vdx", SaveFileFormat.VDX);
            // ExEnd:VisioDiagramProtection
        }
    }
}