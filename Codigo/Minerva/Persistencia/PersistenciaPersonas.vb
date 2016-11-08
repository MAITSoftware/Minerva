Imports MySql.Data.MySqlClient
Imports System.Data

Public Class PersistenciaPersonas

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

    Public Shared Sub Edit(ByVal Ci As String, Nombre As String, Apellido As String)
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text
                .CommandText = "UPDATE `Persona` SET NombrePersona=@NombrePersona, ApellidoPersona=@ApellidoPersona WHERE CiPersona=@CiPersona;"

                .Parameters.AddWithValue("@CiPersona", Ci)
                .Parameters.AddWithValue("@NombrePersona", Nombre)
                .Parameters.AddWithValue("@ApellidoPersona", Apellido)
            End With
            cmd.ExecuteNonQuery()
            conexion.Close()
        End Using
    End Sub

    Public Shared Sub Del(ByVal Ci As String)
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM `Persona` WHERE CiPersona=@CiPersona"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@CiPersona", Ci)
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
