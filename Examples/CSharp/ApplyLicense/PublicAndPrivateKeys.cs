using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.ApplyLicense
{
    public class PublicAndPrivateKeys
    {
        public static void Run() 
        {
            // ExStart:PublicAndPrivateKeys
            // Initialize a Metered license class object
            Aspose.Diagram.Metered metered = new Aspose.Diagram.Metered();
            // apply public and private keys
            metered.SetMeteredKey("your-public-key", "your-private-key");
            // ExEnd:PublicAndPrivateKeys
        }
    }
}
