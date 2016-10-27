Public Class frmHorariosExternos

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub

    Private Sub Grilla_Load(sender As Object, e As EventArgs) Handles Grilla.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Location = New Point(0, 0)
        Me.Size = SystemInformation.PrimaryMonitorSize
        'Me.WindowState = 2
        'Me.TopMost = True
    End Sub

    Private Sub btnAceptar_Click_1(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Dispose()
    End Sub
End Class