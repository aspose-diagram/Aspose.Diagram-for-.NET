using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.ProgrammersGuide.Working_Shapes.ConfigureTimeLineShapes
{
    public class ConfigureTimeLine
    {
        public static void Run()
        {
            // ExStart:ConfigureTimeLine
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // Load diagram
            Diagram diagram = new Diagram(dataDir + "DrawingTimeLine.vsdx");
            int shapeid = 1;
            // Get timeline shape
            Shape timeline = diagram.Pages.GetPage("Page-1").Shapes.GetShape(shapeid);

            // Initialize TimeLineHlper object
            Aspose.Diagram.TimeLineHelper timelineHelper = new TimeLineHelper(timeline);

            // Set start time
            timelineHelper.TimePeriodStart = new DateTime(2014, 12, 21);
            // Set end time
            timelineHelper.TimePeriodFinish = new DateTime(2015, 2, 19);

            // Set date format
            // TimelineHelper.DateFormatForBE = 21;
            // Set date format for intm of timeline shape   
            // TimelineHelper.DateFormatForIntm = 21;

            // Or

            // Set date format string for start and finish of timeline shape
            timelineHelper.DateFormatStringForBE = "yyyy-MM-dd";
            // Set date format string for intm of timeline shape
            timelineHelper.DateFormatStringForIntm = "yyyy-MM-dd";

            // Save to VDX format
            diagram.Save(dataDir + "ConfigureTimeLine_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:ConfigureTimeLine
        }
    }
}
