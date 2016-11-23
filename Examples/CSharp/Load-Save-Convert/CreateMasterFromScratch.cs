using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Aspose.Diagram.Examples.CSharp.Load_Save_Convert
{
    public class CreateMasterFromScratch
    {
        // ExStart:CreateMasterFromScratch
        public static void Run()
        {            
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_LoadSaveConvert();

            // Create a new template
            Diagram diagram = new Diagram();
            // Add master
            diagram.Masters.Add(CreateMaster(101, "Regular", dataDir + "aspose-logo.jpg"));
            // Save template
            diagram.Save(dataDir + "CreateMasterFromScratch_out.vtx", SaveFileFormat.VTX);           
        }

        // Create master
        public static Master CreateMaster(int masterId, string name, string masterImage)
        {
            // Set master properties
            Master master = new Master();
            master.ID = masterId;
            master.Name = name;
            master.IconSize = IconSizeValue.Normal;
            master.AlignName = AlignNameValue.AlignTextCenter;
            master.MatchByName = BOOL.True;
            master.IconUpdate = BOOL.True;
            master.UniqueID = Guid.NewGuid();
            master.BaseID = Guid.NewGuid();
            master.PatternFlags = 1;
            master.Hidden = BOOL.False;

            // Set master's shape properties
            Shape shape = new Shape();
            master.Shapes.Add(shape);

            double width = 0.5443889263424177;
            double height = 0.432916947568133;
            shape.ID = 5;
            shape.Type = TypeValue.Foreign;
            shape.XForm.PinX.Value = 0.2221944631712089;
            shape.XForm.PinY.Value = 0.1666458473784065;
            shape.XForm.Width.Value = width;
            shape.XForm.Height.Value = height;
            shape.XForm.LocPinX.Ufe.F = "Width*0.5";
            shape.XForm.LocPinY.Ufe.F = "Height*0.5";
            shape.XForm.ResizeMode.Value = 0;
            shape.TextXForm.TxtPinY.Ufe.F = "-TxtHeight/2";
            shape.TextXForm.TxtWidth.Ufe.F = "TEXTWIDTH(TheText)";
            shape.TextXForm.TxtHeight.Ufe.F = "TEXTHEIGHT(TheText, TxtWidth)";

            // Set connection properties
            Connection connection = new Connection();
            shape.Connections.Add(connection);

            connection.ID = 1;
            connection.NameU = "All";
            connection.X.Value = 0.22;
            connection.X.Ufe.F = "Width*0.5";
            connection.Y.Value = 0.16;
            connection.Y.Ufe.F = "Height*0.5";
            connection.DirX.Value = 0;
            connection.DirY.Value = 0;
            connection.Type.Value = 0;
            connection.AutoGen.Value = BOOL.False;
            connection.Prompt.Ufe.F = "No Formula";

            shape.ForeignData.ForeignType = ForeignType.Bitmap;
            shape.ForeignData.CompressionType = CompressionType.PNG;
            shape.ForeignData.Value = ReadImageFile(masterImage); // EncodedImage.getBytes();

            return master;
        }
        // Get image bytes
        public static byte[] ReadImageFile(string imageLocation)
        {
            byte[] imageData = null;
            FileInfo fileInfo = new FileInfo(imageLocation);
            long imageFileLength = fileInfo.Length;
            FileStream fs = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imageData = br.ReadBytes((int)imageFileLength);
            return imageData;
        }
        // ExEnd:CreateMasterFromScratch
    }

}
