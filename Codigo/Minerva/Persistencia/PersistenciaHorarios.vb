Imports MySql.Data.MySqlClient
Imports System.Data

Public Class PersistenciaHorarios
    Public Shared Sub Add(ByVal IdAsignatura As String, NroGrupo As String, HoraInicio As TimeSpan, HoraFin As TimeSpan, Dia As String, IdTurno As String, CiPersona As String)
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO `Genera` VALUES (@IdAsignatura, @NroGrupo, @HoraInicio, @HoraFin, @Dia, @IdTurno, @CiPersona);"
                .Parameters.AddWithValue("@IdAsignatura", IdAsignatura)
                .Parameters.AddWithValue("@NroGrupo", NroGrupo)
                .Parameters.AddWithValue("@HoraInicio", HoraInicio)
                .Parameters.AddWithValue("@HoraFin", HoraFin)
                .Parameters.AddWithValue("@Dia", Dia)
                .Parameters.AddWithValue("@IdTurno", IdTurno)
                .Parameters.AddWithValue("@CiPersona", CiPersona)
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

    Public Shared Sub Del(ByVal IdAsignatura As String, NroGrupo As String, CiPersona As String)
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "UPDATE `Genera` SET `CiPersona`='-1' WHERE `IdAsignatura`=@IdAsignatura and `NroGrupo`=@NroGrupo and `CiPersona`=@CiPersona;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@NroGrupo", NroGrupo)
                .Parameters.AddWithValue("@IdAsignatura", IdAsignatura)
                .Parameters.AddWithValue("@CiPersona", CiPersona)
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

    Public Shared Sub Edit(ByVal Ci As String, IdAsignatura As String, NroGrupo As String)
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "UPDATE `Genera` SET `CiPersona`=@CiPersona WHERE `IdAsignatura`=@IdAsignatura and `NroGrupo`=@NroGrupo;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@CiPersona", Ci)
                .Parameters.AddWithValue("@IdAsignatura", IdAsignatura)
                .Parameters.AddWithValue("@NroGrupo", NroGrupo)
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

    Public Shared Function GetForGrupo(ByVal NroGrupo As String) As Object
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM Genera WHERE `NroGrupo`=@NroGrupo;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@NroGrupo", NroGrupo)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Sub DelGrupoEntero(ByVal NroGrupo As String)
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM Genera WHERE `NroGrupo`=@NroGrupo;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@NroGrupo", NroGrupo)
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
