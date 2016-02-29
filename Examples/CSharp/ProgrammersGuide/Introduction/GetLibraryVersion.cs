using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Introduction
{
    public class GetLibraryVersion
    {
        public static void Run()
        {
            //ExStart:GetLibraryVersion
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Intro();

            // build path of an existing diagram
            string visioDrawing = dataDir + "Drawing1.vsdx";

            //Call the diagram constructor to load diagram from a VDX file
            Diagram diagram = new Diagram(visioDrawing);

            //Display Visio version and document modification time at different stages
            Console.WriteLine("Visio Instance Version : " + diagram.Version);
            Console.WriteLine("Full Build Number Created : " + diagram.DocumentProps.BuildNumberCreated);
            Console.WriteLine("Full Build Number Edited : " + diagram.DocumentProps.BuildNumberEdited);
            Console.WriteLine("Date Created : " + diagram.DocumentProps.TimeCreated);
            Console.WriteLine("Date Last Edited : " + diagram.DocumentProps.TimeEdited);
            Console.WriteLine("Date Last Printed : " + diagram.DocumentProps.TimePrinted);
            Console.WriteLine("Date Last Saved : " + diagram.DocumentProps.TimeSaved);

            Console.ReadLine();
            //ExEnd:GetLibraryVersion
        }
    }
}
