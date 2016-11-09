Imports MySql.Data.MySqlClient
Imports System.Data

Public Class PersistenciaAsignaturas
    Public Shared Sub Asignar(ByVal IdAsignatura As String, NroGrupo As String, FechaToma As String, GradoAreaProfesor As Integer, Ci As String)
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "INSERT INTO `Tiene_Ag` VALUES (@IdAsignatura, @NroGrupo, @FechaToma, @GradoAreaProfesor, @CiPersona);"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IdAsignatura", IdAsignatura)
                .Parameters.AddWithValue("@NroGrupo", NroGrupo)
                .Parameters.AddWithValue("@FechaToma", FechaToma)
                .Parameters.AddWithValue("@GradoAreaProfesor", GradoAreaProfesor)
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

    Public Shared Sub DesAsignar(ByVal NroGrupo As String, IdAsignatura As String, Ci As String)
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM `Tiene_Ag` WHERE NroGrupo=@NroGrupo and IdAsignatura=@IdAsignatura and CiPersona=@CiPersona;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@NroGrupo", NroGrupo)
                .Parameters.AddWithValue("@IdAsignatura", IdAsignatura)
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

    Public Shared Function GetAsignadasDocente(ByVal Ci As String) As Object
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT IdAsignatura, IdGrupo, FechaToma, Grado FROM `Tiene_Ag`, `Grupo` WHERE Tiene_Ag.CiPersona=@CiPersona and Grupo.NroGrupo=Tiene_Ag.NroGrupo;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@CiPersona", Ci)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

End Class
