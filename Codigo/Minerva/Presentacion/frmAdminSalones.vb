Public Class frmAdminSalones
    Friend PrimerSalon As String
    Friend TotalSalones As Integer = 0

    Dim TipoUsuario As String
    Dim Editando As Boolean = False
    Dim SalonPreview As Object = New Button()

    Public Sub New(ByVal tipousuario As String)
        InitializeComponent()

        Me.TipoUsuario = tipousuario
    End Sub

    Private Sub frmAdminSalones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HabilitarControles(True)
        txtIdSalon.Focus()
        CargarSalones()
    End Sub

    Public Sub AgregarWidgetSalon(ByVal idSalon As String)
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
        btnSalon.TabStop = False

        btnSalon.Tag = idSalon
        AddHandler btnSalon.Click, AddressOf ClickVerSalon

        btnEditar.Size = btnEditarPlantilla.Size
        btnEditar.FlatStyle = btnEditarPlantilla.FlatStyle
        btnEditar.ForeColor = btnEditarPlantilla.ForeColor
        btnEditar.Text = btnEditarPlantilla.Text
        btnEditar.BackColor = btnEditarPlantilla.BackColor
        btnEditar.Location = btnEditarPlantilla.Location
        btnEditar.Cursor = btnEditarPlantilla.Cursor
        btnEditar.TabStop = False

        btnEditar.Tag = idSalon
        AddHandler btnEditar.Click, AddressOf InterfazEditarSalon

        btnEliminar.Size = btnEliminarPlantilla.Size
        btnEliminar.FlatStyle = btnEliminarPlantilla.FlatStyle
        btnEliminar.ForeColor = btnEliminarPlantilla.ForeColor
        btnEliminar.Text = btnEliminarPlantilla.Text
        btnEliminar.BackColor = btnEliminarPlantilla.BackColor
        btnEliminar.Location = btnEliminarPlantilla.Location
        btnEliminar.Cursor = btnEliminarPlantilla.Cursor
        btnEliminar.TabStop = False

        btnEliminar.Tag = idSalon
        If Me.TipoUsuario.Equals("Adscripto") Then
            btnEliminar.Visible = False
            btnEditar.Visible = False
            btnSalon.Width = btnSalon.Width + btnEliminar.Width
        End If
        AddHandler btnEliminar.Click, AddressOf EliminarSalon

        pnlTemporal.Controls.Add(btnEditar)
        pnlTemporal.Controls.Add(btnEliminar)
        pnlTemporal.Controls.Add(btnSalon)

        AddHandler pnlTemporal.MouseEnter, AddressOf fixScroll
        AddHandler pnlTemporal.MouseWheel, AddressOf fixScroll
        pnlSalones.Controls.Add(pnlTemporal)

        TotalSalones += 1
        lblCantidadSalones.Text = "(" + TotalSalones.ToString() + ")"
    End Sub

    Private Sub fixScroll(sender As Object, e As Object)
        pnlSalones.Focus()
    End Sub

    Private Sub InterfazEditarSalon(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SalonPreview.Enabled = True
        SalonPreview = sender.Parent
        SalonPreview.Enabled = False

        lblNuevoSalon.Text = "Editar salón"
        btnAgregar.Text = "Guardar cambios"

        btnCancelarEdicion.Visible = True
        btnAgregar.Visible = True
        btnNuevoSalon.Visible = False

        HabilitarControles(True)

        txtIdSalon.Enabled = False
        cmbPlanta.Enabled = False
        Editando = True
        pnlAsignado.Visible = False

        Salon.CargarSalon(sender.Tag, Me)
    End Sub

    Public Sub InterfazPrevisualizarSalon(ByVal IdSalon As String)
        btnNuevoSalon.Visible = True
        btnAgregar.Visible = False
        btnCancelarEdicion.Visible = False

        SalonPreview.Enabled = True
        SalonPreview = Nothing
        For Each pnl As Panel In pnlSalones.Controls
            For Each x As Button In pnl.Controls
                If x.Text.Equals(IdSalon) Then
                    If IsNothing(SalonPreview) Then
                        SalonPreview = x
                    End If
                End If
            Next
        Next

        SalonPreview.Enabled = False

        lblNuevoSalon.Text = "Previsualizar salón"
        pnlAsignado.Visible = True

        HabilitarControles(False)
        Salon.CargarSalon(IdSalon, Me)
        If Me.TipoUsuario.Equals("Adscripto") Then
            btnNuevoSalon.Visible = False
        End If
    End Sub

    Private Sub HabilitarControles(ByVal habilitado As Boolean)
        txtIdSalon.Enabled = habilitado
        txtIdSalon.Text = ""
        cmbPlanta.Enabled = habilitado
        cmbPlanta.SelectedIndex = -1
        lblSalonMatutino.Text = "Sin asignar"
        lblSalonNocturno.Text = "Sin asignar"
        lblSalonVespertino.Text = "Sin asignar"
        txtComentarios.Enabled = habilitado
        txtComentarios.Text = ""
    End Sub

    Public Sub IntefazNuevoSalon(Optional ByVal sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles btnNuevoSalon.Click, btnCancelarEdicion.Click
        HabilitarControles(True)

        btnNuevoSalon.Visible = False
        btnAgregar.Visible = True
        btnCancelarEdicion.Visible = False
        pnlAsignado.Visible = False

        lblNuevoSalon.Text = "Nuevo salón"
        btnAgregar.Text = "Agregar salón"

        SalonPreview.Enabled = True
        SalonPreview = New Button()
        Editando = False
    End Sub

    Private Sub CheckNumeros(t As Object, e As KeyEventArgs) Handles txtIdSalon.KeyDown
        If e.KeyCode.Equals(Keys.Delete) Or e.KeyCode.Equals(Keys.Back) Or e.KeyCode.Equals(Keys.Left) Or e.KeyCode.Equals(Keys.Right) Or e.KeyCode.Equals(Keys.Tab) Then
            e.Handled = False
            Return
        End If
        If Not Char.IsDigit(Chr(e.KeyValue)) Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub ClickVerSalon(ByVal sender As System.Object, ByVal e As System.EventArgs)
        InterfazPrevisualizarSalon(sender.Tag)
    End Sub

    ' Comunicación con lógica y persistencia
    Private Sub CheckDatosCorrectos(Optional ByVal sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles btnAgregar.Click
        If Me.TipoUsuario.Equals("Adscripto") And Not Editando Then
            MessageBox.Show("Oops!" & vbCrLf & "Solo los administradores y funcionarios pueden hacer eso...", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtIdSalon.Text) Then
            MessageBox.Show("Debe ingresar un ID de salón.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrWhiteSpace(cmbPlanta.Text) Then
            MessageBox.Show("Debe ingresar la planta del salón.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        Salon.ActualizarDB(Me)
    End Sub

    Public Sub CargarSalones()
        Salon.CargarSalones(Me)

        If Me.TotalSalones = 0 And Me.TipoUsuario.Equals("Adscripto") Then
            lblAunNoHaySalones.Visible = True
        ElseIf Me.TipoUsuario.Equals("Adscripto") Then
            InterfazPrevisualizarSalon(PrimerSalon)
        End If
    End Sub

    Private Sub EliminarSalon(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim result As Integer = MessageBox.Show("¿Está seguro de que desea eliminar el salón '" + sender.Tag + "'?", "Eliminar salón", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If
        Salon.EliminarSalon(sender.Tag, Me)
    End Sub
End Class
