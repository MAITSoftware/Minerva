Imports MySql.Data.MySqlClient
Imports System.Data

Public Class frmAdminDocentes
    ' Clase principal para la administracion de docentes

    Dim totalDocentes As Integer = 0
    Dim docentePreview As Object = New Button()
    Dim prevSelect As String
    Private DB As DB

    Private Sub frmAdminDocentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lstAsignaturas.FullRowSelect = True
        cargarDocentes()
        rellenarCombos()
    End Sub

    Private Sub rellenarCombos()
        ' Llena los combos con los datos de la DB.
        Dim conexion As New DB()

        ' Primero lás áreas
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Area`;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                cmbArea.Items.Add(reader("IDArea").ToString() & " (" & reader("NombreArea") & ")")
            End While
            reader.Close()
        End Using

        ' Segundo los grupos
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT *, Turno.NombreTurno FROM `Grupo`, `Turno` WHERE Grupo.IDTurno=Turno.IDTurno;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                cmbGrupo.Items.Add(reader("IDTrayecto") & " " & reader("IDGrupo") & " (" & reader("NombreTurno") & ")")
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub
    Private Sub cargarDocentes()
        pnlDocentes.Controls.Clear()
        totalDocentes = 0
        lblCantidadDocentes.Text = "(" + totalDocentes.ToString() + ")"

        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Profesor`;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                agregarDocente(reader("CiPersona"), reader("CiPersona").ToString() & ControlChars.NewLine & " (" & reader("NombreProfesor") & " " & reader("ApellidoProfesor") & ")")
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Private Sub agregarDocente(ByVal ciDocente As String, ByVal txtDocente As String)
        ' Basicamente copio la plantilla a un nuevo panel
        Dim pnlTemporal As New Panel
        Dim btnDocente As New Button
        Dim btnEditar, btnEliminar As New Button

        pnlTemporal.Size = pnlDocentePlantilla.Size
        btnDocente.Size = btnDocentePlantilla.Size
        btnDocente.FlatStyle = btnDocentePlantilla.FlatStyle
        btnDocente.ForeColor = btnDocentePlantilla.ForeColor
        btnDocente.Text = txtDocente
        btnDocente.BackColor = btnDocentePlantilla.BackColor
        btnDocente.Location = btnDocentePlantilla.Location
        btnDocente.Cursor = btnDocentePlantilla.Cursor
        btnDocente.Font = btnDocentePlantilla.Font

        btnDocente.Tag = ciDocente
        AddHandler btnDocente.Click, AddressOf verDocente

        btnEditar.Size = btnEditarPlantilla.Size
        btnEditar.FlatStyle = btnEditarPlantilla.FlatStyle
        btnEditar.ForeColor = btnEditarPlantilla.ForeColor
        btnEditar.Text = btnEditarPlantilla.Text
        btnEditar.BackColor = btnEditarPlantilla.BackColor
        btnEditar.Location = btnEditarPlantilla.Location
        btnEditar.Cursor = btnEditarPlantilla.Cursor

        btnEditar.Tag = ciDocente
        AddHandler btnEditar.MouseUp, AddressOf mnuEditarDocente

        btnEliminar.Size = btnEliminarPlantilla.Size
        btnEliminar.FlatStyle = btnEliminarPlantilla.FlatStyle
        btnEliminar.ForeColor = btnEliminarPlantilla.ForeColor
        btnEliminar.Text = btnEliminarPlantilla.Text
        btnEliminar.BackColor = btnEliminarPlantilla.BackColor
        btnEliminar.Location = btnEliminarPlantilla.Location
        btnEliminar.Cursor = btnEliminarPlantilla.Cursor

        btnEliminar.Tag = {ciDocente, txtDocente.Replace(ControlChars.NewLine, " ")}
        AddHandler btnEliminar.Click, AddressOf eliminarDocente

        pnlTemporal.Controls.Add(btnEditar)
        pnlTemporal.Controls.Add(btnEliminar)
        pnlTemporal.Controls.Add(btnDocente)

        pnlDocentes.Controls.Add(pnlTemporal)

        totalDocentes += 1
        lblCantidadDocentes.Text = "(" + totalDocentes.ToString() + ")"
    End Sub



    Public Sub mnuEditarDocente(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles btnEditarPlantilla.MouseUp
        DatosDelDocenteToolStripMenuItem.Tag = {sender.Parent, sender.Tag}
        MateriasDelDocenteToolStripMenuItem.Tag = {sender.Parent, sender.Tag}
        mnuEdicionDocente.Show(sender, New Point(e.X, e.Y))
    End Sub

    Private Sub actualizarDB()
        Dim conexion As New DB()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text

                If btnAgregarDocente.Text.StartsWith("Agregar docente") Then
                    .CommandText = "INSERT INTO `Profesor` VALUES  (@CiPersona, @GradoProfesor, @NombreProfesor, @ApellidoProfesor);"
                Else
                    .CommandText = "UPDATE `Profesor` SET NombreProfesor=@NombreProfesor, ApellidoProfesor=@ApellidoProfesor, GradoProfesor=@GradoProfesor WHERE CiPersona=@CiPersona;"
                End If

                .Parameters.AddWithValue("@CiPersona", txtCI.Text)
                .Parameters.AddWithValue("@NombreProfesor", txtNombre.Text)
                .Parameters.AddWithValue("@ApellidoProfesor", txtApellido.Text)
                .Parameters.AddWithValue("@GradoProfesor", numGrado.Value)
            End With

            Try
                Dim subConexion As New DB()
                If btnAgregarDocente.Text.StartsWith("Agregar docente") Then
                    Using subCmd As New MySqlCommand()
                        With subCmd
                            .Connection = conexion.Conn
                            .CommandText = "INSERT INTO `Persona` VALUES (@CiPersona);"
                            .CommandType = CommandType.Text
                            .Parameters.AddWithValue("@CiPersona", txtCI.Text)
                        End With
                        subCmd.ExecuteNonQuery()
                        subConexion.Close()
                    End Using
                End If

                cmd.ExecuteNonQuery()
                conexion.Close()

                cargarDocentes()
                If btnAgregarDocente.Text.StartsWith("Agregar docente") Then
                    MessageBox.Show("Docente agregado correctamente", "Docente agregado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    editarMateriasDocente(txtCI.Text)
                Else
                    MessageBox.Show("Información de docente actualizada correctamente", "Docente actualizado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    previsualizarDocente(txtCI.Text)
                End If
            Catch ex As Exception
                If ex.ToString().Contains("Duplicate") Then
                    MessageBox.Show("Ya existe un docente (o usuario!) con esa CI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Try
        End Using

    End Sub

    Private Sub btnAgregarDocentes_Click(sender As Object, e As EventArgs) Handles btnAgregarDocente.Click
        checkDatos()
    End Sub

    Private Sub checkDatos()
        If String.IsNullOrWhiteSpace(txtCI.Text) Then
            MessageBox.Show("Debe ingresar una CI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtNombre.Text) Then
            MessageBox.Show("Debe ingresar un nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtApellido.Text) Then
            MessageBox.Show("Debe ingresar un apellido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        actualizarDB()
    End Sub

    Private Sub editarDocente(ByVal sender As System.Object)
        docentePreview.Enabled = True
        docentePreview = sender.Tag(0)
        docentePreview.Enabled = False
        lblNuevoDocente.Text = "Editar docente"
        btnCancelarEdicion.Visible = True
        btnAgregarDocente.Visible = True
        btnAgregarMateria.Visible = False
        btnAgregarAsignatura.Visible = False
        btnEliminarAsignatura.Visible = False
        btnNuevoDocente.Visible = False
        btnAgregarDocente.Text = "Guardar cambios"

        controlesHabilitados(True)
        cargarDatos(sender.Tag(1))
        txtCI.Enabled = False
        habilitarAsignaturas(False)
    End Sub

    Private Sub controlesHabilitados(ByVal habilitado As Boolean)
        txtCI.Enabled = habilitado
        txtCI.Text = ""
        txtNombre.Enabled = habilitado
        txtNombre.Text = ""
        txtApellido.Enabled = habilitado
        txtApellido.Text = ""
        numGrado.Enabled = habilitado
        numGrado.Value = 0
    End Sub

    Private Sub habilitarAsignaturas(ByVal habilitadas As Boolean)
        lstAsignaturas.Enabled = habilitadas
        lstAsignaturas.Items.Clear()
        btnAgregarAsignatura.Enabled = habilitadas
        btnEliminarAsignatura.Enabled = habilitadas
        cmbArea.Enabled = habilitadas
        cmbArea.SelectedIndex = -1
        cmbAsignatura.Enabled = False
        cmbAsignatura.SelectedIndex = -1
        cmbGrupo.Enabled = habilitadas
        cmbGrupo.SelectedIndex = -1
        numHsSemanales.Enabled = habilitadas
        numHsSemanales.Value = 1
        btnAgregarMateria.Enabled = habilitadas
    End Sub

    Private Sub verDocente(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDocentePlantilla.Click
        docentePreview.Enabled = True
        docentePreview = sender
        docentePreview.Enabled = False
        previsualizarDocente(sender.Tag)
        cargarMaterias(sender.Tag)
    End Sub

    Private Sub previsualizarDocente(ByVal ci As String)
        btnNuevoDocente.Visible = True
        btnAgregarDocente.Visible = False
        btnAgregarMateria.Visible = False
        btnCancelarEdicion.Visible = False
        btnAgregarAsignatura.Visible = False
        btnEliminarAsignatura.Visible = False

        lblNuevoDocente.Text = "Previsualizar docente"
        habilitarAsignaturas(False)

        controlesHabilitados(False)
        cargarDatos(ci)
    End Sub

    Private Sub cargarDatos(ByVal ciDocente As String)
        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Profesor` where CiPersona=@CiPersona;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@CiPersona", ciDocente)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                txtCI.Text = reader("CiPersona")
                txtNombre.Text = reader("NombreProfesor")
                txtApellido.Text = reader("ApellidoProfesor")
                numGrado.Value = reader("GradoProfesor")
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Private Sub btnNuevoDocente_Click(sender As Object, e As EventArgs) Handles btnNuevoDocente.Click, btnCancelarEdicion.Click
        controlesHabilitados(True)
        lblNuevoDocente.Text = "Nuevo docente"
        btnNuevoDocente.Visible = False
        btnAgregarMateria.Visible = False
        btnAgregarDocente.Visible = True
        btnAgregarAsignatura.Visible = False
        btnEliminarAsignatura.Visible = False
        btnAgregarDocente.Text = "Agregar docente " & ControlChars.NewLine & "y editar materias"
        btnCancelarEdicion.Visible = False
        docentePreview.Enabled = True
        docentePreview = New Button()
        btnAgregarAsignatura_Click(Nothing, Nothing)
        habilitarAsignaturas(False)
    End Sub

    Private Sub btnAgregarAsignatura_Leave(sender As Object, e As EventArgs) Handles btnAgregarAsignatura.MouseLeave
        btnAgregarAsignatura.BackgroundImage = My.Resources.agregar_normal()
    End Sub

    Private Sub btnAgregarAsignatura_Enter(sender As Object, e As EventArgs) Handles btnAgregarAsignatura.MouseEnter
        btnAgregarAsignatura.BackgroundImage = My.Resources.agregar_hover()
    End Sub

    Private Sub btnEliminarAsignatura_Leave(sender As Object, e As EventArgs) Handles btnEliminarAsignatura.MouseLeave
        btnEliminarAsignatura.BackgroundImage = My.Resources.borrar_normal()
    End Sub

    Private Sub btnEliminarAsignatura_Enter(sender As Object, e As EventArgs) Handles btnEliminarAsignatura.MouseEnter
        btnEliminarAsignatura.BackgroundImage = My.Resources.borrar_hover()
    End Sub

    Private Sub DatosDelDocenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatosDelDocenteToolStripMenuItem.Click
        editarDocente(sender)
    End Sub

    Private Sub btnAgregarAsignatura_Click(sender As Object, e As EventArgs) Handles btnAgregarAsignatura.Click
        cmbArea.SelectedIndex = -1
        cmbGrupo.SelectedIndex = -1
        numHsSemanales.Value = 1
    End Sub

    Private Sub cmbArea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbArea.SelectedIndexChanged
        If cmbArea.Text.Equals(prevSelect) Then
            Return
        End If
        cmbAsignatura.SelectedIndex = -1

        prevSelect = cmbArea.Text
        cmbAsignatura.Enabled = False
        If Not String.IsNullOrWhiteSpace(cmbArea.Text) Then
            cmbAsignatura.Enabled = True
        Else
            Return
        End If
        cargarAsignaturas()
    End Sub

    Private Sub cargarAsignaturas()
        Dim conexion As New DB()
        cmbAsignatura.Items.Clear()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `Asignatura` WHERE IDArea=@IDArea;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IDArea", cmbArea.Text.Substring(0, cmbArea.Text.IndexOf(" (")).Trim())
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                cmbAsignatura.Items.Add(reader("IDAsignatura").ToString() & " (" & reader("NombreAsignatura") & ")")
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Private Sub checkDatosMaterias()
        If String.IsNullOrWhiteSpace(cmbArea.Text) Then
            MessageBox.Show("Debe seleccionar un área.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        If String.IsNullOrWhiteSpace(cmbAsignatura.Text) Then
            MessageBox.Show("Debe seleccionar una asignatura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        If String.IsNullOrWhiteSpace(cmbGrupo.Text) Then
            MessageBox.Show("Debe seleccionar un grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        actualizarDBMaterias()
    End Sub
    Private Sub actualizarDBMaterias()
        Dim conexion As New DB()

        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO `AsignaturasTomadas` VALUES (@CiPersona, @IDAsignatura, @IDTrayecto, @IDGrupo, @cargaHoraria, @fechaAsignacion);"
                .Parameters.AddWithValue("@CiPersona", txtCI.Text)
                .Parameters.AddWithValue("@IDAsignatura", cmbAsignatura.Text.Substring(0, cmbAsignatura.Text.IndexOf(" (")).Trim())
                .Parameters.AddWithValue("@IDGrupo", cmbGrupo.Text.Substring(cmbGrupo.Text.IndexOf(" "), cmbGrupo.Text.IndexOf(" (")).Trim())
                .Parameters.AddWithValue("@IDTrayecto", cmbGrupo.Text.Substring(0, cmbGrupo.Text.IndexOf(" ")).Trim())
                .Parameters.AddWithValue("@cargaHoraria", numHsSemanales.Value)
                Dim d As DateTime = Now
                .Parameters.AddWithValue("@fechaAsignacion", d.ToString("yyyy-MM-dd"))
            End With

            Try
                cmd.ExecuteNonQuery()
                conexion.Close()

                cargarMaterias(txtCI.Text)
                ' Deshabilita la edición de datos del docente.
                lblNuevoDocente.Text = "Editar materias del docente"
                btnAgregarAsignatura_Click(Nothing, Nothing)
            Catch ex As Exception
                If ex.ToString().Contains("Duplicate") Then
                    MessageBox.Show("Esa materia ya ha sido asignada al grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Try
        End Using
    End Sub

    Private Sub btnAgregarMateria_Click(sender As Object, e As EventArgs) Handles btnAgregarMateria.Click
        checkDatosMaterias()
    End Sub

    Private Sub cargarMaterias(ByVal CI As String)
        lstAsignaturas.Items.Clear()
        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `AsignaturasTomadas` WHERE CiPersona=@CiPersona;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@CiPersona", CI)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                Dim item As New ListViewItem
                item = lstAsignaturas.Items.Add(reader("IDAsignatura").ToString())
                item.SubItems.Add(reader("IDTrayecto") & " " & reader("IDGrupo"))
                item.SubItems.Add(reader("cargaHoraria").ToString())
                item.SubItems.Add(reader("fechaAsignacion").ToString())
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Private Sub MateriasDelDocenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MateriasDelDocenteToolStripMenuItem.Click
        ' Deshabilita la edición de datos del docente.
        editarMateriasDocente(sender.Tag(1))
        docentePreview.Enabled = True
        docentePreview = sender.Tag(0)
        docentePreview.Enabled = False
    End Sub

    Private Sub editarMateriasDocente(ByVal CI As String)
        previsualizarDocente(CI)
        habilitarAsignaturas(True)
        btnAgregarMateria.Visible = True
        btnAgregarAsignatura.Visible = True
        btnEliminarAsignatura.Visible = False
        cargarMaterias(CI)
        lblNuevoDocente.Text = "Editar materias del docente"
    End Sub

    Private Sub eliminarDocente(sender As Object, e As EventArgs)
        Dim result As Integer = MessageBox.Show("¿Está seguro de que desea eliminar el docente '" + sender.Tag(1) + "'?", "Eliminar docente", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If

        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM `Profesor` WHERE CiPersona=@CiPersona;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@CiPersona", sender.Tag(0))
            End With
            Try
                totalDocentes -= 1
                cmd.ExecuteNonQuery()
                conexion.Close() 'Cierra la conexión
                Dim subConexion As New DB()
                Using subCmd As New MySqlCommand()
                    With subCmd
                        .Connection = subConexion.Conn
                        .CommandText = "DELETE FROM `Persona` WHERE CiPersona=@CiPersona;"
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@CiPersona", sender.Tag(0))
                    End With

                    subCmd.ExecuteNonQuery()
                    subConexion.Close()
                End Using
                cargarDocentes()
                btnNuevoDocente_Click(Nothing, Nothing)
                MessageBox.Show("Docente'" + sender.Tag(1) + "' eliminado.", "Docente eliminado.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("El docente no se puede eliminar, ya que tiene materias asignadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub lstAsignaturas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAsignaturas.SelectedIndexChanged
        btnEliminarAsignatura.Visible = False
        If lstAsignaturas.SelectedItems.Count > 0 Then
            btnEliminarAsignatura.Visible = True
        End If
    End Sub

    Private Sub btnEliminarAsignatura_Click(sender As Object, e As EventArgs) Handles btnEliminarAsignatura.Click
        Dim result As Integer = MessageBox.Show("¿Está seguro de que desea eliminar la asignatura seleccionada?", "Eliminar asignatura", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If

        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "DELETE FROM `AsignaturasTomadas` WHERE IDGrupo=@IDGrupo and IDAsignatura=@IDAsignatura and IDTrayecto=@IDTrayecto;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@IDAsignatura", lstAsignaturas.SelectedItems.Item(0).SubItems(0).Text)
                .Parameters.AddWithValue("@IDGrupo", lstAsignaturas.SelectedItems.Item(0).SubItems(1).Text.Substring(lstAsignaturas.SelectedItems.Item(0).SubItems(1).Text.IndexOf(" "), lstAsignaturas.SelectedItems.Item(0).SubItems(1).Text.Length - 1).Trim())
                .Parameters.AddWithValue("@IDTrayecto", lstAsignaturas.SelectedItems.Item(0).SubItems(1).Text.Substring(0, lstAsignaturas.SelectedItems.Item(0).SubItems(1).Text.IndexOf(" ")).Trim())
            End With
            Try
                cmd.ExecuteNonQuery()
                conexion.Close() 'Cierra la conexión
                cargarMaterias(txtCI.Text)
                btnEliminarAsignatura.Visible = False
                MessageBox.Show("Asignatura eliminada.", "Asignatura eliminada.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub txtCI_TextChanged(t As Object, e As KeyPressEventArgs) Handles txtCI.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = ""
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
        End If
    End Sub
End Class