Public Class frmVistaGrilla
    Private Sub dgvMaterias_CellContentClick(sender As Object, e As EventArgs) Handles dgvMaterias.SelectionChanged
        sender.ClearSelection()
    End Sub
End Class
