Public Class frmAdminSalones
    ' Clase principal de administración de salones

    Friend totalSalones As Integer = 0
    Dim salonPreview As Object = New Button()

    Private Sub frmAdminSalones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Al cargar la ventana cargarSalones y Grupos, y habilitar los controles.
        cargarSalones()
        cargarGrupos()

        controlesHabilitados(True)
    End Sub

    Public Sub agregarSalon(ByVal idSalon As String)
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
        ' Prepara la interfaz para editar el salón
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
        ' Llama a verSalon cuando un botón es clickeado
        previsualizarSalon(sender.Tag)
    End Sub

    Public Sub previsualizarSalon(ByVal salon As String)
        ' Prepara la interfaz para previsualizar un salón
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

    Private Sub controlesHabilitados(ByVal habilitado As Boolean)
        ' Habilita o deshabilita los controles 
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

    Public Sub btnNuevoSalon_Click(sender As Object, e As EventArgs) Handles btnNuevoSalon.Click, btnCancelarEdicion.Click
        ' Prepara la interfaz para agregar un salón al clickear btnNuevoSalon o btnCancelarEdicion
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
        ' Al clickear el btnAgregar llamar a checkDatos()
        checkDatos()
    End Sub

    Private Sub txtIDSalon_TextChanged(t As Object, e As KeyPressEventArgs) Handles txtIDSalon.KeyPress
        ' Al escribir un caracter que no sea número lo ignora.
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = ""
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
        End If
    End Sub

    ' Persistencia
    Private Sub checkDatos()
        ' Comprueba que esten todos los datos, y luego llama a acutalizarDB()
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

    Public Sub cargarSalones()
        Dim DB As New DBB()
        DB.cargarSalones_frmAdminSalones(Me)
    End Sub

    Public Sub guardarSalones()
        Dim DB As New DBB()
        DB.guardarSalones_frmAdminSalones(Me)
    End Sub

    Public Sub cargarGrupos()
        Dim DB As New DBB()
        DB.cargarGrupos_frmAdminSalones(Me)
    End Sub

    Public Sub actualizarDB()
        Dim DB As New DBB()
        DB.actualizarDB_frmAdminSalones(Me)
    End Sub

    Public Sub cargarDatos(ByVal idSalon As String)
        ' Carga los datos de un salón
        Dim DB As New DBB()
        DB.cargarDatos_frmAdminSalones(idSalon, Me)
    End Sub

    Private Sub eliminarSalon(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Pregunta al usuario si quiere eliminar el salón, y de ser correcto lo elimina
        Dim result As Integer = MessageBox.Show("¿Está seguro de que desea eliminar el salón '" + sender.Tag + "'?", "Eliminar salón", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If
        Dim DB As New DBB()
        DB.eliminarSalon_frmAdminSalones(sender, Me)
    End Sub
End Class
