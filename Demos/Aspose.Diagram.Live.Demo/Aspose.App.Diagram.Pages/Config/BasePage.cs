using Aspose.App.Diagram.Pages.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Aspose.App.Diagram.Pages.Config
{
	public class BasePage : Page
	{

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
		}

		protected string TitleCase(string value)
		{
			return new CultureInfo("en-US", false).TextInfo.ToTitleCase(value);
		}
	}
}
