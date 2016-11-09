Imports MySql.Data.MySqlClient

Public Class Usuario
    Public Shared Sub Login(frm As frmLogin)
        ' Se encarga de comprobar los datos ingresados del usuario, con los de la DB
        Dim accesoDenegado As Boolean = True
        Dim conexion As New Conexion()
        Dim tipoUsuario As String = ""

        Dim resultadosPersistencia As Object = PersistenciaUsuarios.Login(frm.txtCi.Text, frm.txtContraseña.Text)
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

    Public Shared Sub Registro(frm As frmRegistro)
        Dim cantidadAdministradores As Integer = PersistenciaUsuarios.CantAdministradores()

        Try
            PersistenciaPersonas.Add(frm.txtCi.Text)
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
            PersistenciaUsuarios.Add(frm.txtCi.Text, TipoUsuario, frm.txtContraseña.Text, UsuarioAprobado)

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

    Public Shared Sub EditarDatos(frm As frmDatosUsuario)
        PersistenciaPersonas.Edit(frm.frmMain.nombreUsuario, frm.txtNombre.Text, frm.txtApellido.Text)
        MessageBox.Show("Información de usuario actualizada correctamente", "Usuario actualizado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        frm.frmMain.BringToFront()
        frm.Dispose()
    End Sub

    Public Shared Sub CargarUsuarios(frm As frmAdminUsuarios)
        frm.pnlUsuarios.Controls.Clear()
        frm.totalUsuarios = 0
        Dim resultadosPersistencia As Object = InformacionDB.GetUsuarios()
        Dim reader As MySqlDataReader = resultadosPersistencia(0)
        While reader.Read()
            If reader("CiPersona").Equals("-1") Then
                Continue While
            End If
            frm.AgregarWidgetUsuario(reader("CiPersona"), reader("TipoUsuario"), reader("AprobacionUsuario"))
        End While
        reader.Close()
        resultadosPersistencia(1).Close()
    End Sub

    Public Shared Sub EliminarUsuario(Ci As String, frm As frmAdminUsuarios)
        Dim resultadosPersistenciaBackup As Object = PersistenciaUsuarios.GetInfo(Ci)
        Dim readerBackup As MySqlDataReader = resultadosPersistenciaBackup(0)

        Try
            PersistenciaUsuarios.Del(Ci)
            PersistenciaPersonas.Del(Ci)
            MessageBox.Show("Usuario '" + Ci + "' eliminado.", "Usuario eliminado.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CargarUsuarios(frm)
            frm.InterfazNuevoUsuario()
        Catch ex As Exception
            While readerBackup.Read()
                PersistenciaUsuarios.Add(readerBackup("CiPersona"), readerBackup("TipoUsuario"), readerBackup("ContraseniaUsuario"), readerBackup("AprobacionUsuario"))
            End While
            MessageBox.Show("El adscripto está asignado a un grupo, no se puede eliminar.", "Error al eliminar adscripto", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

        readerBackup.Close()
        resultadosPersistenciaBackup(1).Close()
    End Sub

    Public Shared Sub CargarDatos(Ci As String, frm As frmAdminUsuarios)
        Dim resultadosPersistencia As Object = PersistenciaUsuarios.GetInfo(Ci)
        Dim reader As MySqlDataReader = resultadosPersistencia(0)

        While reader.Read()
            frm.txtID.Text = reader("CiPersona")
            frm.txtContraseña.Text = reader("ContraseniaUsuario")
            frm.chkHabilitado.Checked = reader("AprobacionUsuario")
            frm.tipoSeleccionado = reader("TipoUsuario")
            Try
                frm.txtNombre.Text = reader("NombrePersona")
                frm.txtApellido.Text = reader("ApellidoPersona")
            Catch ex As Exception
                frm.txtNombre.Text = ""
                frm.txtApellido.Text = ""
            End Try
            If reader("TipoUsuario").Equals("Funcionario") Then
                frm.radFuncionario.Checked = True
            ElseIf reader("TipoUsuario").Equals("Administrador") Then
                frm.radAdministrador.Checked = True
            ElseIf reader("TipoUsuario").Equals("Adscripto") Then
                frm.radAdscripto.Checked = True
            End If
        End While

        reader.Close()
        resultadosPersistencia(1).Close()
    End Sub

    Public Shared Sub ActualizarDB(frm As frmAdminUsuarios)
        Dim CiPersona As String = frm.txtID.Text
        Dim ContraseniaUsuario As String = frm.txtContraseña.Text
        Dim AprobacionUsuario As Boolean = frm.chkHabilitado.Checked
        Dim Tipousuario As String = frm.tipoSeleccionado
        Dim NombrePersona As String = frm.txtNombre.Text
        Dim ApellidoPersona As String = frm.txtApellido.Text

        If frm.btnAgregar.Text.Equals("Agregar usuario") Then
            Try
                PersistenciaPersonas.Add(CiPersona, NombrePersona, ApellidoPersona)
                PersistenciaUsuarios.Add(CiPersona, Tipousuario, ContraseniaUsuario, AprobacionUsuario)
                MessageBox.Show("Usuario agregado correctamente", "Usuario agregado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                CargarUsuarios(frm)
                frm.InterfazNuevoUsuario()
            Catch ex As Exception
                If ex.ToString().Contains("Duplicate") Then
                    MessageBox.Show("Ya existe un usuario (o profesor!) con ese ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Try
        Else
            PersistenciaPersonas.Edit(CiPersona, NombrePersona, ApellidoPersona)
            PersistenciaUsuarios.Edit(CiPersona, Tipousuario, ContraseniaUsuario, AprobacionUsuario)
            MessageBox.Show("Información de usuario actualizada correctamente", "Usuario actualizado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            CargarUsuarios(frm)
            frm.InterfazNuevoUsuario()
        End If
    End Sub

    Public Shared Sub ContUsuariosNoAprobados(frm As frmMain)
        If Not frm.tipoUsuario.Equals("Administrador") Then
            frm.alertaAprobacion.Visible = False
            Return
        End If

        Dim cantidadAprobar As Integer = PersistenciaUsuarios.CantSinAprobar()

        If cantidadAprobar = 1 Then
            frm.lblCantidadUsuariosAprobacion.Text = "1 usuario está esperando la aprobación de un administrador para poder ingresar."
        Else
            frm.lblCantidadUsuariosAprobacion.Text = cantidadAprobar & " usuarios están esperando la aprobación de un administrador para poder ingresar."
        End If
        If cantidadAprobar <= 0 Then
            frm.alertaAprobacion.Visible = False
        Else
            frm.alertaAprobacion.Visible = True
            If cantidadAprobar = 1 Then
                frm.alertaAprobacion.BackgroundImage = notificacion_1
            ElseIf cantidadAprobar = 2 Then
                frm.alertaAprobacion.BackgroundImage = notificacion_2
            ElseIf cantidadAprobar = 3 Then
                frm.alertaAprobacion.BackgroundImage = notificacion_3
            ElseIf cantidadAprobar = 4 Then
                frm.alertaAprobacion.BackgroundImage = notificacion_4
            ElseIf cantidadAprobar = 5 Then
                frm.alertaAprobacion.BackgroundImage = notificacion_5
            ElseIf cantidadAprobar = 6 Then
                frm.alertaAprobacion.BackgroundImage = notificacion_6
            ElseIf cantidadAprobar = 7 Then
                frm.alertaAprobacion.BackgroundImage = notificacion_7
            ElseIf cantidadAprobar = 8 Then
                frm.alertaAprobacion.BackgroundImage = notificacion_8
            ElseIf cantidadAprobar = 9 Then
                frm.alertaAprobacion.BackgroundImage = notificacion_9
            ElseIf cantidadAprobar = 10 Then
                frm.alertaAprobacion.BackgroundImage = notificacion_10
            ElseIf cantidadAprobar >= 10 Then
                frm.alertaAprobacion.BackgroundImage = notificacion_max
            End If
        End If
    End Sub
End Class
