using System.IO;
using Aspose.Diagram;
using Aspose.Diagram.Manipulation;

namespace Aspose.Diagram.Examples.CSharp.Diagrams
{
    public class AddConnectShapes
    {
        public static void Run()
        {
            // ExStart:AddConnectShapes
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_TechnicalArticles();

            // Set license (you can add 10 shapes without setting a license)
            // License lic = new License();
            // Lic.SetLicense(dataDir + "Aspose.Total.lic");

            // Load masters from any existing diagram, stencil or template
            // And add in the new diagram
            string visioStencil = dataDir + "AddConnectShapes.vss";

            // Names of the masters present in the stencil
            string rectangleMaster = @"Rectangle", starMaster = @"Star 7",
                hexagonMaster = @"Hexagon", connectorMaster = "Dynamic connector";

            int pageNumber = 0;
            double width = 2, height = 2, pinX = 4.25, pinY = 9.5;

            // Create a new diagram
            Diagram diagram = new Diagram(visioStencil);

            // Add a new rectangle shape
            long rectangleId = diagram.AddShape(
                pinX, pinY, width, height, rectangleMaster, pageNumber);

            // Set the new shape's properties
            Shape shape = diagram.Pages[pageNumber].Shapes.GetShape(rectangleId);
            shape.Text.Value.Add(new Txt(@"Rectangle text."));
            shape.Name = "Rectangle1";
            shape.XForm.LocPinX.Ufe.F = "Width*0.5";
            shape.XForm.LocPinY.Ufe.F = "Height*0.5";
            shape.Line.LineColor.Value = "7";
            shape.Line.LineWeight.Value = 0.03;
            shape.Fill.FillBkgnd.Value = "1";
            shape.Fill.FillForegnd.Value = "3";
            shape.Fill.FillPattern.Value = 31;

            // Add a new star shape
            pinX = 2.0;
            pinY = 4.5;
            long starId = diagram.AddShape(
                pinX, pinY, width, height, starMaster, pageNumber);

            // Set the star shape's properties
            shape = diagram.Pages[pageNumber].Shapes.GetShape(starId);
            shape.Text.Value.Add(new Txt(@"Star text."));
            shape.Name = "Star1";
            shape.XForm.LocPinX.Ufe.F = "Width*0.5";
            shape.XForm.LocPinY.Ufe.F = "Height*0.5";
            shape.Line.LineColor.Value = "#ff0000";
            shape.Line.LineWeight.Value = 0.03;
            shape.Fill.FillBkgnd.Value = "#ff00ff";
            shape.Fill.FillForegnd.Value = "#0000ff";
            shape.Fill.FillPattern.Value = 31;

            // Add a new hexagon shape
            pinX = 7.0;
            long hexagonId = diagram.AddShape(
                pinX, pinY, width, height, hexagonMaster, pageNumber);

            // Set the hexagon shape's properties
            shape = diagram.Pages[pageNumber].Shapes.GetShape(hexagonId);
            shape.Text.Value.Add(new Txt(@"Hexagon text."));
            shape.Name = "Hexagon1";
            shape.XForm.LocPinX.Ufe.F = "Width*0.5";
            shape.XForm.LocPinY.Ufe.F = "Height*0.5";
            shape.Line.LineWeight.Value = 0.03;
            shape.Fill.FillPattern.Value = 31;

            // Add master to dynamic connector from the stencil
            diagram.AddMaster(visioStencil, connectorMaster);

            // Connect rectangle and star shapes
            Shape connector1 = new Shape();
            long connecter1Id = diagram.AddShape(connector1, connectorMaster, 0);
            diagram.Pages[0].ConnectShapesViaConnector(rectangleId, ConnectionPointPlace.Bottom,
                starId, ConnectionPointPlace.Top, connecter1Id);

            // Connect rectangle and hexagon shapes
            Shape connector2 = new Shape();
            long connecter2Id = diagram.AddShape(connector2, connectorMaster, 0);
            diagram.Pages[0].ConnectShapesViaConnector(rectangleId, ConnectionPointPlace.Bottom,
                hexagonId, ConnectionPointPlace.Left, connecter2Id);

            // Save the diagram
            diagram.Save(dataDir + "AddConnectShapes_out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:AddConnectShapes
        }
    }
}