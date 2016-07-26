using System.IO;
using Aspose.Diagram;
using Aspose.Diagram.Saving;
namespace Aspose.Diagram.Examples.CSharp.Diagrams
{
    public class ExportToSWFWithoutViewer
    {
        public static void Run()
        {
            try
            {
                // ExStart:ExportToSWFWithoutViewer
                // The path to the documents directory.
                string dataDir = RunExamples.GetDataDir_Diagrams();

                // Instantiate Diagram Object and open VSD file
                Diagram diagram = new Diagram(dataDir + "ExportToSWFWithoutViewer.vsd");

                // Instantiate the Save Options
                SWFSaveOptions options = new SWFSaveOptions();

                // Set Save format as SWF
                options.SaveFormat = SaveFileFormat.SWF;

                // Exclude the embedded viewer
                options.ViewerIncluded = false;

                // Save the resultant SWF file
                diagram.Save(dataDir + "ExportToSWFWithoutViewer_Out.swf", SaveFileFormat.SWF);
                // ExEnd:ExportToSWFWithoutViewer
            }            
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message + "\nThis example will only work if you apply a valid Aspose License. You can purchase full license or get 30 day temporary license from http:// Www.aspose.com/purchase/default.aspx.");
            }            
        }
    }
}