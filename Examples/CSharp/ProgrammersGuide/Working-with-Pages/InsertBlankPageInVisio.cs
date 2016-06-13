using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_with_Pages
{
    public class InsertBlankPageInVisio
    {
        public static void Run()
        {
            // ExStart:InsertBlankPageInVisio
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_VisioPages();

            // Load diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // it calculates max page id
            int max = 0;
            if (diagram.Pages.Count != 0)
                max = diagram.Pages[0].ID;

            for (int i = 1; i < diagram.Pages.Count; i++)
            {
                if (max < diagram.Pages[i].ID)
                    max = diagram.Pages[i].ID;
            }

            // set max page ID
            int MaxPageId = max;

            // Initialize a new page object
            Page newPage = new Page();
            // Set name
            newPage.Name = "new page";
            // Set page ID
            newPage.ID = MaxPageId + 1;

            // Or try the Page constructor
            // Page newPage = new Page(MaxPageId + 1);

            // Add a new blank page
            diagram.Pages.Add(newPage);

            // Save diagram
            diagram.Save(dataDir + "InsertBlankPage_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:InsertBlankPageInVisio
        }
    }
}
