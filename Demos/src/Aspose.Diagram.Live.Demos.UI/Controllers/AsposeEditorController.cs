using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using Aspose.Diagram.Live.Demos.UI.Models;
using Newtonsoft.Json;
using Aspose.Diagram.Live.Demos.UI.Helpers;
using File = System.IO.File;
using EditorHandler.Results;
using Aspose.Diagram.Saving;
using EditorHandler.Models;
using EditorHandler.Vsdx;
using static Aspose.Diagram.Live.Demos.UI.Models.DiagramBase;

namespace Aspose.Diagram.Live.Demos.UI.Controllers
{
	///<Summary>
	/// AsposeViewerController class to get document page
	///</Summary>
	public class AsposeEditorController : ApiController
	{
        private VsdxService _service = new VsdxService();
        private VsdxZip _zip = new VsdxZip();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Import")]
        public Result Import()
        {
            var sessionId = Guid.NewGuid().ToString();
            var file = HttpContext.Current.Request.Files[0];
            var filePath = CreateTempFile(file.FileName, sessionId);
            file.SaveAs(filePath);
            return ImportFile(filePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Open")]
        public Result Open([FromBody]FileInfoRequest fileInfo)
        {

            var filePath = GetTempFile(fileInfo.FolderName, System.Web.HttpUtility.UrlDecode(fileInfo.FileName));
            return ImportFile(filePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appVsdx"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Export")]
        public HttpResponseMessage Export([FromBody]AppVsdx appVsdx)
        {
            var sessionId = Guid.NewGuid().ToString();
            var fileNameWithOutExtension = Path.GetFileNameWithoutExtension(appVsdx.filename);
            var filePath = CreateTempFile(fileNameWithOutExtension + ".vsdx", sessionId);
            string outputType = "";

            var fileDirectory = Path.GetDirectoryName(filePath);
            var outPath = "";
            using (FileStream stream = File.Create(filePath))
            {
                _service.fileName = appVsdx.filename.Split('.')[0];
                _service.addPagesXML(appVsdx.pagesName, appVsdx.images, appVsdx.pageLayers, appVsdx.modelsAttr, appVsdx.pagesXml);
                _service.createVsdxSkeleton(appVsdx.pagesName);
                _service.Zip(_service.fileName, stream);

                outputType = Path.GetExtension(appVsdx.filename).Replace(".", "");
                outPath = ConvertDoc(appVsdx.filename, fileNameWithOutExtension, filePath, fileDirectory, outputType);
                HttpResponseMessage response = new HttpResponseMessage();
                response.Content = new StreamContent(File.OpenRead(outPath));
                response.Content.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                response.Content.Headers.ContentDisposition.FileName = System.Web.HttpUtility.UrlEncode(Path.GetFileName(outPath), System.Text.Encoding.UTF8);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                return response;
            }
        }

        private string ConvertDoc(string fileName, string fileNameWithOutExtension, string filePath, string fileDirectory, string outputType)
        {
            string outPath;
            var saveOpt = GetSaveOptions(outputType.Trim().ToLower());
            var diagram = new Aspose.Diagram.Diagram(filePath);
            if ((diagram.Pages.Count > 1 && IsImage(outputType)) || saveOpt.SaveFileFormat == Aspose.Diagram.SaveFileFormat.HTML)
            {
                var zipOutFolder = Path.Combine(fileDirectory, fileNameWithOutExtension).TrimEnd();
                var zipOutPath = zipOutFolder + ".zip";
                Directory.CreateDirectory(zipOutFolder);
                if (saveOpt.SaveFileFormat == Aspose.Diagram.SaveFileFormat.HTML)
                {
                    diagram.Save(Path.Combine(zipOutFolder, fileName), saveOpt.SaveFileFormat);
                }
                else
                {
                    for (int index = 0; index < diagram.Pages.Count; index++)
                    {
                        if (saveOpt.SaveFileFormat == Aspose.Diagram.SaveFileFormat.SVG)
                        {
                            SVGSaveOptions opt = new SVGSaveOptions();
                            opt.PageIndex = index;
                            diagram.Save(Path.Combine(zipOutFolder, diagram.Pages[index].Name + "." + outputType), opt);
                        }
                        else
                        {
                            ImageSaveOptions opt = new ImageSaveOptions(saveOpt.SaveFileFormat);
                            opt.PageIndex = index;
                            diagram.Save(Path.Combine(zipOutFolder, diagram.Pages[index].Name + "." + outputType), opt);
                        }
                    }
                }
                ZipFile.CreateFromDirectory(zipOutFolder, zipOutPath);
                Directory.Delete(zipOutFolder, true);
                outPath = zipOutPath;
            }
            else
            {
                outPath = Path.Combine(fileDirectory, fileName);
                diagram.Save(outPath, saveOpt.SaveFileFormat);
            }

            return outPath;
        }

        private Result ImportFile(string filePath)
        {
            string xml = "";
            if (Path.GetExtension(filePath) != ".vsdx")
            {
                Aspose.Diagram.Diagram diagram = new Aspose.Diagram.Diagram(filePath);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    diagram.Save(memoryStream, Aspose.Diagram.SaveFileFormat.VSDX);
                    memoryStream.Position = 0;
                    xml = _zip.ReadXml(memoryStream);
                }
            }
            else
            {
                using (Stream stream = File.OpenRead(filePath))
                {
                    xml = _zip.ReadXml(stream);
                }
            }
            return ResultFactory.buildSuccessResult("Success", xml);
        }


        private string CreateTempFile(string fileName, string sessionId)
        {
            var fileDirectory = Path.Combine(Config.Configuration.WorkingDirectory, sessionId);
            Directory.CreateDirectory(fileDirectory);
            var filePath = Path.Combine(fileDirectory, fileName);
            return filePath;

        }



        private string GetTempFile(string folderName, string fileName)
        {
            return Path.Combine(Config.Configuration.WorkingDirectory, folderName, fileName);
        }

        private bool IsImage(string format)
        {
            switch (format.ToLower())
            {
                case "bmp":
                case "emf":
                case "png":
                case "jpg":
                case "jpeg":
                case "gif":
                case "tiff":
                case "svg":
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
		/// GetSaveOptions
		/// </summary>
		/// <param name="outputType"></param>
		/// <returns></returns>
		protected SaveInfo GetSaveOptions(string outputType)
        {
            var saveFormatInfo = new SaveInfo { SaveOptions = null };
            switch (outputType)
            {
                case "pdf":
                    {
                        saveFormatInfo.SaveFileFormat = SaveFileFormat.PDF;
                        saveFormatInfo.SaveOptions = new PdfSaveOptions();
                        break;
                    }
                case "pdfa_1a":
                    {
                        saveFormatInfo.SaveFileFormat = SaveFileFormat.PDF;
                        PdfSaveOptions pdfSaveOptions = new PdfSaveOptions();
                        pdfSaveOptions.Compliance = PdfCompliance.PdfA1a;
                        saveFormatInfo.SaveOptions = pdfSaveOptions;
                        break;
                    }
                case "pdfa_1b":
                    {
                        saveFormatInfo.SaveFileFormat = SaveFileFormat.PDF;
                        PdfSaveOptions pdfSaveOptions = new PdfSaveOptions();
                        pdfSaveOptions.Compliance = PdfCompliance.PdfA1b;
                        saveFormatInfo.SaveOptions = pdfSaveOptions;
                        break;
                    }
                case "pdf_15":
                    {
                        saveFormatInfo.SaveFileFormat = SaveFileFormat.PDF;
                        PdfSaveOptions pdfSaveOptions = new PdfSaveOptions();
                        pdfSaveOptions.Compliance = PdfCompliance.Pdf15;
                        saveFormatInfo.SaveOptions = pdfSaveOptions;
                        break;
                    }
                case "html":
                    {
                        saveFormatInfo.SaveFileFormat = SaveFileFormat.HTML;
                        saveFormatInfo.SaveOptions = new HTMLSaveOptions();
                        break;
                    }
                case "jpg":
                    {
                        saveFormatInfo.SaveFileFormat = SaveFileFormat.JPEG;
                        break;
                    }
                case "png":
                    {
                        saveFormatInfo.SaveFileFormat = SaveFileFormat.PNG;
                        break;
                    }
                case "bmp":
                    {
                        saveFormatInfo.SaveFileFormat = SaveFileFormat.BMP;
                        break;
                    }
                case "svg":
                    {
                        saveFormatInfo.SaveFileFormat = SaveFileFormat.SVG;
                        break;
                    }
                case "tiff":
                    {
                        saveFormatInfo.SaveFileFormat = SaveFileFormat.TIFF;
                        break;
                    }
                case "xps":
                    {
                        saveFormatInfo.SaveFileFormat = SaveFileFormat.XPS;
                        break;
                    }
                case "gif":
                    {
                        saveFormatInfo.SaveFileFormat = SaveFileFormat.GIF;
                        break;
                    }
                case "emf":
                    {
                        saveFormatInfo.SaveFileFormat = SaveFileFormat.EMF;
                        break;
                    }
                case "vsdx":
                    {
                        saveFormatInfo.SaveFileFormat = SaveFileFormat.VSDX;
                        break;
                    }
                case "vsx":
                    {
                        saveFormatInfo.SaveFileFormat = SaveFileFormat.VSX;
                        break;
                    }
                case "vtx":
                    {
                        saveFormatInfo.SaveFileFormat = SaveFileFormat.VTX;
                        break;
                    }
                case "vdx":
                    {
                        saveFormatInfo.SaveFileFormat = SaveFileFormat.VDX;
                        break;
                    }
                case "vssx":
                    {
                        saveFormatInfo.SaveFileFormat = SaveFileFormat.VSSX;
                        break;
                    }
                case "vstx":
                    {
                        saveFormatInfo.SaveFileFormat = SaveFileFormat.VSTX;
                        break;
                    }
                case "vsdm":
                    {
                        saveFormatInfo.SaveFileFormat = SaveFileFormat.VSDM;
                        break;
                    }
                case "vssm":
                    {
                        saveFormatInfo.SaveFileFormat = SaveFileFormat.VSSM;
                        break;
                    }
                case "vstm":
                    {
                        saveFormatInfo.SaveFileFormat = SaveFileFormat.VSTM;
                        break;
                    }
                default:
                    throw new Exception("Invalid file format");
            }
            return saveFormatInfo;
        }
    }

    public class FileInfoRequest
    {
        public string FileName { get; set; }
        public string FolderName { get; set; }
    }
}
