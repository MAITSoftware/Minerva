Imports MySql.Data.MySqlClient
Imports System.Data

Public Class PersistenciaGrupos
    Public Shared Sub Add(IdGrupo As String, Discapacitado As Boolean, IdSalon As String, IdTurno As Integer, Grado As String, IdOrientacion As String, CiAdscripto As String)
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
    Public Shared Sub Edit(IdGrupo As String, Discapacitado As Boolean, IdSalon As String, IdTurno As Integer, Grado As String, CiAdscripto As String)
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

    Public Shared Sub Del(NroGrupo As String)
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

    Public Shared Function GetInfo(nroGrupo As String) As Object
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT Grupo.*, Curso.*, Orientacion.*, CONCAT(Adscriptos.CiPersona, ' - ', Adscripto) as NombreAdscripto FROM `Grupo`, `Curso`, `Orientacion`, `Adscriptos` WHERE Grupo.CiPersona=Adscriptos.CiPersona and Grupo.NroGrupo=@NroGrupo and Orientacion.IdCurso=Curso.IdCurso and Grupo.IdOrientacion=Orientacion.IdOrientacion;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@NroGrupo", nroGrupo)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Function GetNroGrupo(Grupo As String) As String
        Dim NroGrupo As String = Nothing

        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "select * from Grupo where CONCAT(Grado, ' ', IdGrupo)=@Grupo;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@Grupo", Grupo)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                NroGrupo = reader("NroGrupo")
            End While
            reader.Close()
            conexion.Close()

            Return NroGrupo
        End Using
    End Function

    Public Shared Function GetExiste(Grupo As String) As Boolean
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

    Public Shared Function GetGrado(NroGrupo As String) As String
        Dim conexion As New Conexion()
        Dim grado As String = ""

        Dim resultadosPersistencia As Object = GetInfo(NroGrupo)

        Dim reader As MySqlDataReader = resultadosPersistencia(0)
        While reader.Read()
            grado = reader("Grado")
        End While
        reader.Close()

        resultadosPersistencia(1).Close()

        Return grado
    End Function

    Public Shared Function GetOrientacion(Optional IdGrupo As String = "", Optional Grado As String = "", Optional NroGrupo As String = Nothing) As String
        Dim IdOrientacion As String = Nothing

        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                If IsNothing(NroGrupo) Then
                    .CommandText = "SELECT IdOrientacion from Grupo where IdGrupo=@IdGrupo and Grado=@Grado;"
                    .Parameters.AddWithValue("@IdGrupo", IdGrupo)
                    .Parameters.AddWithValue("@Grado", Grado)
                Else
                    .CommandText = "SELECT IdOrientacion from Grupo where NroGrupo=@NroGrupo;"
                    .Parameters.AddWithValue("@NroGrupo", NroGrupo)
                End If
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                IdOrientacion = reader("IdOrientacion")
            End While
            reader.Close()
            conexion.Close()

            Return IdOrientacion
        End Using
    End Function

    Public Shared Function GetAsignaturaTomada(IdAsignatura As String, NroGrupo As String) As Boolean
        Dim AsignaturaTomada As Boolean = False

        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * from `Tiene_Ag` WHERE IdAsignatura=@IdAsignatura and Tiene_Ag.NroGrupo=@NroGrupo;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IdAsignatura", IdAsignatura)
                .Parameters.AddWithValue("@NroGrupo", NroGrupo)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                AsignaturaTomada = True
            End While
            reader.Close()
            conexion.Close()

            Return AsignaturaTomada
        End Using
    End Function

    Public Shared Function GetDetalles(NroGrupo As String) As Object
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "select A.Adscripto, D.*, T.IdTurno, CONCAT(G.Grado, ' ', G.IdGrupo) as Grupo from DatosGrupos D, Turno T, Adscriptos A, Grupo G where A.CiPersona=D.CiPersona and T.NombreTurno=D.NombreTurno and D.Grado=G.Grado and D.IdGrupo=G.IdGrupo and G.NroGrupo=@NroGrupo;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@NroGrupo", NroGrupo)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Function GetTurno(StringGrupo As String) As String
        Dim IdTurno As String = Nothing
        Dim NroGrupo As String = GetNroGrupo(StringGrupo)

        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT IdTurno from Grupo where NroGrupo=@NroGrupo;"
                .Parameters.AddWithValue("@NroGrupo", NroGrupo)
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                IdTurno = reader("IdTurno")
            End While
            reader.Close()
            conexion.Close()

            Return IdTurno
        End Using
    End Function
End Class
