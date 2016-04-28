Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class EditConnectorGeometry
    Public Shared Sub Run()
        'ExStart:EditConnectorGeometry
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_GeometrySection()

        ' load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))
        'set connector shape by page name and ID
        Dim connectorId As Long = 4
        Dim connector As Shape = diagram.Pages.GetPage("Page-1").Shapes.GetShape(connectorId)
        'get connector geometry at index 0
        Dim defaultLineTo As LineTo = connector.Geoms(0).CoordinateCol.LineToCol(0)
        'remove connector geometry from index 0
        connector.Geoms(0).CoordinateCol.LineToCol(0).Del = BOOL.True

        'initialize LineTo geometry object
        Dim lineTo As New LineTo()
        'set X value
        lineTo.X.Value = 0
        'set Y value
        lineTo.Y.Value = defaultLineTo.Y.Value / 2
        'add connector geometry
        connector.Geoms(0).CoordinateCol.Add(lineTo)

        'initialize LineTo geometry object
        lineTo = New LineTo()
        'set Y value
        lineTo.Y.Value = defaultLineTo.Y.Value / 2
        'set X value
        lineTo.X.Value = defaultLineTo.X.Value
        'add connector geometry
        connector.Geoms(0).CoordinateCol.Add(lineTo)

        'initialize LineTo geometry object
        lineTo = New LineTo()
        'set X value
        lineTo.X.Value = defaultLineTo.X.Value
        'set Y value
        lineTo.Y.Value = defaultLineTo.Y.Value
        'add connector geometry
        connector.Geoms(0).CoordinateCol.Add(lineTo)

        'save diagram in VDX format
        diagram.Save(dataDir & Convert.ToString("EditConnectorGeometry_Out.vsdx"), SaveFileFormat.VDX)
        'ExEnd:EditConnectorGeometry
    End Sub
End Class
