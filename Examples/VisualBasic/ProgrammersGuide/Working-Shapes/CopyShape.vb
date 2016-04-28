Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class CopyShape
    Public Shared Sub Run()
        'ExStart:CopyShape
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' load a source Visio
        Dim srcVisio As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' initialize a new Visio
        Dim newDiagram As New Diagram()

        ' add all masters from the source Visio diagram
        Dim originalMasters As MasterCollection = srcVisio.Masters
        For Each master As Master In originalMasters
            newDiagram.AddMaster(srcVisio, master.Name)
        Next

        ' get the page object from the original diagram
        Dim SrcPage As Aspose.Diagram.Page = srcVisio.Pages.GetPage("Page-1")
        ' copy themes from the source diagram
        newDiagram.CopyTheme(srcVisio)
        ' copy pagesheet of the source Visio page
        newDiagram.Pages(0).PageSheet.Copy(SrcPage.PageSheet)

        ' copy shapes from the source Visio page
        For Each shape As Aspose.Diagram.Shape In SrcPage.Shapes
            newDiagram.Pages(0).Shapes.Add(shape)
        Next
        ' save the new Visio
        newDiagram.Save(dataDir & Convert.ToString("CopyShapes_Out.vsdx"), SaveFileFormat.VSDX)
        'ExEnd:CopyShape
    End Sub
End Class
