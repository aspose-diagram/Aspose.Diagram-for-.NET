﻿using Aspose.App.Diagram.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.App.Diagram.Processor
{
    public class ProcessDocument: DocumentModel
    {
        public bool ExistAttachment { get; set; }
        public List<string> Clilds{ get; set; }
    }
}
