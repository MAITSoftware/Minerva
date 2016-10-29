Imports System.IO
Imports System.Data
Imports System.Reflection
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class frmHorariosExternos

    Dim frmMain As frmMain
    Public Sub New(ByVal frmMain As frmMain)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.frmMain = frmMain
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Hide()
        frmMain.BringToFront()
    End Sub

    Private Sub Grilla_Load(sender As Object, e As EventArgs) Handles Grilla.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Location = New Point(0, 0)
        Me.Size = SystemInformation.PrimaryMonitorSize

    End Sub

    Private Sub cboGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGrupo.SelectedIndexChanged
        frmMain.cboGrupo.SelectedIndex = frmMain.cboGrupo.FindStringExact(cboGrupo.Text)
        frmMain.copiarGrilla()
    End Sub

    Private Sub btnExportPDF_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Creating iTextSharp Table from the DataTable data
        Dim pdfTable As New PdfPTable(Grilla.dgvMaterias.ColumnCount)
        Dim intTblWidth() As Integer = {5, 15, 15, 15, 15, 15, 15}
        pdfTable.SetWidths(intTblWidth)
        pdfTable.DefaultCell.Padding = 5
        pdfTable.WidthPercentage = 100
        pdfTable.HorizontalAlignment = Element.ALIGN_CENTER
        pdfTable.DefaultCell.BorderWidth = 1
        pdfTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER

        'Adding Header row
        For Each column As DataGridViewColumn In Grilla.dgvMaterias.Columns
            Dim titulo As String = column.HeaderText
            If titulo.Equals("Hora de inicio") Then
                titulo = "#"
            End If
            Dim cell As New PdfPCell(New Phrase(titulo, FontFactory.GetFont("Microsoft Sans Serif", 10)))
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            cell.BackgroundColor = New BaseColor(240, 240, 240)
            pdfTable.AddCell(cell)
        Next

        'Adding DataRow
        For Each row As DataGridViewRow In Grilla.dgvMaterias.Rows
            For Each cell As DataGridViewCell In row.Cells
                pdfTable.AddCell(New Phrase(cell.Value.ToString(), FontFactory.GetFont("Microsoft Sans Serif", 10)))
            Next
        Next

        'Exporting to PDF
        Dim folderPath As String = "C:\PDFs\"
        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If
        Using stream As New FileStream(folderPath & "DataGridViewExport.pdf", FileMode.Create)
            Dim pdfDoc As New Document(PageSize.A4, 10, 10, 10, 10)
            pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate())
            PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()
            pdfDoc.Open()
            Dim headerPdf = New Paragraph("Horarios del grupo " & cboGrupo.Text & vbCrLf & vbCrLf, FontFactory.GetFont("Courier", 25, BaseColor.BLACK))
            pdfDoc.Add(headerPdf)
            pdfDoc.Add(pdfTable)
            pdfDoc.Close()
            stream.Close()
        End Using
    End Sub
End Class