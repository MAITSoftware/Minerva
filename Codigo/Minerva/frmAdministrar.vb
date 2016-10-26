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

        Me.Controls.Remove(pnlTrabajo)
        acomodarDiseño()
        pnlTrabajo = New frmAdminSalones()
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

        Me.Controls.Remove(pnlTrabajo)
        acomodarDiseño()
        pnlTrabajo = New frmAdminGrupos(frmMain)
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

        Me.Controls.Remove(pnlTrabajo)
        acomodarDiseño()
        pnlTrabajo = New frmAdminDocentes()

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

        Me.Controls.Remove(pnlTrabajo)
        acomodarDiseño(False)
        pnlTrabajo = New frmAdminHorarios(Me.frmMain)
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

        Me.Controls.Remove(pnlTrabajo)
        acomodarDiseño()
        pnlTrabajo = New frmAdminUsuarios(Me.frmMain.nombreUsuario)
        Me.Size = New Point(1024, 575)
        Me.Controls.Add(pnlTrabajo)
        pnlTrabajo.Location = New Point(2, 42)
        pnlTrabajo.BringToFront()
        sender.BringToFront()
        Centrar()
    End Sub
End Class