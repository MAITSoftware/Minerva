Public Class frmAdministrar
    ' Clase principal de administración de datos

    Dim btnActual As Button = New Button()
    Dim pnlTrabajo As New UserControl
    Dim administrador As Boolean = False
    Dim frmMain As frmMain

    Public Sub New(ByVal administrador As Boolean, ByVal frmMain As frmMain)
        InitializeComponent()
        Me.administrador = administrador
        Me.frmMain = frmMain
    End Sub

    Private Sub frmAdministrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Clickear el btnSalones por defecto al iniciar
        btnSalones.PerformClick()
        If administrador Then
            btnUsuarios.Visible = True
        End If
    End Sub

    Private Sub botones_Click(sender As Object, e As EventArgs) Handles btnSalones.Click, btnGrupos.Click, btnDocentes.Click, btnHorarios.Click, btnUsuarios.Click
        ' Cambia la pestaña seleccionada y le cambia el fondo
        pnlTrabajo.Focus()
        If btnActual Is sender Then
            Return
        End If

        btnActual.Location = New Point(btnActual.Location.X, 4)
        btnActual.BackColor = Color.FromArgb(45, 45, 45)
        btnActual.FlatAppearance.BorderColor = Color.Gray
        btnActual.FlatAppearance.MouseDownBackColor = Color.FromArgb(45, 45, 45)
        btnActual.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 45)
        btnActual.Cursor = Cursors.Hand

        btnActual = sender
        btnActual.Location = New Point(btnActual.Location.X, 0)
        btnActual.BackColor = Color.FromArgb(35, 35, 35)
        btnActual.FlatAppearance.BorderColor = Color.PaleGreen
        btnActual.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 35, 35)
        btnActual.FlatAppearance.MouseOverBackColor = Color.FromArgb(35, 35, 35)
        btnActual.Cursor = Cursors.Default

        pnlBorde.BringToFront()
        btnActual.BringToFront()
        pnlTrabajo.BringToFront()
    End Sub

    ' Al clickear X boton mostrar X panel.

    Private Sub btnSalones_Click(sender As Object, e As EventArgs) Handles btnSalones.Click
        Me.Controls.Remove(pnlTrabajo)
        pnlTrabajo = New frmAdminSalones()
        Me.Controls.Add(pnlTrabajo)
        pnlTrabajo.Location = New Point(2, 42)
        pnlTrabajo.BringToFront()
    End Sub

    Private Sub btnGrupos_Click(sender As Object, e As EventArgs) Handles btnGrupos.Click
        Me.Controls.Remove(pnlTrabajo)
        pnlTrabajo = New frmAdminGrupos(frmMain)
        Me.Controls.Add(pnlTrabajo)
        pnlTrabajo.Location = New Point(2, 42)
        pnlTrabajo.BringToFront()
    End Sub

    Private Sub btnDocentes_Click(sender As Object, e As EventArgs) Handles btnDocentes.Click
        Me.Controls.Remove(pnlTrabajo)
        pnlTrabajo = New frmAdminDocentes()
        Me.Controls.Add(pnlTrabajo)
        pnlTrabajo.Location = New Point(2, 42)
        pnlTrabajo.BringToFront()
    End Sub

    Private Sub btnHorarios_Click(sender As Object, e As EventArgs) Handles btnHorarios.Click
        Me.Controls.Remove(pnlTrabajo)
        pnlTrabajo = New frmAdminHorarios()
        Me.Controls.Add(pnlTrabajo)
        pnlTrabajo.Location = New Point(2, 42)
        pnlTrabajo.BringToFront()
    End Sub

    Private Sub btnUsuarios_Click(sender As Object, e As EventArgs) Handles btnUsuarios.Click
        Me.Controls.Remove(pnlTrabajo)
        pnlTrabajo = New frmAdminUsuarios()
        Me.Controls.Add(pnlTrabajo)
        pnlTrabajo.Location = New Point(2, 42)
        pnlTrabajo.BringToFront()
    End Sub
End Class