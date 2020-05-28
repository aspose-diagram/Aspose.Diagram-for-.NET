using Aspose.Diagram.Live.Demos.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aspose.Diagram.Live.Demos.UI.Controllers
{
	public class HomeController : BaseController
	{
	
		public override string Product => (string)RouteData.Values["productname"];
		

		

		public ActionResult Default()
		{
			ViewBag.PageTitle = "Apps, On Premise &amp; Cloud Solutions to Process Visio Drawings";
			ViewBag.MetaDescription = "Create, process &amp; convert Microsoft Visio drawings via On Premise APIs or Cloud-based SDKs. Or use our cross-platform apps to view or convert Visio files.";
			var model = new LandingPageModel(this);

			return View(model);
		}
	}
}
