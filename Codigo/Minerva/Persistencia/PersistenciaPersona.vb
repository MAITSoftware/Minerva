Imports MySql.Data.MySqlClient
Imports System.Data

Public Class PersistenciaPersona

    Public Shared Sub Add(ByVal Ci As String, Optional Nombre As String = Nothing, Optional Apellido As String = Nothing)
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "INSERT INTO `Persona` VALUES (@CiPersona, @Nombre, @Apellido);"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@CiPersona", Ci)
                .Parameters.AddWithValue("@Nombre", Nombre)
                .Parameters.AddWithValue("@Apellido", Apellido)
            End With
            Try
                cmd.ExecuteNonQuery()
                conexion.Close()
            Catch ex As Exception
                conexion.Close()
                Throw ex
            End Try
        End Using
    End Sub
End Class
