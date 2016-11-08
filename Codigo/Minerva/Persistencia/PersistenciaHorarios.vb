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
