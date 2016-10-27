Public Class frmDia

    ' Crea un wdiget que simula ser un mini calendario con horas

    Dim totalHoras As Integer = 0
    Dim dia As String

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub me_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        ' Dibuja un borde
        e.Graphics.DrawRectangle(New Pen(Color.White, 2), New Rectangle(New Point(1, 27), New Size(New Point(pnlDias.Width + 2, pnlDias.Height + 2))))
    End Sub

    Public Sub agregarHora(ByVal horario As String, ByVal materia As String)
        ' Agrega una nueva hora a la lista de horas
        Dim labelHorario As New Label
        Dim labelMateria As New Label

        lblNoHayHoras.Visible = False

        pnlDias.AutoScroll = True

        labelHorario.AutoSize = True
        labelHorario.Padding = New Padding(0, 4, 0, 0)
        labelHorario.ForeColor = SystemColors.Control
        labelHorario.TextAlign = ContentAlignment.MiddleLeft
        labelHorario.Font = New Font("Courier New", 14, FontStyle.Bold)
        labelHorario.Text = horario

        labelMateria.AutoSize = True
        labelMateria.Padding = New Padding(0, 3, 0, 0)
        labelMateria.TextAlign = ContentAlignment.MiddleLeft
        labelMateria.ForeColor = SystemColors.AppWorkspace
        labelMateria.Font = New Font("Courier New", 14)
        labelMateria.Text = materia

        pnlDias.Controls.Add(labelHorario, 0, totalHoras)
        pnlDias.Controls.Add(labelMateria, 1, totalHoras)

        totalHoras += 1
        Me.Invalidate()
    End Sub

    Public Sub limpiar()
        totalHoras = 0
        lblNoHayHoras.Visible = True
        pnlDias.Controls.Clear()
    End Sub

    Private Sub frmDia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Al cargar desactivar el scroll horizontal y poner el nombre del día
        'pnlDias.HorizontalScroll.Maximum = 0
        'pnlDias.AutoScroll = False
        'pnlDias.VerticalScroll.Visible = False
        lblDia.Text = Me.Name.ToString()
    End Sub
End Class
