
Imports Aspose.Diagram
Imports System

Public Class EditConnectorGeometry
    Public Shared Sub Run()
        ' ExStart:EditConnectorGeometry
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_GeometrySection()

        ' Load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        ' Set connector shape by page name and ID
        Dim connectorId As Long = 4
        Dim connector As Shape = diagram.Pages.GetPage("Page-1").Shapes.GetShape(connectorId)
        ' Get connector geometry at index 0
        Dim defaultLineTo As LineTo = connector.Geoms(0).CoordinateCol.LineToCol(0)
        'remove connector geometry from index 0
        connector.Geoms(0).CoordinateCol.LineToCol(0).Del = BOOL.True

        ' Initialize LineTo geometry object
        Dim lineTo As New LineTo()
        ' Set X value
        lineTo.X.Value = 0
        ' Set Y value
        lineTo.Y.Value = defaultLineTo.Y.Value / 2
        ' Add connector geometry
        connector.Geoms(0).CoordinateCol.Add(lineTo)

        ' Initialize LineTo geometry object
        lineTo = New LineTo()
        ' Set Y value
        lineTo.Y.Value = defaultLineTo.Y.Value / 2
        ' Set X value
        lineTo.X.Value = defaultLineTo.X.Value
        ' Add connector geometry
        connector.Geoms(0).CoordinateCol.Add(lineTo)

        ' Initialize LineTo geometry object
        lineTo = New LineTo()
        ' Set X value
        lineTo.X.Value = defaultLineTo.X.Value
        ' Set Y value
        lineTo.Y.Value = defaultLineTo.Y.Value
        ' Add connector geometry
        connector.Geoms(0).CoordinateCol.Add(lineTo)

        ' Save diagram in VDX format
        diagram.Save(dataDir & Convert.ToString("EditConnectorGeometry_Out.vsdx"), SaveFileFormat.VDX)
        ' ExEnd:EditConnectorGeometry
    End Sub
End Class
