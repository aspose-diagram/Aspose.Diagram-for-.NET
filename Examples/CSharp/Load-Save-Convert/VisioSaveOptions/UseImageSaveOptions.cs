using Aspose.Diagram;
using Aspose.Diagram.Saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Load_Save_Convert.VisioSaveOptions
{
    public class UseImageSaveOptions
    {
        public static void Run()
        {
            // ExStart:UseImageSaveOptions
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();

            // Call the diagram constructor to a VSDX diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            ImageSaveOptions options = new ImageSaveOptions(SaveFileFormat.JPEG);
            // Specify the quality level to use during compositing.
            options.CompositingQuality = Aspose.Diagram.Saving.CompositingQuality.HighQuality;

            // Sets the brightness for the the generated images.
            // This property has effect only when saving to raster image formats.
            // The default value is 0.5. The value must be in the range between 0 and 1.
            options.ImageBrightness = 1f;

            // Summary:
            //     value or the font is not installed locally, they may appear as a block,
            //     set the DefaultFont such as MingLiu or MS Gothic to show these
            //     characters.
            options.DefaultFont = "MS Gothic";
            // Sets the number of pages to render in image.
            options.PageCount = 2;
            // Sets the 0-based index of the first page to render. Default is 0.
            options.PageIndex = 0;

            // Set page size
            PageSize pgSize = new PageSize(PaperSizeFormat.A1);
            options.PageSize = pgSize;
            // Discard saving background pages of the Visio diagram
            options.SaveForegroundPagesOnly = true;

            // Sets the color mode for the generated images.
            options.ImageColorMode = ImageColorMode.BlackAndWhite;

            // Sets the contrast for the generated images.
            // This property has effect only when saving to raster image formats.
            // The default value is 0.5. The value must be in the range between 0 and 1.
            options.ImageContrast = 1f;

            // Specify the algorithm that is used when images are scaled or rotated.
            // This property has effect only when saving to raster image formats.
            options.InterpolationMode = Aspose.Diagram.Saving.InterpolationMode.NearestNeighbor;

            // The value may vary from 0 to 100 where 0 means worst quality,
            // But maximum compression and 100 means best quality but minimum compression.
            // The default value is 95.
            options.JpegQuality = 100;

            // Set a value specifying how pixels are offset during rendering.
            options.PixelOffsetMode = Aspose.Diagram.Saving.PixelOffsetMode.HighSpeed;

            // Sets the resolution for the generated images, in dots per inch. The default value is 96.
            options.Resolution = 2f;

            // Sets the zoom factor for the generated images.
            // The default value is 1.0. The value must be greater than 0.
            options.Scale = 1f;

            // Specify whether smoothing (antialiasing) is applied to lines
            // And curves and the edges of filled areas.
            options.SmoothingMode = Aspose.Diagram.Saving.SmoothingMode.HighQuality;
            // Sets the type of compression to apply when saving generated images to the TIFF format.
            options.TiffCompression = TiffCompression.Ccitt3;

            // Save in any supported file format
            diagram.Save(dataDir + "UseImageSaveOptions_out.jpeg", options);
            // ExEnd:UseImageSaveOptions
        }
    }
}
