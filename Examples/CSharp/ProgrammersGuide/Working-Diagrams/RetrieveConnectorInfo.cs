//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
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
    public class RetrieveConnectorInfo
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Diagrams();

            //Call the diagram constructor to load diagram from a VSD file
            Diagram vdxDiagram = new Diagram(dataDir + "RetrieveConnectorInfo.vsd");

            foreach (Aspose.Diagram.Connect connector in vdxDiagram.Pages[0].Connects)
            {
                //Display information about the Connectors
                Console.WriteLine("\nFrom Shape ID : " + connector.FromSheet);
                Console.WriteLine("To Shape ID : " + connector.ToSheet);
            }


        }
    }
}