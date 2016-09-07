Public Class frmAdminUsuarios

    Dim totalUsuarios As Integer = 0

    Private Sub frmAdminUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub agregarUsuario(ByVal IDUsuario As String)
        ' Basicamente copio la plantilla a un nuevo panel
        Dim pnlTemporal As New Panel
        Dim btnUsuario As New Button
        Dim btnEliminar As New Button

        pnlTemporal.Size = pnlUsuarioPlantilla.Size
        btnUsuario.Size = btnUsuarioPlantilla.Size
        btnUsuario.FlatStyle = btnUsuarioPlantilla.FlatStyle
        btnUsuario.ForeColor = btnUsuarioPlantilla.ForeColor
        btnUsuario.Text = IDUsuario
        btnUsuario.Margin = btnUsuarioPlantilla.Margin
        btnUsuario.TextAlign = btnUsuarioPlantilla.TextAlign
        btnUsuario.BackColor = btnUsuarioPlantilla.BackColor
        btnUsuario.Location = btnUsuarioPlantilla.Location
        btnUsuario.Cursor = btnUsuarioPlantilla.Cursor
        btnUsuario.Font = btnUsuarioPlantilla.Font

        btnUsuario.Tag = IDUsuario
        'AddHandler btnUsuario.Click, AddressOf verUsuario

        btnEliminar.Size = btnEliminarPlantilla.Size
        btnEliminar.FlatStyle = btnEliminarPlantilla.FlatStyle
        btnEliminar.ForeColor = btnEliminarPlantilla.ForeColor
        btnEliminar.Text = btnEliminarPlantilla.Text
        btnEliminar.BackColor = btnEliminarPlantilla.BackColor
        btnEliminar.Location = btnEliminarPlantilla.Location
        btnEliminar.Cursor = btnEliminarPlantilla.Cursor

        btnEliminar.Tag = IDUsuario
        'AddHandler btnEliminar.Click, AddressOf eliminarUsuario

        pnlTemporal.Controls.Add(btnEliminar)
        pnlTemporal.Controls.Add(btnUsuario)

        pnlUsuarios.Controls.Add(pnlTemporal)

        totalUsuarios += 1
        lblCantidadUsuarios.Text = "(" + totalUsuarios.ToString() + ")"
    End Sub

End Class
