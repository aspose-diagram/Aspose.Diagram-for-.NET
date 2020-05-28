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
				string _sourceFolder = Guid.NewGuid().ToString();
				var _diagrams = UploadDiagramFiles(Request, _sourceFolder);

				
				AsposeDiagramConversion _asposeDiagramConversion = new AsposeDiagramConversion();
				response = _asposeDiagramConversion.Convert(_diagrams, outputType.Trim());
				

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
