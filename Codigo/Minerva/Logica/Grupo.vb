Imports MySql.Data.MySqlClient

Public Class Grupo
    Public Shared Sub CargarGrupos(frm As frmAdminGrupos)
        ' Carga los grupos a la lista de grupos
        frm.pnlGrupos.Controls.Clear()
        frm.totalGrupos = 0
        frm.lblCantidadGrupos.Text = "(" + frm.totalGrupos.ToString() + ")"

        Dim primerGrupoFijado As Boolean = False
        Dim resultadosPersistencia As Object = InformacionDB.GetGrupos()
        Dim reader As MySqlDataReader = resultadosPersistencia(0)

        While reader.Read()
            If frm.tipoUsuario.Equals("Adscripto") And reader("CiPersona").Equals(frm.ciusuario) Then
                frm.AgregarWidgetGrupo(reader("NroGrupo"), reader("Grado").ToString() & " " & reader("IdGrupo") & ControlChars.NewLine & " (" & reader("NombreTurno") & ")", reader("NombreTurno"), reader("CiPersona"))

                If Not primerGrupoFijado Then
                    frm.primerGrupo = reader("NroGrupo").ToString()
                    primerGrupoFijado = True
                End If
            ElseIf Not frm.tipoUsuario.Equals("Adscripto") Then
                frm.AgregarWidgetGrupo(reader("NroGrupo"), reader("Grado").ToString() & " " & reader("IdGrupo") & ControlChars.NewLine & " (" & reader("NombreTurno") & ")", reader("NombreTurno"), reader("CiPersona"))
            End If
        End While
        reader.Close()

        resultadosPersistencia(1).Close()
    End Sub

    Public Shared Sub CargarSalones(frm As frmAdminGrupos)
        frm.cmbSalon.Items.Clear()
        frm.cmbSalon.Items.Add("Sin asignar")
        frm.cmbSalon.SelectedIndex = 0

        Dim resultadosPersistencia As Object = InformacionDB.GetSalones()
        Dim reader As MySqlDataReader = resultadosPersistencia(0)

        While reader.Read()
            frm.cmbSalon.Items.Add(reader("IdSalon").ToString())
        End While
        reader.Close()

        resultadosPersistencia(1).Close()
    End Sub

    Public Shared Sub CargarGrados(frm As frmAdminGrupos)
        frm.cboGrado.Items.Clear()

        Try
            Dim resultadosPersistencia As Object = InformacionDB.GetGrados(frm.cmbOrientacion.Text.Substring(0, frm.cmbOrientacion.Text.IndexOf(" (")).Trim())
            Dim reader As MySqlDataReader = resultadosPersistencia(0)

            While reader.Read()
                frm.cboGrado.Items.Add(reader("Grado"))
            End While

            reader.Close()
            resultadosPersistencia(1).Close()
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub CargarOrientaciones(frm As frmAdminGrupos)
        frm.cmbOrientacion.Items.Clear()
        Dim resultadosPersistencia = InformacionDB.GetOrientaciones(frm.cmbCurso.Text.Substring(0, frm.cmbCurso.Text.IndexOf(" (")).Trim())
        Dim reader As MySqlDataReader = resultadosPersistencia(0)

        While reader.Read()
            frm.cmbOrientacion.Items.Add(reader("IdOrientacion").ToString() & " (" & reader("NombreOrientacion").ToString() & ")")
        End While
        reader.Close()

        resultadosPersistencia(1).Close()
    End Sub

    Public Shared Sub CargarCursos(frm As frmAdminGrupos)
        frm.cmbCurso.Items.Clear()

        Dim resultadosPersistencia = InformacionDB.GetCursos()
        Dim reader As MySqlDataReader = resultadosPersistencia(0)

        While reader.Read()
            frm.cmbCurso.Items.Add(reader("IdCurso").ToString() & " (" & reader("NombreCurso") & ")")
        End While
        reader.Close()

        resultadosPersistencia(1).Close()
    End Sub

    Public Shared Sub CargarTurnos(frm As frmAdminGrupos)
        frm.cmbTurno.Items.Clear()

        Dim resultadosPersistencia = InformacionDB.GetTurnos()
        Dim reader As MySqlDataReader = resultadosPersistencia(0)

        While reader.Read()
            frm.cmbTurno.Items.Add(reader("NombreTurno"))
        End While
        reader.Close()

        resultadosPersistencia(1).Close()
    End Sub

    Public Shared Sub CargarGrupo(nroGrupo As String, frm As frmAdminGrupos)
        Dim resultadosPersistencia As Object = PersistenciaGrupos.GetInfo(nroGrupo)
        Dim reader As MySqlDataReader = resultadosPersistencia(0)

        While reader.Read()
            frm.txtIdGrupo.Text = reader("IdGrupo")
            frm.cmbCurso.SelectedIndex = frm.cmbCurso.FindStringExact(reader("IDCurso").ToString() & " (" & reader("NombreCurso") & ")")
            frm.chkDiscapacitado.Checked = reader("Discapacitado")
            frm.cmbTurno.SelectedIndex = reader("IDTurno") - 1

            frm.cmbOrientacion.Items.Clear()
            frm.cmbOrientacion.Items.Add(reader("IdOrientacion").ToString() & " (" & reader("NombreOrientacion").ToString() & ")")
            frm.cmbOrientacion.SelectedIndex = 0

            frm.cboGrado.Items.Clear()
            frm.cboGrado.Items.Add(reader("Grado"))
            frm.cboGrado.SelectedIndex = 0

            frm.cmbAdscripto.SelectedIndex = frm.cmbAdscripto.FindStringExact(reader("NombreAdscripto"))
            If reader("NombreAdscripto").Equals("-1 - Sin definir") Then
                frm.cmbAdscripto.SelectedIndex = 0
            End If

            CargarSalones(frm)
            Dim salon As String = reader("IdSalon")
            If salon.Equals("-1") Then
                salon = "Sin asignar"
            End If
            frm.cmbSalon.SelectedIndex = frm.cmbSalon.FindStringExact(salon)

            frm.cmbOrientacion.Enabled = False
            frm.cboGrado.Enabled = False
            frm.cmbAdscripto.Enabled = False
        End While

        reader.Close()
        resultadosPersistencia(1).Close()
    End Sub

    Public Shared Sub CargarAdscriptos(frm As frmAdminGrupos)
        frm.cmbAdscripto.Items.Clear()

        Dim resultadosPersistencia As Object = InformacionDB.GetAdscriptos()
        Dim reader As MySqlDataReader = resultadosPersistencia(0)

        While reader.Read()
            If reader("CiPersona").Equals("-1") Then
                frm.cmbAdscripto.Items.Add("Sin definir")
                Continue While
            End If
            frm.cmbAdscripto.Items.Add(reader("CiPersona") & " - " & reader("Adscripto"))
        End While

        frm.cmbAdscripto.SelectedIndex = 0

        reader.Close()
        resultadosPersistencia(1).Close()
    End Sub

    Public Shared Sub CheckSalonOcupado(frm As frmAdminGrupos)

        Dim salon As String
        salon = frm.cmbSalon.Text
        If salon.Equals("Sin asignar") Then
            salon = "-1"
        End If

        Dim resultadosPersistencia As Object = PersistenciaSalones.GetOcupadoBy(salon, frm.cmbTurno.SelectedIndex + 1)
        Dim reader As MySqlDataReader = resultadosPersistencia(0)

        While reader.Read()
            If reader("IdGrupo").Equals(frm.txtIdGrupo.Text) And reader("Grado").Equals(Integer.Parse(frm.cboGrado.Text)) Then
                Continue While
            End If

            reader.Close()
            resultadosPersistencia(1).Close()

            Throw New System.Exception("Duplicate")
        End While

        reader.Close()
        resultadosPersistencia(1).Close()
    End Sub

    Public Shared Sub ActualizarDB(frm As frmAdminGrupos)
        ' Agrega un salón a la base de datos
        Dim IdGrupo As String = frm.txtIdGrupo.Text
        Dim Discapacitado As Boolean = frm.chkDiscapacitado.Checked
        Dim IdSalon As String = frm.cmbSalon.Text
        Dim IdTurno As String = frm.cmbTurno.SelectedIndex + 1
        Dim Grado As String = frm.cboGrado.Text
        Dim IdOrientacion As String = frm.cmbOrientacion.Text.Substring(0, frm.cmbOrientacion.Text.IndexOf(" (")).Trim()
        Dim CiAdscripto As String

        If IdSalon.Equals("Sin asignar") Then
            IdSalon = "-1"
        End If

        If Not frm.cmbAdscripto.Text.Equals("Sin definir") Then
            CiAdscripto = frm.cmbAdscripto.Text.Substring(0, frm.cmbAdscripto.Text.IndexOf(" - ")).Trim()
        Else
            CiAdscripto = "-1"
        End If

        Try
            CheckSalonOcupado(frm)
        Catch ex As Exception
            MessageBox.Show("El salón escogido ya está en uso.", "Salón en uso", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End Try

        If frm.btnAgregar.Text.Equals("Agregar grupo") Then
            Try
                If PersistenciaGrupos.GetExiste(frm.cboGrado.Text & " " & frm.txtIdGrupo.Text) Then
                    Throw New System.Exception("Duplicate")
                End If

                PersistenciaGrupos.Add(IdGrupo, Discapacitado, IdSalon, IdTurno, Grado, IdOrientacion, CiAdscripto)
            Catch ex As Exception
                If ex.ToString().Contains("Duplicate") Then
                    MessageBox.Show("Ya existe un grupo con ese grado e id.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                Return
            End Try

            If frm.chkDistribuir.Checked Then
                frm.frmAdministrar.habilitarBotones(False)
                frm.ParentForm.Enabled = False

                Dim ventanaEspere As New frmDialogoEspere()
                ventanaEspere.Show()
                ventanaEspere.lblComprobando.Text = "Repartiendo horarios"

                Dim logica As New Logica()
                logica.repartirHorarios(frm)

                frm.ParentForm.Enabled = True
                frm.frmAdministrar.habilitarBotones(True)
                ventanaEspere.Dispose()
            End If

            CargarGrupos(frm)
            MessageBox.Show("Grupo agregado correctamente", "Grupo agregado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else
            PersistenciaGrupos.Edit(IdGrupo, Discapacitado, IdSalon, IdTurno, Grado, CiAdscripto)
            MessageBox.Show("Datos del grupos actualizados correctamente", "Grupo actualizado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If

        frm.InterfazNuevoGrupo()
        frm.btnNuevoGrupo.Text = "Agregar grupo"
        frm.frmMain.recargarGrupo()

    End Sub

    Public Shared Sub EliminarGrupo(nroGrupo As String, nombreGrupo As String, frm As frmAdminGrupos)
        Dim backupMaterias As Object = PersistenciaHorarios.GetForGrupo(nroGrupo)

        Try
            PersistenciaHorarios.DelGrupoEntero(nroGrupo)
            PersistenciaGrupos.Del(nroGrupo)
            CargarGrupos(frm)
            frm.InterfazNuevoGrupo()

            MessageBox.Show("Grupo '" + nombreGrupo + "' eliminado.", "Grupo eliminado.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Dim reader As MySqlDataReader = backupMaterias(0)

            Try
                While reader.Read()
                    PersistenciaHorarios.Add(reader("IdAsignatura"), reader("NroGrupo"), reader("HoraInicio"), reader("HoraFin"), reader("Dia"), reader("IdTurno"), reader("CiPersona"))
                End While
            Catch exx As Exception
            End Try

            MessageBox.Show("No se pudo eliminar el grupo, el mismo tiene docentes (ver admin. de docentes) asignados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        backupMaterias(0).Close()
        backupMaterias(1).Close()
    End Sub
End Class
