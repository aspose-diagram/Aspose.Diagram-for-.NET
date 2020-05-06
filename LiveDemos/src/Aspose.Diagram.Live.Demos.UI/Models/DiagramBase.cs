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

		/// <summary>
		/// Response when uploaded files exceed the limits
		/// </summary>
		protected Response BadDocumentResponse = new Response()
		{
			Status = "Some of your documents are corrupted",
			StatusCode = 500
		};


		///<Summary>
		/// Options class 
		///</Summary>
		public class Options
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
			/// By default, it is the extension of FileName - e.g. ".docx"
			/// </summary>
			public string OutputType
			{
				get => _outputType;
				set
				{
					if (!value.StartsWith("."))
						value = "." + value;
					_outputType = value.ToLower();
				}
			}

			/// <summary>
			/// Check if OuputType is a picture extension
			/// </summary>
			public bool IsPicture
			{
				get
				{
					switch (_outputType)
					{
						case ".bmp":
						case ".png":
						case ".jpg":
						case ".jpeg":
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
			public string ResultFileName = "";

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
			public bool CreateZip = false;
			///<Summary>
			/// CheckNumberOfPages
			///</Summary>
			public bool CheckNumberOfPages = false;
			///<Summary>
			/// DeleteSourceFolder
			///</Summary>
			public bool DeleteSourceFolder = false;

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
					if (System.IO.File.Exists(Config.Configuration.WorkingDirectory + FolderName + "/" + FileName))
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
