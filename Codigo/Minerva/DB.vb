Imports MySql.Data.MySqlClient ' Importa el módulo de MySQL
Imports System.Data

Public Class DB
    ' Define la conexión como variable pública
    Friend Conn As MySqlConnection

    Public Sub New()
        ' Al crear la clase, generar la conexión, y abrirla
        Try
            Conn = New MySqlConnection("server=localhost;uid=minerva;password=minerva;database=Minerva")
            Conn.Open()
        Catch ex As Exception
            ' En caso de error mostrar un mensaje y salir
            System.Console.WriteLine(ex)
            MsgBox("Error al establecer la conexión con el servidor", MsgBoxStyle.Critical)
            Environment.Exit(0)
        End Try
    End Sub

    Public Sub Close()
        ' Cierra la conexión
        Conn.Close()
    End Sub
End Class

Public Class DBB
    Public Sub Login_frmLogin(ByVal frm As frmLogin)
        ' Se encarga de comprobar los datos ingresados del usuario, con los de la DB
        Dim accesoDenegado As Boolean = True
        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Usuario` WHERE CiPersona=@ID AND ContraseñaUsuario=@Contraseña;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@ID", frm.txtUsuario.Text)
                .Parameters.AddWithValue("@Contraseña", frm.txtContraseña.Text)
                frm.cuentaUsuario = frm.txtUsuario.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                If Not reader("AprobacionUsuario") Then
                    MsgBox("Acceso no autorizado" & vbCrLf & "El administrador aún debe confirmar su registro", MsgBoxStyle.Information, "Minerva · Registro a confirmar")
                    frm.lblDatosInc.Text = "Cuenta no autorizada"
                    frm.pnlError.Visible = True
                    Return
                End If
                If reader("TipoUsuario").Equals("Administrador") Then
                    frm.administrador = True
                Else
                    frm.administrador = False
                End If
                accesoDenegado = False
            End While
            reader.Close()
            conexion.Close()
        End Using

        If accesoDenegado Then
            frm.lblDatosInc.Text = "Datos incorrectos!"
            frm.pnlError.Visible = True
        Else
            Dim minerva As New frmMain(False, frm.administrador)
            minerva.Show()
            frm.Hide()
        End If
    End Sub

    Public Sub Registro_frmRegistro(ByVal frm As frmRegistro)
        ' Se encarga de efectuar la conexión a la DB y registrar al usuario en la misma
        Dim conexion As New DB()
        Dim cantidadAdministradores As Integer

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "select COUNT(*) as 'Cantidad' from Usuario WHERE Usuario.TipoUsuario='Administrador';"
                .CommandType = CommandType.Text
            End With
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                cantidadAdministradores = Integer.Parse(reader("Cantidad"))
            End While
            reader.Close()
        End Using

        Try
            Using cmd As New MySqlCommand()
                With cmd
                    .Connection = conexion.Conn
                    .CommandText = "INSERT INTO `Persona` VALUES (@CiPersona, NULL, NULL);"
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@CiPersona", frm.txtUsuario.Text)
                End With
                cmd.ExecuteNonQuery()
            End Using

            Using cmd As New MySqlCommand()
                With cmd
                    .Connection = conexion.Conn
                    .CommandText = "INSERT INTO `Usuario` VALUES (@CiPersona, NULL, NULL, @TipoUsuario, @ContraseñaUsuario, @AprobacionUsuario);"
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@CiPersona", Integer.Parse(frm.txtUsuario.Text))
                    .Parameters.AddWithValue("@ContraseñaUsuario", frm.txtContraseña.Text)
                    If cantidadAdministradores <= 0 Then
                        .Parameters.AddWithValue("@AprobacionUsuario", True) ' Habilitada
                        .Parameters.AddWithValue("@TipoUsuario", "Administrador") ' Admin
                    Else
                        .Parameters.AddWithValue("@AprobacionUsuario", False) ' No está habilitada
                        .Parameters.AddWithValue("@TipoUsuario", "Funcionario") ' No es admin
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
                    frm.Hide()
                    frmIngresarRegistro.Show()
                    frm.Dispose()
                Catch ex As Exception
                    frm.pnlError.Visible = True
                    Console.WriteLine(ex.ToString())
                    conexion.Close()
                End Try
            End Using

        Catch ex As Exception
            Console.WriteLine(ex.ToString())
            frm.pnlError.Visible = True
            conexion.Close()
        End Try
    End Sub

    Public Sub cargarDatos_frmMain(Byval frm as frmMain)
        Dim conexion As New DB()
        ' Carga los grupos al combo
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT *, Turno.NombreTurno from `Grupo`, `Turno` where Grupo.IdTurno=Turno.IdTurno;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                frm.cboGrupo.Items.Add(reader("Grado").ToString() & " " & reader("IdGrupo") & " (" & reader("NombreTurno") & ")")
            End While
            reader.Close()
        End Using
    End Sub

    Public Sub cargarSalones_frmAdminSalones(ByVal frm as frmAdminSalones)
        ' Carga los salones y los pone en la lista
        frm.pnlSalones.Controls.Clear()
        frm.totalSalones = 0
        frm.lblCantidadSalones.Text = "(" + frm.totalSalones.ToString() + ")"

        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Salon`;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                If reader("IdSalon").Equals(-1) Then
                    Continue While
                End If
                frm.agregarSalon(reader("IdSalon"))
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Public Sub guardarSalones_frmAdminSalones(ByVal frm as frmAdminSalones)
        ' Guardo los horarios del salón.
        Dim conexionSalones As New DB()
        Dim txtSalon As String = frm.txtIDSalon.Text
        For Turno As Integer = 1 To 5
            Using cmd As New MySqlCommand()
                With cmd
                    .Connection = conexionSalones.Conn
                    .CommandText = "UPDATE `Grupo` SET IdSalon=@IdSalon WHERE IdGrupo=@IdGrupo and IdTurno=@IdTurno and Grado=@Grado;"
                    .CommandType = CommandType.Text

                    If Turno = 1 Then
                        If frm.cmbTurno1.Text.Equals("Sin asignar") Then
                            ' txtSalon = "-1"
                            Continue For
                        End If
                        .Parameters.AddWithValue("@IdGrupo", frm.cmbTurno1.Text.Substring(frm.cmbTurno1.Text.IndexOf(" "), frm.cmbTurno1.Text.Length - 1).Trim())
                        .Parameters.AddWithValue("@Grado", Integer.Parse(frm.cmbTurno1.Text.Substring(0, frm.cmbTurno1.Text.IndexOf(" ")).Trim()))
                    ElseIf Turno = 2 Then
                        If frm.cmbTurno2.Text.Equals("Sin asignar") Then
                            ' txtSalon = "-1"
                            Continue For
                        End If
                        .Parameters.AddWithValue("@IdGrupo", frm.cmbTurno2.Text.Substring(frm.cmbTurno2.Text.IndexOf(" "), frm.cmbTurno2.Text.Length - 1).Trim())
                        .Parameters.AddWithValue("@Grado", Integer.Parse(frm.cmbTurno2.Text.Substring(0, frm.cmbTurno2.Text.IndexOf(" ")).Trim()))
                    ElseIf Turno = 3 Then
                        If frm.cmbTurno3.Text.Equals("Sin asignar") Then
                            ' txtSalon = "-1"
                            Continue For
                        End If
                        .Parameters.AddWithValue("@IdGrupo", frm.cmbTurno3.Text.Substring(frm.cmbTurno3.Text.IndexOf(" "), frm.cmbTurno3.Text.Length - 1).Trim())
                        .Parameters.AddWithValue("@Grado", Integer.Parse(frm.cmbTurno3.Text.Substring(0, frm.cmbTurno3.Text.IndexOf(" ")).Trim()))
                    ElseIf Turno = 4 Then
                        If frm.cmbTurno4.Text.Equals("Sin asignar") Then
                            ' txtSalon = "-1"
                            Continue For
                        End If
                        .Parameters.AddWithValue("@IdGrupo", frm.cmbTurno4.Text.Substring(frm.cmbTurno4.Text.IndexOf(" "), frm.cmbTurno4.Text.Length - 1).Trim())
                        .Parameters.AddWithValue("@Grado", Integer.Parse(frm.cmbTurno4.Text.Substring(0, frm.cmbTurno4.Text.IndexOf(" ")).Trim()))
                    ElseIf Turno = 5 Then
                        If frm.cmbTurno5.Text.Equals("Sin asignar") Then
                            ' txtSalon = "-1"
                            Continue For
                        End If
                        .Parameters.AddWithValue("@IdGrupo", frm.cmbTurno5.Text.Substring(frm.cmbTurno5.Text.IndexOf(" "), frm.cmbTurno5.Text.Length - 1).Trim())
                        .Parameters.AddWithValue("@Grado", Integer.Parse(frm.cmbTurno5.Text.Substring(0, frm.cmbTurno5.Text.IndexOf(" ")).Trim()))
                    End If
                    .Parameters.AddWithValue("@IdTurno", Turno)
                    .Parameters.AddWithValue("@IdSalon", txtSalon)
                End With

                cmd.ExecuteNonQuery()
            End Using
        Next

        conexionSalones.Close()
    End Sub

    Public Sub cargarGrupos_frmAdminSalones(ByVal frm as frmAdminSalones)
        ' Carga los grupos al combo
        Dim conexion As New DB()
        For Turno As Integer = 0 To 5
            Using cmd As New MySqlCommand()
                With cmd
                    .Connection = conexion.Conn
                    .CommandText = "SELECT * from `Grupo` WHERE `IdTurno`=@IdTurno;"
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@IdTurno", Turno.ToString())
                End With

                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    ' Too lazy to fix this hehe
                    If Turno = 1 Then
                        frm.cmbTurno1.Items.Add(reader("Grado").ToString() & " " & reader("IdGrupo"))
                    ElseIf Turno = 2 Then
                        frm.cmbTurno2.Items.Add(reader("Grado").ToString() & " " & reader("IdGrupo"))
                    ElseIf Turno = 3 Then
                        frm.cmbTurno3.Items.Add(reader("Grado").ToString() & " " & reader("IdGrupo"))
                    ElseIf Turno = 4 Then
                        frm.cmbTurno4.Items.Add(reader("Grado").ToString() & " " & reader("IdGrupo"))
                    ElseIf Turno = 5 Then
                        frm.cmbTurno5.Items.Add(reader("Grado").ToString() & " " & reader("IdGrupo"))
                    End If
                End While
                reader.Close()
            End Using
        Next
        conexion.Close()
    End Sub

    Public Sub actualizarDB_frmAdminSalones(ByVal frm as frmAdminSalones)
        ' Agrega o actualiza los datos del salón en la DB
        Dim conexion As New DB()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text

                If frm.btnAgregar.Text.Equals("Agregar salón") Then
                    .CommandText = "INSERT INTO `Salon` VALUES (@IdSalon, @ComentariosSalon, @PlantaSalon);"
                Else
                    .CommandText = "UPDATE `Salon` SET ComentariosSalon=@ComentariosSalon, PlantaSalon=@PlantaSalon WHERE IDSalon=@IDSalon;"
                End If

                .Parameters.AddWithValue("@IdSalon", frm.txtIDSalon.Text)
                .Parameters.AddWithValue("@ComentariosSalon", frm.txtComentarios.Text)
                .Parameters.AddWithValue("@PlantaSalon", frm.cmbPlanta.Text)
            End With

            Try
                cmd.ExecuteNonQuery()
                conexion.Close()
                frm.guardarSalones()
                frm.cargarSalones()
                If frm.btnAgregar.Text.Equals("Agregar salón") Then
                    MessageBox.Show("Salón agregado correctamente", "Salón agregado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Else
                    MessageBox.Show("Información de salón actualizada correctamente", "Salón actualizado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
                frm.previsualizarSalon(frm.txtIDSalon.Text)
            Catch ex As Exception
                If ex.ToString().Contains("Duplicate") Then
                    MessageBox.Show("Ya existe un salón con ese ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Try
        End Using
    End Sub

    Public Sub cargarDatos_frmAdminSalones(ByVal idSalon As String, ByVal frm As frmAdminSalones)
        ' Carga los datos de un salón
        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Salon` where IdSalon=@IdSalon;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IdSalon", idSalon)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                frm.txtIDSalon.Text = reader("IdSalon")
                frm.txtComentarios.Text = reader("ComentariosSalon").ToString()
                frm.cmbPlanta.SelectedIndex = frm.cmbPlanta.FindStringExact(reader("PlantaSalon"))
            End While
            reader.Close()
            conexion.Close()
        End Using

        Dim conexionSalones As New DB()
        ' Carga los horarios del salón.
        For Turno As Integer = 1 To 5
            Using cmd As New MySqlCommand()
                With cmd
                    .Connection = conexionSalones.Conn
                    .CommandText = "SELECT Grupo.IdGrupo, Grupo.Grado FROM `Salon`, `Grupo` WHERE Salon.IdSalon=Grupo.IdSalon and Grupo.IdTurno=@IdTurno and Salon.IdSalon=@IdSalon;"
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@IdSalon", idSalon)
                    .Parameters.AddWithValue("@IdTurno", Turno)
                End With

                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    ' Too lazy to fix this hehe
                    If Turno = 1 Then
                        frm.cmbTurno1.SelectedIndex = frm.cmbTurno1.FindStringExact(reader("Grado").ToString() & " " & reader("IdGrupo"))
                    ElseIf Turno = 2 Then
                        frm.cmbTurno2.SelectedIndex = frm.cmbTurno2.FindStringExact(reader("Grado").ToString() & " " & reader("IdGrupo"))
                    ElseIf Turno = 3 Then
                        frm.cmbTurno3.SelectedIndex = frm.cmbTurno3.FindStringExact(reader("Grado").ToString() & " " & reader("IdGrupo"))
                    ElseIf Turno = 4 Then
                        frm.cmbTurno4.SelectedIndex = frm.cmbTurno4.FindStringExact(reader("Grado").ToString() & " " & reader("IdGrupo"))
                    ElseIf Turno = 5 Then
                        frm.cmbTurno5.SelectedIndex = frm.cmbTurno5.FindStringExact(reader("Grado").ToString() & " " & reader("IdGrupo"))
                    End If
                End While
                reader.Close()
            End Using
        Next
        conexionSalones.Close()
    End Sub

    Public Sub eliminarSalon_frmAdminSalones(ByVal sender As System.Object, ByVal frm As frmAdminSalones)
        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM `Salon` WHERE IdSalon=@IdSalon;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IdSalon", sender.Tag)
            End With
            frm.totalSalones -= 1
            Try
                cmd.ExecuteNonQuery()
                conexion.Close() 'Cierra la conexión
                frm.cargarSalones()
                frm.btnNuevoSalon_Click(Nothing, Nothing)
                MessageBox.Show("Salón '" + sender.tag + "' eliminado.", "Salón eliminado.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("El salón no se puede eliminar, ya que está asignado a un grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Public Sub cargarUsuarios_frmAdminUsuarios(ByVal frm As frmAdminUsuarios)
        ' Carga los usuarios a la lista de usuarios
        Dim conexion As New DB()
        frm.pnlUsuarios.Controls.Clear()
        frm.totalUsuarios = 0
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Usuario`;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                frm.agregarUsuario(reader("CiPersona"), reader("TipoUsuario"))
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Public Sub eliminarUsuario_frmAdminUsuarios(sender As Object, ByVal frm As frmAdminUsuarios)
        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM `Usuario` WHERE CiPersona=@CiPersona;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@CiPersona", sender.Tag(0))
            End With

            cmd.ExecuteNonQuery()
        End Using

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM `Persona` WHERE CiPersona=@CiPersona;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@CiPersona", sender.Tag(0))
            End With

            cmd.ExecuteNonQuery()
            conexion.Close() 'Cierra la conexión
            frm.cargarUsuarios()
            frm.nuevoUsuario(Nothing, Nothing)
            MessageBox.Show("Usuario '" + sender.Tag(1) + "' eliminado.", "Usuario eliminado.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
    End Sub

    Public Sub cargarDatos_frmAdminUsuarios(ByVal ID As String, ByVal frm As frmAdminUsuarios)
        ' Carga los datos del usuario y los muestra en pantalla
        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Usuario` WHERE CiPersona=@CiPersona;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@CiPersona", ID)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                frm.txtID.Text = reader("CiPersona")
                frm.txtContraseña.Text = reader("ContraseñaUsuario")
                frm.chkHabilitado.Checked = reader("AprobacionUsuario")
                frm.usuarioHabilitado = reader("AprobacionUsuario")
                frm.tipoSeleccionado = reader("TipoUsuario")
                If reader("TipoUsuario").Equals("Funcionario") Then
                    frm.radFuncionario.Checked = True
                Else
                    frm.radAdministrador.Checked = True
                End If
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Public Sub actualizarDB_frmAdminUsuarios(ByVal frm As frmAdminUsuarios)
        ' Guarda o edita los datos del usuario a la DB
        Dim conexion As New DB()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text

                If frm.btnAgregar.Text.Equals("Agregar usuario") Then
                    .CommandText = "INSERT INTO `Usuario` VALUES (@CiPersona, NULL, NULL, @TipoUsuario, @ContraseñaUsuario, @AprobacionUsuario);"
                Else
                    .CommandText = "UPDATE `Usuario` SET TipoUsuario=@TipoUsuario, ContraseñaUsuario=@ContraseñaUsuario, AprobacionUsuario=@AprobacionUsuario WHERE CiPersona=@CiPersona;"
                End If

                .Parameters.AddWithValue("@CiPersona", frm.txtID.Text)
                .Parameters.AddWithValue("@ContraseñaUsuario", frm.txtContraseña.Text)
                .Parameters.AddWithValue("@AprobacionUsuario", frm.chkHabilitado.Checked)
                .Parameters.AddWithValue("@TipoUsuario", frm.tipoSeleccionado)
            End With

            Try
                If frm.btnAgregar.Text.Equals("Agregar usuario") Then
                    Dim subConexion As New DB()
                    Using subCmd As New MySqlCommand()
                        With subCmd
                            .Connection = subConexion.Conn
                            .CommandText = "INSERT INTO `Persona` VALUES (@CiPersona, NULL, NULL);"
                            .CommandType = CommandType.Text
                            .Parameters.AddWithValue("@CiPersona", frm.txtID.Text)
                        End With
                        subCmd.ExecuteNonQuery()
                    End Using
                End If

                cmd.ExecuteNonQuery()
                conexion.Close()
                If frm.btnAgregar.Text.Equals("Agregar usuario") Then
                    MessageBox.Show("Usuario agregado correctamente", "Usuario agregado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Else
                    MessageBox.Show("Información de usuario actualizada correctamente", "Usuario actualizado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
                frm.cargarUsuarios()
                frm.nuevoUsuario(Nothing, Nothing)
            Catch ex As Exception
                If ex.ToString().Contains("Duplicate") Then
                    MessageBox.Show("Ya existe un usuario (o profesor!) con ese ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Try
        End Using
    End Sub

    Public Sub cargarGrupos_frmAdminGrupos(ByVal frm As frmAdminGrupos)
        ' Carga los grupos a la lista de grupos
        frm.pnlGrupos.Controls.Clear()
        frm.totalGrupos = 0
        frm.lblCantidadGrupos.Text = "(" + frm.totalGrupos.ToString() + ")"

        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT *, Turno.NombreTurno FROM `Grupo`, `Turno` WHERE Grupo.IdTurno=Turno.IdTurno;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                frm.agregarGrupo(reader("IdGrupo"), reader("Grado").ToString(), reader("IdTurno"), reader("Grado").ToString() & " " & reader("IdGrupo") & ControlChars.NewLine & " (" & reader("NombreTurno") & ")", reader("NombreTurno"))
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Public Sub cargarOrientaciones_frmAdminGrupos(ByVal frm As frmAdminGrupos)
        ' carga las orientaciones a los combobox
        Dim conexion As New DB()
        frm.cmbOrientacion.Items.Clear()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Orientacion` WHERE IdCurso=@IdCurso;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IdCurso", frm.cmbCurso.Text.Substring(0, frm.cmbCurso.Text.IndexOf(" (")).Trim())
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                frm.cmbOrientacion.Items.Add(reader("IdOrientacion").ToString() & " (" & reader("NombreOrientacion") & ")")
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Public Sub rellenarCombos_frmAdminGrupos(ByVal frm As frmAdminGrupos)
        ' Llena los combos con los datos de la DB.
        Dim conexion As New DB()

        ' Primero los cursos
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Curso`;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                frm.cmbCurso.Items.Add(reader("IdCurso").ToString() & " (" & reader("NombreCurso") & ")")
            End While
            reader.Close()
        End Using

        ' Segundo los turnos
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Turno`;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                frm.cmbTurno.Items.Add(reader("NombreTurno"))
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Public Sub cargarDatos_frmAdminGrupos(ByVal grupo As Object, ByVal frm As frmAdminGrupos)
        ' carga los datos del grupo y los coloca en la interfaz
        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT *, Curso.NombreCurso, Orientacion.NombreOrientacion FROM `Grupo`, `Curso`, `Orientacion` WHERE Grupo.IdGrupo=@IdGrupo and Grupo.IdTurno=@IdTurno and Grupo.Grado=@Grado and Orientacion.IdOrientacion=Grupo.IdOrientacion;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IdGrupo", grupo(0))
                .Parameters.AddWithValue("@Grado", grupo(1))
                .Parameters.AddWithValue("@IdTurno", grupo(2))
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                frm.txtIDGrupo.Text = reader("IdGrupo")
                frm.numGrado.Value = Integer.Parse(reader("Grado"))
                frm.cmbCurso.SelectedIndex = frm.cmbCurso.FindStringExact(reader("IDCurso").ToString() & " (" & reader("NombreCurso") & ")")
                frm.cargarOrientaciones()
                frm.chkDiscapacitado.Checked = reader("Discapacitado")
                frm.cmbTurno.SelectedIndex = reader("IDTurno") - 1
                frm.cmbOrientacion.SelectedIndex = frm.cmbOrientacion.FindStringExact(reader("IdOrientacion").ToString() & " (" & reader("NombreOrientacion") & ")")
                frm.cmbOrientacion.Enabled = False
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Public Sub actualizarDB_frmAdminGrupos(ByVal frm As frmAdminGrupos)
        ' Agrega un salón a la base de datos
        Dim conexion As New DB()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO `Grupo` VALUES (@IdGrupo, @Discapacitado, @Grado, @IDOrientacion, -1, @IdTurno);"

                .Parameters.AddWithValue("@IDGrupo", frm.txtIDGrupo.Text)
                .Parameters.AddWithValue("@Discapacitado", frm.chkDiscapacitado.Checked)
                .Parameters.AddWithValue("@Grado", frm.numGrado.Value)
                .Parameters.AddWithValue("@IdOrientacion", frm.cmbOrientacion.Text.Substring(0, frm.cmbOrientacion.Text.IndexOf(" (")).Trim())
                .Parameters.AddWithValue("@IdTurno", frm.cmbTurno.SelectedIndex + 1)
            End With

            Try
                cmd.ExecuteNonQuery()
                conexion.Close()

                frm.cargarGrupos()
                MessageBox.Show("Grupo agregado correctamente", "Grupo agregado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                frm.btnNuevoGrupo_Click(Nothing, Nothing)
            Catch ex As Exception
                If ex.ToString().Contains("Duplicate") Then
                    MessageBox.Show("Ya existe un grupo con el mismo trayecto y ID en dicho turno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                Console.WriteLine(ex.ToString())
            End Try
        End Using
    End Sub

    Public Sub eliminarGrupo_frmAdminGrupos(ByVal sender As System.Object, ByVal frm As frmAdminGrupos)
        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM `Grupo` WHERE IdGrupo=@IDGrupo and IdTurno=@IDTurno and Grado=@Grado;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IdGrupo", sender.Tag(0))
                .Parameters.AddWithValue("@IdTurno", sender.Tag(2))
                .Parameters.AddWithValue("@Grado", sender.Tag(1))
            End With
            frm.totalGrupos -= 1
            cmd.ExecuteNonQuery()
            conexion.Close() 'Cierra la conexión
            frm.cargarGrupos()
            frm.btnNuevoGrupo_Click(Nothing, Nothing)
            MessageBox.Show("Grupo '" + sender.Tag(4) + "' eliminado.", "Grupo eliminado.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
    End Sub

    Public Sub cargarTurnos_frmAdminGrupos(ByVal frm As frmAdminGrupos)
        ' carga las orientaciones a los combobox
        Dim conexion As New DB()
        frm.cmbTurno.Items.Clear()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Turno`;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                frm.cmbTurno.Items.Add(reader("NombreTurno").ToString())
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub
End Class