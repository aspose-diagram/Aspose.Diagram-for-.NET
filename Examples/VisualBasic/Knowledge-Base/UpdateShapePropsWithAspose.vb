Imports System
Imports Aspose.Diagram
Imports VisualBasic

Public Class UpdateShapePropsWithAspose
    Public Shared Sub Run()
        'ExStart:UpdateShapePropsWithAspose
        Try
            ' The path to the documents directory.
            Dim dataDir As String = RunExamples.GetDataDir_KnowledgeBase()

            'Save the uploaded file as PDF
            Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsd"))

            'Find a particular shape and update its properties
            For Each shape As Aspose.Diagram.Shape In diagram.Pages(0).Shapes
                If shape.Name.ToLower() = "process1" Then
                    shape.Text.Value.Clear()
                    shape.Text.Value.Add(New Txt("Hello World"))

                    'Find custom style sheet and set as shape's text style
                    For Each styleSheet As StyleSheet In diagram.StyleSheets
                        If styleSheet.Name = "CustomStyle1" Then
                            shape.TextStyle = styleSheet
                        End If
                    Next

                    'Set horizontal and vertical position of the shape
                    shape.XForm.PinX.Value = 5
                    shape.XForm.PinY.Value = 5

                    'Set height and width of the shape
                    shape.XForm.Height.Value = 2
                    shape.XForm.Width.Value = 3
                End If
            Next

            'Save shape as VDX
            diagram.Save(dataDir & Convert.ToString("UpdateShapePropsWithAspose_Out.vdx"), SaveFileFormat.VDX)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        'ExEnd:UpdateShapePropsWithAspose
    End Sub
End Class
