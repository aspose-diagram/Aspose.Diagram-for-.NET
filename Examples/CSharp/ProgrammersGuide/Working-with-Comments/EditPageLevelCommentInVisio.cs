using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.ProgrammersGuide.Working_with_Comments
{
    public class EditPageLevelCommentInVisio
    {
        public static void Run() 
        {
            //ExStart:EditPageLevelCommentInVisio
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_VisioComments();

            // load Visio
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // get collection of the annotations
            AnnotationCollection annotations = diagram.Pages.GetPage("Page-1").PageSheet.Annotations;

            // iterate through the annotations
            foreach (Annotation annotation in annotations)
            {
                string comment = annotation.Comment.Value;
                comment += "Updation mark";
                annotation.Comment.Value = comment;
            }
            // save Visio
            diagram.Save(dataDir + "EditComment_Out.vsdx", SaveFileFormat.VSDX);
            //ExEnd:EditPageLevelCommentInVisio
        }
    }
}
