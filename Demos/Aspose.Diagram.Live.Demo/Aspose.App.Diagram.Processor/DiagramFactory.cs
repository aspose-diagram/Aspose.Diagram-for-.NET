using Aspose.App.Diagram.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.App.Diagram.Processor
{
    public class DiagramFactory
    {
        public static Aspose.Diagram.Diagram Build(string path, string sessionId)
        {
            try
            {
                var diagram = new Aspose.Diagram.Diagram(path);
                return diagram;
            }
            catch (Exception e)
            {
                var msg = $"{Path.GetFileName(path)} is invalid file, please ensure that uploading correct file";
                throw new AppException(sessionId, msg);
            }
        }
    }
}
