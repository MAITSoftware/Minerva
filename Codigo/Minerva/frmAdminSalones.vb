Imports MySql.Data.MySqlClient
Imports System.Data

Public Class frmAdminSalones
    ' Clase principal de administración de salones

    Dim totalSalones As Integer = 0
    Dim salonPreview As Object = New Button()
    Private DB As DB

    Private Sub frmAdminSalones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarSalones()
        cargarGrupos()

        controlesHabilitados(True)
    End Sub

    Private Sub cargarSalones()
        pnlSalones.Controls.Clear()
        totalSalones = 0
        lblCantidadSalones.Text = "(" + totalSalones.ToString() + ")"

        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Salon`;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                If reader("IDSalon").Equals(-1) Then
                    Continue While
                End If
                agregarSalon(reader("IDSalon"))
            End While
            reader.Close()
            conexion.Close()
        End Using

    End Sub

    Private Sub agregarSalon(ByVal idSalon As String)
        ' Basicamente copio la plantilla a un nuevo panel
        Dim pnlTemporal As New Panel
        Dim btnSalon As New Button
        Dim btnEditar, btnEliminar As New Button

        pnlTemporal.Size = pnlSalonPlantilla.Size
        btnSalon.Size = btnSalonPlantilla.Size
        btnSalon.FlatStyle = btnSalonPlantilla.FlatStyle
        btnSalon.ForeColor = btnSalonPlantilla.ForeColor
        btnSalon.Text = idSalon
        btnSalon.BackColor = btnSalonPlantilla.BackColor
        btnSalon.Location = btnSalonPlantilla.Location
        btnSalon.Cursor = btnSalonPlantilla.Cursor
        btnSalon.Font = btnSalonPlantilla.Font

        btnSalon.Tag = idSalon
        AddHandler btnSalon.Click, AddressOf verSalon

        btnEditar.Size = btnEditarPlantilla.Size
        btnEditar.FlatStyle = btnEditarPlantilla.FlatStyle
        btnEditar.ForeColor = btnEditarPlantilla.ForeColor
        btnEditar.Text = btnEditarPlantilla.Text
        btnEditar.BackColor = btnEditarPlantilla.BackColor
        btnEditar.Location = btnEditarPlantilla.Location
        btnEditar.Cursor = btnEditarPlantilla.Cursor

        btnEditar.Tag = idSalon
        AddHandler btnEditar.Click, AddressOf editarSalon

        btnEliminar.Size = btnEliminarPlantilla.Size
        btnEliminar.FlatStyle = btnEliminarPlantilla.FlatStyle
        btnEliminar.ForeColor = btnEliminarPlantilla.ForeColor
        btnEliminar.Text = btnEliminarPlantilla.Text
        btnEliminar.BackColor = btnEliminarPlantilla.BackColor
        btnEliminar.Location = btnEliminarPlantilla.Location
        btnEliminar.Cursor = btnEliminarPlantilla.Cursor

        btnEliminar.Tag = idSalon
        AddHandler btnEliminar.Click, AddressOf eliminarSalon

        pnlTemporal.Controls.Add(btnEditar)
        pnlTemporal.Controls.Add(btnEliminar)
        pnlTemporal.Controls.Add(btnSalon)

        pnlSalones.Controls.Add(pnlTemporal)

        totalSalones += 1
        lblCantidadSalones.Text = "(" + totalSalones.ToString() + ")"
    End Sub

    Private Sub editarSalon(ByVal sender As System.Object, ByVal e As System.EventArgs)
        salonPreview.Enabled = True
        salonPreview = sender.Parent
        salonPreview.Enabled = False
        lblNuevoSalon.Text = "Editar salón"
        btnCancelarEdicion.Visible = True
        btnAgregar.Visible = True
        btnNuevoSalon.Visible = False
        btnAgregar.Text = "Guardar cambios"

        controlesHabilitados(True)
        cargarDatos(sender.Tag)
        txtIDSalon.Enabled = False

    End Sub

    Private Sub verSalon(ByVal sender As System.Object, ByVal e As System.EventArgs)
        previsualizarSalon(sender.Tag)
    End Sub

    Private Sub previsualizarSalon(ByVal salon As String)
        btnNuevoSalon.Visible = True
        btnAgregar.Visible = False
        btnCancelarEdicion.Visible = False

        salonPreview.Enabled = True
        salonPreview = Nothing
        For Each pnl As Panel In pnlSalones.Controls
            For Each x As Button In pnl.Controls
                If x.Text.Equals(salon) Then
                    If IsNothing(salonPreview) Then
                        salonPreview = x
                    End If
                End If
            Next
        Next

        salonPreview.Enabled = False

        lblNuevoSalon.Text = "Previsualizar salón"

        controlesHabilitados(False)
        cargarDatos(salon)
    End Sub

    Private Sub eliminarSalon(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim result As Integer = MessageBox.Show("¿Está seguro de que desea eliminar el salón '" + sender.Tag + "'?", "Eliminar salón", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If

        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM `Salon` WHERE IDSalon=@IDSalon;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IDSalon", sender.Tag)
            End With
            totalSalones -= 1
            Try
                cmd.ExecuteNonQuery()
                conexion.Close() 'Cierra la conexión
                cargarSalones()
                btnNuevoSalon_Click(Nothing, Nothing)
                MessageBox.Show("Salón '" + sender.tag + "' eliminado.", "Salón eliminado.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("El salón no se puede eliminar, ya que está asignado a un grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub cargarDatos(ByVal idSalon As String)
        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Salon` where IDSalon=@IDSalon;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IDSalon", idSalon)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                txtIDSalon.Text = reader("IDSalon")
                txtComentarios.Text = reader("Comentarios").ToString()
                cmbPlanta.SelectedIndex = cmbPlanta.FindStringExact(reader("PlantaSalon"))
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
                    .CommandText = "SELECT Grupo.IDGrupo, Grupo.IDTrayecto FROM `Salon`, `Grupo` WHERE Salon.IDSalon=Grupo.IDSalon and Grupo.IDTurno=@IDTurno and Salon.IDSalon=@IDSalon;"
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@IDSalon", idSalon)
                    .Parameters.AddWithValue("@IDTurno", Turno)
                End With

                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    ' Too lazy to fix this hehe
                    If Turno = 1 Then
                        cmbTurno1.SelectedIndex = cmbTurno1.FindStringExact(reader("IDTrayecto").ToString() & " " & reader("IDGrupo"))
                    ElseIf Turno = 2 Then
                        cmbTurno2.SelectedIndex = cmbTurno2.FindStringExact(reader("IDTrayecto").ToString() & " " & reader("IDGrupo"))
                    ElseIf Turno = 3 Then
                        cmbTurno3.SelectedIndex = cmbTurno3.FindStringExact(reader("IDTrayecto").ToString() & " " & reader("IDGrupo"))
                    ElseIf Turno = 4 Then
                        cmbTurno4.SelectedIndex = cmbTurno4.FindStringExact(reader("IDTrayecto").ToString() & " " & reader("IDGrupo"))
                    ElseIf Turno = 5 Then
                        cmbTurno5.SelectedIndex = cmbTurno5.FindStringExact(reader("IDTrayecto").ToString() & " " & reader("IDGrupo"))
                    End If
                End While
                reader.Close()
            End Using
        Next
        conexionSalones.Close()
    End Sub

    Private Sub controlesHabilitados(ByVal habilitado As Boolean)
        txtIDSalon.Enabled = habilitado
        txtIDSalon.Text = ""
        cmbPlanta.Enabled = habilitado
        cmbPlanta.SelectedIndex = -1
        cmbTurno1.Enabled = habilitado
        cmbTurno1.SelectedIndex = 0
        cmbTurno2.Enabled = habilitado
        cmbTurno2.SelectedIndex = 0
        cmbTurno3.Enabled = habilitado
        cmbTurno3.SelectedIndex = 0
        cmbTurno4.Enabled = habilitado
        cmbTurno4.SelectedIndex = 0
        cmbTurno5.Enabled = habilitado
        cmbTurno5.SelectedIndex = 0
        txtComentarios.Enabled = habilitado
        txtComentarios.Text = ""
    End Sub

    Private Sub btnNuevoSalon_Click(sender As Object, e As EventArgs) Handles btnNuevoSalon.Click, btnCancelarEdicion.Click
        controlesHabilitados(True)
        lblNuevoSalon.Text = "Nuevo salón"
        btnNuevoSalon.Visible = False
        btnAgregar.Visible = True
        btnAgregar.Text = "Agregar salón"
        btnCancelarEdicion.Visible = False
        salonPreview.Enabled = True
        salonPreview = New Button()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        checkDatos()
    End Sub

    Private Sub checkDatos()
        If String.IsNullOrWhiteSpace(txtIDSalon.Text) Then
            MessageBox.Show("Debe ingresar un ID de salón.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        If String.IsNullOrWhiteSpace(cmbPlanta.Text) Then
            MessageBox.Show("Debe ingresar la planta del salón.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        actualizarDB()
    End Sub

    Private Sub actualizarDB()
        Dim conexion As New DB()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text

                If btnAgregar.Text.Equals("Agregar salón") Then
                    .CommandText = "INSERT INTO `Salon` VALUES  (@IDSalon, @PlantaSalon, @Comentarios);"
                Else
                    .CommandText = "UPDATE `Salon` SET PlantaSalon=@PlantaSalon, Comentarios=@Comentarios WHERE IDSalon=@IDSalon;"
                End If

                .Parameters.AddWithValue("@IDSalon", txtIDSalon.Text)
                .Parameters.AddWithValue("@PlantaSalon", cmbPlanta.Text)
                .Parameters.AddWithValue("@Comentarios", txtComentarios.Text)
            End With

            Try
                cmd.ExecuteNonQuery()
                conexion.Close()
                guardarSalones()
                cargarSalones()
                If btnAgregar.Text.Equals("Agregar salón") Then
                    MessageBox.Show("Salón agregado correctamente", "Salón agregado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Else
                    MessageBox.Show("Información de salón actualizada correctamente", "Salón actualizado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
                previsualizarSalon(txtIDSalon.Text)
            Catch ex As Exception
                If ex.ToString().Contains("Duplicate") Then
                    MessageBox.Show("Ya existe un salón con ese ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Try
        End Using
    End Sub

    Private Sub cargarGrupos()
        Dim conexion As New DB()
        ' Carga los grupos al combo
        For Turno As Integer = 0 To 5
            Using cmd As New MySqlCommand()
                With cmd
                    .Connection = conexion.Conn
                    .CommandText = "SELECT * from `Grupo` WHERE `IDTurno`=@IDTurno"
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@IDTurno", Turno.ToString())
                End With

                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    ' Too lazy to fix this hehe
                    If Turno = 1 Then
                        cmbTurno1.Items.Add(reader("IDTrayecto").ToString() & " " & reader("IDGrupo"))
                    ElseIf Turno = 2 Then
                        cmbTurno2.Items.Add(reader("IDTrayecto").ToString() & " " & reader("IDGrupo"))
                    ElseIf Turno = 3 Then
                        cmbTurno3.Items.Add(reader("IDTrayecto").ToString() & " " & reader("IDGrupo"))
                    ElseIf Turno = 4 Then
                        cmbTurno4.Items.Add(reader("IDTrayecto").ToString() & " " & reader("IDGrupo"))
                    ElseIf Turno = 5 Then
                        cmbTurno5.Items.Add(reader("IDTrayecto").ToString() & " " & reader("IDGrupo"))
                    End If
                End While
                reader.Close()
            End Using
        Next
        conexion.Close()
    End Sub

    Private Sub guardarSalones()
        ' Guardo los horarios del salón.
        Dim conexionSalones As New DB()
        Dim txtSalon As String = txtIDSalon.Text
        For Turno As Integer = 1 To 5
            Using cmd As New MySqlCommand()
                With cmd
                    .Connection = conexionSalones.Conn
                    .CommandText = "UPDATE `Grupo` SET IDSalon=@IDSalon WHERE IDGrupo=@IDGrupo and IDTurno=@IDTurno and IDTrayecto=@IDTrayecto;"
                    .CommandType = CommandType.Text
                    Console.WriteLine(Turno)
                    If Turno = 1 Then
                        If cmbTurno1.Text.Equals("Sin asignar") Then
                            ' txtSalon = "-1"
                            Continue For
                        End If
                        .Parameters.AddWithValue("@IDGrupo", cmbTurno1.Text.Substring(cmbTurno1.Text.IndexOf(" "), cmbTurno1.Text.Length - 1).Trim())
                        .Parameters.AddWithValue("@IDTrayecto", Integer.Parse(cmbTurno1.Text.Substring(0, cmbTurno1.Text.IndexOf(" ")).Trim()))
                    ElseIf Turno = 2 Then
                        If cmbTurno2.Text.Equals("Sin asignar") Then
                            ' txtSalon = "-1"
                            Continue For
                        End If
                        .Parameters.AddWithValue("@IDGrupo", cmbTurno2.Text.Substring(cmbTurno2.Text.IndexOf(" "), cmbTurno2.Text.Length - 1).Trim())
                        .Parameters.AddWithValue("@IDTrayecto", Integer.Parse(cmbTurno2.Text.Substring(0, cmbTurno2.Text.IndexOf(" ")).Trim()))
                    ElseIf Turno = 3 Then
                        If cmbTurno3.Text.Equals("Sin asignar") Then
                            ' txtSalon = "-1"
                            Continue For
                        End If
                        .Parameters.AddWithValue("@IDGrupo", cmbTurno3.Text.Substring(cmbTurno3.Text.IndexOf(" "), cmbTurno3.Text.Length - 1).Trim())
                        .Parameters.AddWithValue("@IDTrayecto", Integer.Parse(cmbTurno3.Text.Substring(0, cmbTurno3.Text.IndexOf(" ")).Trim()))
                    ElseIf Turno = 4 Then
                        If cmbTurno4.Text.Equals("Sin asignar") Then
                            ' txtSalon = "-1"
                            Continue For
                        End If
                        .Parameters.AddWithValue("@IDGrupo", cmbTurno4.Text.Substring(cmbTurno4.Text.IndexOf(" "), cmbTurno4.Text.Length - 1).Trim())
                        .Parameters.AddWithValue("@IDTrayecto", Integer.Parse(cmbTurno4.Text.Substring(0, cmbTurno4.Text.IndexOf(" ")).Trim()))
                    ElseIf Turno = 5 Then
                        If cmbTurno5.Text.Equals("Sin asignar") Then
                            ' txtSalon = "-1"
                            Continue For
                        End If
                        .Parameters.AddWithValue("@IDGrupo", cmbTurno5.Text.Substring(cmbTurno5.Text.IndexOf(" "), cmbTurno5.Text.Length - 1).Trim())
                        .Parameters.AddWithValue("@IDTrayecto", Integer.Parse(cmbTurno5.Text.Substring(0, cmbTurno5.Text.IndexOf(" ")).Trim()))
                    End If
                    .Parameters.AddWithValue("@IDTurno", Turno)
                    .Parameters.AddWithValue("@IDSalon", txtSalon)
                End With

                cmd.ExecuteNonQuery()
            End Using
        Next

        conexionSalones.Close()
    End Sub

    Private Sub txtIDSalon_TextChanged(t As Object, e As KeyPressEventArgs) Handles txtIDSalon.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = ""
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
        End If
    End Sub
End Class
