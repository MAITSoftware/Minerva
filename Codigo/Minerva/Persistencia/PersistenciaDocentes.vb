Imports MySql.Data.MySqlClient
Imports System.Data

Public Class PersistenciaDocentes
    Public Shared Sub Add(Ci As String, GradoProfesor As Integer)
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "INSERT INTO `Profesor` VALUES (@CiPersona, @GradoProfesor);"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@CiPersona", Ci)
                .Parameters.AddWithValue("@GradoProfesor", GradoProfesor)
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

    Public Shared Sub Edit(Ci As String, GradoProfesor As Integer)
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text
                .CommandText = "UPDATE `Profesor` SET GradoProfesor=@GradoProfesor WHERE CiPersona=@CiPersona;"
                .Parameters.AddWithValue("@CiPersona", Ci)
                .Parameters.AddWithValue("@GradoProfesor", GradoProfesor)
            End With
            cmd.ExecuteNonQuery()
            conexion.Close()
        End Using
    End Sub

    Public Shared Sub Del(Ci As String)
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM `Profesor` WHERE CiPersona=@CiPersona;"
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

    Public Shared Function GetInfo(Ci As String) As Object
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT Profesor.*, Persona.NombrePersona, Persona.ApellidoPersona FROM `Profesor`, `Persona` where Profesor.CiPersona=@CiPersona and Profesor.CiPersona=Persona.CiPersona;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@CiPersona", Ci)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Function GetConflictosAsignacion(Ci As String, IdAsignatura As String, NroGrupo As String) As Object
        Dim Conflictivo As Boolean = False
        Dim IdGrupo As String = ""

        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "select CONCAT(Grado, ' ', IdGrupo) as Grupo from Genera, Grupo, (select HoraInicio, Dia from Genera where IdAsignatura=@IdAsignatura and Genera.NroGrupo=@NroGrupo) AEC where Genera.CiPersona=@CiPersona and Genera.HoraInicio=AEC.HoraInicio and Genera.Dia=AEC.Dia and Grupo.NroGrupo=@NroGrupo;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IdAsignatura", IdAsignatura)
                .Parameters.AddWithValue("@NroGrupo", NroGrupo)
                .Parameters.AddWithValue("@CiPersona", Ci)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                Conflictivo = True
                IdGrupo = reader("Grupo")
            End While
            reader.Close()
            conexion.Close()

            Return {Conflictivo, IdGrupo}
        End Using

    End Function
End Class
