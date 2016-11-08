Imports MySql.Data.MySqlClient

Public Class Salon

    Public Shared Sub CargarSalones(ByVal frm As frmAdminSalones)
        ' Carga los salones y los pone en la lista
        frm.pnlSalones.Controls.Clear()
        frm.totalSalones = 0
        frm.lblCantidadSalones.Text = "(" + frm.totalSalones.ToString() + ")"

        Dim primerSalonFijado As Boolean = False

        Dim resultadosPersistencia As Object = InformacionDB.GetSalones()
        Dim reader As MySqlDataReader = resultadosPersistencia(0)

        While reader.Read()
            frm.agregarWidgetSalon(reader("IdSalon"))

            If Not primerSalonFijado Then
                frm.primerSalon = reader("IdSalon")
                primerSalonFijado = True
            End If
        End While

        reader.Close()
        resultadosPersistencia(1).Close()
    End Sub

    Public Shared Sub ActualizarDB(ByVal frm As frmAdminSalones)
        ' Agrega o actualiza los datos del salón en la DB
        If frm.btnAgregar.Text.Equals("Agregar salón") Then
            Try
                PersistenciaSalones.Add(frm.txtIdSalon.Text, frm.txtComentarios.Text, frm.cmbPlanta.Text)
                MessageBox.Show("Salón agregado correctamente", "Salón agregado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

                frm.CargarSalones()
                frm.InterfazPrevisualizarSalon(frm.txtIdSalon.Text)
            Catch ex As Exception
                MessageBox.Show("Ya existe un salón con ese ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            PersistenciaSalones.Edit(frm.txtIdSalon.Text, frm.txtComentarios.Text, frm.cmbPlanta.Text)
            MessageBox.Show("Información de salón actualizada correctamente", "Salón actualizado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

            frm.CargarSalones()
            frm.InterfazPrevisualizarSalon(frm.txtIdSalon.Text)
        End If
    End Sub

    Public Shared Sub CargarSalon(ByVal IdSalon As String, frm As frmAdminSalones)
        '  Carga los datos de un salón
        Dim resultadoPersistencia As Object = PersistenciaSalones.GetInfo(IdSalon)
        Dim reader As MySqlDataReader = resultadoPersistencia(0)

        While reader.Read()
            frm.txtIdSalon.Text = reader("IdSalon")
            frm.txtComentarios.Text = reader("ComentariosSalon").ToString()
            frm.cmbPlanta.SelectedIndex = frm.cmbPlanta.FindStringExact(reader("PlantaSalon"))
        End While

        reader.Close()
        resultadoPersistencia(1).Close()

        ' Carga los horarios del salón.

        For Turno As Integer = 1 To 3
            resultadoPersistencia = PersistenciaSalones.GetAsignado(IdSalon, Turno)
            reader = resultadoPersistencia(0)
            While reader.Read()
                If Turno = 1 Then
                    frm.lblSalonMatutino.Text = reader("Grupo")
                ElseIf Turno = 2 Then
                    frm.lblSalonVespertino.Text = reader("Grupo")
                ElseIf Turno = 3 Then
                    frm.lblSalonNocturno.Text = reader("Grupo")
                End If
            End While
            reader.Close()
            resultadoPersistencia(1).Close()
        Next
    End Sub

    Public Shared Sub EliminarSalon(ByVal IdSalon As String, frm As frmAdminSalones)
        Try
            PersistenciaSalones.Del(IdSalon)
            frm.cargarSalones()
            frm.IntefazNuevoSalon()
            MessageBox.Show("Salón '" + (IdSalon) + "' eliminado.", "Salón eliminado.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("El salón no se puede eliminar, ya que está asignado a un grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
