Imports MySql.Data.MySqlClient
Imports System.Data

Public Class PersistenciaGrupos
    Public Shared Sub Add(ByVal IdGrupo As String, Discapacitado As Boolean, IdSalon As String, IdTurno As Integer, Grado As String, IdOrientacion As String, CiAdscripto As String)
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO `Grupo` VALUES (Null, @IdGrupo, @Discapacitado, @Idsalon, @IdTurno, @Grado, @IDOrientacion, @CiAdscripto);"
                .Parameters.AddWithValue("@IdGrupo", IdGrupo)
                .Parameters.AddWithValue("@Discapacitado", Discapacitado)
                .Parameters.AddWithValue("@IdSalon", IdSalon)
                .Parameters.AddWithValue("@IdTurno", IdTurno)
                .Parameters.AddWithValue("@Grado", Grado)
                .Parameters.AddWithValue("@IdOrientacion", IdOrientacion)
                .Parameters.AddWithValue("@CiAdscripto", CiAdscripto)
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

    Public Shared Sub Edit(ByVal IdGrupo As String, Discapacitado As Boolean, IdSalon As String, IdTurno As Integer, Grado As String, CiAdscripto As String)
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text
                .CommandText = "UPDATE `Grupo` SET CiPersona=@CiAdscripto, Discapacitado=@Discapacitado, IdSalon=@IdSalon where Grado=@Grado and IdGrupo=@IdGrupo"
                .Parameters.AddWithValue("@IdGrupo", IdGrupo)
                .Parameters.AddWithValue("@Discapacitado", Discapacitado)
                .Parameters.AddWithValue("@IdSalon", IdSalon)
                .Parameters.AddWithValue("@IdTurno", IdTurno)
                .Parameters.AddWithValue("@Grado", Grado)
                .Parameters.AddWithValue("@CiAdscripto", CiAdscripto)
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

    Public Shared Sub Del(ByVal NroGrupo As String)
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM `Grupo` WHERE NroGrupo=@NroGrupo;"
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

    Public Shared Function GetInfo(ByVal nroGrupo As String)
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT *, Curso.NombreCurso, Orientacion.NombreOrientacion, CONCAT(Adscriptos.CiPersona, ' - ', Adscripto) as NombreAdscripto FROM `Grupo`, `Curso`, `Orientacion`, `Adscriptos` WHERE Grupo.CiPersona=Adscriptos.CiPersona and Grupo.NroGrupo=@NroGrupo and Orientacion.IdCurso=Curso.IdCurso and Grupo.IdOrientacion=Orientacion.IdOrientacion;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@NroGrupo", nroGrupo)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Function GetExiste(ByVal Grupo As String) As Boolean
        Dim conexion As New Conexion()
        Dim existe As Boolean = False

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "select * from Grupo where CONCAT(Grado, ' ', IdGrupo)=@Grupo"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@Grupo", Grupo)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                existe = True
            End While
            reader.Close()
        End Using
        conexion.Close()

        Return existe
    End Function
End Class
