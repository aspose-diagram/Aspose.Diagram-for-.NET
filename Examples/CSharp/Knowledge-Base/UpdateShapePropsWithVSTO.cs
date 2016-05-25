using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Visio = Microsoft.Office.Interop.Visio;

namespace CSharp.Knowledge_Base
{
    public class UpdateShapePropsWithVSTO
    {
        public static void Run() 
        {
            //ExStart:UpdateShapePropsWithVSTO
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_KnowledgeBase();

            Visio.Application vsdApp = null;
            Visio.Document vsdDoc = null;
            try
            {
                //Create Visio Application Object
                vsdApp = new Visio.Application();

                //Make Visio Application Invisible
                vsdApp.Visible = false;

                //Create a document object and load a diagram
                vsdDoc = vsdApp.Documents.Open(dataDir + "Drawing1.vsd");

                //Create page object to get required page
                Visio.Page page = vsdApp.ActivePage;

                //Create shape object to get required shape
                Visio.Shape shape = page.Shapes["Process1"];

                //Set shape text and text style
                shape.Text = "Hello World";
                shape.TextStyle = "CustomStyle1";

                //Set shape's position
                shape.get_Cells("PinX").ResultIU = 5;
                shape.get_Cells("PinY").ResultIU = 5;

                //Set shape's height and width
                shape.get_Cells("Height").ResultIU = 2;
                shape.get_Cells("Width").ResultIU = 3;

                //Save file as VDX
                vsdDoc.SaveAs(dataDir + "Drawing1.vdx");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nThis example will only work if you apply a valid Aspose License. You can purchase full license or get 30 day temporary license from http://www.aspose.com/purchase/default.aspx.");
            }           
            //ExEnd:UpdateShapePropsWithVSTO
        }
    }
}
