using Aspose.App.Diagram.Infrastructure;
using Aspose.App.Diagram.Pages.Models;
using Aspose.App.Diagram.Pages.Models.SEO;
using Aspose.App.Diagram.Pages.PageModels;
using Aspose.App.Diagram.Pages.PageResources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.App.Diagram.Pages.PageRenderers
{
    public class StructuralDataRenderer
    {
        public static List<string> GetJson(AppModel appModel,FileFormatInfo fileFormatInfo) {
            if (appModel.App == DiagramApps.Editor)
            {
                return null;
            }
            List<string> list = new List<string>();
            try
            {
                list.Add(PrepareJsonLdBreadcrumbList(appModel, fileFormatInfo));
                list.Add(PrepareJsonLdSoftware(appModel));
                list.Add(PrepareJsonLdHowTo(appModel));
            }
            catch (Exception ex)
            {
                NLogger.InternalServerError(ex);
            }

            return list;

        }

        private static string PrepareJsonLdBreadcrumbList(AppModel appModel, FileFormatInfo fileFormatInfo)
        {
            List<(string Name, string Href)> list = new List<(string Name, string Href)>();
            list.Add(("Aspose Product Family", "https://products.aspose.app/"));
            list.Add(("diagram", "https://products.aspose.app/diagram/family"));
            list.Add(($"{appModel.AppName}", "https://products.aspose.app/diagram/" + appModel.AppName));

            if (fileFormatInfo!=null&&(!string.IsNullOrEmpty(fileFormatInfo.SourceExtension)))
            {
                var add1 = fileFormatInfo.SourceExtension == null ? "" : fileFormatInfo.SourceExtension.ToUpper();
                var add2 = fileFormatInfo.DestinationExtension == null ? "" : fileFormatInfo.DestinationExtension.ToUpper();

                string name;
                switch (appModel.App)
                {
                    case DiagramApps.Conversion:
                        name = string.Format(AppXmlResource.GetResource($"{appModel.AppName}Breadcrumb"), add1, add2);
                        break;
                    case DiagramApps.Viewer:
                        name = $"View {add1}";
                        break;
                    case DiagramApps.Merger:
                        name = $"Merge {add1}";
                        break;
                    case DiagramApps.Editor:
                        name = $"Edit {add1}";
                        break;
                    default:
                        name = "Document";
                        break;
                }
                list.Add((name, "https://products.aspose.app" + fileFormatInfo.PathAndQuery));
            }
            return Breadcrumb.GenerateJson(list.ToArray());
        }

        private static string PrepareJsonLdSoftware(AppModel appModel)
        {
            SoftwareApplication obj = new SoftwareApplication()
            {
                Name = appModel.Title,
                Description = appModel.PageMetaDescription,
                SoftwareRequirements = new URL() { Id = "https://docs.aspose.com/display/diagramnet/System+Requirements" },
                SoftwareHelp = "https://docs.aspose.com/display/diagramnet/Home"
            };
            return JsonConvert.SerializeObject(obj);
        }

        private static string PrepareJsonLdHowTo(AppModel appModel)
        {
            HowTo obj = new HowTo(appModel.HowToModel, appModel.TitleSub, appModel.Title);
            return JsonConvert.SerializeObject(obj);
        }
    }
}