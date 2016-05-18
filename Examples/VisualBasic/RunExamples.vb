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
            'ExportToXML.Run()
            'ExportToXPS.Run()
            'ExtractAllImagesFromPage.Run()
            'LayOutShapesInCompactTreeStyle.Run()
            'LayOutShapesInFlowchartStyle.Run()
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
            'RefreshMilestoneWithMilestoneHelper.Run()

            ' =====================================================
            ' =====================================================
            ' Working With Comments
            ' =====================================================
            ' =====================================================

            'AddPageLevelCommentInVisio.Run()
            'EditPageLevelCommentInVisio.Run()

            ' Stop before exiting
            Console.WriteLine(Constants.vbLf + Constants.vbLf & "Program Finished. Press any key to exit....")
            Console.ReadKey()
        End Sub

        Public Shared Function GetDataDir_Intro() As [String]
            Return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Introduction/")
        End Function
        Public Shared Function GetDataDir_LoadSaveConvert() As [String]
            Return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Load-Save-Convert/")
        End Function
        Public Shared Function GetDataDir_Diagrams() As [String]
            Return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-Diagrams/")
        End Function

        Public Shared Function GetDataDir_Shapes() As [String]
            Return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-Shapes/")
        End Function
        Public Shared Function GetDataDir_ShapeText() As [String]
            Return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Text/")
        End Function
        Public Shared Function GetDataDir_Protection() As [String]
            Return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Protection/")
        End Function
        Public Shared Function GetDataDir_Master() As [String]
            Return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Masters/")
        End Function
        Public Shared Function GetDataDir_VisioPages() As [String]
            Return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Pages/")
        End Function
        Public Shared Function GetDataDir_VisioComments() As [String]
            Return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Comments/")
        End Function
        Public Shared Function GetDataDir_ExternalDataSources() As [String]
            Return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-External-Data-Sources/")
        End Function
        Public Shared Function GetDataDir_GeometrySection() As [String]
            Return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Geometry-Section/")
        End Function
        Public Shared Function GetDataDir_HeadersAndFooters() As [String]
            Return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Headers-and-Footers/")
        End Function
        Public Shared Function GetDataDir_Hyperlinks() As [String]
            Return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Hyperlinks/")
        End Function
        Public Shared Function GetDataDir_Layers() As [String]
            Return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Layers/")
        End Function
        Public Shared Function GetDataDir_Print() As [String]
            Return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Print/")
        End Function
        Public Shared Function GetDataDir_SolutionXML() As [String]
            Return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-SolutionXML-Elements/")
        End Function
        Public Shared Function GetDataDir_ShapeTextBoxData() As [String]
            Return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Text-Boxes/")
        End Function
        Public Shared Function GetDataDir_UserDefinedCells() As [String]
            Return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-User-defined-Cells/")
        End Function
        Public Shared Function GetDataDir_WindowElements() As [String]
            Return Path.GetFullPath(GetDataDir_Data() + "ProgrammersGuide/Working-with-Window-Elements/")
        End Function
        Public Shared Function GetDataDir_TechnicalArticles() As [String]
            Return Path.GetFullPath(GetDataDir_Data() + "Technical-Articles/")
        End Function
        Public Shared Function GetDataDir_KnowledgeBase() As [String]
            Return Path.GetFullPath(GetDataDir_Data() + "Knowledge-Base/")
        End Function
        Private Shared Function GetDataDir_Data() As String
            Dim parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent
            Dim startDirectory As String = Nothing
            If parent IsNot Nothing Then
                Dim directoryInfo = parent.Parent
                If directoryInfo IsNot Nothing Then
                    startDirectory = directoryInfo.FullName
                End If
            Else
                startDirectory = parent.FullName
            End If
            Return Path.Combine(startDirectory, "Data\")
        End Function
    End Class
End Namespace