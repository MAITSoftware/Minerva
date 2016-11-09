Public Class frmDatosUsuario

    Friend frmMain As frmMain

    Public Sub New(frmMain As frmMain)
        'inicia el programa, en caso de que sea invitado lo detecta
        InitializeComponent()
        Me.frmMain = frmMain
    End Sub

    Private Sub frmDatosUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblNombreUsuario.Text = frmMain.nombreUsuario
        txtNombre.Focus()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        ' Al clickear salir, nos desloguea y muestra la ventana de inicio
        frmIngresarRegistro.Show()
        frmIngresarRegistro.BringToFront()
        Me.Hide()
        Me.frmMain.Dispose()
    End Sub

    Private Sub checkDatos(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles btnAceptar.Click
        ' Comprueba si hay datos enlos entrys y en base a esto habilita o deshabilita el botón aceptar.
        If String.IsNullOrWhiteSpace(txtNombre.Text) Then
            MessageBox.Show("Debe escribir un nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtApellido.Text) Then
            MessageBox.Show("Debe escribir un apellido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        Usuario.EditarDatos(Me)
    End Sub

    Private Sub EnterClick(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyDown, txtApellido.KeyDown
        If e.KeyCode.Equals(Keys.Enter) Then
            btnAceptar.PerformClick()
        End If
    End Sub
End Class