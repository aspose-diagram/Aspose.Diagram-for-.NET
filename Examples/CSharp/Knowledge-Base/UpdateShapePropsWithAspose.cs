using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Knowledge_Base
{
    public class UpdateShapePropsWithAspose
    {
        public static void Run() 
        {
            // ExStart:UpdateShapePropsWithAspose
            try
            {
                // The path to the documents directory.
                string dataDir = RunExamples.GetDataDir_KnowledgeBase();

                // Save the uploaded file as PDF
                Diagram diagram = new Diagram(dataDir + "Drawing1.vsd");

                // Find a particular shape and update its properties
                foreach (Aspose.Diagram.Shape shape in diagram.Pages[0].Shapes)
                {
                    if (shape.Name.ToLower() == "process1")
                    {
                        shape.Text.Value.Clear();
                        shape.Text.Value.Add(new Txt("Hello World"));

                        // Find custom style sheet and set as shape's text style
                        foreach (StyleSheet styleSheet in diagram.StyleSheets)
                        {
                            if (styleSheet.Name == "CustomStyle1")
                            {
                                shape.TextStyle = styleSheet;
                            }
                        }

                        // Set horizontal and vertical position of the shape
                        shape.XForm.PinX.Value = 5;
                        shape.XForm.PinY.Value = 5;

                        // Set height and width of the shape
                        shape.XForm.Height.Value = 2;
                        shape.XForm.Width.Value = 3;
                    }
                }

                // Save shape as VDX
                diagram.Save(dataDir + "UpdateShapePropsWithAspose_Out.vdx", SaveFileFormat.VDX);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // ExEnd:UpdateShapePropsWithAspose
        }
    }
}
