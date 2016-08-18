using System.IO;
using Aspose.Diagram;
namespace Aspose.Diagram.Examples.CSharp.Diagrams
{
    public class ExportToSWF
    {
        public static void Run()
        {

            try
            {
                // ExStart:ExportToSWF
                // The path to the documents directory.
                string dataDir = RunExamples.GetDataDir_Diagrams();
                // Load diagram
                Diagram diagram = new Diagram(dataDir + "ActvDir.vsd");
                // Save diagram
                diagram.Save(dataDir + "Output_Out.swf", SaveFileFormat.SWF);
                // ExEnd:ExportToSWF
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message + "\nThis example will only work if you apply a valid Aspose License. You can purchase full license or get 30 day temporary license from http:// Www.aspose.com/purchase/default.aspx.");
            }
        }
    }
}