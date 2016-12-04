Imports MySql.Data.MySqlClient

Public Class frmEditarServidor
    Dim conexionCorrecta As Boolean = True
    Dim userInicial, contraInicial, serverInicial, dbInicial
    Dim testeado = True

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub frmEditarServidor_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        serverInicial = GetSetting("Minerva", "BaseDeDatos", "IP").ToString()
        userInicial = GetSetting("Minerva", "BaseDeDatos", "Usuario").ToString()
        contraInicial = GetSetting("Minerva", "BaseDeDatos", "Contraseña").ToString()
        dbInicial = GetSetting("Minerva", "BaseDeDatos", "DB").ToString()

        txtDB.Text = dbInicial
        txtPasswd.Text = contraInicial
        txtUsuario.Text = userInicial
        txtServidor.Text = serverInicial
        btnProbar.PerformClick()
    End Sub

    Private Sub btnProbar_Click(sender As Object, e As EventArgs) Handles btnProbar.Click
        Me.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Dim ventanaEspere As New frmDialogoEspere
        ventanaEspere.Show()
        Dim Conn As MySqlConnection
        Try
            Conn = New MySqlConnection("server=" & txtServidor.Text & ";uid=" & txtUsuario.Text & ";password=" & txtPasswd.Text & ";database=" & txtDB.Text & ";")
            Conn.Open()
            lblEstado1.ForeColor = Color.GreenYellow
            lblEstado2.ForeColor = Color.GreenYellow
            lblEstado2.Text = "Conexión establecida"
            conexionCorrecta = True
            Conn.Dispose()
        Catch ex As Exception
            conexionCorrecta = False
            lblEstado1.ForeColor = Color.Red
            lblEstado2.ForeColor = Color.Red
            lblEstado2.Text = "Error al establecer la conexión"
        End Try
        testeado = True
        Me.Enabled = True
        Me.Cursor = Cursors.Default
        ventanaEspere.Dispose()
        Me.BringToFront()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Not conexionCorrecta Or Not testeado Then
            MessageBox.Show("El programa debe ser capaz de establecer la conexión a la base de datos para poder continuar." & vbCrLf & "Recuerde que debe testear la conexión antes de presionar aceptar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If
        SaveSetting("Minerva", "BaseDeDatos", "IP", txtServidor.Text)
        SaveSetting("Minerva", "BaseDeDatos", "Usuario", txtUsuario.Text)
        SaveSetting("Minerva", "BaseDeDatos", "Contraseña", txtPasswd.Text)
        SaveSetting("Minerva", "BaseDeDatos", "DB", txtDB.Text)
        frmIngresarRegistro.BringToFront()
        Me.Dispose()
    End Sub

    Private Sub _TextChanged(sender As Object, e As EventArgs) Handles txtServidor.TextChanged, txtPasswd.TextChanged, txtUsuario.TextChanged, txtDB.TextChanged
        testeado = False
        lblEstado1.ForeColor = Color.SkyBlue
        lblEstado2.ForeColor = Color.SkyBlue
        lblEstado2.Text = "Conexión sin probar"
    End Sub
End Class