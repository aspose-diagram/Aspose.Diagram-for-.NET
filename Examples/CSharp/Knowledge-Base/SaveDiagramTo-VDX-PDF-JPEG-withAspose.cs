using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Knowledge_Base
{
    public class SaveDiagramTo_VDX_PDF_JPEG_withAspose
    {
        public static void Run() 
        {
            // ExStart:SaveDiagramTo_VDX_PDF_JPEG_withAspose
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_KnowledgeBase();

            // load an exiting Visio diagram
            Diagram vsdDiagram = new Diagram(dataDir + "Drawing1.vsd");

            // Save the diagram as VDX
            vsdDiagram.Save(dataDir + "SaveDiagramToVDXwithAspose_Out.vdx", SaveFileFormat.VDX);

            // Save as PDF
            vsdDiagram.Save(dataDir + "SaveDiagramToPDFwithAspose_Out.pdf", SaveFileFormat.PDF);

            // Save as JPEG
            vsdDiagram.Save(dataDir + "SaveDiagramToJPGwithAspose_Out.jpg", SaveFileFormat.JPEG);
            // ExEnd:SaveDiagramTo_VDX_PDF_JPEG_withAspose
        }
    }
}
