Imports MySql.Data.MySqlClient
Imports System.Data

Public Class frmRegistro
    ' Datos de prueba: Si el usuario no es ignacio, este va a existir siempre.

    Dim estadoAnimacion As Boolean = False

    Private Sub frmLogin_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' Al cerrar ventana, cerrar programa
        frmIngresarRegistro.Dispose()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        ' al clickear cancelar, volver a la ventana inicial
        frmIngresarRegistro.Show()
        Me.Dispose()
    End Sub

    Private Sub timerAnimacion_Tick(sender As Object, e As EventArgs) Handles timerAnimacion.Tick
        ' cambia el color de la alerta cada x tiempo
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
        ' Al clickear el lblIngrseUsuario (placeholder) dar focus a txtUsuario
        txtUsuario.Text = ""
        txtUsuario.Focus()
    End Sub

    Private Sub txtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsuario.KeyPress
        ' al escribir espacio en txtUsuario, suena una alerta
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
        ' al cargar ventana, iniciar animacion
        timerAnimacion.Start()
    End Sub

    Private Sub Registro(sender As Object, e As EventArgs) Handles btnEntrar.Click
        Dim conexion As New DB()
        Dim cantidadAdministradores As Integer

        ' Verifica si es el primer usuario.
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "select COUNT(*) as 'Cantidad' from Usuario WHERE Usuario.Tipo='Administrador';"
                .CommandType = CommandType.Text
            End With
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                cantidadAdministradores = Integer.Parse(reader("Cantidad"))
            End While
            reader.Close()
        End Using


        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "INSERT INTO `Usuario` VALUES (@ID, @Contraseña, @Aprobado, @Tipo);"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@ID", txtUsuario.Text)
                .Parameters.AddWithValue("@Contraseña", txtContraseña.Text)
                If cantidadAdministradores <= 0 Then
                    .Parameters.AddWithValue("@Aprobado", True) ' Habilitada
                    .Parameters.AddWithValue("@Tipo", "Administrador") ' Admin
                Else
                    .Parameters.AddWithValue("@Aprobado", False) ' No está habilitada
                    .Parameters.AddWithValue("@Tipo", "Funcionario") ' No es admin
                End If
            End With

            Try
                cmd.ExecuteNonQuery()
                conexion.Close()
                If cantidadAdministradores <= 0 Then
                    MsgBox("Gracias por registrarse. " & vbCrLf & "Usted ha sido registrado como administrador." & vbCrLf & "Ya puede acceder al sistema utilizando sus datos.", MsgBoxStyle.Information, "Minerva · Confirmación de registro")
                Else
                    MsgBox("Gracias por registrarse. " & vbCrLf & "El administrador deberá confirmar su registro", MsgBoxStyle.Information, "Minerva · Confirmación de registro")
                End If
                Me.Hide()
                frmIngresarRegistro.Show()
                Me.Dispose()
            Catch ex As Exception
                pnlError.Visible = True
                conexion.Close()
            End Try
        End Using
    End Sub
End Class