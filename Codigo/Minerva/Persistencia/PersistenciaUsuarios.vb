Imports MySql.Data.MySqlClient
Imports System.Data

Public Class PersistenciaUsuarios

    Public Shared Sub Add(Ci As String, TipoUsuario As String, ContraseniaUsuario As String, AprobacionUsuario As Boolean)
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "INSERT INTO `Usuario` VALUES (@CiPersona, @TipoUsuario, @ContraseniaUsuario, @AprobacionUsuario);"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@CiPersona", Ci)
                .Parameters.AddWithValue("@TipoUsuario", TipoUsuario)
                .Parameters.AddWithValue("@ContraseniaUsuario", ContraseniaUsuario)
                .Parameters.AddWithValue("@AprobacionUsuario", AprobacionUsuario)
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

    Public Shared Sub Del(Ci As String)
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM `Usuario` WHERE CiPersona=@CiPersona"
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

    Public Shared Sub Edit(Ci As String, TipoUsuario As String, ContraseniaUsuario As String, AprobacionUsuario As Boolean)
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "UPDATE `Usuario` SET TipoUsuario=@TipoUsuario, ContraseniaUsuario=@ContraseniaUsuario, AprobacionUsuario=@AprobacionUsuario WHERE CiPersona=@CiPersona;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@CiPersona", Ci)
                .Parameters.AddWithValue("@TipoUsuario", TipoUsuario)
                .Parameters.AddWithValue("@ContraseniaUsuario", ContraseniaUsuario)
                .Parameters.AddWithValue("@AprobacionUsuario", AprobacionUsuario)
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
                .CommandText = "SELECT Usuario.*, NombrePersona, ApellidoPersona from Usuario, Persona where Usuario.CiPersona=Persona.CiPersona and Usuario.CiPersona=@Ci;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@Ci", Ci)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Function GetNombre(Ci As String) As Object
        Dim Nombre As String = ""
        Dim Apellido As String = ""

        Dim resultadosPersistencia As Object = GetInfo(Ci)
        Dim reader As MySqlDataReader = resultadosPersistencia(0)
        While reader.Read()
            Nombre = reader("NombrePersona")
            Apellido = reader("ApellidoPersona")
        End While

        Return {Nombre, Apellido}
    End Function

    Public Shared Function Login(Ci As String, Contraseña As String) As Object
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Usuario` WHERE CiPersona=@Ci AND ContraseniaUsuario=@Contrasenia;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@Ci", Ci)
                .Parameters.AddWithValue("@Contrasenia", Contraseña)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            Return {reader, conexion}
        End Using
    End Function

    Public Shared Function CantAdministradores() As Integer
        Dim cantidadAdministradores As Integer
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "select COUNT(*) as 'Cantidad' from Usuario WHERE Usuario.TipoUsuario='Administrador' and Usuario.AprobacionUsuario is True;"
                .CommandType = CommandType.Text
            End With
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                cantidadAdministradores = Integer.Parse(reader("Cantidad"))
            End While
            reader.Close()
        End Using
        conexion.Close()
        Return cantidadAdministradores
    End Function

    Public Shared Function CantSinAprobar() As Integer
        Dim cantidadAprobar As Integer = 0
        Dim conexion As New Conexion()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "select COUNT(*) as 'Cantidad' from Usuario WHERE Usuario.AprobacionUsuario=False and not Usuario.CiPersona='-1';"
                .CommandType = CommandType.Text
            End With
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                cantidadAprobar = Integer.Parse(reader("Cantidad"))
            End While
            reader.Close()
        End Using
        conexion.Close()

        Return cantidadAprobar
    End Function
End Class
