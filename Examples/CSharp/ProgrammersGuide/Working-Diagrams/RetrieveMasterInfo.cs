//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Diagram. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Diagram;
using System;

namespace CSharp.Diagrams
{
    public class RetrieveMasterInfo
    {
        public static void Run()
        {
            //ExStart:RetrieveMasterInfo
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Diagrams();

            //Call the diagram constructor to load diagram from a VDX file
            Diagram vdxDiagram = new Diagram(dataDir + "RetrieveMasterInfo.vdx");

            foreach (Aspose.Diagram.Master master in vdxDiagram.Masters)
            {
                //Display information about the masters
                Console.WriteLine("\nMaster ID : " + master.ID);
                Console.WriteLine("Master Name : " + master.Name);
            }
            
            Console.ReadLine();
            //ExEnd:RetrieveMasterInfo
        }
    }
}