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

namespace RetrievingShapeInformation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Load diagram
            Diagram vsdDiagram = new Diagram(dataDir + "Drawing1.vsd");

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