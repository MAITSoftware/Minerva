Public Class frmAdminGrupos
    ' Clase principal para la administración de grupos

    Friend CiUsuario As String
    Friend frmAdministrar As frmAdministrar
    Friend frmMain As frmMain
    Friend PrimerGrupo As String
    Friend TipoUsuario As String
    Friend TotalGrupos As Integer = 0

    Dim PrevSelect As String
    Dim PrevOrientacionSelect As String

    Dim NroGrupo As String
    Dim GrupoPreview As Control = New Button()
    Dim Editando As Boolean = False
    Dim Previsualizando As Boolean = False

    Public Sub New(ByVal frmMain As frmMain, ByVal tipousuario As String, ByVal ciUsuario As String, ByVal frmAdministrar As frmAdministrar)
        InitializeComponent()
        Me.frmMain = frmMain
        Me.TipoUsuario = tipousuario
        Me.CiUsuario = ciUsuario
        Me.frmAdministrar = frmAdministrar
    End Sub

    Private Sub frmAdminGrupos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Al cargar la ventana, cargarGrupos y rellenar los combos con los datos.

        HabilitarControles(True)

        Grupo.CargarTurnos(Me)
        Grupo.CargarCursos(Me)
        Grupo.CargarAdscriptos(Me)
        Grupo.CargarSalones(Me)

        cmbAdscripto.SelectedIndex = 0

        cmbOrientacion.Enabled = False
        cboGrado.Enabled = False
        cmbCurso.Focus()
        CargarGrupos()
    End Sub

    Public Sub AgregarWidgetGrupo(ByVal NroGrupo As String, idTexto As String, ByVal nombreTurno As String, ByVal ciAdscripto As String)
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
        AddHandler btnGrupo.Click, AddressOf ClickVerGrupo

        btnEditar.Size = btnEditarPlantilla.Size
        btnEditar.FlatStyle = btnEditarPlantilla.FlatStyle
        btnEditar.ForeColor = btnEditarPlantilla.ForeColor
        btnEditar.Text = btnEditarPlantilla.Text
        btnEditar.BackColor = btnEditarPlantilla.BackColor
        btnEditar.Location = btnEditarPlantilla.Location
        btnEditar.Cursor = btnEditarPlantilla.Cursor
        btnEditar.TabStop = False
        btnEditar.Tag = {NroGrupo, "editar"}
        AddHandler btnEditar.Click, AddressOf InterfazEditarGrupo

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

        If Me.TipoUsuario.Equals("Adscripto") Then
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

        TotalGrupos += 1
        lblCantidadGrupos.Text = "(" + TotalGrupos.ToString() + ")"
    End Sub

    Private Sub fixScroll(sender As Object, e As Object)
        pnlGrupos.Focus()
    End Sub

    Private Sub HabilitarControles(ByVal habilitado As Boolean)
        ' Habilita o deshabilita los controles
        txtIdGrupo.Enabled = habilitado
        txtIdGrupo.Text = ""

        cmbTurno.Enabled = habilitado
        cmbTurno.SelectedIndex = -1

        PrevSelect = ""
        cmbCurso.Enabled = habilitado
        cmbCurso.SelectedIndex = -1
        cmbOrientacion.Enabled = habilitado
        cmbOrientacion.SelectedIndex = -1
        cboGrado.Enabled = habilitado
        cboGrado.SelectedIndex = -1
        chkDiscapacitado.Enabled = True
        chkDiscapacitado.Checked = False

        cmbSalon.Enabled = habilitado
    End Sub

    Public Sub InterfazNuevoGrupo(Optional ByVal sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles btnNuevoGrupo.Click
        ' Prepara la interfaz para agregar un nuevo grupo
        If Me.TipoUsuario.Equals("Adscripto") Then
            InterfazPrevisualizarGrupo(NroGrupo)
            Return
        End If
        HabilitarControles(True)
        lblNuevoGrupo.Text = "Nuevo grupo"
        btnNuevoGrupo.Visible = False
        btnAgregar.Visible = True
        btnAgregar.Text = "Agregar grupo"
        cmbOrientacion.Enabled = False
        cboGrado.Enabled = False
        Editando = False
        Previsualizando = False
        chkDiscapacitado.TabStop = True
        cmbAdscripto.Enabled = True

        Grupo.CargarTurnos(Me)
        Grupo.CargarCursos(Me)
        Grupo.CargarAdscriptos(Me)
        Grupo.CargarSalones(Me)

        GrupoPreview.Enabled = True
        GrupoPreview = New Button()
        chkDistribuir.Checked = True
        chkDistribuir.Visible = True
    End Sub

    Private Sub CheckDatosCorrectos(Optional ByVal sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles btnAgregar.Click
        ' Comprueba los datos y en caso de que no falte ninguno, llama a actualizarDB()
        If Me.TipoUsuario.Equals("Adscripto") And Not Editando Then
            MessageBox.Show("Oops!" & vbCrLf & "Solo los administradores y funcionarios pueden hacer eso...", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtIdGrupo.Text) Then
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

        If String.IsNullOrWhiteSpace(cboGrado.Text) Then
            MessageBox.Show("Debe seleccionar un grado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        Grupo.ActualizarDB(Me)
    End Sub

    Private Sub ClickVerGrupo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        InterfazPrevisualizarGrupo(sender.Tag(0))

        chkDiscapacitado.TabStop = False
    End Sub

    Private Sub InterfazEditarGrupo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nroGrupo As String = sender.Tag(0)
        InterfazPrevisualizarGrupo(sender.Tag(0))

        GrupoPreview.Enabled = True
        GrupoPreview = sender.Parent
        GrupoPreview.Enabled = False

        btnNuevoGrupo.Text = "Nuevo grupo / cancelar"
        If Me.TipoUsuario.Equals("Adscripto") Then
            btnNuevoGrupo.Text = "Cancelar"
        End If
        btnNuevoGrupo.Visible = True
        btnAgregar.Text = "Guardar cambios"
        btnAgregar.Visible = True
        lblNuevoGrupo.Text = "Editar grupo"
        cmbAdscripto.Enabled = True
        Previsualizando = False
        Editando = True
        cmbSalon.Enabled = True
        If Me.TipoUsuario.Equals("Adscripto") Then
            cmbAdscripto.Enabled = False
        End If
        chkDistribuir.Checked = False
        chkDistribuir.Visible = False
    End Sub

    Private Sub InterfazPrevisualizarGrupo(ByVal nroGrupo As String)
        ' Prepara la interfaz para previsualizarUnGrupo
        Me.NroGrupo = nroGrupo
        btnNuevoGrupo.Visible = True
        btnAgregar.Visible = False
        btnNuevoGrupo.Text = "Nuevo grupo"
        lblNuevoGrupo.Text = "Previsualizar grupo"

        GrupoPreview.Enabled = True
        GrupoPreview = Nothing
        For Each pnl As Panel In pnlGrupos.Controls
            For Each x As Button In pnl.Controls
                If x.Tag(0).Equals(nroGrupo) And x.Tag(1).Equals("principal") Then
                    If IsNothing(GrupoPreview) Then
                        GrupoPreview = x
                    End If
                End If
            Next
        Next

        If Me.TipoUsuario.Equals("Adscripto") Then
            btnNuevoGrupo.Visible = False
        End If
        GrupoPreview.Enabled = False

        chkDistribuir.Checked = False
        chkDistribuir.Visible = False

        HabilitarControles(False)
        Grupo.CargarGrupo(nroGrupo, Me)
        Previsualizando = True
    End Sub

    Private Sub CursoCambiado(sender As Object, e As EventArgs) Handles cmbCurso.SelectedIndexChanged
        ' Al cambiar el id de curso, cargarOrientaciones
        If cmbCurso.Text.Equals(PrevSelect) Then
            Return
        End If
        cmbOrientacion.SelectedIndex = -1
        Grupo.CargarOrientaciones(Me)
        cmbOrientacion.Enabled = False
        If Not String.IsNullOrWhiteSpace(cmbCurso.Text) Then
            cmbOrientacion.Enabled = True
        End If
        PrevSelect = cmbCurso.Text
    End Sub

    Private Sub IgnorarEspacio(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdGrupo.KeyPress
        ' Al apretar la tecla espacio, ignorarla
        If e.KeyChar = " " Then
            e.KeyChar = Nothing
        End If
    End Sub

    Public Sub CargarGrupos()
        Grupo.CargarGrupos(Me)

        If Me.TotalGrupos = 0 And Me.TipoUsuario.Equals("Adscripto") Then
            lblNoGrupoAsignado.Visible = True
        ElseIf Me.TipoUsuario.Equals("Adscripto") Then
            InterfazPrevisualizarGrupo(PrimerGrupo)
        End If
    End Sub


    Private Sub EliminarGrupo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Le pregunta al usuario si quiere eliminar el grupo, de ser correcto, lo elimina
        Dim grupo_ As String
        grupo_ = sender.Tag(1)
        Dim result As Integer = MessageBox.Show("¿Está seguro de que desea eliminar el grupo '" + grupo_ + "'?", "Eliminar grupo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If

        Grupo.EliminarGrupo(sender.Tag(0), sender.Tag(1), Me)
        Me.frmMain.recargarGrupo()
    End Sub

    Private Sub IngnorarClick_ChkDiscapacitado(sender As Object, e As EventArgs) Handles chkDiscapacitado.Click
        If Previsualizando Or Me.TipoUsuario.Equals("Adscripto") Then
            chkDiscapacitado.Checked = Not chkDiscapacitado.Checked
        End If
    End Sub

    Private Sub OrientacionCambiada(sender As Object, e As EventArgs) Handles cmbOrientacion.SelectedIndexChanged
        If cmbOrientacion.Text.Equals(PrevOrientacionSelect) Then
            Return
        End If

        cboGrado.SelectedIndex = -1
        Grupo.CargarGrados(Me)
        cboGrado.Enabled = False
        If Not String.IsNullOrWhiteSpace(cmbOrientacion.Text) Then
            cboGrado.Enabled = True
        End If
        PrevOrientacionSelect = cmbOrientacion.Text
    End Sub

End Class
