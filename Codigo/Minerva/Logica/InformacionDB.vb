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

    Public Shared Function GetGrupos(Optional IdCurso As String = Nothing, Optional IdTurno As String = Nothing) As Object
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                If Not IsNothing(IdCurso) And Not IsNothing(IdTurno) Then
                    .CommandText = "SELECT Grupo.*, Turno.NombreTurno from `Grupo`, `Orientacion`, `Turno` where Grupo.IdTurno=@IdTurno and Grupo.IdTurno=Turno.IdTurno and Orientacion.IdOrientacion=Grupo.IdOrientacion and Orientacion.IdCurso=@IdCurso;"
                    .Parameters.AddWithValue("@IdCurso", IdCurso)
                    .Parameters.AddWithValue("@IdTurno", IdTurno)
                ElseIf Not IsNothing(IdCurso) Then
                    .CommandText = "SELECT Grupo.*, Turno.NombreTurno from `Grupo`, `Orientacion`, `Turno` where Grupo.IdTurno=Turno.IdTurno and Orientacion.IdOrientacion=Grupo.IdOrientacion and Orientacion.IdCurso=@IdCurso;"
                    .Parameters.AddWithValue("@IdCurso", IdCurso)
                ElseIf Not IsNothing(IdTurno) Then
                    .CommandText = "SELECT Grupo.*, Turno.NombreTurno from `Grupo`, `Turno` where Grupo.IdTurno=@IdTurno and Grupo.IdTurno=Turno.IdTurno;"
                    .Parameters.AddWithValue("@IdTurno", IdTurno)
                Else
                    .CommandText = "SELECT Grupo.*, Turno.NombreTurno FROM `Grupo`, `Turno` WHERE Grupo.IdTurno=Turno.IdTurno;"
                End If
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

    Public Shared Function GetOrientaciones(IdCurso As String) As Object
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

    Public Shared Function GetGrados(IdOrientacion As String) As Object
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

    Public Shared Function GetAreasOrientacionByGrado(IdOrientacion As String, Grado As String) As Object
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

    Public Shared Function GetAsignaturasForGrupo(IdGrupo As String, Grado As String, IdArea As String) As Object
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
    End Function

    Public Shared Function GetAsignaturasReparticion(IdGrupo As String, Grado As String) As Object
        Dim conexion As New Conexion()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "select T.* from Tiene_Ta T, Grupo G, Asignatura A where T.IdAsignatura=A.IdAsignatura and T.IdOrientacion=G.IdOrientacion and G.IdGrupo=@IdGrupo and G.Grado=@Grado and T.Grado=G.Grado order by `CargaHoraria` DESC;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IdGrupo", IdGrupo)
                .Parameters.AddWithValue("@Grado", Grado)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function
End Class
