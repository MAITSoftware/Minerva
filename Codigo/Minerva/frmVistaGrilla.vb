Public Class frmVistaGrilla

    Private Sub frmVistaGrilla_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgvMaterias_CellContentClick(sender As Object, e As EventArgs) Handles dgvMaterias.SelectionChanged
        sender.ClearSelection()
    End Sub
End Class
