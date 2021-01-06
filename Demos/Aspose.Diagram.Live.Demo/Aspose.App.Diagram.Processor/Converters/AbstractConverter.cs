using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.App.Diagram.Infrastructure;
using Aspose.App.Diagram.Models.App;

namespace Aspose.App.Diagram.Processor
{
    public abstract class AbstractConverter : IConverter
    {
        protected abstract List<string> SaveDocument(Aspose.Diagram.Diagram diagram, SaveOpts saveOpts, string filePath);
        public List<ProcessDocument> Convert(ProcessorModel model)
        {
            var documents = new List<ProcessDocument>();
            foreach (var document in model.Documents)
            {
                Aspose.Diagram.Diagram diagram = DiagramFactory.Build(document.FilePath, model.SessionId); ;
                var documentResult = ConvertDocument(diagram, model, document.FileName);
                documents.Add(documentResult);
            }
            return documents;
        }

        public ProcessDocument Merge(ProcessorModel model)
        {
            var documents = new List<ProcessDocument>();
            Aspose.Diagram.Diagram diagram = DiagramFactory.Build(model.Documents[0].FilePath, model.SessionId);
            for (int index = 1; index < model.Documents.Count(); index++)
            {
                var diagramItem = DiagramFactory.Build(model.Documents[index].FilePath, model.SessionId);
                diagram.Combine(diagramItem);
            }
            var documentResult = ConvertDocument(diagram, model, "MergeDocument.vsdx");
            return documentResult;
        }

        private ProcessDocument ConvertDocument(Aspose.Diagram.Diagram diagram,ProcessorModel model, string documentFileName)
        {
        
            var existAttachment = false;
            var saveOpts = ConverterFactory.BuildSaveOpts(model.FileFormat);
            if (saveOpts.DiagramSaveFileFormat == Aspose.Diagram.SaveFileFormat.HTML)
            {
                existAttachment = true;
            }
            var fileName = Path.ChangeExtension(documentFileName, saveOpts.DiagramSaveFileFormat.ToString().ToLower());
            if (saveOpts.IsBridge)
            {
                fileName = Path.ChangeExtension(documentFileName, model.FileFormat.ToString().ToLower());
            }
            var directory = Path.Combine(model.ProcessorPath, Path.GetFileNameWithoutExtension(documentFileName)).Trim();
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            var filePath = Path.Combine(directory, fileName);
            var clilds = SaveDocument(diagram, saveOpts, filePath);
            return new ProcessDocument()
            {
                FileName = fileName,
                FilePath = filePath,
                ExistAttachment = existAttachment,
                Clilds = clilds,
            };
        }

       
    }
}
