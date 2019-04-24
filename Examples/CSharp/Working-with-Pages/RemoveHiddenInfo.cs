using Aspose.Diagram.Saving;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Pages
{
    public class RemoveHiddenInfo
    {
        public static void Run()
        {

            // ExStart:RemoveHiddenInfo
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Intro();
            // Load an existing Visio
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // Remove hidden information from diagram
            diagram.RemoveHiddenInformation((int)(RemoveHiddenInfoItem.Shapes | RemoveHiddenInfoItem.Masters));
            // Initialize PDF save options
            HTMLSaveOptions options = new HTMLSaveOptions();
            // Set export option of hidden Visio pages
            options.ExportHiddenPage = false;
            // Save the Visio diagram
            diagram.Save(dataDir + "RemoveHiddenInfo_out.html", options);
            // ExEnd:RemoveHiddenInfo

        }
    }
}
