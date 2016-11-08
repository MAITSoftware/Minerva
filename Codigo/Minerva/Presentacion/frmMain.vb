Public Class frmMain

    Dim cuentaInvitado As Boolean = True
    Dim estadoAnimacion As Boolean = False
    Friend nombreUsuario As String
    Friend Administrador As Boolean = False
    Friend vista As String = "Día"
    Dim frmHorariosExternos As New frmHorariosExternos(Me)
    Dim filtrando As Boolean = False
    Friend tipoUsuario As String
    Friend turnoElegido As ToolStripMenuItem = Nothing
    Friend cursoElegido As ToolStripMenuItem = Nothing

    Public Sub New(Optional ByVal invitado As Boolean = False, Optional ByVal usuario As String = Nothing, Optional ByVal tipoUsuario As String = "Funcionario")
        'inicia el programa, en caso de que sea invitado lo detecta
        InitializeComponent()
        Me.cuentaInvitado = invitado
        Me.tipoUsuario = tipoUsuario
        Me.nombreUsuario = usuario
        cboGrupo.SelectedIndex = 0
        cargarDatos()
        timerbtnrefrescar.Enabled = True
    End Sub

    Private Sub btnAdministrar_showMenu(sender As Object, e As EventArgs) Handles btnAdministrar.Click, alertaAprobacion.Click
        ' Abre la ventana de administracion al clickear
        Dim abrirusuario As Boolean = False
        If sender Is alertaAprobacion Then
            abrirusuario = True
        End If
        Dim administracion As New frmAdministrar(Me.tipoUsuario, Me, abrirUsuario)
        administracion.ShowDialog(Me)
    End Sub

    Private Sub cboGrupo_Changed(sender As Object, e As EventArgs) Handles cboGrupo.SelectedIndexChanged
        btnRefrescarHorarios.Enabled = False
        btnRecargar.Enabled = False
        btnFullscreen.Visible = False
        btnGuardarPdf.Visible = False

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
        Grilla.dgvMaterias.Rows.Clear()
        If vista.Equals("Semana") Then
            Grilla.Visible = True
            Grilla.BringToFront()
            tblDias.Visible = False
            btnFullscreen.Visible = True
            btnGuardarPdf.Visible = True
        Else
            Grilla.Visible = False
            tblDias.Visible = True
            tblDias.BringToFront()
        End If

        timerbtnrefrescar.Enabled = True
        Dim Logica as New Logica()

        Logica.cargarDatosGrupo_frmMain(Me)
        Logica.cargarMateriasGrupo_frmMain(Me)
        imgLogoMAITs.Focus()
    End Sub

    Private Sub Minerva_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' al cerrar la ventana termianr programa
        frmIngresarRegistro.Dispose()
    End Sub

    Private Sub Minerva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Al iniciar programa inicia oculta el boton de administracion en caso de que sea invitado

        If Not cuentaInvitado Then
            btnAdministrar.Visible = True
            imgLogoInvitado.Visible = False
            imgLogoUsuario.Visible = True
            alertaAprobacion.Visible = True
            lblUsuario.Text = "Bienvenido usuario."
            timerDatosUsuario.Start()
            timerDatosUsuario.Enabled = True
        End If
        Me.WindowState = FormWindowState.Maximized
        Dim Logica as New Logica()
        Usuario.ContUsuariosNoAprobados(Me)
        Logica.crearMenuCursosTurnos_frmMain(Me)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        ' Al clickear salir, nos desloguea y muestra la ventana de inicio
        frmIngresarRegistro.Show()
        Me.Dispose()
    End Sub

    ' Persistencia
    Private Sub cargarDatos()
        Dim Logica as New Logica()
        Logica.cargarDatos_frmMain(Me)
    End Sub

    Private Sub timerDatosUsuario_Tick(sender As Object, e As EventArgs) Handles timerDatosUsuario.Tick
        timerDatosUsuario.Enabled = False
        timerDatosUsuario.Stop()
        cargarNombre()
    End Sub

    Public Sub cargarNombre()
        Dim Logica as New Logica()
        Logica.cargarNombre_frmMain(Me)
    End Sub

    Private Sub btnRefrescarHorarios_Click(sender As Object, e As EventArgs) Handles btnRefrescarHorarios.Click
        recargarGrupo()
    End Sub

    Private Sub timerbtnrefrescar_Tick(sender As Object, e As EventArgs) Handles timerbtnrefrescar.Tick
        btnRefrescarHorarios.Enabled = True
        btnRecargar.Enabled = True
        timerbtnrefrescar.Enabled = False
    End Sub

    Public Sub recargarGrupo()
        Dim grupo As String
        grupo = cboGrupo.Text
        cargarDatos()
        cboGrupo.SelectedIndex = 0
        If Not (cboGrupo.FindStringExact(grupo) = -1) Then
            cboGrupo.SelectedIndex = cboGrupo.FindStringExact(grupo)
        End If
    End Sub

    Private Sub btnVistaDias_Click(sender As Object, e As EventArgs) Handles btnVistaDias.Click
        vista = "Día"
        btnVistaDias.Enabled = False
        btnVistaDias.BackgroundImage = My.Resources.dia_seleccionado()
        btnVistaSemana.Enabled = True
        btnVistaSemana.BackgroundImage = My.Resources.semana_normal()
        recargarGrupo()
        pnlAyudabtnVistaDias.Visible = False
    End Sub
    Private Sub btnVistaSemana_Click(sender As Object, e As EventArgs) Handles btnVistaSemana.Click
        vista = "Semana"
        btnVistaSemana.Enabled = False
        btnVistaSemana.BackgroundImage = My.Resources.semana_seleccionado()
        btnVistaDias.Enabled = True
        btnVistaDias.BackgroundImage = My.Resources.dia_normal()
        recargarGrupo()
        pnlAyudabtnVistaSemana.Visible = False
    End Sub

    Private Sub btnFullscreen_Click(sender As Object, e As EventArgs) Handles btnFullscreen.Click
        sender.BackgroundImage = My.Resources.fullscreen_normal()
        frmHorariosExternos.cboGrupo.Items.Clear()
        For i = 1 To cboGrupo.Items.Count - 1
            frmHorariosExternos.cboGrupo.Items.Add(cboGrupo.Items(i))
        Next
        frmHorariosExternos.cboGrupo.SelectedIndex = cboGrupo.SelectedIndex - 1
        copiarGrilla()
        frmHorariosExternos.ShowDialog(Me)
    End Sub

    Public Sub copiarGrilla()
        Dim targetRows = New List(Of DataGridViewRow)
        For Each sourceRow As DataGridViewRow In Grilla.dgvMaterias.Rows
            If (Not sourceRow.IsNewRow) Then
                Dim targetRow = CType(sourceRow.Clone(), DataGridViewRow)
                For Each cell As DataGridViewCell In sourceRow.Cells
                    targetRow.Cells(cell.ColumnIndex).Value = cell.Value
                Next

                targetRows.Add(targetRow)
            End If
        Next
        frmHorariosExternos.Grilla.dgvMaterias.Columns.Clear()
        For Each column As DataGridViewColumn In Grilla.dgvMaterias.Columns
            frmHorariosExternos.Grilla.dgvMaterias.Columns.Add(CType(column.Clone(), DataGridViewColumn))
        Next
        frmHorariosExternos.Grilla.dgvMaterias.Rows.AddRange(targetRows.ToArray())
    End Sub

    Private Sub tblMaterias_Resize(sender As Object, e As EventArgs) Handles tblMaterias.Resize
        tblMaterias.Invalidate()
    End Sub
    Private Sub btnGuardarPdf_Enter(sender As Object, e As EventArgs) Handles btnGuardarPdf.MouseEnter
        If Not sender.Enabled Then
            Return
        End If
        pnlAyudabtnGuardarPdf.Visible = True
        sender.BackgroundImage = My.Resources.guardar_como_pdf_hover()
    End Sub

    Private Sub btnGuardarPdf_Leave(sender As Object, e As EventArgs) Handles btnGuardarPdf.MouseLeave
        If Not sender.Enabled Then
            Return
        End If
        pnlAyudabtnGuardarPdf.Visible = False
        sender.BackgroundImage = My.Resources.guardar_como_pdf_normal()
    End Sub

    Private Sub btnGuardarPdf_Click(sender As Object, e As EventArgs) Handles btnGuardarPdf.Click
        copiarGrilla()
        frmHorariosExternos.btnExportPDF_Click(sender, e)
    End Sub

    ' Presentación
    Private Sub btnRecargarAyuda_leave(sender As Object, e As EventArgs) Handles btnRefrescarHorarios.MouseLeave
        pnlAyudabtnRefrescarHorarios.Visible = False
        sender.BackgroundImage = My.Resources.refrescar_normal()
    End Sub

    Private Sub btnRecargarAyuda_enter(sender As Object, e As EventArgs) Handles btnRefrescarHorarios.MouseEnter
        pnlAyudabtnRefrescarHorarios.Visible = True
        sender.BackgroundImage = My.Resources.refrescar_hover()
    End Sub

    Private Sub btnRecargar_Leave(sender As Object, e As EventArgs) Handles btnRecargar.MouseLeave
        sender.BackgroundImage = My.Resources.refrescar_normal()
        ' al dejar el botón btnEliminarAsignatura cambiar la imagen
        pnlAyudabtnRecargar.Visible = False
    End Sub

    Private Sub btnRecargar_Enter(sender As Object, e As EventArgs) Handles btnRecargar.MouseEnter
        sender.BackgroundImage = My.Resources.refrescar_hover()
        ' al entrar a el botón btnAgregarAsignatura cambiar la imagen
        pnlAyudabtnRecargar.Visible = True
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        recargarGrupo()
    End Sub

    Private Sub btnVistaDias_Enter(sender As Object, e As EventArgs) Handles btnVistaDias.MouseEnter
        ' al entrar a el botón btnAgregarAsignatura cambiar la imagen
        If Not sender.enabled Then
            Return
        End If
        sender.BackgroundImage = My.Resources.dia_hover()
        pnlAyudabtnVistaDias.Visible = True
    End Sub

    Private Sub btnVistaDias_Leave(sender As Object, e As EventArgs) Handles btnVistaDias.MouseLeave
        ' al entrar a el botón btnAgregarAsignatura cambiar la imagen
        If Not sender.enabled Then
            Return
        End If
        sender.BackgroundImage = My.Resources.dia_normal()
        pnlAyudabtnVistaDias.Visible = False
    End Sub

    Private Sub btnVistaSemana_Enter(sender As Object, e As EventArgs) Handles btnVistaSemana.MouseEnter
        ' al entrar a el botón btnAgregarAsignatura cambiar la imagen
        If Not sender.enabled Then
            Return
        End If
        sender.BackgroundImage = My.Resources.semana_hover()
        pnlAyudabtnVistaSemana.Visible = True
    End Sub

    Private Sub btnVistaSemana_Leave(sender As Object, e As EventArgs) Handles btnVistaSemana.MouseLeave
        ' al entrar a el botón btnAgregarAsignatura cambiar la imagen
        If Not sender.enabled Then
            Return
        End If
        sender.BackgroundImage = My.Resources.semana_normal()
        pnlAyudabtnVistaSemana.Visible = False
    End Sub

    Private Sub btnFullscreen_Enter(sender As Object, e As EventArgs) Handles btnFullscreen.MouseEnter
        ' al entrar a el botón btnAgregarAsignatura cambiar la imagen
        If Not sender.enabled Then
            Return
        End If
        sender.BackgroundImage = My.Resources.fullscreen_hover()
        pnlAyudabtnFullscreen.Visible = True
    End Sub

    Private Sub btnFullscreen_Leave(sender As Object, e As EventArgs) Handles btnFullscreen.MouseLeave
        ' al entrar a el botón btnAgregarAsignatura cambiar la imagen
        If Not sender.enabled Then
            Return
        End If
        sender.BackgroundImage = My.Resources.fullscreen_normal()
        pnlAyudabtnFullscreen.Visible = False
    End Sub

    Private Sub btnFiltrar_Leave(sender As Object, e As EventArgs) Handles btnFiltrar.MouseLeave
        lblFiltrado.Text = "Filtrado de grupos (activo)"
        sender.backgroundimage = My.Resources.filtrar_click()

        If Not filtrando Then
            sender.BackgroundImage = My.Resources.filtrar_normal()
            lblFiltrado.Text = "Filtrado de grupos (inactivo)"
        End If
        ' al dejar el botón btnEliminarAsignatura cambiar la imagen
        pnlAyudabtnFiltrar.Visible = False
    End Sub

    Private Sub btnFiltrar_Enter(sender As Object, e As EventArgs) Handles btnFiltrar.MouseEnter
        lblFiltrado.Text = "Filtrado de grupos (activo)"
            sender.backgroundimage = My.Resources.filtrar_click()

        If Not filtrando Then
            sender.BackgroundImage = My.Resources.filtrar_hover()
            lblFiltrado.Text = "Filtrado de grupos (inactivo)"
        End If
        ' al dejar el botón btnEliminarAsignatura cambiar la imagen
        pnlAyudabtnFiltrar.Visible = True
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As MouseEventArgs) Handles btnFiltrar.Click
        ContextMenuStrip1.Show(sender, New Point(e.X, e.Y))
    End Sub

    Private Sub alertaAprobacion_MouseEnter(sender As Object, e As EventArgs) Handles alertaAprobacion.MouseEnter
        pnlAyudaalertaAprobacion.Visible = True
    End Sub

    Private Sub alertaAprobacion_MouseLeave(sender As Object, e As EventArgs) Handles alertaAprobacion.MouseLeave
        pnlAyudaalertaAprobacion.Visible = False
    End Sub

    Private Sub pnlMaterias_MouseEnter(sender As Object, e As EventArgs) Handles tblMaterias.MouseWheel, tblMaterias.MouseEnter
        pnlMaterias.Focus()
    End Sub

    Public Sub filtroTurnoCambiado(sender As Object, e As EventArgs)
        If Not IsNothing(turnoElegido) Then
            If sender Is turnoElegido Then
                sender.checked = False
                turnoElegido = Nothing
                checkFiltrando()
                recargarGrupo()
                Return
            End If
            turnoElegido.Checked = False
        End If
        sender.checked = True
        turnoElegido = sender
        checkFiltrando()
        recargarGrupo()
    End Sub

    Public Sub filtroCursoCambiado(sender As Object, e As EventArgs)
        If Not IsNothing(cursoElegido) Then
            If sender Is cursoElegido Then
                sender.checked = False
                cursoElegido = Nothing
                checkFiltrando()
                recargarGrupo()
                Return
            End If
            cursoElegido.Checked = False
        End If
        sender.checked = True
        cursoElegido = sender
        checkFiltrando()
        recargarGrupo()
    End Sub

    Private Sub checkFiltrando()
        filtrando = True
        btnFiltrar.BackgroundImage = My.Resources.filtrar_click()
        If cursoElegido Is Nothing And turnoElegido Is Nothing Then
            filtrando = False
            btnFiltrar.BackgroundImage = My.Resources.filtrar_normal()
        End If
    End Sub
End Class
