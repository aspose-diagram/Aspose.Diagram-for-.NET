using System.IO;
using Aspose.Diagram;
using Aspose.Diagram.AutoLayout;
namespace Aspose.Diagram.Examples.CSharp.Diagrams
{
    public class LayOutShapesInFlowchartStyle
    {
        public static void Run()
        {
            // ExStart:LayOutShapesInFlowchartStyle
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Diagrams();

            // load an existing Visio diagram
            string fileName = "LayOutShapesInFlowchartStyle.vdx";
            Diagram diagram = new Diagram(dataDir + fileName);

            // set layout options 
            LayoutOptions flowChartOptions = new LayoutOptions();
            flowChartOptions.LayoutStyle = LayoutStyle.FlowChart;
            flowChartOptions.SpaceShapes = 1f;
            flowChartOptions.EnlargePage = true;

            // set layout direction as BottomToTop and then save
            flowChartOptions.Direction = LayoutDirection.BottomToTop;
            diagram.Layout(flowChartOptions);
            diagram.Save(dataDir + "sample_btm_top.vdx", SaveFileFormat.VDX);

            // set layout direction as TopToBottom and then save
            diagram = new Diagram(dataDir + fileName);
            flowChartOptions.Direction = LayoutDirection.TopToBottom;
            diagram.Layout(flowChartOptions);
            diagram.Save(dataDir + "sample_top_btm.vdx", SaveFileFormat.VDX);

            // set layout direction as LeftToRight and then save
            diagram = new Diagram(dataDir + fileName);
            flowChartOptions.Direction = LayoutDirection.LeftToRight;
            diagram.Layout(flowChartOptions);
            diagram.Save(dataDir + "sample_left_right.vdx", SaveFileFormat.VDX);

            // set layout direction as RightToLeft and then save
            diagram = new Diagram(dataDir + fileName);
            flowChartOptions.Direction = LayoutDirection.RightToLeft;
            diagram.Layout(flowChartOptions);
            diagram.Save(dataDir + "sample_right_left.vdx", SaveFileFormat.VDX);
            // ExEnd:LayOutShapesInFlowchartStyle
        }
    }
}