Imports MySql.Data.MySqlClient
Imports System.Data

Public Class frmAdminGrupos
    ' Clase principal para la administración de grupos

    Dim totalGrupos As Integer = 0
    Dim prevSelect As String
    Private DB As DB

    Private Sub frmAdminGrupos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarGrupos()

        controlesHabilitados(True)
        rellenarCombos()

        cmbOrientacion.Enabled = False
    End Sub

    Private Sub cargarGrupos()
        pnlGrupos.Controls.Clear()
        totalGrupos = 0
        lblCantidadGrupos.Text = "(" + totalGrupos.ToString() + ")"

        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT *, Turno.NombreTurno FROM `Grupo`, `Turno` WHERE Grupo.IDTurno=Turno.IDTurno;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                agregarGrupo(reader("IDGrupo"), reader("IDTrayecto").ToString(), reader("IDTurno"), reader("IDTrayecto").ToString() & " " & reader("IDGrupo") & ControlChars.NewLine & " (" & reader("NombreTurno") & ")", reader("NombreTurno"))
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Private Sub agregarGrupo(ByVal IDGrupo As String, ByVal Trayecto As String, ByVal IDTurno As String, ByVal idTexto As String, ByVal nombreTurno As String)
        ' Basicamente copio la plantilla a un nuevo panel
        Dim pnlTemporal As New Panel
        Dim btnGrupo As New Button
        Dim btnEliminar As New Button

        pnlTemporal.Size = pnlGrupoPlantilla.Size
        btnGrupo.Size = btnGrupoPlantilla.Size
        btnGrupo.FlatStyle = btnGrupoPlantilla.FlatStyle
        btnGrupo.ForeColor = btnGrupoPlantilla.ForeColor
        btnGrupo.Text = idTexto
        btnGrupo.Margin = btnGrupoPlantilla.Margin
        btnGrupo.TextAlign = btnGrupoPlantilla.TextAlign
        btnGrupo.BackColor = btnGrupoPlantilla.BackColor
        btnGrupo.Location = btnGrupoPlantilla.Location
        btnGrupo.Cursor = btnGrupoPlantilla.Cursor
        btnGrupo.Font = btnGrupoPlantilla.Font

        btnGrupo.Tag = {IDGrupo, Trayecto, IDTurno, nombreTurno}
        AddHandler btnGrupo.Click, AddressOf verGrupo

        btnEliminar.Size = btnEliminarPlantilla.Size
        btnEliminar.FlatStyle = btnEliminarPlantilla.FlatStyle
        btnEliminar.ForeColor = btnEliminarPlantilla.ForeColor
        btnEliminar.Text = btnEliminarPlantilla.Text
        btnEliminar.BackColor = btnEliminarPlantilla.BackColor
        btnEliminar.Location = btnEliminarPlantilla.Location
        btnEliminar.Cursor = btnEliminarPlantilla.Cursor

        btnEliminar.Tag = {IDGrupo, Trayecto, IDTurno, nombreTurno}
        AddHandler btnEliminar.Click, AddressOf eliminarGrupo

        pnlTemporal.Controls.Add(btnEliminar)
        pnlTemporal.Controls.Add(btnGrupo)

        pnlGrupos.Controls.Add(pnlTemporal)

        totalGrupos += 1
        lblCantidadGrupos.Text = "(" + totalGrupos.ToString() + ")"
    End Sub

    Private Sub controlesHabilitados(ByVal habilitado As Boolean)
        txtIDGrupo.Enabled = habilitado
        txtIDGrupo.Text = ""

        cmbTurno.Enabled = habilitado
        cmbTurno.SelectedIndex = -1

        prevSelect = ""
        cmbCurso.Enabled = habilitado
        cmbCurso.SelectedIndex = -1
        cmbOrientacion.Enabled = habilitado
        cmbOrientacion.SelectedIndex = -1
        numGrado.Enabled = habilitado
        numGrado.Value = 1
        chkDiscapacitado.Enabled = True
        chkDiscapacitado.Checked = False
    End Sub

    Private Sub btnNuevoGrupo_Click(sender As Object, e As EventArgs) Handles btnNuevoGrupo.Click
        controlesHabilitados(True)
        lblNuevoGrupo.Text = "Nuevo grupo"
        btnNuevoGrupo.Visible = False
        btnAgregar.Visible = True
        btnAgregar.Text = "Agregar grupo"
        cmbOrientacion.Enabled = False
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        checkDatos()
    End Sub

    Private Sub checkDatos()
        If String.IsNullOrWhiteSpace(txtIDGrupo.Text) Then
            MessageBox.Show("Debe ingresar un ID de grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        If String.IsNullOrWhiteSpace(cmbCurso.Text) Then
            MessageBox.Show("Debe seleccionar un curso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        If String.IsNullOrWhiteSpace(cmbOrientacion.Text) Then
            MessageBox.Show("Debe seleccionar una orientación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        If String.IsNullOrWhiteSpace(cmbTurno.Text) Then
            MessageBox.Show("Debe seleccionar un turno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        actualizarDB()
    End Sub

    Private Sub eliminarGrupo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim grupo As String
        grupo = sender.Tag(1) + " " + sender.Tag(0) + " (" + sender.Tag(3) + ")"
        Dim result As Integer = MessageBox.Show("¿Está seguro de que desea eliminar el grupo '" + grupo + "'?", "Eliminar grupo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If

        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM `Grupo` WHERE IDGrupo=@IDGrupo and IDTurno=@IDTurno and IDTrayecto=@IDTrayecto;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IDGrupo", sender.Tag(0))
                .Parameters.AddWithValue("@IDTurno", sender.Tag(2))
                .Parameters.AddWithValue("@IDTrayecto", sender.Tag(1))
            End With
            totalGrupos -= 1
            cmd.ExecuteNonQuery()
            conexion.Close() 'Cierra la conexión
            cargarGrupos()
            btnNuevoGrupo_Click(Nothing, Nothing)
            MessageBox.Show("Grupo '" + grupo + "' eliminado.", "Grupo eliminado.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using

    End Sub

    Private Sub actualizarDB()
        Dim conexion As New DB()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO `Grupo` VALUES  (@IDGrupo, @Discapacitado, -1, @IDTrayecto, @IDTurno, @IDOrientacion, @IDCurso);"
                Console.WriteLine(cmbTurno.SelectedIndex)
                .Parameters.AddWithValue("@IDGrupo", txtIDGrupo.Text)
                .Parameters.AddWithValue("@Discapacitado", chkDiscapacitado.Checked)
                .Parameters.AddWithValue("@IDTrayecto", numGrado.Value.ToString())
                .Parameters.AddWithValue("@IDTurno", cmbTurno.SelectedIndex + 1)
                .Parameters.AddWithValue("@IDOrientacion", cmbOrientacion.Text.Substring(0, cmbOrientacion.Text.IndexOf(" (")).Trim())
                .Parameters.AddWithValue("@IDCurso", cmbCurso.Text.Substring(0, cmbCurso.Text.IndexOf(" (")).Trim())
            End With

            Try
                cmd.ExecuteNonQuery()
                conexion.Close()

                cargarGrupos()
                MessageBox.Show("Grupo agregado correctamente", "Grupo agregado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                btnNuevoGrupo_Click(Nothing, Nothing)
            Catch ex As Exception
                If ex.ToString().Contains("Duplicate") Then
                    MessageBox.Show("Ya existe un grupo con el mismo trayecto y ID en dicho turno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                Console.WriteLine(ex.ToString())
            End Try
        End Using
    End Sub

    Private Sub verGrupo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        previsualizarGrupo(sender.Tag(0), sender.Tag(1).ToString(), sender.Tag(2))
    End Sub

    Private Sub previsualizarGrupo(ByVal id As String, ByVal grado As String, ByVal turno As String)
        btnNuevoGrupo.Visible = True
        btnAgregar.Visible = False
        lblNuevoGrupo.Text = "Previsualizar grupo"

        controlesHabilitados(False)
        cargarDatos({id, grado, turno})
    End Sub

    Private Sub cargarDatos(ByVal grupo As Object)
        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT *, Curso.NombreCurso, Orientacion.NombreOrientacion FROM `Grupo`, `Curso`, `Orientacion` WHERE Grupo.IDGrupo=@IDGrupo and Grupo.IDTurno=@IDTurno and Grupo.IDTrayecto=@IDTrayecto and Curso.IDCurso=Grupo.IDCurso and Orientacion.IDOrientacion=Grupo.IDOrientacion;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IDGrupo", grupo(0))
                .Parameters.AddWithValue("@IDTrayecto", grupo(1))
                .Parameters.AddWithValue("@IDTurno", grupo(2))
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                txtIDGrupo.Text = reader("IDGrupo")
                numGrado.Value = Integer.Parse(reader("IDTrayecto"))
                cmbCurso.SelectedIndex = cmbCurso.FindStringExact(reader("IDCurso").ToString() & " (" & reader("NombreCurso") & ")")
                cargarOrientaciones()
                chkDiscapacitado.Checked = reader("Discapacitado")
                cmbTurno.SelectedIndex = reader("IDTurno") - 1
                cmbOrientacion.SelectedIndex = cmbOrientacion.FindStringExact(reader("IDOrientacion").ToString() & " (" & reader("NombreOrientacion") & ")")
                cmbOrientacion.Enabled = False
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Private Sub rellenarCombos()
        ' Llena los combos con los datos de la DB.
        Dim conexion As New DB()

        ' Primero los cursos
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Curso`;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                cmbCurso.Items.Add(reader("IDCurso").ToString() & " (" & reader("NombreCurso") & ")")
            End While
            reader.Close()
        End Using

        ' Segundo los turnos
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Turno`;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                cmbTurno.Items.Add(reader("NombreTurno"))
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Private Sub cargarOrientaciones()
        Dim conexion As New DB()
        cmbOrientacion.Items.Clear()
        ' Por último las orientaciones
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Orientacion` WHERE IDCurso=@IDCurso;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IDCurso", cmbCurso.Text.Substring(0, cmbCurso.Text.IndexOf(" (")).Trim())
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                cmbOrientacion.Items.Add(reader("IDOrientacion").ToString() & " (" & reader("NombreOrientacion") & ")")
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Private Sub cmbCurso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCurso.SelectedIndexChanged
        If cmbCurso.Text.Equals(prevSelect) Then
            Return
        End If
        cmbOrientacion.SelectedIndex = -1
        cargarOrientaciones()
        cmbOrientacion.Enabled = False
        If Not String.IsNullOrWhiteSpace(cmbCurso.Text) Then
            cmbOrientacion.Enabled = True
        End If
        prevSelect = cmbCurso.Text
    End Sub

    Private Sub txtIDGrupo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIDGrupo.KeyPress
        If e.KeyChar = " " Then
            e.KeyChar = Nothing
        End If
    End Sub
End Class
