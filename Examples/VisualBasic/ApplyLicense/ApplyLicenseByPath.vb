Imports Aspose.Diagram
Imports System

Public Class ApplyLicenseByPath
    Public Shared Sub Run()
        ' ExStart:ApplyLicenseByPath
        ' set path of the license file, i.e. c:\temp\
        Dim dataDir As String = "c:\temp\"

        Dim license As New License()
        license.SetLicense(dataDir & Convert.ToString("Aspose.Diagram.lic"))
        ' ExEnd:ApplyLicenseByPath
    End Sub
End Class
