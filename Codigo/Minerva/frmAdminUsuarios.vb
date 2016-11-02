Public Class frmAdminUsuarios
    ' Clase principal para la administracion de usuarios

    Friend totalUsuarios As Integer = 0
    Friend tipoSeleccionado As String = "Funcionario"
    Friend previsualizando As Boolean = False
    Dim miUsuario As String = "asd"

    Public Sub New(ByVal usuario As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        Me.miUsuario = usuario
    End Sub
    Private Sub frmAdminUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Al iniciar el programa, cargar los usuarios, y reiniciar la interfaz
        cargarUsuarios()
        nuevoUsuario(Nothing, Nothing)
        txtID.Focus()
    End Sub

    Public Sub agregarUsuario(ByVal IDUsuario As String, ByVal Tipo As String)
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

        btnUsuario.Tag = IDUsuario
        AddHandler btnUsuario.Click, AddressOf verUsuario_Click

        btnEditar.Size = btnEditarPlantilla.Size
        btnEditar.FlatStyle = btnEditarPlantilla.FlatStyle
        btnEditar.ForeColor = btnEditarPlantilla.ForeColor
        btnEditar.Text = btnEditarPlantilla.Text
        btnEditar.BackColor = btnEditarPlantilla.BackColor
        btnEditar.Location = btnEditarPlantilla.Location
        btnEditar.Cursor = btnEditarPlantilla.Cursor
        btnEditar.TabStop = False

        btnEditar.Tag = IDUsuario
        AddHandler btnEditar.Click, AddressOf editarUsuario

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

        pnlUsuarios.Controls.Add(pnlTemporal)
        pnlUsuarios.Focus()

        totalUsuarios += 1
        lblCantidadUsuarios.Text = "(" + totalUsuarios.ToString() + ")"
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        ' Llama a checkDatos() al clickear en el botón agregar usuario
        checkDatos()
    End Sub

    Private Sub checkDatos()
        ' Comprueba que haya datos en los campos y llama a actualizarDB()
        If String.IsNullOrWhiteSpace(txtID.Text) Then
            MessageBox.Show("Debe ingresar un ID de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        If String.IsNullOrEmpty(txtContraseña.Text) Then
            MessageBox.Show("Debe ingresar una contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        actualizarDB()
    End Sub

    Private Sub rad_CheckedChanged(sender As Object, e As EventArgs) Handles radFuncionario.CheckedChanged, radAdministrador.CheckedChanged, radAdscripto.CheckedChanged
        If sender.Checked Then
            tipoSeleccionado = sender.Text
        End If
    End Sub

    Public Sub nuevoUsuario(sender As Object, e As EventArgs) Handles btnNuevoUsuario.Click, btnCancelar.Click
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
        limpiarControles()
    End Sub

    Private Sub limpiarControles()
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

    Private Sub editarUsuario(sender As Object, e As EventArgs)
        ' Prepara la interfaz para editar el usuario
        lblNuevoUsuario.Text = "Editar usuario"
        btnNuevoUsuario.Visible = False
        btnAgregar.Text = "Confirmar cambios"
        btnAgregar.Visible = True
        btnNuevoUsuario.Visible = True
        btnCancelar.Visible = True
        txtContraseña.Enabled = True
        cargarDatos(sender.Tag)
        txtID.Enabled = False
        previsualizando = False
        txtNombre.Enabled = True
        txtApellido.Enabled = True

        If Not sender.Tag.Equals(miUsuario) Then
            radAdministrador.Enabled = True
            radFuncionario.Enabled = True
            radAdscripto.Enabled = True
            chkHabilitado.Enabled = True
        Else
            radAdministrador.Enabled = False
            radFuncionario.Enabled = False
            radAdscripto.Enabled = False
            chkHabilitado.Enabled = False
        End If
        If tipoSeleccionado.Equals("Adscripto") Then
            radAdministrador.Enabled = False
            radFuncionario.Enabled = False
            radAdscripto.Checked = True
        End If
    End Sub

    Private Sub verUsuario_Click(sender As Object, e As EventArgs)
        ' Llama a la función que permite mostrar los datos del usuario
        verUsuario(sender.Tag)
        previsualizando = True
    End Sub

    Private Sub verUsuario(ByVal ID As String)
        ' Muestra los datos del usuario
        limpiarControles()
        cargarDatos(ID)
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

    Private Sub chkHabilitado_CheckedChanged(sender As Object, e As EventArgs) Handles chkHabilitado.Click
        If previsualizando Then
            chkHabilitado.Checked = Not chkHabilitado.Checked
        End If
    End Sub

    Private Sub txtID_TextChanged(t As Object, e As KeyPressEventArgs) Handles txtID.KeyPress, txtID.TextChanged
        ' Al escribir un caracter que no sea número lo ignora.
        If Not Char.IsNumber(e.KeyChar) AndAlso Not e.KeyChar = ChrW(Keys.Return) AndAlso Not e.KeyChar = ChrW(Keys.Tab) Then
            e.KeyChar = ""
        End If
    End Sub

    ' Persistencia

    Public Sub cargarUsuarios()
        Dim DB As New BaseDeDatos()
        DB.cargarUsuarios_frmAdminUsuarios(Me)

    End Sub

    Public Sub eliminarUsuario(sender As Object, e As EventArgs)
        ' Pregunta al usuario si quiere eliminar el usuario y de ser correcto lo elimina
        Dim result As Integer = MessageBox.Show("¿Está seguro de que desea eliminar el usuario '" + sender.Tag(1) + "'?", "Eliminar usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If

        Dim DB As New BaseDeDatos()
        DB.eliminarUsuario_frmAdminUsuarios(sender, Me)
    End Sub

    Public Sub cargarDatos(ByVal ID As String)
        ' Carga los datos del usuario y los muestra en pantalla
        Dim DB As New BaseDeDatos()
        DB.cargarDatos_frmAdminUsuarios(ID, Me)
    End Sub

    Public Sub actualizarDB()
        Dim DB As New BaseDeDatos()
        DB.actualizarDB_frmAdminUsuarios(Me)
    End Sub
End Class
