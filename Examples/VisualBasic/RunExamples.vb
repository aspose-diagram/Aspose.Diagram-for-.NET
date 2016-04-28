Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Text

Imports VisualBasic.Diagrams
Imports VisualBasic.Shapes

Namespace VisualBasic
    Friend Class RunExamples
        <STAThread()> _
        Public Shared Sub Main()
            Console.WriteLine("Open RunExamples.cs. In Main() method, Un-comment the example that you want to run")
            Console.WriteLine("=====================================================")
            ' Un-comment the one you want to try out

            ' =====================================================
            ' =====================================================
            ' Working With Diagrams
            ' =====================================================
            ' =====================================================

            'AddConnectShapes.Run()
            'CreateDiagram.Run()
            'ExportPageToImage.Run()
            'ExportToHTML.Run()
            'ExportToImage.Run()
            'ExportToPDF.Run()
            'ExportToSVG.Run()
            'ExportToSWF.Run()
            'ExportToSWFWithoutViewer.Run()
            'ExportToXML.Run()
            'ExportToXPS.Run()
            'ExtractAllImagesFromPage.Run()
            'LayOutShapesInCompactTreeStyle.Run()
            'LayOutShapesInFlowchartStyle.Run()
            'ProtectAndUnprotect.Run()
            'ReadDiagramFile.Run()
            'RetrieveConnectorInfo.Run()
            'RetrieveFontInfo.Run()
            'RetrieveMasterInfo.Run()
            'RetrievePageInfo.Run()

            ' =====================================================
            ' =====================================================
            ' Working With Shapes
            ' =====================================================
            ' =====================================================

            'ApplyCustomStyleSheets.Run()
            'RetrieveShapeInfo.Run()
            'SetFillData.Run()
            'SetLineData.Run()
            'SetXFormdata.Run()
            'UpdateShapeText.Run()
            RefreshMilestoneWithMilestoneHelper.Run()

            ' Stop before exiting
            Console.WriteLine(Constants.vbLf + Constants.vbLf & "Program Finished. Press any key to exit....")
            Console.ReadKey()
        End Sub

        Public Shared Function GetDataDir_Diagrams() As String
            Return Path.GetFullPath("../../ProgrammersGuide/Working-Diagrams/Data/")
        End Function

        Public Shared Function GetDataDir_Shapes() As String
            Return Path.GetFullPath("../../ProgrammersGuide/Working-Shapes/Data/")
        End Function
        Public Shared Function GetDataDir_Intro() As String
            Return Path.GetFullPath("../../ProgrammersGuide/Introduction/Data/")
        End Function
        Public Shared Function GetDataDir_LoadSaveConvert() As String
            Return Path.GetFullPath("../../ProgrammersGuide/Load-Save-Convert/Data/")
        End Function
        Public Shared Function GetDataDir_ShapeText() As String
            Return Path.GetFullPath("../../ProgrammersGuide/Working-with-Text/Data/")
        End Function
        Public Shared Function GetDataDir_Protection() As String
            Return Path.GetFullPath("../../ProgrammersGuide/Working-with-Protection/Data/")
        End Function
        Public Shared Function GetDataDir_Master() As String
            Return Path.GetFullPath("../../ProgrammersGuide/Working-with-Masters/Data/")
        End Function
        Public Shared Function GetDataDir_VisioPages() As String
            Return Path.GetFullPath("../../ProgrammersGuide/Working-with-Pages/Data/")
        End Function
        Public Shared Function GetDataDir_VisioComments() As String
            Return Path.GetFullPath("../../ProgrammersGuide/Working-with-Comments/Data/")
        End Function
        Public Shared Function GetDataDir_ExternalDataSources() As String
            Return Path.GetFullPath("../../ProgrammersGuide/Working-with-External-Data-Sources/Data/")
        End Function
        Public Shared Function GetDataDir_GeometrySection() As String
            Return Path.GetFullPath("../../ProgrammersGuide/Working-with-Geometry-Section/Data/")
        End Function
        Public Shared Function GetDataDir_HeadersAndFooters() As String
            Return Path.GetFullPath("../../ProgrammersGuide/Working-with-Headers-and-Footers/Data/")
        End Function
        Public Shared Function GetDataDir_Hyperlinks() As String
            Return Path.GetFullPath("../../ProgrammersGuide/Working-with-Hyperlinks/Data/")
        End Function
        Public Shared Function GetDataDir_Layers() As String
            Return Path.GetFullPath("../../ProgrammersGuide/Working-with-Hyperlinks/Data/")
        End Function
        Public Shared Function GetDataDir_Print() As String
            Return Path.GetFullPath("../../ProgrammersGuide/Working-with-Layers/Data/")
        End Function
        Public Shared Function GetDataDir_SolutionXML() As String
            Return Path.GetFullPath("../../ProgrammersGuide/Working-with-SolutionXML-Elements/Data/")
        End Function
        Public Shared Function GetDataDir_ShapeTextBoxData() As String
            Return Path.GetFullPath("../../ProgrammersGuide/Working-with-Text-Boxes/Data/")
        End Function
        Public Shared Function GetDataDir_UserDefinedCells() As String
            Return Path.GetFullPath("../../ProgrammersGuide/Working-with-User-defined-Cells/Data/")
        End Function
        Public Shared Function GetDataDir_WindowElements() As String
            Return Path.GetFullPath("../../ProgrammersGuide/Working-with-Window-Elements/Data/")
        End Function
        Public Shared Function GetDataDir_TechnicalArticles() As String
            Return Path.GetFullPath("../../ProgrammersGuide/Technical-Articles/Data/")
        End Function
        Public Shared Function GetDataDir_KnowledgeBase() As [String]
            Return Path.GetFullPath("../../Knowledge-Base/Data/")
        End Function
    End Class
End Namespace