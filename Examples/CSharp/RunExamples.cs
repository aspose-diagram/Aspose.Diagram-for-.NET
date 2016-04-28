using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using CSharp.Diagrams;
using CSharp.Shapes;
using CSharp.ProgrammersGuide.Introduction;
using CSharp.ProgrammersGuide.Working_Shapes;

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
            // Introduction
            // =====================================================
            // =====================================================
            GetLibraryVersion.Run();

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
            //RefreshMilestoneWithMilestoneHelper.Run();
            
            // Stop before exiting
            Console.WriteLine("\n\nProgram Finished. Press any key to exit....");
            Console.ReadKey();
        }
        public static String GetDataDir_Intro()
        {
            return Path.GetFullPath("../../ProgrammersGuide/Introduction/Data/");
        }
        public static String GetDataDir_LoadSaveConvert()
        {
            return Path.GetFullPath("../../ProgrammersGuide/Load-Save-Convert/Data/");
        }
        public static String GetDataDir_Diagrams()
        {
            return Path.GetFullPath("../../ProgrammersGuide/Working-Diagrams/Data/");
        }

        public static String GetDataDir_Shapes()
        {
            return Path.GetFullPath("../../ProgrammersGuide/Working-Shapes/Data/");
        }
        public static String GetDataDir_ShapeText()
        {
            return Path.GetFullPath("../../ProgrammersGuide/Working-with-Text/Data/");
        }
        public static String GetDataDir_Protection()
        {
            return Path.GetFullPath("../../ProgrammersGuide/Working-with-Protection/Data/");
        }
        public static String GetDataDir_Master()
        {
            return Path.GetFullPath("../../ProgrammersGuide/Working-with-Masters/Data/");
        }
        public static String GetDataDir_VisioPages()
        {
            return Path.GetFullPath("../../ProgrammersGuide/Working-with-Pages/Data/");
        }
        public static String GetDataDir_VisioComments()
        {
            return Path.GetFullPath("../../ProgrammersGuide/Working-with-Comments/Data/");
        }
        public static String GetDataDir_ExternalDataSources()
        {
            return Path.GetFullPath("../../ProgrammersGuide/Working-with-External-Data-Sources/Data/");
        }
        public static String GetDataDir_GeometrySection()
        {
            return Path.GetFullPath("../../ProgrammersGuide/Working-with-Geometry-Section/Data/");
        }
        public static String GetDataDir_HeadersAndFooters()
        {
            return Path.GetFullPath("../../ProgrammersGuide/Working-with-Headers-and-Footers/Data/");
        }
        public static String GetDataDir_Hyperlinks()
        {
            return Path.GetFullPath("../../ProgrammersGuide/Working-with-Hyperlinks/Data/");
        }
        public static String GetDataDir_Layers()
        {
            return Path.GetFullPath("../../ProgrammersGuide/Working-with-Layers/Data/");
        }
        public static String GetDataDir_Print()
        {
            return Path.GetFullPath("../../ProgrammersGuide/Working-with-Print/Data/");
        }
        public static String GetDataDir_SolutionXML()
        {
            return Path.GetFullPath("../../ProgrammersGuide/Working-with-SolutionXML-Elements/Data/");
        }
        public static String GetDataDir_ShapeTextBoxData()
        {
            return Path.GetFullPath("../../ProgrammersGuide/Working-with-Text-Boxes/Data/");
        }
        public static String GetDataDir_UserDefinedCells()
        {
            return Path.GetFullPath("../../ProgrammersGuide/Working-with-User-defined-Cells/Data/");
        }
        public static String GetDataDir_WindowElements()
        {
            return Path.GetFullPath("../../ProgrammersGuide/Working-with-Window-Elements/Data/");
        }
        public static String GetDataDir_TechnicalArticles()
        {
            return Path.GetFullPath("../../ProgrammersGuide/Technical-Articles/Data/");
        }
        public static String GetDataDir_KnowledgeBase()
        {
            return Path.GetFullPath("../../Knowledge-Base/Data/");
        }
    }
}