using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_Geometry_Section
{
    public class EditConnectorGeometry
    {
        public static void Run() 
        {
            // ExStart:EditConnectorGeometry
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_GeometrySection();

            // load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            // Set connector shape by page name and ID
            long connectorId = 4;
            Shape connector = diagram.Pages.GetPage("Page-1").Shapes.GetShape(connectorId);
            // Get connector geometry at index 0
            LineTo defaultLineTo = connector.Geoms[0].CoordinateCol.LineToCol[0];
            // Remove connector geometry from index 0
            connector.Geoms[0].CoordinateCol.LineToCol[0].Del = BOOL.True;

            // Initialize LineTo geometry object
            LineTo lineTo = new LineTo();
            // Set X value
            lineTo.X.Value = 0;
            // Set Y value
            lineTo.Y.Value = defaultLineTo.Y.Value / 2;
            // Add connector geometry
            connector.Geoms[0].CoordinateCol.Add(lineTo);

            // Initialize LineTo geometry object
            lineTo = new LineTo();
            // Set Y value
            lineTo.Y.Value = defaultLineTo.Y.Value / 2;
            // Set X value
            lineTo.X.Value = defaultLineTo.X.Value;
            // Add connector geometry
            connector.Geoms[0].CoordinateCol.Add(lineTo);

            // Initialize LineTo geometry object
            lineTo = new LineTo();
            // Set X value
            lineTo.X.Value = defaultLineTo.X.Value;
            // Set Y value
            lineTo.Y.Value = defaultLineTo.Y.Value;
            // Add connector geometry
            connector.Geoms[0].CoordinateCol.Add(lineTo);

            // Save diagram in VDX format
            diagram.Save(dataDir + "EditConnectorGeometry_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:EditConnectorGeometry
         }
    }
}
