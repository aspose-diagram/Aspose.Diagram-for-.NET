Imports Aspose.Diagram.Saving
Imports System
Imports System.Security.Cryptography.X509Certificates
Imports Aspose.Diagram
Public Class UsePDFSaveOptions
    Public Shared Sub Run()
        ' ExStart:UsePDFSaveOptions
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_LoadSaveConvert()

        ' Call the diagram constructor to load diagram from a VSD file
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' Options when saving a diagram into the PDF format
        Dim options As New PdfSaveOptions()

        ' Discard saving background pages of the Visio diagram
        options.SaveForegroundPagesOnly = True

        ' Specify the quality of JPEG compression for images (if JPEG compression is used). Default is 95.
        options.JpegQuality = 100

        ' Specify default font name
        options.DefaultFont = "Arial"

        ' Conformance level for generated PDF document.
        options.Compliance = PdfCompliance.Pdf15

        ' Load the certificate from disk.
        ' The other constructor overloads can be used to load certificates from different locations.
        Dim cert As New X509Certificate2(dataDir & Convert.ToString("certificate.pfx"), "feyb4lgcfbme")
        ' Sets a digital signature details. If not set, then no signing will be performed.
        options.DigitalSignatureDetails = New PdfDigitalSignatureDetails(cert, "Test Signing", "Aspose Office", DateTime.Now, PdfDigitalSignatureHashAlgorithm.Sha512)

        ' Set encription details
        Dim encriptionDetails As New PdfEncryptionDetails("user password", "Owner Password", PdfEncryptionAlgorithm.RC4_128)
        options.EncryptionDetails = encriptionDetails
        ' Sets the number of pages to render in PDF.
        options.PageCount = 2
        ' Sets the 0-based index of the first page to render. Default is 0.
        options.PageIndex = 0

        ' Set page size
        Dim pgSize As New PageSize(PaperSizeFormat.A1)
        options.PageSize = pgSize
        ' Save in any supported file format
        diagram.Save(dataDir & Convert.ToString("UsePDFSaveOptions_out.pdf"), options)
        ' ExEnd:UsePDFSaveOptions
    End Sub
End Class
