using System.IO;
using Aspose.Diagram;
using Aspose.Diagram.AutoLayout;
namespace Aspose.Diagram.Examples.CSharp.Diagrams
{
    public class LayOutShapesInCompactTreeStyle
    {
        public static void Run()
        {
            // ExStart:LayOutShapesInCompactTreeStyle
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Diagrams();

            string fileName = "LayOutShapesInCompactTreeStyle.vdx";
            // load an existing Visio diagram
            Diagram diagram = new Diagram(dataDir + fileName);

            // set layout options 
            LayoutOptions compactTreeOptions = new LayoutOptions();
            compactTreeOptions.LayoutStyle = LayoutStyle.CompactTree;
            compactTreeOptions.EnlargePage = true;

            // set layout direction as DownThenRight and then save
            compactTreeOptions.Direction = LayoutDirection.DownThenRight;
            diagram.Layout(compactTreeOptions);
            diagram.Save(dataDir + "sample_down_right.vdx", SaveFileFormat.VDX);

            // set layout direction as DownThenLeft and then save
            diagram = new Diagram(dataDir + fileName);
            compactTreeOptions.Direction = LayoutDirection.DownThenLeft;
            diagram.Layout(compactTreeOptions);
            diagram.Save(dataDir + "sample_down_left.vdx", SaveFileFormat.VDX);

            // set layout direction as RightThenDown and then save
            diagram = new Diagram(dataDir + fileName);
            compactTreeOptions.Direction = LayoutDirection.RightThenDown;
            diagram.Layout(compactTreeOptions);
            diagram.Save(dataDir + "sample_right_down.vdx", SaveFileFormat.VDX);

            // set layout direction as LeftThenDown and then save
            diagram = new Diagram(dataDir + fileName);
            compactTreeOptions.Direction = LayoutDirection.LeftThenDown;
            diagram.Layout(compactTreeOptions);
            diagram.Save(dataDir + "sample_left_down.vdx", SaveFileFormat.VDX);
            // ExEnd:LayOutShapesInCompactTreeStyle
        }
    }
}