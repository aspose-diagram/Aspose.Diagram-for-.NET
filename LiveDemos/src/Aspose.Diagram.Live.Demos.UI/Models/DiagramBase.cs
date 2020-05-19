using Aspose.Diagram.Live.Demos.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Aspose.Diagram.Live.Demos.UI.Helpers;
using Aspose.Diagram.Live.Demos.UI.Services;
using Aspose.Diagram.Saving;
using Newtonsoft.Json.Linq;
using Path = System.IO.Path;


namespace Aspose.Diagram.Live.Demos.UI.Models
{
	///<Summary>
	/// DiagramBase class 
	///</Summary>

	public class DiagramBase : ModelBase
	{
		/// <summary>
		/// Maximum number of files which can be uploaded for MVC Aspose.Pdf apps
		/// </summary>
		protected static int MaximumUploadFiles = 10;

		/// <summary>
		/// Original file format SaveAs option for multiple files uploading. By default, "-"
		/// </summary>
		protected const string SaveAsOriginalName = ".-";

		/// <summary>
		/// Response when uploaded files exceed the limits
		/// </summary>
		protected Response MaximumFileLimitsResponse = new Response()
		{
			Status = $"Number of files should be equal or less {MaximumUploadFiles}",
			StatusCode = 500
		};
		protected Response PasswordProtectedResponse = new Response()
		{
			Status = "Some of your documents are password protected",
			StatusCode = 500
		};
		/// <summary>
		/// Response when uploaded files exceed the limits
		/// </summary>
		protected Response BadDocumentResponse = new Response()
		{
			Status = "Some of your documents are corrupted",
			StatusCode = 500
		};


		///<Summary>
		/// Aspose Diagram Options Class
		///</Summary>
		protected class Options
		{
			///<Summary>
			/// AppName
			///</Summary>
			public string AppName;

			///<Summary>
			/// FolderName
			///</Summary>
			public string FolderName;

			///<Summary>
			/// FileName
			///</Summary>
			public string FileName;

			private string _outputType;

			/// <summary>
			/// By default, it is the extension of FileName
			/// </summary>
			public string OutputType
			{
				get => _outputType;
				set
				{
					if (!value.StartsWith("."))
						value = "." + value;
					_outputType = value;
				}
			}

			/// <summary>
			/// Check if OuputType is a picture extension
			/// </summary>
			public bool IsPicture
			{
				get
				{
					switch (_outputType.ToLower())
					{
						case ".bmp":
						case ".emf":
						case ".png":
						case ".jpg":
						case ".jpeg":
						case ".gif":
						case ".tiff":
							return true;
						default:
							return false;
					}
				}
			}

			///<Summary>
			/// ResultFileName
			///</Summary>
			public string ResultFileName;

			///<Summary>
			/// MethodName
			///</Summary>
			public string MethodName;

			///<Summary>
			/// ModelName
			///</Summary>
			public string ModelName;

			///<Summary>
			/// CreateZip
			///</Summary>
			public bool CreateZip;

			///<Summary>
			/// CheckNumberOfPages
			///</Summary>
			public bool CheckNumberOfPages = false;

			///<Summary>
			/// DeleteSourceFolder
			///</Summary>
			public bool DeleteSourceFolder = false;

			///<Summary>
			/// CalculateZipFileName
			///</Summary>
			public bool CalculateZipFileName = true;

			/// <summary>
			/// Output zip filename (without '.zip'), if CreateZip property is true
			/// By default, FileName + AppName
			/// </summary>
			public string ZipFileName;

			/// <summary>
			/// AppSettings.WorkingDirectory + FolderName + "/" + FileName
			/// </summary>
			public string WorkingFileName
			{
				get
				{
					if (File.Exists(Config.Configuration.WorkingDirectory + FolderName + "/" + FileName))
						return Config.Configuration.WorkingDirectory + FolderName + "/" + FileName;
					return Config.Configuration.OutputDirectory + FolderName + "/" + FileName;
				}
			}
		}
		/// <summary>
		/// init Options
		/// </summary>
		protected Options Opts = new Options();

