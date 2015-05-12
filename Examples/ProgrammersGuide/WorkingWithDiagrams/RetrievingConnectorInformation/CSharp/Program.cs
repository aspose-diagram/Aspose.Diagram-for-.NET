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

namespace RetrievingConnectorInformation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Call the diagram constructor to load diagram from a VSD file
            Diagram vdxDiagram = new Diagram(dataDir + "Drawing1.vsd");

            foreach (Aspose.Diagram.Connect connector in vdxDiagram.Pages[0].Connects)
            {
                //Display information about the Connectors
                Console.WriteLine("\nFrom Shape ID : " + connector.FromSheet);
                Console.WriteLine("To Shape ID : " + connector.ToSheet);
            }


        }
    }
}