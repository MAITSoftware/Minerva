Public Class frmLimpiarDB

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        Dim result As Integer = MessageBox.Show("¿Está seguro de que desea realizar estos cambios?" & vbCrLf & vbCrLf & "Se recomienda realizar una copia de seguridad (backup) de la base de datos, para poder restaurlarla en caso de fallos.", "Alterar base datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If
        Me.Dispose()
    End Sub
End Class