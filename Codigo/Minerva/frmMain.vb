Public Class frmMain

    Dim cuentaInvitado As Boolean = True
    Dim estadoAnimacion As Boolean = False
    Friend nombreUsuario As String
    Friend Administrador As Boolean = False

    Public Sub New(Optional ByVal invitado As Boolean = False, Optional ByVal usuario As String = Nothing, Optional ByVal admin As Boolean = False)
        'inicia el programa, en caso de que sea invitado lo detecta
        InitializeComponent()
        Me.cuentaInvitado = invitado
        Me.Administrador = admin
        Me.nombreUsuario = usuario
        cboGrupo.SelectedIndex = 0
        cargarDatos()

        Call New ToolTip().SetToolTip(btnRecargar, "Recarga la lista de grupos")
        Call New ToolTip().SetToolTip(btnRefrescarHorarios, "Actualiza la lista de horarios")
        timerbtnrefrescar.Enabled = True
    End Sub

    Private Sub btnAdministrar_showMenu(sender As Object, e As EventArgs) Handles btnAdministrar.Click
        ' Abre la ventana de administracion al clickear
        Dim administracion As New frmAdministrar(Administrador, Me)
        administracion.ShowDialog(Me)
    End Sub

    Private Sub cboGrupo_Changed(sender As Object, e As EventArgs) Handles cboGrupo.SelectedIndexChanged
        btnRefrescarHorarios.Enabled = False
        btnRecargar.Enabled = False

        ' Actualiza la información e horarios del grupo tras la selección de grupos
        If cboGrupo.Text.Equals("Elija un grupo") Then
            lblSeleccioneGrupo.Visible = True
            lblSeleccioneGrupo.BringToFront()
            lblSeleccioneGrupo2.Visible = True
            lblSeleccioneGrupo2.BringToFront()
            timerbtnrefrescar.Enabled = True
            Return
        End If

        lblNomGrupo.Text = cboGrupo.Text.Trim()
        lblSeleccioneGrupo.Visible = cboGrupo.SelectedIndex = -1
        lblSeleccioneGrupo2.Visible = cboGrupo.SelectedIndex = -1

        Lunes.limpiar()
        Martes.limpiar()
        Miércoles.limpiar()
        Jueves.limpiar()
        Viernes.limpiar()
        Sábado.limpiar()

        timerbtnrefrescar.Enabled = True
        Dim DB As New BaseDeDatos()
        DB.cargarMateriasGrupo_frmMain(Me)
        DB.cargarDatosGrupo_frmMain(Me)
        imgLogo.Focus()
    End Sub

    Private Sub Minerva_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' al cerrar la ventana termianr programa
        frmIngresarRegistro.Dispose()
    End Sub

    Private Sub Minerva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Al iniciar programa inicia oculta el boton de administracion en caso de que sea invitado
        If Not cuentaInvitado Then
            btnAdministrar.Visible = True
            imgLogo.Location = New Point(12, 15)
            imgLogo.Size = New Size(176, 78)
            lblUsuario.Text = "Bienvenido usuario."
            timerDatosUsuario.Start()
            timerDatosUsuario.Enabled = True
        End If
    End Sub


    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        ' Al clickear salir, nos desloguea y muestra la ventana de inicio
        frmIngresarRegistro.Show()
        Me.Dispose()
    End Sub

    ' Persistencia
    Private Sub cargarDatos()
        Dim DB As New BaseDeDatos()
        DB.cargarDatos_frmMain(Me)
    End Sub

    Private Sub timerDatosUsuario_Tick(sender As Object, e As EventArgs) Handles timerDatosUsuario.Tick
        timerDatosUsuario.Enabled = False
        timerDatosUsuario.Stop()
        cargarNombre()
    End Sub

    Private Sub cargarNombre()
        Dim DB As New BaseDeDatos()
        DB.cargarNombre_frmMain(Me)
    End Sub

    Private Sub btnRecargar_Leave(sender As Object, e As EventArgs) Handles btnRecargar.MouseLeave, btnRefrescarHorarios.MouseLeave
        ' al dejar el botón btnEliminarAsignatura cambiar la imagen
        sender.BackgroundImage = My.Resources.refrescar_normal()
    End Sub

    Private Sub btnRecargar_Enter(sender As Object, e As EventArgs) Handles btnRecargar.MouseEnter, btnRefrescarHorarios.MouseEnter
        ' al entrar a el botón btnAgregarAsignatura cambiar la imagen
        sender.BackgroundImage = My.Resources.refrescar_hover()
    End Sub


    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        cargarDatos()
    End Sub

    Private Sub btnRefrescarHorarios_Click(sender As Object, e As EventArgs) Handles btnRefrescarHorarios.Click
        Dim currentIndex As Object
        currentIndex = cboGrupo.SelectedIndex
        cboGrupo.SelectedIndex = 0
        cboGrupo.SelectedIndex = currentIndex
    End Sub

    Private Sub timerbtnrefrescar_Tick(sender As Object, e As EventArgs) Handles timerbtnrefrescar.Tick
        btnRefrescarHorarios.Enabled = True
        btnRecargar.Enabled = True
        timerbtnrefrescar.Enabled = False
    End Sub

    Public Sub recargarGrupo()
        Dim grupo As String
        grupo = cboGrupo.Text
        cboGrupo.SelectedIndex = 0
        cboGrupo.SelectedIndex = cboGrupo.FindStringExact(grupo)
    End Sub
End Class
