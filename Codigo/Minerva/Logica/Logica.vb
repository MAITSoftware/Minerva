Imports MySql.Data.MySqlClient ' Importa el módulo de MySQL
Imports System.Data

Public Class Logica
    ' Logica: Una clase con muchos métodos :)
    ' Cada un de estos métodos, se encarga de conectarse a la Base de datos:
    ' guardar, eliminar, cargar datos, y en algunos hacer operaciones complejas.
    ' Metimos todo aca, y no en Persistencia, porque cada funcion depende de su form principal.
    ' Si bien actua con la base de datos, la clase principal de la base de datos se encuentra en la carpeta
    ' Persistencia.

    ' Estructura "básica" de un módulo de ésta clase.
    ' Public Sub nombreFuncion(*argumentos*) -> Definimos el módulo, el Public lo utilizamos, porque lo vamos a llamar desde otra parte del programa
    '   Dim conexion AS New Conexion() -> Establece la conexión con la base de datos
    '   Dim xArgumento AS tipoDeObjeto -> Crea una variable

    '   1 - "Hablar" con la base de datos:
    '       Dim cmd AS New MySqlCommand()   -> Crea el comando para la Consultas
    '       cmd.Connection = conexion.Conn  -> Utilizo la conexión que cree previamente
    '       cmd.CommandType = CommandType.Text  -> Establezco el tipo de comando a texto (??)

    '   1.1 - Consultas
    '       cmd.CommandText = 'SELECT * FROM Tabla;' -> La sentencia
    '       Dim reader AS MySqlDataReader() -> Abro un reader para obtener los resultados de la Consultas

    '       while reader.Read() -> reader.Read() nos lleva a la próxima fila de el resultado
    '           xArgumento = reader("Campo") -> Para leer datos (y ejecutar la sentencia) tengo que llamar a reader (y el campo de la consulta)
    '           o, hago lo que quiero con los datos
    '       end while -> termino el while

    '   1.2 - Insertar datos
    '       .CommandText = "INSERT INTO `Tabla` VALUES (Valor1, Valor2, Valor3);" -> La sentencia
    '       cmd.ExecuteNonQuery() -> Ejecuto la sentencia

    '   1.3 - Reemplazar datos de una consulta: Como no puedo combinar datos, tengo que ponerlos manualmente.
    '   Por lo tanto, en la sentencia, los datos que quiero reemplazar de forma manual debo ponerlos con un @ delante.
    '   Es decir: Tengo la sentencia: "SELECT * FROM Usuario WHERE Contraseña=[123]", y quiero cambiar el valor de la contraseña
    '   al de un campo de texto.
    '   En ese caso, la sentencia quedaría: "SELECT * FROM Usuario WHERE Contraseña=@Contraseña", ahora queda pasarle el valor
    '   Por lo tanto:
    '       cmd.Parameters.AddWithValue("@Contraseña", Valor) -> Cabe destacar que @Contraseña puede ser cualquier campo

    '   1.4 - Al terminar de usar la base de datos
    '       reader.Close() -> Es muy importante cerrar el reader cuando termino para no saturar la conexión
    '       conexion.Close() -> Cierro la conexión para no saturar a MySQL.

    '   1.5 - Hago lo que quiero con los datos

    ' End Sub -> Finalizamos el módulo

    ' frmLogin
    Public Sub Login_frmLogin(ByVal frm As frmLogin)
        ' Se encarga de comprobar los datos ingresados del usuario, con los de la DB
        Dim accesoDenegado As Boolean = True
        Dim conexion As New Conexion()
        Dim tipoUsuario As String = ""
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Usuario` WHERE CiPersona=@ID AND ContraseniaUsuario=@Contrasenia;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@ID", frm.txtUsuario.Text)
                .Parameters.AddWithValue("@Contrasenia", frm.txtContraseña.Text)
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
                tipoUsuario = reader("TipoUsuario")
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
            Dim minerva As New frmMain(False, frm.cuentaUsuario, tipoUsuario)

            minerva.Show()
            minerva.BringToFront()
            frm.Hide()
        End If
    End Sub

    ' frmRegistro
    Public Function ContarAdministradores_frmRegistro() As Integer
        Dim cantidadAdministradores As Integer
        Dim conexion As New Conexion()
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
        conexion.Close()
        Return cantidadAdministradores
    End Function

    Public Sub Registro_frmRegistro(ByVal frm As frmRegistro)
        ' Se encarga de efectuar la conexión a la DB y registrar al usuario en la misma
        Dim conexion As New Conexion()
        Dim cantidadAdministradores As Integer = ContarAdministradores_frmRegistro()

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
                    .CommandText = "INSERT INTO `Usuario` VALUES (@CiPersona, @TipoUsuario, @ContraseniaUsuario, @AprobacionUsuario);"
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@CiPersona", frm.txtUsuario.Text)
                    .Parameters.AddWithValue("@ContraseniaUsuario", frm.txtContraseña.Text)
                    If cantidadAdministradores <= 0 Then
                        .Parameters.AddWithValue("@AprobacionUsuario", True) ' Habilitada
                        .Parameters.AddWithValue("@TipoUsuario", "Administrador") ' Admin
                    Else
                        .Parameters.AddWithValue("@AprobacionUsuario", False) ' No está habilitada
                        If frm.radFuncionario.Checked Then
                            .Parameters.AddWithValue("@TipoUsuario", "Funcionario")
                        ElseIf frm.radAdscripto.Checked Then
                            .Parameters.AddWithValue("@TipoUsuario", "Adscripto")
                        ElseIf frm.radAdministrador.Checked Then
                            .Parameters.AddWithValue("@TipoUsuario", "Administrador")
                        End If
                    End If
                End With

                Try
                    cmd.ExecuteNonQuery()
                    conexion.Close()
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
                    conexion.Close()
                End Try
            End Using

        Catch ex As Exception
            frm.pnlError.Visible = True
            conexion.Close()
        End Try
    End Sub

    ' frmDatosUsuario
    Public Sub setDatos_frmDatosUsuario(ByVal frm As frmDatosUsuario)
        Dim conexion As New Conexion()
        Dim subConexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text
                .CommandText = "UPDATE `Persona` SET NombrePersona=@NombrePersona, ApellidoPersona=@ApellidoPersona WHERE CiPersona=@CiPersona;"

                .Parameters.AddWithValue("@CiPersona", frm._frmMain.nombreUsuario)
                .Parameters.AddWithValue("@NombrePersona", frm.txtNombre.Text)
                .Parameters.AddWithValue("@ApellidoPersona", frm.txtApellido.Text)
            End With
            cmd.ExecuteNonQuery()
            conexion.Close()
        End Using

        MessageBox.Show("Información de usuario actualizada correctamente", "Usuario actualizado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        frm._frmMain.BringToFront()
        frm.Dispose()
    End Sub

    ' frmMain
    Public Sub crearMenuCursosTurnos_frmMain(ByVal frm As frmMain)
        frm.ContextMenuStrip1.Items.Clear()
        Dim item, turno, curso As ToolStripMenuItem
        turno = New ToolStripMenuItem()
        turno.Text = "Turno"
        curso = New ToolStripMenuItem()
        curso.Text = "Curso"
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "select CONCAT(NombreTurno, ' (', IdTurno, ')') as Turno from Turno;"
                .CommandType = CommandType.Text
            End With
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                item = New ToolStripMenuItem()
                item.Text = reader("Turno")
                AddHandler item.Click, AddressOf frm.filtroTurnoCambiado
                turno.DropDownItems.Add(item)
            End While
            reader.Close()
        End Using

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "select CONCAT(NombreCurso, ' (', IdCurso, ')') as Curso from Curso;"
                .CommandType = CommandType.Text
            End With
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                item = New ToolStripMenuItem()
                item.Text = reader("Curso")
                AddHandler item.Click, AddressOf frm.filtroCursoCambiado
                curso.DropDownItems.Add(item)
            End While
            reader.Close()
        End Using
        frm.ContextMenuStrip1.Items.Add(turno)
        frm.ContextMenuStrip1.Items.Add(curso)
        conexion.Close()
    End Sub

    Public Sub contarAprobacion_frmMain(ByVal frm As frmMain)
        If Not frm.tipoUsuario.Equals("Administrador") Then
            frm.alertaAprobacion.Visible = False
            Return
        End If
        Dim cantidadAprobar As Integer
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "select COUNT(*) as 'Cantidad' from Usuario WHERE Usuario.AprobacionUsuario=False and not Usuario.CiPersona='-1';"
                .CommandType = CommandType.Text
            End With
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                cantidadAprobar = Integer.Parse(reader("Cantidad"))
            End While
            reader.Close()
        End Using
        conexion.Close()

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

    Public Sub cargarNombre_frmMain(ByVal frm As frmMain)
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT NombrePersona, ApellidoPersona from `Persona` where CiPersona=@CiPersona"
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
        Dim cursoElegido, turnoElegido As String
        frm.cboGrupo.Items.Clear()
        frm.cboGrupo.Items.Add("Elija un grupo")
        frm.cboGrupo.SelectedIndex = 0
        ' Carga los grupos al combo
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * from `Grupo`;"
                If Not IsNothing(frm.cursoElegido) And Not IsNothing(frm.turnoElegido) Then
                    cursoElegido = frm.cursoElegido.Text.ToString()
                    cursoElegido = cursoElegido.Substring(cursoElegido.IndexOf(" (") + 2).Trim(")")

                    turnoElegido = frm.turnoElegido.Text.ToString()
                    turnoElegido = turnoElegido.Substring(turnoElegido.IndexOf(" (") + 2).Trim(")")

                    .CommandText = "SELECT * from `Grupo`, `Orientacion` where Grupo.IdTurno=@IdTurno and Orientacion.IdOrientacion=Grupo.IdOrientacion and Orientacion.IdCurso=@IdCurso;"
                    .Parameters.AddWithValue("@IdCurso", cursoElegido)
                    .Parameters.AddWithValue("@IdTurno", turnoElegido)

                ElseIf Not IsNothing(frm.cursoElegido) Then
                    cursoElegido = frm.cursoElegido.Text.ToString()
                    cursoElegido = cursoElegido.Substring(cursoElegido.IndexOf(" (") + 2).Trim(")")

                    .CommandText = "SELECT * from `Grupo`, `Orientacion` where Orientacion.IdOrientacion=Grupo.IdOrientacion and Orientacion.IdCurso=@IdCurso;"
                    .Parameters.AddWithValue("@IdCurso", cursoElegido)

                ElseIf Not IsNothing(frm.turnoElegido) Then
                    turnoElegido = frm.turnoElegido.Text.ToString()
                    turnoElegido = turnoElegido.Substring(turnoElegido.IndexOf(" (") + 2).Trim(")")

                    .CommandText = "SELECT * from `Grupo` where Grupo.IdTurno=@IdTurno;"
                    .Parameters.AddWithValue("@IdTurno", turnoElegido)
                End If
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
        Dim nroGrupo As Integer
        Dim reader As MySqlDataReader

        Using primerCmd As New MySqlCommand()
            With primerCmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text
                .CommandText = "select * from Grupo where CONCAT(Grado, ' ', IdGrupo)=@Grupo;"
                .Parameters.AddWithValue("@Grupo", frm.cboGrupo.Text)
            End With
            reader = primerCmd.ExecuteReader()
            While reader.Read()
                nroGrupo = reader("NroGrupo")
            End While
            reader.Close()
        End Using

        Dim cmd As MySqlCommand
        cmd = New MySqlCommand()
        cmd.Connection = conexion.Conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select Adscripto, Salon, IdOrientacion, Orientacion, Curso, Grado, IdGrupo, DatosGrupos.NombreTurno, IdTurno, Concat(Grado, ' ', IdGrupo) as Grupo from DatosGrupos, Turno, Adscriptos where Adscriptos.CiPersona=DatosGrupos.CiPersona and DatosGrupos.NombreTurno=Turno.NombreTurno;"

        reader = cmd.ExecuteReader()
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
                frm.lblValorTipoAdscripto.Text = reader("Adscripto")
                grado = reader("Grado")
                idgrupo = reader("IdGrupo")
                idOrientacion = reader("IdOrientacion").ToString()
            End If
        End While
        reader.Dispose()

        cmd = New MySqlCommand()
        cmd.Connection = conexion.Conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select Tiene_Ta.IdAsignatura, Tiene_Ta.Grado, Tiene_Ta.IdOrientacion, NombreAsignatura from Tiene_Ta, Asignatura where IdOrientacion=@IdOrientacion and Grado=@Grado and Tiene_Ta.IdAsignatura=Asignatura.IdAsignatura;"
        cmd.Parameters.AddWithValue("@IdOrientacion", idOrientacion)
        cmd.Parameters.AddWithValue("@Grado", frm.lblValorTipoGrado.Text)
        reader = cmd.ExecuteReader()
        Dim x As Integer = 1
        While reader.Read()
            Dim subcmd As New MySqlCommand()
            subcmd.Connection = subconexion.Conn
            subcmd.CommandType = CommandType.Text
            subcmd.CommandText = "select Tiene_Ag.IdAsignatura, CONCAT(NombrePersona, ' ', ApellidoPersona) as Profesor from Tiene_Ag, Persona, Grupo where Grupo.IdOrientacion=@IdOrientacion and IdAsignatura=@IdAsignatura and Tiene_Ag.NroGrupo=@NroGrupo and Grupo.Grado=@Grado and Persona.CiPersona=Tiene_Ag.CiPersona;"
            subcmd.Parameters.AddWithValue("@IdOrientacion", idOrientacion)
            subcmd.Parameters.AddWithValue("@IdAsignatura", reader("IdAsignatura"))
            subcmd.Parameters.AddWithValue("@NroGrupo", nroGrupo)
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
                    .CommandText = "select *, DATE_FORMAT(HoraInicio, '%H:%i') as HoraOrden from Calendario where Dia=@Dia and Grupo=@StringGrupo order by HoraOrden;"
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
                        row_dia(current_dia) = "Sin definir" & vbCrLf & ""
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

    ' frmAdminUsuarios
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
                If reader("CiPersona").Equals("-1") Then
                    Continue While
                End If
                frm.agregarUsuario(reader("CiPersona"), reader("TipoUsuario"), reader("AprobacionUsuario"))
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Public Sub eliminarUsuario_frmAdminUsuarios(sender As Object, ByVal frm As frmAdminUsuarios)
        Dim conexion As New Conexion()
        Dim ci, contraseña, tipousuario As String
        Dim aprobado As Boolean
        cargarDatos_frmAdminUsuarios(sender.Tag(0), frm)
        ci = frm.txtID.Text
        contraseña = frm.txtContraseña.Text
        tipousuario = frm.tipoSeleccionado
        aprobado = frm.chkHabilitado.Checked
        frm.nuevoUsuario(Nothing, Nothing)

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

            Try
                cmd.ExecuteNonQuery()
                MessageBox.Show("Usuario '" + sender.Tag(1) + "' eliminado.", "Usuario eliminado.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                ' Restauro el usuario...
                Using backCmd As New MySqlCommand()
                    With backCmd
                        .Connection = conexion.Conn
                        .CommandText = "INSERT INTO Usuario VALUES (@CiPersona, @TipoUsuario, @ContraseniaUsuario, @AprobacionUsuario);"
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@CiPersona", ci)
                        .Parameters.AddWithValue("@ContraseniaUsuario", contraseña)
                        .Parameters.AddWithValue("@AprobacionUsuario", aprobado)
                        .Parameters.AddWithValue("@TipoUsuario", tipousuario)
                    End With
                    backCmd.ExecuteNonQuery()
                End Using
                MessageBox.Show("El adscripto está asignado a un grupo, no se puede eliminar.", "Error al eliminar adscripto", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End Using

        frm.cargarUsuarios()
        frm.nuevoUsuario(Nothing, Nothing)
        conexion.Close() 'Cierra la conexión
    End Sub

    Public Sub cargarDatos_frmAdminUsuarios(ByVal ID As String, ByVal frm As frmAdminUsuarios)
        ' Carga los datos del usuario y los muestra en pantalla
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT *, NombrePersona, ApellidoPersona FROM `Usuario`, `Persona` WHERE Usuario.CiPersona=@CiPersona and Persona.CiPersona=Usuario.CiPersona;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@CiPersona", ID)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
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
                    .CommandText = "INSERT INTO `Usuario` VALUES (@CiPersona, @TipoUsuario, @ContraseniaUsuario, @AprobacionUsuario);"
                Else
                    .CommandText = "UPDATE `Usuario` SET TipoUsuario=@TipoUsuario, ContraseniaUsuario=@ContraseniaUsuario, AprobacionUsuario=@AprobacionUsuario WHERE CiPersona=@CiPersona;"
                End If

                .Parameters.AddWithValue("@CiPersona", frm.txtID.Text)
                .Parameters.AddWithValue("@ContraseniaUsuario", frm.txtContraseña.Text)
                .Parameters.AddWithValue("@AprobacionUsuario", frm.chkHabilitado.Checked)
                .Parameters.AddWithValue("@TipoUsuario", frm.tipoSeleccionado)
            End With

            Try
                Using subCmd As New MySqlCommand()
                    With subCmd
                        .Connection = conexion.Conn
                        If frm.btnAgregar.Text.Equals("Agregar usuario") Then
                            .CommandText = "INSERT INTO `Persona` VALUES (@CiPersona, @Nombre, @Apellido);"
                        Else
                            .CommandText = "UPDATE `Persona` SET NombrePersona=@Nombre, ApellidoPersona=@Apellido where CiPersona=@CiPersona;"
                        End If
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@CiPersona", frm.txtID.Text)
                        .Parameters.AddWithValue("@Nombre", frm.txtNombre.Text)
                        .Parameters.AddWithValue("@Apellido", frm.txtApellido.Text)
                    End With
                    subCmd.ExecuteNonQuery()
                End Using

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

    ' frmAdminDocentes
    Public Sub cargarAreas_frmAdminDocentes(ByVal frm As frmAdminDocentes)
        ' Carga areas
        Dim conexion As New Conexion()
        Dim IdOrientacion As String = ""
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
                .CommandText = "select DISTINCT Area.IdArea, NombreArea from (select Asignatura.IdArea from Tiene_Ta, Asignatura where Tiene_Ta.IdAsignatura=Asignatura.IdAsignatura and Tiene_Ta.IdOrientacion=@IdOrientacion and Tiene_Ta.Grado=@Grado) Orientacion, Area where Orientacion.IdArea=Area.IdArea;"
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
        ' Llena los combos con los datos de la Logica.
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
                .CommandText = "SELECT Profesor.CiPersona, Persona.NombrePersona, Persona.ApellidoPersona FROM `Profesor`, `Persona` where Profesor.CiPersona=Persona.CiPersona;"
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
                    .CommandText = "INSERT INTO `Profesor` VALUES (@CiPersona, @GradoProfesor);"
                Else
                    .CommandText = "UPDATE `Profesor` SET GradoProfesor=@GradoProfesor WHERE CiPersona=@CiPersona;"
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
                .CommandText = "SELECT Profesor.CiPersona, Profesor.GradoProfesor, Persona.NombrePersona, Persona.ApellidoPersona FROM `Profesor`, `Persona` where Profesor.CiPersona=@CiPersona and Profesor.CiPersona=Persona.CiPersona;"
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
        Dim nroGrupo As Integer

        Using primerCmd As New MySqlCommand()
            With primerCmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text
                .CommandText = "select * from Grupo where CONCAT(Grado, ' ', IdGrupo)=@Grupo;"
                .Parameters.AddWithValue("@Grupo", frm.lstAsignaturas.SelectedItems.Item(0).SubItems(1).Text)
            End With
            Dim reader As MySqlDataReader = primerCmd.ExecuteReader()
            While reader.Read()
                nroGrupo = reader("NroGrupo")
            End While
            reader.Close()
        End Using

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM `Tiene_Ag` WHERE NroGrupo=@NroGrupo and IdAsignatura=@IdAsignatura and CiPersona=@CiPersona;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IdAsignatura", frm.lstAsignaturas.SelectedItems.Item(0).SubItems(0).Text)
                .Parameters.AddWithValue("@NroGrupo", nroGrupo)
                .Parameters.AddWithValue("@CiPersona", frm.txtCI.Text)
            End With
            Try
                Dim subCmd As New MySqlCommand()
                subCmd.Connection = conexion.Conn
                subCmd.CommandType = CommandType.Text
                subCmd.CommandText = "UPDATE `Genera` SET `CiPersona`='-1' WHERE `IdAsignatura`=@IdAsignatura and `NroGrupo`=@NroGrupo and`CiPersona`=@CiPersona;"
                subCmd.Parameters.AddWithValue("@IdAsignatura", frm.lstAsignaturas.SelectedItems.Item(0).SubItems(0).Text)
                subCmd.Parameters.AddWithValue("@NroGrupo", nroGrupo)
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
        ci = ""
        nombre = ""
        apellido = ""
        grado = ""
        Dim backupDatos As New MySqlCommand()
        backupDatos.Connection = conexion.Conn
        backupDatos.CommandText = "SELECT Profesor.CiPersona, Profesor.GradoProfesor, Persona.NombrePersona, Persona.ApellidoPersona FROM `Profesor`, `Persona` where Profesor.CiPersona=@CiPersona and Profesor.CiPersona=Persona.CiPersona;"
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
                MessageBox.Show("Docente '" + sender.Tag(1) + "' eliminado.", "Docente eliminado.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("El docente no se puede eliminar, ya que tiene materias asignadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ' No encontre una forma de arreglarlo. :/ así que tengo que crear el docente nuevamente.
                Try
                    Using subSubCmd As New MySqlCommand()
                        With subSubCmd
                            .Connection = conexion.Conn
                            .CommandText = "INSERT INTO `Profesor` VALUES (@CiPersona, @GradoProfesor)"
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
                .CommandText = "SELECT IdAsignatura, IdGrupo, FechaToma, Grado FROM `Tiene_Ag`, `Grupo` WHERE Tiene_Ag.CiPersona=@CiPersona and Grupo.NroGrupo=Tiene_Ag.NroGrupo;"
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
        Dim subconexion As New Conexion()
        Dim yaEsta As Boolean = False
        Dim nroGrupo As Integer

        Using primerCmd As New MySqlCommand()
            With primerCmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text
                .CommandText = "select * from Grupo where CONCAT(Grado, ' ', IdGrupo)=@Grupo"
                .Parameters.AddWithValue("@Grupo", frm.cmbGrupo.Text.Substring(0, frm.cmbGrupo.Text.IndexOf(" - ")))
            End With
            Dim reader As MySqlDataReader = primerCmd.ExecuteReader()
            While reader.Read()
                nroGrupo = reader("NroGrupo")
            End While
            reader.Close()
        End Using

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text
                .CommandText = "SELECT * from `Tiene_Ag`, `Grupo` WHERE IdAsignatura=@IdAsignatura and CONCAT(Grupo.Grado, ' ', Grupo.IdGrupo)=@Grupo and Tiene_Ag.NroGrupo=Grupo.NroGrupo;"
                .Parameters.AddWithValue("@IdAsignatura", frm.cmbAsignatura.Text.Substring(0, frm.cmbAsignatura.Text.IndexOf(" - ")).Trim())
                .Parameters.AddWithValue("@Grupo", frm.cmbGrupo.Text.Substring(0, frm.cmbGrupo.Text.IndexOf(" - ")))
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
                .CommandText = "INSERT INTO `Tiene_Ag` VALUES (@IdAsignatura, @NroGrupo, @FechaToma, @GradoAreaProfesor, @CiPersona);"
                .Parameters.AddWithValue("@CiPersona", frm.txtCI.Text)
                .Parameters.AddWithValue("@IdAsignatura", frm.cmbAsignatura.Text.Substring(0, frm.cmbAsignatura.Text.IndexOf(" - ")).Trim())
                .Parameters.AddWithValue("@NroGrupo", nroGrupo)
                Dim d As DateTime = Now
                .Parameters.AddWithValue("@FechaToma", d.ToString("yyyy-MM-dd"))
                .Parameters.AddWithValue("@GradoAreaProfesor", frm.numGradoArea.Value)
            End With

            Try
                cmd.ExecuteNonQuery()

                Dim subCmd As New MySqlCommand()
                subCmd.Connection = subconexion.Conn
                subCmd.CommandType = CommandType.Text
                subCmd.CommandText = "select IdAsignatura, CONCAT(Grado, ' ', IdGrupo) as Grupo from Genera, Grupo, (select HoraInicio, Dia from Genera where IdAsignatura=@IdAsignatura and Genera.NroGrupo=@NroGrupo) AEC where Genera.CiPersona=@CiPersona and Genera.HoraInicio=AEC.HoraInicio and Genera.Dia=AEC.Dia and Grupo.NroGrupo=@NroGrupo;"
                subCmd.Parameters.AddWithValue("@CiPersona", frm.txtCI.Text)
                subCmd.Parameters.AddWithValue("@IdAsignatura", frm.cmbAsignatura.Text.Substring(0, frm.cmbAsignatura.Text.IndexOf(" - ")).Trim())
                subCmd.Parameters.AddWithValue("@NroGrupo", nroGrupo)
                Dim reader As MySqlDataReader = subCmd.ExecuteReader()
                Dim mensajeMostrado As Boolean = False
                While reader.Read()
                    If Not mensajeMostrado Then
                        MessageBox.Show("El docente ya tiene un grupo asignado (" & reader("Grupo") & ") en el horario de ésta asignatura." & vbCrLf & "Se recomienda acomodar los horarios en la vista de Horarios.", "Conflictos detectados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        mensajeMostrado = True
                    End If
                End While
                reader.Close()

                subCmd = New MySqlCommand()
                subCmd.Connection = conexion.Conn
                subCmd.CommandType = CommandType.Text
                subCmd.CommandText = "UPDATE `Genera` SET `CiPersona`=@CiPersona WHERE `IdAsignatura`=@IdAsignatura and `NroGrupo`=@NroGrupo;"
                subCmd.Parameters.AddWithValue("@CiPersona", frm.txtCI.Text)
                subCmd.Parameters.AddWithValue("@IdAsignatura", frm.cmbAsignatura.Text.Substring(0, frm.cmbAsignatura.Text.IndexOf(" - ")).Trim())
                subCmd.Parameters.AddWithValue("@NroGrupo", nroGrupo)
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
        subconexion.Close()
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
                .CommandText = "select Asignatura.IdArea, Asignatura.IdAsignatura, Asignatura.NombreAsignatura, Tiene_Ta.IdOrientacion from (select DISTINCT Area.IdArea, NombreArea from (select Asignatura.IdArea from Tiene_Ta, Asignatura where Tiene_Ta.IdAsignatura=Asignatura.IdAsignatura and Tiene_Ta.IdOrientacion=@IdOrientacion) Orientacion, Area where Orientacion.IdArea=Area.IdArea) Areas, Asignatura, Tiene_Ta where Asignatura.IdArea=Areas.IdArea and Tiene_Ta.IdAsignatura=Asignatura.IdAsignatura and Tiene_Ta.Grado=@Grado and IdOrientacion=@IdOrientacion1 and Asignatura.IdArea=@IdArea;"
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

    ' frmAdminHorarios
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

        Dim nroGrupo As Integer

        Using primerCmd As New MySqlCommand()
            With primerCmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text
                .CommandText = "select * from Grupo where CONCAT(Grado, ' ', IdGrupo)=@Grupo;"
                .Parameters.AddWithValue("@Grupo", frm.cmbGrupo.Text)
            End With
            Dim reader As MySqlDataReader = primerCmd.ExecuteReader()
            While reader.Read()
                nroGrupo = reader("NroGrupo")
            End While
            reader.Close()
        End Using

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
                    .CommandText = "select DISTINCT AO.IdAsignatura, NombreAsignatura, CargaHoraria from (select Tiene_Ta.*, Asignatura.NombreAsignatura from Tiene_Ta, Asignatura WHERE Asignatura.IdAsignatura=Tiene_Ta.IdAsignatura) AO, Grupo WHERE Grupo.IdOrientacion=AO.IdOrientacion and Grupo.IdGrupo=@IdGrupo AND Grupo.Grado=@Grado AND AO.Grado=Grupo.Grado;"
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@Grado", Integer.Parse(frm.cmbGrupo.Text.Substring(0, frm.cmbGrupo.Text.IndexOf(" ")).Trim()))
                    .Parameters.AddWithValue("@IdGrupo", frm.cmbGrupo.Text.Substring(frm.cmbGrupo.Text.IndexOf(" "), frm.cmbGrupo.Text.Length - 1).Trim())
                End With

                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    For carga As Integer = 1 To Integer.Parse(reader("CargaHoraria"))
                        Dim materia As Button
                        materia = New Button()
                        AddHandler materia.MouseEnter, AddressOf frm.fixScroll
                        AddHandler materia.MouseWheel, AddressOf frm.fixScroll
                        materia.TabStop = False
                        materia.Cursor = Cursors.Hand

                        ' Quien enseña la materia?
                        Dim subCmd As New MySqlCommand()
                        Dim nombreProfesor As String = "Sin profesor"
                        Dim ciProfesor As String = "-1"
                        subCmd.Connection = subConexion.Conn
                        subCmd.CommandText = "select Tiene_Ag.CiPersona, Concat(NombrePersona, ' ', ApellidoPersona) as 'Profesor' from Tiene_Ag, Persona where IdAsignatura=@IdAsignatura and NroGrupo=@NroGrupo and Tiene_Ag.CiPersona=Persona.CiPersona;"
                        subCmd.Parameters.AddWithValue("@NroGrupo", nroGrupo)
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
                        AddHandler materia.MouseEnter, AddressOf frm.fixScroll
                        AddHandler materia.MouseWheel, AddressOf frm.fixScroll
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
        cmd.CommandText = "select IdTurno from Grupo where CONCAT(Grado, ' ', IdGrupo)=@Grupo;"
        cmd.Parameters.AddWithValue("@Grupo", frm.cmbGrupo.Text)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()
        reader.Read()
        Dim IdTurno As String = reader("IdTurno").ToString()
        reader.Close()

        cmd = New MySqlCommand()
        cmd.Connection = conexion.Conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select DISTINCT HoraInicio, HoraFin from Asignacion where IdTurno=@IdTurno;"
        cmd.Parameters.AddWithValue("@IdTurno", IdTurno)
        frm._IdTurno = IdTurno

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

        Dim nroGrupo As Integer
        Using primerCmd As New MySqlCommand()
            With primerCmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text
                .CommandText = "select * from Grupo where CONCAT(Grado, ' ', IdGrupo)=@Grupo;"
                .Parameters.AddWithValue("@Grupo", frm.cmbGrupo.Text)
            End With
            Dim reader As MySqlDataReader = primerCmd.ExecuteReader()
            While reader.Read()
                nroGrupo = reader("NroGrupo")
            End While
            reader.Close()
        End Using

        frm.frmAdministrar.habilitarBotones(False)

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
                    cmd2.CommandType = CommandType.Text

                    Dim btn As Button = New Button()
                    AddHandler btn.MouseEnter, AddressOf frm.fixScroll
                    AddHandler btn.MouseWheel, AddressOf frm.fixScroll
                    If dia.Equals("Lunes") Then
                        If horarios(hora_n).Equals(frm.horarioPrimera) Then
                            Try
                                btn = frm.tableLunes1.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSegunda) Then
                            Try
                                btn = frm.tableLunes2.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioTercera) Then
                            Try
                                btn = frm.tableLunes3.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioCuarta) Then
                            Try
                                btn = frm.tableLunes4.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioQuinta) Then
                            Try
                                btn = frm.tableLunes5.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSexta) Then
                            Try
                                btn = frm.tableLunes6.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioExtra) Then
                            Try
                                btn = frm.tableLunes7.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                    End If
                    If dia.Equals("Martes") Then
                        If horarios(hora_n).Equals(frm.horarioPrimera) Then
                            Try
                                btn = frm.tableMartes1.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSegunda) Then
                            Try
                                btn = frm.tableMartes2.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioTercera) Then
                            Try
                                btn = frm.tableMartes3.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioCuarta) Then
                            Try
                                btn = frm.tableMartes4.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioQuinta) Then
                            Try
                                btn = frm.tableMartes5.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSexta) Then
                            Try
                                btn = frm.tableMartes6.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioExtra) Then
                            Try
                                btn = frm.tableMartes7.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                    End If
                    If dia.Equals("Miércoles") Then
                        If horarios(hora_n).Equals(frm.horarioPrimera) Then
                            Try
                                btn = frm.tableMiercoles1.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSegunda) Then
                            Try
                                btn = frm.tableMiercoles2.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioTercera) Then
                            Try
                                btn = frm.tableMiercoles3.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioCuarta) Then
                            Try
                                btn = frm.tableMiercoles4.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioQuinta) Then
                            Try
                                btn = frm.tableMiercoles5.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSexta) Then
                            Try
                                btn = frm.tableMiercoles6.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioExtra) Then
                            Try
                                btn = frm.tableMiercoles7.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                    End If
                    If dia.Equals("Jueves") Then
                        If horarios(hora_n).Equals(frm.horarioPrimera) Then
                            Try
                                btn = frm.tableJueves1.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSegunda) Then
                            Try
                                btn = frm.tableJueves2.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioTercera) Then
                            Try
                                btn = frm.tableJueves3.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioCuarta) Then
                            Try
                                btn = frm.tableJueves4.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioQuinta) Then
                            Try
                                btn = frm.tableJueves5.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSexta) Then
                            Try
                                btn = frm.tableJueves6.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioExtra) Then
                            Try
                                btn = frm.tableJueves7.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                    End If
                    If dia.Equals("Viernes") Then
                        If horarios(hora_n).Equals(frm.horarioPrimera) Then
                            Try
                                btn = frm.tableViernes1.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSegunda) Then
                            Try
                                btn = frm.tableViernes2.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioTercera) Then
                            Try
                                btn = frm.tableViernes3.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioCuarta) Then
                            Try
                                btn = frm.tableViernes4.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioQuinta) Then
                            Try
                                btn = frm.tableViernes5.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSexta) Then
                            Try
                                btn = frm.tableViernes6.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioExtra) Then
                            Try
                                btn = frm.tableViernes7.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                    End If
                    If dia.Equals("Sábado") Then
                        If horarios(hora_n).Equals(frm.horarioPrimera) Then
                            Try
                                btn = frm.tableSabado1.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSegunda) Then
                            Try
                                btn = frm.tableSabado2.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioTercera) Then
                            Try
                                btn = frm.tableSabado3.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioCuarta) Then
                            Try
                                btn = frm.tableSabado4.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioQuinta) Then
                            Try
                                btn = frm.tableSabado5.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioSexta) Then
                            Try
                                btn = frm.tableSabado6.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                        If horarios(hora_n).Equals(frm.horarioExtra) Then
                            Try
                                btn = frm.tableSabado7.Controls(0)
                            Catch ex As Exception
                                btn.Tag = {"-1", "-1"}
                            End Try
                        End If
                    End If

                    cmd2.CommandText = "INSERT INTO `Genera` VALUES (@IdAsignatura, @NroGrupo, @HoraInicio, @HoraFin, @Dia, @IdTurno, @CiPersona)"
                    cmd2.Parameters.AddWithValue("@IdAsignatura", btn.Tag(0))
                    Dim idGrupo As String = frm.cmbGrupo.Text.Substring(frm.cmbGrupo.Text.IndexOf(" "), frm.cmbGrupo.Text.Length - 1).ToString()
                    cmd2.Parameters.AddWithValue("@NroGrupo", nroGrupo)
                    cmd2.Parameters.AddWithValue("@HoraInicio", horarios(hora_n))
                    cmd2.Parameters.AddWithValue("@HoraFin", horarios(hora_n + 1))
                    cmd2.Parameters.AddWithValue("@Dia", dia)
                    cmd2.Parameters.AddWithValue("@IdTurno", frm._IdTurno)
                    cmd2.Parameters.AddWithValue("@CiPersona", btn.Tag(1))

                    Try
                        Dim cmd_check As New MySqlCommand()
                        cmd_check.Connection = conexion_check.Conn
                        cmd_check.CommandType = CommandType.Text
                        cmd_check.CommandText = "select IdAsignatura, Grupo, Dia, CiPersona, NombreProfesor from Calendario where CiPersona=@CiPersona and HoraInicio=@horaInicio and Dia=@dia;"
                        If Not btn.Tag(1).ToString().Equals("-1") Then

                            cmd_check.Parameters.AddWithValue("@horainicio", horarios(hora_n))
                            cmd_check.Parameters.AddWithValue("@CiPersona", btn.Tag(1))
                            cmd_check.Parameters.AddWithValue("@dia", dia)
                            Dim reader_check = cmd_check.ExecuteReader()
                            While reader_check.Read()
                                If reader_check("IdAsignatura").ToString().Equals(btn.Tag(0)) And reader_check("Grupo").ToString().Equals(frm.cmbGrupo.Text) Then
                                    Continue While
                                End If
                                hora_n += 1
                                MessageBox.Show("El profesor '" & reader_check("NombreProfesor") & "' ya enseña una materia al grupo " & reader_check("Grupo") & " el día: " & dia & " a la hora " & horarios(hora_n), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                huboError = True
                                reader_check.Close()
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
                                .CommandText = "DELETE FROM `Genera` WHERE HoraInicio=@HoraInicio and HoraFin=@HoraFin and Dia=@Dia and NroGrupo=@NroGrupo and IdTurno=@IdTurno;"
                                .CommandType = CommandType.Text
                                idGrupo = frm.cmbGrupo.Text.Substring(frm.cmbGrupo.Text.IndexOf(" "), frm.cmbGrupo.Text.Length - 1).ToString()
                                .Parameters.AddWithValue("@HoraInicio", horarios(hora_n))
                                .Parameters.AddWithValue("@HoraFin", horarios(hora_n + 1))
                                .Parameters.AddWithValue("@Dia", dia)
                                .Parameters.AddWithValue("@NroGrupo", nroGrupo)
                                .Parameters.AddWithValue("@IdTurno", frm._IdTurno)
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


        frm.dialogoEspere.SendToBack()
        frm.frmAdministrar.habilitarBotones(True)
        If Not huboError Then
            cargarMaterias_frmAdminHorarios(frm)
            MessageBox.Show("Asignación de horarios guardada", "Todo salió bien", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frm.frmMain.recargarGrupo()
        End If

    End Sub

    ' Miscelaneo
    Dim max_horas_diarias As Integer = 7
    Dim materias_auxiliares(1) As Array
    Dim materias_ordenadas(1) As Array
    Dim asignacionLunes(1) As String
    Dim asignacionMartes(1) As String
    Dim asignacionMiercoles(1) As String
    Dim asignacionJueves(1) As String
    Dim asignacionViernes(1) As String
    Dim asignacionSabado(1) As String

    Public Function cargarMateriasAsignacion(ByVal frm As frmAdminGrupos) As Object
        Dim IdTurno, NroGrupo As String
        Dim conexion As New Conexion()
        Dim cmd As New MySqlCommand()
        cmd.Connection = conexion.Conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select NroGrupo, Tiene_Ta.IdAsignatura, CargaHoraria, EnseniaDeCorrido, Tiene_Ta.IdOrientacion, Grupo.IdTurno from Tiene_Ta, Grupo, Asignatura where Tiene_Ta.IdAsignatura=Asignatura.IdAsignatura and Tiene_Ta.IdOrientacion=Grupo.IdOrientacion and Grupo.IdGrupo=@IdGrupo and Grupo.Grado=@Grado and Tiene_Ta.Grado=Grupo.Grado order by `CargaHoraria` DESC;"
        cmd.Parameters.AddWithValue("@Grado", frm.cboGrado.Text)
        cmd.Parameters.AddWithValue("@IdGrupo", frm.txtIdGrupo.Text)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()
        Dim pos As Integer = 0
        While reader.Read()
            materias_auxiliares(pos) = {reader("IdAsignatura"), reader("CargaHoraria"), reader("EnseniaDeCorrido")}
            IdTurno = reader("IdTurno")
            NroGrupo = reader("NroGrupo")
            pos += 1
            ReDim Preserve materias_auxiliares(pos + 1)
        End While
        reader.Close()
        conexion.Close()

        ReDim Preserve materias_auxiliares(pos - 1)
        Return {NroGrupo, IdTurno}
    End Function

    Public Sub crearModulos()
        Dim pos As Integer = 0
        For Each materia As Object In materias_auxiliares
            If Not materia(2) And materia(1) > 1 Then
                While materia(1) > 0
                    If materia(1) = 1 Then
                        materia = {materia(0), 0, False}
                        materias_ordenadas(pos) = {materia(0), 1, "-"}
                    ElseIf materia(1) = 2 Then
                        materia = {materia(0), 0, False}
                        materias_ordenadas(pos) = {materia(0), 2, "-"}
                    Else
                        materia = {materia(0), materia(1) - 2, False}
                        materias_ordenadas(pos) = {materia(0), 2, "-"}
                    End If

                    pos += 1
                    ReDim Preserve materias_ordenadas(pos + 1)
                End While
            ElseIf materia(2) Then
                materias_ordenadas(pos) = {materia(0), materia(1), "--"}
                pos += 1
                ReDim Preserve materias_ordenadas(pos + 1)
            End If
        Next
        ReDim Preserve materias_ordenadas(materias_ordenadas.Length - 1)
    End Sub

    Public Sub repartirHorarios(ByVal frm As frmAdminGrupos)
        ReDim Me.materias_auxiliares(1)
        ReDim Me.materias_ordenadas(1)
        ReDim Me.asignacionLunes(1)
        ReDim Me.asignacionMartes(1)
        ReDim Me.asignacionMiercoles(1)
        ReDim Me.asignacionJueves(1)
        ReDim Me.asignacionViernes(1)
        ReDim Me.asignacionSabado(1)
        Try
            repartirHorariosAutomagicamente(frm)
        Catch ex As Exception
            Console.WriteLine(ex)
            MessageBox.Show("Hubieron errores al hacer la asignación inicial de materias." & vbCrLf & "Deberá modificar las asignaturas manualmente en la pestaña horarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Public Sub repartirHorariosAutomagicamente(ByVal frm As frmAdminGrupos)
        Dim infoGrupo As Object = cargarMateriasAsignacion(frm)
        Dim NroGrupo, IdTurno As String
        NroGrupo = infoGrupo(0)
        IdTurno = infoGrupo(1)
        crearModulos()

        Dim materias_asignadas(materias_ordenadas.Length) As Array

        Dim posLunes As Integer = 0
        Dim posMartes As Integer = 0
        Dim posMiercoles As Integer = 0
        Dim posJueves As Integer = 0
        Dim posViernes As Integer = 0
        Dim posSabado As Integer = 0
        Dim pos As Integer = 0
        For value As Integer = 0 To 50
            For Each materia As Object In materias_ordenadas
                If materias_asignadas.Contains(materia) Then
                    Continue For
                End If

                If value > 25 And Not IdTurno = 3 Then
                    max_horas_diarias = 8
                Else
                    max_horas_diarias = 7
                End If

                If max_horas_diarias > asignacionLunes.Length - 1 + materia(1) And Not asignacionLunes.Contains(materia(0)) Then
                    Dim x As Integer = 0
                    While x < materia(1)
                        asignacionLunes(posLunes) = materia(0)
                        x += 1
                        posLunes += 1
                        ReDim Preserve asignacionLunes(posLunes)
                    End While
                    materias_asignadas(pos) = materia
                    pos += 1
                ElseIf max_horas_diarias > asignacionMartes.Length - 1 + materia(1) And Not asignacionMartes.Contains(materia(0)) Then
                    Dim x As Integer = 0
                    While x < materia(1)
                        asignacionMartes(posMartes) = materia(0)
                        x += 1
                        posMartes += 1
                        ReDim Preserve asignacionMartes(posMartes)
                    End While
                    materias_asignadas(pos) = materia
                    pos += 1

                ElseIf max_horas_diarias > asignacionMiercoles.Length - 1 + materia(1) And Not asignacionMiercoles.Contains(materia(0)) Then
                    Dim x As Integer = 0
                    While x < materia(1)
                        asignacionMiercoles(posMiercoles) = materia(0)
                        x += 1
                        posMiercoles += 1
                        ReDim Preserve asignacionMiercoles(posMiercoles)
                    End While
                    materias_asignadas(pos) = materia
                    pos += 1

                ElseIf max_horas_diarias > asignacionJueves.Length - 1 + materia(1) And Not asignacionJueves.Contains(materia(0)) Then
                    Dim x As Integer = 0
                    While x < materia(1)
                        asignacionJueves(posJueves) = materia(0)
                        x += 1
                        posJueves += 1
                        ReDim Preserve asignacionJueves(posJueves)
                    End While
                    materias_asignadas(pos) = materia
                    pos += 1

                ElseIf max_horas_diarias > asignacionViernes.Length - 1 + materia(1) And Not asignacionViernes.Contains(materia(0)) Then
                    Dim x As Integer = 0
                    While x < materia(1)
                        asignacionViernes(posViernes) = materia(0)
                        x += 1
                        posViernes += 1
                        ReDim Preserve asignacionViernes(posViernes)
                    End While
                    materias_asignadas(pos) = materia
                    pos += 1

                ElseIf max_horas_diarias > asignacionSabado.Length - 1 + materia(1) And Not asignacionSabado.Contains(materia(0)) And max_horas_diarias <= 7 Then
                    Dim x As Integer = 0
                    While x < materia(1)
                        asignacionSabado(posSabado) = materia(0)
                        x += 1
                        posSabado += 1
                        ReDim Preserve asignacionSabado(posSabado)
                    End While
                    materias_asignadas(pos) = materia
                    pos += 1
                Else
                End If
            Next
        Next

        ReDim Preserve asignacionLunes(asignacionLunes.Length - 2)
        ReDim Preserve asignacionMartes(asignacionMartes.Length - 2)
        ReDim Preserve asignacionMiercoles(asignacionMiercoles.Length - 2)
        ReDim Preserve asignacionJueves(asignacionJueves.Length - 2)
        ReDim Preserve asignacionViernes(asignacionViernes.Length - 2)
        ReDim Preserve asignacionSabado(asignacionSabado.Length - 2)

        Dim horarioPrimera, finPrimera, _
            horarioSegunda, finSegunda, _
            horarioTercera, finTercera, _
            horarioCuarta, finCuarta, _
            horarioQuinta, finQuinta, _
            horarioSexta, finSexta, _
            horarioExtra, finExtra As String

        Dim cmd As New MySqlCommand()
        Dim conexion As New Conexion()
        cmd.Connection = conexion.Conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select DISTINCT HoraInicio, HoraFin from Asignacion where IdTurno=@IdTurno;"
        cmd.Parameters.AddWithValue("@IdTurno", IdTurno)

        Dim reader As MySqlDataReader = cmd.ExecuteReader()
        Dim posActual As Integer = 1
        While reader.Read()
            If posActual = 1 Then
                horarioPrimera = reader("HoraInicio").ToString()
                finPrimera = reader("HoraFin").ToString()
            ElseIf posActual = 2 Then
                horarioSegunda = reader("HoraInicio").ToString()
                finSegunda = reader("HoraFin").ToString()
            ElseIf posActual = 3 Then
                horarioTercera = reader("HoraInicio").ToString()
                finTercera = reader("HoraFin").ToString()
            ElseIf posActual = 4 Then
                horarioCuarta = reader("HoraInicio").ToString()
                finCuarta = reader("HoraFin").ToString()
            ElseIf posActual = 5 Then
                horarioQuinta = reader("HoraInicio").ToString()
                finQuinta = reader("HoraFin").ToString()
            ElseIf posActual = 6 Then
                horarioSexta = reader("HoraInicio").ToString()
                finSexta = reader("HoraFin").ToString()
            ElseIf posActual = 7 Then
                horarioExtra = reader("HoraInicio").ToString()
                finExtra = reader("HoraFin").ToString()
            End If
            posActual += 1
        End While
        reader.Close()

        Dim total As Integer = 0
        Dim horaActual As Integer = 1
        Dim sentencias(0) As Array
        Dim horaInicio, horaFin As String

        For Each item In asignacionLunes
            If horaActual = 1 Then
                horaInicio = horarioPrimera
                horaFin = finPrimera
            ElseIf horaActual = 2 Then
                horaInicio = horarioSegunda
                horaFin = finSegunda
            ElseIf horaActual = 3 Then
                horaInicio = horarioTercera
                horaFin = finTercera
            ElseIf horaActual = 4 Then
                horaInicio = horarioCuarta
                horaFin = finCuarta
            ElseIf horaActual = 5 Then
                horaInicio = horarioQuinta
                horaFin = finQuinta
            ElseIf horaActual = 6 Then
                horaInicio = horarioSexta
                horaFin = finSexta
            ElseIf horaActual = 7 Then
                horaInicio = horarioExtra
                horaFin = finExtra
            End If
            sentencias(total) = {item, NroGrupo, horaInicio, horaFin, "Lunes", IdTurno, "-1"}

            horaActual += 1
            total += 1
            ReDim Preserve sentencias(total)
        Next


        horaActual = 1
        For Each item In asignacionMartes
            If horaActual = 1 Then
                horaInicio = horarioPrimera
                horaFin = finPrimera
            ElseIf horaActual = 2 Then
                horaInicio = horarioSegunda
                horaFin = finSegunda
            ElseIf horaActual = 3 Then
                horaInicio = horarioTercera
                horaFin = finTercera
            ElseIf horaActual = 4 Then
                horaInicio = horarioCuarta
                horaFin = finCuarta
            ElseIf horaActual = 5 Then
                horaInicio = horarioQuinta
                horaFin = finQuinta
            ElseIf horaActual = 6 Then
                horaInicio = horarioSexta
                horaFin = finSexta
            ElseIf horaActual = 7 Then
                horaInicio = horarioExtra
                horaFin = finExtra
            End If
            sentencias(total) = {item, NroGrupo, horaInicio, horaFin, "Martes", IdTurno, "-1"}
            horaActual += 1
            total += 1
            ReDim Preserve sentencias(total)
        Next

        horaActual = 1
        For Each item In asignacionMiercoles
            If horaActual = 1 Then
                horaInicio = horarioPrimera
                horaFin = finPrimera
            ElseIf horaActual = 2 Then
                horaInicio = horarioSegunda
                horaFin = finSegunda
            ElseIf horaActual = 3 Then
                horaInicio = horarioTercera
                horaFin = finTercera
            ElseIf horaActual = 4 Then
                horaInicio = horarioCuarta
                horaFin = finCuarta
            ElseIf horaActual = 5 Then
                horaInicio = horarioQuinta
                horaFin = finQuinta
            ElseIf horaActual = 6 Then
                horaInicio = horarioSexta
                horaFin = finSexta
            ElseIf horaActual = 7 Then
                horaInicio = horarioExtra
                horaFin = finExtra
            End If
            sentencias(total) = {item, NroGrupo, horaInicio, horaFin, "Miércoles", IdTurno, "-1"}

            horaActual += 1
            total += 1
            ReDim Preserve sentencias(total)
        Next


        horaActual = 1
        For Each item In asignacionJueves
            If horaActual = 1 Then
                horaInicio = horarioPrimera
                horaFin = finPrimera
            ElseIf horaActual = 2 Then
                horaInicio = horarioSegunda
                horaFin = finSegunda
            ElseIf horaActual = 3 Then
                horaInicio = horarioTercera
                horaFin = finTercera
            ElseIf horaActual = 4 Then
                horaInicio = horarioCuarta
                horaFin = finCuarta
            ElseIf horaActual = 5 Then
                horaInicio = horarioQuinta
                horaFin = finQuinta
            ElseIf horaActual = 6 Then
                horaInicio = horarioSexta
                horaFin = finSexta
            ElseIf horaActual = 7 Then
                horaInicio = horarioExtra
                horaFin = finExtra
            End If
            sentencias(total) = {item, NroGrupo, horaInicio, horaFin, "Jueves", IdTurno, "-1"}
            horaActual += 1
            total += 1
            ReDim Preserve sentencias(total)
        Next

        horaActual = 1
        For Each item In asignacionViernes
            If horaActual = 1 Then
                horaInicio = horarioPrimera
                horaFin = finPrimera
            ElseIf horaActual = 2 Then
                horaInicio = horarioSegunda
                horaFin = finSegunda
            ElseIf horaActual = 3 Then
                horaInicio = horarioTercera
                horaFin = finTercera
            ElseIf horaActual = 4 Then
                horaInicio = horarioCuarta
                horaFin = finCuarta
            ElseIf horaActual = 5 Then
                horaInicio = horarioQuinta
                horaFin = finQuinta
            ElseIf horaActual = 6 Then
                horaInicio = horarioSexta
                horaFin = finSexta
            ElseIf horaActual = 7 Then
                horaInicio = horarioExtra
                horaFin = finExtra
            End If
            sentencias(total) = {item, NroGrupo, horaInicio, horaFin, "Viernes", IdTurno, "-1"}
            horaActual += 1
            total += 1
            ReDim Preserve sentencias(total)
        Next

        horaActual = 1
        For Each item In asignacionSabado
            If horaActual = 1 Then
                horaInicio = horarioPrimera
                horaFin = finPrimera
            ElseIf horaActual = 2 Then
                horaInicio = horarioSegunda
                horaFin = finSegunda
            ElseIf horaActual = 3 Then
                horaInicio = horarioTercera
                horaFin = finTercera
            ElseIf horaActual = 4 Then
                horaInicio = horarioCuarta
                horaFin = finCuarta
            ElseIf horaActual = 5 Then
                horaInicio = horarioQuinta
                horaFin = finQuinta
            ElseIf horaActual = 6 Then
                horaInicio = horarioSexta
                horaFin = finSexta
            ElseIf horaActual = 7 Then
                horaInicio = horarioExtra
                horaFin = finExtra
            End If
            sentencias(total) = {item, NroGrupo, horaInicio, horaFin, "Sábado", IdTurno, "-1"}
            horaActual += 1
            total += 1
            ReDim Preserve sentencias(total)
        Next

        ReDim Preserve sentencias(sentencias.Length - 1)
        Dim huboError = False

        For Each sentencia As Object In sentencias
            Dim subCmd As MySqlCommand
            Try
                subCmd = New MySqlCommand()
                subCmd.Connection = conexion.Conn
                subCmd.CommandType = CommandType.Text
                subCmd.CommandText = "INSERT INTO `Genera` VALUES (@IdAsignatura, @NroGrupo, @HoraInicio, @HoraFin, @Dia, @IdTurno, @CiPersona);"
                subCmd.Parameters.AddWithValue("@IdAsignatura", sentencia(0))
                subCmd.Parameters.AddWithValue("@NroGrupo", sentencia(1))
                subCmd.Parameters.AddWithValue("@HoraInicio", sentencia(2))
                subCmd.Parameters.AddWithValue("@HoraFin", sentencia(3))
                subCmd.Parameters.AddWithValue("@Dia", sentencia(4))
                subCmd.Parameters.AddWithValue("@IdTurno", sentencia(5))
                subCmd.Parameters.AddWithValue("@CiPersona", sentencia(6))
                subCmd.ExecuteNonQuery()
            Catch ex As Exception
            End Try
        Next

        For Each materia As Object In materias_ordenadas
            If materias_asignadas.Contains(materia) Then
                Continue For
            End If
            Try
                Console.WriteLine(materia(0))
                Throw New System.Exception("No se pueden asignar :(")
            Catch ex As Exception
                If ex.ToString().Contains("No se pueden") Then
                    Throw New System.Exception("No se pueden asignar :(")
                End If
            End Try
            Exit For
        Next

    End Sub
End Class
