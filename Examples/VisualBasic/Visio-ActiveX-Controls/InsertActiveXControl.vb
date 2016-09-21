Imports Aspose.Diagram
Imports System.IO
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Aspose.Diagram.ActiveXControls

Public Class InsertActiveXControl
    Public Shared Sub Run()
        ' ExStart:InsertActiveXControl
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_VisioActiveXControls()
        ' Instantiate Diagram Object
        Dim diagram As New Diagram()
        ' Insert an ActiveX control
        diagram.Pages(0).AddActiveXControl(ControlType.Image, 1, 1, 1, 1)
        ' Save diagram
        diagram.Save(dataDir & Convert.ToString("InsertActiveXControl_out_.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:ManipulateObjects
    End Sub
End Class
