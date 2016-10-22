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

    Dim tablas As Object = Nothing

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim x As BaseDeDatos
        x = New BaseDeDatos()
    End Sub

    Public Sub Materia_MouseDown(sender As Object, e As MouseEventArgs)
        Dim btn As Control = TryCast(sender, Control)
        btn.DoDragDrop(btn, DragDropEffects.Move)
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

    Private Sub Panel_DragDrop(sender As Object, e As DragEventArgs)
        Dim c As Control = TryCast(e.Data.GetData(e.Data.GetFormats()(0)), Control)
        Console.WriteLine(sender)
        Dim x As Button
        prevHover.BackColor = Color.FromArgb(35, 35, 35)
        If c IsNot Nothing Then
            c.Location = sender.PointToClient(New Point(e.X, e.Y))
            If c Is btnSinAsignar Then
                ' Replica del botoncito :c
                x = New Button()
                x.Text = "Sin asignar"
                x.Size = btnSinAsignar.Size
                x.Tag = "-1"
                x.FlatStyle = FlatStyle.Flat
                x.FlatAppearance.BorderColor = btnSinAsignar.FlatAppearance.BorderColor
                x.FlatAppearance.BorderSize = btnSinAsignar.FlatAppearance.BorderSize
                x.FlatAppearance.CheckedBackColor = btnSinAsignar.FlatAppearance.CheckedBackColor
                x.FlatAppearance.MouseDownBackColor = btnSinAsignar.FlatAppearance.MouseDownBackColor
                x.FlatAppearance.MouseOverBackColor = btnSinAsignar.FlatAppearance.MouseOverBackColor
                x.BackColor = Color.White
                AddHandler x.MouseDown, AddressOf Materia_MouseDown
                sender.Controls.Add(x)
            Else
                sender.Controls.Add(c)
            End If
        End If
    End Sub

    Private Sub Panel_DragOver(sender As Object, e As DragEventArgs)
        prevHover.BackColor = Color.FromArgb(35, 35, 35)
        sender.BackColor = Color.FromArgb(50, 50, 50)
        If sender.Controls.Count > 0 Then
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
            tableSabado1, tableSabado2, tableSabado3, tableSabado4, tableSabado5, tableSabado6, tableSabado7
        }

        For Each tabla As Control In tablas
            tabla.AllowDrop = True
            AddHandler tabla.DragOver, AddressOf Panel_DragOver
            AddHandler tabla.DragDrop, AddressOf Panel_DragDrop
            For Each c As Control In tabla.Controls
                AddHandler c.MouseDown, AddressOf Materia_MouseDown
            Next
        Next

        Dim DB As New BaseDeDatos()
        DB.cargarGrupos_frmAdminHorarios(Me)
    End Sub

    Private Sub cmbGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGrupo.SelectedIndexChanged
        If cmbGrupo.Text.Equals(prevSelect) Then
            Return
        End If

        prevSelect = cmbGrupo.Text

        For Each tabla As Control In tablas
            tabla.Controls.Clear()
        Next

        lblSeleccioneGrupo.Visible = False
        pnlMaterias.Enabled = True
        If cmbGrupo.Text.Equals("...") Then
            lblSeleccioneGrupo.Visible = True
            pnlMaterias.Enabled = False
            Return
        End If

        Dim DB As New BaseDeDatos()
        DB.cargarMaterias_frmAdminHorarios(Me)
    End Sub

    Private Sub btnGuardado_Click(sender As Object, e As EventArgs) Handles btnGuardado.Click
        Dim DB As New BaseDeDatos()
        DB.guardarHorarios_frmAdminHorarios(Me)
    End Sub
End Class
