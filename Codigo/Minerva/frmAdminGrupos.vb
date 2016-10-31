Public Class frmAdminGrupos
    ' Clase principal para la administración de grupos

    Friend totalGrupos As Integer = 0
    Friend prevSelect As String
    Friend prevOrientacionSelect As String
    Friend frmMain As frmMain
    Dim editando As Boolean = False
    Dim previsualizando As Boolean = False
    Dim tipoUsuario As String

    Public Sub New(ByVal frmMain As frmMain, ByVal tipoUsuario As String)
        InitializeComponent()
        Me.frmMain = frmMain
        Me.tipoUsuario = tipoUsuario
    End Sub

    Private Sub frmAdminGrupos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Al cargar la ventana, cargarGrupos y rellenar los combos con los datos.
        cargarGrupos()

        controlesHabilitados(True)
        rellenarCombos()

        cmbAdscripto.SelectedIndex = 0

        cmbOrientacion.Enabled = False
        cmbGrado.Enabled = False
        cmbCurso.Focus()
        Call New ToolTip().SetToolTip(lblSalon, "Salón del grupo. Se administra en la pestaña Salones.")
        Call New ToolTip().SetToolTip(lblSalonReal, "Salón del grupo. Se administra en la pestaña Salones.")
    End Sub

    Public Sub agregarGrupo(ByVal NroGrupo As String, idTexto As String, ByVal nombreTurno As String)
        ' Basicamente copio la plantilla a un nuevo panel
        Dim pnlTemporal As New Panel
        Dim btnGrupo As New Button
        Dim btnEliminar As New Button
        Dim btnEditar As New Button()

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
        btnGrupo.TabStop = False

        btnGrupo.Tag = {NroGrupo}
        AddHandler btnGrupo.Click, AddressOf verGrupo

        btnEditar.Size = btnEditarPlantilla.Size
        btnEditar.FlatStyle = btnEditarPlantilla.FlatStyle
        btnEditar.ForeColor = btnEditarPlantilla.ForeColor
        btnEditar.Text = btnEditarPlantilla.Text
        btnEditar.BackColor = btnEditarPlantilla.BackColor
        btnEditar.Location = btnEditarPlantilla.Location
        btnEditar.Cursor = btnEditarPlantilla.Cursor
        btnEditar.TabStop = False
        btnEditar.Tag = {NroGrupo}
        AddHandler btnEditar.Click, AddressOf editarGrupo

        btnEliminar.Size = btnEliminarPlantilla.Size
        btnEliminar.FlatStyle = btnEliminarPlantilla.FlatStyle
        btnEliminar.ForeColor = btnEliminarPlantilla.ForeColor
        btnEliminar.Text = btnEliminarPlantilla.Text
        btnEliminar.BackColor = btnEliminarPlantilla.BackColor
        btnEliminar.Location = btnEliminarPlantilla.Location
        btnEliminar.Cursor = btnEliminarPlantilla.Cursor
        btnEliminar.TabStop = False

        If Me.tipoUsuario.Equals("Adscripto") Then
            btnEliminar.Visible = False
        End If

        btnEliminar.Tag = {NroGrupo, idTexto, nombreTurno}
        AddHandler btnEliminar.Click, AddressOf eliminarGrupo

        pnlTemporal.Controls.Add(btnEditar)
        pnlTemporal.Controls.Add(btnEliminar)
        pnlTemporal.Controls.Add(btnGrupo)

        pnlGrupos.Controls.Add(pnlTemporal)

        totalGrupos += 1
        lblCantidadGrupos.Text = "(" + totalGrupos.ToString() + ")"
    End Sub

    Private Sub controlesHabilitados(ByVal habilitado As Boolean)
        ' Habilita o deshabilita los controles
        txtIDGrupo.Enabled = habilitado
        txtIDGrupo.Text = ""

        cmbTurno.Enabled = habilitado
        cmbTurno.SelectedIndex = -1

        prevSelect = ""
        cmbCurso.Enabled = habilitado
        cmbCurso.SelectedIndex = -1
        cmbOrientacion.Enabled = habilitado
        cmbOrientacion.SelectedIndex = -1
        cmbGrado.Enabled = habilitado
        cmbGrado.SelectedIndex = -1
        chkDiscapacitado.Enabled = True
        chkDiscapacitado.Checked = False
    End Sub

    Public Sub btnNuevoGrupo_Click(sender As Object, e As EventArgs) Handles btnNuevoGrupo.Click
        ' Prepara la interfaz para agregar un nuevo grupo
        controlesHabilitados(True)
        lblNuevoGrupo.Text = "Nuevo grupo"
        btnNuevoGrupo.Visible = False
        btnAgregar.Visible = True
        btnAgregar.Text = "Agregar grupo"
        cmbOrientacion.Enabled = False
        cmbGrado.Enabled = False
        editando = False
        previsualizando = False
        chkDiscapacitado.TabStop = True
        cmbAdscripto.Enabled = True
        rellenarCombos()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        ' llama a checkDatos() cuando btnAgregar es clickeado
        checkDatos()
    End Sub

    Private Sub checkDatos()
        ' Comprueba los datos y en caso de que no falte ninguno, llama a actualizarDB()
        If Me.tipoUsuario.Equals("Adscripto") And Not editando Then
            MessageBox.Show("Oops!" & vbCrLf & "Solo los administradores y funcionarios pueden hacer eso...", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

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

        If String.IsNullOrWhiteSpace(cmbGrado.Text) Then
            MessageBox.Show("Debe seleccionar un grado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        actualizarDB()
    End Sub

    Private Sub verGrupo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Llama a previsualizarGrupo cuando un botón es clickeado.
        previsualizarGrupo(sender.Tag(0))

        chkDiscapacitado.TabStop = False
    End Sub

    Private Sub editarGrupo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nroGrupo As String = sender.Tag(0)
        previsualizarGrupo(sender.Tag(0))
        btnNuevoGrupo.Text = "Nuevo grupo / cancelar"
        btnNuevoGrupo.Visible = True
        btnAgregar.Text = "Guardar cambios"
        btnAgregar.Visible = True
        lblNuevoGrupo.Text = "Editar grupo"
        cmbAdscripto.Enabled = True
        previsualizando = False
        editando = True
    End Sub

    Private Sub previsualizarGrupo(ByVal nroGrupo As String)
        ' Prepara la interfaz para previsualizarUnGrupo
        btnNuevoGrupo.Visible = True
        btnAgregar.Visible = False
        btnNuevoGrupo.Text = "Nuevo grupo"
        lblNuevoGrupo.Text = "Previsualizar grupo"

        controlesHabilitados(False)
        cargarDatos(nroGrupo)
    End Sub

    Private Sub cmbCurso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCurso.SelectedIndexChanged
        ' Al cambiar el id de curso, cargarOrientaciones
        If cmbCurso.Text.Equals(prevSelect) Then
            Return
        End If
        cmbOrientacion.SelectedIndex = -1
        cargarOrientaciones()
        cmbOrientacion.Enabled = False
        If Not String.IsNullOrWhiteSpace(cmbCurso.Text) Then
            cmbOrientacion.Enabled = True
        End If
        prevSelect = cmbCurso.Text
    End Sub

    Private Sub txtIDGrupo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIDGrupo.KeyPress
        ' Al apretar la tecla espacio, ignorarla
        If e.KeyChar = " " Then
            e.KeyChar = Nothing
        End If
    End Sub

    ' Persistencia
    Public Sub cargarGrupos()
        Dim DB As New BaseDeDatos()
        DB.cargarGrupos_frmAdminGrupos(Me)
    End Sub

    Public Sub cargarOrientaciones()
        ' carga las orientaciones a los combobox
        Dim DB As New BaseDeDatos()
        DB.cargarOrientaciones_frmAdminGrupos(Me)
    End Sub

    Public Sub rellenarCombos()
        ' Llena los combos con los datos de la DB.
        cmbCurso.Items.Clear()
        cmbAdscripto.Items.Clear()
        Dim DB As New BaseDeDatos()
        DB.rellenarCombos_frmAdminGrupos(Me)
        DB.cargarAdscriptos_frmAdminGrupos(Me)
    End Sub

    Public Sub cargarDatos(ByVal nroGrupo As String)
        ' carga los datos del grupo y los coloca en la interfaz
        Dim DB As New BaseDeDatos()
        DB.cargarDatos_frmAdminGrupos(nroGrupo, Me)
        previsualizando = True
    End Sub

    Public Sub actualizarDB()
        Dim DB As New BaseDeDatos()
        DB.actualizarDB_frmAdminGrupos(Me)
    End Sub

    Public Sub cargarTurnos()
        Dim DB As New BaseDeDatos()
        DB.cargarTurnos_frmAdminGrupos(Me)
    End Sub

    Public Sub cargarGrados()
        Dim DB As New BaseDeDatos()
        DB.cargarGrados_frmAdminGrupos(Me)
    End Sub

    Private Sub eliminarGrupo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Le pregunta al usuario si quiere eliminar el grupo, de ser correcto, lo elimina
        Dim grupo As String
        grupo = sender.Tag(1)
        Dim result As Integer = MessageBox.Show("¿Está seguro de que desea eliminar el grupo '" + grupo + "'?", "Eliminar grupo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If

        Dim DB As New BaseDeDatos()
        DB.eliminarGrupo_frmAdminGrupos(sender.Tag(0), sender.Tag(1), Me)
        Me.frmMain.recargarGrupo()
    End Sub

    Private Sub chkDiscapacitado_CheckedChanged(sender As Object, e As EventArgs) Handles chkDiscapacitado.Click
        If previsualizando Then
            chkDiscapacitado.Checked = Not chkDiscapacitado.Checked
        End If
    End Sub

    Private Sub cmbOrientacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOrientacion.SelectedIndexChanged
        If cmbOrientacion.Text.Equals(prevOrientacionSelect) Then
            Return
        End If

        cmbGrado.SelectedIndex = -1
        cargarGrados()
        cmbGrado.Enabled = False
        If Not String.IsNullOrWhiteSpace(cmbOrientacion.Text) Then
            cmbGrado.Enabled = True
        End If
        prevOrientacionSelect = cmbOrientacion.Text
    End Sub
End Class
