using Aspose.Diagram.Live.Demos.UI.Models;
using System.Web.Http;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Linq;
using Aspose.Diagram;
using Aspose.Diagram.Saving;

namespace Aspose.Diagram.Live.Demos.UI.Models
{
	///<Summary>
	/// AsposeDiagramConversion class to convert page file to other format
	///</Summary>
	public class AsposeDiagramConversion : DiagramBase
	{
		///<Summary>
		/// Convert method
		///</Summary>
		private Response ProcessTask(string fileName, string folderName, string outFileExtension, bool createZip, bool checkNumberofPages, ActionDelegate action)
		{
			Aspose.Diagram.Live.Demos.UI.Models.License.SetAsposeDiagramLicense();
			return  Process(this.GetType().Name, fileName, folderName, outFileExtension, createZip, checkNumberofPages,  (new StackTrace()).GetFrame(5).GetMethod().Name, action);

		}
		///<Summary>
		/// ConvertDiagramToPdf method to convert diagram file to pdf
		///</Summary>
		public Response ConvertDiagramToPdf(string fileName, string folderName, string outputType)
		{
			return  ProcessTask(fileName, folderName, ".pdf", false, false, delegate (string inFilePath, string outPath, string zipOutFolder)
			{
				PdfSaveOptions pdfSaveOptions = new PdfSaveOptions();

				if (outputType == "pdfa_1b")
				{
					pdfSaveOptions.Compliance = PdfCompliance.PdfA1b;
				}
				else if (outputType == "pdfa_1a")
				{
					pdfSaveOptions.Compliance = PdfCompliance.PdfA1a;
				}
				else if (outputType == "pdf_15")
				{
					pdfSaveOptions.Compliance = PdfCompliance.Pdf15;
				}

				using (FileStream stream = new FileStream(inFilePath, FileMode.Open))
				{
					Aspose.Diagram.Diagram diagram = new Aspose.Diagram.Diagram(stream);
					diagram.Save(outPath, pdfSaveOptions);

					stream.Flush();
					stream.Close();
				}
			});
		}
		///<Summary>
		/// ConvertDiagramToHtml method to convert diagram file to html
		///</Summary>
		public Response ConvertDiagramToHtml(string fileName, string folderName)
		{
			return  ProcessTask(fileName, folderName, ".html", true, false, delegate (string inFilePath, string outPath, string zipOutFolder)
			{
				using (FileStream stream = new FileStream(inFilePath, FileMode.Open))
				{
					Aspose.Diagram.Diagram diagram = new Aspose.Diagram.Diagram(stream);
					diagram.Save(outPath, SaveFileFormat.HTML);

					stream.Flush();
					stream.Close();
				}


			});
		}
		///<Summary>
		/// ConvertDiagramToSingleImage method to convert diagram file to single image
		///</Summary>
		public Response ConvertDiagramToSingleImage(string fileName, string folderName, string outputType)
		{
			if (outputType.Equals("tiff") || outputType.Equals("xps") || outputType.Equals("svg"))
			{
				SaveFileFormat format = SaveFileFormat.TIFF;

				if (outputType.Equals("svg"))
				{
					format = SaveFileFormat.SVG;
				}
				else if (outputType.Equals("xps"))
				{
					format = SaveFileFormat.XPS;
				}

				return  ProcessTask(fileName, folderName, "." + outputType, false, false, delegate (string inFilePath, string outPath, string zipOutFolder)
				{
					using (FileStream stream = new FileStream(inFilePath, FileMode.Open))
					{
						Aspose.Diagram.Diagram diagram = new Aspose.Diagram.Diagram(stream);
						diagram.Save(outPath, format);

						stream.Flush();
						stream.Close();
					}
				});
			}

			return new Response
			{
				FileName = null,
				Status = "Output type not found",
				StatusCode = 500
			};
		}
		///<Summary>
		/// ConvertDiagramToSingleImage method to convert diagram file to images
		///</Summary>
		public Response ConvertDiagramToImages(string fileName, string folderName, string outputType)
		{
			if (outputType.Equals("bmp") || outputType.Equals("jpg") || outputType.Equals("png"))
			{
				ImageSaveOptions saveOptions = new ImageSaveOptions(SaveFileFormat.BMP);

				if (outputType.Equals("jpg"))
				{
					saveOptions = new ImageSaveOptions(SaveFileFormat.JPEG);
				}
				else if (outputType.Equals("png"))
				{
					saveOptions = new ImageSaveOptions(SaveFileFormat.PNG);
				}

				return  ProcessTask(fileName, folderName, "." + outputType, true, true, delegate (string inFilePath, string outPath, string zipOutFolder)
				{
					using (FileStream stream = new FileStream(inFilePath, FileMode.Open))
					{
						Aspose.Diagram.Diagram diagram = new Aspose.Diagram.Diagram(stream);

						string outfileName = "";

						if (diagram.Pages.Count > 1)
						{
							outfileName = Path.GetFileNameWithoutExtension(fileName) + "_{0}";
							for (int i = 0; i < diagram.Pages.Count; i++)
							{
								outPath = zipOutFolder + "/" + outfileName;
								saveOptions.PageIndex = i;

								diagram.Save(string.Format(outPath, (i + 1) + "." + outputType), saveOptions);
							}
						}
						else
						{
							outfileName = Path.GetFileNameWithoutExtension(fileName);
							outPath = zipOutFolder + "/" + outfileName;
							saveOptions.PageIndex = 0;

							diagram.Save(outPath + "." + outputType, saveOptions);


						}

						stream.Flush();
						stream.Close();
					}
				});
			}

			return new Response
			{
				FileName = null,
				Status = "Output type not found",
				StatusCode = 500
			};
		}
		///<Summary>
		/// ConvertFile
		///</Summary>
		public Response ConvertFile(string fileName, string folderName, string outputType)
		{
			outputType = outputType.ToLower();

			if (outputType.StartsWith("pdf"))
			{
				return  ConvertDiagramToPdf(fileName, folderName, outputType);
			}
			else if (outputType.Equals("html"))
			{
				return  ConvertDiagramToHtml(fileName, folderName);
			}
			else if (outputType.Equals("tiff") || outputType.Equals("xps") || outputType.Equals("svg"))
			{
				return  ConvertDiagramToSingleImage(fileName, folderName, outputType);
			}
			else if (outputType.Equals("bmp") || outputType.Equals("jpg") || outputType.Equals("png"))
			{
				return  ConvertDiagramToImages(fileName, folderName, outputType);
			}

			return new Response
			{
				FileName = null,
				Status = "Output type not found",
				StatusCode = 500
			};
		}

	}
	
}
