Imports Aspose.Diagram
Imports System
Public Class SetConnectorAppearance
    Public Shared Sub Run()
        ' ExStart:SetConnectorAppearance
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' Call a Diagram class constructor to load the VSDX diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' Get a particular page
        Dim page As Page = diagram.Pages.GetPage("Page-3")
        ' Get a dynamic connector type shape by id
        Dim shape As Shape = page.Shapes.GetShape(18)
        ' Set dynamic connector appearance
        shape.SetConnectorsType(ConnectorsTypeValue.StraightLines)

        ' Saving Visio diagram
        diagram.Save(dataDir & Convert.ToString("SetConnectorAppearance_out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:SetConnectorAppearance
    End Sub
End Class
