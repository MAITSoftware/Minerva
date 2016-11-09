Public Class frmMain

    Friend NombreUsuario As String
    Friend TipoUsuario As String
    Friend cuentaInvitado As Boolean = True

    Friend TurnoElegido As ToolStripMenuItem = Nothing
    Friend CursoElegido As ToolStripMenuItem = Nothing

    Dim estadoAnimacion As Boolean = False
    Dim prevGrupo As String = ""
    Dim frmHorariosExternos As New frmHorariosExternos(Me)
    Dim filtrando As Boolean = False
    Dim vista As String = "Día"

    Public Sub New(Optional invitado As Boolean = False, Optional usuario As String = Nothing, Optional tipoUsuario As String = "Funcionario")
        InitializeComponent()

        Me.cuentaInvitado = invitado
        Me.TipoUsuario = tipoUsuario
        Me.NombreUsuario = usuario

        cboGrupo.SelectedIndex = 0
        FuncionesMinerva.CargarGrupos(Me)
        TimerBtnRefrescar.Enabled = True
    End Sub

    Private Sub frmMain_Closed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmIngresarRegistro.Dispose()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not cuentaInvitado Then
            btnAdministrar.Visible = True
            imgLogoInvitado.Visible = False
            imgLogoUsuario.Visible = True
            alertaAprobacion.Visible = True
            lblUsuario.Text = "Bienvenido usuario."
        End If
        Me.WindowState = FormWindowState.Maximized

        Usuario.ContUsuariosNoAprobados(Me)
        FuncionesMinerva.CrearMenuFiltrado(Me)
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        FuncionesMinerva.CargarNombre(Me)
    End Sub

    Private Sub AbrirAdministracion(sender As Object, e As EventArgs) Handles btnAdministrar.Click, alertaAprobacion.Click
        Dim abrirusuario As Boolean = False

        If sender Is alertaAprobacion Then
            abrirusuario = True
        End If

        Dim administracion As New frmAdministrar(Me.TipoUsuario, Me, abrirusuario)
        administracion.ShowDialog(Me)
    End Sub

    Private Sub GrupoCambiado(sender As Object, e As EventArgs) Handles cboGrupo.SelectedIndexChanged
        btnRefrescarHorarios.Enabled = False
        btnRecargar.Enabled = False
        btnFullscreen.Visible = False
        btnGuardarPdf.Visible = False

        If cboGrupo.Text.Equals("Elija un grupo") Then
            lblSeleccioneGrupo.Visible = True
            lblSeleccioneGrupo.BringToFront()
            lblSeleccioneGrupo2.Visible = True
            lblSeleccioneGrupo2.BringToFront()
            TimerBtnRefrescar.Enabled = True
            Return
        End If

        lblNomGrupo.Text = cboGrupo.Text.Trim()
        lblSeleccioneGrupo.Visible = cboGrupo.SelectedIndex = -1
        lblSeleccioneGrupo2.Visible = cboGrupo.SelectedIndex = -1

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

        TimerBtnRefrescar.Enabled = True

        If Not cboGrupo.Text.Equals(prevGrupo) Then
            Lunes.limpiar()
            Martes.limpiar()
            Miércoles.limpiar()
            Jueves.limpiar()
            Viernes.limpiar()
            Sábado.limpiar()
            Grilla.dgvMaterias.Rows.Clear()
            FuncionesMinerva.CargarInfoGrupo(Me)
            FuncionesMinerva.CargarHorariosGrupo(Me)
        End If
        prevGrupo = cboGrupo.Text
        imgLogoMAITs.Focus()
    End Sub

    Private Sub Salir(sender As Object, e As EventArgs) Handles btnSalir.Click
        frmIngresarRegistro.Show()
        Me.Dispose()
    End Sub

    Public Sub RefrescarHorarios(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles btnRefrescarHorarios.Click, btnRecargar.Click
        prevGrupo = "-1"
        RecargarGrupo()
    End Sub

    Private Sub TimerBtnRefrescar_Tick(sender As Object, e As EventArgs) Handles TimerBtnRefrescar.Tick
        btnRefrescarHorarios.Enabled = True
        btnRecargar.Enabled = True
        TimerBtnRefrescar.Enabled = False
    End Sub

    Public Sub RecargarGrupo()
        Dim grupo As String

        grupo = cboGrupo.Text
        FuncionesMinerva.CargarGrupos(Me)
        cboGrupo.SelectedIndex = 0

        If Not (cboGrupo.FindStringExact(grupo) = -1) Then
            cboGrupo.SelectedIndex = cboGrupo.FindStringExact(grupo)
        End If
    End Sub

    Private Sub ClickVistaDias(sender As Object, e As EventArgs) Handles btnVistaDias.Click
        vista = "Día"

        btnVistaDias.Enabled = False
        btnVistaDias.BackgroundImage = My.Resources.dia_seleccionado()

        btnVistaSemana.Enabled = True
        btnVistaSemana.BackgroundImage = My.Resources.semana_normal()

        RecargarGrupo()
        pnlAyudabtnVistaDias.Visible = False
    End Sub

    Private Sub ClickVistaSemana(sender As Object, e As EventArgs) Handles btnVistaSemana.Click
        vista = "Semana"

        btnVistaSemana.Enabled = False
        btnVistaSemana.BackgroundImage = My.Resources.semana_seleccionado()

        btnVistaDias.Enabled = True
        btnVistaDias.BackgroundImage = My.Resources.dia_normal()

        RecargarGrupo()
        pnlAyudabtnVistaSemana.Visible = False
    End Sub

    Private Sub VerHorariosEnPantallaCompleta(sender As Object, e As EventArgs) Handles btnFullscreen.Click
        sender.BackgroundImage = My.Resources.fullscreen_normal()
        frmHorariosExternos.cboGrupo.Items.Clear()

        For i = 1 To cboGrupo.Items.Count - 1
            frmHorariosExternos.cboGrupo.Items.Add(cboGrupo.Items(i))
        Next

        frmHorariosExternos.cboGrupo.SelectedIndex = cboGrupo.SelectedIndex - 1
        copiarGrilla()
        frmHorariosExternos.ShowDialog(Me)
    End Sub

    Private Sub GuardarPdf(sender As Object, e As EventArgs) Handles btnGuardarPdf.Click
        copiarGrilla()
        frmHorariosExternos.btnExportPDF_Click(sender, e)
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

    Private Sub fixScroll(sender As Object, e As EventArgs) Handles tblMaterias.MouseWheel, tblMaterias.MouseEnter
        pnlMaterias.Focus()
    End Sub

    Public Sub FiltroTurnoCambiado(sender As Object, e As EventArgs)
        If Not IsNothing(TurnoElegido) Then
            If sender Is TurnoElegido Then
                sender.checked = False
                TurnoElegido = Nothing
                CheckFiltrando()
                RecargarGrupo()
                Return
            End If
            TurnoElegido.Checked = False
        End If

        sender.checked = True
        TurnoElegido = sender
        CheckFiltrando()
        RecargarGrupo()
    End Sub

    Public Sub FiltroCursoCambiado(sender As Object, e As EventArgs)
        If Not IsNothing(CursoElegido) Then
            If sender Is CursoElegido Then
                sender.checked = False
                CursoElegido = Nothing
                CheckFiltrando()
                RecargarGrupo()
                Return
            End If
            CursoElegido.Checked = False
        End If

        sender.checked = True
        CursoElegido = sender
        CheckFiltrando()
        RecargarGrupo()
    End Sub

    Private Sub CheckFiltrando()
        filtrando = True
        btnFiltrar.BackgroundImage = My.Resources.filtrar_click()
        If CursoElegido Is Nothing And TurnoElegido Is Nothing Then
            filtrando = False
            btnFiltrar.BackgroundImage = My.Resources.filtrar_normal()
        End If
    End Sub

    Private Sub Animacion_1_E(sender As Object, e As EventArgs) Handles btnGuardarPdf.MouseEnter
        If Not sender.Enabled Then
            Return
        End If

        pnlAyudabtnGuardarPdf.Visible = True
        sender.BackgroundImage = My.Resources.guardar_como_pdf_hover()
    End Sub

    Private Sub Animacion_1_L(sender As Object, e As EventArgs) Handles btnGuardarPdf.MouseLeave
        If Not sender.Enabled Then
            Return
        End If

        pnlAyudabtnGuardarPdf.Visible = False
        sender.BackgroundImage = My.Resources.guardar_como_pdf_normal()
    End Sub

    Private Sub Animacion_2_E(sender As Object, e As EventArgs) Handles btnRefrescarHorarios.MouseEnter
        pnlAyudabtnRefrescarHorarios.Visible = True
        sender.BackgroundImage = My.Resources.refrescar_hover()
    End Sub

    Private Sub Animacion_2_L(sender As Object, e As EventArgs) Handles btnRefrescarHorarios.MouseLeave
        pnlAyudabtnRefrescarHorarios.Visible = False
        sender.BackgroundImage = My.Resources.refrescar_normal()
    End Sub

    Private Sub Animacion_3_L(sender As Object, e As EventArgs) Handles btnRecargar.MouseLeave
        sender.BackgroundImage = My.Resources.refrescar_normal()
        pnlAyudabtnRecargar.Visible = False
    End Sub

    Private Sub Animacion_3_E(sender As Object, e As EventArgs) Handles btnRecargar.MouseEnter
        sender.BackgroundImage = My.Resources.refrescar_hover()
        ' al entrar a el botón btnAgregarAsignatura cambiar la imagen
        pnlAyudabtnRecargar.Visible = True
    End Sub

    Private Sub Animacion_4_E(sender As Object, e As EventArgs) Handles btnVistaDias.MouseEnter
        If Not sender.enabled Then
            Return
        End If

        sender.BackgroundImage = My.Resources.dia_hover()
        pnlAyudabtnVistaDias.Visible = True
    End Sub

    Private Sub Animacion_4_L(sender As Object, e As EventArgs) Handles btnVistaDias.MouseLeave
        If Not sender.enabled Then
            Return
        End If

        sender.BackgroundImage = My.Resources.dia_normal()
        pnlAyudabtnVistaDias.Visible = False
    End Sub

    Private Sub Animacion_5_E(sender As Object, e As EventArgs) Handles btnVistaSemana.MouseEnter
        If Not sender.enabled Then
            Return
        End If

        sender.BackgroundImage = My.Resources.semana_hover()
        pnlAyudabtnVistaSemana.Visible = True
    End Sub

    Private Sub Animacion_5_L(sender As Object, e As EventArgs) Handles btnVistaSemana.MouseLeave
        If Not sender.enabled Then
            Return
        End If

        sender.BackgroundImage = My.Resources.semana_normal()
        pnlAyudabtnVistaSemana.Visible = False
    End Sub

    Private Sub Animacion_6_E(sender As Object, e As EventArgs) Handles btnFullscreen.MouseEnter
        If Not sender.enabled Then
            Return
        End If

        sender.BackgroundImage = My.Resources.fullscreen_hover()
        pnlAyudabtnFullscreen.Visible = True
    End Sub

    Private Sub Animacion_6_L(sender As Object, e As EventArgs) Handles btnFullscreen.MouseLeave
        If Not sender.enabled Then
            Return
        End If

        sender.BackgroundImage = My.Resources.fullscreen_normal()
        pnlAyudabtnFullscreen.Visible = False
    End Sub

    Private Sub Animacion_7_L(sender As Object, e As EventArgs) Handles btnFiltrar.MouseLeave
        lblFiltrado.Text = "Filtrado de grupos (activo)"
        sender.backgroundimage = My.Resources.filtrar_click()

        If Not filtrando Then
            sender.BackgroundImage = My.Resources.filtrar_normal()
            lblFiltrado.Text = "Filtrado de grupos (inactivo)"
        End If

        pnlAyudabtnFiltrar.Visible = False
    End Sub

    Private Sub Animacion_7_E(sender As Object, e As EventArgs) Handles btnFiltrar.MouseEnter
        lblFiltrado.Text = "Filtrado de grupos (activo)"
        sender.backgroundimage = My.Resources.filtrar_click()

        If Not filtrando Then
            sender.BackgroundImage = My.Resources.filtrar_hover()
            lblFiltrado.Text = "Filtrado de grupos (inactivo)"
        End If

        pnlAyudabtnFiltrar.Visible = True
    End Sub

    Private Sub MenuFiltrado(sender As Object, e As MouseEventArgs) Handles btnFiltrar.Click
        cmsFiltrado.Show(sender, New Point(e.X, e.Y))
    End Sub

    Private Sub Animacion_8_E(sender As Object, e As EventArgs) Handles alertaAprobacion.MouseEnter
        pnlAyudaalertaAprobacion.Visible = True
    End Sub

    Private Sub Animacion_8_L(sender As Object, e As EventArgs) Handles alertaAprobacion.MouseLeave
        pnlAyudaalertaAprobacion.Visible = False
    End Sub

    Private Sub imgLogoInvitado_Click(sender As Object, e As EventArgs) Handles imgLogoInvitado.Click, imgLogoUsuario.Click
        Dim frmAcerca As New frmAcerca()
        frmAcerca.ShowDialog(Me)
    End Sub
End Class
