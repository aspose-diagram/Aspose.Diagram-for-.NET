using Aspose.App.Diagram.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.App.Diagram.Processor
{
    public interface IConverter
    {
        List<ProcessDocument> Convert(ProcessorModel model);

        ProcessDocument Merge(ProcessorModel model);
    }
}
