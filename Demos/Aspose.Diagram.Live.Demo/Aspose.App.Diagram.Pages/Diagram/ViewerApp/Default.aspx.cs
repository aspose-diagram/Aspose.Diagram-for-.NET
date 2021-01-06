using Aspose.App.Diagram.Pages.Config;
using System;
using System.Web;
using System.Web.UI;

namespace Aspose.App.Diagram.Pages.ViewerApp
{
	public partial class Default : BasePage
	{
		public string fileName = "";
		public string downloadFileName = "";
		public string productName = "diagram";
		public string fileFormat = "";
		public string folderName = "";
		public string callbackURL = "";
        public string apiUrl = "";

        protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				fileName = Get("filename");

				if (!string.IsNullOrEmpty(fileName))
					downloadFileName = HttpUtility.UrlEncode(fileName);

				fileFormat = Get("fileformat");
				folderName = Get("foldername");
				callbackURL = Get("callbackURL");

                apiUrl = AppConfiguration.ApiUrl;
			}
		}

		private string Get(string key)
		{
			return Page.RouteData.Values[key]?.ToString() ?? Request.QueryString[key];
		}

		public string GetAppRoute(string appName)
		{
			return appName; //Resources.GetValueOrDefault($"{productName}Default{appName}Route");
		}
	}
}
