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

            AddConnectShapes.Run()
            'CreateDiagram.Run();
            'ExportPageToImage.Run();
            'ExportToHTML.Run();
            'ExportToImage.Run();
            'ExportToPDF.Run();
            'ExportToSVG.Run();
            'ExportToSWF.Run();
            'ExportToSWFWithoutViewer.Run();
            'ExportToXML.Run();
            'ExportToXPS.Run();
            'ExtractAllImagesFromPage.Run();
            'LayOutShapesInCompactTreeStyle.Run();
            'LayOutShapesInFlowchartStyle.Run();
            'ProtectAndUnprotect.Run();
            'ReadDiagramFile.Run();
            'RetrieveConnectorInfo.Run();
            'RetrieveFontInfo.Run();
            'RetrieveMasterInfo.Run();
            'RetrievePageInfo.Run();

            ' =====================================================
            ' =====================================================
            ' Working With Shapes
            ' =====================================================
            ' =====================================================

            'ApplyCustomStyleSheets.Run();
            'RetrieveShapeInfo.Run();
            'SetFillData.Run();
            'SetLineData.Run();
            'SetXFormdata.Run();
            'UpdateShapeText.Run();


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

    End Class
End Namespace