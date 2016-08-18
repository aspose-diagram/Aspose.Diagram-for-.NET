using Aspose.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Diagram.Examples.CSharp.Working_with_SolutionXML_Elements
{
    public class AddSolutionXMLElement
    {
        public static void Run() 
        {
            // ExStart:AddSolutionXMLElement
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_SolutionXML();

            // Load source Visio diagram
            Diagram diagram = new Diagram(dataDir + "Drawing1.vsdx");

            // Initialize SolutionXML object
            SolutionXML solXML = new SolutionXML();
            // Set name
            solXML.Name = "Solution XML";
            // Set xml value
            solXML.XmlValue = "XML Value";
            // Add SolutionXML element
            diagram.SolutionXMLs.Add(solXML);

            // Save Visio diagram
            diagram.Save(dataDir + "AddSolutionXMLElement_Out.vsdx", SaveFileFormat.VSDX);
            // ExEnd:AddSolutionXMLElement
        }
    }
}
