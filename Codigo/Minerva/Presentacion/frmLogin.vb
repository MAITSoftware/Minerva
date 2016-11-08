Public Class frmLogin

    Friend estadoAnimacion As Boolean = False
    Friend administrador As Boolean = False

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        timerAnimacion.Start()
    End Sub

    Private Sub frmLogin_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmIngresarRegistro.Dispose()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        frmIngresarRegistro.Show()
        frmIngresarRegistro.BringToFront()
        Me.Dispose()
    End Sub

    Private Sub Login(sender As Object, e As EventArgs) Handles btnEntrar.Click
        Me.Cursor = Cursors.WaitCursor
        Usuario.Login(Me)
    End Sub

    Private Sub timerAnimacion_Tick(sender As Object, e As EventArgs) Handles timerAnimacion.Tick
        If estadoAnimacion Then
            lblDatosInc.ForeColor = Color.IndianRed
            imgWarning.BackgroundImage = My.Resources.warningRojo
        Else
            lblDatosInc.ForeColor = Color.White
            imgWarning.BackgroundImage = My.Resources.warningBlanco
        End If

        estadoAnimacion = Not estadoAnimacion
    End Sub

    Private Sub checkEscrito(sender As Object, e As EventArgs) Handles txtCi.TextChanged, txtContraseña.TextChanged
        btnEntrar.Enabled = Not (String.IsNullOrWhiteSpace(txtCi.Text) Or String.IsNullOrEmpty(txtContraseña.Text))

        pnlError.Visible = False
        lblIngreseUsuario.Visible = String.IsNullOrWhiteSpace(txtCi.Text)
        lblIngreseContraseña.Visible = String.IsNullOrEmpty(txtContraseña.Text)
    End Sub

    Private Sub lblIngreseUsuario_Click(sender As Object, e As EventArgs) Handles lblIngreseUsuario.Click
        txtCi.Text = ""
        txtCi.Focus()
    End Sub

    Private Sub lblIngreseContraseña_Click(sender As Object, e As EventArgs) Handles lblIngreseContraseña.Click
        txtContraseña.Text = ""
        txtContraseña.Focus()
    End Sub

    Private Sub EnterClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCi.KeyDown, txtContraseña.KeyDown
        If e.KeyCode.Equals(Keys.Delete) Or e.KeyCode.Equals(Keys.Back) Or e.KeyCode.Equals(Keys.Left) Or e.KeyCode.Equals(Keys.Right) Or e.KeyCode.Equals(Keys.Tab) Then
            e.Handled = False
            Return
        End If

        If sender Is txtCi Then
            If Not Char.IsDigit(Chr(e.KeyValue)) Then
                e.SuppressKeyPress = True
            End If
        End If

        If e.KeyCode.Equals(Keys.Enter) Then
            btnEntrar.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub
End Class