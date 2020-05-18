using Aspose.Diagram.Live.Demos.UI.Models.Common;
using Aspose.Diagram.Live.Demos.UI.Models;
using Aspose.Diagram.Live.Demos.UI.Services;
using System;
using System.Collections;
using System.Web;
using System.Web.Mvc;

namespace Aspose.Diagram.Live.Demos.UI.Controllers
{
	public class ConversionController : BaseController
	{
		public override string Product => (string)RouteData.Values["product"];
		
		[HttpPost]
		public Response Conversion(string outputType)
		{
			Response response = null;
			if (Request.Files.Count > 0)
			{
				
				var _diagrams = UploadFiles(Request);

				for (int i = 0; i < _diagrams.Count; i++)
				{
					AsposeDiagramConversion _asposeDiagramConversion = new AsposeDiagramConversion();
					response = _asposeDiagramConversion.ConvertFile(_diagrams[i].FileName, _diagrams[i].FolderName, outputType);
				}

			}

			return response;

		}

		

		public ActionResult Conversion()
		{
			var model = new ViewModel(this, "Conversion")
			{
				SaveAsComponent = true,
				SaveAsOriginal = false,
				MaximumUploadFiles = 1,
				DropOrUploadFileLabel = Resources["DropOrUploadFile"]
			};

			return View(model);
		}
		

	}
}
