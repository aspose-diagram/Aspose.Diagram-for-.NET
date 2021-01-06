using EditorHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.App.Diagram.Api.Models
{
    public class AppVsdxAdapter: AppVsdx
    {
        public AppVsdxAdapter(object[] pagesName, XMLModel[] images, XMLModel[] shapesXml, ModelsAttr[] modelsAttr, PageLayers[] pageLayers, string filename, string model, string currentFile) : base(pagesName, images, shapesXml, modelsAttr, pageLayers, filename, model, currentFile) {
        }

        public string format { get; set; }
    }
}