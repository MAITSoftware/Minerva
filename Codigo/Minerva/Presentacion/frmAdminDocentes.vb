Public Class frmAdminDocentes
    ' Clase principal para la administracion de docentes

    Friend totalDocentes As Integer = 0

    Dim frmMain As frmMain
    Dim prevSelect As String
    Dim prevGrupoSelect As String
    Dim docentePreview As Object = New Button()

    Public Sub New(frmMain As frmMain)
        InitializeComponent()
        Me.frmMain = frmMain
    End Sub

    Private Sub frmAdminDocentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lstAsignaturas.FullRowSelect = True
        Docente.CargarDocentes(Me)
        Docente.CargarGrupos(Me)
        txtCI.Focus()
    End Sub

    Public Sub AgregarWidgetDocente(ciDocente As String, txtDocente As String)
        Dim pnlTemporal As New Panel
        Dim btnDocente As New Button
        Dim btnEditar, btnEliminar As New Button

        pnlTemporal.Size = pnlDocentePlantilla.Size
        btnDocente.Size = btnDocentePlantilla.Size
        btnDocente.FlatStyle = btnDocentePlantilla.FlatStyle
        btnDocente.ForeColor = btnDocentePlantilla.ForeColor
        btnDocente.Text = txtDocente
        btnDocente.BackColor = btnDocentePlantilla.BackColor
        btnDocente.Location = btnDocentePlantilla.Location
        btnDocente.Cursor = btnDocentePlantilla.Cursor
        btnDocente.Font = btnDocentePlantilla.Font
        btnDocente.TabStop = False

        btnDocente.Tag = ciDocente
        AddHandler btnDocente.Click, AddressOf InterfazVerDocente

        btnEditar.Size = btnEditarPlantilla.Size
        btnEditar.FlatStyle = btnEditarPlantilla.FlatStyle
        btnEditar.ForeColor = btnEditarPlantilla.ForeColor
        btnEditar.Text = btnEditarPlantilla.Text
        btnEditar.BackColor = btnEditarPlantilla.BackColor
        btnEditar.Location = btnEditarPlantilla.Location
        btnEditar.Cursor = btnEditarPlantilla.Cursor
        btnEditar.TabStop = False

        btnEditar.Tag = ciDocente
        AddHandler btnEditar.MouseUp, AddressOf AbrirMenuEdicionDocente

        btnEliminar.Size = btnEliminarPlantilla.Size
        btnEliminar.FlatStyle = btnEliminarPlantilla.FlatStyle
        btnEliminar.ForeColor = btnEliminarPlantilla.ForeColor
        btnEliminar.Text = btnEliminarPlantilla.Text
        btnEliminar.BackColor = btnEliminarPlantilla.BackColor
        btnEliminar.Location = btnEliminarPlantilla.Location
        btnEliminar.Cursor = btnEliminarPlantilla.Cursor
        btnEliminar.TabStop = False

        btnEliminar.Tag = {ciDocente, txtDocente.Replace(ControlChars.NewLine, " ")}
        AddHandler btnEliminar.Click, AddressOf EliminarDocente

        AddHandler pnlTemporal.MouseWheel, AddressOf fixScroll
        AddHandler pnlTemporal.MouseEnter, AddressOf fixScroll
        pnlTemporal.Controls.Add(btnDocente)
        pnlTemporal.Controls.Add(btnEditar)
        pnlTemporal.Controls.Add(btnEliminar)

        pnlDocentes.Controls.Add(pnlTemporal)

        totalDocentes += 1
        lblCantidadDocentes.Text = "(" + totalDocentes.ToString() + ")"
    End Sub

    Private Sub fixScroll(sender As Object, e As Object)
        pnlDocentes.Focus()
    End Sub

    Private Sub AbrirMenuEdicionDocente(sender As System.Object, e As MouseEventArgs) Handles btnEditarPlantilla.MouseUp
        DatosDelDocenteToolStripMenuItem.Tag = {sender.Parent, sender.Tag}
        AsignaturasDelDocenteToolStripMenuItem.Tag = {sender.Parent, sender.Tag}
        mnuEdicionDocente.Show(sender, New Point(e.X, e.Y))
    End Sub

    Private Sub CheckDatosDocente(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles btnAgregarDocente.Click
        If String.IsNullOrWhiteSpace(txtCI.Text) Then
            MessageBox.Show("Debe ingresar una CI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtNombre.Text) Then
            MessageBox.Show("Debe ingresar un nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtApellido.Text) Then
            MessageBox.Show("Debe ingresar un apellido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        Docente.ActualizarDB(Me)
        frmMain.recargarGrupo()
    End Sub

    Private Sub InterfazEditarDocente(sender As System.Object)
        docentePreview.Enabled = True
        docentePreview = sender.Tag(0)
        docentePreview.Enabled = False
        lblNuevoDocente.Text = "Editar docente"
        btnCancelarEdicion.Visible = True
        btnAgregarDocente.Visible = True
        btnAgregarAsignatura.Visible = False
        btnLimpiarAsignatura.Visible = False
        btnEliminarAsignatura.Visible = False
        btnNuevoDocente.Visible = False
        btnAgregarDocente.Text = "Guardar cambios"

        HabilitarControles(True)
        Docente.CargarInfo(sender.Tag(1), Me)
        txtCI.Enabled = False
        HabilitarControlesAsignaturas(False)
        Docente.CargarAsignaturas(sender.Tag(1), Me)
    End Sub

    Private Sub HabilitarControles(habilitado As Boolean)
        txtCI.Enabled = habilitado
        txtCI.Text = ""
        txtNombre.Enabled = habilitado
        txtNombre.Text = ""
        txtApellido.Enabled = habilitado
        txtApellido.Text = ""
        numGrado.Enabled = habilitado
        numGrado.Value = 1
    End Sub

    Private Sub HabilitarControlesAsignaturas(habilitadas As Boolean)
        lstAsignaturas.Enabled = habilitadas
        lstAsignaturas.Items.Clear()
        btnLimpiarAsignatura.Enabled = habilitadas
        btnEliminarAsignatura.Enabled = habilitadas
        cmbArea.Enabled = False
        cmbArea.SelectedIndex = -1
        cmbAsignatura.Enabled = False
        cmbAsignatura.SelectedIndex = -1
        cmbGrupo.Enabled = habilitadas
        cmbGrupo.SelectedIndex = -1
        numGradoArea.Enabled = habilitadas
        numGradoArea.Value = 1
        btnAgregarAsignatura.Enabled = habilitadas
    End Sub

    Private Sub InterfazVerDocente(sender As System.Object, e As System.EventArgs)
        docentePreview.Enabled = True
        docentePreview = sender
        docentePreview.Enabled = False
        InterfazPrevisualizarDocente(sender.Tag)

        lstAsignaturas.Enabled = True
        Docente.CargarAsignaturas(sender.Tag, Me)
    End Sub

    Public Sub InterfazPrevisualizarDocente(ci As String)
        btnNuevoDocente.Visible = True
        btnAgregarDocente.Visible = False
        btnAgregarAsignatura.Visible = False
        btnCancelarEdicion.Visible = False
        btnLimpiarAsignatura.Visible = False
        btnEliminarAsignatura.Visible = False

        lblNuevoDocente.Text = "Previsualizar docente"
        HabilitarControlesAsignaturas(False)

        HabilitarControles(False)
        Docente.CargarInfo(ci, Me)

        docentePreview.Enabled = True
        docentePreview = Nothing
        For Each pnl As Panel In pnlDocentes.Controls
            For Each x As Button In pnl.Controls
                If x.Tag.Equals(ci) Then
                    If IsNothing(docentePreview) Then
                        docentePreview = x
                    End If
                End If
            Next
        Next
        docentePreview.Enabled = False
    End Sub

    Public Sub InterfazNuevoDocente(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles btnNuevoDocente.Click, btnCancelarEdicion.Click
        HabilitarControles(True)
        lblNuevoDocente.Text = "Nuevo docente"
        btnNuevoDocente.Visible = False
        btnAgregarAsignatura.Visible = False
        btnAgregarDocente.Visible = True
        btnLimpiarAsignatura.Visible = False
        btnEliminarAsignatura.Visible = False
        btnAgregarDocente.Text = "Agregar docente " & ControlChars.NewLine & "y editar asignaturas"
        btnCancelarEdicion.Visible = False
        docentePreview.Enabled = True
        docentePreview = New Button()
        LimpiarDatosAsignatura()
        HabilitarControlesAsignaturas(False)
    End Sub

    Private Sub EditarDatosDelDocente_Click(sender As Object, e As EventArgs) Handles DatosDelDocenteToolStripMenuItem.Click
        InterfazEditarDocente(sender)
    End Sub

    Private Sub LimpiarDatosAsignatura(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles btnLimpiarAsignatura.Click
        cmbArea.SelectedIndex = -1
        cmbGrupo.SelectedIndex = -1
        numGradoArea.Value = 1
    End Sub

    Private Sub GrupoCambiado(sender As Object, e As EventArgs) Handles cmbGrupo.SelectedIndexChanged
        If cmbGrupo.Text.Equals(prevGrupoSelect) Then
            Return
        End If
        cmbArea.SelectedIndex = -1

        prevGrupoSelect = cmbGrupo.Text
        cmbArea.Enabled = False
        If Not String.IsNullOrWhiteSpace(cmbGrupo.Text) Then
            cmbArea.Enabled = True
        Else
            Return
        End If
        Docente.CargarAreas(Me)
    End Sub

    Private Sub AreaCambiada(sender As Object, e As EventArgs) Handles cmbArea.SelectedIndexChanged
        If cmbArea.Text.Equals(prevSelect) Then
            Return
        End If
        cmbAsignatura.SelectedIndex = -1

        prevSelect = cmbArea.Text
        cmbAsignatura.Enabled = False
        If Not String.IsNullOrWhiteSpace(cmbArea.Text) Then
            cmbAsignatura.Enabled = True
        Else
            Return
        End If
        Docente.CargarAsignaturasGrupo(Me)
    End Sub

    Private Sub CheckDatosAsignatura(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles btnAgregarAsignatura.Click
        If String.IsNullOrWhiteSpace(cmbArea.Text) Then
            MessageBox.Show("Debe seleccionar un área.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        If String.IsNullOrWhiteSpace(cmbAsignatura.Text) Then
            MessageBox.Show("Debe seleccionar una asignatura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        If String.IsNullOrWhiteSpace(cmbGrupo.Text) Then
            MessageBox.Show("Debe seleccionar un grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        Docente.ActualizarDB_Asignatura(Me)
        frmMain.RecargarGrupo()
    End Sub

    Private Sub EditarAsignaturasDelDocente_Click(sender As Object, e As EventArgs) Handles AsignaturasDelDocenteToolStripMenuItem.Click
        ' Deshabilita la edición de datos del docente.
        InterfazEditarAsignaturasDocente(sender.Tag(1))
        docentePreview.Enabled = True
        docentePreview = sender.Tag(0)
        docentePreview.Enabled = False
    End Sub

    Public Sub InterfazEditarAsignaturasDocente(CI As String)
        InterfazPrevisualizarDocente(CI)
        HabilitarControlesAsignaturas(True)
        btnAgregarAsignatura.Visible = True
        btnLimpiarAsignatura.Visible = True
        btnEliminarAsignatura.Visible = False
        lstAsignaturas.Enabled = True
        Docente.CargarAsignaturas(CI, Me)
        lblNuevoDocente.Text = "Editar ms del docente"
        docentePreview.Enabled = True
        docentePreview = docentePreview.Parent
        docentePreview.Enabled = False
    End Sub

    Private Sub EliminarAsignatura(sender As Object, e As EventArgs) Handles btnEliminarAsignatura.Click
        Dim result As Integer = MessageBox.Show("¿Está seguro de que desea eliminar la asignatura seleccionada?", "Eliminar asignatura", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If

        Docente.EliminarAsignatura(Me)
        frmMain.RecargarGrupo()
    End Sub

    Private Sub EliminarDocente(sender As Object, e As EventArgs)
        Dim result As Integer = MessageBox.Show("¿Está seguro de que desea eliminar el docente '" + sender.Tag(1) + "'?", "Eliminar docente", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If
        Docente.EliminarDocente(sender.Tag(0), sender.Tag(1), Me)
        frmMain.RecargarGrupo()
    End Sub

    Private Sub AsignaturaSeleccionada(sender As Object, e As EventArgs) Handles lstAsignaturas.SelectedIndexChanged
        If btnLimpiarAsignatura.Visible = False Then
            Return
        End If
        btnEliminarAsignatura.Visible = False
        If lstAsignaturas.SelectedItems.Count > 0 Then
            btnEliminarAsignatura.Visible = True
        End If
    End Sub

    Private Sub CheckNumeros(t As Object, e As KeyEventArgs) Handles txtCI.KeyDown
        If e.KeyCode.Equals(Keys.Delete) Or e.KeyCode.Equals(Keys.Back) Or e.KeyCode.Equals(Keys.Left) Or e.KeyCode.Equals(Keys.Right) Or e.KeyCode.Equals(Keys.Tab) Then
            e.Handled = False
            Return
        End If
        If Not Char.IsDigit(Chr(e.KeyValue)) Then
            e.SuppressKeyPress = True
        End If

    End Sub

    Private Sub Animacion_1_L(sender As Object, e As EventArgs) Handles btnLimpiarAsignatura.MouseLeave
        btnLimpiarAsignatura.BackgroundImage = My.Resources.agregar_normal()
        pnlAyudabtnAgregarAsignatura.Visible = False
    End Sub

    Private Sub Animacion_1_E(sender As Object, e As EventArgs) Handles btnLimpiarAsignatura.MouseEnter
        ' al entrar a el botón btnAgregarAsignatura cambiar la imagen
        btnLimpiarAsignatura.BackgroundImage = My.Resources.agregar_hover()
        pnlAyudabtnAgregarAsignatura.Visible = True
    End Sub

    Private Sub Animacion_2_L(sender As Object, e As EventArgs) Handles btnEliminarAsignatura.MouseLeave
        btnEliminarAsignatura.BackgroundImage = My.Resources.borrar_normal()
        pnlAyudabtnEliminarAsignatura.Visible = False
    End Sub

    Private Sub Animacion_2_E(sender As Object, e As EventArgs) Handles btnEliminarAsignatura.MouseEnter
        btnEliminarAsignatura.BackgroundImage = My.Resources.borrar_hover()
        pnlAyudabtnEliminarAsignatura.Visible = True
    End Sub
End Class
