Imports System.IO
Imports System
Imports Aspose.Diagram
Imports Aspose.Diagram.Vba

Public Class ModifyVBAModule
    Public Shared Sub Run()
        ' ExStart:ModifyVBAModule
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Diagrams()

        ' Load an existing Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdm"), LoadFileFormat.VSDM)
        ' Extract VBA project
        Dim v As Aspose.Diagram.Vba.VbaProject = diagram.VbaProject
        ' Iterate through the modules and modify VBA module code
        For Each [module] As VbaModule In diagram.VbaProject.Modules
            Dim code As String = [module].Codes
            If code.Contains("This is test message.") Then
                code = code.Replace("This is test message.", "This is Aspose.Diagram message.")
            End If
            [module].Codes = code
        Next
        ' Save the Visio diagram
        diagram.Save(dataDir & Convert.ToString("ModifyVBAModule_out_.vssm"), SaveFileFormat.VSSM)
        ' ExEnd:ModifyVBAModule           
    End Sub
End Class

