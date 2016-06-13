using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_with_User_defined_Cells
{
    public class CreateUserDefinedCellInShapeSheet
    {
        public static void Run() 
        {
            // ExStart:CreateUserDefinedCellInShapeSheet
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_UserDefinedCells();

            // load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // get page by name
            Page page = diagram.Pages.GetPage("Page-1");
            // get shape by id
            Shape shape = page.Shapes.GetShape(2);
            
            // initialize user object
            User user = new User();
            user.Name = "UserDefineCell";
            user.Value.Val = "800";
            // add user-defined cell
            shape.Users.Add(user);

            // save diagram
            diagram.Save(dataDir + "CreateUserDefinedCellInShapeSheet_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:CreateUserDefinedCellInShapeSheet
        }
    }
}
