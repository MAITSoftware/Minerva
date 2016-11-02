﻿Public Class frmAdministrar
    ' Clase principal de administración de datos

    Dim btnActual As Button = New Button()
    Dim pnlTrabajo As New UserControl
    Dim tipoUsuario As String
    Dim frmMain As frmMain
    Dim abrirUsuarios As Boolean

    Public Sub New(ByVal tipoUsuario As String, ByVal frmMain As frmMain, Optional ByVal abrirUsuarios As Boolean = False)
        InitializeComponent()
        Me.tipoUsuario = tipoUsuario
        Me.frmMain = frmMain
        Me.abrirUsuarios = abrirUsuarios
    End Sub

    Public Sub habilitarBotones(ByVal habilitar As Boolean)
        btnSalones.Enabled = habilitar
        btnGrupos.Enabled = habilitar
        btnDocentes.Enabled = habilitar
        btnHorarios.Enabled = habilitar
        btnUsuarios.Enabled = habilitar
    End Sub

    Private Sub frmAdministrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If tipoUsuario.Equals("Administrador") Then
            btnSalones.Visible = True
            btnGrupos.Visible = True
            btnDocentes.Visible = True
            btnHorarios.Visible = True
            btnUsuarios.Visible = True
        ElseIf tipoUsuario.Equals("Funcionario") Then
            btnSalones.Visible = True
            btnGrupos.Visible = True
            btnDocentes.Visible = True
            btnHorarios.Visible = True
            btnUsuarios.Visible = True
        ElseIf tipoUsuario.Equals("Adscripto") Then
            btnSalones.Visible = True
            btnGrupos.Visible = True
            btnDocentes.Visible = False
            btnHorarios.Visible = False
            btnUsuarios.Visible = False
        End If
        ' Clickear el btnSalones por defecto al iniciar
        btnSalones.PerformClick()
        If Me.abrirUsuarios Then
            btnUsuarios.PerformClick()
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

    Private Sub acomodarDiseño(Optional ByVal original As Boolean = True)
        If original Then
            pnlBorde.Size = New Point(1007, 2)
            pnlBorde1.Location = New Point(1005, 41)
            pnlBorde1.Size = New Point(3, 504)
            pnlBorde2.Location = New Point(0, 40)
            pnlBorde2.Size = New Point(2, 500)
            pnlBorde3.Location = New Point(0, 535)
            pnlBorde3.Size = New Point(1007, 2)

            pnlBorde.BringToFront()
            pnlBorde1.BringToFront()
            pnlBorde2.BringToFront()
            pnlBorde3.BringToFront()
        Else
            pnlBorde.Size = New Point(1400, 2)

            pnlBorde1.Location = New Point(1182, 41)
            pnlBorde1.Size = New Point(3, 604)

            pnlBorde2.Location = New Point(0, 40)
            pnlBorde2.Size = New Point(2, 600)

            pnlBorde3.Location = New Point(0, 560)
            pnlBorde3.Size = New Point(1200, 2)

            pnlBorde.BringToFront()
            pnlBorde1.BringToFront()
            pnlBorde2.BringToFront()
            pnlBorde3.BringToFront()
        End If
    End Sub

    Private Sub Centrar()
        '' Note: call this from frm's Load event!
        Dim r As Rectangle
        r = Me.frmMain.RectangleToScreen(frmMain.ClientRectangle)

        Dim x = r.Left + (r.Width - Me.Width) \ 2
        Dim y = r.Top + (r.Height - Me.Height) \ 2
        Me.Location = New Point(x, y)
    End Sub

    ' Al clickear X boton mostrar X panel.

    Private Sub btnSalones_Click(sender As Object, e As EventArgs) Handles btnSalones.Click
        If btnActual Is sender Then
            If TypeOf (pnlTrabajo) Is frmAdminSalones Then
                Return
            End If
        End If

        Me.Text = "Minerva · Administración de salones"
        Me.Controls.Remove(pnlTrabajo)
        acomodarDiseño()
        pnlTrabajo = New frmAdminSalones(Me.frmMain, Me.tipoUsuario)
        Me.Controls.Add(pnlTrabajo)
        pnlTrabajo.Location = New Point(2, 42)
        pnlTrabajo.BringToFront()
        sender.BringToFront()
        Centrar()
    End Sub

    Private Sub btnGrupos_Click(sender As Object, e As EventArgs) Handles btnGrupos.Click
        If btnActual Is sender Then
            If TypeOf (pnlTrabajo) Is frmAdminGrupos Then
                Return
            End If
        End If

        Me.Text = "Minerva · Administración de grupos"
        Me.Controls.Remove(pnlTrabajo)
        acomodarDiseño()
        pnlTrabajo = New frmAdminGrupos(Me.frmMain, Me.tipoUsuario, Me.frmMain.nombreUsuario)
        Me.Size = New Point(1024, 575)
        Me.Controls.Add(pnlTrabajo)
        pnlTrabajo.Location = New Point(2, 42)
        pnlTrabajo.BringToFront()
        sender.BringToFront()
        Centrar()
    End Sub

    Private Sub btnDocentes_Click(sender As Object, e As EventArgs) Handles btnDocentes.Click
        If btnActual Is sender Then
            If TypeOf (pnlTrabajo) Is frmAdminDocentes Then
                Return
            End If
        End If

        Me.Text = "Minerva · Administración de docentes"
        Me.Controls.Remove(pnlTrabajo)
        acomodarDiseño()
        pnlTrabajo = New frmAdminDocentes(Me.frmMain)

        Me.Size = New Point(1024, 575)
        Me.Controls.Add(pnlTrabajo)
        pnlTrabajo.Location = New Point(2, 42)
        pnlTrabajo.BringToFront()
        sender.BringToFront()
        Centrar()
    End Sub

    Private Sub btnHorarios_Click(sender As Object, e As EventArgs) Handles btnHorarios.Click
        If btnActual Is sender Then
            If TypeOf (pnlTrabajo) Is frmAdminHorarios Then
                Return
            End If
        End If

        Me.Text = "Minerva · Administración de horarios"
        Me.Controls.Remove(pnlTrabajo)
        acomodarDiseño(False)
        pnlTrabajo = New frmAdminHorarios(Me.frmMain, Me)
        Me.Size = New Point(1200, 600)
        Me.Controls.Add(pnlTrabajo)
        pnlTrabajo.Location = New Point(2, 42)
        pnlTrabajo.BringToFront()
        sender.BringToFront()
        Centrar()
    End Sub

    Private Sub btnUsuarios_Click(sender As Object, e As EventArgs) Handles btnUsuarios.Click
        If btnActual Is sender Then
            If TypeOf (pnlTrabajo) Is frmAdminUsuarios Then
                Return
            End If
        End If

        Me.Text = "Minerva · Administración de usuarios"
        Me.Controls.Remove(pnlTrabajo)
        acomodarDiseño()
        pnlTrabajo = New frmAdminUsuarios(Me.frmMain.nombreUsuario, Me.frmMain)
        Me.Size = New Point(1024, 575)
        Me.Controls.Add(pnlTrabajo)
        pnlTrabajo.Location = New Point(2, 42)
        pnlTrabajo.BringToFront()
        sender.BringToFront()
        Centrar()
    End Sub

    Private Sub frmAdministrar_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Hide()
        frmMain.cargarNombre()
        frmMain.recargarGrupo()
    End Sub
End Class