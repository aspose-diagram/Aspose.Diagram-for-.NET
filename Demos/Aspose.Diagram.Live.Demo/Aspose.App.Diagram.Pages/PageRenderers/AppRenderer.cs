using Aspose.App.Diagram.Pages.Config;
using Aspose.App.Diagram.Pages.Models;
using Aspose.App.Diagram.Pages.PageModels;
using Aspose.App.Diagram.Pages.PageResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Aspose.App.Diagram.Pages.PageRenderers
{
    public class AppRenderer
    {
        private FileFormatInfo fileFormatInfo;
        private string appName;
        private string appURL;
        private DiagramApps app;
        private const string VISIO = "Visio";
        private static string[] LoadFormats = new string[] { "vsd", "vsdx", "vsx", "vtx", "vdx", "vssx", "vstx", "vsdm", "vssm", "vstm" };
        private static string[] SaveFormats = new string[] { "pdf", "html", "jpg", "png", "svg", "bmp", "tiff", "xps", "gif", "emf", "vsdx", "vsx", "vtx", "vdx", "vssx", "vstx", "vsdm", "vssm", "vstm", "pptx", "docx" };


        public AppModel GetAppModel(DiagramApps app, FileFormatInfo fileFormat)
        {
            this.app = app;
            appName = app.ToString();
            appURL = AppConfiguration.PageUrl + appName;
            fileFormatInfo = fileFormat;
            AppModel model = new AppModel();
            model.App = app;
            model.AppURL = appURL;
            model.AppName = appName;
            model.Title = GetAppResourceFromExtension("Title");
            model.TitleSub = GetAppResourceFromExtension("TitleSub");
            model.PageTitle = GetAppResourceFromExtension("PageTitle");
            model.PageMetaDescription = GetAppResourceFromExtension("MetaDescription");
            model.CanonicalModel = GetCanonicalModel();
            model.ExtensionModel = GetExtensionModel();
            model.HowToModel = GetHowToModel();
            model.OtherApps = GetOtherApps();
            model.OtherFeaturesModel = GetOtherFeaturesModel();
            model.OverviewModel = GetOverviewModel();
            model.SaveAsOptions = GetSaveAsOptions();
            model.UploadAndRedirect = GetIsUploadAndRedirect();
            model.JSOptions = GetJSOptionsModel(model);
            model.StructuralDataJson = StructuralDataRenderer.GetJson(model, fileFormat);
            return model;
        }


        private JSOptionsModel GetJSOptionsModel(AppModel appModel)
        {
            var model = new JSOptionsModel() {
                Accept = ".vsd,.vsdx,.vsx,.vtx,.vdx,.vssx,.vstx,.vsdm,.vssm,.vstm",
                AppURL = appModel.AppURL,
                AppName = appModel.App.ToString(),
                APIBasePath = AppConfiguration.ApiUrl,
                UIBasePath = AppConfiguration.PageUrl,
                ViewerPathWF = AppConfiguration.PageUrl + "view/",
                EditorPathWF = AppConfiguration.PageUrl + "edit/",
                Multiple = !appModel.UploadAndRedirect,
                FileSelectMessage = AppXmlResource.GetResource("FileSelectMessage"),
                DropFilesPrompt= appModel.UploadAndRedirect? AppXmlResource.GetResource("DropOrUploadFile"): AppXmlResource.GetResource("DropOrUploadFiles"),
                MaximumUploadFiles=10,
                UploadAndRedirect=appModel.UploadAndRedirect,
                FileAmountMessage = "Please select less than ten files",
                UploadOptions=new string[] { "VSD", "VSDX", "VSX", "VTX", "VDX", "VSSX", "VSTX", "VSDM", "VSSM", "VSTM" },
            };
            return model;
        }

        private List<string> GetSaveAsOptions()
        {
            var saveOpts = SaveFormats.Select(x => x.ToUpper()).ToList();
            if (fileFormatInfo != null && fileFormatInfo.DestinationExtension != null)
            {
                saveOpts.Remove(fileFormatInfo.RealDestinationExtension.ToUpper());
                saveOpts.Insert(0, fileFormatInfo.RealDestinationExtension.ToUpper());
            }
            return saveOpts;
        }

        private bool GetIsUploadAndRedirect()
        {
            switch (app)
            {
                case DiagramApps.Conversion:
                case DiagramApps.Merger:
                   return false;
                case DiagramApps.Editor:
                case DiagramApps.Viewer:
                    return true;
                default:
                    return false;
            }

        }

        private OverviewModel GetOverviewModel()
        {
            var model= new OverviewModel()
            {
                OverviewTitle = fileFormatInfo == null ? VISIO +" "+ appName : fileFormatInfo.SourceExtension+" " + appName,
                RawHtmlOverview =FormatOrDefault("RawHtmlOverview")
            };
            var appFeatures = new List<string>();

            var i = 1;
            while (AppXmlResource.ContainsKey($"{appName}LiFeature{i}"))
                appFeatures.Add(AppXmlResource.GetResource($"{appName}LiFeature{i++}"));

            model.AppFeatures = appFeatures;
            return model;
        }

        private OtherFeaturesModel GetOtherFeaturesModel()
        {
            var model = new OtherFeaturesModel();

            model.Title = GetAppResourceFromApp("OtherFeaturesTitle");
            model.TitleSub = GetAppResourceFromApp("OtherFeaturesTitleSub");
           
            var items = new List<OtherFeaturesItem>();

            switch (app)
            {
                case DiagramApps.Conversion:
                    foreach (var item in SaveFormats)
                    {
                        var title = $"{VISIO} to {item}";
                        var url = $"{appURL}/{VISIO}-to-{item}";
                        items.Add(new OtherFeaturesItem(url, title, item));
                    }
                    break;
                case DiagramApps.Viewer:
                    foreach (var item in LoadFormats)
                    {
                        var title = $"View {item}";
                        var url = $"{appURL}/{item}";
                        items.Add(new OtherFeaturesItem(url, title, item));
                    }
                    break;
                case DiagramApps.Merger:
                    foreach (var item in LoadFormats)
                    {
                        var title = $"Merge {item}";
                        var url = $"{appURL}/{item}";
                        items.Add(new OtherFeaturesItem(url, title, item));
                    }
                    break;
                case DiagramApps.Editor:
                    foreach (var item in LoadFormats)
                    {
                        var title = $"Edit {item}";
                        var url = $"{appURL}/{item}";
                        items.Add(new OtherFeaturesItem(url, title, item));
                    }
                    break;
                default:
                    break;
            }

            model.Items = items;
            return model;
        }

        private List<AnotherApp> GetOtherApps()
        {
            var apps = new List<AnotherApp>();

            foreach (var appName in Enum.GetNames(typeof(DiagramApps)))
                apps.Add(new AnotherApp(appName));

            return apps;
        }

        private PageModels.HowToModel GetHowToModel()
        {
            if (app == DiagramApps.Editor)
            {
                return null;
            }
            var extension = VISIO;
            if (fileFormatInfo != null && fileFormatInfo.SourceExtension != null)
            {
                extension = fileFormatInfo.SourceExtension;
            }
            var model = new HowToModel();
            model.Title = string.Format(GetAppResourceFromApp("HowtoTitle"), extension);
            var items = new List<HowToItem>();
            var i = 1;
            while (AppXmlResource.ContainsKey($"{appName}HowtoFeature{i}"))
            {
                items.Add(new HowToItem()
                {
                    Name = string.Format(AppXmlResource.GetResource($"{appName}HowtoNameFeature{i}"), extension),
                    Text = string.Format(AppXmlResource.GetResource($"{appName}HowtoFeature{i}"), extension),
                    ImageUrl = string.Format(AppXmlResource.GetResource($"{appName}HowtoImageUrlFeature{i}"), extension),
                    UrlPath = string.Format(AppXmlResource.GetResource($"{appName}HowtoUrlPathFeature{i}"), extension),
                });
                i++;
            }
            model.List = items;
            return model;
        }

        private ExtensionModel GetExtensionModel()
        {
            if (fileFormatInfo == null)
            {
                return null;
            }
            var model = new ExtensionModel();
            if (fileFormatInfo.SourceExtension != null)
            {
                model.Extension = fileFormatInfo.SourceExtension;
                var SourceFileFormat = AppExtensionResource.GetResource(fileFormatInfo.RealSourceExtension);
                if (SourceFileFormat == null) {
                    return null;
                }
                model.ExtensionInfoModel = new FileFormatModel(SourceFileFormat);
            }

            if (fileFormatInfo.DestinationExtension != null)
            {
                model.Extension2 = fileFormatInfo.DestinationExtension;
                var DestinationFileFormat = AppExtensionResource.GetResource(fileFormatInfo.RealDestinationExtension);
                if (DestinationFileFormat == null)
                {
                    return null;
                }
                model.ExtensionInfoModel2 = new FileFormatModel(DestinationFileFormat);
            }

            if (model.Extension2 == null)
            {
                model.ShowExtensionInfo2 = false;
            }
            else
            {
                model.ShowExtensionInfo2 = true;
            }
            return model;
        }

        private CanonicalModel GetCanonicalModel()
        {
            var model = new CanonicalModel() {
                PoweredBy = AppXmlResource.GetResource("PoweredBy"),
                Feature1= GetAppResourceFromApp("Feature1"),
                Feature1Description= GetAppResourceFromApp("Feature1Description"),
                Feature2 = GetAppResourceFromApp("Feature2"),
                Feature2Description = GetAppResourceFromApp("Feature2Description"),
                Feature3 = GetAppResourceFromApp("Feature3"),
                Feature3Description = AppXmlResource.GetResource("Feature3Description"),
            };
            return model;
        }

        private string FormatOrDefault(string key)
        {
            var content = GetAppResourceFromApp(key);
            var extension = VISIO;
            if (fileFormatInfo != null)
            {
                extension = fileFormatInfo.SourceExtension;
            }
            return string.Format(content, extension);
        }

        private string GetAppResourceFromApp(string key) {
            return AppXmlResource.GetResource(appName + key);
        }
        private string GetAppResourceFromExtension(string key)
        {
            if (fileFormatInfo == null)
            {
                return GetAppResourceFromApp(key);
            }
            else
            {
                if (fileFormatInfo.DestinationExtension == null)
                {
                    return string.Format(AppXmlResource.GetResource(appName + key + "1"), fileFormatInfo.SourceExtension.ToUpper());
                }
                else
                {
                    return string.Format(AppXmlResource.GetResource(appName + key + "2"), fileFormatInfo.SourceExtension.ToUpper(), fileFormatInfo.DestinationExtension.ToUpper());
                }
            }
        }

        
    }
}