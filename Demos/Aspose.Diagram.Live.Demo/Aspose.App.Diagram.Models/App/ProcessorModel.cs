using Aspose.App.Diagram.Infrastructure;
using Aspose.App.Diagram.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.App.Diagram.Models.App
{
    public class ProcessorModel : BaseModel
    {
        public ProcessorModel() {
        }
        public ProcessorModel(string sessionId, string outputType, DocumentModel document, string processorPath) 
            : this(sessionId, outputType, new DocumentModel[] { document }, processorPath)
        {
        }

        public ProcessorModel(string sessionId, string outputType, DocumentModel[] documents,string processorPath)
        {
            SessionId = sessionId;
            this.Documents = documents;
            this.ProcessorPath = processorPath;
            ExportFileFormat fileFormat;
            if (Enum.TryParse(outputType.ToUpper(), out fileFormat))
            {
                this.FileFormat = fileFormat;
            }
            else
            {
                throw new AppException(sessionId, "Invalid file format");
            }
        }
        public string ProcessorPath { get; set; }
        public ExportFileFormat FileFormat { get; set; }
        public DocumentModel[] Documents { get; set; }
    }
}
