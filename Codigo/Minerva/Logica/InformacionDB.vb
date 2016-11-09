Imports MySql.Data.MySqlClient
Imports System.Data

Public Class InformacionDB
    Public Shared Function GetSalones() As Object
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Salon` where not IdSalon='-1';"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Function GetGrupos() As Object
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT Grupo.*, Turno.NombreTurno FROM `Grupo`, `Turno` WHERE Grupo.IdTurno=Turno.IdTurno;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Function GetCursos() As Object
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Curso`;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Function GetOrientaciones(ByVal IdCurso As String) As Object
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Orientacion` WHERE IdCurso=@IdCurso;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IdCurso", IdCurso)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Function GetGrados(ByVal IdOrientacion As String) As Object
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "select * from Trayecto where IdOrientacion=@IdOrientacion;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IdOrientacion", IdOrientacion)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Function GetTurnos() As Object
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Turno`;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Function GetAdscriptos() As Object
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "select * from Adscriptos;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Function GetUsuarios() As Object
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Usuario`;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Function GetAreasOrientacionByGrado(ByVal IdOrientacion As String, Grado As String) As Object
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "select DISTINCT Area.IdArea, NombreArea from (select Asignatura.IdArea from Tiene_Ta, Asignatura where Tiene_Ta.IdAsignatura=Asignatura.IdAsignatura and Tiene_Ta.IdOrientacion=@IdOrientacion and Tiene_Ta.Grado=@Grado) Orientacion, Area where Orientacion.IdArea=Area.IdArea;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IdOrientacion", IdOrientacion)
                .Parameters.AddWithValue("@Grado", Grado)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Function GetDocentes() As Object
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT Profesor.CiPersona, Persona.NombrePersona, Persona.ApellidoPersona FROM `Profesor`, `Persona` where Profesor.CiPersona=Persona.CiPersona;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Function GetAsignaturasForGrupo(ByVal IdGrupo As String, Grado As String, IdArea As String) As Object
        Dim conexion As New Conexion()

        Dim IdOrientacion As String = PersistenciaGrupos.GetOrientacion(IdGrupo, Grado)

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "select Asignatura.* from (select DISTINCT Area.IdArea, NombreArea from (select Asignatura.IdArea from Tiene_Ta, Asignatura where Tiene_Ta.IdAsignatura=Asignatura.IdAsignatura and Tiene_Ta.IdOrientacion=@IdOrientacion) Orientacion, Area where Orientacion.IdArea=Area.IdArea) Areas, Asignatura, Tiene_Ta where Asignatura.IdArea=Areas.IdArea and Tiene_Ta.IdAsignatura=Asignatura.IdAsignatura and Tiene_Ta.Grado=@Grado and IdOrientacion=@IdOrientacion and Asignatura.IdArea=@IdArea;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@Grado", Grado)
                .Parameters.AddWithValue("@IdOrientacion", IdOrientacion)
                .Parameters.AddWithValue("@IdArea", IdArea)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using

        ' 
        ' SELECT IdOrientacion from Grupo where CONCAT(Grado, ' ', IdGrupo)=@Grupo;

    End Function
End Class
