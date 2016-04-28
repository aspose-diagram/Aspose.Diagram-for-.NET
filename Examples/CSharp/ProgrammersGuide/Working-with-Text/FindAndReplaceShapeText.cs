using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_with_Text
{
    public class FindAndReplaceShapeText
    {
        public static void Run()
        {
            //ExStart:FindAndReplaceShapeText
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_ShapeText();

            //prepare a collection old and new text
            Dictionary<string, string> replacements = new Dictionary<string, string>();
            replacements.Add("[[CompanyName]]", "Research Society of XYZ");
            replacements.Add("[[EmployeeName]]", "James Bond");
            replacements.Add("[[SubjectTitle]]", "The affect of the internet on social behavior in the industrialize world");
            replacements.Add("[[TimePeriod]]", DateTime.Now.AddYears(-1).ToString("dd/MMMM/yyyy") + " -- " + DateTime.Now.ToString("dd/MMMM/yyyy"));
            replacements.Add("[[SubmissionDate]]", DateTime.Now.AddDays(-7).ToString("dd/MMMM/yyyy"));
            replacements.Add("[[AmountReq]]", "$100,000");
            replacements.Add("[[DateApproved]]", DateTime.Now.AddDays(1).ToString("dd/MMMM/yyyy"));

            // load diagram
            Diagram diagram = new Diagram(dataDir + "FindReplaceText.vsdx");
            // get page by name
            Page page = diagram.Pages.GetPage("Page-1");

            //iterate through the shapes of a page
            foreach (Shape shape in page.Shapes)
            {
                foreach (KeyValuePair<string, string> kvp in replacements)
                {
                    foreach (FormatTxt txt in shape.Text.Value)
                    {
                        Txt tx = txt as Txt;
                        if (tx != null && tx.Text.Contains(kvp.Key))
                        {
                            //find and replace text of a shape
                            tx.Text = tx.Text.Replace(kvp.Key, kvp.Value);
                        }
                    }
                }
            }
            //save the diagram
            diagram.Save(dataDir + "FindAndReplaceShapeText_Out.vsdx", SaveFileFormat.VSDX);
            //ExEnd:FindAndReplaceShapeText
        }
    }
}
