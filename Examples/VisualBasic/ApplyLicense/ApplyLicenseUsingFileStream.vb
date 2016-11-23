Imports System.IO
Imports Aspose.Diagram
Imports System
Public Class ApplyLicenseUsingFileStream
    Public Shared Sub Run()
        ' ExStart:ApplyLicenseUsingFileStream
        ' Set path of the license file, i.e. c:\temp\
        Dim dataDir As String = "c:\temp\"
        ' Load an existing Visio file in the stream
        Dim LicStream As New FileStream(dataDir & Convert.ToString("Aspose.Diagram.lic"), FileMode.Open)

        Dim license As New License()
        license.SetLicense(LicStream)
        ' ExEnd:ApplyLicenseUsingFileStream
    End Sub
End Class
