using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using CSharp.Diagrams;
using CSharp.Shapes;

namespace CSharp
{
    class RunExamples
    {
        [STAThread]
        public static void Main()
        {
            Console.WriteLine("Open RunExamples.cs. In Main() method, Un-comment the example that you want to run");
            Console.WriteLine("=====================================================");
            // Un-comment the one you want to try out

            // =====================================================
            // =====================================================
            // Working With Diagrams
            // =====================================================
            // =====================================================

            //AddConnectShapes.Run();
            //CreateDiagram.Run();
            //ExportPageToImage.Run();
            //ExportToHTML.Run();
            //ExportToImage.Run();
            //ExportToPDF.Run();
            //ExportToSVG.Run();
            //ExportToSWF.Run();
            //ExportToSWFWithoutViewer.Run();
            //ExportToXML.Run();
            //ExportToXPS.Run();
            //ExtractAllImagesFromPage.Run();
            //LayOutShapesInCompactTreeStyle.Run();
            //LayOutShapesInFlowchartStyle.Run();
            //ProtectAndUnprotect.Run();
            //ReadDiagramFile.Run();
            //RetrieveConnectorInfo.Run();
            //RetrieveFontInfo.Run();
            //RetrieveMasterInfo.Run();
            //RetrievePageInfo.Run();

            // =====================================================
            // =====================================================
            // Working With Shapes
            // =====================================================
            // =====================================================

            //ApplyCustomStyleSheets.Run();
            //RetrieveShapeInfo.Run();
            //SetFillData.Run();
            //SetLineData.Run();
            //SetXFormdata.Run();
            //UpdateShapeText.Run();
            RefreshMilestoneWithMilestoneHelper.Run();
            
            // Stop before exiting
            Console.WriteLine("\n\nProgram Finished. Press any key to exit....");
            Console.ReadKey();
        }

        public static String GetDataDir_Diagrams()
        {
            return Path.GetFullPath("../../ProgrammersGuide/Working-Diagrams/Data/");
        }

        public static String GetDataDir_Shapes()
        {
            return Path.GetFullPath("../../ProgrammersGuide/Working-Shapes/Data/");
        }

    }
}