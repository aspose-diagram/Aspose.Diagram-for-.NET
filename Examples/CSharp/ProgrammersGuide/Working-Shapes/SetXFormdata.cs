//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Diagram. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Diagram;

namespace CSharp.Shapes
{
    public class SetXFormdata
    {
        public static void Run()
        {
            // ExStart:SetXFormdata
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // call a Diagram class constructor to load the VSD diagram
            Diagram diagram = new Diagram(dataDir + "SetXFormdata.vsd");

            // Find a particular shape and update its XForm
            foreach (Aspose.Diagram.Shape shape in diagram.Pages[0].Shapes)
            {
                if (shape.NameU.ToLower() == "process" && shape.ID == 1)
                {
                    shape.XForm.PinX.Value = 5;
                    shape.XForm.PinY.Value = 5;
                }
            }
            // save diagram
            diagram.Save(dataDir + "SetXFormdata_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:SetXFormdata
        }
    }
}