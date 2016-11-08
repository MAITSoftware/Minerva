Public Class frmAdminGrupos
    ' Clase principal para la administración de grupos

    Friend totalGrupos As Integer = 0
    Friend prevSelect As String
    Friend prevOrientacionSelect As String
    Friend primerGrupo As String
    Friend frmMain As frmMain

    Dim nroGrupo As String
    Dim grupoPreview As Control = New Button()
    Friend tipoUsuario As String
    Dim editando As Boolean = False
    Dim previsualizando As Boolean = False
    Friend ciusuario As String
    Friend frmAdministrar As frmAdministrar

    Public Sub New(ByVal frmMain As frmMain, ByVal tipousuario As String, ByVal ciUsuario As String, ByVal frmAdministrar As frmAdministrar)
        InitializeComponent()
        Me.frmMain = frmMain
        Me.tipoUsuario = tipousuario
        Me.ciusuario = ciUsuario
        Me.frmAdministrar = frmAdministrar
    End Sub

    Private Sub frmAdminGrupos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Al cargar la ventana, cargarGrupos y rellenar los combos con los datos.

        controlesHabilitados(True)
        rellenarCombos()

        cmbAdscripto.SelectedIndex = 0

        cmbOrientacion.Enabled = False
        cmbGrado.Enabled = False
        cmbCurso.Focus()
        cargarGrupos()
    End Sub

    Public Sub agregarGrupo(ByVal NroGrupo As String, idTexto As String, ByVal nombreTurno As String, ByVal ciAdscripto As String)
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

        btnGrupo.Tag = {NroGrupo, "principal"}
        AddHandler btnGrupo.Click, AddressOf verGrupo

        btnEditar.Size = btnEditarPlantilla.Size
        btnEditar.FlatStyle = btnEditarPlantilla.FlatStyle
        btnEditar.ForeColor = btnEditarPlantilla.ForeColor
        btnEditar.Text = btnEditarPlantilla.Text
        btnEditar.BackColor = btnEditarPlantilla.BackColor
        btnEditar.Location = btnEditarPlantilla.Location
        btnEditar.Cursor = btnEditarPlantilla.Cursor
        btnEditar.TabStop = False
        btnEditar.Tag = {NroGrupo, "editar"}
        AddHandler btnEditar.Click, AddressOf editarGrupo

        btnEliminar.Size = btnEliminarPlantilla.Size
        btnEliminar.FlatStyle = btnEliminarPlantilla.FlatStyle
        btnEliminar.ForeColor = btnEliminarPlantilla.ForeColor
        btnEliminar.Text = btnEliminarPlantilla.Text
        btnEliminar.BackColor = btnEliminarPlantilla.BackColor
        btnEliminar.Location = btnEliminarPlantilla.Location
        btnEliminar.Cursor = btnEliminarPlantilla.Cursor
        btnEliminar.TabStop = False

        btnEliminar.Tag = {NroGrupo, idTexto, nombreTurno}
        AddHandler btnEliminar.Click, AddressOf eliminarGrupo

        If Me.tipoUsuario.Equals("Adscripto") Then
            btnEliminar.Visible = False
            btnEditar.Text = "Editar" & vbCrLf & "salón"
            btnEditar.Height = btnGrupo.Height
        End If
        AddHandler pnlTemporal.MouseWheel, AddressOf fixScroll
        AddHandler pnlTemporal.MouseEnter, AddressOf fixScroll
        pnlTemporal.Controls.Add(btnEditar)
        pnlTemporal.Controls.Add(btnEliminar)
        pnlTemporal.Controls.Add(btnGrupo)
        pnlGrupos.Controls.Add(pnlTemporal)

        totalGrupos += 1
        lblCantidadGrupos.Text = "(" + totalGrupos.ToString() + ")"
    End Sub

    Private Sub fixScroll(sender As Object, e As Object)
        pnlGrupos.Focus()
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

        cmbSalon.Enabled = habilitado
    End Sub

    Public Sub btnNuevoGrupo_Click(sender As Object, e As EventArgs) Handles btnNuevoGrupo.Click
        ' Prepara la interfaz para agregar un nuevo grupo
        If Me.tipoUsuario.Equals("Adscripto") Then
            previsualizarGrupo(nroGrupo)
            Return
        End If
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
        grupoPreview.Enabled = True
        grupoPreview = New Button()
        chkDistribuir.Checked = True
        chkDistribuir.Visible = True
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

        grupoPreview.Enabled = True
        grupoPreview = sender.Parent
        grupoPreview.Enabled = False

        btnNuevoGrupo.Text = "Nuevo grupo / cancelar"
        If Me.tipoUsuario.Equals("Adscripto") Then
            btnNuevoGrupo.Text = "Cancelar"
        End If
        btnNuevoGrupo.Visible = True
        btnAgregar.Text = "Guardar cambios"
        btnAgregar.Visible = True
        lblNuevoGrupo.Text = "Editar grupo"
        cmbAdscripto.Enabled = True
        previsualizando = False
        editando = True
        cmbSalon.Enabled = True
        If Me.tipoUsuario.Equals("Adscripto") Then
            cmbAdscripto.Enabled = False
        End If
        chkDistribuir.Checked = False
        chkDistribuir.Visible = False
    End Sub

    Private Sub previsualizarGrupo(ByVal nroGrupo As String)
        ' Prepara la interfaz para previsualizarUnGrupo
        Me.nroGrupo = nroGrupo
        btnNuevoGrupo.Visible = True
        btnAgregar.Visible = False
        btnNuevoGrupo.Text = "Nuevo grupo"
        lblNuevoGrupo.Text = "Previsualizar grupo"

        grupoPreview.Enabled = True
        grupoPreview = Nothing
        For Each pnl As Panel In pnlGrupos.Controls
            For Each x As Button In pnl.Controls
                If x.Tag(0).Equals(nroGrupo) And x.Tag(1).Equals("principal") Then
                    If IsNothing(grupoPreview) Then
                        grupoPreview = x
                    End If
                End If
            Next
        Next

        If Me.tipoUsuario.Equals("Adscripto") Then
            btnNuevoGrupo.Visible = False
        End If
        grupoPreview.Enabled = False

        chkDistribuir.Checked = False
        chkDistribuir.Visible = False

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
        Dim Logica as New Logica()
        Logica.cargarGrupos_frmAdminGrupos(Me)
        If Me.totalGrupos = 0 And Me.tipoUsuario.Equals("Adscripto") Then
            lblNoGrupoAsignado.Visible = True
        ElseIf Me.tipoUsuario.Equals("Adscripto") Then
            previsualizarGrupo(primerGrupo)
        End If
    End Sub

    Public Sub cargarOrientaciones()
        ' carga las orientaciones a los combobox
        Dim Logica as New Logica()
        Logica.cargarOrientaciones_frmAdminGrupos(Me)
    End Sub

    Public Sub rellenarCombos()
        ' Llena los combos con los datos de la Logica.
        cmbCurso.Items.Clear()
        cmbAdscripto.Items.Clear()
        Dim Logica as New Logica()
        Logica.rellenarCombos_frmAdminGrupos(Me)
        Logica.cargarAdscriptos_frmAdminGrupos(Me)
        Logica.cargarSalones_frmAdminGrupos(Me)
    End Sub

    Public Sub cargarDatos(ByVal nroGrupo As String)
        ' carga los datos del grupo y los coloca en la interfaz
        Dim Logica as New Logica()
        Logica.cargarDatos_frmAdminGrupos(nroGrupo, Me)
        previsualizando = True
    End Sub

    Public Sub actualizarDB()
        Dim Logica as New Logica()
        Logica.actualizarDB_frmAdminGrupos(Me)
    End Sub

    Public Sub cargarGrados()
        Dim Logica as New Logica()
        Logica.cargarGrados_frmAdminGrupos(Me)
    End Sub

    Private Sub eliminarGrupo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Le pregunta al usuario si quiere eliminar el grupo, de ser correcto, lo elimina
        Dim grupo As String
        grupo = sender.Tag(1)
        Dim result As Integer = MessageBox.Show("¿Está seguro de que desea eliminar el grupo '" + grupo + "'?", "Eliminar grupo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If

        Dim Logica as New Logica()
        Logica.eliminarGrupo_frmAdminGrupos(sender.Tag(0), sender.Tag(1), Me)
        Me.frmMain.recargarGrupo()
    End Sub

    Private Sub chkDiscapacitado_CheckedChanged(sender As Object, e As EventArgs) Handles chkDiscapacitado.Click
        If previsualizando Or Me.tipoUsuario.Equals("Adscripto") Then
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
