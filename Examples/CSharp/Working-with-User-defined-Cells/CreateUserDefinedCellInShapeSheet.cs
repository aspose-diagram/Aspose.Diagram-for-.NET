using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_User_defined_Cells
{
    public class CreateUserDefinedCellInShapeSheet
    {
        public static void Run() 
        {
            // ExStart:CreateUserDefinedCellInShapeSheet
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_UserDefinedCells();

            // Load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // Get page by name
            Page page = diagram.Pages.GetPage("Page-1");
            // Get shape by id
            Shape shape = page.Shapes.GetShape(2);
            
            // Initialize user object
            User user = new User();
            user.Name = "UserDefineCell";
            user.Value.Val = "800";
            // Add user-defined cell
            shape.Users.Add(user);

            // Save diagram
            diagram.Save(dataDir + "CreateUserDefinedCellInShapeSheet_out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:CreateUserDefinedCellInShapeSheet
        }
    }
}
