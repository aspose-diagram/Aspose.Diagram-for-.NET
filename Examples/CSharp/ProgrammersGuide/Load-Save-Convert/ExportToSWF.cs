//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Diagram. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Diagram;

namespace CSharp.Diagrams
{
    public class ExportToSWF
    {
        public static void Run()
        {

            try
            {
                //ExStart:ExportToSWF
                // The path to the documents directory.
                string dataDir = RunExamples.GetDataDir_Diagrams();
                // load diagram
                Diagram diagram = new Diagram(dataDir + "ActvDir.vsd");
                // save diagram
                diagram.Save(dataDir + "Output_Out.swf", SaveFileFormat.SWF);
                //ExEnd:ExportToSWF
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("This example will only work if you apply a valid Aspose License. You can purchase full license or get 30 day temporary license from http://www.aspose.com/purchase/default.aspx.");
            }
        }
    }
}