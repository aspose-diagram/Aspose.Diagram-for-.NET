Imports Aspose.Diagram
Imports System.IO
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System
Imports Aspose.Diagram.ActiveXControls
Public Class RetrieveActiveXControl
    Public Shared Sub Run()
        ' ExStart:RetrieveActiveXControl
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_VisioActiveXControls()
        ' Load and get a Visio page by name
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsd"))
        Dim page As Page = diagram.Pages.GetPage("Page-1")
        ' Get a shape by ID
        Dim shape As Shape = page.Shapes.GetShape(1)
        ' Get an ActiveX control
        Dim cbac As CommandButtonActiveXControl = DirectCast(shape.ActiveXControl, CommandButtonActiveXControl)
        ' Set width, height and caption of the command button control
        cbac.Width = 4
        cbac.Height = 4
        cbac.Caption = "Test Button"
        ' Save diagram
        diagram.Save(dataDir & Convert.ToString("RetrieveActiveXControl_out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:RetrieveActiveXControl
    End Sub
End Class

