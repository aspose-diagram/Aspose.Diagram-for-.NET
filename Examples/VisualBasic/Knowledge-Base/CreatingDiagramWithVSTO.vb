
Imports Aspose.Diagram
Imports System
Imports System.IO
Imports Visio = Microsoft.Office.Interop.Visio
Imports System.Collections

Public Class CreatingDiagramWithVSTO
    Public Shared Sub Run()
        ' ExStart:CreatingDiagramWithVSTO
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_KnowledgeBase()

        Dim vdxApp As Visio.Application = Nothing
        Dim vdxDoc As Visio.Document = Nothing
        Try
            ' Create Visio Application Object
            vdxApp = New Visio.Application()

            ' Make Visio Application Invisible
            vdxApp.Visible = False

            ' Create a new diagram
            vdxDoc = vdxApp.Documents.Add("")

            ' Load Visio Stencil
            Dim visioDocs As Visio.Documents = vdxApp.Documents
            Dim visioStencil As Visio.Document = visioDocs.OpenEx("Basic Shapes.vss", CShort(Microsoft.Office.Interop.Visio.VisOpenSaveArgs.visOpenHidden))

            ' Set active page
            Dim visioPage As Visio.Page = vdxApp.ActivePage

            ' Add a new rectangle shape
            ' Dim visioRectMaster As Visio.Master = visioStencil.Masters.get_ItemU("Rectangle")
            ' Dim visioRectShape As Visio.Shape = visioPage.Drop(visioRectMaster, 4.25, 5.5)
            ' visioRectShape.Text = "Rectangle text."

            ' Add a new star shape
            ' Dim visioStarMaster As Visio.Master = visioStencil.Masters.get_ItemU("Star 7")
            ' Dim visioStarShape As Visio.Shape = visioPage.Drop(visioStarMaster, 2.0, 5.5)
            ' visioStarShape.Text = "Star text."

            ' Add a new hexagon shape
            ' Dim visioHexagonMaster As Visio.Master = visioStencil.Masters.get_ItemU("Hexagon")
            ' Dim visioHexagonShape As Visio.Shape = visioPage.Drop(visioHexagonMaster, 7.0, 5.5)
            ' visioHexagonShape.Text = "Hexagon text."


            ' Save diagram as VDX
            vdxDoc.SaveAs(dataDir & Convert.ToString("CreatingDiagramWithVSTO_Out.vdx"))

        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.WriteLine("This example will only work if you apply a valid Aspose License. You can purchase full license or get 30 day temporary license from http://www.aspose.com/purchase/default.aspx.")
        End Try

    End Sub
End Class
