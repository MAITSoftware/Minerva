Imports MySql.Data.MySqlClient
Imports System.Data

Public Class PersistenciaSalones

    Public Shared Function GetSalones() As Object
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Salon`;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Sub Add(ByVal IdSalon As String, ComentariosSalon As String, PlantaSalon As String)
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO `Salon` VALUES (@IdSalon, @ComentariosSalon, @PlantaSalon);"

                .Parameters.AddWithValue("@IdSalon", IdSalon)
                .Parameters.AddWithValue("@ComentariosSalon", ComentariosSalon)
                .Parameters.AddWithValue("@PlantaSalon", PlantaSalon)
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

    Public Shared Sub Edit(ByVal IdSalon As String, ComentariosSalon As String, PlantaSalon As String)
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text
                .CommandText = "UPDATE `Salon` SET ComentariosSalon=@ComentariosSalon, PlantaSalon=@PlantaSalon WHERE IDSalon=@IDSalon;"

                .Parameters.AddWithValue("@IdSalon", IdSalon)
                .Parameters.AddWithValue("@ComentariosSalon", ComentariosSalon)
                .Parameters.AddWithValue("@PlantaSalon", PlantaSalon)
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

    Public Shared Function GetInfo(ByVal IdSalon As String) As Object
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Salon` where IdSalon=@IdSalon;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IdSalon", IdSalon)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Function GetAsignado(ByVal IdSalon As String, Turno As Integer) As Object
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT CONCAT(Grupo.Grado, ' ', Grupo.IdGrupo) as Grupo FROM `Salon`, `Grupo` WHERE Salon.IdSalon=Grupo.IdSalon and Grupo.IdTurno=@IdTurno and Salon.IdSalon=@IdSalon;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IdSalon", IdSalon)
                .Parameters.AddWithValue("@IdTurno", Turno)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Sub Del(ByVal IdSalon As String)
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM `Salon` WHERE IdSalon=@IdSalon;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IdSalon", IdSalon)
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
