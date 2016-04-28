using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Visio = Microsoft.Office.Interop.Visio;

namespace CSharp.Knowledge_Base
{
    public class CreatingDiagramWithVSTO
    {
        public static void Run() 
        {
            //ExStart:CreatingDiagramWithVSTO
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_KnowledgeBase();

            Visio.Application vdxApp = null;
            Visio.Document vdxDoc = null;
            try
            {
                //Create Visio Application Object
                vdxApp = new Visio.Application();

                //Make Visio Application Invisible
                vdxApp.Visible = false;

                //Create a new diagram
                vdxDoc = vdxApp.Documents.Add("");

                //Load Visio Stencil
                Visio.Documents visioDocs = vdxApp.Documents;
                Visio.Document visioStencil = visioDocs.OpenEx("Basic Shapes.vss",
                    (short)Microsoft.Office.Interop.Visio.VisOpenSaveArgs.visOpenHidden);

                //Set active page
                Visio.Page visioPage = vdxApp.ActivePage;

                //Add a new rectangle shape
                Visio.Master visioRectMaster = visioStencil.Masters.get_ItemU(@"Rectangle");
                Visio.Shape visioRectShape = visioPage.Drop(visioRectMaster, 4.25, 5.5);
                visioRectShape.Text = @"Rectangle text.";

                //Add a new star shape
                Visio.Master visioStarMaster = visioStencil.Masters.get_ItemU(@"Star 7");
                Visio.Shape visioStarShape = visioPage.Drop(visioStarMaster, 2.0, 5.5);
                visioStarShape.Text = @"Star text.";

                //Add a new hexagon shape
                Visio.Master visioHexagonMaster = visioStencil.Masters.get_ItemU(@"Hexagon");
                Visio.Shape visioHexagonShape = visioPage.Drop(visioHexagonMaster, 7.0, 5.5);
                visioHexagonShape.Text = @"Hexagon text.";


                //Save diagram as VDX
                vdxDoc.SaveAs(dataDir + "CreatingDiagramWithVSTO_Out.vdx");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Close active document and quit
                vdxDoc.Close();
                vdxApp.Quit();
            }
            //ExEnd:CreatingDiagramWithVSTO
        }
    }
}
