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
    End Sub

    Private Sub btnAdministrar_showMenu(sender As Object, e As EventArgs) Handles btnAdministrar.Click
        ' Abre la ventana de administracion al clickear
        Dim administracion As New frmAdministrar(Administrador, Me)
        administracion.ShowDialog(Me)
    End Sub

    Private Sub cboGrupo_Changed(sender As Object, e As EventArgs) Handles cboGrupo.SelectedIndexChanged
        ' Actualiza la información e horarios del grupo tras la selección de grupos
        If cboGrupo.Text.Equals("Elija un grupo") Then
            lblSeleccioneGrupo.Visible = True
            lblSeleccioneGrupo.BringToFront()
            lblSeleccioneGrupo2.Visible = True
            lblSeleccioneGrupo2.BringToFront()
            Return
        End If
        lblNomGrupo.Text = "Grupo" & vbCrLf & cboGrupo.Text.Substring(0, cboGrupo.Text.IndexOf(" (")).Trim()
        lblSeleccioneGrupo.Visible = cboGrupo.SelectedIndex = -1
        lblSeleccioneGrupo2.Visible = cboGrupo.SelectedIndex = -1
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

    Private Sub cboCurso_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Esto solo es para prueba: Al seleccionar el tipo de curso agrega más datos al día
        Lunes.agregarHora("13:00", "Son las")
        Lunes.agregarHora("14:00", "7:30am :(")
        Lunes.agregarHora("15:00", "tengo")
        Lunes.agregarHora("16:00", "que")
        Lunes.agregarHora("17:00", "Dormir")
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
End Class
