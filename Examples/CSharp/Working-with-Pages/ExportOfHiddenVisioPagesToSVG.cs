using Aspose.Diagram;
using Aspose.Diagram.Saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Pages
{
    public class ExportOfHiddenVisioPagesToSVG
    {
        public static void Run()
        {
            try
            {
                // ExStart:ExportOfHiddenVisioPagesToSVG
                // The path to the documents directory.
                string dataDir = RunExamples.GetDataDir_Intro();

                // Load an existing Visio
                Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
                // Get a particular page
                Page page = diagram.Pages.GetPage("Flow 2");
                // Set Visio page visiblity
                page.PageSheet.PageProps.UIVisibility.Value = UIVisibilityValue.Visible;

                // Initialize PDF save options
                SVGSaveOptions options = new SVGSaveOptions();
                // Set export option of hidden Visio pages
                options.ExportHiddenPage = false;

                // Save the Visio diagram
                diagram.Save(dataDir + "ExportOfHiddenVisioPagesToSVG_out.svg", options);
                // ExEnd:ExportOfHiddenVisioPagesToSVG
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message + "\nThis example will only work if you apply a valid Aspose License. You can purchase full license or get 30 day temporary license from http:// Www.aspose.com/purchase/default.aspx.");
            }
        }
    }
}
