using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.ApplyLicense
{
    public class ApplyLicenseByPath
    {
        public static void Run() 
        {
            // ExStart:ApplyLicenseByPath
            // set path of the license file, i.e. c:\temp\
            string dataDir = @"c:\temp\";

            License license = new License();
            license.SetLicense(dataDir + "Aspose.Diagram.lic");
            // ExEnd:ApplyLicenseByPath
        }
    }
}
