using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_with_User_defined_Cells
{
    public class ReadUserdefinedCellsOfShape
    {
        public static void Run() 
        {
            // ExStart:ReadUserdefinedCellsOfShape
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_UserDefinedCells();

            // load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // get page by name
            Page page = diagram.Pages.GetPage("Page-1");
            // get shape by id
            Shape shape = page.Shapes.GetShape(1);
            // extract user defined cells of the shape
            foreach (User user in shape.Users)
            {
                Console.WriteLine(user.Name + ": " + user.Value.Val);
            }
            // ExEnd:ReadUserdefinedCellsOfShape
        }
    }
}
