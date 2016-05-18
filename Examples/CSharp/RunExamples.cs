using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using CSharp.Diagrams;
using CSharp.Shapes;
using CSharp.ProgrammersGuide.Introduction;
using CSharp.ProgrammersGuide.Working_Shapes;
using CSharp.ProgrammersGuide.Working_with_Comments;

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
            //GetLibraryVersion.Run();

            // =====================================================
            // =====================================================
            // Working With Diagrams
            // =====================================================
            // =====================================================

            //AddConnectShapes.Run();
            //CreateDiagram.Run();
            ExportPageToImage.Run();
            //ExportToHTML.Run();
            //ExportToImage.Run();
            //ExportToPDF.Run();
            //ExportToSVG.Run();            
            //ExportToXML.Run();
            //ExportToXPS.Run();
            //ExtractAllImagesFromPage.Run();
            //LayOutShapesInCompactTreeStyle.Run();
            //LayOutShapesInFlowchartStyle.Run();           
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

            // =====================================================
            // =====================================================
            // Working With Comments
            // =====================================================
            // =====================================================

            //AddPageLevelCommentInVisio.Run();
            //EditPageLevelCommentInVisio.Run();
            
            // Stop before exiting
            Console.WriteLine("\n\nProgram Finished. Press any key to exit....");
            Console.ReadKey();
        }
        public static String GetDataDir_Intro()
        {
            return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Introduction/");
        }
        public static String GetDataDir_LoadSaveConvert()
        {
            return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Load-Save-Convert/");
        }
        public static String GetDataDir_Diagrams()
        {
            return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-Diagrams/");
        }

        public static String GetDataDir_Shapes()
        {
            return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-Shapes/");
        }
        public static String GetDataDir_ShapeText()
        {
            return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Text/");
        }
        public static String GetDataDir_Protection()
        {
            return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Protection/");
        }
        public static String GetDataDir_Master()
        {
            return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Masters/");
        }
        public static String GetDataDir_VisioPages()
        {
            return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Pages/");
        }
        public static String GetDataDir_VisioComments()
        {
            return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Comments/");
        }
        public static String GetDataDir_ExternalDataSources()
        {
            return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-External-Data-Sources/");
        }
        public static String GetDataDir_GeometrySection()
        {
            return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Geometry-Section/");
        }
        public static String GetDataDir_HeadersAndFooters()
        {
            return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Headers-and-Footers/");
        }
        public static String GetDataDir_Hyperlinks()
        {
            return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Hyperlinks/");
        }
        public static String GetDataDir_Layers()
        {
            return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Layers/");
        }
        public static String GetDataDir_Print()
        {
            return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Print/");
        }
        public static String GetDataDir_SolutionXML()
        {
            return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-SolutionXML-Elements/");
        }
        public static String GetDataDir_ShapeTextBoxData()
        {
            return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Text-Boxes/");
        }
        public static String GetDataDir_UserDefinedCells()
        {
            return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-User-defined-Cells/");
        }
        public static String GetDataDir_WindowElements()
        {
            return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Window-Elements/");
        }
        public static String GetDataDir_TechnicalArticles()
        {
            return Path.GetFullPath(GetDataDir_Data() + "Technical-Articles/");
        }
        public static String GetDataDir_KnowledgeBase()
        {
            return Path.GetFullPath(GetDataDir_Data() + "Knowledge-Base/");
        }
        private static string GetDataDir_Data()
        {
            var parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            string startDirectory = null;
            if (parent != null)
            {
                var directoryInfo = parent.Parent;
                if (directoryInfo != null)
                {
                    startDirectory = directoryInfo.FullName;
                }
            }
            else
            {
                startDirectory = parent.FullName;
            }
            return Path.Combine(startDirectory, "Data\\");
        }       
    }
}