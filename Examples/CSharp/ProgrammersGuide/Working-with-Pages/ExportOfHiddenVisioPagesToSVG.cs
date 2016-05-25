using Aspose.Diagram;
using Aspose.Diagram.Saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_with_Pages
{
    public class ExportOfHiddenVisioPagesToSVG
    {
        public static void Run()
        {
            try
            {
                //ExStart:ExportOfHiddenVisioPagesToSVG
                // The path to the documents directory.
                string dataDir = RunExamples.GetDataDir_Intro();

                // load an existing Visio
                Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
                // get a particular page
                Page page = diagram.Pages.GetPage("Flow 2");
                // set Visio page visiblity
                page.PageSheet.PageProps.UIVisibility.Value = BOOL.False;

                // initialize PDF save options
                SVGSaveOptions options = new SVGSaveOptions();
                // set export option of hidden Visio pages
                options.ExportHiddenPage = false;

                //Save the Visio diagram
                diagram.Save(dataDir + "ExportOfHiddenVisioPagesToSVG_Out.svg", options);
                //ExEnd:ExportOfHiddenVisioPagesToSVG
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("This example will only work if you apply a valid Aspose License. You can purchase full license or get 30 day temporary license from http://www.aspose.com/purchase/default.aspx.");
            }
        }
    }
}
