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
		public Response Convert(DocumentInfo[] docs, string outputType)
		{
			
			if (docs == null)
				return PasswordProtectedResponse;
			if (docs.Length == 0 || docs.Length > MaximumUploadFiles)
				return MaximumFileLimitsResponse;
			SetDefaultOptions(docs, outputType);
			Opts.AppName = "ConversionApp";
			Opts.MethodName = "Convert";
			Opts.ZipFileName = docs.Length > 1 ? "Converted documents" : Path.GetFileNameWithoutExtension(docs[0].FileName);

			var saveOpt = GetSaveOptions(outputType.Trim().ToLower());
			return  Process((inFilePath, outPath, zipOutFolder) =>
			{
				var tasks = docs.Select(doc =>
					Task.Factory.StartNew(() => SaveDocument(doc, outPath, zipOutFolder, saveOpt))).ToArray();
				Task.WaitAll(tasks);
			});
		}
		

	}
	
}
