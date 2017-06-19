using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.OS_Fonts_Location
{
    class HandleDocumentWarnings : IWarningCallback
    {
        /**
     * Our callback only needs to implement the "Warning" method. This method is
     * called whenever there is a potential issue during document processing.
     * The callback can be set to listen for warnings generated during document
     * load and/or document save.
     */
        public void Warning(WarningInfo info)
        {
            // We are only interested in fonts being substituted.
            if (info.WarningType == WarningType.FontSubstitution)
            {
                Console.WriteLine("Font substitution: " + info.Description);
            }
        }
    }
}