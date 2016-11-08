Public Class frmAdminUsuarios
    Friend totalUsuarios As Integer = 0
    Friend tipoSeleccionado As String = "Funcionario"

    Dim previsualizando As Boolean = False
    Dim miUsuario As String = ""
    Dim frmMain As frmMain

    Public Sub New(ByVal usuario As String, ByVal frmMain As frmMain)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        Me.miUsuario = usuario
        Me.frmMain = frmMain
    End Sub

    Private Sub frmAdminUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Al iniciar el programa, cargar los usuarios, y reiniciar la interfaz
        Usuario.CargarUsuarios(Me)
        InterfazNuevoUsuario()
        txtID.Focus()
    End Sub

    Public Sub AgregarWidgetUsuario(ByVal IDUsuario As String, ByVal Tipo As String, ByVal usuarioAprobado As Boolean)
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
        btnUsuario.TabStop = False


        btnUsuario.BackgroundImage = My.Resources.usuario_no_aprobado()
        If usuarioAprobado Then
            btnUsuario.BackgroundImage = My.Resources.usuario_aprobado()
        End If

        btnUsuario.Tag = IDUsuario
        AddHandler btnUsuario.Click, AddressOf ClickVerUsuario

        btnEditar.Size = btnEditarPlantilla.Size
        btnEditar.FlatStyle = btnEditarPlantilla.FlatStyle
        btnEditar.ForeColor = btnEditarPlantilla.ForeColor
        btnEditar.Text = btnEditarPlantilla.Text
        btnEditar.BackColor = btnEditarPlantilla.BackColor
        btnEditar.Location = btnEditarPlantilla.Location
        btnEditar.Cursor = btnEditarPlantilla.Cursor
        btnEditar.TabStop = False

        btnEditar.Tag = IDUsuario
        AddHandler btnEditar.Click, AddressOf InterfazEditarUsuario

        btnEliminar.Size = btnEliminarPlantilla.Size
        btnEliminar.FlatStyle = btnEliminarPlantilla.FlatStyle
        btnEliminar.ForeColor = btnEliminarPlantilla.ForeColor
        btnEliminar.Text = btnEliminarPlantilla.Text
        btnEliminar.BackColor = btnEliminarPlantilla.BackColor
        btnEliminar.Location = btnEliminarPlantilla.Location
        btnEliminar.Cursor = btnEliminarPlantilla.Cursor
        btnEliminar.TabStop = False

        btnEliminar.Tag = {IDUsuario, btnUsuario.Text.Replace(vbCrLf, " ")}
        AddHandler btnEliminar.Click, AddressOf eliminarUsuario

        pnlTemporal.Controls.Add(btnUsuario)
        If Not IDUsuario.Equals(miUsuario) Then
            pnlTemporal.Controls.Add(btnEliminar)
        End If
        pnlTemporal.Controls.Add(btnEditar)

        AddHandler pnlTemporal.MouseEnter, AddressOf fixScroll
        AddHandler pnlTemporal.MouseWheel, AddressOf fixScroll
        pnlUsuarios.Controls.Add(pnlTemporal)
        pnlUsuarios.Focus()

        totalUsuarios += 1
        lblCantidadUsuarios.Text = "(" + totalUsuarios.ToString() + ")"
    End Sub

    Private Sub fixScroll(sender As Object, e As Object)
        pnlUsuarios.Focus()
    End Sub

    Private Sub CheckDatosCorrectos(Optional ByVal sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles btnAgregar.Click
        If String.IsNullOrWhiteSpace(txtID.Text) Then
            MessageBox.Show("Debe ingresar un ID de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        If String.IsNullOrEmpty(txtContraseña.Text) Then
            MessageBox.Show("Debe ingresar una contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        Usuario.ActualizarDB(Me)
        Usuario.ContUsuariosNoAprobados(Me.frmMain)
    End Sub

    Private Sub TipoUsuario_Cambiado(sender As Object, e As EventArgs) Handles radFuncionario.CheckedChanged, radAdministrador.CheckedChanged, radAdscripto.CheckedChanged
        If sender.Checked Then
            tipoSeleccionado = sender.Text
        End If
    End Sub

    Public Sub InterfazNuevoUsuario(Optional ByVal sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles btnNuevoUsuario.Click, btnCancelar.Click
        ' Reinicia la interfaz 
        lblNuevoUsuario.Text = "Nuevo usuario"
        btnAgregar.Text = "Agregar usuario"

        previsualizando = False
        btnAgregar.Visible = True
        btnCancelar.Visible = False
        btnNuevoUsuario.Visible = False
        txtID.Enabled = True
        txtContraseña.Enabled = True
        radFuncionario.Checked = True
        txtNombre.Enabled = True
        txtApellido.Enabled = True
        tipoSeleccionado = "Funcionario"
        RestablecerControles()
    End Sub

    Private Sub RestablecerControles()
        ' Limpia los valores de los controles
        chkHabilitado.Checked = False
        chkHabilitado.Enabled = True
        radAdministrador.Checked = False
        radFuncionario.Checked = True
        radAdscripto.Checked = False
        txtID.Text = ""
        txtContraseña.Text = ""
        txtNombre.Text = ""
        txtApellido.Text = ""
        tipoSeleccionado = "Funcionario"
        radAdministrador.Enabled = True
        radFuncionario.Enabled = True
        radAdscripto.Enabled = True
    End Sub

    Private Sub InterfazEditarUsuario(sender As Object, e As EventArgs)
        ' Prepara la interfaz para editar el usuario
        lblNuevoUsuario.Text = "Editar usuario"
        btnNuevoUsuario.Visible = False
        btnAgregar.Text = "Confirmar cambios"
        btnAgregar.Visible = True
        btnNuevoUsuario.Visible = True
        btnCancelar.Visible = True
        txtContraseña.Enabled = True
        Usuario.CargarDatos(sender.Tag, Me)
        txtID.Enabled = False
        previsualizando = False
        txtNombre.Enabled = True
        txtApellido.Enabled = True

        radAdscripto.Enabled = False
        If Not sender.Tag.Equals(miUsuario) Then
            radAdministrador.Enabled = True
            radFuncionario.Enabled = True
            chkHabilitado.Enabled = True
        Else
            radAdministrador.Enabled = False
            radFuncionario.Enabled = False
            chkHabilitado.Enabled = False
        End If

        If tipoSeleccionado.Equals("Adscripto") Then
            radAdministrador.Enabled = False
            radFuncionario.Enabled = False
            radAdscripto.Enabled = True
            radAdscripto.Checked = True
        End If
    End Sub

    Private Sub ClickVerUsuario(sender As Object, e As EventArgs)
        ' Llama a la función que permite mostrar los datos del usuario
        InterfazVerUsuario(sender.Tag)
        previsualizando = True
    End Sub

    Private Sub InterfazVerUsuario(ByVal ID As String)
        ' Muestra los datos del usuario
        RestablecerControles()
        Usuario.CargarDatos(ID, Me)
        lblNuevoUsuario.Text = "Previsualizar usuario"
        btnNuevoUsuario.Visible = True
        btnCancelar.Visible = False
        btnAgregar.Visible = False
        txtID.Enabled = False
        txtContraseña.Enabled = False
        radAdministrador.Enabled = False
        radFuncionario.Enabled = False
        radAdscripto.Enabled = False
        txtNombre.Enabled = False
        txtApellido.Enabled = False
    End Sub

    Private Sub CuentaHabilitada_Cambiado(sender As Object, e As EventArgs) Handles chkHabilitado.Click
        If previsualizando Then
            chkHabilitado.Checked = Not chkHabilitado.Checked
        End If
    End Sub

    Private Sub Check_Numero(t As Object, e As KeyEventArgs) Handles txtID.KeyDown
        ' Al escribir un caracter que no sea número lo ignora.
        If e.KeyCode.Equals(Keys.Delete) Or e.KeyCode.Equals(Keys.Back) Or e.KeyCode.Equals(Keys.Left) Or e.KeyCode.Equals(Keys.Right) Or e.KeyCode.Equals(Keys.Tab) Then
            e.Handled = False
            Return
        End If

        If Not Char.IsDigit(Chr(e.KeyValue)) Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Public Sub EliminarUsuario(sender As Object, e As EventArgs)
        ' Pregunta al usuario si quiere eliminar el usuario y de ser correcto lo elimina
        Dim result As Integer = MessageBox.Show("¿Está seguro de que desea eliminar el usuario '" + sender.Tag(1) + "'?", "Eliminar usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If

        Usuario.EliminarUsuario(sender.Tag(0), Me)
        Usuario.ContUsuariosNoAprobados(Me.frmMain)
    End Sub
End Class
