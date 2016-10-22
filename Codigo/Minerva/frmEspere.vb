Public Class frmEspere

    Private Sub pnlFondo_Leave(sender As Object, e As EventArgs) Handles pnlFondo.LostFocus
        Me.BringToFront()
    End Sub
End Class