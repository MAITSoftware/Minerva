Public Class frmMain

    Dim cuentaInvitado As Boolean = True
    Dim estadoAnimacion As Boolean = False

    Public Sub New(Optional ByVal invitado As Boolean = True)
        'inicia el programa, en caso de que sea invitado lo detecta
        InitializeComponent()
        Me.cuentaInvitado = invitado
    End Sub

    Private Sub btnAdministrar_showMenu(sender As Object, e As EventArgs) Handles btnAdministrar.Click
        ' Abre la ventana de administracion al clickear
        Dim administracion As New frmAdministrar()
        administracion.ShowDialog(Me)
    End Sub


    Private Sub chkFiltrado_Cambiado(sender As Object, e As EventArgs) Handles chkCurso.CheckedChanged, chkGrado.CheckedChanged, chkTurno.CheckedChanged
        ' Activa o desactiva los combobox en base a los checkbox
        cboCurso.Enabled = chkCurso.Checked
        cboGrado.Enabled = chkGrado.Checked
        cboTurno.Enabled = chkTurno.Checked
        cboCurso.SelectedIndex = -1
        cboGrado.SelectedIndex = -1
        cboGrado.SelectedIndex = -1
    End Sub

    Private Sub cboGrupo_Changed(sender As Object, e As EventArgs) Handles cboGrupo.SelectedIndexChanged
        ' Actualiza la información e horarios del grupo tras la selección de grupos
        lblNomGrupo.Text = "Grupo" & vbCrLf & cboGrupo.Text
        lblSeleccioneGrupo.Visible = cboGrupo.SelectedIndex = -1
        lblSeleccioneGrupo2.Visible = cboGrupo.SelectedIndex = -1
    End Sub

    Private Sub Minerva_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' al cerrar la ventana termianr programa
        frmIngresarRegistro.Dispose()
    End Sub

    Private Sub Minerva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Al iniciar programa inicia el timer de la animacion, y oculta el boton de administracion en caso de que sea invitado
        timerAnimacion.Start()
        If Not cuentaInvitado Then
            btnAdministrar.Visible = True
            imgLogo.Location = New Point(12, 15)
            imgLogo.Size = New Size(176, 78)
        End If
    End Sub

    Private Sub timerAnimacion_Tick(sender As Object, e As EventArgs) Handles timerAnimacion.Tick
        ' Cambia el color del label cada x tiempo
        If Not cboGrupo.SelectedIndex = -1 Then
            lblGrupo.ForeColor = Color.PaleGreen
            lblGrupo.Text = "Grupo"
            Return
        End If
        lblGrupo.Text = "➤ Grupo"
        If estadoAnimacion Then
            lblGrupo.ForeColor = Color.PaleGreen
        Else
            lblGrupo.ForeColor = Color.FromArgb(47, 213, 102)
        End If

        estadoAnimacion = Not estadoAnimacion
    End Sub

    Private Sub cboCurso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCurso.SelectedIndexChanged
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
End Class
