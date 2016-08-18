using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_Shapes
{
    public class CopyShape
    {
        public static void Run()
        {
            // ExStart:CopyShape
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();
            
            // Load a source Visio
            Diagram srcVisio = new Diagram(dataDir + "Drawing1.vsdx");
            
            // Initialize a new Visio
            Diagram newDiagram = new Diagram();

            // Add all masters from the source Visio diagram
            MasterCollection originalMasters = srcVisio.Masters;
            foreach (Master master in originalMasters)
                newDiagram.AddMaster(srcVisio, master.Name);

            // Get the page object from the original diagram
            Aspose.Diagram.Page SrcPage = srcVisio.Pages.GetPage("Page-1");
            // Copy themes from the source diagram
            newDiagram.CopyTheme(srcVisio);
            // Copy pagesheet of the source Visio page
            newDiagram.Pages[0].PageSheet.Copy(SrcPage.PageSheet);

            // Copy shapes from the source Visio page
            foreach (Aspose.Diagram.Shape shape in SrcPage.Shapes)
            {
                newDiagram.Pages[0].Shapes.Add(shape);
            }
            // Save the new Visio
            newDiagram.Save(dataDir + "CopyShapes_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:CopyShape
        }
    }
}
