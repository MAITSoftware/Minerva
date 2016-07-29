Public Class frmIngresarRegistro

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        ' Al clickear ingresar mostrar login
        Dim login As New frmLogin()
        login.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnInvitado.Click
        ' Al clickear invitado mostrar Minerva
        Dim programa As New frmMain()
        programa.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnRegistro.Click
        ' Al clickear registro mostrar registro
        Dim registro As New frmRegistro()
        registro.Show()
        Me.Hide()
    End Sub
End Class