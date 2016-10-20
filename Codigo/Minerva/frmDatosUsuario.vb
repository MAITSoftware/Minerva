Public Class frmDatosUsuario

    Friend _frmMain As frmMain
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        ' Al clickear salir, nos desloguea y muestra la ventana de inicio
        frmIngresarRegistro.Show()
        Me.Hide()
        Me._frmMain.Dispose()
    End Sub

    Public Sub New(ByVal _frmMain As frmMain)
        'inicia el programa, en caso de que sea invitado lo detecta
        InitializeComponent()
        Me._frmMain = _frmMain
    End Sub

    Private Sub checkDatos()
        ' Comprueba si hay datos enlos entrys y en base a esto habilita o deshabilita el botón aceptar.
        If String.IsNullOrWhiteSpace(txtNombre.Text) Then
            MessageBox.Show("Debe escribir un nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtApellido.Text) Then
            MessageBox.Show("Debe escribir un apellido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        Dim DB As New DBB()
        DB.setDatos_frmDatosUsuario(Me)
    End Sub

    Private Sub frmDatosUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblNombreUsuario.Text = _frmMain.nombreUsuario
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        checkDatos()
    End Sub
End Class