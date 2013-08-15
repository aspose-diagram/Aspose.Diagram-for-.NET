//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Diagram. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Diagram;
using Aspose.Diagram.AutoLayout;

namespace LayingOutShapesInCompactTreeStyle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            string fileName = "drawing.vdx";
            Diagram diagram = new Diagram(dataDir + fileName);

            LayoutOptions compactTreeOptions = new LayoutOptions();
            compactTreeOptions.LayoutStyle = LayoutStyle.CompactTree;
            compactTreeOptions.EnlargePage = true;

            compactTreeOptions.Direction = LayoutDirection.DownThenRight;
            diagram.Layout(compactTreeOptions);
            diagram.Save(dataDir + "sample_down_right.vdx", SaveFileFormat.VDX);

            diagram = new Diagram(dataDir + fileName);
            compactTreeOptions.Direction = LayoutDirection.DownThenLeft;
            diagram.Layout(compactTreeOptions);
            diagram.Save(dataDir + "sample_down_left.vdx", SaveFileFormat.VDX);

            diagram = new Diagram(dataDir + fileName);
            compactTreeOptions.Direction = LayoutDirection.RightThenDown;
            diagram.Layout(compactTreeOptions);
            diagram.Save(dataDir + "sample_right_down.vdx", SaveFileFormat.VDX);

            diagram = new Diagram(dataDir + fileName);
            compactTreeOptions.Direction = LayoutDirection.LeftThenDown;
            diagram.Layout(compactTreeOptions);
            diagram.Save(dataDir + "sample_left_down.vdx", SaveFileFormat.VDX);
        }
    }
}