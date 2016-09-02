Public Class frmAdminDocentes
    ' Clase principal para la administracion de docentes

    Private Sub frmAdminDocentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call New ToolTip().SetToolTip(lblObligatorio1, "Dato obligatorio")
        Call New ToolTip().SetToolTip(lblObligatorio2, "Dato obligatorio")
        Call New ToolTip().SetToolTip(lblObligatorio3, "Dato obligatorio")
        Call New ToolTip().SetToolTip(lblObligatorio4, "Dato obligatorio")
        Call New ToolTip().SetToolTip(lblObligatorio5, "Dato obligatorio")
    End Sub
End Class
