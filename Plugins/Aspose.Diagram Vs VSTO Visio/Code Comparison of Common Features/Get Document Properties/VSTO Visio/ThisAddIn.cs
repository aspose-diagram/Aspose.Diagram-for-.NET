using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;

namespace VSTO_Visio
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            MessageBox.Show(Application.ActiveDocument.Version.ToString());
            MessageBox.Show(Application.ActiveDocument.BuildNumberCreated.ToString());
            MessageBox.Show(Application.ActiveDocument.BuildNumberEdited.ToString());
            MessageBox.Show(Application.ActiveDocument.TimeCreated.ToString());
            MessageBox.Show(Application.ActiveDocument.TimeEdited.ToString());
            MessageBox.Show(Application.ActiveDocument.TimePrinted.ToString());
            MessageBox.Show(Application.ActiveDocument.TimeSaved.ToString());
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
