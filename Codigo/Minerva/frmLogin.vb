Public Class frmLogin
    ' Datos de prueba: mismo usuario y misma contraseña = acceso
    ' Otros datos: error

    Friend estadoAnimacion As Boolean = False
    Friend cuentaUsuario As String
    Friend administrador As Boolean = False

    Private Sub frmLogin_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' Al cerrar esta ventana cerrar todo el programa
        frmIngresarRegistro.Dispose()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        ' Al clickear cancelar mostrar ventana inicial
        frmIngresarRegistro.Show()
        frmIngresarRegistro.BringToFront()
        Me.Dispose()
    End Sub

    ' Persistencia

    Private Sub Login(sender As Object, e As EventArgs) Handles btnEntrar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim DB As New BaseDeDatos()
        DB.Login_frmLogin(Me)
    End Sub

    ' Presentación

    Private Sub timerAnimacion_Tick(sender As Object, e As EventArgs) Handles timerAnimacion.Tick
        ' Cambia el color de la alerta de error cada x segundos
        If estadoAnimacion Then
            lblDatosInc.ForeColor = Color.IndianRed
            imgWarning.BackgroundImage = My.Resources.warningRojo
        Else
            lblDatosInc.ForeColor = Color.White
            imgWarning.BackgroundImage = My.Resources.warningBlanco
        End If

        estadoAnimacion = Not estadoAnimacion
    End Sub

    Private Sub checkEscrito(sender As Object, e As EventArgs) Handles txtUsuario.TextChanged, txtContraseña.TextChanged
        ' Comprueba que haya algo realmente escrito en los campos'
        btnEntrar.Enabled = Not (String.IsNullOrWhiteSpace(txtUsuario.Text) Or String.IsNullOrEmpty(txtContraseña.Text)) 'btnEntrar se activará si txtICI o txtContrasenia no están vacíos

        pnlError.Visible = False
        lblIngreseUsuario.Visible = String.IsNullOrWhiteSpace(txtUsuario.Text)
        lblIngreseContraseña.Visible = String.IsNullOrEmpty(txtContraseña.Text)
    End Sub

    Private Sub lblIngreseUsuario_Click(sender As Object, e As EventArgs) Handles lblIngreseUsuario.Click
        ' Al clickear el lblIngreseUsuario (placeholder) dar focus a txtUsuario
        txtUsuario.Text = ""
        txtUsuario.Focus()
    End Sub

    Private Sub lblIngreseContraseña_Click(sender As Object, e As EventArgs) Handles lblIngreseContraseña.Click
        ' Al clickear el lblIngrseContraseña (placeholder) dar focus a txtContraseña
        txtContraseña.Text = ""
        txtContraseña.Focus()
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Inicia el timer de la animacino
        timerAnimacion.Start()
    End Sub

    Private Sub EnterClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsuario.KeyDown, txtContraseña.KeyDown
        If e.KeyCode.Equals(Keys.Delete) Or e.KeyCode.Equals(Keys.Back) Or e.KeyCode.Equals(Keys.Left) Or e.KeyCode.Equals(Keys.Right) Or e.KeyCode.Equals(Keys.Tab) Then
            e.Handled = False
            Return
        End If

        If sender Is txtUsuario Then
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