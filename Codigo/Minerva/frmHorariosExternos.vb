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
End Class