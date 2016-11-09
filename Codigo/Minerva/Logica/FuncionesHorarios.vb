Imports MySql.Data.MySqlClient

Public Class FuncionesHorarios
    Public Shared Sub CargarGrupos(frm As frmAdminHorarios)
        frm.cmbGrupo.Items.Clear()
        frm.cmbGrupo.Items.Add("...")
        frm.cmbGrupo.SelectedIndex = 0
        Dim resultadosPersistencia As Object = InformacionDB.GetGrupos()

        Dim reader As MySqlDataReader = resultadosPersistencia(0)
        While reader.Read()
            frm.cmbGrupo.Items.Add(reader("Grado").ToString() + " " + reader("IdGrupo").ToString())
        End While
        reader.Close()

        resultadosPersistencia(1).Close()
    End Sub

    Public Shared Sub CargarAsignaturas(frm As frmAdminHorarios)
        frm.Cursor = Cursors.WaitCursor
        frm.pnlMaterias.Enabled = False

        frm.LimpiarTablas()

        Dim NroGrupo As String = PersistenciaGrupos.GetNroGrupo(frm.cmbGrupo.Text)

        Dim Tablas As Object = {frm.tableLunes, frm.tableMartes, frm.tableMiercoles, frm.tableJueves, frm.tableViernes, frm.tableSabado}
        For Each Tabla In Tablas
            Tabla.Enabled = False
        Next

        Dim BotonesAsignaturas As New List(Of List(Of Object))
        Dim Asignaturas As New List(Of String)

        Dim resultadosPersistenciaAsignaturas As Object = PersistenciaAsignaturas.GetAllForGrupo(NroGrupo)

        Dim readerAsignaturas As MySqlDataReader = resultadosPersistenciaAsignaturas(0)
        While readerAsignaturas.Read()
            For Carga As Integer = 1 To Integer.Parse(readerAsignaturas("CargaHoraria"))
                Dim Asignatura As New Button
                AddHandler Asignatura.MouseEnter, AddressOf frm.fixScroll
                AddHandler Asignatura.MouseWheel, AddressOf frm.fixScroll
                Asignatura.TabStop = False
                Asignatura.Cursor = Cursors.Hand

                If readerAsignaturas("IdAsignatura").Equals("-1") Then
                    Continue For
                End If

                Dim DatosProfesor As Object = PersistenciaAsignaturas.GetProfesor(readerAsignaturas("IdAsignatura"), NroGrupo)
                Dim NombreProfesor As String = DatosProfesor(0)
                Dim CiProfesor As String = DatosProfesor(1)

                If NombreProfesor.Equals("-1") Then
                    NombreProfesor = "Sin profesor"
                End If

                Asignatura.Text = readerAsignaturas("NombreAsignatura") & vbCrLf & NombreProfesor
                Asignatura.Tag = {readerAsignaturas("IdAsignatura"), CiProfesor}

                Asignatura.Size = New Size(144, 60)
                Asignatura.BackColor = Color.White
                Asignatura.FlatStyle = FlatStyle.Flat
                Asignatura.FlatAppearance.BorderColor = Color.Red
                Asignatura.FlatAppearance.MouseDownBackColor = Color.White
                Asignatura.FlatAppearance.MouseOverBackColor = Color.White

                If Asignaturas.Contains(readerAsignaturas("NombreAsignatura")) Then
                    BotonesAsignaturas(Asignaturas.IndexOf(readerAsignaturas("NombreAsignatura"))).Add(Asignatura)
                Else
                    Asignaturas.Add(readerAsignaturas("NombreAsignatura"))
                    BotonesAsignaturas.Add(New List(Of Object))
                    BotonesAsignaturas(Asignaturas.IndexOf(readerAsignaturas("NombreAsignatura"))).Add(Asignatura)
                End If

                AddHandler Asignatura.MouseDown, AddressOf frm.Materia_MouseDown
                frm.pnlMaterias.Controls.Add(Asignatura)
            Next
        End While

        readerAsignaturas.Close()
        resultadosPersistenciaAsignaturas(1).Close()

        Dim Dias() As String = {"Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"}
        Dim TablasLunes As Object = {frm.tableLunes1, frm.tableLunes2, frm.tableLunes3, frm.tableLunes4, frm.tableLunes5, frm.tableLunes6, frm.tableLunes7}
        Dim TablasMartes As Object = {frm.tableMartes1, frm.tableMartes2, frm.tableMartes3, frm.tableMartes4, frm.tableMartes5, frm.tableMartes6, frm.tableMartes7}
        Dim TablasMiercoles As Object = {frm.tableMiercoles1, frm.tableMiercoles2, frm.tableMiercoles3, frm.tableMiercoles4, frm.tableMiercoles5, frm.tableMiercoles6, frm.tableMiercoles7}
        Dim TablasJueves As Object = {frm.tableJueves1, frm.tableJueves2, frm.tableJueves3, frm.tableJueves4, frm.tableJueves5, frm.tableJueves6, frm.tableJueves7}
        Dim TablasViernes As Object = {frm.tableViernes1, frm.tableViernes2, frm.tableViernes3, frm.tableViernes4, frm.tableViernes5, frm.tableViernes6, frm.tableViernes7}
        Dim TablasSabado As Object = {frm.tableSabado1, frm.tableSabado2, frm.tableSabado3, frm.tableSabado4, frm.tableSabado5, frm.tableSabado6, frm.tableSabado7}
        Dim TablasDias As Object = {TablasLunes, TablasMartes, TablasMiercoles, TablasJueves, TablasViernes, TablasSabado}
        Dim Horas As Object = {frm.horarioPrimera, frm.horarioSegunda, frm.horarioTercera, frm.horarioCuarta, frm.horarioQuinta, frm.horarioSexta, frm.horarioExtra}

        Dim resultadosPersistenciaCalendario As Object = PersistenciaHorarios.GetCalendarioForGrupo(frm.cmbGrupo.Text)
        Dim readerCalendario As MySqlDataReader = resultadosPersistenciaCalendario(0)
        While readerCalendario.Read()
            If readerCalendario("Materia").Equals("Sin asignar") Then
                Continue While
            End If

            Try
                Dim Index As Integer = Asignaturas.IndexOf(readerCalendario("Materia"))
                Dim BotonAsignatura As Control = BotonesAsignaturas(Index).ToArray().Last()
                BotonesAsignaturas(Index).RemoveAt(BotonesAsignaturas(Index).Count - 1)
                Dim Dia As String = readerCalendario("Dia")

                Dim TablasDia As Object = TablasDias(Array.IndexOf(Dias, Dia))
                Dim Hora As Integer = Array.IndexOf(Horas, readerCalendario("HoraInicio").ToString())
                Dim Tabla As Object = TablasDia(Hora)
                If Not (Tabla.Controls.Count > 0) Then
                    frm.pnlMaterias.Controls.Remove(BotonAsignatura)
                    Tabla.Controls.Add(BotonAsignatura)
                End If
            Catch ex As Exception
            End Try
        End While

        readerCalendario.Close()
        resultadosPersistenciaCalendario(1).Close()

        frm.Cursor = Cursors.Default
        frm.pnlMaterias.Enabled = True

        For Each Tabla In Tablas
            Tabla.Enabled = True
        Next
    End Sub

    Public Shared Sub CargarHorariosTurno(frm As frmAdminHorarios)
        Dim IdTurno As String = PersistenciaGrupos.GetTurno(frm.cmbGrupo.Text)

        Dim resultadosPersistencia As Object = PersistenciaHorarios.GetHorariosTurno(IdTurno)
        Dim reader As MySqlDataReader = resultadosPersistencia(0)
        Dim posActual As Integer = 1
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

        If IdTurno.Equals("3") Then
            frm.pnlBordeOculto.Visible = True
            frm.pnlOcultarExtra.Visible = True
        Else
            frm.pnlBordeOculto.Visible = False
            frm.pnlOcultarExtra.Visible = False
        End If
        frm.actHorarios()

        reader.Close()
        resultadosPersistencia(1).Close()
    End Sub

    Public Shared Sub GuardarHorarios(frm As frmAdminHorarios)
        Dim NroGrupo As String = PersistenciaGrupos.GetNroGrupo(frm.cmbGrupo.Text)
        Dim IdTurno As String = PersistenciaGrupos.GetTurno(frm.cmbGrupo.Text)

        frm.frmAdministrar.habilitarBotones(False)

        Dim Tablas As Object = {frm.tableLunes, frm.tableMartes, frm.tableMiercoles, frm.tableJueves, frm.tableViernes, frm.tableSabado}
        For Each Tabla In Tablas
            Tabla.Enabled = False
        Next

        Dim Dias() As String = {"Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"}
        Dim TablasLunes As Object = {frm.tableLunes1, frm.tableLunes2, frm.tableLunes3, frm.tableLunes4, frm.tableLunes5, frm.tableLunes6, frm.tableLunes7}
        Dim TablasMartes As Object = {frm.tableMartes1, frm.tableMartes2, frm.tableMartes3, frm.tableMartes4, frm.tableMartes5, frm.tableMartes6, frm.tableMartes7}
        Dim TablasMiercoles As Object = {frm.tableMiercoles1, frm.tableMiercoles2, frm.tableMiercoles3, frm.tableMiercoles4, frm.tableMiercoles5, frm.tableMiercoles6, frm.tableMiercoles7}
        Dim TablasJueves As Object = {frm.tableJueves1, frm.tableJueves2, frm.tableJueves3, frm.tableJueves4, frm.tableJueves5, frm.tableJueves6, frm.tableJueves7}
        Dim TablasViernes As Object = {frm.tableViernes1, frm.tableViernes2, frm.tableViernes3, frm.tableViernes4, frm.tableViernes5, frm.tableViernes6, frm.tableViernes7}
        Dim TablasSabado As Object = {frm.tableSabado1, frm.tableSabado2, frm.tableSabado3, frm.tableSabado4, frm.tableSabado5, frm.tableSabado6, frm.tableSabado7}
        Dim TablasDias As Object = {TablasLunes, TablasMartes, TablasMiercoles, TablasJueves, TablasViernes, TablasSabado}
        Dim HorasInicio As Object = {frm.horarioPrimera, frm.horarioSegunda, frm.horarioTercera, frm.horarioCuarta, frm.horarioQuinta, frm.horarioSexta, frm.horarioExtra}
        Dim HorasFin As Object = {frm.finPrimera, frm.finSegunda, frm.finTercera, frm.finCuarta, frm.finQuinta, frm.finSexta, frm.finExtra}

        Dim HuboError As Boolean = False

        For Each Dia As String In Dias
            Dim TablasDia As Object = TablasDias(Array.IndexOf(Dias, Dia))

            For Each HoraStr As String In HorasInicio
                Dim Hora As Integer = Array.IndexOf(HorasInicio, HoraStr)
                Dim HoraInicio As String = HorasInicio(Hora)
                Dim HoraFin As String = HorasFin(Hora)

                Dim Tabla As TableLayoutPanel = TablasDia(Hora)

                Dim Btn As New Button
                AddHandler Btn.MouseEnter, AddressOf frm.fixScroll
                AddHandler Btn.MouseWheel, AddressOf frm.fixScroll

                Try
                    Btn = Tabla.Controls(0)
                Catch ex As Exception
                    Btn.Tag = {"-1", "-1"}
                End Try

                Dim resultadosConflicto As Object = PersistenciaDocentes.GetConflictoGuardado(HoraInicio, Btn.Tag(1), Dia, frm.cmbGrupo.Text, Btn.Tag(0))
                If resultadosConflicto(0) And Not Btn.Tag(1).ToString().Equals("-1") Then
                    If Not HuboError Then
                        MessageBox.Show("El profesor '" & resultadosConflicto(1) & "' ya enseña una materia al grupo " & resultadosConflicto(2) & " el día: " & Dia & " a la hora " & HoraInicio, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    End If
                    HuboError = True
                    Continue For
                End If

                PersistenciaHorarios.ForceDel(HoraInicio, HoraFin, Dia, NroGrupo, IdTurno)
                PersistenciaHorarios.Add(Btn.Tag(0), NroGrupo, HoraInicio, HoraFin, Dia, IdTurno, Btn.Tag(1))
            Next

            If HuboError Then
                MessageBox.Show("Se encontró al menos un error. Los cambios que ha realizado, no han quedado guardados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit For
            End If
        Next
        frm.Cursor = Cursors.Default

        For Each Tabla In Tablas
            Tabla.Enabled = True
        Next

        frm.dialogoEspere.SendToBack()
        frm.frmAdministrar.habilitarBotones(True)
        If Not HuboError Then
            FuncionesHorarios.CargarAsignaturas(frm)
            MessageBox.Show("Asignación de horarios guardada", "Todo salió bien", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frm.frmMain.RefrescarHorarios()
        End If
    End Sub
End Class
