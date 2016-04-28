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
    public class ExtractAllImagesFromPage
    {
        public static void Run()
        {
            //ExStart:ExtractAllImagesFromPage
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // call a Diagram class constructor to load a VSD diagram
            Diagram diagram = new Diagram(dataDir + "ExtractAllImagesFromPage.vsd");

            //enter page index i.e. 0 for first one
            foreach (Shape shape in diagram.Pages[0].Shapes)
            {
                //Filter shapes by type Foreign
                if (shape.Type == Aspose.Diagram.TypeValue.Foreign)
                {
                    using (System.IO.MemoryStream stream = new System.IO.MemoryStream(shape.ForeignData.Value))
                    {
                        //Load memory stream into bitmap object
                        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(stream);

                        // save bmp here
                        bitmap.Save(dataDir + "ExtractAllImages" + shape.ID + "_Out.bmp");
                    }
                }
            }
            //ExEnd:ExtractAllImagesFromPage
        }
    }
}