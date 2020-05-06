using Aspose.Diagram.Live.Demos.UI.Config;
using Aspose.Diagram.Live.Demos.UI.Models;
using Aspose.Diagram.Live.Demos.UI.Models.Common;
using Aspose.Diagram.Live.Demos.UI.Services;
using Aspose.Diagram.Live.Demos.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Aspose.Diagram;
using System.IO;

namespace Aspose.Diagram.Live.Demos.UI.Controllers
{
	public abstract class BaseController : Controller
	{
	
		/// <summary>
		/// Response when uploaded files exceed the limits
		/// </summary>
		protected Response BadDocumentResponse = new Response()
		{
			Status = "Some of your documents are corrupted",
			StatusCode = 500
		};
		

		public abstract string Product { get; }

		protected override void OnActionExecuted(ActionExecutedContext ctx)
		{
			base.OnActionExecuted(ctx);			
			ViewBag.Title = ViewBag.Title ?? Resources["ApplicationTitle"];
			ViewBag.MetaDescription = ViewBag.MetaDescription ?? "Save time and software maintenance costs by running single instance of software, but serving multiple tenants/websites. Customization available for Joomla, Wordpress, Discourse, Confluence and other popular applications.";
		}
		/// <summary>
		/// Prepare upload files and return as documents
		/// </summary>
		/// <param name="inputType"></param>
		protected InputFiles UploadFiles(HttpRequestBase Request)
		{
			try
			{
				string sourceFolder = Guid.NewGuid().ToString();
				var pathProcessor = new PathProcessor(sourceFolder);
				InputFiles documents = new InputFiles();
				
				for (int i = 0; i < Request.Files.Count; i++)
				{
					HttpPostedFileBase postedFile = Request.Files[i];

					if (postedFile != null)
					{
						// Check if File is available.
						if (postedFile != null && postedFile.ContentLength > 0)
						{
							string _fileName = postedFile.FileName;
							string _savepath = pathProcessor.SourceFolder + "\\" + System.IO.Path.GetFileName(_fileName);
							postedFile.SaveAs(_savepath);
							documents.Add(new InputFile(_fileName, sourceFolder ));
						}
					}
				}
				return documents;
			}			
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return null;
				
			}
		}
		protected Aspose.Diagram.Diagram[] UploadVisioDocs(HttpRequestBase Request)
		{
			try
			{
				string sourceFolder = Guid.NewGuid().ToString();
				var pathProcessor = new PathProcessor(sourceFolder);
				List< Aspose.Diagram.Diagram> documents = new List<Aspose.Diagram.Diagram> ();
				//foreach (string fileName in Request.Files)
				for (int i = 0; i < Request.Files.Count; i++)
				{
					HttpPostedFileBase postedFile = Request.Files[i];

					if (postedFile != null)
					{
						// Check if File is available.
						if (postedFile != null && postedFile.ContentLength > 0)
						{
							string _savepath = pathProcessor.SourceFolder + "\\" + System.IO.Path.GetFileName(postedFile.FileName);
							postedFile.SaveAs(_savepath);
							documents.Add(new Diagram(_savepath));
						}
					}
				}
				return documents.ToArray();
			}			
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return new Aspose.Diagram.Diagram[0];
			}
		}
		

		private AsposeDiagramContext _atcContext;
		

		/// <summary>
		/// Main context object to access all the dcContent specific context info
		/// </summary>
		public AsposeDiagramContext AsposeDiagramContext
		{
			get
			{
				if (_atcContext == null) _atcContext = new AsposeDiagramContext(HttpContext.ApplicationInstance.Context);
				return _atcContext;
			}
		}

		private Dictionary<string, string> _resources;

		/// <summary>
		/// key/value pair containing all the error messages defined in resources.xml file
		/// </summary>
		public Dictionary<string, string> Resources
		{
			get
			{
				if (_resources == null) _resources = AsposeDiagramContext.Resources;
				return _resources;
			}
		}

		

		
	}
}
