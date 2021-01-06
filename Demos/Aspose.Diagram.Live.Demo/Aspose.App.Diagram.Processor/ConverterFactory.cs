using Aspose.App.Diagram.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.App.Diagram.Processor
{
    public class ConverterFactory
    {
        public static IConverter Build(ExportFileFormat fileFormat)
        {
            switch (fileFormat)
            {
                case ExportFileFormat.HTML:
                case ExportFileFormat.VSDX:
                case ExportFileFormat.VSX:
                case ExportFileFormat.VTX:
                case ExportFileFormat.VDX:
                case ExportFileFormat.VSSX:
                case ExportFileFormat.VSTX:
                case ExportFileFormat.VSDM:
                case ExportFileFormat.VSSM:
                case ExportFileFormat.VSTM:
                case ExportFileFormat.TIFF:
                case ExportFileFormat.XPS:
                case ExportFileFormat.PDF:
                    return new SimpleConverter();
                case ExportFileFormat.JPG:
                case ExportFileFormat.PNG:
                case ExportFileFormat.BMP:
                case ExportFileFormat.GIF:
                case ExportFileFormat.EMF:
                    return new ImageConverter();
                case ExportFileFormat.SVG:
                    return new SvgConverter();
                case ExportFileFormat.PPTX:
                case ExportFileFormat.DOCX:
                    return new PdfConverter();
                default:
                    return new SimpleConverter();
            }
        }

        public static SaveOpts BuildSaveOpts(ExportFileFormat fileFormat)
        {
            var saveOpts = new SaveOpts();
            switch (fileFormat)
            {
                case ExportFileFormat.HTML:
                    {
                        saveOpts.DiagramSaveFileFormat = Aspose.Diagram.SaveFileFormat.HTML;
                        break;
                    }
                case ExportFileFormat.VSDX:
                    {
                        saveOpts.DiagramSaveFileFormat = Aspose.Diagram.SaveFileFormat.VSDX;
                        break;
                    }
                case ExportFileFormat.VSX:
                    {
                        saveOpts.DiagramSaveFileFormat = Aspose.Diagram.SaveFileFormat.VSX;
                        break;
                    }
                case ExportFileFormat.VTX:
                    {
                        saveOpts.DiagramSaveFileFormat = Aspose.Diagram.SaveFileFormat.VTX;
                        break;
                    }
                case ExportFileFormat.VDX:
                    {
                        saveOpts.DiagramSaveFileFormat = Aspose.Diagram.SaveFileFormat.VDX;
                        break;
                    }
                case ExportFileFormat.VSSX:
                    {
                        saveOpts.DiagramSaveFileFormat = Aspose.Diagram.SaveFileFormat.VSSX;
                        break;
                    }
                case ExportFileFormat.VSTX:
                    {
                        saveOpts.DiagramSaveFileFormat = Aspose.Diagram.SaveFileFormat.VSTX;
                        break;
                    }
                case ExportFileFormat.VSDM:
                    {
                        saveOpts.DiagramSaveFileFormat = Aspose.Diagram.SaveFileFormat.VSDM;
                        break;
                    }
                case ExportFileFormat.VSSM:
                    {
                        saveOpts.DiagramSaveFileFormat = Aspose.Diagram.SaveFileFormat.VSSM;
                        break;
                    }
                case ExportFileFormat.VSTM:
                    {
                        saveOpts.DiagramSaveFileFormat = Aspose.Diagram.SaveFileFormat.VSTM;
                        break;
                    }
                case ExportFileFormat.TIFF:
                    {
                        saveOpts.DiagramSaveFileFormat = Aspose.Diagram.SaveFileFormat.TIFF;
                        break;
                    }
                case ExportFileFormat.XPS:
                    {
                        saveOpts.DiagramSaveFileFormat = Aspose.Diagram.SaveFileFormat.XPS;
                        break;
                    }
                case ExportFileFormat.PDF:
                    {
                        saveOpts.DiagramSaveFileFormat = Aspose.Diagram.SaveFileFormat.PDF;
                        break;
                    }
                case ExportFileFormat.JPG:
                    {
                        saveOpts.DiagramSaveFileFormat = Aspose.Diagram.SaveFileFormat.JPEG;
                        break;
                    }
                case ExportFileFormat.PNG:
                    {
                        saveOpts.DiagramSaveFileFormat = Aspose.Diagram.SaveFileFormat.PNG;
                        break;
                    }
                case ExportFileFormat.BMP:
                    {
                        saveOpts.DiagramSaveFileFormat = Aspose.Diagram.SaveFileFormat.BMP;
                        break;
                    }
                case ExportFileFormat.GIF:
                    {
                        saveOpts.DiagramSaveFileFormat = Aspose.Diagram.SaveFileFormat.GIF;
                        break;
                    }
                case ExportFileFormat.EMF:
                    {
                        saveOpts.DiagramSaveFileFormat = Aspose.Diagram.SaveFileFormat.EMF;
                        break;
                    }
                case ExportFileFormat.SVG:
                    {
                        saveOpts.DiagramSaveFileFormat = Aspose.Diagram.SaveFileFormat.SVG;
                        break;
                    }
                case ExportFileFormat.PPTX:
                    {
                        saveOpts.DiagramSaveFileFormat = Aspose.Diagram.SaveFileFormat.PDF;
                        saveOpts.IsBridge = true;
                        saveOpts.PdfSaveFileFormat = Pdf.SaveFormat.Pptx;
                        break;
                    }
                case ExportFileFormat.DOCX:
                    {
                        saveOpts.DiagramSaveFileFormat = Aspose.Diagram.SaveFileFormat.PDF;
                        saveOpts.IsBridge = true;
                        saveOpts.PdfSaveFileFormat = Pdf.SaveFormat.DocX;
                        break;
                    }
            }
            return saveOpts;
        }
    }
}
