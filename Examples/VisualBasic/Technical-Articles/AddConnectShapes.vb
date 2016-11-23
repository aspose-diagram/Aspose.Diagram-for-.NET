Imports Microsoft.VisualBasic
Imports System.IO
Imports Aspose.Diagram
Imports Aspose.Diagram.Manipulation

Namespace Diagrams
    Public Class AddConnectShapes
        Public Shared Sub Run()
            ' ExStart:AddConnectShapes
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_TechnicalArticles()

            ' Set license (you can add 10 shapes without setting a license)
            ' License lic = new License();
            ' Lic.SetLicense(dataDir + "Aspose.Total.lic");

            ' Load masters from any existing diagram, stencil or template
            ' And add in the new diagram
            Dim visioStencil As String = dataDir & "AddConnectShapes.vss"

            ' Names of the masters present in the stencil
            Dim rectangleMaster As String = "Rectangle", starMaster As String = "Star 7", hexagonMaster As String = "Hexagon", connectorMaster As String = "Dynamic connector"

            Dim pageNumber As Integer = 0
            Dim width As Double = 2, height As Double = 2, pinX As Double = 4.25, pinY As Double = 9.5

            ' Create a new diagram
            Dim diagram As New Diagram(visioStencil)

            ' Add a new rectangle shape
            Dim rectangleId As Long = diagram.AddShape(pinX, pinY, width, height, rectangleMaster, pageNumber)

            ' Set the new shape's properties
            Dim shape As Shape = diagram.Pages(pageNumber).Shapes.GetShape(rectangleId)
            shape.Text.Value.Add(New Txt("Rectangle text."))
            shape.Name = "Rectangle1"
            shape.XForm.LocPinX.Ufe.F = "Width*0.5"
            shape.XForm.LocPinY.Ufe.F = "Height*0.5"
            shape.Line.LineColor.Value = "7"
            shape.Line.LineWeight.Value = 0.03
            shape.Fill.FillBkgnd.Value = "1"
            shape.Fill.FillForegnd.Value = "3"
            shape.Fill.FillPattern.Value = 31

            ' Add a new star shape
            pinX = 2.0
            pinY = 4.5
            Dim starId As Long = diagram.AddShape(pinX, pinY, width, height, starMaster, pageNumber)

            ' Set the star shape' S properties
            shape = diagram.Pages(pageNumber).Shapes.GetShape(starId)
            shape.Text.Value.Add(New Txt("Star text."))
            shape.Name = "Star1"
            shape.XForm.LocPinX.Ufe.F = "Width*0.5"
            shape.XForm.LocPinY.Ufe.F = "Height*0.5"
            shape.Line.LineColor.Value = "#ff0000"
            shape.Line.LineWeight.Value = 0.03
            shape.Fill.FillBkgnd.Value = "#ff00ff"
            shape.Fill.FillForegnd.Value = "#0000ff"
            shape.Fill.FillPattern.Value = 31

            ' Add a new hexagon shape
            pinX = 7.0
            Dim hexagonId As Long = diagram.AddShape(pinX, pinY, width, height, hexagonMaster, pageNumber)

            ' Set the hexagon shape' S properties
            shape = diagram.Pages(pageNumber).Shapes.GetShape(hexagonId)
            shape.Text.Value.Add(New Txt("Hexagon text."))
            shape.Name = "Hexagon1"
            shape.XForm.LocPinX.Ufe.F = "Width*0.5"
            shape.XForm.LocPinY.Ufe.F = "Height*0.5"
            shape.Line.LineWeight.Value = 0.03
            shape.Fill.FillPattern.Value = 31

            ' Add master to dynamic connector from the stencil
            diagram.AddMaster(visioStencil, connectorMaster)

            ' Connect rectangle and star shapes
            Dim connector1 As New Shape()
            Dim connecter1Id As Long = diagram.AddShape(connector1, connectorMaster, 0)
            diagram.Pages(0).ConnectShapesViaConnector(rectangleId, ConnectionPointPlace.Bottom, starId, ConnectionPointPlace.Top, connecter1Id)

            ' Connect rectangle and hexagon shapes
            Dim connector2 As New Shape()
            Dim connecter2Id As Long = diagram.AddShape(connector2, connectorMaster, 0)
            diagram.Pages(0).ConnectShapesViaConnector(rectangleId, ConnectionPointPlace.Bottom, hexagonId, ConnectionPointPlace.Left, connecter2Id)

            ' Save the diagram
            diagram.Save(dataDir & "AddConnectShapes_out.vsdx", SaveFileFormat.VSDX)
            ' ExEnd:AddConnectShapes
        End Sub
    End Class
End Namespace