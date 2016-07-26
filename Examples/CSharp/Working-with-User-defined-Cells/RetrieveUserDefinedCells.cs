using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_User_defined_Cells
{
    public class RetrieveUserDefinedCells
    {
        public static void Run() 
        {
            // ExStart:RetrieveUserDefinedCells
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_UserDefinedCells();
            int count = 0;
            // load diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // Iterate through pages
            foreach (Aspose.Diagram.Page objPage in diagram.Pages)
            {
                // Iterate through shapes
                foreach (Aspose.Diagram.Shape objShape in objPage.Shapes)
                {
                    Console.WriteLine(objShape.NameU);
                    // Iterate through user-defined cells
                    foreach (Aspose.Diagram.User objUserField in objShape.Users)
                    {
                        count++;
                        Console.WriteLine(count + " - Name: " + objUserField.NameU + " Value: " + objUserField.Value.Val + " Prompt: " + objUserField.Prompt.Value);
                    }
                }
            }  
            // ExEnd:RetrieveUserDefinedCells            
        }
    }
}
