
Imports System.Drawing
Imports Aspose.Diagram
Imports System

Public Class ManageHeadersandFooters
    Public Shared Sub Run()
        ' ExStart:ManageHeadersandFooters
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_HeadersAndFooters()

        ' Load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' Add page number at the right corner of header
        diagram.HeaderFooter.HeaderRight = "&p"

        ' Set text at the center
        diagram.HeaderFooter.HeaderCenter = "Center of the header"

        ' Set text at the left side
        diagram.HeaderFooter.HeaderLeft = "Left of the header"

        ' Add text at the right corner of footer
        diagram.HeaderFooter.FooterRight = "Right of the footer"

        ' Set text at the center
        diagram.HeaderFooter.FooterCenter = "Center of the footer"

        ' Set text at the left side
        diagram.HeaderFooter.FooterLeft = "Left of the footer"

        ' Set header & footer color
        diagram.HeaderFooter.HeaderFooterColor = Color.AliceBlue

        ' Set text font properties
        diagram.HeaderFooter.HeaderFooterFont.Italic = BOOL.True
        diagram.HeaderFooter.HeaderFooterFont.Underline = BOOL.False

        ' Save Visio diagram
        diagram.Save(dataDir & Convert.ToString("ManageHeadersandFooters_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:ManageHeadersandFooters
    End Sub
End Class
