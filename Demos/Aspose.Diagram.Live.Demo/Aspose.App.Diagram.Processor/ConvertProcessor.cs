using Aspose.App.Diagram.Infrastructure;
using Aspose.App.Diagram.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.App.Diagram.Processor
{
    public class ConvertProcessor
    {
        public static DocumentModel Convert(ProcessorModel model)
        {
            try
            {
                if (model.Documents == null || model.Documents.Count() == 0)
                {
                    throw new AppException(model.SessionId, "The number of documents must be greater than 0");
                }
                IConverter converter = ConverterFactory.Build(model.FileFormat);
                var documents = converter.Convert(model);
                if (documents.Count == 1)
                {
                    if (documents.First().Clilds == null && (!documents.First().ExistAttachment))
                    {
                        return documents.First();
                    }
                }
                return ZipProcessor.Save(model.ProcessorPath, documents);
            }
            catch (Exception e) {
                throw e;
            }
        }

        public static DocumentModel Merge(ProcessorModel model)
        {
            try
            {
                if (model.Documents == null || model.Documents.Count() <= 1)
                {
                    throw new AppException(model.SessionId, "The number of documents must be greater than 1");
                }
                IConverter converter = ConverterFactory.Build(model.FileFormat);
                var document = converter.Merge(model);
                if (document.Clilds == null && (!document.ExistAttachment))
                {
                    return document;
                }
                return ZipProcessor.Save(model.ProcessorPath, document);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
