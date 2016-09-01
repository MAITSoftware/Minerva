Imports MySql.Data.MySqlClient
Imports System.Data

Public Class frmAdminGrupos
    ' Clase principal para la administración de grupos

    Dim totalGrupos As Integer = 0
    Dim grupoPreview As Object = New Button()

    Private Sub frmAdminGrupos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarGrupos()

        controlesHabilitados(True)
        Call New ToolTip().SetToolTip(lblObligatorio1, "Dato obligatorio")
        Call New ToolTip().SetToolTip(lblObligatorio2, "Dato obligatorio")
        Call New ToolTip().SetToolTip(lblObligatorio3, "Dato obligatorio")
        Call New ToolTip().SetToolTip(lblObligatorio5, "Dato obligatorio")
        Call New ToolTip().SetToolTip(lblObligatorio6, "Dato obligatorio")

    End Sub

    Private Sub cargarGrupos()
        pnlGrupos.Controls.Clear()
        totalGrupos = 0
        lblCantidadGrupos.Text = "(" + totalGrupos.ToString() + ")"

        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `grupo`;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                agregarGrupo(reader("id"), reader("grado").ToString(), reader("turno"), reader("grado").ToString() & " " & reader("id") & ControlChars.NewLine & " (" & reader("turno") & ")")
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Private Sub agregarGrupo(ByVal idGrupo As String, ByVal grado As String, ByVal turno As String, ByVal idTexto As String)
        ' Basicamente copio la plantilla a un nuevo panel
        Dim pnlTemporal As New Panel
        Dim btnGrupo As New Button
        Dim btnEditar, btnEliminar As New Button

        pnlTemporal.Size = pnlGrupoPlantilla.Size
        btnGrupo.Size = btnGrupoPlantilla.Size
        btnGrupo.FlatStyle = btnGrupoPlantilla.FlatStyle
        btnGrupo.ForeColor = btnGrupoPlantilla.ForeColor
        btnGrupo.Text = idTexto
        btnGrupo.Margin = btnGrupoPlantilla.Margin
        btnGrupo.TextAlign = btnGrupoPlantilla.TextAlign
        btnGrupo.BackColor = btnGrupoPlantilla.BackColor
        btnGrupo.Location = btnGrupoPlantilla.Location
        btnGrupo.Cursor = btnGrupoPlantilla.Cursor
        btnGrupo.Font = btnGrupoPlantilla.Font

        btnGrupo.Tag = {idGrupo, grado, turno}
        AddHandler btnGrupo.Click, AddressOf verGrupo

        btnEditar.Size = btnEditarPlantilla.Size
        btnEditar.FlatStyle = btnEditarPlantilla.FlatStyle
        btnEditar.ForeColor = btnEditarPlantilla.ForeColor
        btnEditar.Text = btnEditarPlantilla.Text
        btnEditar.BackColor = btnEditarPlantilla.BackColor
        btnEditar.Location = btnEditarPlantilla.Location
        btnEditar.Cursor = btnEditarPlantilla.Cursor

        btnEditar.Tag = {idGrupo, grado, turno}
        AddHandler btnEditar.Click, AddressOf editarGrupo

        btnEliminar.Size = btnEliminarPlantilla.Size
        btnEliminar.FlatStyle = btnEliminarPlantilla.FlatStyle
        btnEliminar.ForeColor = btnEliminarPlantilla.ForeColor
        btnEliminar.Text = btnEliminarPlantilla.Text
        btnEliminar.BackColor = btnEliminarPlantilla.BackColor
        btnEliminar.Location = btnEliminarPlantilla.Location
        btnEliminar.Cursor = btnEliminarPlantilla.Cursor

        btnEliminar.Tag = {idGrupo, grado, turno}
        AddHandler btnEliminar.Click, AddressOf eliminarGrupo

        pnlTemporal.Controls.Add(btnEditar)
        pnlTemporal.Controls.Add(btnEliminar)
        pnlTemporal.Controls.Add(btnGrupo)

        pnlGrupos.Controls.Add(pnlTemporal)

        totalGrupos += 1
        lblCantidadGrupos.Text = "(" + totalGrupos.ToString() + ")"
    End Sub

    Private Sub editarGrupo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grupoPreview.Enabled = True
        grupoPreview = sender.Parent
        grupoPreview.Enabled = False
        lblNuevoGrupo.Text = "Editar grupo"
        btnCancelarEdicion.Visible = True
        btnAgregar.Visible = True
        btnNuevoGrupo.Visible = False
        btnAgregar.Text = "Guardar cambios"

        controlesHabilitados(True)
        cargarDatos(sender.Tag)
        txtIDGrupo.Enabled = False
        numGrado.Enabled = False
        cmbTurno.Enabled = False
    End Sub

    Private Sub controlesHabilitados(ByVal habilitado As Boolean)
        txtIDGrupo.Enabled = habilitado
        txtIDGrupo.Text = ""

        cmbTurno.Enabled = habilitado
        cmbTurno.SelectedIndex = -1
        cmbCurso.Enabled = habilitado
        cmbCurso.SelectedIndex = -1
        cmbOrientacion.Enabled = habilitado
        cmbOrientacion.SelectedIndex = -1
        numGrado.Enabled = habilitado
        numGrado.Value = 1
    End Sub

    Private Sub btnNuevoGrupo_Click(sender As Object, e As EventArgs) Handles btnNuevoGrupo.Click, btnCancelarEdicion.Click
        controlesHabilitados(True)
        lblNuevoGrupo.Text = "Nuevo grupo"
        btnNuevoGrupo.Visible = False
        btnAgregar.Visible = True
        btnAgregar.Text = "Agregar grupo"
        btnCancelarEdicion.Visible = False
        grupoPreview.Enabled = True
        grupoPreview = New Button()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        checkDatos()
    End Sub

    Private Sub checkDatos()
        If String.IsNullOrWhiteSpace(txtIDGrupo.Text) Then
            MessageBox.Show("Debe ingresar un ID de grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        If String.IsNullOrWhiteSpace(cmbCurso.Text) Then
            MessageBox.Show("Debe seleccionar un curso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        If String.IsNullOrWhiteSpace(cmbOrientacion.Text) Then
            MessageBox.Show("Debe seleccionar una orientación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        If String.IsNullOrWhiteSpace(cmbTurno.Text) Then
            MessageBox.Show("Debe seleccionar un turno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        actualizarDB()
    End Sub

    Private Sub eliminarGrupo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim grupo As String
        grupo = sender.Tag(1) + " " + sender.Tag(0) + " (" + sender.Tag(2) + ")"
        Dim result As Integer = MessageBox.Show("¿Está seguro de que desea eliminar el grupo '" + grupo + "'?", "Eliminar grupo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If

        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM `grupo` WHERE id=@id and turno=@turno and grado=@grado;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@id", sender.Tag(0))
                .Parameters.AddWithValue("@turno", sender.Tag(2))
                .Parameters.AddWithValue("@grado", sender.Tag(1))
            End With
            totalGrupos -= 1
            cmd.ExecuteNonQuery()
            conexion.Close() 'Cierra la conexión
            cargarGrupos()
            btnNuevoGrupo_Click(Nothing, Nothing)
            MessageBox.Show("Grupo '" + grupo + "' eliminado.", "Grupo eliminado.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using

    End Sub

    Private Sub actualizarDB()
        Dim conexion As New DB()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text

                If btnAgregar.Text.Equals("Agregar grupo") Then
                    .CommandText = "INSERT INTO `grupo` VALUES  (@id, @grado, @curso, @turno, @orientacion);"
                Else
                    .CommandText = "UPDATE `grupo` SET grado=@grado, curso=@curso, turno=@turno, orientacion=@orientacion, WHERE id=@id and turno=@turno and grado=@grado;"
                End If

                .Parameters.AddWithValue("@grado", numGrado.Value.ToString())
                .Parameters.AddWithValue("@id", txtIDGrupo.Text)
                .Parameters.AddWithValue("@curso", cmbCurso.Text)
                .Parameters.AddWithValue("@turno", cmbTurno.Text)
                .Parameters.AddWithValue("@orientacion", cmbOrientacion.Text)
            End With

            Try
                cmd.ExecuteNonQuery()
                conexion.Close()

                cargarGrupos()
                If btnAgregar.Text.Equals("Agregar grupo") Then
                    MessageBox.Show("Grupo agregado correctamente", "Grupo agregado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Else
                    MessageBox.Show("Información de grupo actualizada correctamente", "Grupo actualizado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
                btnNuevoGrupo_Click(Nothing, Nothing)
            Catch ex As Exception
                If ex.ToString().Contains("Duplicate") Then
                    MessageBox.Show("Ya existe un grupo con el mismo grado y ID en dicho turno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Try
        End Using
    End Sub

    Private Sub verGrupo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        previsualizarGrupo(sender.Tag(0), sender.Tag(1).ToString(), sender.Tag(2))
    End Sub

    Private Sub previsualizarGrupo(ByVal id As String, ByVal grado As String, ByVal turno As String)
        btnNuevoGrupo.Visible = True
        btnAgregar.Visible = False
        btnCancelarEdicion.Visible = False

        grupoPreview.Enabled = True
        grupoPreview = Nothing
        For Each pnl As Panel In pnlGrupos.Controls
            For Each x As Button In pnl.Controls
                Dim txt As String = grado & " " & id & ControlChars.NewLine & " (" + turno + ")"
                If x.Text.Equals(txt) Then
                    If IsNothing(grupoPreview) Then
                        grupoPreview = x
                    End If
                End If
            Next
        Next

        grupoPreview.Enabled = False

        lblNuevoGrupo.Text = "Previsualizar grupo"

        controlesHabilitados(False)
        cargarDatos({id, grado, turno})
    End Sub

    Private Sub cargarDatos(ByVal grupo As Object)
        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `grupo` where id=@id and turno=@turno and grado=@grado;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@id", grupo(0))
                .Parameters.AddWithValue("@grado", grupo(1))
                .Parameters.AddWithValue("@turno", grupo(2))
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                txtIDGrupo.Text = reader("id")
                numGrado.Value = Integer.Parse(reader("grado"))
                cmbCurso.SelectedIndex = cmbCurso.FindStringExact(reader("curso"))
                cmbTurno.SelectedIndex = cmbTurno.FindStringExact(reader("turno"))
                cmbOrientacion.SelectedIndex = cmbOrientacion.FindStringExact(reader("orientacion"))
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

End Class
