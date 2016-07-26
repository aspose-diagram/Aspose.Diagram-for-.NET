Imports Aspose.Diagram.Saving
Imports System

Imports Aspose.Diagram

Public Class UseImageSaveOptions
    Public Shared Sub Run()
        ' ExStart:UseImageSaveOptions
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_LoadSaveConvert()

        ' call the diagram constructor to a VSDX diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        Dim options As New ImageSaveOptions(SaveFileFormat.JPEG)
        ' specify the quality level to use during compositing.
        options.CompositingQuality = Aspose.Diagram.Saving.CompositingQuality.HighQuality

        ' sets the brightness for the the generated images.
        ' this property has effect only when saving to raster image formats.
        ' The default value is 0.5. The value must be in the range between 0 and 1.
        options.ImageBrightness = 1.0F

        ' Summary:
        '     value or the font is not installed locally, they may appear as a block,
        '     set the DefaultFont such as MingLiu or MS Gothic to show these
        '     characters.
        options.DefaultFont = "MS Gothic"
        ' sets the number of pages to render in image.
        options.PageCount = 2
        ' sets the 0-based index of the first page to render. Default is 0.
        options.PageIndex = 0

        ' set page size
        Dim pgSize As New PageSize(PaperSizeFormat.A1)
        options.PageSize = pgSize
        ' discard saving background pages of the Visio diagram
        options.SaveForegroundPagesOnly = True

        ' sets the color mode for the generated images.
        options.ImageColorMode = ImageColorMode.BlackAndWhite

        ' sets the contrast for the generated images.
        ' this property has effect only when saving to raster image formats.
        ' the default value is 0.5. The value must be in the range between 0 and 1.
        options.ImageContrast = 1.0F

        ' specify the algorithm that is used when images are scaled or rotated.
        ' this property has effect only when saving to raster image formats.
        options.InterpolationMode = Aspose.Diagram.Saving.InterpolationMode.NearestNeighbor

        ' the value may vary from 0 to 100 where 0 means worst quality,
        ' but maximum compression and 100 means best quality but minimum compression.
        ' the default value is 95.
        options.JpegQuality = 100

        ' set a value specifying how pixels are offset during rendering.
        options.PixelOffsetMode = Aspose.Diagram.Saving.PixelOffsetMode.HighSpeed

        ' sets the resolution for the generated images, in dots per inch. The default value is 96.
        options.Resolution = 2.0F

        ' sets the zoom factor for the generated images.
        ' the default value is 1.0. The value must be greater than 0.
        options.Scale = 1.0F

        ' specify whether smoothing (antialiasing) is applied to lines
        ' and curves and the edges of filled areas.
        options.SmoothingMode = Aspose.Diagram.Saving.SmoothingMode.HighQuality
        ' sets the type of compression to apply when saving generated images to the TIFF format.
        options.TiffCompression = TiffCompression.Ccitt3

        ' save in any supported file format
        diagram.Save(dataDir & Convert.ToString("UseImageSaveOptions_Out.jpeg"), options)
        ' ExEnd:UseImageSaveOptions
    End Sub
End Class
