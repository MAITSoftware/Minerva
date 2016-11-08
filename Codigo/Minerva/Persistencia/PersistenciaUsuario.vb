Imports MySql.Data.MySqlClient
Imports System.Data

Public Class PersistenciaUsuario

    Public Shared Sub Add(ByVal Ci As String, TipoUsuario As String, ContraseniaUsuario As String, AprobacionUsuario As Boolean)
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

    Public Shared Function Login(ByVal Ci As String, Contraseña As String) As Object
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

End Class
