using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_Shapes.ConfigureTimeLineShapes
{
    public class SetMilestoneProps
    {
        public static void Run()
        {
            // ExStart:SetMilestoneProps
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Shapes();

            // Load diagram
            Diagram diagram = new Diagram(dataDir + "DrawingTimeLine.vsdx");
            int shapeid = 22;
            // Get timeline shape
            Shape milestone = diagram.Pages.GetPage("Page-1").Shapes.GetShape(shapeid);

            // Initialize MilestoneHelper object
            Aspose.Diagram.MilestoneHelper milestoneHelper = new MilestoneHelper(milestone);

            // Set milestone date
            milestoneHelper.MilestoneDate = new DateTime(2014, 10, 21);
            // Set date format
            milestoneHelper.DateFormat = 21;
            // Set auto update flag
            milestoneHelper.IsAutoUpdate = true;
            // Set milestone type
            milestoneHelper.Type = 6;

            // Save to VDX format
            diagram.Save(dataDir + "SetMilestoneProps_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:SetMilestoneProps
        }
    }
}
