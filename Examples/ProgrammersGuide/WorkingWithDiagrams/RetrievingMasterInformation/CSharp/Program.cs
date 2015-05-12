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

namespace RetrievingMasterInformation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Call the diagram constructor to load diagram from a VDX file
            Diagram vdxDiagram = new Diagram(dataDir + "drawing.vdx");

            foreach (Aspose.Diagram.Master master in vdxDiagram.Masters)
            {
                //Display information about the masters
                Console.WriteLine("\nMaster ID : " + master.ID);
                Console.WriteLine("Master Name : " + master.Name);
            }

            Console.ReadLine();
        }
    }
}