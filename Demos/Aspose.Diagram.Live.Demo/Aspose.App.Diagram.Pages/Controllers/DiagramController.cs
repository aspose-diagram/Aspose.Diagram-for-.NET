using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Aspose.App.Diagram.Pages.Config;
using Aspose.App.Diagram.Pages.Models;
using Aspose.App.Diagram.Pages.PageModels;
using Aspose.App.Diagram.Pages.PageRenderers;

namespace Aspose.App.Diagram.Pages.Controllers
{

    public class DiagramController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Merger()
        {
            var fileFormatInfo = GetFileFormatInfo();
            var renderer = new AppRenderer();
            var model = renderer.GetAppModel(DiagramApps.Merger, fileFormatInfo);
            var isSupportedExt = fileFormatInfo == null ? true : isSupportedMergerExtensions(fileFormatInfo.RealSourceExtension, fileFormatInfo.RealDestinationExtension);
            if (!isSupportedExt)
            {
                return Redirect("/diagram/" + model.App.ToString().ToLower());
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Conversion()
        {
            var fileFormatInfo = GetFileFormatInfo();
            var renderer = new AppRenderer();
            var model = renderer.GetAppModel(DiagramApps.Conversion, fileFormatInfo);
            return View(model);
        }

        public ActionResult Viewer()
        {
            var fileFormatInfo = GetFileFormatInfo();
            var renderer = new AppRenderer();
            var model = renderer.GetAppModel(DiagramApps.Viewer, fileFormatInfo);
            return View(model);
        }

        public ActionResult Editor()
        {
            var fileFormatInfo = GetFileFormatInfo();
            var renderer = new AppRenderer();
            var model = renderer.GetAppModel(DiagramApps.Editor, fileFormatInfo);
            return View(model);
        }

        public ActionResult Error()
        {
            ViewBag.SaveAsComponent = false;
            return View();
        }
    }
}
