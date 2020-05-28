using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Http;


namespace Aspose.Diagram.Live.Demos.UI.Models
{

	public class AsposeDiagramMerger : DiagramBase
	{		
		public Response Merge( Diagram[] visioDocs, string outputType)
		{
			Aspose.Diagram.Live.Demos.UI.Models.License.SetAsposeDiagramLicense();		

			Aspose.Diagram.Diagram dgs = visioDocs[0];

			int iter = 0;
			foreach(var dg in visioDocs)
			{
				if (iter != 0)
				{
					dgs.Combine(dg);
				}
				iter++;
			}

			string folderName = Guid.NewGuid().ToString();
			string fileName = "Merged document." + outputType.ToLower();

			string strOutputFolder = Config.Configuration.OutputDirectory + folderName +"\\";
			System.IO.Directory.CreateDirectory(strOutputFolder);

			string outpath = strOutputFolder + fileName;

			if (outputType.ToLower() == "vsdm")
			{
				dgs.Save(outpath, Aspose.Diagram.SaveFileFormat.VSDM);
			}
			else
			{
				dgs.Save(outpath, Aspose.Diagram.SaveFileFormat.VSDX);
			}

			return new Response()
			{
				DownloadFileLink = outpath,
				FolderName=folderName,
				FileName =fileName,
				Status = "Ok",
				StatusCode = 200,
				FileProcessingErrorCode = FileProcessingErrorCode.OK
			};
		}
	}
}
