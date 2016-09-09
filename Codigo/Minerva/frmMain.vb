Imports MySql.Data.MySqlClient
Imports System.Data

Public Class frmMain

    Dim cuentaInvitado As Boolean = True
    Dim estadoAnimacion As Boolean = False
    Friend Administrador As Boolean = False
    Private DB As DB

    Public Sub New(Optional ByVal invitado As Boolean = False, Optional ByVal admin As Boolean = False)
        'inicia el programa, en caso de que sea invitado lo detecta
        InitializeComponent()
        Me.cuentaInvitado = invitado
        Me.Administrador = admin
        cboGrupo.SelectedIndex = 0
        cargarDatos()
    End Sub

    Private Sub btnAdministrar_showMenu(sender As Object, e As EventArgs) Handles btnAdministrar.Click
        ' Abre la ventana de administracion al clickear
        Dim administracion As New frmAdministrar(Administrador)
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

    Private Sub cargarDatos()
        Dim conexion As New DB()
        ' Carga los grupos al combo
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT *, Turno.Nombre as 'nombreTurno' from `Grupo`, `Turno` where Grupo.IDTurno=Turno.ID;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                cboGrupo.Items.Add(reader("Trayecto").ToString() & " " & reader("ID") & " (" & reader("nombreTurno") & ")")
            End While
            reader.Close()
        End Using
    End Sub
End Class
