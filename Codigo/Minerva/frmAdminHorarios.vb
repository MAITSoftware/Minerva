Public Class frmAdminHorarios
    ' Clase principal para la administración de horarios
    Dim prevHover As Control = New Control()
    Dim prevSelect As String = Nothing

    Friend _IdOrientacion As String = Nothing
    Friend horarioPrimera As String = "13:00"
    Friend finPrimera As String = "13:45"
    Friend horarioSegunda As String = "13:50"
    Friend finSegunda As String = "14:35"
    Friend horarioTercera As String = "14:40"
    Friend finTercera As String = "15:25"
    Friend horarioCuarta As String = "15:30"
    Friend finCuarta As String = "16:15"
    Friend horarioQuinta As String = "16:20"
    Friend finQuinta As String = "17:05"
    Friend horarioSexta As String = "17:10"
    Friend finSexta As String = "17:55"
    Friend horarioExtra As String = "18:00"
    Friend finExtra As String = "18:45"
    Friend frmMain As frmMain

    Dim tablas As Object = Nothing

    Public Sub New(ByVal frmMain As frmMain)
        Me.frmMain = frmMain
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Call New ToolTip().SetToolTip(btnDeshacer, "Recargar horarios desde base de datos")
    End Sub

    Public Sub Materia_MouseDown(sender As Object, e As MouseEventArgs)
        Dim btn As Control = TryCast(sender, Control)
        btn.DoDragDrop(btn, DragDropEffects.Move)
        prevHover.BackColor = Color.FromArgb(35, 35, 35)
        If (e.Button = Windows.Forms.MouseButtons.Right) Then
            If Not (sender.Parent Is pnlMaterias Or sender.Text.Equals("Sin asignar")) Then
                sender.Parent.BackColor = Color.FromArgb(35, 35, 35)
                sender.Parent.Controls.Remove(sender)
                pnlMaterias.Controls.Add(sender)
            ElseIf (sender.Text.Equals("Sin asignar") And Not (sender.Parent Is pnlMaterias)) Then
                sender.Parent.Controls.Remove(sender)
            End If

        End If
    End Sub

    Private Sub pnl_DragDrop(sender As Object, e As DragEventArgs)
        Dim c As Control = TryCast(e.Data.GetData(e.Data.GetFormats()(0)), Control)
        Console.WriteLine(sender)
        Dim x As Button
        prevHover.BackColor = Color.FromArgb(35, 35, 35)
        If TypeOf (c) Is TableLayoutPanel Then
            c = c.Controls(0)
        End If
        If c IsNot Nothing Then
            c.Location = sender.PointToClient(New Point(e.X, e.Y))
            If c Is btnSinAsignar Then
                ' Replica del botoncito :c
                x = New Button()
                x.Text = "Sin asignar"
                x.Size = btnSinAsignar.Size
                x.Tag = {"-1", "-1"}
                x.FlatStyle = FlatStyle.Flat
                x.FlatAppearance.BorderColor = btnSinAsignar.FlatAppearance.BorderColor
                x.FlatAppearance.BorderSize = btnSinAsignar.FlatAppearance.BorderSize
                x.FlatAppearance.CheckedBackColor = btnSinAsignar.FlatAppearance.CheckedBackColor
                x.FlatAppearance.MouseDownBackColor = btnSinAsignar.FlatAppearance.MouseDownBackColor
                x.FlatAppearance.MouseOverBackColor = btnSinAsignar.FlatAppearance.MouseOverBackColor
                x.BackColor = Color.White
                x.TabStop = False
                AddHandler x.MouseDown, AddressOf Materia_MouseDown
                sender.Controls.Add(x)
            Else
                If c.Text = "Sin asignar" Or c.Tag Is {"-1", "-1"} Then
                    c.Dispose()
                    Return
                End If
                sender.Controls.Add(c)
            End If
        End If
    End Sub

    Private Sub pnl_DragOver(sender As Object, e As DragEventArgs)
        prevHover.BackColor = Color.FromArgb(35, 35, 35)
        sender.BackColor = Color.FromArgb(50, 50, 50)
        If sender.Controls.Count > 0 And Not (sender Is pnlMaterias) Then
            e.Effect = DragDropEffects.None
        Else
            e.Effect = DragDropEffects.Move
        End If
        prevHover = sender
    End Sub


    Private Sub frmAdminHorarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each c As Control In pnlMaterias.Controls
            AddHandler c.MouseDown, AddressOf Materia_MouseDown
        Next

        tablas = {
            tableLunes1, tableLunes2, tableLunes3, tableLunes4, tableLunes5, tableLunes6, tableLunes7, _
            tableMartes1, tableMartes2, tableMartes3, tableMartes4, tableMartes5, tableMartes6, tableMartes7, _
            tableMiercoles1, tableMiercoles2, tableMiercoles3, tableMiercoles4, tableMiercoles5, tableMiercoles6, tableMiercoles7, _
            tableJueves1, tableJueves2, tableJueves3, tableJueves4, tableJueves5, tableJueves6, tableJueves7, _
            tableViernes1, tableViernes2, tableViernes3, tableViernes4, tableViernes5, tableViernes6, tableViernes7, _
            tableSabado1, tableSabado2, tableSabado3, tableSabado4, tableSabado5, tableSabado6, tableSabado7, pnlMaterias
        }

        For Each tabla As Control In tablas
            tabla.AllowDrop = True
            AddHandler tabla.DragOver, AddressOf pnl_DragOver
            AddHandler tabla.DragDrop, AddressOf pnl_DragDrop
            For Each c As Control In tabla.Controls
                AddHandler c.MouseDown, AddressOf Materia_MouseDown
            Next
        Next

        Dim DB As New BaseDeDatos()
        DB.cargarGrupos_frmAdminHorarios(Me)
        cmbGrupo.Focus()
        Call New ToolTip().SetToolTip(btnDeshacer, "Carga los horarios desde la base de datos (elimina las modificaciones)")
    End Sub

    Private Sub cmbGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGrupo.SelectedIndexChanged
        If cmbGrupo.Text.Equals(prevSelect) Then
            Return
        End If

        prevSelect = cmbGrupo.Text

        cargarGrupo()
    End Sub

    Private Sub btnGuardado_Click(sender As Object, e As EventArgs) Handles btnGuardado.Click
        Dim DB As New BaseDeDatos()
        DB.guardarHorarios_frmAdminHorarios(Me)
    End Sub

    Private Sub cargarGrupo()
        For Each tabla As Control In tablas
            tabla.Controls.Clear()
        Next

        lblSeleccioneGrupo.Visible = False
        lblTapaMaterias.Visible = False
        pnlMaterias.Enabled = True
        btnDeshacer.Visible = True

        btnGuardado.TabStop = True
        btnLimpiar.TabStop = True

        If cmbGrupo.Text.Equals("...") Then
            lblSeleccioneGrupo.Visible = True
            lblTapaMaterias.Visible = True
            pnlMaterias.Enabled = False
            btnDeshacer.Visible = False
            btnGuardado.TabStop = False
            btnLimpiar.TabStop = False
            Return
        End If

        Dim DB As New BaseDeDatos()
        DB.cargarHorarios_frmAdminHorarios(Me)
        DB.cargarMaterias_frmAdminHorarios(Me)
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        For Each tabla As Control In tablas
            If tabla Is pnlMaterias Then
                Return
            End If
            For Each btn As Control In tabla.Controls()
                If btn.Text.Equals("Sin asignar") Then
                    btn.Dispose()
                Else
                    btn.Parent = Nothing
                    pnlMaterias.Controls.Add(btn)
                End If
            Next
        Next
    End Sub

    Public Sub actHorarios()
        lblHora1.Text = horarioPrimera.Substring(0, horarioPrimera.Length - 3)
        lblHora2.Text = horarioSegunda.Substring(0, horarioSegunda.Length - 3)
        lblHora3.Text = horarioTercera.Substring(0, horarioTercera.Length - 3)
        lblHora4.Text = horarioCuarta.Substring(0, horarioCuarta.Length - 3)
        lblHora5.Text = horarioQuinta.Substring(0, horarioQuinta.Length - 3)
        lblHora6.Text = horarioSexta.Substring(0, horarioSexta.Length - 3)
        lblHora7.Text = horarioExtra.Substring(0, horarioExtra.Length - 3)
    End Sub

    Private Sub btnDeshacer_Click(sender As Object, e As EventArgs) Handles btnDeshacer.Click
        cargarGrupo()
    End Sub

    Private Sub btnDeshacer_Leave(sender As Object, e As EventArgs) Handles btnDeshacer.MouseLeave
        ' al dejar el botón btnDeshacer cambiar la imagen
        btnDeshacer.BackgroundImage = My.Resources.cancelar_normal()
    End Sub

    Private Sub btnDeshacer_Enter(sender As Object, e As EventArgs) Handles btnDeshacer.MouseEnter
        ' al entrar a el botón btnDeshacer cambiar la imagen
        btnDeshacer.BackgroundImage = My.Resources.cancelar_hover()
    End Sub

End Class
