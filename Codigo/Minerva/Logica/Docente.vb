Imports MySql.Data.MySqlClient

Public Class Docente

    Public Shared Sub CargarAreas(frm As frmAdminDocentes)
        frm.cmbArea.Items.Clear()

        Dim conexion As New Conexion()
        Dim IdGrupo As String = frm.cmbGrupo.Text.Substring(frm.cmbGrupo.Text.IndexOf(" "), frm.cmbGrupo.Text.IndexOf(" - ")).Trim()
        Dim Grado As String = frm.cmbGrupo.Text.Substring(0, frm.cmbGrupo.Text.IndexOf(" ")).Trim()

        Dim IdOrientacion As String = PersistenciaGrupos.GetOrientacion(IdGrupo, Grado)

        Dim resultadosPersistencia As Object = InformacionDB.GetAreasOrientacionByGrado(IdOrientacion, Grado)
        Dim reader As MySqlDataReader = resultadosPersistencia(0)
        While reader.Read()
            frm.cmbArea.Items.Add(reader("IdArea").ToString() & " - " & reader("NombreArea") & "")
        End While

        reader.Close()
        resultadosPersistencia(1).Close()
    End Sub

    Public Shared Sub CargarGrupos(frm As frmAdminDocentes)
        Dim resultadosPersistencia As Object = InformacionDB.GetGrupos()
        Dim reader As MySqlDataReader = resultadosPersistencia(0)

        While reader.Read()
            frm.cmbGrupo.Items.Add(reader("Grado") & " " & reader("IdGrupo") & " - " & reader("NombreTurno") & "")
        End While

        reader.Close()
        resultadosPersistencia(1).Close()
    End Sub

    Public Shared Sub CargarDocentes(frm As frmAdminDocentes)
        frm.pnlDocentes.Controls.Clear()
        frm.totalDocentes = 0
        frm.lblCantidadDocentes.Text = "(" + frm.totalDocentes.ToString() + ")"

        Dim resultadosPersistencia As Object = InformacionDB.GetDocentes()
        Dim reader As MySqlDataReader = resultadosPersistencia(0)

        While reader.Read()
            If reader("CiPersona").ToString().Equals("-1") Then
                Continue While
            End If
            frm.AgregarWidgetDocente(reader("CiPersona"), reader("CiPersona").ToString() & ControlChars.NewLine & reader("NombrePersona") & " " & reader("ApellidoPersona"))
        End While
        reader.Close()

        resultadosPersistencia(1).Close()
    End Sub

    Public Shared Sub ActualizarDB(frm As frmAdminDocentes)
        Dim Ci As String = frm.txtCI.Text
        Dim Nombre As String = frm.txtNombre.Text
        Dim Apellido As String = frm.txtApellido.Text
        Dim Grado As Integer = frm.numGrado.Value

        If frm.btnAgregarDocente.Text.StartsWith("Agregar docente") Then
            Try
                PersistenciaPersonas.Add(Ci, Nombre, Apellido)
                PersistenciaDocentes.Add(Ci, Grado)
                MessageBox.Show("Docente agregado correctamente", "Docente agregado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                CargarDocentes(frm)
                frm.InterfazEditarAsignaturasDocente(Ci)
            Catch ex As Exception
                If ex.ToString().Contains("Duplicate") Then
                    MessageBox.Show("Ya existe un docente (o usuario!) con esa CI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Try
        Else
            PersistenciaPersonas.Edit(Ci, Nombre, Apellido)
            PersistenciaDocentes.Edit(Ci, Grado)
            MessageBox.Show("Información de docente actualizada correctamente", "Docente actualizado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            CargarDocentes(frm)
            frm.InterfazPrevisualizarDocente(frm.txtCI.Text)
        End If
    End Sub

    Public Shared Sub CargarInfo(Ci As String, frm As frmAdminDocentes)
        Dim resultadosPersistencia As Object = PersistenciaDocentes.GetInfo(Ci)
        Dim reader As MySqlDataReader = resultadosPersistencia(0)

        While reader.Read()
            frm.txtCI.Text = reader("CiPersona")
            frm.txtNombre.Text = reader("NombrePersona")
            frm.txtApellido.Text = reader("ApellidoPersona")
            frm.numGrado.Value = reader("GradoProfesor")
        End While
        reader.Close()

        resultadosPersistencia(1).Close()
    End Sub

    Public Shared Sub EliminarDocente(Ci As String, Nombre As String, frm As frmAdminDocentes)
        Dim resultadosPersistenciaBackup As Object = PersistenciaDocentes.GetInfo(Ci)
        Dim readerBackup As MySqlDataReader = resultadosPersistenciaBackup(0)

        Try
            PersistenciaDocentes.Del(Ci)
            PersistenciaPersonas.Del(Ci)
            CargarDocentes(frm)
            frm.InterfazNuevoDocente()
            MessageBox.Show("Docente '" + Nombre + "' eliminado.", "Docente eliminado.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("El docente no se puede eliminar, ya que tiene asignaturas asignadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Try
                While readerBackup.Read()
                    PersistenciaDocentes.Add(readerBackup("CiPersona"), readerBackup("GradoProfesor"))
                End While
            Catch exx As Exception
                MessageBox.Show(exx.ToString(), "Error!", MessageBoxButtons.OK)
            End Try
        End Try

        readerBackup.Close()
        resultadosPersistenciaBackup(1).Close()
    End Sub

    ' **** Asignaturas **** 

    Public Shared Sub EliminarAsignatura(frm As frmAdminDocentes)
        Dim NroGrupo As String = PersistenciaGrupos.GetNroGrupo(frm.lstAsignaturas.SelectedItems.Item(0).SubItems(1).Text)
        Dim IdAsignatura As String = frm.lstAsignaturas.SelectedItems.Item(0).SubItems(0).Text
        Dim CiPersona As String = frm.txtCI.Text

        Try
            PersistenciaHorarios.Del(IdAsignatura, NroGrupo, CiPersona)
            PersistenciaAsignaturas.DesAsignar(NroGrupo, IdAsignatura, CiPersona)
            CargarAsignaturas(CiPersona, frm)
            frm.btnEliminarAsignatura.Visible = False
            MessageBox.Show("Asignatura eliminada.", "Asignatura eliminada.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Shared Sub CargarAsignaturas(Ci As String, frm As frmAdminDocentes)
        frm.lstAsignaturas.Items.Clear()
        Dim resultadosPersistencia As Object = PersistenciaAsignaturas.GetAsignadasDocente(Ci)

        Dim reader As MySqlDataReader = resultadosPersistencia(0)
        While reader.Read()
            Dim item As New ListViewItem
            item = frm.lstAsignaturas.Items.Add(reader("IdAsignatura").ToString())
            item.SubItems.Add(reader("Grado") & " " & reader("IdGrupo"))
            item.SubItems.Add(reader("FechaToma").ToString())
        End While
        reader.Close()

        resultadosPersistencia(1).Close()
    End Sub

    Public Shared Sub ActualizarDB_Asignatura(frm As frmAdminDocentes)
        Dim NroGrupo As String = PersistenciaGrupos.GetNroGrupo(frm.cmbGrupo.Text.Substring(0, frm.cmbGrupo.Text.IndexOf(" - ")))
        Dim IdAsignatura As String = frm.cmbAsignatura.Text.Substring(0, frm.cmbAsignatura.Text.IndexOf(" - ")).Trim()
        Dim FechaAhora As DateTime = Now
        Dim FechaToma As String = FechaAhora.ToString("yyyy-MM-dd")
        Dim GradoAreaProfesor As Integer = frm.numGradoArea.Value
        Dim Ci As String = frm.txtCI.Text

        If PersistenciaGrupos.GetAsignaturaTomada(IdAsignatura, NroGrupo) Then
            MessageBox.Show("Esa asignatura ya ha sido asignada al grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            PersistenciaAsignaturas.Asignar(IdAsignatura, NroGrupo, FechaToma, GradoAreaProfesor, Ci)

            Dim resultadosPersistenciaConflicto As Object = PersistenciaDocentes.GetConflictosAsignacion(Ci, IdAsignatura, NroGrupo)
            If resultadosPersistenciaConflicto(0) Then
                MessageBox.Show("El docente ya tiene un grupo asignado (" & resultadosPersistenciaConflicto(1) & ") en el horario de ésta asignatura." & vbCrLf & "Se recomienda acomodar los horarios en la vista de Horarios.", "Conflictos detectados", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            PersistenciaHorarios.Edit(Ci, IdAsignatura, NroGrupo)
            CargarAsignaturas(Ci, frm)
            frm.lblNuevoDocente.Text = "Editar asignaturas del docente"
            frm.LimpiarDatosAsignatura()
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK)
        End Try

    End Sub

    Public Shared Sub CargarAsignaturasGrupo(frm As frmAdminDocentes)
        frm.cmbAsignatura.Items.Clear()

        Dim IdGrupo As String = frm.cmbGrupo.Text.Substring(frm.cmbGrupo.Text.IndexOf(" "), frm.cmbGrupo.Text.IndexOf(" - ")).Trim()
        Dim Grado As String = frm.cmbGrupo.Text.Substring(0, frm.cmbGrupo.Text.IndexOf(" ")).Trim()
        Dim IdArea As String = frm.cmbArea.Text.Substring(0, frm.cmbArea.Text.IndexOf(" - "))

        Dim resultadosPersistencia As Object = InformacionDB.GetAsignaturasForGrupo(IdGrupo, Grado, IdArea)
        Dim reader As MySqlDataReader = resultadosPersistencia(0)

        While reader.Read()
            If reader("IdAsignatura").ToString().Equals("-1") Then
                Continue While
            End If

            frm.cmbAsignatura.Items.Add(reader("IdAsignatura").ToString() & " - " & reader("NombreAsignatura"))
        End While

        reader.Close()
        resultadosPersistencia(1).Close()
    End Sub

    Public Shared Sub CrearGrillaHorariosDocente(frm As frmAdminDocentes)
        Dim Dias As Object = {"Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"}
        Dim frmHorariosExterno As New frmHorariosExternos(Nothing, frm.ParentForm, frm.txtNombre.Text & " " & frm.txtApellido.Text)

        For Turno As Integer = 1 To 3

            Dim Horarios(0) As String

            If Turno = 3 Then
                ReDim Horarios(5)
            Else
                ReDim Horarios(6)
            End If

            Dim Row_Primera(8) As String
            Dim Row_Segunda(8) As String
            Dim Row_Tercera(8) As String
            Dim Row_Cuarta(8) As String
            Dim Row_Quinta(8) As String
            Dim Row_Sexta(8) As String
            Dim Row_Extra(8) As String

            Dim Rows As Object = {Row_Primera, Row_Segunda, Row_Tercera, Row_Cuarta, Row_Quinta, Row_Sexta, Row_Extra}

            Dim resultadosPersistenciaHorariosTurno As Object = PersistenciaHorarios.GetHorariosTurno(Turno)
            Dim readerHorariosTurno As MySqlDataReader = resultadosPersistenciaHorariosTurno(0)
            Dim pos As Integer = 0
            While readerHorariosTurno.Read()
                Horarios(pos) = readerHorariosTurno("HoraInicio").ToString()
                Rows(pos)(0) = readerHorariosTurno("HoraInicio").ToString()
                Rows(pos)(0) = Rows(pos)(0).Substring(0, Rows(pos)(0).Length - 3)
                pos += 1
            End While
            readerHorariosTurno.Close()
            resultadosPersistenciaHorariosTurno(1).Close()

            Dim resultadosPersistencia As Object = PersistenciaHorarios.GetForProfesor(frm.txtCI.Text, Turno)
            Dim reader As MySqlDataReader = resultadosPersistencia(0)

            While reader.Read()
                Dim PosHora As Integer = Array.IndexOf(Horarios, reader("HoraInicio").ToString())
                Dim PosDia As Integer = Array.IndexOf(Dias, reader("Dia"))
                Rows(PosHora)(PosDia + 1) = reader("Materia") & vbCrLf & reader("NombreProfesor")
            End While

            reader.Close()
            resultadosPersistencia(1).Close()

            Dim primeraVacia As Boolean = True
            Dim segundaVacia As Boolean = True
            Dim terceraVacia As Boolean = True
            Dim cuartaVacia As Boolean = True
            Dim quintaVacia As Boolean = True
            Dim sextaVacia As Boolean = True
            Dim extraVacia As Boolean = True

            pos = 0
            For Each Horario In Row_Primera
                If (Not IsNothing(Horario) And Not String.IsNullOrEmpty(Horario)) And Not pos = 0 Then
                    primeraVacia = False
                End If
                pos += 1
            Next

            pos = 0
            For Each Horario In Row_Segunda
                If (Not IsNothing(Horario) And Not String.IsNullOrEmpty(Horario)) And Not pos = 0 Then
                    segundaVacia = False
                End If
                pos += 1
            Next

            pos = 0
            For Each Horario In Row_Tercera
                If (Not IsNothing(Horario) And Not String.IsNullOrEmpty(Horario)) And Not pos = 0 Then
                    terceraVacia = False
                End If
                pos += 1
            Next

            pos = 0
            For Each Horario In Row_Cuarta
                If (Not IsNothing(Horario) And Not String.IsNullOrEmpty(Horario)) And Not pos = 0 Then
                    cuartaVacia = False
                End If
                pos += 1
            Next

            pos = 0
            For Each Horario In Row_Quinta
                If (Not IsNothing(Horario) And Not String.IsNullOrEmpty(Horario)) And Not pos = 0 Then
                    quintaVacia = False
                End If
                pos += 1
            Next

            pos = 0
            For Each Horario In Row_Sexta
                If (Not IsNothing(Horario) And Not String.IsNullOrEmpty(Horario)) And Not pos = 0 Then
                    sextaVacia = False
                End If
                pos += 1
            Next

            pos = 0
            For Each Horario In Row_Extra
                If (Not IsNothing(Horario) And Not String.IsNullOrEmpty(Horario)) And Not pos = 0 Then
                    extraVacia = False
                End If
                pos += 1
            Next

            If Not primeraVacia Then
                frmHorariosExterno.Grilla.dgvMaterias.Rows.Add(Row_Primera)
            End If
            If Not segundaVacia Then
                frmHorariosExterno.Grilla.dgvMaterias.Rows.Add(Row_Segunda)
            End If
            If Not terceraVacia Then
                frmHorariosExterno.Grilla.dgvMaterias.Rows.Add(Row_Tercera)
            End If
            If Not cuartaVacia Then
                frmHorariosExterno.Grilla.dgvMaterias.Rows.Add(Row_Cuarta)
            End If
            If Not quintaVacia Then
                frmHorariosExterno.Grilla.dgvMaterias.Rows.Add(Row_Quinta)
            End If
            If Not sextaVacia Then
                frmHorariosExterno.Grilla.dgvMaterias.Rows.Add(Row_Sexta)
            End If
            If Not extraVacia Then
                frmHorariosExterno.Grilla.dgvMaterias.Rows.Add(Row_Extra)
            End If
        Next
        frmHorariosExterno.ShowDialog(frm)
    End Sub
End Class
