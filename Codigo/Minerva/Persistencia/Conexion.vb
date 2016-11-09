Imports MySql.Data.MySqlClient ' Importa el módulo de MySQL

Public Class Conexion
    ' Define la conexión como variable pública
    Friend Conn As MySqlConnection
    Dim server, user, passwd, db As String

    Public Sub New(Optional noSalir As Boolean = False)
        ' Al crear la clase, generar la conexión, y abrirla
        Try
            server = GetSetting("Minerva", "BaseDeDatos", "IP").ToString()
            user = GetSetting("Minerva", "BaseDeDatos", "Usuario").ToString()
            passwd = GetSetting("Minerva", "BaseDeDatos", "Contraseña").ToString()
            db = GetSetting("Minerva", "BaseDeDatos", "DB").ToString()
            Dim servidor_sentencia As String = "server=" & server & ";uid=" & user & ";password=" & passwd & ";database=" & db & ";Connect Timeout=2;"
            Conn = New MySqlConnection(servidor_sentencia)
            Conn.Open()
        Catch ex As Exception
            ' En caso de error mostrar un mensaje y salir
            If Not noSalir Then
                MsgBox("Error al establecer la conexión con el servidor, puede cambiar los datos de conexión la ventana inicial. El programa procederá a cerrarse.", MsgBoxStyle.Critical)
                Environment.Exit(0)
            Else
                MsgBox("Error al establecer la conexión con el servidor, puede cambiar los datos de conexión la ventana inicial.", MsgBoxStyle.Critical)
            End If
        End Try
    End Sub

    Public Sub Close()
        ' Cierra la conexión
        Conn.Dispose()
    End Sub
End Class

