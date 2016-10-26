Public Class frmAdminDocentes
    ' Clase principal para la administracion de docentes

    Friend totalDocentes As Integer = 0
    Friend docentePreview As Object = New Button()
    Friend prevSelect As String
    Friend prevGrupoSelect As String

    Private Sub frmAdminDocentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Al cargar la ventana, cargar la lista de docentes, y rellenar los combos con los datos adecuados
        lstAsignaturas.FullRowSelect = True
        cargarDocentes()
        rellenarCombos()
        txtCI.Focus()
    End Sub

    Public Sub agregarDocente(ByVal ciDocente As String, ByVal txtDocente As String)
        ' Basicamente copio la plantilla a un nuevo panel
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
        AddHandler btnDocente.Click, AddressOf verDocente

        btnEditar.Size = btnEditarPlantilla.Size
        btnEditar.FlatStyle = btnEditarPlantilla.FlatStyle
        btnEditar.ForeColor = btnEditarPlantilla.ForeColor
        btnEditar.Text = btnEditarPlantilla.Text
        btnEditar.BackColor = btnEditarPlantilla.BackColor
        btnEditar.Location = btnEditarPlantilla.Location
        btnEditar.Cursor = btnEditarPlantilla.Cursor
        btnEditar.TabStop = False

        btnEditar.Tag = ciDocente
        AddHandler btnEditar.MouseUp, AddressOf mnuEditarDocente

        btnEliminar.Size = btnEliminarPlantilla.Size
        btnEliminar.FlatStyle = btnEliminarPlantilla.FlatStyle
        btnEliminar.ForeColor = btnEliminarPlantilla.ForeColor
        btnEliminar.Text = btnEliminarPlantilla.Text
        btnEliminar.BackColor = btnEliminarPlantilla.BackColor
        btnEliminar.Location = btnEliminarPlantilla.Location
        btnEliminar.Cursor = btnEliminarPlantilla.Cursor
        btnEliminar.TabStop = False

        btnEliminar.Tag = {ciDocente, txtDocente.Replace(ControlChars.NewLine, " ")}
        AddHandler btnEliminar.Click, AddressOf eliminarDocente

        pnlTemporal.Controls.Add(btnEditar)
        pnlTemporal.Controls.Add(btnEliminar)
        pnlTemporal.Controls.Add(btnDocente)

        pnlDocentes.Controls.Add(pnlTemporal)

        totalDocentes += 1
        lblCantidadDocentes.Text = "(" + totalDocentes.ToString() + ")"
    End Sub

    Public Sub mnuEditarDocente(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles btnEditarPlantilla.MouseUp
        ' Al clickear el botón editarDocente mostrar un menú
        DatosDelDocenteToolStripMenuItem.Tag = {sender.Parent, sender.Tag}
        MateriasDelDocenteToolStripMenuItem.Tag = {sender.Parent, sender.Tag}
        mnuEdicionDocente.Show(sender, New Point(e.X, e.Y))
    End Sub

    Private Sub btnAgregarDocentes_Click(sender As Object, e As EventArgs) Handles btnAgregarDocente.Click
        ' Al clickear el botón de agregarDocentes llamar checkDatos()
        checkDatos()
    End Sub

    Private Sub checkDatos()
        ' Comprueba que haya datos en todos los campos, y llama a actualizarDB()
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

        actualizarDB()
    End Sub

    Private Sub editarDocente(ByVal sender As System.Object)
        ' Al clickear editarDocente preparar la interfaz para editarlo
        docentePreview.Enabled = True
        docentePreview = sender.Tag(0)
        docentePreview.Enabled = False
        lblNuevoDocente.Text = "Editar docente"
        btnCancelarEdicion.Visible = True
        btnAgregarDocente.Visible = True
        btnAgregarMateria.Visible = False
        btnAgregarAsignatura.Visible = False
        btnEliminarAsignatura.Visible = False
        btnNuevoDocente.Visible = False
        btnAgregarDocente.Text = "Guardar cambios"

        controlesHabilitados(True)
        cargarDatos(sender.Tag(1))
        txtCI.Enabled = False
        habilitarAsignaturas(False)
    End Sub

    Private Sub controlesHabilitados(ByVal habilitado As Boolean)
        ' Habilita o deshabilita los controles del docente en base a el argumento habilitado.
        txtCI.Enabled = habilitado
        txtCI.Text = ""
        txtNombre.Enabled = habilitado
        txtNombre.Text = ""
        txtApellido.Enabled = habilitado
        txtApellido.Text = ""
        numGrado.Enabled = habilitado
        numGrado.Value = 1
    End Sub

    Private Sub habilitarAsignaturas(ByVal habilitadas As Boolean)
        ' Habilita o deshabilita los controles de las asignaturas en base a el argumento habilitado.
        lstAsignaturas.Enabled = habilitadas
        lstAsignaturas.Items.Clear()
        btnAgregarAsignatura.Enabled = habilitadas
        btnEliminarAsignatura.Enabled = habilitadas
        cmbArea.Enabled = False
        cmbArea.SelectedIndex = -1
        cmbAsignatura.Enabled = False
        cmbAsignatura.SelectedIndex = -1
        cmbGrupo.Enabled = habilitadas
        cmbGrupo.SelectedIndex = -1
        numGradoArea.Enabled = habilitadas
        numGradoArea.Value = 1
        btnAgregarMateria.Enabled = habilitadas
    End Sub

    Public Sub verDocente(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDocentePlantilla.Click
        ' Carga y muestra los datos del docente (y materias) llamando a previsualizarDocente()
        docentePreview.Enabled = True
        docentePreview = sender
        docentePreview.Enabled = False
        previsualizarDocente(sender.Tag)
        cargarMaterias(sender.Tag)
    End Sub

    Public Sub previsualizarDocente(ByVal ci As String)
        ' muestra los datos del docente y los muestra
        btnNuevoDocente.Visible = True
        btnAgregarDocente.Visible = False
        btnAgregarMateria.Visible = False
        btnCancelarEdicion.Visible = False
        btnAgregarAsignatura.Visible = False
        btnEliminarAsignatura.Visible = False

        lblNuevoDocente.Text = "Previsualizar docente"
        habilitarAsignaturas(False)

        controlesHabilitados(False)
        cargarDatos(ci)
    End Sub

    Public Sub btnNuevoDocente_Click(sender As Object, e As EventArgs) Handles btnNuevoDocente.Click, btnCancelarEdicion.Click
        ' al clickear en nuevo docente, reestablece la interfaz
        controlesHabilitados(True)
        lblNuevoDocente.Text = "Nuevo docente"
        btnNuevoDocente.Visible = False
        btnAgregarMateria.Visible = False
        btnAgregarDocente.Visible = True
        btnAgregarAsignatura.Visible = False
        btnEliminarAsignatura.Visible = False
        btnAgregarDocente.Text = "Agregar docente " & ControlChars.NewLine & "y editar materias"
        btnCancelarEdicion.Visible = False
        docentePreview.Enabled = True
        docentePreview = New Button()
        btnAgregarAsignatura_Click(Nothing, Nothing)
        habilitarAsignaturas(False)

        Call New ToolTip().SetToolTip(btnAgregarAsignatura, "Limpia los campos de texto")
        Call New ToolTip().SetToolTip(btnEliminarAsignatura, "Elimina la asignatura seleccionada")
    End Sub

    Private Sub btnAgregarAsignatura_Leave(sender As Object, e As EventArgs) Handles btnAgregarAsignatura.MouseLeave
        ' al dejar el botón btnAgregarAsignatura cambiar la imagen
        btnAgregarAsignatura.BackgroundImage = My.Resources.agregar_normal()
    End Sub

    Private Sub btnAgregarAsignatura_Enter(sender As Object, e As EventArgs) Handles btnAgregarAsignatura.MouseEnter
        ' al entrar a el botón btnAgregarAsignatura cambiar la imagen
        btnAgregarAsignatura.BackgroundImage = My.Resources.agregar_hover()
    End Sub

    Private Sub btnEliminarAsignatura_Leave(sender As Object, e As EventArgs) Handles btnEliminarAsignatura.MouseLeave
        ' al dejar el botón btnEliminarAsignatura cambiar la imagen
        btnEliminarAsignatura.BackgroundImage = My.Resources.borrar_normal()
    End Sub

    Private Sub btnEliminarAsignatura_Enter(sender As Object, e As EventArgs) Handles btnEliminarAsignatura.MouseEnter
        ' al entrar a el botón btnAgregarAsignatura cambiar la imagen
        btnEliminarAsignatura.BackgroundImage = My.Resources.borrar_hover()
    End Sub

    Private Sub DatosDelDocenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatosDelDocenteToolStripMenuItem.Click
        ' Al clickear la opción "Datos del docente" en el menu, llamar a editarDocente
        editarDocente(sender)
    End Sub

    Public Sub btnAgregarAsignatura_Click(sender As Object, e As EventArgs) Handles btnAgregarAsignatura.Click
        ' Al clickear btnAgregarAsignatura reestablecer la zona de materias
        cmbArea.SelectedIndex = -1
        cmbGrupo.SelectedIndex = -1
        numGradoArea.Value = 1
    End Sub

    Private Sub cmbGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGrupo.SelectedIndexChanged
        ' Al cambiar el id del area cargas las ASignaturas de la misma
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
        cargarAreas()
    End Sub

    Private Sub cmbArea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbArea.SelectedIndexChanged
        ' Al cambiar el id del area cargas las ASignaturas de la misma
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
        cargarAsignaturas()
    End Sub

    Private Sub checkDatosMaterias()
        ' Comprueba que hay datos en los campos requeridos para agregar una materia, y actualiza la db
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

        actualizarDBMaterias()
    End Sub

    Private Sub btnAgregarMateria_Click(sender As Object, e As EventArgs) Handles btnAgregarMateria.Click
        ' Al clickear en agregarMateria llamar a checkDatosMaterias()
        checkDatosMaterias()
    End Sub

    Private Sub MateriasDelDocenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MateriasDelDocenteToolStripMenuItem.Click
        ' Deshabilita la edición de datos del docente.
        editarMateriasDocente(sender.Tag(1))
        docentePreview.Enabled = True
        docentePreview = sender.Tag(0)
        docentePreview.Enabled = False
    End Sub

    Public Sub editarMateriasDocente(ByVal CI As String)
        ' Al clickear en editarmateriasDocentes preparar la interfaz
        previsualizarDocente(CI)
        habilitarAsignaturas(True)
        btnAgregarMateria.Visible = True
        btnAgregarAsignatura.Visible = True
        btnEliminarAsignatura.Visible = False
        cargarMaterias(CI)
        lblNuevoDocente.Text = "Editar materias del docente"
    End Sub

    Private Sub lstAsignaturas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAsignaturas.SelectedIndexChanged
        ' Al cambiar la seleccion en la lista de asignaturas, habilita o deshabilita el botón eliminarAsignatura
        If btnAgregarAsignatura.Visible = False Then
            Return
        End If
        btnEliminarAsignatura.Visible = False
        If lstAsignaturas.SelectedItems.Count > 0 Then
            btnEliminarAsignatura.Visible = True
        End If
    End Sub

    Private Sub txtCI_TextChanged(t As Object, e As KeyPressEventArgs) Handles txtCI.KeyPress
        ' Al escribir un caracter que no sea número lo ignora.
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = ""
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
        End If
    End Sub

    ' Persistencia
    Public Sub cargarAreas()
        Dim Db As New BaseDeDatos()
        Db.cargarAreas_frmAdminDocentes(Me)
    End Sub

    Public Sub rellenarCombos()
        Dim DB As New BaseDeDatos()
        DB.rellenarCombos_frmAdminDocentes(Me)
    End Sub

    Public Sub cargarDocentes()
        Dim DB As New BaseDeDatos()
        DB.cargarDocentes_frmAdminDocentes(Me)
    End Sub

    Public Sub actualizarDB()
        Dim DB As New BaseDeDatos()
        DB.actualizarDB_frmAdminDocentes(Me)
    End Sub

    Public Sub cargarDatos(ByVal ciDocente As String)
        Dim DB As New BaseDeDatos()
        DB.cargarDatos_frmAdminDocentes(ciDocente, Me)
    End Sub

    Public Sub eliminarAsignatura(sender As Object, e As EventArgs) Handles btnEliminarAsignatura.Click
        ' Pregunta al usuario si quiere eliminar la asignatura, y de ser correcto la elimina
        Dim result As Integer = MessageBox.Show("¿Está seguro de que desea eliminar la asignatura seleccionada?", "Eliminar asignatura", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If

        Dim DB As New BaseDeDatos()
        DB.eliminarAsignatura_frmAdminDocentes(sender, Me)
    End Sub

    Public Sub eliminarDocente(sender As Object, e As EventArgs)
        ' Pregunta al usuario si quiere eliminar al profesor, y de ser correcto lo elimina
        Dim result As Integer = MessageBox.Show("¿Está seguro de que desea eliminar el docente '" + sender.Tag(1) + "'?", "Eliminar docente", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If
        Dim DB As New BaseDeDatos()
        DB.eliminarDocente_frmAdminDocentes(sender, Me)
    End Sub

    Public Sub cargarMaterias(ByVal CI As String)
        Dim DB As New BaseDeDatos()
        lstAsignaturas.Enabled = True
        DB.cargarMaterias_frmAdminDocentes(CI, Me)
    End Sub

    Public Sub actualizarDBMaterias()
        ' Se encarga de manejar la DB (parte asignaturas del docente), agrega o edita asignaturas.
        Dim DB As New BaseDeDatos()
        DB.actualizarDBMaterias_frmAdminDocentes(Me)
    End Sub

    Public Sub cargarAsignaturas()
        ' Carga las asignaturas al combo
        Dim DB As New BaseDeDatos()
        DB.cargarAsignaturas_frmAdminDocentes(Me)
    End Sub

End Class