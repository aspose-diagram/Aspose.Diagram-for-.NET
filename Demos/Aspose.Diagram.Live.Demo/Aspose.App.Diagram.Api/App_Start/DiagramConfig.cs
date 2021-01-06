using Aspose.App.Diagram.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.App.Diagram.Api
{
    public class DiagramConfig
    {
        public static void RegisterGlobalDiagram()
        {
            SetAsposeDiagramLicense();
            SetAsposePdfLicense();
            SetAsposeDiagramFontFolder();
        }

        private static void SetAsposeDiagramLicense()
        {
            Aspose.Diagram.License lic = new Aspose.Diagram.License();
            //lic.SetLicense("Aspose.Total.lic");
        }

        /// <summary>
        /// Set Aspose Pdf License
        /// </summary>
        private static void SetAsposePdfLicense()
        {
            Aspose.Pdf.License lic = new Aspose.Pdf.License();
            //lic.SetLicense("Aspose.Total.lic");
        }

        private static void SetAsposeDiagramFontFolder()
        {
            Aspose.Diagram.FontConfigs.SetFontFolder(AppConfig.FontRootDirectory, true);
        }

    }
}