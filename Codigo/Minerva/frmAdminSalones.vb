Imports MySql.Data.MySqlClient
Imports System.Data

Public Class frmAdminSalones
    ' Clase principal de administración de salones

    Dim totalSalones As Integer = 0
    Dim salonPreview As Object = New Button()

    Private Sub frmAdminSalones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarSalones()
    End Sub

    Private Sub cargarSalones()
        pnlSalones.Controls.Clear()
        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `salon`;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                agregarSalon(reader("id"))
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
        btnNuevoSalon.Visible = True
        btnAgregar.Visible = False
        btnCancelarEdicion.Visible = False
        salonPreview.Enabled = True
        salonPreview = sender
        salonPreview.Enabled = False

        lblNuevoSalon.Text = "Previsualizar salón"

        controlesHabilitados(False)

        cargarDatos(sender.Tag)
    End Sub
    Private Sub eliminarSalon(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM `salon` WHERE ID=@id;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@id", sender.Tag)
            End With
            cmd.ExecuteNonQuery()
            conexion.Close() 'Cierra la conexión
            cargarSalones()
            btnNuevoSalon_Click(Nothing, Nothing)
        End Using
    End Sub
    Private Sub cargarDatos(ByVal idSalon As String)
        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `salon` where id=@id;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@id", idSalon)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                txtIDSalon.Text = reader("id")
                txtCapacidad.Text = reader("capacidad")
                txtComentarios.Text = reader("comentarios").ToString()
                cmbPlanta.SelectedIndex = cmbPlanta.FindStringExact(reader("planta"))
                cmbTurno1.SelectedIndex = cmbTurno1.FindStringExact(reader("turno1"))
                cmbTurno2.SelectedIndex = cmbTurno2.FindStringExact(reader("turno2"))
                cmbTurno3.SelectedIndex = cmbTurno3.FindStringExact(reader("turno3"))
                cmbTurno4.SelectedIndex = cmbTurno4.FindStringExact(reader("turno4"))
                cmbTurno5.SelectedIndex = cmbTurno5.FindStringExact(reader("turno5"))
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Private Sub controlesHabilitados(ByVal habilitado As Boolean)
        txtIDSalon.Enabled = habilitado
        txtIDSalon.Text = ""
        cmbPlanta.Enabled = habilitado
        cmbPlanta.SelectedIndex = -1
        cmbTurno1.Enabled = habilitado
        cmbTurno1.SelectedIndex = -1
        cmbTurno2.Enabled = habilitado
        cmbTurno2.SelectedIndex = -1
        cmbTurno3.Enabled = habilitado
        cmbTurno3.SelectedIndex = -1
        cmbTurno4.Enabled = habilitado
        cmbTurno4.SelectedIndex = -1
        cmbTurno5.Enabled = habilitado
        cmbTurno5.SelectedIndex = -1
        txtComentarios.Enabled = habilitado
        txtComentarios.Text = ""
        txtCapacidad.Enabled = habilitado
        txtCapacidad.Text = ""
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
        Dim conexion As New DB()
        If btnAgregar.Text.Equals("Agregar salón") Then
            Using cmd As New MySqlCommand()
                With cmd
                    .Connection = conexion.Conn
                    .CommandText = "INSERT INTO `salon` VALUES  (@id, @planta, @capacidad, @turno1, @turno2, @turno3, @turno4, @turno5, @comentarios);"
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@id", txtIDSalon.Text)
                    .Parameters.AddWithValue("@planta", cmbPlanta.Text)
                    .Parameters.AddWithValue("@capacidad", txtCapacidad.Text)
                    .Parameters.AddWithValue("@turno1", cmbTurno1.Text)
                    .Parameters.AddWithValue("@turno2", cmbTurno2.Text)
                    .Parameters.AddWithValue("@turno3", cmbTurno3.Text)
                    .Parameters.AddWithValue("@turno4", cmbTurno4.Text)
                    .Parameters.AddWithValue("@turno5", cmbTurno5.Text)
                    .Parameters.AddWithValue("@comentarios", txtComentarios.Text)
                End With

                Try
                    cmd.ExecuteNonQuery()
                    conexion.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString())
                End Try
            End Using
        Else
            Using cmd As New MySqlCommand()
                With cmd
                    .Connection = conexion.Conn
                    .CommandText = "UPDATE `salon` SET planta=@planta, capacidad=@capacidad, turno1=@turno1, turno2=@turno2, turno3=@turno3, turno4=@turno4, turno5=@turno5, comentarios=@comentarios WHERE id=@id;"
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@planta", cmbPlanta.Text)
                    .Parameters.AddWithValue("@capacidad", txtCapacidad.Text)
                    .Parameters.AddWithValue("@turno1", cmbTurno1.Text)
                    .Parameters.AddWithValue("@turno2", cmbTurno2.Text)
                    .Parameters.AddWithValue("@turno3", cmbTurno3.Text)
                    .Parameters.AddWithValue("@turno4", cmbTurno4.Text)
                    .Parameters.AddWithValue("@turno5", cmbTurno5.Text)
                    .Parameters.AddWithValue("@comentarios", txtComentarios.Text)
                    .Parameters.AddWithValue("@id", txtIDSalon.Text)
                End With

                Try
                    cmd.ExecuteNonQuery()
                    conexion.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString())
                End Try
            End Using
        End If
        cargarSalones()
        btnNuevoSalon_Click(Nothing, Nothing)
    End Sub
End Class