		/// <summary>
		/// UTF8WithoutBom
		/// </summary>
		protected static readonly Encoding UTF8WithoutBom = new UTF8Encoding(false);

		

		private object Lock1 = new object();
		private object Lock2 = new object();

		/// <summary>
		/// PageBase
		/// </summary>
		public DiagramBase()
		{
			
			Opts.ModelName = GetType().Name;
		}

		/// <summary>
		/// PageBase
		/// </summary>
		static DiagramBase()
		{
			Aspose.Diagram.Live.Demos.UI.Models.License.SetAsposeDiagramLicense();
			
		}



		/// <summary>
		/// Set default parameters into Opts
		/// </summary>
		/// <param name="docs"></param>
		protected void SetDefaultOptions(DocumentInfo[] docs,  string outputType)
		{
			if (docs.Length <= 0) return;
			SetDefaultOptions(Path.GetFileName(docs[0].FileName), outputType);
			Opts.CreateZip = docs.Length > 1 || Opts.IsPicture;
		}

		/// <summary>
		/// Set default parameters into Opts
		/// </summary>
		/// <param name="filename"></param>
		private void SetDefaultOptions(string filename, string outputType)
		{
			//Opts.FolderName = FolderName;
			Opts.ResultFileName = filename;
			Opts.FileName = Path.GetFileName(filename);

			//var query = Request.GetQueryNameValuePairs().ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);

			//if (query.ContainsKey("outputType"))
			//outputType = query["outputType"];
			Opts.OutputType = !string.IsNullOrEmpty(outputType)
			  ? outputType
			  : Path.GetExtension(Opts.FileName);

			Opts.ResultFileName = Opts.OutputType == SaveAsOriginalName
			  ? Opts.FileName
			  : Path.GetFileNameWithoutExtension(Opts.FileName) + Opts.OutputType;
		}


		/// <summary>
		/// Process
		/// </summary>
		protected Response Process(ActionDelegate action)
		{
			if (string.IsNullOrEmpty(Opts.OutputType))
				Opts.OutputType = Path.GetExtension(Opts.FileName);
			if (Opts.OutputType.ToLower() == ".html" || Opts.OutputType == ".SVG" || Opts.IsPicture)
				Opts.CreateZip = true;
			if (string.IsNullOrEmpty(Opts.ZipFileName) && Opts.CalculateZipFileName)
				Opts.ZipFileName = Path.GetFileNameWithoutExtension(Opts.FileName) + Opts.AppName;

			//Opts.OutputType = FilterOutType(Opts.OutputType);
			return Process(GetType().Name, Opts.ResultFileName, Opts.FolderName, Opts.OutputType, Opts.CreateZip,
				Opts.CheckNumberOfPages,
				Opts.MethodName, action,
				Opts.DeleteSourceFolder, Opts.ZipFileName);
		}
		/// <summary>
		/// SaveFormatType
		/// </summary>
		public class SaveInfo
		{
			/// <summary>
			/// SaveOptions
			/// </summary>
			public SaveOptions SaveOptions { get; set; }

			/// <summary>
			/// SaveType
			/// </summary>
			public SaveFileFormat SaveFileFormat { get; set; }
		}

		/// <summary>
		/// DocumentInfo
		/// </summary>
		public class DocumentInfo
		{
			/// <summary>
			/// FolderName
			/// </summary>
			public string FolderName { get; set; }

			/// <summary>
			/// FileName
			/// </summary>
			public string FileName { get; set; }

