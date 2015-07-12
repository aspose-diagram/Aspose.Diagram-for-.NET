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

namespace CSharp.Shapes
{
    public class RetrieveShapeInfo
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            //Load diagram
            Diagram vsdDiagram = new Diagram(dataDir + "RetrieveShapeInfo.vsd");

            foreach (Aspose.Diagram.Shape shape in vsdDiagram.Pages[0].Shapes)
            {
                //Display information about the shapes
                Console.WriteLine("\nShape ID : " + shape.ID);
                Console.WriteLine("Name : " + shape.Name);
                Console.WriteLine("Master Shape : " + shape.Master.Name);
            }
            

        }
    }
}