using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.ProgrammersGuide.Working_Shapes.ConfigureTimeLineShapes
{
    public class RefreshTimeLine
    {
        public static void Run()
        {
            // ExStart:RefreshTimeLine
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // Load diagram
            Diagram diagram = new Diagram(dataDir + "DrawingTimeLine.vsdx");

            int shapeid = 1;
            // Get timeline shape
            Shape timeline = diagram.Pages.GetPage("Page-1").Shapes.GetShape(shapeid);

            // Initialize TimeLineHlper object
            TimeLineHelper timelineHelper = new TimeLineHelper(timeline);

            // Set start time
            timelineHelper.TimePeriodStart = new DateTime(2014, 12, 21);
            // Set end time
            timelineHelper.TimePeriodFinish = new DateTime(2015, 2, 19);

            // Set date format
            timelineHelper.DateFormatForBE = 21;

            // Revive milestones on the timeline
            timelineHelper.RefreshTimeLine();

            // Save to VDX format
            diagram.Save(dataDir + "RefreshTimeLine_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:RefreshTimeLine
        }
    }
}
