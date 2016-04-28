using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_with_Hyperlinks
{
    public class AddHyperlinkToShape
    {
        public static void Run() 
        {
            //ExStart:AddHyperlinkToShape
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Hyperlinks();

            // load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // get page by name
            Page page = diagram.Pages.GetPage("Page-1");
            // get shape by ID
            Shape shape = page.Shapes.GetShape(2);

            //initialize Hyperlink object
            Hyperlink hyperlink = new Hyperlink();
            //set address value
            hyperlink.Address.Value = "http://www.google.com/";
            //set sub address value
            hyperlink.SubAddress.Value = "Sub address here";
            //set description value
            hyperlink.Description.Value = "Description here";
            //set name
            hyperlink.Name = "MyHyperLink";

            //add hyperlink to the shape
            shape.Hyperlinks.Add(hyperlink);            
            //save diagram to local space
            diagram.Save(dataDir + "AddHyperlinkToShape_Out.vsdx", SaveFileFormat.VSDX);
            //ExEnd:AddHyperlinkToShape
        }
    }
}
