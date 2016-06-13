Imports VisualBasic
Imports System.Drawing
Imports Aspose.Diagram
Imports System

Public Class ManageHeadersandFooters
    Public Shared Sub Run()
        ' ExStart:ManageHeadersandFooters
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_HeadersAndFooters()

        ' load source Visio diagram
        Dim diagram As New Diagram(dataDir & Convert.ToString("Drawing1.vsdx"))

        ' add page number at the right corner of header
        diagram.HeaderFooter.HeaderRight = "&p"

        ' set text at the center
        diagram.HeaderFooter.HeaderCenter = "Center of the header"

        ' set text at the left side
        diagram.HeaderFooter.HeaderLeft = "Left of the header"

        ' add text at the right corner of footer
        diagram.HeaderFooter.FooterRight = "Right of the footer"

        ' set text at the center
        diagram.HeaderFooter.FooterCenter = "Center of the footer"

        ' set text at the left side
        diagram.HeaderFooter.FooterLeft = "Left of the footer"

        ' set header & footer color
        diagram.HeaderFooter.HeaderFooterColor = Color.AliceBlue

        ' set text font properties
        diagram.HeaderFooter.HeaderFooterFont.Italic = BOOL.True
        diagram.HeaderFooter.HeaderFooterFont.Underline = BOOL.False

        ' save Visio diagram
        diagram.Save(dataDir & Convert.ToString("ManageHeadersandFooters_Out.vsdx"), SaveFileFormat.VSDX)
        ' ExEnd:ManageHeadersandFooters
    End Sub
End Class
