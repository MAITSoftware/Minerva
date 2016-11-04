Public Class frmIngresarRegistro


    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        ' Al clickear ingresar mostrar login
        Dim login As New frmLogin()
        login.Show()
    End Sub

    Private Sub btnInvitado_Click(sender As Object, e As EventArgs) Handles btnInvitado.Click
        ' Al clickear invitado mostrar Minerva
        Dim programa As New frmMain(True)
        programa.Show()
        Me.Hide()

    End Sub

    Private Sub btnRegistro_Click(sender As Object, e As EventArgs) Handles btnRegistro.Click
        ' Al clickear registro mostrar registro

        Dim registro As New frmRegistro()
        registro.Show()
        Me.Hide()

    End Sub

    Private Sub btnPreferencias_Enter(sender As Object, e As EventArgs) Handles btnPreferencias.MouseEnter
        pnlAyudabtnPreferencias.Visible = True
        sender.BackgroundImage = My.Resources.preferencias_hover()
    End Sub

    Private Sub btnPreferencias_Leave(sender As Object, e As EventArgs) Handles btnPreferencias.MouseLeave
        pnlAyudabtnPreferencias.Visible = False
        sender.BackgroundImage = My.Resources.preferencias_normal()
    End Sub

    Private Sub btnPreferencias_Click(sender As Object, e As EventArgs) Handles btnPreferencias.Click
        Dim editarServidor As New frmEditarServidor()
        editarServidor.ShowDialog(Me)
    End Sub

    Private Sub frmIngresarRegistro_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False
        Dim ventanaEspere As New frmDialogoEspere
        ventanaEspere.Show()

        ' Datos por defecto de la base de datos
        If String.IsNullOrEmpty(GetSetting("Minerva", "BaseDeDatos", "IP").ToString()) Then
            SaveSetting("Minerva", "BaseDeDatos", "IP", "192.168.0.1")
        End If
        If String.IsNullOrEmpty(GetSetting("Minerva", "BaseDeDatos", "Usuario").ToString()) Then
            SaveSetting("Minerva", "BaseDeDatos", "Usuario", "Minerva")
        End If
        If String.IsNullOrEmpty(GetSetting("Minerva", "BaseDeDatos", "Contraseña").ToString()) Then
            SaveSetting("Minerva", "BaseDeDatos", "Contraseña", "Minerva")
        End If
        If String.IsNullOrEmpty(GetSetting("Minerva", "BaseDeDatos", "DB").ToString()) Then
            SaveSetting("Minerva", "BaseDeDatos", "DB", "Minerva")
        End If

        ' Comprueba la conexión.
        Dim conexion As New Conexion(True)
        conexion.Close()
        ventanaEspere.Dispose()
        Me.Cursor = Cursors.Default
        Me.Enabled = True
        Me.BringToFront()
    End Sub
End Class