using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Pages
{
    public class CopyVisioPage
    {
        public static void Run()
        {
            // ExStart:CopyVisioPage
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_VisioPages();

            // Initialize the new visio diagram
            Diagram NewDigram = new Diagram();

            // Load source diagram
            Diagram dgm = new Diagram(dataDir + "Drawing1.vsdx");
            // Add all masters from the source Visio diagram
            foreach (Master master in dgm.Masters)
                NewDigram.Masters.Add(master);

            // Get page object
            Aspose.Diagram.Page SrcPage = dgm.Pages.GetPage("Page-1");
            // Set name
            SrcPage.Name = "new page";

            // It calculates max page id
            int max = 0;
            if (NewDigram.Pages.Count != 0)
                max = NewDigram.Pages[0].ID;

            for (int i = 1; i < NewDigram.Pages.Count; i++)
            {
                if (max < NewDigram.Pages[i].ID)
                    max = NewDigram.Pages[i].ID;
            }
            
            // Set max page ID 
            int MaxPageId = max;
            // Set page ID
            SrcPage.ID = MaxPageId + 1;

            // Add page from the source diagram
            NewDigram.Pages.Add(SrcPage);
            // Remove first empty page
            NewDigram.Pages.Remove(NewDigram.Pages[0]);
            // Save diagram
            NewDigram.Save(dataDir + "CopyVisioPage_out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:CopyVisioPage
        }
    }
}
