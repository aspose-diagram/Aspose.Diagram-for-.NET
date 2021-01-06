using Aspose.App.Diagram.Pages.PageResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.App.Diagram.Pages.PageRenderers
{
    public class ResourceAdapter
    {
        public string this[string key]
        {
            get
            {
                return AppXmlResource.GetResource(key);
            }
        }

    }
}