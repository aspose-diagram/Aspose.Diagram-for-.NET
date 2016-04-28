using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharp.ApplyLicense
{
    public class ApplyLicenseUsingFileStream
    {
        public static void Run()
        {
            //ExStart:ApplyLicenseUsingFileStream
            // set path of the license file, i.e. c:\temp\
            string dataDir = @"c:\temp\";
            // load an existing Visio file in the stream
            FileStream LicStream = new FileStream(dataDir + "Aspose.Diagram.lic", FileMode.Open);

            License license = new License();
            license.SetLicense(LicStream);
            //ExEnd:ApplyLicenseUsingFileStream
        }

    }
}
