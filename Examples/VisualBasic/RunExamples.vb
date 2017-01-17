Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Text
Imports Aspose.Diagram.Examples.VisualBasic.Diagrams
Imports Aspose.Diagram.Examples.VisualBasic.Shapes
Imports Aspose.Diagram.Examples.VisualBasic.Event_Section
Friend Class RunExamples
    <STAThread()> _
    Public Shared Sub Main()
        Console.WriteLine("Open RunExamples.vb. " & vbLf & "In Main() method uncomment the example that you want to run.")
        Console.WriteLine("=====================================================")
        ' Uncomment the one you want to try out

        '' =====================================================
        '' =====================================================
        '' Introduction
        '' =====================================================
        '' =====================================================

        'GetLibraryVersion.Run()
        'SetVisioProperties.Run()
        'DetectVisioFileFormat.Run()

        '' =====================================================
        '' =====================================================
        '' Load-Save-Convert
        '' =====================================================
        '' =====================================================

        ' CreateNewVisio.Run()
        ' ExportHTMLinStream.Run()
        ' ExportToXAML.Run()
        ' ReadVisioDiagram.Run()
        ' CreateMasterFromScratch.Run()
        ' ConvertVisioWithSelectiveShapes.Run()

        '' =====================================================
        '' =====================================================
        '' Working-with-Geometry-Section
        '' =====================================================
        '' =====================================================

        ' EditConnectorGeometry.Run()

        '' =====================================================
        '' =====================================================
        '' Working-with-Headers-and-Footers
        '' =====================================================
        '' =====================================================

        ' ManageHeadersandFooters.Run()

        '' =====================================================
        '' =====================================================
        '' Working With Diagrams
        '' =====================================================
        '' =====================================================

        ' AddConnectShapes.Run()
        ' CreateDiagram.Run()
        ' ExportPageToImage.Run()
        ' ExportToHTML.Run()
        ' ExportToImage.Run()
        ' ExportToPDF.Run()
        ' ExportToSVG.Run()
        ' ExportToXML.Run()
        ' ExportToXPS.Run()
        ' ExtractAllImagesFromPage.Run()
        ' LayOutShapesInCompactTreeStyle.Run()
        ' LayOutShapesInFlowchartStyle.Run()
        ' ReadDiagramFile.Run()
        ' RetrieveConnectorInfo.Run()
        ' RetrieveFontInfo.Run()
        ' RetrieveMasterInfo.Run()
        ' RetrievePageInfo.Run()
        ' ExportToSWF.Run()
        ' ExportToSWFWithoutViewer.Run()
        ' ModifyVBAModule.Run()
        ' RetrieveInheritedFillData.Run()

        '' =====================================================
        '' =====================================================
        '' Working With Shapes
        '' =====================================================
        '' =====================================================

        ' ApplyCustomStyleSheets.Run()
        ' RetrieveShapeInfo.Run()
        ' SetFillData.Run()
        ' SetLineData.Run()
        ' SetXFormdata.Run()
        ' UpdateShapeText.Run()
        ' RefreshMilestoneWithMilestoneHelper.Run()

        '' =====================================================
        '' =====================================================
        '' Working With Comments
        '' =====================================================
        '' =====================================================

        ' AddPageLevelCommentInVisio.Run()
        ' EditPageLevelCommentInVisio.Run()

        '' =====================================================
        '' =====================================================
        '' Knowledge-Base
        '' =====================================================
        '' =====================================================

        ' CreatingDiagramWithAspose.Run()
        ' CreatingDiagramWithVSTO.Run()
        ' SaveDiagramTo_VDX_PDF_JPEG_withAspose.Run()
        ' SaveDiagramTo_VDX_PDF_JPEG_withAspose.Run()
        ' UpdateShapePropsWithAspose.Run()
        ' UpdateShapePropsWithVSTO.Run()

        '' =====================================================
        '' =====================================================
        '' Technical-Articles
        '' =====================================================
        '' =====================================================

        ' AddConnectShapes.Run()

        '' =====================================================
        '' =====================================================
        '' Working-with-Hyperlinks
        '' =====================================================
        '' =====================================================

        ' AddHyperlinkToShape.Run()
        ' GetHyperlinks.Run()

        '' =====================================================
        '' =====================================================
        '' Working-with-Layers
        '' =====================================================
        '' =====================================================

        ' AddLayer.Run()
        ' ConfigureShapeLayers.Run()
        ' RetrieveAllLayers.Run()

        '' =====================================================
        '' =====================================================
        '' Working-with-Masters
        '' =====================================================
        '' =====================================================

        ' CheckMasterPresencebyID.Run()
        ' CheckMasterPresencebyName.Run()
        ' GetMasterbyID.Run()
        ' GetMasterbyName.Run()
        ' RetrieveMasterInfo.Run()

        '' =====================================================
        '' =====================================================
        '' Working-with-Pages
        '' =====================================================
        '' =====================================================

        ' CopyVisioPage.Run()
        ' ExportOfHiddenVisioPagesToHTML.Run()
        ' ExportOfHiddenVisioPagesToImage.Run()
        ' ExportOfHiddenVisioPagesToPDF.Run()
        ' ExportOfHiddenVisioPagesToSVG.Run()
        ' ExportOfHiddenVisioPagesToXPS.Run()
        ' GetVisioPagebyID.Run()
        ' GetVisioPagebyName.Run()
        ' InsertBlankPageInVisio.Run()
        ' RetrievePageInfo.Run()
        ' SetVisioPageOrientation.Run()

        '' =====================================================
        '' =====================================================
        '' Working-with-Print
        '' =====================================================
        '' =====================================================

        ' ByDefaultPrinter.Run()
        ' BySpecificPrinter.Run()
        ' PrintDiagramVisXPSPrinterAPI.Run()
        ' SetPrintJobAndPrinterName.Run()

        '' =====================================================
        '' =====================================================
        '' Working-with-Protection
        '' =====================================================
        '' =====================================================

        ' VisioDiagramProtection.Run()
        ' VisioShapeProtection.Run()

        '' =====================================================
        '' =====================================================
        '' Working-with-SolutionXML-Elements
        '' =====================================================
        '' =====================================================

        ' AddSolutionXMLElement.Run()
        ' ReadSolutionXMLElement.Run()

        '' =====================================================
        '' =====================================================
        '' Working-with-Text
        '' =====================================================
        '' =====================================================

        ' ApplyCustomStyleSheets.Run()
        ' ApplyFontOnText.Run()
        ' FindAndReplaceShapeText.Run()
        ' GetPlainTextOfVisio.Run()
        ' UpdateShapeText.Run()
        ' InsertTextShape.Run()

        '' =====================================================
        '' =====================================================
        '' Working-with-Text-Boxes
        '' =====================================================
        '' =====================================================

        ' FormatShapeTextBlockSection.Run()
        ' SetShapeTextPositionAtBottom.Run()
        ' SetShapeTextPositionAtLeft.Run()
        ' SetShapeTextPositionAtRight.Run()
        ' SetShapeTextPositionAtTop.Run()

        '' =====================================================
        '' =====================================================
        '' Working-with-User-defined-Cells
        '' =====================================================
        '' =====================================================

        ' CreateUserDefinedCellInShapeSheet.Run()
        ' ReadUserdefinedCellsOfShape.Run()
        ' RetrieveUserDefinedCells.Run()

        '' =====================================================
        '' =====================================================
        '' Working-with-Window-Elements
        '' =====================================================
        '' =====================================================

        ' AddSupportOfVisualAids.Run()
        ' AddWindowElementInVisio.Run()
        ' DisplayGridsRulersGuidesAndPageBreaks.Run()
        ' RetrieveWindowElementsOfDiagram.Run()

        '' =====================================================
        '' =====================================================
        '' OLE-Objects
        '' =====================================================
        '' =====================================================
        ' ManipulateObjects.Run()

        '' =====================================================
        '' =====================================================
        '' Event-Section
        '' =====================================================
        '' =====================================================
        ' SettingCellsInEventSection.Run()

        '' =====================================================
        '' =====================================================
        '' Visio-ActiveX-Controls
        '' =====================================================
        '' =====================================================
        ' InsertActiveXControl.Run()

        '' =====================================================
        '' =====================================================
        '' ModifyShapeGradientFillData
        '' =====================================================
        '' =====================================================
        ' ModifyShapeGradientFillData.Run()

        ' Stop before exiting
        Console.WriteLine(Constants.vbLf + Constants.vbLf & "Program Finished. Press any key to exit....")
        Console.ReadKey()
    End Sub
    Public Shared Function GetDataDir_OLEObjects() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "OLE-Objects/")
    End Function
    Public Shared Function GetDataDir_VisioActiveXControls() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Visio-ActiveX-Controls/")
    End Function
    Public Shared Function GetDataDir_Intro() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Introduction/")
    End Function
    Public Shared Function GetDataDir_LoadSaveConvert() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Load-Save-Convert/")
    End Function
    Public Shared Function GetDataDir_Diagrams() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Working-Diagrams/")
    End Function

    Public Shared Function GetDataDir_Shapes() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Working-Shapes/")
    End Function
    Public Shared Function GetDataDir_ShapeText() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Working-with-Text/")
    End Function
    Public Shared Function GetDataDir_Protection() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Working-with-Protection/")
    End Function
    Public Shared Function GetDataDir_Master() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Working-with-Masters/")
    End Function
    Public Shared Function GetDataDir_VisioPages() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Working-with-Pages/")
    End Function
    Public Shared Function GetDataDir_VisioComments() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Working-with-Comments/")
    End Function
    Public Shared Function GetDataDir_ExternalDataSources() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Working-with-External-Data-Sources/")
    End Function
    Public Shared Function GetDataDir_GeometrySection() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Working-with-Geometry-Section/")
    End Function
    Public Shared Function GetDataDir_HeadersAndFooters() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Working-with-Headers-and-Footers/")
    End Function
    Public Shared Function GetDataDir_Hyperlinks() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Working-with-Hyperlinks/")
    End Function
    Public Shared Function GetDataDir_Layers() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Working-with-Layers/")
    End Function
    Public Shared Function GetDataDir_Print() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Working-with-Print/")
    End Function
    Public Shared Function GetDataDir_SolutionXML() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Working-with-SolutionXML-Elements/")
    End Function
    Public Shared Function GetDataDir_ShapeTextBoxData() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Working-with-Text-Boxes/")
    End Function
    Public Shared Function GetDataDir_UserDefinedCells() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Working-with-User-defined-Cells/")
    End Function
    Public Shared Function GetDataDir_WindowElements() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Working-with-Window-Elements/")
    End Function
    Public Shared Function GetDataDir_TechnicalArticles() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Technical-Articles/")
    End Function
    Public Shared Function GetDataDir_KnowledgeBase() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Knowledge-Base/")
    End Function
    Public Shared Function GetDataDir_EventSection() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "Event-Section/")
    End Function
    Public Shared Function GetDataDir_ShapeGradientFillData() As [String]
        Return Path.GetFullPath(GetDataDir_Data() + "ShapeGradientFillData/")
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
