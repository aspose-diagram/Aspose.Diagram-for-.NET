
Imports System
Imports System.Collections
Imports Aspose.Diagram

Public Class SaveVisioShapeInOtherFormats
    Public Shared Sub Run()
        ' ExStart:SaveVisioShapeInOtherFormats
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' call a Diagram class constructor to load the VSDX diagram
        Dim srcVisio As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        Dim shapeWidth As Double = 0
        Dim shapeHeight As Double = 0

        ' get Visio page
        Dim srcPage As Aspose.Diagram.Page = srcVisio.Pages.GetPage("Page-3")
        ' remove background page
        srcPage.BackPage = Nothing

        ' get hash table of shapes, it holds id and name
        Dim remShapes As New Hashtable()
        ' Hashtable<Long, String> remShapes = new Hashtable<Long, String>();
        For Each shape As Aspose.Diagram.Shape In srcPage.Shapes
            ' for the normal shape
            remShapes.Add(shape.ID, shape.Name)
        Next

        ' iterate through the hash table
        For Each shapeEntry As DictionaryEntry In remShapes
            Dim key As Long = CLng(shapeEntry.Key)
            Dim val As String = DirectCast(shapeEntry.Value, String)
            Dim shape As Aspose.Diagram.Shape = srcPage.Shapes.GetShape(key)
            ' check of the shape name
            If val.Equals("GroupShape1") Then
                ' move shape to the origin corner
                shapeWidth = shape.XForm.Width.Value
                shapeHeight = shape.XForm.Height.Value
                shape.MoveTo(shapeWidth * 0.5, shapeHeight * 0.5)
                ' trim page size
                srcPage.PageSheet.PageProps.PageWidth.Value = shapeWidth
                srcPage.PageSheet.PageProps.PageHeight.Value = shapeHeight
            Else
                ' remove shape from the Visio page and hash table
                srcPage.Shapes.Remove(shape)
            End If
        Next
        remShapes.Clear()

        ' specify saving options
        Dim opts As New Aspose.Diagram.Saving.PdfSaveOptions()
        ' set page count to save
        opts.PageCount = 1
        ' set starting index of the page
        opts.PageIndex = 1
        ' save it
        srcVisio.Save(dataDir & Convert.ToString("SaveVisioShapeInOtherFormats_Out.pdf"), opts)
        ' ExEnd:SaveVisioShapeInOtherFormats
    End Sub
End Class
