Imports VisualBasic
Imports Aspose.Diagram
Imports System

Public Class GetShapeIcon
    Public Shared Sub Run()
        'ExStart:GetShapeIcon
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Shapes()

        ' Load stencil file to a diagram object
        Dim stencil As New Diagram(dataDir & Convert.ToString("Timeline.vss"))
        ' get master
        Dim master As Master = stencil.Masters.GetMaster(1)

        Using stream As New System.IO.MemoryStream(master.Icon)
            ' Load memory stream into bitmap object
            Dim bitmap As New System.Drawing.Bitmap(stream)
            ' save as png format
            bitmap.Save(dataDir & Convert.ToString("MasterIcon_Out.png"), System.Drawing.Imaging.ImageFormat.Png)
        End Using
        'ExEnd:GetShapeIcon
    End Sub
End Class
