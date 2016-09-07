Imports MySql.Data.MySqlClient
Imports System.Data

Public Class frmLogin
    ' Datos de prueba: mismo usuario y misma contraseña = acceso
    ' Otros datos: error

    Dim estadoAnimacion As Boolean = False
    Dim cuentaUsuario As String
    Dim administrador As Boolean = False

    Private Sub frmLogin_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' Al cerrar esta ventana cerrar todo el programa
        frmIngresarRegistro.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        ' Al clickear cancelar mostrar ventana inicial
        frmIngresarRegistro.Show()
        Me.Dispose()
    End Sub

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

    Private Sub txtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsuario.KeyPress
        ' hace un sonido al ingresar espacio en la txtUsuario
        If e.KeyChar = " " Then
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
            e.Handled = True
        End If
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

    Private Sub Login(sender As Object, e As EventArgs) Handles btnEntrar.Click
        Dim accesoDenegado As Boolean = True
        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Usuario` WHERE ID=@ID AND Contraseña=@Contraseña;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@ID", txtUsuario.Text)
                .Parameters.AddWithValue("@Contraseña", txtContraseña.Text)
                Me.cuentaUsuario = txtUsuario.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                If Not reader("Aprobado") Then
                    MsgBox("Acceso no autorizado" & vbCrLf & "El administrador aún debe confirmar su registro", MsgBoxStyle.Information, "Minerva · Registro a confirmar")
                    lblDatosInc.Text = "Cuenta no autorizada"
                    pnlError.Visible = True
                    Return
                End If
                If reader("Tipo").Equals("Administrador") Then
                    administrador = True
                Else
                    administrador = False
                End If
                accesoDenegado = False
            End While
            reader.Close()
            conexion.Close()
        End Using

        If accesoDenegado Then
            lblDatosInc.Text = "Datos incorrectos!"
            pnlError.Visible = True
        Else
            Dim minerva As New frmMain(False, administrador)
            minerva.Show()
            Me.Hide()
        End If
    End Sub
End Class