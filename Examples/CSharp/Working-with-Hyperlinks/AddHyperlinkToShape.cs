using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Hyperlinks
{
    public class AddHyperlinkToShape
    {
        public static void Run() 
        {
            // ExStart:AddHyperlinkToShape
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Hyperlinks();

            // Load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // Get page by name
            Page page = diagram.Pages.GetPage("Page-1");
            // Get shape by ID
            Shape shape = page.Shapes.GetShape(2);

            // Initialize Hyperlink object
            Hyperlink hyperlink = new Hyperlink();
            // Set address value
            hyperlink.Address.Value = "http:// Www.google.com/";
            // Set sub address value
            hyperlink.SubAddress.Value = "Sub address here";
            // Set description value
            hyperlink.Description.Value = "Description here";
            // Set name
            hyperlink.Name = "MyHyperLink";

            // Add hyperlink to the shape
            shape.Hyperlinks.Add(hyperlink);            
            // Save diagram to local space
            diagram.Save(dataDir + "AddHyperlinkToShape_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:AddHyperlinkToShape
        }
    }
}
