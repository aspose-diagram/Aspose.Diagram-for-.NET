using Aspose.App.Diagram.Pages.Config;
using Aspose.App.Diagram.Pages.PageModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Aspose.App.Diagram.Pages.PageResources
{
    public class AppExtensionResource
    {
        private static Dictionary<string, FileFormat> resources = null;

        public static FileFormat GetResource(string key)
        {
            if (resources==null)
            {
                Initialize();
            }
            if (resources.ContainsKey(key))
            {
                return resources[key];
            }
            else {
                return null;
            }
        }

        private static void Initialize()
        {
            resources = new Dictionary<string, FileFormat>();
            resources = GetAllFromLocal();
        }

  
        public static Dictionary<string, FileFormat> GetAllFromLocal() {
            string jsonFilePath = HttpContext.Current.Server.MapPath("~/App_Data/extensions.json");
            using (StreamReader sr = new StreamReader(jsonFilePath)) {
                var json = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<Dictionary<string, FileFormat>>(json);
            }
        }
    }
}