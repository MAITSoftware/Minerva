Imports MySql.Data.MySqlClient
Imports System.Data

Public Class frmAdminUsuarios

    Dim totalUsuarios As Integer = 0
    Dim tipoSeleccionado As String = "Funcionario"
    Dim usuarioHabilitado As Boolean = False
    Dim previsualizando As Boolean = False
    Private DB As DB

    Private Sub frmAdminUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarUsuarios()
        nuevoUsuario(Nothing, Nothing)
    End Sub

    Private Sub agregarUsuario(ByVal IDUsuario As String, ByVal Tipo As String)
        ' Basicamente copio la plantilla a un nuevo panel
        Dim pnlTemporal As New Panel
        Dim btnUsuario As New Button
        Dim btnEliminar, btnEditar As New Button

        pnlTemporal.Size = pnlUsuarioPlantilla.Size
        btnUsuario.Size = btnUsuarioPlantilla.Size
        btnUsuario.FlatStyle = btnUsuarioPlantilla.FlatStyle
        btnUsuario.ForeColor = btnUsuarioPlantilla.ForeColor
        btnUsuario.Text = IDUsuario & vbCrLf & "(" & Tipo & ")"
        btnUsuario.Margin = btnUsuarioPlantilla.Margin
        btnUsuario.TextAlign = btnUsuarioPlantilla.TextAlign
        btnUsuario.BackColor = btnUsuarioPlantilla.BackColor
        btnUsuario.Location = btnUsuarioPlantilla.Location
        btnUsuario.Cursor = btnUsuarioPlantilla.Cursor
        btnUsuario.Font = btnUsuarioPlantilla.Font

        btnUsuario.Tag = IDUsuario
        AddHandler btnUsuario.Click, AddressOf verUsuario_Click

        btnEditar.Size = btnEditarPlantilla.Size
        btnEditar.FlatStyle = btnEditarPlantilla.FlatStyle
        btnEditar.ForeColor = btnEditarPlantilla.ForeColor
        btnEditar.Text = btnEditarPlantilla.Text
        btnEditar.BackColor = btnEditarPlantilla.BackColor
        btnEditar.Location = btnEditarPlantilla.Location
        btnEditar.Cursor = btnEditarPlantilla.Cursor

        btnEditar.Tag = IDUsuario
        AddHandler btnEditar.Click, AddressOf editarUsuario

        btnEliminar.Size = btnEliminarPlantilla.Size
        btnEliminar.FlatStyle = btnEliminarPlantilla.FlatStyle
        btnEliminar.ForeColor = btnEliminarPlantilla.ForeColor
        btnEliminar.Text = btnEliminarPlantilla.Text
        btnEliminar.BackColor = btnEliminarPlantilla.BackColor
        btnEliminar.Location = btnEliminarPlantilla.Location
        btnEliminar.Cursor = btnEliminarPlantilla.Cursor

        btnEliminar.Tag = {IDUsuario, btnUsuario.Text.Replace(vbCrLf, " ")}
        AddHandler btnEliminar.Click, AddressOf eliminarUsuario

        pnlTemporal.Controls.Add(btnUsuario)
        pnlTemporal.Controls.Add(btnEliminar)
        pnlTemporal.Controls.Add(btnEditar)

        pnlUsuarios.Controls.Add(pnlTemporal)
        pnlUsuarios.Focus()

        totalUsuarios += 1
        lblCantidadUsuarios.Text = "(" + totalUsuarios.ToString() + ")"
    End Sub

    Private Sub cargarUsuarios()
        Dim conexion As New DB()
        pnlUsuarios.Controls.Clear()
        totalUsuarios = 0
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Usuario`;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                agregarUsuario(reader("ID"), reader("Tipo"))
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        checkDatos()
    End Sub

    Private Sub checkDatos()
        If String.IsNullOrWhiteSpace(txtID.Text) Then
            MessageBox.Show("Debe ingresar un ID de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        If String.IsNullOrEmpty(txtContraseña.Text) Then
            MessageBox.Show("Debe ingresar una contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
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

                If btnAgregar.Text.Equals("Agregar usuario") Then
                    .CommandText = "INSERT INTO `Usuario` VALUES  (@ID, @Contraseña, @Aprobado, @Tipo);"
                Else
                    .CommandText = "UPDATE `Usuario` SET Contraseña=@Contraseña, Aprobado=@Aprobado, Tipo=@Tipo WHERE ID=@ID;"
                End If

                .Parameters.AddWithValue("@ID", txtID.Text)
                .Parameters.AddWithValue("@Contraseña", txtContraseña.Text)
                .Parameters.AddWithValue("@Aprobado", chkHabilitado.Checked)
                .Parameters.AddWithValue("@Tipo", tipoSeleccionado)
            End With

            Try
                cmd.ExecuteNonQuery()
                conexion.Close()
                If btnAgregar.Text.Equals("Agregar usuario") Then
                    MessageBox.Show("Usuario agregado correctamente", "Usuario agregado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Else
                    MessageBox.Show("Información de usuario actualizada correctamente", "Usuario actualizado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
                cargarUsuarios()
                nuevoUsuario(Nothing, Nothing)
            Catch ex As Exception
                If ex.ToString().Contains("Duplicate") Then
                    MessageBox.Show("Ya existe un usuario con ese ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Try
        End Using
    End Sub

    Private Sub rad_CheckedChanged(sender As Object, e As EventArgs) Handles radFuncionario.CheckedChanged, radAdministrador.CheckedChanged
        If previsualizando Then
            If tipoSeleccionado.Equals("Funcionario") Then
                radFuncionario.Checked = True
                radAdministrador.Checked = False
            Else
                radFuncionario.Checked = False
                radAdministrador.Checked = True
            End If
            Return
        End If
        If sender.Checked Then
            tipoSeleccionado = sender.Text
        End If
    End Sub

    Private Sub nuevoUsuario(sender As Object, e As EventArgs) Handles btnNuevoUsuario.Click, btnCancelar.Click
        lblNuevoUsuario.Text = "Nuevo usuario"
        btnAgregar.Text = "Agregar usuario"

        previsualizando = False
        btnAgregar.Visible = True
        btnCancelar.Visible = False
        btnNuevoUsuario.Visible = False
        txtID.Enabled = True
        txtContraseña.Enabled = True
        radFuncionario.Checked = True
        tipoSeleccionado = "Funcionario"
        limpiarControles()
    End Sub

    Private Sub limpiarControles()
        chkHabilitado.Checked = False
        radAdministrador.Checked = False
        radFuncionario.Checked = True
        txtID.Text = ""
        txtContraseña.Text = ""
        tipoSeleccionado = "Funcionario"
    End Sub

    Private Sub editarUsuario(sender As Object, e As EventArgs)
        lblNuevoUsuario.Text = "Editar usuario"
        btnNuevoUsuario.Visible = False
        btnAgregar.Text = "Confirmar cambios"
        btnAgregar.Visible = True
        btnCancelar.Visible = True
        txtContraseña.Enabled = True
        cargarDatos(sender.Tag)
        txtID.Enabled = False
        previsualizando = False
    End Sub

    Private Sub cargarDatos(ByVal ID As String)
        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Usuario` WHERE ID=@ID;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@ID", ID)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                txtID.Text = reader("ID")
                txtContraseña.Text = reader("Contraseña")
                chkHabilitado.Checked = reader("Aprobado")
                usuarioHabilitado = reader("Aprobado")
                tipoSeleccionado = reader("Tipo")
                If reader("Tipo").Equals("Funcionario") Then
                    radFuncionario.Checked = True
                Else
                    radAdministrador.Checked = True
                End If
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Private Sub verUsuario_Click(sender As Object, e As EventArgs)
        verUsuario(sender.Tag)
        previsualizando = True
    End Sub

    Private Sub verUsuario(ByVal ID As String)
        limpiarControles()
        cargarDatos(ID)
        lblNuevoUsuario.Text = "Previsualizar usuario"
        btnNuevoUsuario.Visible = True
        btnCancelar.Visible = False
        btnAgregar.Visible = False
        txtID.Enabled = False
        txtContraseña.Enabled = False
    End Sub

    Private Sub chkHabilitado_CheckedChanged(sender As Object, e As EventArgs) Handles chkHabilitado.CheckedChanged
        If previsualizando Then
            chkHabilitado.Checked = usuarioHabilitado
            Return
        End If
        usuarioHabilitado = chkHabilitado.Checked
    End Sub

    Private Sub eliminarUsuario(sender As Object, e As EventArgs)
        Dim result As Integer = MessageBox.Show("¿Está seguro de que desea eliminar el usuario '" + sender.Tag(1) + "'?", "Eliminar usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If

        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM `Usuario` WHERE ID=@ID;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@ID", sender.Tag(0))
            End With

            cmd.ExecuteNonQuery()
            conexion.Close() 'Cierra la conexión
            cargarUsuarios()
            nuevoUsuario(Nothing, Nothing)
            MessageBox.Show("Usuario '" + sender.Tag(1) + "' eliminado.", "Usuario eliminado.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
    End Sub
End Class
