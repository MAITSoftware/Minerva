Imports MySql.Data.MySqlClient ' Importa el módulo de MySQL
Imports System.Data

Public Class Conexion
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
        Conn.Dispose()
    End Sub
End Class

Public Class BaseDeDatos
    Public Sub Login_frmLogin(ByVal frm As frmLogin)
        ' Se encarga de comprobar los datos ingresados del usuario, con los de la DB
        Dim accesoDenegado As Boolean = True
        Dim conexion as New Conexion()
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
                    frm.Cursor = Cursors.Default
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

        frm.Cursor = Cursors.Default
        If accesoDenegado Then
            frm.lblDatosInc.Text = "Datos incorrectos!"
            frm.pnlError.Visible = True
        Else
            Dim minerva As New frmMain(False, frm.cuentaUsuario, frm.administrador)
            minerva.Show()
            frm.Hide()
        End If
    End Sub

    Public Sub Registro_frmRegistro(ByVal frm As frmRegistro)
        ' Se encarga de efectuar la conexión a la DB y registrar al usuario en la misma
        Dim conexion as New Conexion()
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
                    .Parameters.AddWithValue("@CiPersona", frm.txtUsuario.Text)
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
                    frmIngresarRegistro.BringToFront()
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

    Public Sub setDatos_frmDatosUsuario(ByVal frm As frmDatosUsuario)
        Dim conexion as New Conexion()
        Dim subConexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text
                .CommandText = "UPDATE `Usuario` SET NombrePersona=@NombrePersona, ApellidoPersona=@ApellidoPersona WHERE CiPersona=@CiPersona;"

                .Parameters.AddWithValue("@CiPersona", frm._frmMain.nombreUsuario)
                .Parameters.AddWithValue("@NombrePersona", frm.txtNombre.Text)
                .Parameters.AddWithValue("@ApellidoPersona", frm.txtApellido.Text)
            End With
            cmd.ExecuteNonQuery()
            conexion.Close()
        End Using

        Using subCmd As New MySqlCommand()
            With subCmd
                .Connection = subConexion.Conn
                .CommandText = "UPDATE `Persona` SET NombrePersona=@NombrePersona, ApellidoPersona=@ApellidoPersona WHERE CiPersona=@CiPersona;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@CiPersona", frm._frmMain.nombreUsuario)
                .Parameters.AddWithValue("@NombrePersona", frm.txtNombre.Text)
                .Parameters.AddWithValue("@ApellidoPersona", frm.txtApellido.Text)
            End With
            subCmd.ExecuteNonQuery()
            subConexion.Close()
        End Using

        MessageBox.Show("Información de usuario actualizada correctamente", "Usuario actualizado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        frm._frmMain.BringToFront()
        frm.Dispose()
    End Sub

    Public Sub cargarNombre_frmMain(ByVal frm As frmMain)
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT NombrePersona, ApellidoPersona from `Usuario` where CiPersona=@CiPersona"
                .Parameters.AddWithValue("@CiPersona", frm.nombreUsuario)
                .CommandType = CommandType.Text
            End With

            Dim nombreElegido = False

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                If String.IsNullOrEmpty(reader("NombrePersona").ToString()) Or String.IsNullOrEmpty(reader("ApellidoPersona").ToString()) Then
                    nombreElegido = False
                Else
                    frm.lblUsuario.Text = "Bienvenido " & reader("NombrePersona") & " " & reader("ApellidoPersona") & "."
                    nombreElegido = True
                End If
            End While
            reader.Close()
            conexion.Close()

            If Not nombreElegido Then
                Try
                    Dim x As New frmDatosUsuario(frm)
                    x.ShowDialog(frm)
                    cargarNombre_frmMain(frm)
                Catch ex As Exception
                    ' El usuario presionó salir.
                End Try
            End If
        End Using
    End Sub

    Public Sub cargarDatos_frmMain(ByVal frm As frmMain)
        Dim conexion As New Conexion()
        frm.cboGrupo.Items.Clear()
        frm.cboGrupo.Items.Add("Elija un grupo")
        frm.cboGrupo.SelectedIndex = 0
        ' Carga los grupos al combo
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT *, Turno.NombreTurno from `Grupo`, `Turno` where Grupo.IdTurno=Turno.IdTurno;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                frm.cboGrupo.Items.Add(reader("Grado").ToString() & " " & reader("IdGrupo"))
            End While
            reader.Close()
        End Using
        conexion.Close()
    End Sub

    Public Sub cargarDatosGrupo_frmMain(ByVal frm As frmMain)
        Dim conexion As New Conexion()
        Dim subconexion As New Conexion()
        frm.tblMaterias.Controls.Clear()

        Dim cmd As MySqlCommand
        cmd = New MySqlCommand()
        cmd.Connection = conexion.Conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select Salon, IdOrientacion, Orientacion, Curso, Grado, IdGrupo, DatosGrupos.NombreTurno, IdTurno, Concat(Grado, ' ', IdGrupo) as Grupo from DatosGrupos, Turno where DatosGrupos.NombreTurno=Turno.NombreTurno;"

        Dim reader As MySqlDataReader = cmd.ExecuteReader()
        Dim idOrientacion As String = ""
        Dim grado As String = ""
        Dim idgrupo As String = ""

        While reader.Read()
            If reader("Grupo").ToString().Equals(frm.cboGrupo.Text) Then
                frm.lblValorTipoCurso.Text = reader("Curso")
                frm.lblValorTipoSalon.Text = reader("Salon")
                If frm.lblValorTipoSalon.Text.Equals("-1") Then
                    frm.lblValorTipoSalon.Text = "Sin asignar"
                End If
                frm.lblValorTipoGrado.Text = reader("Grado")
                frm.lblValorTipoTurno.Text = reader("NombreTurno")
                frm.lblValorTipoTurno.Tag = reader("IdTurno").ToString()
                grado = reader("Grado")
                idgrupo = reader("IdGrupo")
                idOrientacion = reader("IdOrientacion").ToString()
            End If
        End While
        reader.Dispose()

        cmd = New MySqlCommand()
        cmd.Connection = conexion.Conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select Tiene_ta.IdAsignatura, Tiene_Ta.Grado, Tiene_Ta.IdOrientacion, NombreAsignatura from tiene_ta, asignatura where IdOrientacion=@IdOrientacion and Grado=@Grado and Tiene_ta.IdAsignatura=Asignatura.IdAsignatura;"
        cmd.Parameters.AddWithValue("@IdOrientacion", idOrientacion)
        cmd.Parameters.AddWithValue("@Grado", frm.lblValorTipoGrado.Text)
        reader = cmd.ExecuteReader()
        Dim x As Integer = 1
        While reader.Read()
            Dim subcmd As New MySqlCommand()
            subcmd.Connection = subconexion.Conn
            subcmd.CommandType = CommandType.Text
            subcmd.CommandText = "select Tiene_ag.IdAsignatura, tiene_ag.IdGrupo, tiene_ag.Grado, tiene_ag.IdOrientacion, CONCAT(NombrePersona, ' ', ApellidoPersona) as Profesor from Tiene_ag, Persona where IdOrientacion=@IdOrientacion and IdAsignatura=@IdAsignatura and IdGrupo=@IdGrupo and Grado=@Grado and Persona.CiPersona=Tiene_ag.CiPersona;"
            subcmd.Parameters.AddWithValue("@IdOrientacion", idOrientacion)
            subcmd.Parameters.AddWithValue("@IdAsignatura", reader("IdAsignatura"))
            subcmd.Parameters.AddWithValue("@IdGrupo", idgrupo)
            subcmd.Parameters.AddWithValue("@Grado", grado)
            Dim subreader As MySqlDataReader = subcmd.ExecuteReader()
            Dim profesor = "Sin profesor"
            While subreader.Read()
                profesor = subreader("Profesor")
            End While

            Dim lblMateria As New Label
            Dim lblProfesor As New Label

            lblMateria.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            lblProfesor.Font = New Font("Microsoft Sans Serif", 12)
            lblProfesor.Padding = New Padding(0, 0, 0, 5)
            lblMateria.ForeColor = Color.White

            lblMateria.Text = reader("NombreAsignatura").ToString()
            lblProfesor.Text = "         " & profesor


            frm.tblMaterias.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0))
            frm.tblMaterias.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0))
            frm.tblMaterias.Controls.Add(lblMateria, 0, x)
            frm.tblMaterias.Controls.Add(lblProfesor, 0, x + 1)

            lblMateria.AutoSize = True
            lblProfesor.AutoSize = True
            subreader.Dispose()
            x += 2
        End While

        reader.Dispose()
        conexion.Close()
        subconexion.Close()
    End Sub

    Public Sub cargarMateriasGrupo_frmMain(ByVal frm As frmMain)
        Dim conexion As New Conexion()
        Dim reader As MySqlDataReader
        ' Carga los grupos al combo
        Dim dias As Object = {"Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"}
        frm.Cursor = Cursors.WaitCursor
        For Each dia As String In dias
            Using cmd As New MySqlCommand()
                With cmd
                    .Connection = conexion.Conn
                    .CommandText = "select * from Calendario where Dia=@Dia and Grupo=@StringGrupo order by HoraOrden;"
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@Dia", dia)
                    .Parameters.AddWithValue("@StringGrupo", frm.cboGrupo.Text)
                End With

                reader = cmd.ExecuteReader()
                While reader.Read()
                    If reader("Materia").Equals("Sin asignar") Then
                        Continue While
                    End If
                    If dia.Equals("Lunes") Then
                        frm.Lunes.agregarHora(reader("HoraOrden"), reader("Materia"))
                    End If
                    If dia.Equals("Martes") Then
                        frm.Martes.agregarHora(reader("HoraOrden"), reader("Materia"))
                    End If
                    If dia.Equals("Miércoles") Then
                        frm.Miércoles.agregarHora(reader("HoraOrden"), reader("Materia"))
                    End If
                    If dia.Equals("Jueves") Then
                        frm.Jueves.agregarHora(reader("HoraOrden"), reader("Materia"))
                    End If
                    If dia.Equals("Viernes") Then
                        frm.Viernes.agregarHora(reader("HoraOrden"), reader("Materia"))
                    End If
                    If dia.Equals("Sábado") Then
                        frm.Sábado.agregarHora(reader("HoraOrden"), reader("Materia"))
                    End If
                End While
                reader.Close()
            End Using
        Next
        Dim Label As New Label()
        Label.Anchor = AnchorStyles.Left
        Label.Visible = False

        Dim horarios(0) As Object
        If frm.lblValorTipoTurno.Tag.Equals("3") Then
            ReDim horarios(5)
        Else
            ReDim horarios(6)
        End If

        Dim subCmd As New MySqlCommand()
        subCmd.CommandType = CommandType.Text
        subCmd.Connection = conexion.Conn
        subCmd.CommandText = "select DISTINCT HoraInicio, HoraFin from Asignacion where IdTurno=@IdTurno;"
        subCmd.Parameters.AddWithValue("@IdTurno", frm.lblValorTipoTurno.Tag)
        reader = subCmd.ExecuteReader()
        Dim x As Integer = 0
        While reader.Read()
            horarios(x) = reader("HoraInicio").ToString()
            x += 1
        End While
        reader.Close()

        Dim current_dia As Integer
        For Each hora As String In horarios
            Dim row_dia(8) As String
            current_dia = 1
            row_dia(0) = hora.Substring(0, hora.Length - 3)
            For Each dia As String In dias
                Dim testCmd As New MySqlCommand()
                testCmd.CommandText = "select IdAsignatura, Materia, NombreProfesor from (select DISTINCT * from Calendario where HoraInicio=@HoraInicio and Grupo=@Grupo) Resultado where Dia=@Dia;"
                testCmd.CommandType = CommandType.Text
                testCmd.Connection = conexion.Conn
                testCmd.Parameters.AddWithValue("@HoraInicio", hora)
                testCmd.Parameters.AddWithValue("@Grupo", frm.cboGrupo.Text)
                testCmd.Parameters.AddWithValue("@Dia", dia)
                reader = testCmd.ExecuteReader()
                Dim huboResultado As Boolean = False
                While reader.Read()
                    huboResultado = True
                    If reader("IdAsignatura").Equals("-1") Then
                        row_dia(current_dia) = "" & vbCrLf & ""
                        Continue While
                    End If
                    row_dia(current_dia) = reader("Materia") & vbCrLf & reader("NombreProfesor")
                End While
                If Not huboResultado Then
                    row_dia(current_dia) = "Sin definir" & vbCrLf
                End If
                reader.Close()
                current_dia += 1
            Next
            frm.Grilla.dgvMaterias.Rows.Add(row_dia)
        Next

        conexion.Close()
        frm.Cursor = Cursors.Default

    End Sub

    Public Sub cargarSalones_frmAdminSalones(ByVal frm As frmAdminSalones)
        ' Carga los salones y los pone en la lista
        frm.pnlSalones.Controls.Clear()
        frm.totalSalones = 0
        frm.lblCantidadSalones.Text = "(" + frm.totalSalones.ToString() + ")"

        Dim conexion As New Conexion()
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

    Public Sub guardarSalones_frmAdminSalones(ByVal frm As frmAdminSalones)
        Dim conexion As New Conexion()
        Dim subConexion As New Conexion()
        ' Guardo los horarios del salón.
        For Turno As Integer = 1 To 3
            Using cmd As New MySqlCommand()
                With cmd

                    Dim txtSalon As String
                    cmd.Connection = conexion.Conn
                    cmd.CommandText = "UPDATE `Grupo` SET IdSalon=@IdSalon WHERE IdGrupo=@IdGrupo and IdTurno=@IdTurno and Grado=@Grado;"
                    cmd.CommandType = CommandType.Text

                    If Turno = 1 Then
                        If frm.cmbTurno1.Text.Equals("Sin asignar") Then
                            If frm.grupoTurno1(0).Equals("-1") Or frm.grupoTurno1(1).Equals("-1") Then
                                Continue For
                            End If
                            cmd.Parameters.AddWithValue("@Grado", frm.grupoTurno1(0))
                            cmd.Parameters.AddWithValue("@IdGrupo", frm.grupoTurno1(1))
                            txtSalon = "-1"
                        Else
                            If Not (frm.grupoTurno1(0).Equals("-1") Or frm.grupoTurno1(1).Equals("-1")) Then
                                Dim subCmd As New MySqlCommand()
                                subCmd.CommandText = "UPDATE `Grupo` SET IdSalon=@IdSalon WHERE IdGrupo=@IdGrupo and IdTurno=@IdTurno and Grado=@Grado;"
                                subCmd.CommandType = CommandType.Text
                                subCmd.Connection = subConexion.Conn
                                subCmd.Parameters.AddWithValue("@IdSalon", "-1")
                                subCmd.Parameters.AddWithValue("@Grado", frm.grupoTurno1(0))
                                subCmd.Parameters.AddWithValue("@IdGrupo", frm.grupoTurno1(1))
                                subCmd.Parameters.AddWithValue("@IdTurno", 2)
                                subCmd.ExecuteNonQuery()
                            End If
                            cmd.Parameters.AddWithValue("@IdGrupo", frm.cmbTurno1.Text.Substring(frm.cmbTurno1.Text.IndexOf(" "), frm.cmbTurno1.Text.Length - 1).Trim())
                            cmd.Parameters.AddWithValue("@Grado", Integer.Parse(frm.cmbTurno1.Text.Substring(0, frm.cmbTurno1.Text.IndexOf(" ")).Trim()))
                        End If

                    ElseIf Turno = 2 Then
                        If frm.cmbTurno2.Text.Equals("Sin asignar") Then
                            If frm.grupoTurno2(0).Equals("-1") Or frm.grupoTurno2(1).Equals("-1") Then
                                Continue For
                            End If
                            cmd.Parameters.AddWithValue("@Grado", frm.grupoTurno2(0))
                            cmd.Parameters.AddWithValue("@IdGrupo", frm.grupoTurno2(1))
                        Else
                            If Not (frm.grupoTurno2(0).Equals("-1") Or frm.grupoTurno2(1).Equals("-1")) Then
                                Dim subCmd As New MySqlCommand()
                                subCmd.CommandText = "UPDATE `Grupo` SET IdSalon=@IdSalon WHERE IdGrupo=@IdGrupo and IdTurno=@IdTurno and Grado=@Grado;"
                                subCmd.CommandType = CommandType.Text
                                subCmd.Connection = subConexion.Conn
                                subCmd.Parameters.AddWithValue("@IdSalon", "-1")
                                subCmd.Parameters.AddWithValue("@Grado", frm.grupoTurno2(0))
                                subCmd.Parameters.AddWithValue("@IdGrupo", frm.grupoTurno2(1))
                                subCmd.Parameters.AddWithValue("@IdTurno", 2)
                                subCmd.ExecuteNonQuery()
                            End If

                            cmd.Parameters.AddWithValue("@IdGrupo", frm.cmbTurno2.Text.Substring(frm.cmbTurno2.Text.IndexOf(" "), frm.cmbTurno2.Text.Length - 1).Trim())
                            cmd.Parameters.AddWithValue("@Grado", Integer.Parse(frm.cmbTurno2.Text.Substring(0, frm.cmbTurno2.Text.IndexOf(" ")).Trim()))
                        End If
                    ElseIf Turno = 3 Then
                        If frm.cmbTurno3.Text.Equals("Sin asignar") Then
                            If frm.grupoTurno3(0).Equals("-1") Or frm.grupoTurno3(1).Equals("-1") Then
                                Continue For
                            End If
                            cmd.Parameters.AddWithValue("@Grado", frm.grupoTurno3(0))
                            cmd.Parameters.AddWithValue("@IdGrupo", frm.grupoTurno3(1))
                            txtSalon = "-1"
                        Else
                            If Not (frm.grupoTurno3(0).Equals("-1") Or frm.grupoTurno3(1).Equals("-1")) Then
                                Dim subCmd As New MySqlCommand()
                                subCmd.CommandText = "UPDATE `Grupo` SET IdSalon=@IdSalon WHERE IdGrupo=@IdGrupo and IdTurno=@IdTurno and Grado=@Grado;"
                                subCmd.CommandType = CommandType.Text
                                subCmd.Connection = subConexion.Conn
                                subCmd.Parameters.AddWithValue("@IdSalon", "-1")
                                subCmd.Parameters.AddWithValue("@Grado", frm.grupoTurno3(0))
                                subCmd.Parameters.AddWithValue("@IdGrupo", frm.grupoTurno3(1))
                                subCmd.Parameters.AddWithValue("@IdTurno", 2)
                                subCmd.ExecuteNonQuery()
                            End If
                            cmd.Parameters.AddWithValue("@IdGrupo", frm.cmbTurno3.Text.Substring(frm.cmbTurno3.Text.IndexOf(" "), frm.cmbTurno3.Text.Length - 1).Trim())
                            cmd.Parameters.AddWithValue("@Grado", Integer.Parse(frm.cmbTurno3.Text.Substring(0, frm.cmbTurno3.Text.IndexOf(" ")).Trim()))
                        End If
                    End If

                    If frm.cmbTurno1.Text.Equals("Sin asignar") And Turno = 1 Then
                        txtSalon = "-1"
                    ElseIf frm.cmbTurno2.Text.Equals("Sin asignar") And Turno = 2 Then
                        txtSalon = "-1"
                    ElseIf frm.cmbTurno3.Text.Equals("Sin asignar") And Turno = 3 Then
                        txtSalon = "-1"
                    Else
                        txtSalon = frm.txtIDSalon.Text
                    End If

                    cmd.Parameters.AddWithValue("@IdTurno", Turno)
                    cmd.Parameters.AddWithValue("@IdSalon", txtSalon)
                    cmd.ExecuteNonQuery()
                End With
            End Using
        Next
        conexion.Close()
        subconexion.close()
    End Sub

    Public Sub cargarGrupos_frmAdminSalones(ByVal frm As frmAdminSalones)
        ' Carga los grupos al combo
        Dim conexion As New Conexion()
        For Turno As Integer = 1 To 3
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
                    End If
                End While
                reader.Close()
            End Using
        Next
        conexion.Close()
    End Sub

    Public Sub actualizarDB_frmAdminSalones(ByVal frm As frmAdminSalones)
        ' Agrega o actualiza los datos del salón en la DB
        Dim conexion As New Conexion()

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
                conexion.Close()
            End Try
        End Using
    End Sub

    Public Sub cargarDatos_frmAdminSalones(ByVal idSalon As String, ByVal frm As frmAdminSalones)
        ' Carga los datos de un salón
        Dim conexion As New Conexion()
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
        End Using

        ' Carga los horarios del salón.
        frm.grupoTurno1 = {"-1", "-1"}
        frm.grupoTurno2 = {"-1", "-1"}
        frm.grupoTurno3 = {"-1", "-1"}
        For Turno As Integer = 1 To 3
            Using cmd As New MySqlCommand()
                With cmd
                    .Connection = conexion.Conn
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
                        frm.grupoTurno1 = {reader("Grado"), reader("IdGrupo")}
                    ElseIf Turno = 2 Then
                        frm.cmbTurno2.SelectedIndex = frm.cmbTurno2.FindStringExact(reader("Grado").ToString() & " " & reader("IdGrupo"))
                        frm.grupoTurno2 = {reader("Grado"), reader("IdGrupo")}
                    ElseIf Turno = 3 Then
                        frm.cmbTurno3.SelectedIndex = frm.cmbTurno3.FindStringExact(reader("Grado").ToString() & " " & reader("IdGrupo"))
                        frm.grupoTurno3 = {reader("Grado"), reader("IdGrupo")}
                    End If
                End While
                reader.Close()
            End Using
        Next
        conexion.Close()
    End Sub

    Public Sub eliminarSalon_frmAdminSalones(ByVal sender As System.Object, ByVal frm As frmAdminSalones)
        Dim conexion As New Conexion()
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
                frm.cargarSalones()
                frm.btnNuevoSalon_Click(Nothing, Nothing)
                MessageBox.Show("Salón '" + sender.tag + "' eliminado.", "Salón eliminado.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("El salón no se puede eliminar, ya que está asignado a un grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        conexion.Close() 'Cierra la conexión
    End Sub

    Public Sub cargarUsuarios_frmAdminUsuarios(ByVal frm As frmAdminUsuarios)
        ' Carga los usuarios a la lista de usuarios
        Dim conexion As New Conexion()
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
        Dim conexion As New Conexion()
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
        Dim conexion As New Conexion()
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
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text

                If frm.btnAgregar.Text.Equals("Agregar usuario") Then
                    .CommandText = "INSERT INTO `Usuario` VALUES (@CiPersona, @Nombre, @Apellido, @TipoUsuario, @ContraseñaUsuario, @AprobacionUsuario);"
                Else
                    .CommandText = "UPDATE `Usuario` SET NombrePersona=@Nombre, ApellidoPersona=@Apellido, TipoUsuario=@TipoUsuario, ContraseñaUsuario=@ContraseñaUsuario, AprobacionUsuario=@AprobacionUsuario WHERE CiPersona=@CiPersona;"
                End If

                .Parameters.AddWithValue("@CiPersona", frm.txtID.Text)
                .Parameters.AddWithValue("@Nombre", frm.txtNombre.Text)
                .Parameters.AddWithValue("@Apellido", frm.txtApellido.Text)
                .Parameters.AddWithValue("@ContraseñaUsuario", frm.txtContraseña.Text)
                .Parameters.AddWithValue("@AprobacionUsuario", frm.chkHabilitado.Checked)
                .Parameters.AddWithValue("@TipoUsuario", frm.tipoSeleccionado)
            End With

            Try
                If frm.btnAgregar.Text.Equals("Agregar usuario") Then
                    Using subCmd As New MySqlCommand()
                        With subCmd
                            .Connection = conexion.Conn
                            .CommandText = "INSERT INTO `Persona` VALUES (@CiPersona, @Nombre, @Apellido);"
                            .CommandType = CommandType.Text
                            .Parameters.AddWithValue("@CiPersona", frm.txtID.Text)
                            .Parameters.AddWithValue("@Nombre", frm.txtNombre.Text)
                            .Parameters.AddWithValue("@Apellido", frm.txtApellido.Text)
                        End With
                        subCmd.ExecuteNonQuery()
                    End Using
                End If

                cmd.ExecuteNonQuery()
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

        conexion.Close()
    End Sub

    Public Sub cargarGrupos_frmAdminGrupos(ByVal frm As frmAdminGrupos)
        ' Carga los grupos a la lista de grupos
        frm.pnlGrupos.Controls.Clear()
        frm.totalGrupos = 0
        frm.lblCantidadGrupos.Text = "(" + frm.totalGrupos.ToString() + ")"

        Dim conexion As New Conexion()
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

    Public Sub cargarGrados_frmAdminGrupos(ByVal frm As frmAdminGrupos)
        Dim conexion As New Conexion()
        frm.cmbGrado.Items.Clear()
        Try
            Using cmd As New MySqlCommand()
                With cmd
                    .Connection = conexion.Conn
                    .CommandText = "select * from Trayecto where IdOrientacion=@IdOrientacion;"
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@IdOrientacion", frm.cmbOrientacion.Text.Substring(0, frm.cmbOrientacion.Text.IndexOf(" (")).Trim())
                End With
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    frm.cmbGrado.Items.Add(reader("Grado"))
                End While
                reader.Close()
            End Using
        Catch ex As Exception
            ' Asumo que está viendo datos.
        End Try
        conexion.Close()
    End Sub

    Public Sub cargarOrientaciones_frmAdminGrupos(ByVal frm As frmAdminGrupos)
        ' carga las orientaciones a los combobox
        Dim conexion As New Conexion()
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
                frm.cmbOrientacion.Items.Add(reader("IdOrientacion").ToString() & " (" & reader("NombreOrientacion").ToString() & ")")
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Public Sub rellenarCombos_frmAdminGrupos(ByVal frm As frmAdminGrupos)
        ' Llena los combos con los datos de la DB.
        Dim conexion As New Conexion()

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
        End Using
        conexion.Close()
    End Sub

    Public Sub cargarDatos_frmAdminGrupos(ByVal grupo As Object, ByVal frm As frmAdminGrupos)
        ' carga los datos del grupo y los coloca en la interfaz
        Dim conexion As New Conexion()
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
                frm.cmbCurso.SelectedIndex = frm.cmbCurso.FindStringExact(reader("IDCurso").ToString() & " (" & reader("NombreCurso") & ")")
                frm.chkDiscapacitado.Checked = reader("Discapacitado")
                frm.cmbTurno.SelectedIndex = reader("IDTurno") - 1

                frm.cmbOrientacion.Items.Clear()
                frm.cmbOrientacion.Items.Add(reader("IdOrientacion").ToString() & " (" & reader("NombreOrientacion").ToString() & ")")
                frm.cmbOrientacion.SelectedIndex = 0

                frm.cmbGrado.Items.Clear()
                frm.cmbGrado.Items.Add(reader("Grado"))
                frm.cmbGrado.SelectedIndex = 0

                Dim salon As String = reader("IdSalon")
                If salon.Equals("-1") Then
                    salon = "Sin asignar"
                End If
                frm.lblSalonReal.Text = salon
                frm.cmbOrientacion.Enabled = False
                frm.cmbGrado.Enabled = False
            End While
            reader.Close()
        End Using
        conexion.Close()
    End Sub

    Public Sub actualizarDB_frmAdminGrupos(ByVal frm As frmAdminGrupos)
        ' Agrega un salón a la base de datos
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO `Grupo` VALUES (@IdGrupo, @Discapacitado, @Grado, @IDOrientacion, -1, @IdTurno);"

                .Parameters.AddWithValue("@IDGrupo", frm.txtIDGrupo.Text)
                .Parameters.AddWithValue("@Discapacitado", frm.chkDiscapacitado.Checked)
                .Parameters.AddWithValue("@Grado", frm.cmbGrado.Text)
                .Parameters.AddWithValue("@IdOrientacion", frm.cmbOrientacion.Text.Substring(0, frm.cmbOrientacion.Text.IndexOf(" (")).Trim())
                .Parameters.AddWithValue("@IdTurno", frm.cmbTurno.SelectedIndex + 1)
            End With

            Try
                Dim subCmd As New MySqlCommand()
                subCmd.Connection = conexion.Conn
                subCmd.CommandType = CommandType.Text
                subCmd.CommandText = "SELECT IdGrupo from Grupos where IdGrupo=@IdGrupo"
                subCmd.Parameters.AddWithValue("@IdGrupo", frm.txtIDGrupo.Text)

                Dim reader As MySqlDataReader = subCmd.ExecuteReader()
                While reader.Read()
                    Throw New System.Exception("Duplicate")
                End While

                reader.Close()

                cmd.ExecuteNonQuery()
                frm.cargarGrupos()
                MessageBox.Show("Grupo agregado correctamente", "Grupo agregado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                frm.btnNuevoGrupo_Click(Nothing, Nothing)
                cargarDatos_frmMain(frm.frmMain)
            Catch ex As Exception
                If ex.ToString().Contains("Duplicate") Then
                    MessageBox.Show("Ya existe un grupo con ese ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                Console.WriteLine(ex.ToString())
            End Try
        End Using
        conexion.Close()
    End Sub

    Public Sub eliminarGrupo_frmAdminGrupos(ByVal sender As System.Object, ByVal frm As frmAdminGrupos)
        Dim conexion As New Conexion()
        Dim subConexion As New Conexion()
        Dim subSubConexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM `Grupo` WHERE IdGrupo=@IdGrupo and IdTurno=@IdTurno and Grado=@Grado;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IdGrupo", sender.Tag(0))
                .Parameters.AddWithValue("@IdTurno", sender.Tag(2))
                .Parameters.AddWithValue("@Grado", sender.Tag(1))
            End With
            ' Backup de horarios D: !
            ' Hay una forma más fácil de hacer esto, comprobando que no haya datos en X tablas
            ' pero me gusta más lo complicado :)
            Dim backCmd As New MySqlCommand()
            backCmd.CommandType = CommandType.Text
            backCmd.Connection = subConexion.Conn
            backCmd.CommandText = "SELECT * FROM Genera WHERE `IdGrupo`=@IdGrupo and `Grado`=@Grado;"
            backCmd.Parameters.AddWithValue("@IdGrupo", sender.Tag(0))
            backCmd.Parameters.AddWithValue("@Grado", sender.Tag(1))
            Dim backReader As MySqlDataReader = backCmd.ExecuteReader()

            Try
                Dim subCmd As New MySqlCommand()
                subCmd.Connection = subSubConexion.Conn
                subCmd.CommandType = CommandType.Text
                subCmd.CommandText = "DELETE FROM Genera WHERE `IdGrupo`=@IdGrupo and `Grado`=@Grado;"
                subCmd.Parameters.AddWithValue("@IdGrupo", sender.Tag(0))
                subCmd.Parameters.AddWithValue("@Grado", sender.Tag(1))
                subCmd.ExecuteNonQuery()

                cmd.ExecuteNonQuery()
                frm.cargarGrupos()
                frm.btnNuevoGrupo_Click(Nothing, Nothing)

                frm.totalGrupos -= 1
                MessageBox.Show("Grupo '" + sender.Tag(4) + "' eliminado.", "Grupo eliminado.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                ' Devuelvo los horarios a la tabla D;
                Dim insConexion As New Conexion()
                Try
                    While backReader.Read()
                        Dim insCmd As New MySqlCommand()
                        insCmd.Connection = insConexion.Conn
                        insCmd.CommandType = CommandType.Text
                        insCmd.CommandText = "INSERT INTO `Genera` VALUES (@HoraInicio, @HoraFin, @Dia, @Grado, @IdAsignatura, @IdGrupo, @IdOrientacion, @CiPersona);"
                        insCmd.Parameters.AddWithValue("@HoraInicio", backReader("HoraInicio"))
                        insCmd.Parameters.AddWithValue("@HoraFin", backReader("HoraFin"))
                        insCmd.Parameters.AddWithValue("@Dia", backReader("Dia"))
                        insCmd.Parameters.AddWithValue("@Grado", backReader("Grado"))
                        insCmd.Parameters.AddWithValue("@IdAsignatura", backReader("IdAsignatura"))
                        insCmd.Parameters.AddWithValue("@IdGrupo", backReader("IdGrupo"))
                        insCmd.Parameters.AddWithValue("@IdOrientacion", backReader("IdOrientacion"))
                        insCmd.Parameters.AddWithValue("@CiPersona", backReader("CiPersona"))
                        insCmd.ExecuteNonQuery()
                    End While
                    backReader.Close()
                Catch exx As Exception
                    ' No se borro el horario, yay :D
                    insConexion.Close()
                End Try

                MessageBox.Show("No se pudo eliminar el grupo, el mismo tiene materias docentes (ver admin. de docentes) asignados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Console.WriteLine(ex.ToString())

            End Try
        End Using
        subConexion.Close()
        subSubConexion.Close()
        conexion.Close() 'Cierra la conexión
    End Sub

    Public Sub cargarTurnos_frmAdminGrupos(ByVal frm As frmAdminGrupos)
        ' carga las orientaciones a los combobox
        Dim conexion As New Conexion()
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
        End Using
        conexion.Close()
    End Sub

    Public Sub cargarAreas_frmAdminDocentes(ByVal frm As frmAdminDocentes)
        ' Carga areas
        Dim conexion As New Conexion()
        Dim IdOrientacion As String
        frm.cmbArea.Items.Clear()

        Dim cmd As New MySqlCommand()
        cmd.Connection = conexion.Conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT IdOrientacion from Grupo where IdGrupo=@IdGrupo and Grado=@Grado"
        cmd.Parameters.AddWithValue("@IdGrupo", frm.cmbGrupo.Text.Substring(frm.cmbGrupo.Text.IndexOf(" "), frm.cmbGrupo.Text.IndexOf(" - ")).Trim())
        cmd.Parameters.AddWithValue("@Grado", frm.cmbGrupo.Text.Substring(0, frm.cmbGrupo.Text.IndexOf(" ")).Trim())
        Dim reader As MySqlDataReader = cmd.ExecuteReader()
        While reader.Read()
            IdOrientacion = reader("IdOrientacion").ToString()
        End While
        reader.Close()

        Using subCmd As New MySqlCommand()
            With subCmd
                .Connection = conexion.Conn
                .CommandText = "select DISTINCT Area.IdArea, NombreArea from (select Asignatura.IdArea from Tiene_ta, Asignatura where Tiene_Ta.IdAsignatura=Asignatura.IdAsignatura and Tiene_ta.IdOrientacion=@IdOrientacion and Tiene_ta.Grado=@Grado) Orientacion, Area where Orientacion.IdArea=Area.IdArea;"
                .Parameters.AddWithValue("@IdOrientacion", IdOrientacion)
                .Parameters.AddWithValue("@Grado", frm.cmbGrupo.Text.Substring(0, frm.cmbGrupo.Text.IndexOf(" ")).Trim())
                .CommandType = CommandType.Text
            End With

            reader = subCmd.ExecuteReader()
            While reader.Read()
                frm.cmbArea.Items.Add(reader("IdArea").ToString() & " - " & reader("NombreArea") & "")
            End While
            reader.Close()
        End Using
        conexion.Close()
    End Sub

    Public Sub rellenarCombos_frmAdminDocentes(ByVal frm As frmAdminDocentes)
        ' Llena los combos con los datos de la DB.
        Dim conexion As New Conexion()
        ' Cargar grupos
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT *, Turno.NombreTurno FROM `Grupo`, `Turno` WHERE Grupo.IdTurno=Turno.IdTurno;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                frm.cmbGrupo.Items.Add(reader("Grado") & " " & reader("IdGrupo") & " - " & reader("NombreTurno") & "")
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Public Sub cargarDocentes_frmAdminDocentes(ByVal frm As frmAdminDocentes)
        ' carga la lista de docentes
        frm.pnlDocentes.Controls.Clear()
        frm.totalDocentes = 0
        frm.lblCantidadDocentes.Text = "(" + frm.totalDocentes.ToString() + ")"

        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Profesor`;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                If reader("CiPersona").ToString().Equals("-1") Then
                    Continue While
                End If
                frm.agregarDocente(reader("CiPersona"), reader("CiPersona").ToString() & ControlChars.NewLine & reader("NombrePersona") & " " & reader("ApellidoPersona"))
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Public Sub actualizarDB_frmAdminDocentes(ByVal frm As frmAdminDocentes)
        ' Se encarga de manejar la DB (parte datos de docente), agrega o edita docentes.
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text

                If frm.btnAgregarDocente.Text.StartsWith("Agregar docente") Then
                    .CommandText = "INSERT INTO `Profesor` VALUES (@CiPersona, @NombreProfesor, @ApellidoProfesor, @GradoProfesor);"
                Else
                    .CommandText = "UPDATE `Profesor` SET NombrePersona=@NombreProfesor, ApellidoPersona=@ApellidoProfesor, GradoProfesor=@GradoProfesor WHERE CiPersona=@CiPersona;"
                End If

                .Parameters.AddWithValue("@CiPersona", frm.txtCI.Text)
                .Parameters.AddWithValue("@NombreProfesor", frm.txtNombre.Text)
                .Parameters.AddWithValue("@ApellidoProfesor", frm.txtApellido.Text)
                .Parameters.AddWithValue("@GradoProfesor", frm.numGrado.Value)
            End With

            Try
                Using subCmd As New MySqlCommand()
                    With subCmd
                        .Connection = conexion.Conn
                        If frm.btnAgregarDocente.Text.StartsWith("Agregar docente") Then
                            .CommandText = "INSERT INTO `Persona` VALUES (@CiPersona, @NombreProfesor, @ApellidoProfesor);"
                        Else
                            .CommandText = "UPDATE `Persona` SET NombrePersona=@NombreProfesor, ApellidoPersona=@ApellidoProfesor where CiPersona=@CiPersona;"
                        End If
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@CiPersona", frm.txtCI.Text)
                        .Parameters.AddWithValue("@NombreProfesor", frm.txtNombre.Text)
                        .Parameters.AddWithValue("@ApellidoProfesor", frm.txtApellido.Text)
                    End With
                    subCmd.ExecuteNonQuery()
                End Using

                cmd.ExecuteNonQuery()

                frm.cargarDocentes()
                If frm.btnAgregarDocente.Text.StartsWith("Agregar docente") Then
                    MessageBox.Show("Docente agregado correctamente", "Docente agregado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    frm.editarMateriasDocente(frm.txtCI.Text)
                Else
                    MessageBox.Show("Información de docente actualizada correctamente", "Docente actualizado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    frm.previsualizarDocente(frm.txtCI.Text)
                End If
            Catch ex As Exception
                If ex.ToString().Contains("Duplicate") Then
                    MessageBox.Show("Ya existe un docente (o usuario!) con esa CI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Try
        End Using
        conexion.Close()
    End Sub

    Public Sub cargarDatos_frmAdminDocentes(ByVal ciDocente As String, ByVal frm As frmAdminDocentes)
        ' carga los datos del docente
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Profesor` where CiPersona=@CiPersona;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@CiPersona", ciDocente)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                frm.txtCI.Text = reader("CiPersona")
                frm.txtNombre.Text = reader("NombrePersona")
                frm.txtApellido.Text = reader("ApellidoPersona")
                frm.numGrado.Value = reader("GradoProfesor")
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Public Sub eliminarAsignatura_frmAdminDocentes(sender As Object, ByVal frm As frmAdminDocentes)
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM `Tiene_Ag` WHERE IdGrupo=@IdGrupo and IdAsignatura=@IdAsignatura and Grado=@Grado and CiPersona=@CiPersona;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IdAsignatura", frm.lstAsignaturas.SelectedItems.Item(0).SubItems(0).Text)
                .Parameters.AddWithValue("@IdGrupo", frm.lstAsignaturas.SelectedItems.Item(0).SubItems(1).Text.Substring(frm.lstAsignaturas.SelectedItems.Item(0).SubItems(1).Text.IndexOf(" "), frm.lstAsignaturas.SelectedItems.Item(0).SubItems(1).Text.Length - 1).Trim())
                .Parameters.AddWithValue("@Grado", frm.lstAsignaturas.SelectedItems.Item(0).SubItems(1).Text.Substring(0, frm.lstAsignaturas.SelectedItems.Item(0).SubItems(1).Text.IndexOf(" ")).Trim())
                .Parameters.AddWithValue("@CiPersona", frm.txtCI.Text)
            End With
            Try
                Dim subCmd As New MySqlCommand()
                subCmd.Connection = conexion.Conn
                subCmd.CommandType = CommandType.Text
                subCmd.CommandText = "UPDATE `Genera` SET `CiPersona`='-1' WHERE `IdAsignatura`=@IdAsignatura and `IdGrupo`=@IdGrupo and`CiPersona`=@CiPersona and `Grado`=@Grado;"
                subCmd.Parameters.AddWithValue("@IdAsignatura", frm.lstAsignaturas.SelectedItems.Item(0).SubItems(0).Text)
                subCmd.Parameters.AddWithValue("@IdGrupo", frm.lstAsignaturas.SelectedItems.Item(0).SubItems(1).Text.Substring(frm.lstAsignaturas.SelectedItems.Item(0).SubItems(1).Text.IndexOf(" "), frm.lstAsignaturas.SelectedItems.Item(0).SubItems(1).Text.Length - 1).Trim())
                subCmd.Parameters.AddWithValue("@Grado", frm.lstAsignaturas.SelectedItems.Item(0).SubItems(1).Text.Substring(0, frm.lstAsignaturas.SelectedItems.Item(0).SubItems(1).Text.IndexOf(" ")).Trim())
                subCmd.Parameters.AddWithValue("@CiPersona", frm.txtCI.Text)
                subCmd.ExecuteNonQuery()

                cmd.ExecuteNonQuery()
                frm.cargarMaterias(frm.txtCI.Text)
                frm.btnEliminarAsignatura.Visible = False
                MessageBox.Show("Asignatura eliminada.", "Asignatura eliminada.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        conexion.Close() 'Cierra la conexión
    End Sub

    Public Sub eliminarDocente_frmAdminDocentes(sender As Object, ByVal frm As frmAdminDocentes)
        Dim conexion As Conexion
        conexion = New Conexion()

        Dim ci, nombre, apellido, grado As String
        Dim backupDatos As New MySqlCommand()
        backupDatos.Connection = conexion.Conn
        backupDatos.CommandText = "SELECT * from `Profesor` WHERE CiPersona=@CiPersona;"
        backupDatos.CommandType = CommandType.Text
        backupDatos.Parameters.AddWithValue("@CiPersona", sender.Tag(0))
        Dim readerBackup As MySqlDataReader = backupDatos.ExecuteReader()
        While readerBackup.Read()
            ci = readerBackup("CiPersona").ToString()
            nombre = readerBackup("NombrePersona").ToString()
            apellido = readerBackup("ApellidoPersona").ToString()
            grado = readerBackup("GradoProfesor").ToString()
        End While
        readerBackup.Close()
        conexion.Close()

        conexion = New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM `Profesor` WHERE CiPersona=@CiPersona;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@CiPersona", sender.Tag(0))
            End With
            Try
                cmd.ExecuteNonQuery()
                conexion.Close() 'Cierra la conexión
                Using subCmd As New MySqlCommand()
                    With subCmd
                        .Connection = conexion.Conn
                        .CommandText = "DELETE FROM `Persona` WHERE CiPersona=@CiPersona;"
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@CiPersona", sender.Tag(0))
                    End With
                    subCmd.ExecuteNonQuery()
                End Using
                frm.cargarDocentes()
                frm.btnNuevoDocente_Click(Nothing, Nothing)
                frm.totalDocentes -= 1
                MessageBox.Show("Docente'" + sender.Tag(1) + "' eliminado.", "Docente eliminado.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("El docente no se puede eliminar, ya que tiene materias asignadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ' No encontre una forma de arreglarlo. :/ así que tengo que crear el docente nuevamente.
                Try
                    Using subSubCmd As New MySqlCommand()
                        With subSubCmd
                            .Connection = conexion.Conn
                            .CommandText = "INSERT INTO `Profesor` VALUES (@CiPersona, @NombrePersona, @ApellidoPersona, @GradoProfesor)"
                            .CommandType = CommandType.Text
                            .Parameters.AddWithValue("@CiPersona", ci)
                            .Parameters.AddWithValue("@NombrePersona", nombre)
                            .Parameters.AddWithValue("@ApellidoPersona", apellido)
                            .Parameters.AddWithValue("@GradoProfesor", grado)
                        End With
                        subSubCmd.ExecuteNonQuery()
                    End Using
                Catch exx As Exception
                End Try
                Console.WriteLine(ex.ToString())
            End Try
        End Using
        conexion.Close()
    End Sub

    Public Sub cargarMaterias_frmAdminDocentes(ByVal CI As String, ByVal frm As frmAdminDocentes)
        ' Carga la lista de materias a la lista
        frm.lstAsignaturas.Items.Clear()
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Tiene_Ag` WHERE CiPersona=@CiPersona;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@CiPersona", CI)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                Dim item As New ListViewItem
                item = frm.lstAsignaturas.Items.Add(reader("IdAsignatura").ToString())
                item.SubItems.Add(reader("Grado") & " " & reader("IdGrupo"))
                item.SubItems.Add(reader("FechaToma").ToString())
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Public Sub actualizarDBMaterias_frmAdminDocentes(ByVal frm As frmAdminDocentes)
        ' Se encarga de manejar la DB (parte asignaturas del docente), agrega o edita asignaturas.
        Dim conexion As New Conexion()
        Dim yaEsta As Boolean = False

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text
                .CommandText = "SELECT * from `AsignaturasTomadas` WHERE IdAsignatura=@IdAsignatura and IdGrupo=@IdGrupo and Grado=@Grado;"
                .Parameters.AddWithValue("@IdAsignatura", frm.cmbAsignatura.Text.Substring(0, frm.cmbAsignatura.Text.IndexOf(" - ")).Trim())
                .Parameters.AddWithValue("@IdGrupo", frm.cmbGrupo.Text.Substring(frm.cmbGrupo.Text.IndexOf(" "), frm.cmbGrupo.Text.IndexOf(" - ")).Trim())
                .Parameters.AddWithValue("@Grado", frm.cmbGrupo.Text.Substring(0, frm.cmbGrupo.Text.IndexOf(" ")).Trim())
            End With
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                yaEsta = True
            End While
            reader.Close()
        End Using

        If yaEsta Then
            MessageBox.Show("Esa materia ya ha sido asignada al grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO `Tiene_Ag` VALUES (@IdAsignatura, @IdGrupo, @Grado, @IdOrientacion, @CiPersona, @FechaToma, @GradoAreaProfesor);"
                .Parameters.AddWithValue("@CiPersona", frm.txtCI.Text)
                .Parameters.AddWithValue("@IdAsignatura", frm.cmbAsignatura.Text.Substring(0, frm.cmbAsignatura.Text.IndexOf(" - ")).Trim())
                .Parameters.AddWithValue("@IdGrupo", frm.cmbGrupo.Text.Substring(frm.cmbGrupo.Text.IndexOf(" "), frm.cmbGrupo.Text.IndexOf(" - ")).Trim())
                .Parameters.AddWithValue("@Grado", frm.cmbGrupo.Text.Substring(0, frm.cmbGrupo.Text.IndexOf(" ")).Trim())
                Dim d As DateTime = Now
                .Parameters.AddWithValue("@FechaToma", d.ToString("yyyy-MM-dd"))
                .Parameters.AddWithValue("@GradoAreaProfesor", frm.numGradoArea.Value)

                Dim orientacionGrupo As String

                Using subCmd As New MySqlCommand()
                    subCmd.Connection = conexion.Conn
                    subCmd.CommandType = CommandType.Text
                    subCmd.CommandText = "SELECT IdOrientacion from Grupo where IdGrupo=@IdGrupo and Grado=@Grado;"
                    subCmd.Parameters.AddWithValue("@IdGrupo", frm.cmbGrupo.Text.Substring(frm.cmbGrupo.Text.IndexOf(" "), frm.cmbGrupo.Text.IndexOf(" - ")).Trim())
                    subCmd.Parameters.AddWithValue("@Grado", frm.cmbGrupo.Text.Substring(0, frm.cmbGrupo.Text.IndexOf(" ")).Trim())
                    Dim reader As MySqlDataReader = subCmd.ExecuteReader()
                    reader.Read()
                    orientacionGrupo = reader("IdOrientacion").ToString()
                    reader.Close()
                End Using

                .Parameters.AddWithValue("@IdOrientacion", orientacionGrupo)
            End With

            Try
                cmd.ExecuteNonQuery()

                Dim subCmd As New MySqlCommand()
                subCmd.Connection = conexion.Conn
                subCmd.CommandType = CommandType.Text
                subCmd.CommandText = "UPDATE `Genera` SET `CiPersona`=@CiPersona WHERE `IdAsignatura`=@IdAsignatura and `IdGrupo`=@IdGrupo and `Grado`=@Grado;"
                subCmd.Parameters.AddWithValue("@CiPersona", frm.txtCI.Text)
                subCmd.Parameters.AddWithValue("@IdAsignatura", frm.cmbAsignatura.Text.Substring(0, frm.cmbAsignatura.Text.IndexOf(" - ")).Trim())
                subCmd.Parameters.AddWithValue("@IdGrupo", frm.cmbGrupo.Text.Substring(frm.cmbGrupo.Text.IndexOf(" "), frm.cmbGrupo.Text.IndexOf(" - ")).Trim())
                subCmd.Parameters.AddWithValue("@Grado", frm.cmbGrupo.Text.Substring(0, frm.cmbGrupo.Text.IndexOf(" ")).Trim())
                subCmd.ExecuteNonQuery()

                frm.cargarMaterias(frm.txtCI.Text)
                ' Deshabilita la edición de datos del docente.
                frm.lblNuevoDocente.Text = "Editar materias del docente"
                frm.btnAgregarAsignatura_Click(Nothing, Nothing)
            Catch ex As Exception
                Console.WriteLine(ex)
                If ex.ToString().Contains("Duplicate") Then
                    MessageBox.Show("Esa materia ya ha sido asignada al grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Try
        End Using
        conexion.Close()
    End Sub

    Public Sub cargarAsignaturas_frmAdminDocentes(ByVal frm As frmAdminDocentes)
        ' Carga las asignaturas al combo
        Dim conexion As New Conexion()
        Dim IdOrientacion As String
        Dim grado As String = frm.cmbGrupo.Text.Substring(0, frm.cmbGrupo.Text.IndexOf(" ")).Trim()
        frm.cmbAsignatura.Items.Clear()

        Dim cmd As New MySqlCommand()
        cmd.Connection = conexion.Conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT IdOrientacion from Grupo where IdGrupo=@IdGrupo and Grado=@Grado"
        cmd.Parameters.AddWithValue("@IdGrupo", frm.cmbGrupo.Text.Substring(frm.cmbGrupo.Text.IndexOf(" "), frm.cmbGrupo.Text.IndexOf(" - ")).Trim())
        cmd.Parameters.AddWithValue("@Grado", grado)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()
        While reader.Read()
            IdOrientacion = reader("IdOrientacion").ToString()
        End While
        reader.Close()

        Using subCmd As New MySqlCommand()
            With subCmd
                .Connection = conexion.Conn
                .CommandText = "select Asignatura.IdArea, Asignatura.IdAsignatura, Asignatura.NombreAsignatura, Tiene_Ta.IdOrientacion from (select DISTINCT Area.IdArea, NombreArea from (select Asignatura.IdArea from Tiene_ta, Asignatura where Tiene_Ta.IdAsignatura=Asignatura.IdAsignatura and Tiene_ta.IdOrientacion=@IdOrientacion) Orientacion, Area where Orientacion.IdArea=Area.IdArea) Areas, Asignatura, Tiene_ta where Asignatura.IdArea=Areas.IdArea and Tiene_ta.IdAsignatura=Asignatura.IdAsignatura and Tiene_Ta.Grado=@Grado and IdOrientacion=@IdOrientacion1 and Asignatura.IdArea=@IdArea;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@Grado", grado)
                .Parameters.AddWithValue("@IdOrientacion", IdOrientacion)
                .Parameters.AddWithValue("@IdOrientacion1", IdOrientacion)
                .Parameters.AddWithValue("@IdArea", frm.cmbArea.Text.Substring(0, frm.cmbArea.Text.IndexOf(" - ")))
                Console.WriteLine(grado)
                Console.WriteLine(IdOrientacion)
            End With

            reader = subCmd.ExecuteReader()
            While reader.Read()
                Console.Write("cargando")
                If reader("IdAsignatura").ToString().Equals("-1") Then
                    Continue While
                End If
                If reader("IdArea").ToString().Equals(frm.cmbArea.Text.Substring(0, frm.cmbArea.Text.IndexOf(" - "))) Then
                    frm.cmbAsignatura.Items.Add(reader("IdAsignatura").ToString() & " - " & reader("NombreAsignatura"))
                End If
            End While
            reader.Close()
        End Using
        conexion.Close()
    End Sub

    Public Sub cargarGrupos_frmAdminHorarios(ByVal frm As frmAdminHorarios)
        ' Carga los grupos a la lista de grupos
        Dim conexion As New Conexion()
        frm.cmbGrupo.Items.Clear()
        frm.cmbGrupo.Items.Add("...")
        frm.cmbGrupo.SelectedIndex = 0
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT Grado, IdGrupo FROM `Grupo`;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                frm.cmbGrupo.Items.Add(reader("Grado").ToString() + " " + reader("IdGrupo").ToString())
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Public Sub cargarMaterias_frmAdminHorarios(ByVal frm As frmAdminHorarios)
        Dim conexion As New Conexion()
        Dim subConexion As New Conexion()

        frm.btnSinAsignar.Parent = frm
        frm.pnlMaterias.Controls.Clear()
        frm.pnlMaterias.Controls.Add(frm.btnSinAsignar)

        frm.Cursor = Cursors.WaitCursor
        frm.pnlMaterias.Enabled = False
        frm.tableLunes.Enabled = False
        frm.tableMartes.Enabled = False
        frm.tableMiercoles.Enabled = False
        frm.tableJueves.Enabled = False
        frm.tableViernes.Enabled = False
        frm.tableSabado.Enabled = True

        Try
            Dim botonesMaterias As New List(Of List(Of Object))
            Dim materias As New List(Of String)
            Using cmd As New MySqlCommand()
                With cmd
                    .Connection = conexion.Conn
                    .CommandText = "select DISTINCT NombreAsignatura, Grupo.IdGrupo, Grupo.IdOrientacion, AsignaturasOrientaciones.IdAsignatura, CargaHoraria, AsignaturasOrientaciones.Grado from AsignaturasOrientaciones, Grupo where Grupo.IdOrientacion=AsignaturasOrientaciones.IdOrientacion and Grupo.IdGrupo=@IdGrupo and Grupo.Grado=@Grado and AsignaturasOrientaciones.Grado=Grupo.Grado;"
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@Grado", Integer.Parse(frm.cmbGrupo.Text.Substring(0, frm.cmbGrupo.Text.IndexOf(" ")).Trim()))
                    .Parameters.AddWithValue("@IdGrupo", frm.cmbGrupo.Text.Substring(frm.cmbGrupo.Text.IndexOf(" "), frm.cmbGrupo.Text.Length - 1).Trim())
                End With

                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    For carga As Integer = 1 To Integer.Parse(reader("CargaHoraria"))
                        frm._IdOrientacion = reader("IdOrientacion")
                        Dim materia As Button
                        materia = New Button()
                        materia.TabStop = False
                        materia.Cursor = Cursors.Hand

                        ' Quien enseña la materia?
                        Dim subCmd As New MySqlCommand()
                        Dim nombreProfesor As String = "Sin profesor"
                        Dim ciProfesor As String = "-1"
                        subCmd.Connection = subConexion.Conn
                        subCmd.CommandText = "select Tiene_ag.CiPersona, Concat(NombrePersona, ' ', ApellidoPersona) as 'Profesor' from Tiene_ag, Persona where IdAsignatura=@IdAsignatura and IdGrupo=@IdGrupo and Grado=@Grado and Tiene_ag.CiPersona=Persona.CiPersona;"
                        subCmd.Parameters.AddWithValue("@Grado", Integer.Parse(frm.cmbGrupo.Text.Substring(0, frm.cmbGrupo.Text.IndexOf(" ")).Trim()))
                        subCmd.Parameters.AddWithValue("@IdGrupo", frm.cmbGrupo.Text.Substring(frm.cmbGrupo.Text.IndexOf(" "), frm.cmbGrupo.Text.Length - 1).Trim())
                        subCmd.Parameters.AddWithValue("@IdAsignatura", reader("IdAsignatura"))
                        Dim subReader As MySqlDataReader = subCmd.ExecuteReader()
                        While subReader.Read()
                            nombreProfesor = subReader("Profesor")
                            ciProfesor = subReader("CiPersona")
                        End While
                        subReader.Close()

                        materia.Text = reader("NombreAsignatura") & vbCrLf & nombreProfesor
                        materia.Tag = {reader("IdAsignatura"), ciProfesor}
                        If materia.Text.Equals("Sin asignar") Then
                            Continue While
                        End If

                        If materias.Contains(reader("NombreAsignatura")) Then
                            botonesMaterias(materias.IndexOf(reader("NombreAsignatura"))).Add(materia)
                        Else
                            materias.Add(reader("NombreAsignatura"))
                            botonesMaterias.Add(New List(Of Object))
                            botonesMaterias(materias.IndexOf(reader("NombreAsignatura"))).Add(materia)
                        End If

                        materia.Size = frm.btnSinAsignar.Size
                        materia.FlatStyle = FlatStyle.Flat
                        materia.FlatAppearance.BorderColor = frm.btnSinAsignar.FlatAppearance.BorderColor
                        materia.FlatAppearance.BorderSize = frm.btnSinAsignar.FlatAppearance.BorderSize
                        materia.FlatAppearance.CheckedBackColor = frm.btnSinAsignar.FlatAppearance.CheckedBackColor
                        materia.FlatAppearance.MouseDownBackColor = frm.btnSinAsignar.FlatAppearance.MouseDownBackColor
                        materia.FlatAppearance.MouseOverBackColor = frm.btnSinAsignar.FlatAppearance.MouseOverBackColor
                        materia.BackColor = Color.White
                        AddHandler materia.MouseDown, AddressOf frm.Materia_MouseDown
                        frm.pnlMaterias.Controls.Add(materia)
                    Next
                End While
                reader.Close()
            End Using
            conexion.Close()
            subConexion.Close()

            conexion = New Conexion()
            Using cmd As New MySqlCommand()
                With cmd
                    .Connection = conexion.Conn
                    .CommandText = "select * from Calendario where Grupo=@Grupo;"
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@Grupo", frm.cmbGrupo.Text)
                End With

                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    If reader("Materia").Equals("Sin asignar") Then
                        Continue While
                    End If
                    Try
                        Dim Index As Integer = materias.IndexOf(reader("Materia"))
                        botonesMaterias(Index).ToArray().Last.Dispose()
                        botonesMaterias(Index).RemoveAt(botonesMaterias(Index).Count - 1)

                        Dim materia As New Button()
                        materia.TabStop = False
                        materia.Cursor = Cursors.Hand
                        materia.Text = reader("Materia") & vbCrLf & reader("NombreProfesor")
                        materia.Size = frm.btnSinAsignar.Size
                        materia.FlatStyle = FlatStyle.Flat
                        materia.FlatAppearance.BorderColor = frm.btnSinAsignar.FlatAppearance.BorderColor
                        materia.FlatAppearance.BorderSize = frm.btnSinAsignar.FlatAppearance.BorderSize
                        materia.FlatAppearance.CheckedBackColor = frm.btnSinAsignar.FlatAppearance.CheckedBackColor
                        materia.FlatAppearance.MouseDownBackColor = frm.btnSinAsignar.FlatAppearance.MouseDownBackColor
                        materia.FlatAppearance.MouseOverBackColor = frm.btnSinAsignar.FlatAppearance.MouseOverBackColor
                        materia.BackColor = Color.White
                        materia.Tag = {reader("IdAsignatura"), reader("CiPersona")}
                        AddHandler materia.MouseDown, AddressOf frm.Materia_MouseDown

                        If reader("Dia").Equals("Lunes") Then
                            ' Mismo condicionaaaaal :'/
                            If reader("HoraInicio").ToString().Equals(frm.horarioPrimera) Then
                                If Not (frm.tableLunes1.Controls.Count > 0) Then
                                    frm.tableLunes1.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioSegunda) Then
                                If Not (frm.tableLunes2.Controls.Count > 0) Then
                                    frm.tableLunes2.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioTercera) Then
                                If Not (frm.tableLunes3.Controls.Count > 0) Then
                                    frm.tableLunes3.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioCuarta) Then
                                If Not (frm.tableLunes4.Controls.Count > 0) Then
                                    frm.tableLunes4.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioQuinta) Then
                                If Not (frm.tableLunes5.Controls.Count > 0) Then
                                    frm.tableLunes5.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioSexta) Then
                                If Not (frm.tableLunes6.Controls.Count > 0) Then
                                    frm.tableLunes6.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioExtra) Then
                                If Not (frm.tableLunes7.Controls.Count > 0) Then
                                    frm.tableLunes7.Controls.Add(materia)
                                End If
                            End If
                        End If
                        If reader("Dia").Equals("Martes") Then
                            ' Mismo condicionaaaaal :'/
                            If reader("HoraInicio").ToString().Equals(frm.horarioPrimera) Then
                                If Not (frm.tableMartes1.Controls.Count > 0) Then
                                    frm.tableMartes1.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioSegunda) Then
                                If Not (frm.tableMartes2.Controls.Count > 0) Then
                                    frm.tableMartes2.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioTercera) Then
                                If Not (frm.tableMartes3.Controls.Count > 0) Then
                                    frm.tableMartes3.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioCuarta) Then
                                If Not (frm.tableMartes4.Controls.Count > 0) Then
                                    frm.tableMartes4.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioQuinta) Then
                                If Not (frm.tableMartes5.Controls.Count > 0) Then
                                    frm.tableMartes5.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioSexta) Then
                                If Not (frm.tableMartes6.Controls.Count > 0) Then
                                    frm.tableMartes6.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioExtra) Then
                                If Not (frm.tableMartes7.Controls.Count > 0) Then
                                    frm.tableMartes7.Controls.Add(materia)
                                End If
                            End If
                        End If
                        If reader("Dia").Equals("Miércoles") Then
                            ' Mismo condicionaaaaal :'/
                            If reader("HoraInicio").ToString().Equals(frm.horarioPrimera) Then
                                If Not (frm.tableMiercoles1.Controls.Count > 0) Then
                                    frm.tableMiercoles1.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioSegunda) Then
                                If Not (frm.tableMiercoles2.Controls.Count > 0) Then
                                    frm.tableMiercoles2.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioTercera) Then
                                If Not (frm.tableMiercoles3.Controls.Count > 0) Then
                                    frm.tableMiercoles3.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioCuarta) Then
                                If Not (frm.tableMiercoles4.Controls.Count > 0) Then
                                    frm.tableMiercoles4.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioQuinta) Then
                                If Not (frm.tableMiercoles5.Controls.Count > 0) Then
                                    frm.tableMiercoles5.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioSexta) Then
                                If Not (frm.tableMiercoles6.Controls.Count > 0) Then
                                    frm.tableMiercoles6.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioExtra) Then
                                If Not (frm.tableMiercoles7.Controls.Count > 0) Then
                                    frm.tableMiercoles7.Controls.Add(materia)
                                End If
                            End If
                        End If

                        If reader("Dia").Equals("Jueves") Then
                            ' Mismo condicionaaaaal :'/
                            If reader("HoraInicio").ToString().Equals(frm.horarioPrimera) Then
                                If Not (frm.tableJueves1.Controls.Count > 0) Then
                                    frm.tableJueves1.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioSegunda) Then
                                If Not (frm.tableJueves2.Controls.Count > 0) Then
                                    frm.tableJueves2.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioTercera) Then
                                If Not (frm.tableJueves3.Controls.Count > 0) Then
                                    frm.tableJueves3.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioCuarta) Then
                                If Not (frm.tableJueves4.Controls.Count > 0) Then
                                    frm.tableJueves4.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioQuinta) Then
                                If Not (frm.tableJueves5.Controls.Count > 0) Then
                                    frm.tableJueves5.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioSexta) Then
                                If Not (frm.tableJueves6.Controls.Count > 0) Then
                                    frm.tableJueves6.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioExtra) Then
                                If Not (frm.tableJueves7.Controls.Count > 0) Then
                                    frm.tableJueves7.Controls.Add(materia)
                                End If
                            End If
                        End If

                        If reader("Dia").Equals("Viernes") Then
                            ' Mismo condicionaaaaal :'/
                            If reader("HoraInicio").ToString().Equals(frm.horarioPrimera) Then
                                If Not (frm.tableViernes1.Controls.Count > 0) Then
                                    frm.tableViernes1.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioSegunda) Then
                                If Not (frm.tableViernes2.Controls.Count > 0) Then
                                    frm.tableViernes2.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioTercera) Then
                                If Not (frm.tableViernes3.Controls.Count > 0) Then
                                    frm.tableViernes3.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioCuarta) Then
                                If Not (frm.tableViernes4.Controls.Count > 0) Then
                                    frm.tableViernes4.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioQuinta) Then
                                If Not (frm.tableViernes5.Controls.Count > 0) Then
                                    frm.tableViernes5.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioSexta) Then
                                If Not (frm.tableViernes6.Controls.Count > 0) Then
                                    frm.tableViernes6.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioExtra) Then
                                If Not (frm.tableViernes7.Controls.Count > 0) Then
                                    frm.tableViernes7.Controls.Add(materia)
                                End If
                            End If
                        End If
                        If reader("Dia").Equals("Sábado") Then
                            ' Mismo condicionaaaaal :'/
                            If reader("HoraInicio").ToString().Equals(frm.horarioPrimera) Then
                                If Not (frm.tableSabado1.Controls.Count > 0) Then
                                    frm.tableSabado1.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioSegunda) Then
                                If Not (frm.tableSabado2.Controls.Count > 0) Then
                                    frm.tableSabado2.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioTercera) Then
                                If Not (frm.tableSabado3.Controls.Count > 0) Then
                                    frm.tableSabado3.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioCuarta) Then
                                If Not (frm.tableSabado4.Controls.Count > 0) Then
                                    frm.tableSabado4.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioQuinta) Then
                                If Not (frm.tableSabado5.Controls.Count > 0) Then
                                    frm.tableSabado5.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioSexta) Then
                                If Not (frm.tableSabado6.Controls.Count > 0) Then
                                    frm.tableSabado6.Controls.Add(materia)
                                End If
                            End If
                            If reader("HoraInicio").ToString().Equals(frm.horarioExtra) Then
                                If Not (frm.tableSabado7.Controls.Count > 0) Then
                                    frm.tableSabado7.Controls.Add(materia)
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        Console.WriteLine(ex.ToString())
                    End Try
                End While
                reader.Close()
            End Using
        Catch ex As Exception
            Console.WriteLine(ex.ToString())
        End Try
        conexion.Close()

        frm.Cursor = Cursors.Default
        frm.pnlMaterias.Enabled = True
        frm.tableLunes.Enabled = True
        frm.tableMartes.Enabled = True
        frm.tableMiercoles.Enabled = True
        frm.tableJueves.Enabled = True
        frm.tableViernes.Enabled = True
        frm.tableSabado.Enabled = True
    End Sub

    Public Sub cargarHorarios_frmAdminHorarios(ByVal frm As frmAdminHorarios)
        Dim conexion As New Conexion()
        Dim cmd As New MySqlCommand()
        cmd.Connection = conexion.Conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select IdTurno from Grupo where Grado=@Grado and IdGrupo=@IdGrupo;"
        cmd.Parameters.AddWithValue("@Grado", Integer.Parse(frm.cmbGrupo.Text.Substring(0, frm.cmbGrupo.Text.IndexOf(" ")).Trim()))
        cmd.Parameters.AddWithValue("@IdGrupo", frm.cmbGrupo.Text.Substring(frm.cmbGrupo.Text.IndexOf(" "), frm.cmbGrupo.Text.Length - 1).Trim())
        Dim reader As MySqlDataReader = cmd.ExecuteReader()
        reader.Read()
        Dim IdTurno As String = reader("IdTurno").ToString()
        reader.Close()

        cmd = New MySqlCommand()
        cmd.Connection = conexion.Conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select DISTINCT HoraInicio, HoraFin from Asignacion where IdTurno=@IdTurno;"
        cmd.Parameters.AddWithValue("@IdTurno", IdTurno)

        Dim posActual As Integer = 1
        reader = cmd.ExecuteReader()
        While reader.Read()
            If posActual = 1 Then
                frm.horarioPrimera = reader("HoraInicio").ToString()
                frm.finPrimera = reader("HoraFin").ToString()
            ElseIf posActual = 2 Then
                frm.horarioSegunda = reader("HoraInicio").ToString()
                frm.finSegunda = reader("HoraFin").ToString()
            ElseIf posActual = 3 Then
                frm.horarioTercera = reader("HoraInicio").ToString()
                frm.finTercera = reader("HoraFin").ToString()
            ElseIf posActual = 4 Then
                frm.horarioCuarta = reader("HoraInicio").ToString()
                frm.finCuarta = reader("HoraFin").ToString()
            ElseIf posActual = 5 Then
                frm.horarioQuinta = reader("HoraInicio").ToString()
                frm.finQuinta = reader("HoraFin").ToString()
            ElseIf posActual = 6 Then
                frm.horarioSexta = reader("HoraInicio").ToString()
                frm.finSexta = reader("HoraFin").ToString()
            ElseIf posActual = 7 Then
                frm.horarioExtra = reader("HoraInicio").ToString()
                frm.finExtra = reader("HoraFin").ToString()
            End If
            posActual += 1
        End While

        If IdTurno.ToString().Equals("3") Then
            frm.pnlBordeOculto.Visible = True
            frm.pnlOcultarExtra.Visible = True
        Else
            frm.pnlBordeOculto.Visible = False
            frm.pnlOcultarExtra.Visible = False
        End If
        frm.actHorarios()
        reader.Close()
        conexion.Close()
    End Sub
    Public Sub guardarHorarios_frmAdminHorarios(ByVal frm As frmAdminHorarios)
        Dim conexion As New Conexion()
        Dim conexion2 As New Conexion()
        Dim conexion_check As New Conexion()
        Dim dias As Object
        Dim ventanaEspere As New frmEspere()
        ventanaEspere.Show()
        frm.ParentForm.Controls(0).Enabled = False

        frm.Cursor = Cursors.WaitCursor
        frm.pnlMaterias.Enabled = False
        frm.tableLunes.Enabled = False
        frm.tableMartes.Enabled = False
        frm.tableMiercoles.Enabled = False
        frm.tableJueves.Enabled = False
        frm.tableViernes.Enabled = False
        frm.tableSabado.Enabled = True

        Dim horarios() As String = {frm.horarioPrimera, frm.finPrimera, frm.horarioSegunda, frm.finSegunda, _
                                     frm.horarioTercera, frm.finTercera, frm.horarioCuarta, frm.finCuarta, _
                                     frm.horarioQuinta, frm.finQuinta, frm.horarioSexta, frm.finSexta, _
                                     frm.horarioExtra, frm.finExtra}

        dias = {"Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"}
        horarios(0) = frm.horarioPrimera
        horarios(1) = frm.finPrimera

        Dim huboError As Boolean = False

        For Each dia As String In dias
            For hora_n As Integer = 0 To 13
                Using cmd2 As New MySqlCommand()
                    cmd2.Connection = conexion2.Conn
                    cmd2.CommandText = "INSERT INTO `Genera` VALUES (@HoraInicio, @HoraFin, @Dia, @Grado, @IdAsignatura, @IdGrupo, @IdOrientacion, @CiPersona)"
                    cmd2.CommandType = CommandType.Text
                    Dim idGrupo As String = frm.cmbGrupo.Text.Substring(frm.cmbGrupo.Text.IndexOf(" "), frm.cmbGrupo.Text.Length - 1).ToString()
                    cmd2.Parameters.AddWithValue("@HoraInicio", horarios(hora_n))
                    cmd2.Parameters.AddWithValue("@HoraFin", horarios(hora_n + 1))
                    cmd2.Parameters.AddWithValue("@Dia", dia)
                    cmd2.Parameters.AddWithValue("@IdGrupo", idGrupo.Substring(1, idGrupo.Length - 1))
                    cmd2.Parameters.AddWithValue("@Grado", Integer.Parse(frm.cmbGrupo.Text.Substring(0, frm.cmbGrupo.Text.IndexOf(" ")).Trim()))
                    cmd2.Parameters.AddWithValue("@IdOrientacion", frm._IdOrientacion)

                    Dim btn As Button = New Button()


                    If dia.Equals("Lunes") Then
                        If horarios(hora_n).Equals(frm.horarioPrimera) Then
                            Try
                                btn = frm.tableLunes1.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSegunda) Then
                            Try
                                btn = frm.tableLunes2.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioTercera) Then
                            Try
                                btn = frm.tableLunes3.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioCuarta) Then
                            Try
                                btn = frm.tableLunes4.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioQuinta) Then
                            Try
                                btn = frm.tableLunes5.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSexta) Then
                            Try
                                btn = frm.tableLunes6.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioExtra) Then
                            Try
                                btn = frm.tableLunes7.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                    End If
                    If dia.Equals("Martes") Then
                        If horarios(hora_n).Equals(frm.horarioPrimera) Then
                            Try
                                btn = frm.tableMartes1.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSegunda) Then
                            Try
                                btn = frm.tableMartes2.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioTercera) Then
                            Try
                                btn = frm.tableMartes3.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioCuarta) Then
                            Try
                                btn = frm.tableMartes4.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioQuinta) Then
                            Try
                                btn = frm.tableMartes5.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSexta) Then
                            Try
                                btn = frm.tableMartes6.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioExtra) Then
                            Try
                                btn = frm.tableMartes7.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                    End If
                    If dia.Equals("Miércoles") Then
                        If horarios(hora_n).Equals(frm.horarioPrimera) Then
                            Try
                                btn = frm.tableMiercoles1.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSegunda) Then
                            Try
                                btn = frm.tableMiercoles2.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioTercera) Then
                            Try
                                btn = frm.tableMiercoles3.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioCuarta) Then
                            Try
                                btn = frm.tableMiercoles4.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioQuinta) Then
                            Try
                                btn = frm.tableMiercoles5.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSexta) Then
                            Try
                                btn = frm.tableMiercoles6.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioExtra) Then
                            Try
                                btn = frm.tableMiercoles7.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                    End If
                    If dia.Equals("Jueves") Then
                        If horarios(hora_n).Equals(frm.horarioPrimera) Then
                            Try
                                btn = frm.tableJueves1.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSegunda) Then
                            Try
                                btn = frm.tableJueves2.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioTercera) Then
                            Try
                                btn = frm.tableJueves3.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioCuarta) Then
                            Try
                                btn = frm.tableJueves4.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioQuinta) Then
                            Try
                                btn = frm.tableJueves5.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSexta) Then
                            Try
                                btn = frm.tableJueves6.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioExtra) Then
                            Try
                                btn = frm.tableJueves7.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                    End If
                    If dia.Equals("Viernes") Then
                        If horarios(hora_n).Equals(frm.horarioPrimera) Then
                            Try
                                btn = frm.tableViernes1.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSegunda) Then
                            Try
                                btn = frm.tableViernes2.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioTercera) Then
                            Try
                                btn = frm.tableViernes3.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioCuarta) Then
                            Try
                                btn = frm.tableViernes4.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioQuinta) Then
                            Try
                                btn = frm.tableViernes5.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSexta) Then
                            Try
                                btn = frm.tableViernes6.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioExtra) Then
                            Try
                                btn = frm.tableViernes7.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                    End If
                    If dia.Equals("Sábado") Then
                        If horarios(hora_n).Equals(frm.horarioPrimera) Then
                            Try
                                btn = frm.tableSabado1.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSegunda) Then
                            Try
                                btn = frm.tableSabado2.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioTercera) Then
                            Try
                                btn = frm.tableSabado3.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioCuarta) Then
                            Try
                                btn = frm.tableSabado4.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioQuinta) Then
                            Try
                                btn = frm.tableSabado5.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSexta) Then
                            Try
                                btn = frm.tableSabado6.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioExtra) Then
                            Try
                                btn = frm.tableSabado7.Controls(0)
                            Catch ex As Exception
                                btn = New Button()
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                    End If

                    cmd2.Parameters.AddWithValue("@IdAsignatura", btn.Tag(0))
                    cmd2.Parameters.AddWithValue("@CiPersona", btn.Tag(1))

                    Try
                        Dim cmd_check As New MySqlCommand()
                        cmd_check.Connection = conexion_check.Conn
                        cmd_check.CommandType = CommandType.Text
                        cmd_check.CommandText = "select IdAsignatura, Grupo, HoraOrden, Dia, CiPersona, NombreProfesor from Calendario where CiPersona=@CiPersona and HoraInicio=@horaInicio and Dia=@dia;"
                        If Not btn.Tag(1).ToString().Equals("-1") Then

                            cmd_check.Parameters.AddWithValue("@horainicio", horarios(hora_n))
                            cmd_check.Parameters.AddWithValue("@CiPersona", btn.Tag(1))
                            cmd_check.Parameters.AddWithValue("@dia", dia)
                            Dim reader_check = cmd_check.ExecuteReader()
                            While reader_check.Read()
                                If reader_check("IdAsignatura").ToString().Equals(btn.Tag(0)) And reader_check("Grupo").ToString().Equals(frm.cmbGrupo.Text) Then
                                    Continue While
                                End If
                                ventanaEspere.Hide()
                                Dim result As Integer = MessageBox.Show("El profesor '" & reader_check("NombreProfesor") & "' ya tiene una materia el día: " & dia & " a la hora " & horarios(hora_n), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                ventanaEspere.Show()
                                ventanaEspere.BringToFront()
                                hora_n += 1
                                huboError = True
                                Continue For
                            End While
                            reader_check.Close()
                        End If

                        If huboError Then
                            MessageBox.Show("Se encontró al menos un error. Los cambios que ha realizado, no han quedado guardados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit For
                        End If

                        Using cmd As New MySqlCommand()
                            With cmd
                                .Connection = conexion.Conn
                                .CommandText = "DELETE FROM `Genera` WHERE HoraInicio=@HoraInicio and HoraFin=@HoraFin and Dia=@Dia and IdGrupo=@IdGrupo and IdOrientacion=@IdOrientacion and Grado=@Grado;"
                                .CommandType = CommandType.Text
                                idGrupo = frm.cmbGrupo.Text.Substring(frm.cmbGrupo.Text.IndexOf(" "), frm.cmbGrupo.Text.Length - 1).ToString()
                                .Parameters.AddWithValue("@HoraInicio", horarios(hora_n))
                                .Parameters.AddWithValue("@HoraFin", horarios(hora_n + 1))
                                .Parameters.AddWithValue("@Dia", dia)
                                .Parameters.AddWithValue("@IdGrupo", idGrupo.Substring(1, idGrupo.Length - 1))
                                .Parameters.AddWithValue("@Grado", Integer.Parse(frm.cmbGrupo.Text.Substring(0, frm.cmbGrupo.Text.IndexOf(" ")).Trim()))
                                .Parameters.AddWithValue("@IdOrientacion", frm._IdOrientacion)
                            End With
                            Try
                                cmd.ExecuteNonQuery()
                            Catch ex As Exception
                                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try
                        End Using

                        cmd2.ExecuteNonQuery()
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using

                hora_n += 1
            Next
            If huboError Then
                Exit For
            End If
        Next
        conexion.Close()
        conexion2.Close()
        conexion_check.Close()

        frm.Cursor = Cursors.Default
        frm.pnlMaterias.Enabled = True
        frm.tableLunes.Enabled = True
        frm.tableMartes.Enabled = True
        frm.tableMiercoles.Enabled = True
        frm.tableJueves.Enabled = True
        frm.tableViernes.Enabled = True
        frm.tableSabado.Enabled = True


        frm.ParentForm.Controls(0).Enabled = True
        ventanaEspere.Hide()
        cargarMaterias_frmAdminHorarios(frm)

        frm.frmMain.recargarGrupo()
    End Sub
End Class