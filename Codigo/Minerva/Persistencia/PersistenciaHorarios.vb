Imports MySql.Data.MySqlClient
Imports System.Data

Public Class PersistenciaHorarios
    Public Shared Sub Add(IdAsignatura As String, NroGrupo As String, HoraInicio As String, HoraFin As String, Dia As String, IdTurno As String, CiPersona As String)
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

    Public Shared Sub ForceDel(HoraInicio As String, HoraFin As String, Dia As String, NroGrupo As String, IdTurno As String)
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM `Genera` WHERE HoraInicio=@HoraInicio and HoraFin=@HoraFin and Dia=@Dia and NroGrupo=@NroGrupo and IdTurno=@IdTurno"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@HoraInicio", HoraInicio)
                .Parameters.AddWithValue("@HoraFin", HoraFin)
                .Parameters.AddWithValue("@Dia", Dia)
                .Parameters.AddWithValue("@NroGrupo", NroGrupo)
                .Parameters.AddWithValue("@IdTurno", IdTurno)
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

    Public Shared Sub Del(IdAsignatura As String, NroGrupo As String, CiPersona As String)
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

    Public Shared Sub Edit(Ci As String, IdAsignatura As String, NroGrupo As String)
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

    Public Shared Function GetForGrupo(NroGrupo As String) As Object
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

    Public Shared Sub DelGrupoEntero(NroGrupo As String)
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

    Public Shared Function GetCalendarioForGrupo(ByVal StringGrupo As String) As Object
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "select * from Calendario where Grupo=@StringGrupo;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@StringGrupo", StringGrupo)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Function GetCalendarioDiarioForGrupo(Dia As String, StringGrupo As String) As Object
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "select *, DATE_FORMAT(HoraInicio, '%H:%i') as HoraOrden from Calendario where Dia=@Dia and Grupo=@StringGrupo order by HoraOrden;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@StringGrupo", StringGrupo)
                .Parameters.AddWithValue("@Dia", Dia)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Function GetHorariosTurno(IdTurno As String) As Object
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "select DISTINCT HoraInicio, HoraFin from Asignacion where IdTurno=@IdTurno;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IdTurno", IdTurno)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using

    End Function

    Public Shared Function GetConflicto()
        Return "asd"
    End Function
End Class