			/// <summary>
			/// Diagram
			/// </summary>
			public Aspose.Diagram.Diagram Diagram { get; set; }
		}
		/// <summary>
		/// Check if the OutputType is a picture and saves the document
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="outPath"></param>
		/// <param name="zipOutFolder"></param>
		/// <param name="saveOptions"></param>
		protected void SaveDocument(DocumentInfo doc, string outPath, string zipOutFolder, SaveInfo saveOptions)
		{
			string filename;
			if (Opts.CreateZip)
				filename = zipOutFolder + "/" +
						   (Opts.OutputType == SaveAsOriginalName
							   ? Path.GetFileName(doc.FileName)
							   : Path.GetFileNameWithoutExtension(doc.FileName) + Opts.OutputType);
			else
				filename = outPath;
			SaveDocument(doc, filename, saveOptions);
		}

		/// <summary>
		/// Check if the OutputType is a picture and saves the document
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="filename">The output full FileName</param>
		/// <param name="saveInfo"></param>
		protected void SaveDocument(DocumentInfo doc, string filename, SaveInfo saveInfo)
		{
			string outPath;
			var zipOutFolder = $"{Path.GetDirectoryName(filename)}\\{Path.GetFileNameWithoutExtension(filename)}";
			if (Opts.CreateZip)
				Directory.CreateDirectory(zipOutFolder);

			outPath = zipOutFolder;
			var extension = "." + saveInfo.SaveFileFormat.ToString().ToLower();

			if (saveInfo.SaveOptions != null)
			{
				doc.Diagram.Save(outPath + extension, saveInfo.SaveOptions);
			}
			else
			{
				var pageCount = doc.Diagram.Pages.Count;
				var outfileName = Path.GetFileNameWithoutExtension(doc.FileName) + "_{0}";

				switch (saveInfo.SaveFileFormat)
				{
					case SaveFileFormat.HTML:
					case SaveFileFormat.PDF:
					case SaveFileFormat.VSDX:
					case SaveFileFormat.VSX:
					case SaveFileFormat.VTX:
					case SaveFileFormat.VDX:
					case SaveFileFormat.VSSX:
					case SaveFileFormat.VSTX:
					case SaveFileFormat.VSDM:
					case SaveFileFormat.VSSM:
					case SaveFileFormat.VSTM:
					case SaveFileFormat.TIFF:
					case SaveFileFormat.XPS:
						var savePath = outPath + extension;
						doc.Diagram.Save(savePath, saveInfo.SaveFileFormat);
						break;
					case SaveFileFormat.JPEG:
					case SaveFileFormat.PNG:
					case SaveFileFormat.SVG:
					case SaveFileFormat.BMP:
					case SaveFileFormat.GIF:
					case SaveFileFormat.EMF:
						ImageSaveOptions opt = new ImageSaveOptions(saveInfo.SaveFileFormat);
						for (int index = 0; index < pageCount; index++)
						{
							var page = doc.Diagram.Pages[index];
							if (pageCount > 1)
							{
								outPath = zipOutFolder + "/" + outfileName;
								outPath = string.Format(outPath, page.Name + extension);
							}
							else
							{
								outPath = zipOutFolder + "/" + Path.GetFileNameWithoutExtension(doc.FileName) + extension;
							}
							opt.PageIndex = index;
							doc.Diagram.Save(outPath, opt);
						}
						break;
				}
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
		protected string CheckInputType(MultipartFormDataStreamProviderSafe uploadProvider, string _inputType)
		{
			if (uploadProvider.FileData[0] != null)
			{
				string inputFileName = uploadProvider.FileData[0].LocalFileName;
				string actualInputType = inputFileName.Substring(inputFileName.LastIndexOf('.') + 1);
				if (!_inputType.Equals(actualInputType))
					_inputType = actualInputType;
			}
			return _inputType;
		}	
		

		

		#region Common
		/// <summary>
		/// IsValidRegex
		/// </summary>
		public static bool IsValidRegex(string pattern)
		{
			if (string.IsNullOrEmpty(pattern))
				return false;
			try
			{
				Regex.Match("", pattern);
			}
			catch (ArgumentException)
			{
				return false;
			}
			return true;
		}

		

		
		#endregion
	}

	
}
