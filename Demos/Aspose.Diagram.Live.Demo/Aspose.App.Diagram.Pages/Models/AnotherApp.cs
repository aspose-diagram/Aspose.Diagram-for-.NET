using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aspose.App.Diagram.Pages.Config;

namespace Aspose.App.Diagram.Pages.Models
{
	public class AnotherApp
	{
		public string ImageSource { get; set; }
		public string ImageAlt { get; set; }
		public string AppName { get; set; }
		public string Href { get; set; }

		public AnotherApp()
		{
			// Empty for inheritance
		}

		public AnotherApp(string appName)
		{
			AppName = appName;
			Href = $"{appName.ToLower()}";
            ImageSource =$"https://www.aspose.cloud/templates/asposeapp/images/products/logo/aspose_{appName.ToLower()}-app.png";
			ImageAlt = $"{AppName}";
		}
	}
}
