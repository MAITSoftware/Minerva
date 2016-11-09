Imports MySql.Data.MySqlClient
Imports System.Data

Public Class PersistenciaAsignaturas
    Public Shared Sub Asignar(IdAsignatura As String, NroGrupo As String, FechaToma As String, GradoAreaProfesor As Integer, Ci As String)
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

    Public Shared Sub DesAsignar(NroGrupo As String, IdAsignatura As String, Ci As String)
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

    Public Shared Function GetAsignadasDocente(Ci As String) As Object
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

    Public Shared Function GetAllForGrupo(NroGrupo As String)
        Dim IdOrientacion As String = PersistenciaGrupos.GetOrientacion(NroGrupo:=NroGrupo)
        Dim Grado As String = PersistenciaGrupos.GetGrado(NroGrupo)

        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "select Tiene_Ta.*, NombreAsignatura from Tiene_Ta, Asignatura where IdOrientacion=@IdOrientacion and Grado=@Grado and Tiene_Ta.IdAsignatura=Asignatura.IdAsignatura;"
                .Parameters.AddWithValue("@IdOrientacion", IdOrientacion)
                .Parameters.AddWithValue("@Grado", Grado)
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Function GetProfesor(IdAsignatura As String, NroGrupo As String) As String
        Dim NombreProfesor As String = "Sin profesor"
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "select CONCAT(NombrePersona, ' ', ApellidoPersona) as Profesor from Tiene_Ag T, Persona P where T.IdAsignatura=@IdAsignatura and T.NroGrupo=@NroGrupo and P.CiPersona=T.CiPersona;"
                .Parameters.AddWithValue("@IdAsignatura", IdAsignatura)
                .Parameters.AddWithValue("@NroGrupo", NroGrupo)
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                NombreProfesor = reader("Profesor")
            End While
            reader.Close()
        End Using

        conexion.Close()

        Return NombreProfesor
    End Function
End Class
