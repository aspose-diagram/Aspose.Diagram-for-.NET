using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Aspose.App.Diagram.Pages.PageModels
{
    public class JSOptionsModel
    {
        #region FileDrop
        public bool Multiple { get; set; }
        public string DropFilesPrompt { get; set; }
        public string Accept { get; set; }
        public bool CanWorkWithoutFiles { get; set; }
        public bool DefaultFileBlockDisabled { get; set; }
        public string[] UploadOptions { get; set; }
        #endregion

        public string AppURL { get; set; }
        public string AppName { get; set; }
        public string AppRoute { get; set; }

        public string APIBasePath { get; set; }
        public string UIBasePath { get; set; }

        public string ViewerPathWF { get; set; }

        public string EditorPathWF { get; set; }

        public bool ShowViewerButton { get; set; }
        public int MaximumUploadFiles { get; set; }

        public string FileAmountMessage { get; set; }

        public string FileSelectMessage { get; set; }

        public bool UploadAndRedirect { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }
}