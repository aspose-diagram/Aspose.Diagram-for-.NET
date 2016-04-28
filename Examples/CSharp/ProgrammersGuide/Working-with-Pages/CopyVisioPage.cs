using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_with_Pages
{
    public class CopyVisioPage
    {
        public static void Run()
        {
            //ExStart:CopyVisioPage
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_VisioPages();

            // initialize the new visio diagram
            Diagram NewDigram = new Diagram();

            // load source diagram
            Diagram dgm = new Diagram(dataDir + "Drawing1.vsdx");
            // add all masters from the source Visio diagram
            foreach (Master master in dgm.Masters)
                NewDigram.Masters.Add(master);

            // get page object
            Aspose.Diagram.Page SrcPage = dgm.Pages.GetPage("Page-1");
            // Set name
            SrcPage.Name = "new page";

            // it calculates max page id
            int max = 0;
            if (NewDigram.Pages.Count != 0)
                max = NewDigram.Pages[0].ID;

            for (int i = 1; i < NewDigram.Pages.Count; i++)
            {
                if (max < NewDigram.Pages[i].ID)
                    max = NewDigram.Pages[i].ID;
            }
            
            // set max page ID 
            int MaxPageId = max;
            // Set page ID
            SrcPage.ID = MaxPageId + 1;

            // add page from the source diagram
            NewDigram.Pages.Add(SrcPage);
            // remove first empty page
            NewDigram.Pages.Remove(NewDigram.Pages[0]);
            // save diagram
            NewDigram.Save(dataDir + "CopyVisioPage_Out.vsdx", SaveFileFormat.VSDX);
            //ExEnd:CopyVisioPage
        }
    }
}
