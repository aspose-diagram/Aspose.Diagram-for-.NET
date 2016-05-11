using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_with_Geometry_Section
{
    public class EditConnectorGeometry
    {
        public static void Run() 
        {
            //ExStart:EditConnectorGeometry
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_GeometrySection();

            // load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");
            //set connector shape by page name and ID
            long connectorId = 4;
            Shape connector = diagram.Pages.GetPage("Page-1").Shapes.GetShape(connectorId);
            //get connector geometry at index 0
            LineTo defaultLineTo = connector.Geoms[0].CoordinateCol.LineToCol[0];
            //remove connector geometry from index 0
            connector.Geoms[0].CoordinateCol.LineToCol[0].Del = BOOL.True;

            //initialize LineTo geometry object
            LineTo lineTo = new LineTo();
            //set X value
            lineTo.X.Value = 0;
            //set Y value
            lineTo.Y.Value = defaultLineTo.Y.Value / 2;
            //add connector geometry
            connector.Geoms[0].CoordinateCol.Add(lineTo);

            //initialize LineTo geometry object
            lineTo = new LineTo();
            //set Y value
            lineTo.Y.Value = defaultLineTo.Y.Value / 2;
            //set X value
            lineTo.X.Value = defaultLineTo.X.Value;
            //add connector geometry
            connector.Geoms[0].CoordinateCol.Add(lineTo);

            //initialize LineTo geometry object
            lineTo = new LineTo();
            //set X value
            lineTo.X.Value = defaultLineTo.X.Value;
            //set Y value
            lineTo.Y.Value = defaultLineTo.Y.Value;
            //add connector geometry
            connector.Geoms[0].CoordinateCol.Add(lineTo);

            //save diagram in VDX format
            diagram.Save(dataDir + "EditConnectorGeometry_Out.vsdx", SaveFileFormat.VSDX);
            //ExEnd:EditConnectorGeometry
         }
    }
}
