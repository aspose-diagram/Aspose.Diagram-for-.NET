using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.Diagram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load diagram
            Diagram diagram = new Diagram(@"E:\Aspose\Aspose Vs VSTO\Aspose.Diagram Vs VSTO Visio v1.1\Sample Files\Drawing1.vsd");

            // Get max page ID
            int MaxPageId = GetMaxPageID(diagram);

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
            diagram.Save(@"E:\Aspose\Aspose Vs VSTO\Aspose.Diagram Vs VSTO Visio v1.1\Sample Files\Output.vdx", SaveFileFormat.VDX);


        }

        private static int GetMaxPageID(Diagram diagram)
        {
            int max = diagram.Pages[0].ID;
            for (int i = 1; i < diagram.Pages.Count; i++)
            {
                if (max < diagram.Pages[i].ID)
                    max = diagram.Pages[i].ID;
            }
            return max;
        }
    }
}
