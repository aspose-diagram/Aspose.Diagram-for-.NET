
Imports System
Imports Aspose.Diagram
Imports System.IO

Public Class AddMasterFromStencil
    Public Shared Sub Run()
        ' ExStart:AddMasterFromStencil
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Master()

        ' Load diagram
        Dim diagram As New Diagram()

        ' Load stencil to a stream
        Dim templateFileName As String = dataDir & Convert.ToString("NetApp-FAS-series.vss")
        Dim stream As Stream = New FileStream(templateFileName, FileMode.Open)

        ' Add master with stencil file path and master id
        Dim masterName As String = "FAS80xx rear empty"
        diagram.AddMaster(templateFileName, 2)

        ' Add master with stencil file path and master name
        diagram.AddMaster(templateFileName, masterName)

        ' Add master with stencil file stream and master id
        diagram.AddMaster(stream, 2)

        ' Adds master to diagram from source diagram
        Dim src As New Diagram(templateFileName)
        diagram.AddMaster(src, masterName)

        ' Add master with stencil file stream and master id
        diagram.AddMaster(stream, masterName)

        ' Adds shape with defined PinX and PinY.
        diagram.AddShape(2.0, 2.0, masterName, 0)
        diagram.AddShape(6.0, 6.0, masterName, 0)

        ' Adds shape with defined PinX,PinY,Width and Height.
        diagram.AddShape(7.0, 3.0, 1.5, 1.5, masterName, 0)
        ' ExEnd:AddMasterFromStencil
    End Sub
End Class
