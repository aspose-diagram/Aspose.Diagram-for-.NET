using Aspose.App.Diagram.Models.App;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.App.Diagram.Processor
{
    public class ZipProcessor
    {
        const string ZIP_NAME = "documents.zip";
        public static DocumentModel Save(string rootPath, ProcessDocument document)
        {
            return Save(rootPath, new List<ProcessDocument> { document });
        }

        public static DocumentModel Save(string rootPath, List<ProcessDocument> documents)
        {
            if (documents.Count > 1)
            {
                string zipPath = Path.Combine(new DirectoryInfo(rootPath).Parent.FullName, ZIP_NAME);
                ZipFile.CreateFromDirectory(rootPath, zipPath);
                return new DocumentModel()
                {
                    FileName = ZIP_NAME,
                    FilePath = zipPath,
                };
            }
            else
            {
                string sourceDirectory = Path.GetDirectoryName(documents.First().FilePath);
                string zipName = Path.ChangeExtension(documents.First().FileName, "zip");
                DirectoryInfo directory = new DirectoryInfo(sourceDirectory);
                string zipPath = Path.Combine(directory.Parent.FullName, zipName);
                ZipFile.CreateFromDirectory(sourceDirectory, zipPath);
                return new DocumentModel()
                {
                    FileName = zipName,
                    FilePath = zipPath,
                };
            }
        }
    }
}
