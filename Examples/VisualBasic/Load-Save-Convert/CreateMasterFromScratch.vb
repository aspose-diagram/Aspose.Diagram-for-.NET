Imports Aspose.Diagram
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports System

Public Class CreateMasterFromScratch
    ' ExStart:CreateMasterFromScratch
    Public Shared Sub Run()
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_LoadSaveConvert()

        ' Create a new template
        Dim diagram As New Diagram()
        ' Add master
        diagram.Masters.Add(CreateMaster(101, "Regular", dataDir & Convert.ToString("aspose-logo.jpg")))
        ' Save template
        diagram.Save(dataDir & Convert.ToString("CreateMasterFromScratch_out_.vtx"), SaveFileFormat.VTX)
    End Sub

    ' Create master
    Public Shared Function CreateMaster(masterId As Integer, name As String, masterImage As String) As Master
        ' Set master properties
        Dim master As New Master()
        master.ID = masterId
        master.Name = name
        master.IconSize = IconSizeValue.Normal
        master.AlignName = AlignNameValue.AlignTextCenter
        master.MatchByName = BOOL.[True]
        master.IconUpdate = BOOL.[True]
        master.UniqueID = Guid.NewGuid()
        master.BaseID = Guid.NewGuid()
        master.PatternFlags = 1
        master.Hidden = BOOL.[False]

        ' Set master's shape properties
        Dim shape As New Shape()
        master.Shapes.Add(shape)

        Dim width As Double = 0.544388926342418
        Dim height As Double = 0.432916947568133
        shape.ID = 5
        shape.Type = TypeValue.Foreign
        shape.XForm.PinX.Value = 0.222194463171209
        shape.XForm.PinY.Value = 0.166645847378406
        shape.XForm.Width.Value = width
        shape.XForm.Height.Value = height
        shape.XForm.LocPinX.Ufe.F = "Width*0.5"
        shape.XForm.LocPinY.Ufe.F = "Height*0.5"
        shape.XForm.ResizeMode.Value = 0
        shape.TextXForm.TxtPinY.Ufe.F = "-TxtHeight/2"
        shape.TextXForm.TxtWidth.Ufe.F = "TEXTWIDTH(TheText)"
        shape.TextXForm.TxtHeight.Ufe.F = "TEXTHEIGHT(TheText, TxtWidth)"

        ' Set connection properties
        Dim connection As New Connection()
        shape.Connections.Add(connection)

        connection.ID = 1
        connection.NameU = "All"
        connection.X.Value = 0.22
        connection.X.Ufe.F = "Width*0.5"
        connection.Y.Value = 0.16
        connection.Y.Ufe.F = "Height*0.5"
        connection.DirX.Value = 0
        connection.DirY.Value = 0
        connection.Type.Value = 0
        connection.AutoGen.Value = BOOL.[False]
        connection.Prompt.Ufe.F = "No Formula"

        shape.ForeignData.ForeignType = ForeignType.Bitmap
        shape.ForeignData.CompressionType = CompressionType.PNG
        shape.ForeignData.Value = ReadImageFile(masterImage)
        ' EncodedImage.getBytes();
        Return master
    End Function
    ' Get image bytes
    Public Shared Function ReadImageFile(imageLocation As String) As Byte()
        Dim imageData As Byte() = Nothing
        Dim fileInfo As New FileInfo(imageLocation)
        Dim imageFileLength As Long = fileInfo.Length
        Dim fs As New FileStream(imageLocation, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fs)
        imageData = br.ReadBytes(CInt(imageFileLength))
        Return imageData
    End Function
    ' ExEnd:CreateMasterFromScratch
End Class

