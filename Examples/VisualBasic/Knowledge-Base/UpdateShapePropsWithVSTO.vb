Imports System
Imports VisualBasic
Imports Visio = Microsoft.Office.Interop.Visio

Public Class UpdateShapePropsWithVSTO
    Public Shared Sub Run()
        'ExStart:UpdateShapePropsWithVSTO
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_KnowledgeBase()

        Dim vsdApp As Visio.Application = Nothing
        Dim vsdDoc As Visio.Document = Nothing
        Try
            'Create Visio Application Object
            vsdApp = New Visio.Application()

            'Make Visio Application Invisible
            vsdApp.Visible = False

            'Create a document object and load a diagram
            vsdDoc = vsdApp.Documents.Open(dataDir & Convert.ToString("Drawing1.vsd"))

            'Create page object to get required page
            Dim page As Visio.Page = vsdApp.ActivePage

            'Create shape object to get required shape
            Dim shape As Visio.Shape = page.Shapes("Process1")

            'Set shape text and text style
            shape.Text = "Hello World"
            shape.TextStyle = "CustomStyle1"

            'Set shape's position
            shape.get_Cells("PinX").ResultIU = 5
            shape.get_Cells("PinY").ResultIU = 5

            'Set shape's height and width
            shape.get_Cells("Height").ResultIU = 2
            shape.get_Cells("Width").ResultIU = 3

            'Save file as VDX
            vsdDoc.SaveAs(dataDir & Convert.ToString("Drawing1.vdx"))
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            'Close active document and quit
            vsdDoc.Close()
            vsdApp.Quit()
        End Try
        'ExEnd:UpdateShapePropsWithVSTO
    End Sub
End Class
