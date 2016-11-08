Imports MySql.Data.MySqlClient

Public Class Usuario
    Public Shared Sub Login(ByVal frm As frmLogin)
        ' Se encarga de comprobar los datos ingresados del usuario, con los de la DB
        Dim accesoDenegado As Boolean = True
        Dim conexion As New Conexion()
        Dim tipoUsuario As String = ""

        Dim resultadosPersistencia As Object = PersistenciaUsuario.Login(frm.txtCi.Text, frm.txtContraseña.Text)
        Dim reader As MySqlDataReader = resultadosPersistencia(0)
        While reader.Read()
            If Not reader("AprobacionUsuario") Then
                MsgBox("Acceso no autorizado" & vbCrLf & "El administrador aún debe confirmar su registro", MsgBoxStyle.Information, "Minerva · Registro a confirmar")
                frm.lblDatosInc.Text = "Cuenta no autorizada"
                frm.pnlError.Visible = True
                frm.Cursor = Cursors.Default
                Return
            End If
            tipoUsuario = reader("TipoUsuario")
            accesoDenegado = False
        End While
        reader.Close()
        resultadosPersistencia(1).Close()

        frm.Cursor = Cursors.Default
        If accesoDenegado Then
            frm.lblDatosInc.Text = "Datos incorrectos!"
            frm.pnlError.Visible = True
        Else
            Dim minerva As New frmMain(False, frm.txtCi.Text, tipoUsuario)

            minerva.Show()
            minerva.BringToFront()
            frm.Hide()
        End If
    End Sub

    Public Shared Sub Registro(ByVal frm As frmRegistro)
        Dim cantidadAdministradores As Integer = PersistenciaUsuario.CantAdministradores()

        Try
            PersistenciaPersona.Add(frm.txtCi.Text)
            Dim UsuarioAprobado As Boolean = False
            Dim TipoUsuario As String = ""
            If cantidadAdministradores <= 0 Then
                UsuarioAprobado = True
                TipoUsuario = "Administrador"
            Else
                If frm.radFuncionario.Checked Then
                    TipoUsuario = "Funcionario"
                ElseIf frm.radAdscripto.Checked Then
                    TipoUsuario = "Adscripto"
                ElseIf frm.radAdministrador.Checked Then
                    TipoUsuario = "Administrador"
                End If
                UsuarioAprobado = False
            End If
            PersistenciaUsuario.Add(frm.txtCi.Text, TipoUsuario, frm.txtContraseña.Text, UsuarioAprobado)

            If cantidadAdministradores <= 0 Then
                MsgBox("Gracias por registrarse. " & vbCrLf & "Usted ha sido registrado automáticamente como administrador." & vbCrLf & "Ya puede acceder al sistema utilizando sus datos.", MsgBoxStyle.Information, "Minerva · Confirmación de registro")
            Else
                MsgBox("Gracias por registrarse. " & vbCrLf & "El administrador deberá confirmar su registro", MsgBoxStyle.Information, "Minerva · Confirmación de registro")
            End If
            frm.Hide()
            frmIngresarRegistro.Show()
            frmIngresarRegistro.BringToFront()
            frm.Dispose()
        Catch ex As Exception
            frm.pnlError.Visible = True
        End Try
    End Sub

End Class
