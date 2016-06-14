using System.IO;
using Aspose.Diagram;
namespace Aspose.Diagram.Examples.CSharp.Shapes
{
    public class SetXFormdata
    {
        public static void Run()
        {
            // ExStart:SetXFormdata
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // call a Diagram class constructor to load the VSD diagram
            Diagram diagram = new Diagram(dataDir + "SetXFormdata.vsd");

            // Find a particular shape and update its XForm
            foreach (Aspose.Diagram.Shape shape in diagram.Pages[0].Shapes)
            {
                if (shape.NameU.ToLower() == "process" && shape.ID == 1)
                {
                    shape.XForm.PinX.Value = 5;
                    shape.XForm.PinY.Value = 5;
                }
            }
            // save diagram
            diagram.Save(dataDir + "SetXFormdata_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:SetXFormdata
        }
    }
}