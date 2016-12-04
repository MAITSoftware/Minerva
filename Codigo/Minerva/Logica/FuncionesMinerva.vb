Imports MySql.Data.MySqlClient
Public Class FuncionesMinerva

    Public Shared Sub CargarNombre(frm As frmMain)
        If frm.cuentaInvitado Then
            Return
        End If
        Dim InfoUsuario As Object = PersistenciaUsuarios.GetNombre(frm.NombreUsuario)
        Dim Nombre As String = InfoUsuario(0)
        Dim Apellido As String = InfoUsuario(1)

        If String.IsNullOrEmpty(Nombre) Or String.IsNullOrEmpty(Apellido) Then
            Try
                Dim x As New frmDatosUsuario(frm)
                x.ShowDialog(frm)
                CargarNombre(frm)
            Catch ex As Exception
                ' El usuario presionó salir.
            End Try
        Else
            frm.lblUsuario.Text = "Bienvenido " & Nombre & " " & Apellido & "."
        End If
    End Sub

    Public Shared Sub CrearMenuFiltrado(frm As frmMain)
        frm.cmsFiltrado.Items.Clear()
        Dim Item, Turno, Curso As ToolStripMenuItem
        Turno = New ToolStripMenuItem()
        Turno.Text = "Turno"

        Curso = New ToolStripMenuItem()
        Curso.Text = "Curso"

        Dim resultadosPersistenciaTurnos As Object = InformacionDB.GetTurnos()
        Dim readerTurno As MySqlDataReader = resultadosPersistenciaTurnos(0)
        While readerTurno.Read()
            Item = New ToolStripMenuItem()
            Item.Text = readerTurno("NombreTurno") & " (" & readerTurno("IdTurno") & ")"
            AddHandler Item.Click, AddressOf frm.filtroTurnoCambiado
            Turno.DropDownItems.Add(Item)
        End While

        readerTurno.Close()
        resultadosPersistenciaTurnos(1).Close()

        Dim resultadosPersistenciaCursos As Object = InformacionDB.GetCursos()
        Dim readerCurso As MySqlDataReader = resultadosPersistenciaCursos(0)
        While readerCurso.Read()
            Item = New ToolStripMenuItem()
            Item.Text = readerCurso("NombreCurso") & " (" & readerCurso("IdCurso") & ")"
            AddHandler Item.Click, AddressOf frm.filtroCursoCambiado
            Curso.DropDownItems.Add(Item)
        End While

        readerCurso.Close()
        resultadosPersistenciaCursos(1).Close()
        frm.cmsFiltrado.Items.Add(Turno)
        frm.cmsFiltrado.Items.Add(Curso)
    End Sub

    Public Shared Sub CargarGrupos(frm As frmMain)
        Dim CursoElegido As String = Nothing
        Dim TurnoElegido As String = Nothing

        frm.cboGrupo.Items.Clear()
        frm.cboGrupo.Items.Add("Elija un grupo")
        frm.cboGrupo.SelectedIndex = 0

        If Not IsNothing(frm.cursoElegido) And Not IsNothing(frm.turnoElegido) Then
            CursoElegido = frm.cursoElegido.Text.ToString()
            CursoElegido = CursoElegido.Substring(CursoElegido.IndexOf(" (") + 2).Trim(")")

            TurnoElegido = frm.turnoElegido.Text.ToString()
            TurnoElegido = TurnoElegido.Substring(TurnoElegido.IndexOf(" (") + 2).Trim(")")

        ElseIf Not IsNothing(frm.cursoElegido) Then
            CursoElegido = frm.cursoElegido.Text.ToString()
            CursoElegido = CursoElegido.Substring(CursoElegido.IndexOf(" (") + 2).Trim(")")

        ElseIf Not IsNothing(frm.turnoElegido) Then
            TurnoElegido = frm.turnoElegido.Text.ToString()
            TurnoElegido = TurnoElegido.Substring(TurnoElegido.IndexOf(" (") + 2).Trim(")")
        End If

        Dim resultadosPersistencia As Object = InformacionDB.GetGrupos(CursoElegido, TurnoElegido)
        Dim reader As MySqlDataReader = resultadosPersistencia(0)

        While reader.Read()
            frm.cboGrupo.Items.Add(reader("Grado").ToString() & " " & reader("IdGrupo"))
        End While

        reader.Close()
        resultadosPersistencia(1).Close()
    End Sub

    Public Shared Sub CargarInfoGrupo(frm As frmMain)
        frm.tblMaterias.Controls.Clear()
        frm.Cursor = Cursors.WaitCursor

        Dim IdOrientacion As String = ""
        Dim Grado As String = ""
        Dim IdGrupo As String = ""
        Dim NroGrupo As String = PersistenciaGrupos.GetNroGrupo(frm.cboGrupo.Text)

        Dim resultadosPersistenciaDetalles As Object = PersistenciaGrupos.GetDetalles(NroGrupo)
        Dim reader As MySqlDataReader = resultadosPersistenciaDetalles(0)
        While reader.Read()
            frm.lblValorTipoCurso.Text = reader("Curso")
            frm.lblValorTipoSalon.Text = reader("Salon")
            If frm.lblValorTipoSalon.Text.Equals("-1") Then
                frm.lblValorTipoSalon.Text = "Sin asignar"
            End If
            frm.lblValorTipoGrado.Text = reader("Grado")
            frm.lblValorTipoTurno.Text = reader("NombreTurno")
            frm.lblValorTipoTurno.Tag = reader("IdTurno").ToString()
            frm.lblValorTipoAdscripto.Text = reader("Adscripto")
        End While

        reader.Close()
        resultadosPersistenciaDetalles(1).Close()

        Dim resultadosPersistenciaMaterias As Object = PersistenciaAsignaturas.GetAllForGrupo(NroGrupo)
        Dim readerMaterias As MySqlDataReader = resultadosPersistenciaMaterias(0)
        Dim pos As Integer = 1

        While readerMaterias.Read()
            Dim NombreAsignatura As String = readerMaterias("NombreAsignatura")
            Dim NombreProfesor As String = PersistenciaAsignaturas.GetProfesor(readerMaterias("IdAsignatura"), NroGrupo)(0)

            Dim lblMateria As New Label
            Dim lblProfesor As New Label

            lblMateria.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            lblProfesor.Font = New Font("Microsoft Sans Serif", 12)
            lblProfesor.Padding = New Padding(0, 0, 0, 5)
            lblMateria.ForeColor = Color.White

            lblMateria.Text = NombreAsignatura
            lblProfesor.Text = "         " & NombreProfesor


            frm.tblMaterias.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0))
            frm.tblMaterias.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0))
            frm.tblMaterias.Controls.Add(lblMateria, 0, pos)
            frm.tblMaterias.Controls.Add(lblProfesor, 0, pos + 1)

            lblMateria.AutoSize = True
            lblProfesor.AutoSize = True
            pos += 2
        End While

        readerMaterias.Close()

        resultadosPersistenciaMaterias(1).Close()
        frm.Cursor = Cursors.Default
    End Sub

    Public Shared Sub CargarHorariosGrupo(frm As frmMain)
        Dim Dias As Object = {"Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"}
        frm.Cursor = Cursors.WaitCursor

        Dim Horarios(0) As String

        If frm.lblValorTipoTurno.Tag.Equals("3") Then
            ReDim Horarios(5)
        Else
            ReDim Horarios(6)
        End If

        Dim resultadosPersistenciaHorariosTurno As Object = PersistenciaHorarios.GetHorariosTurno(frm.lblValorTipoTurno.Tag)
        Dim readerHorariosTurno As MySqlDataReader = resultadosPersistenciaHorariosTurno(0)

        Dim Row_Primera(8) As String
        Dim Row_Segunda(8) As String
        Dim Row_Tercera(8) As String
        Dim Row_Cuarta(8) As String
        Dim Row_Quinta(8) As String
        Dim Row_Sexta(8) As String
        Dim Row_Extra(8) As String

        Dim Rows As Object = {Row_Primera, Row_Segunda, Row_Tercera, Row_Cuarta, Row_Quinta, Row_Sexta, Row_Extra}
        Dim WidgetDias As Object = {frm.Lunes, frm.Martes, frm.Miércoles, frm.Jueves, frm.Viernes, frm.Sábado}

        Dim pos As Integer = 0
        While readerHorariosTurno.Read()
            Horarios(pos) = readerHorariosTurno("HoraInicio").ToString()
            Rows(pos)(0) = readerHorariosTurno("HoraInicio").ToString()
            Rows(pos)(0) = Rows(pos)(0).Substring(0, Rows(pos)(0).Length - 3)
            pos += 1
        End While

        For Each Dia As String In Dias
            Dim resultadoPersistencia As Object = PersistenciaHorarios.GetCalendarioDiarioForGrupo(Dia, frm.cboGrupo.Text)
            Dim reader As MySqlDataReader = resultadoPersistencia(0)

            While reader.Read()
                Dim PosHora As Integer = Array.IndexOf(Horarios, reader("HoraInicio").ToString())
                Dim PosDia As Integer = Array.IndexOf(Dias, Dia)
                Dim WidgetDia As Object = WidgetDias(PosDia)

                If reader("Materia").Equals("Sin asignar") Then
                    Rows(PosHora)(PosDia + 1) = "Sin definir" & vbCrLf & ""
                    Continue While
                End If

                WidgetDia.agregarHora(reader("HoraOrden"), reader("Materia"))
                Rows(PosHora)(PosDia + 1) = reader("Materia") & vbCrLf & reader("NombreProfesor")
            End While

            reader.Close()
            resultadoPersistencia(1).Close()
        Next

        For Each row As Object In Rows
            pos = 0
            For Each Materia As String In row
                If String.IsNullOrWhiteSpace(Materia) Then
                    row(pos) = "Sin definir" & vbCrLf & ""
                End If
                pos += 1
            Next
        Next

        frm.Grilla.dgvMaterias.Rows.Add(Row_Primera)
        frm.Grilla.dgvMaterias.Rows.Add(Row_Segunda)
        frm.Grilla.dgvMaterias.Rows.Add(Row_Tercera)
        frm.Grilla.dgvMaterias.Rows.Add(Row_Cuarta)
        frm.Grilla.dgvMaterias.Rows.Add(Row_Quinta)
        frm.Grilla.dgvMaterias.Rows.Add(Row_Sexta)
        frm.Grilla.dgvMaterias.Rows.Add(Row_Extra)
        frm.Cursor = Cursors.Default

        readerHorariosTurno.Close()
        resultadosPersistenciaHorariosTurno(1).Close()
    End Sub
End Class
