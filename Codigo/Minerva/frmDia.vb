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

        labelHorario.AutoSize = False
        labelHorario.Padding = New Padding(5, 0, 0, 0)
        labelHorario.Size = New Size(80, 30)
        labelHorario.ForeColor = SystemColors.Control
        labelHorario.Font = New Font("Candara", 18, FontStyle.Bold)
        labelHorario.Text = horario

        labelMateria.AutoSize = False
        labelMateria.Size = New Size(150, 30)
        labelMateria.TextAlign = ContentAlignment.BottomLeft
        labelMateria.ForeColor = SystemColors.AppWorkspace
        labelMateria.Font = New Font("Corbel", 15)
        labelMateria.Text = materia

        pnlDias.Controls.Add(labelMateria, 0, totalHoras)
        pnlDias.Controls.Add(labelHorario, 0, totalHoras)

        totalHoras += 1
        Me.Invalidate()
    End Sub

    Private Sub frmDia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Al cargar desactivar el scroll horizontal y poner el nombre del día
        pnlDias.HorizontalScroll.Maximum = 0
        pnlDias.AutoScroll = False
        pnlDias.VerticalScroll.Visible = False
        lblDia.Text = Me.Name.ToString()
    End Sub
End Class
