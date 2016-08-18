using System.IO;
using Aspose.Diagram;
namespace Aspose.Diagram.Examples.CSharp.Shapes
{
    public class SetFillData
    {
        public static void Run()
        {
            // ExStart:SetFillData
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // Call a Diagram class constructor to load the VSD diagram
            Diagram diagram = new Diagram(dataDir + "SetFillData.vsd");

            // Find a particular shape and update its XForm
            foreach (Aspose.Diagram.Shape shape in diagram.Pages[0].Shapes)
            {
                if (shape.NameU.ToLower() == "rectangle" && shape.ID == 1)
                {
                    shape.Fill.FillBkgnd.Value = diagram.Pages[1].Shapes[0].Fill.FillBkgnd.Value;
                    shape.Fill.FillForegnd.Value = "#ebf8df";
                }
            }
            // Save diagram
            diagram.Save(dataDir + "SetFillData_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:SetFillData
        }
    }
}