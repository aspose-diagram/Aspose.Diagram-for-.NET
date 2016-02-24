//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Diagram. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Diagram;
using Aspose.Diagram.AutoLayout;

namespace CSharp.Diagrams
{
    public class LayOutShapesInFlowchartStyle
    {
        public static void Run()
        {
            //ExStart:LayOutShapesInFlowchartStyle
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Diagrams();

            string fileName = "LayOutShapesInFlowchartStyle.vdx";
            Diagram diagram = new Diagram(dataDir + fileName);

            LayoutOptions flowChartOptions = new LayoutOptions();
            flowChartOptions.LayoutStyle = LayoutStyle.FlowChart;
            flowChartOptions.SpaceShapes = 1f;
            flowChartOptions.EnlargePage = true;

            flowChartOptions.Direction = LayoutDirection.BottomToTop;
            diagram.Layout(flowChartOptions);
            diagram.Save(dataDir + "sample_btm_top.vdx", SaveFileFormat.VDX);

            diagram = new Diagram(dataDir + fileName);
            flowChartOptions.Direction = LayoutDirection.TopToBottom;
            diagram.Layout(flowChartOptions);
            diagram.Save(dataDir + "sample_top_btm.vdx", SaveFileFormat.VDX);

            diagram = new Diagram(dataDir + fileName);
            flowChartOptions.Direction = LayoutDirection.LeftToRight;
            diagram.Layout(flowChartOptions);
            diagram.Save(dataDir + "sample_left_right.vdx", SaveFileFormat.VDX);

            diagram = new Diagram(dataDir + fileName);
            flowChartOptions.Direction = LayoutDirection.RightToLeft;
            diagram.Layout(flowChartOptions);
            diagram.Save(dataDir + "sample_right_left.vdx", SaveFileFormat.VDX);
            //ExEnd:LayOutShapesInFlowchartStyle
        }
    }
}