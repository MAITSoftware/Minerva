Public Class frmAdminGrupos
    ' Clase principal para la administración de grupos

    Dim totalGrupos As Integer = 0
    Dim salonPreview As Object = New Button()

    Private Sub frmAdminGrupos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarGrupos()

        controlesHabilitados(True)
        Call New ToolTip().SetToolTip(lblObligatorio1, "Dato obligatorio")
        Call New ToolTip().SetToolTip(lblObligatorio2, "Dato obligatorio")
        Call New ToolTip().SetToolTip(lblObligatorio3, "Dato obligatorio")
        Call New ToolTip().SetToolTip(lblObligatorio4, "Dato obligatorio")
        Call New ToolTip().SetToolTip(lblObligatorio5, "Dato obligatorio")
        Call New ToolTip().SetToolTip(lblObligatorio6, "Dato obligatorio")
        Call New ToolTip().SetToolTip(lblObligatorio7, "Dato obligatorio")
    End Sub

    Private Sub cargarGrupos()
        pnlGrupos.Controls.Clear()
        totalGrupos = 0
        lblCantidadGrupos.Text = "(" + totalGrupos.ToString() + ")"
    End Sub

    Private Sub agregarGrupo(ByVal idGrupo As String)
        ' Basicamente copio la plantilla a un nuevo panel
        Dim pnlTemporal As New Panel
        Dim btnGrupo As New Button
        Dim btnEditar, btnEliminar As New Button

        pnlTemporal.Size = pnlGrupoPlantilla.Size
        btnGrupo.Size = btnGrupoPlantilla.Size
        btnGrupo.FlatStyle = btnGrupoPlantilla.FlatStyle
        btnGrupo.ForeColor = btnGrupoPlantilla.ForeColor
        btnGrupo.Text = idGrupo
        btnGrupo.BackColor = btnGrupoPlantilla.BackColor
        btnGrupo.Location = btnGrupoPlantilla.Location
        btnGrupo.Cursor = btnGrupoPlantilla.Cursor
        btnGrupo.Font = btnGrupoPlantilla.Font

        btnGrupo.Tag = idGrupo
        ' AddHandler btnGrupo.Click, AddressOf verGrupo

        btnEditar.Size = btnEditarPlantilla.Size
        btnEditar.FlatStyle = btnEditarPlantilla.FlatStyle
        btnEditar.ForeColor = btnEditarPlantilla.ForeColor
        btnEditar.Text = btnEditarPlantilla.Text
        btnEditar.BackColor = btnEditarPlantilla.BackColor
        btnEditar.Location = btnEditarPlantilla.Location
        btnEditar.Cursor = btnEditarPlantilla.Cursor

        btnEditar.Tag = idGrupo
        AddHandler btnEditar.Click, AddressOf editarGrupo

        btnEliminar.Size = btnEliminarPlantilla.Size
        btnEliminar.FlatStyle = btnEliminarPlantilla.FlatStyle
        btnEliminar.ForeColor = btnEliminarPlantilla.ForeColor
        btnEliminar.Text = btnEliminarPlantilla.Text
        btnEliminar.BackColor = btnEliminarPlantilla.BackColor
        btnEliminar.Location = btnEliminarPlantilla.Location
        btnEliminar.Cursor = btnEliminarPlantilla.Cursor

        btnEliminar.Tag = idGrupo
        AddHandler btnEliminar.Click, AddressOf eliminarGrupo

        pnlTemporal.Controls.Add(btnEditar)
        pnlTemporal.Controls.Add(btnEliminar)
        pnlTemporal.Controls.Add(btnGrupo)

        pnlGrupos.Controls.Add(pnlTemporal)

        totalGrupos += 1
        lblCantidadGrupos.Text = "(" + totalGrupos.ToString() + ")"
    End Sub

    Private Sub editarGrupo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        salonPreview.Enabled = True
        salonPreview = sender.Parent
        salonPreview.Enabled = False
        lblNuevoGrupo.Text = "Editar salón"
        btnCancelarEdicion.Visible = True
        btnAgregar.Visible = True
        btnNuevoGrupo.Visible = False
        btnAgregar.Text = "Guardar cambios"

        controlesHabilitados(True)
        'cargarDatos(sender.Tag)
        txtIDDB.Enabled = False

    End Sub

    Private Sub controlesHabilitados(ByVal habilitado As Boolean)
        txtIDDB.Enabled = habilitado
        txtIDDB.Text = ""
        txtIDGrupo.Enabled = habilitado
        txtIDGrupo.Text = ""

        cmbTurno.Enabled = habilitado
        cmbTurno.SelectedIndex = -1
        cmbCurso.Enabled = habilitado
        cmbCurso.SelectedIndex = 0
        cmbOrientacion.Enabled = habilitado
        cmbOrientacion.SelectedIndex = 0
        cmbSalon.Enabled = habilitado
        cmbSalon.SelectedIndex = 0
        txtIDDB.Enabled = habilitado
        txtIDDB.Text = ""
        numGrado.Enabled = habilitado
        numGrado.Value = 1
        numAlumnos.Enabled = habilitado
        numAlumnos.Value = 1
    End Sub

    Private Sub btnNuevoGrupo_Click(sender As Object, e As EventArgs) Handles btnNuevoGrupo.Click, btnCancelarEdicion.Click
        controlesHabilitados(True)
        lblNuevoGrupo.Text = "Nuevo salón"
        btnNuevoGrupo.Visible = False
        btnAgregar.Visible = True
        btnAgregar.Text = "Agregar salón"
        btnCancelarEdicion.Visible = False
        salonPreview.Enabled = True
        salonPreview = New Button()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        checkDatos()
        agregarGrupo("3ºerobg")
    End Sub

    Private Sub checkDatos()
        'If String.IsNullOrWhiteSpace(txtIDSalon.Text) Then
        '    MessageBox.Show("Error", "Debe ingresar un ID de salón.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        '    Return
        'End If

        'If String.IsNullOrWhiteSpace(cmbPlanta.Text) Then
        '    MessageBox.Show("Error", "Debe ingresar la planta del salón.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        '    Return
        'End If

        ' actualizarDB()
    End Sub

    Private Sub eliminarGrupo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim result As Integer = MessageBox.Show("¿Está seguro de que desea eliminar el salón '" + sender.Tag + "'?", "Eliminar salón", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If
    End Sub
End Class
