//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Diagram. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Diagram;

namespace ReadingDiagramFile
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Call the diagram constructor to load diagram from a VSD stream
            FileStream st = new FileStream(dataDir + "Drawing1.vsd", FileMode.Open);

            Diagram vsdDiagram = new Diagram(st);

            System.Console.WriteLine("Total Pages:" + vsdDiagram.Pages.Count);

            st.Close();

        }
    }
}