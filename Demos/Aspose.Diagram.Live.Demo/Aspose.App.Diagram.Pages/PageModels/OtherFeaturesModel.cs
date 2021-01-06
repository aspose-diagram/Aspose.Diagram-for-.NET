using Aspose.App.Diagram.Infrastructure;
using Aspose.App.Diagram.Pages.PageResources;
using System;
using System.Collections.Generic;

namespace Aspose.App.Diagram.Pages.PageModels
{
    public class OtherFeaturesModel
    {
        public string Title { get; set; }
        public string TitleSub { get; set; }

        public List<OtherFeaturesItem> Items { get; set; }
    }


    public class OtherFeaturesItem
    {
        /// <summary>
        /// Url for anchor
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// TitleSub
        /// </summary>
        public string TitleSub { get; set; }

        public OtherFeaturesItem(string url, string title, string format)
        {
            URL = url.ToLower();
            Title = title.ToUpper();
            var fileFormat = AppExtensionResource.GetResource(format);
            if (fileFormat == null)
            {
                TitleSub = Title;
            }
            else
            {
                TitleSub = fileFormat.name;
            }
        }
    }
}
