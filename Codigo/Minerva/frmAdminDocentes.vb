Imports MySql.Data.MySqlClient
Imports System.Data

Public Class frmAdminDocentes
    ' Clase principal para la administracion de docentes

    Dim totalDocentes As Integer = 0
    Dim docentePreview As Object = New Button()

    Private Sub frmAdminDocentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call New ToolTip().SetToolTip(lblObligatorio1, "Dato obligatorio")
        Call New ToolTip().SetToolTip(lblObligatorio2, "Dato obligatorio")
        Call New ToolTip().SetToolTip(lblObligatorio3, "Dato obligatorio")
        Call New ToolTip().SetToolTip(lblObligatorio4, "Dato obligatorio")
        Call New ToolTip().SetToolTip(lblObligatorio5, "Dato obligatorio")
        cargarDocentes()
    End Sub

    Private Sub cargarDocentes()
        pnlDocentes.Controls.Clear()
        totalDocentes = 0
        lblCantidadDocentes.Text = "(" + totalDocentes.ToString() + ")"

        Dim conexion As New DB()
        Using cmd As New MySqlCommand()
            With cmd
                .Connection = conexion.Conn
                .CommandText = "SELECT * FROM `docente`;"
                .CommandType = CommandType.Text
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                agregarDocente(reader("ci"), reader("ci").ToString() & ControlChars.NewLine & " (" & reader("nombre") & " " & reader("apellido") & ")")
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

        btnEliminar.Tag = ciDocente
        'AddHandler btnEliminar.Click, AddressOf eliminarDocente

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

                If btnAgregarDocente.Text.Equals("Agregar docente") Then
                    .CommandText = "INSERT INTO `docente` VALUES  (@ci, @nombre, @apellido, @cargo, @grado, @asignaturas);"
                Else
                    .CommandText = "UPDATE `docente` SET nombre=@nombre, apellido=@apellido, cargo=@cargo, grado=@grado, asignaturas=@asignaturas WHERE ci=@ci;"
                End If

                .Parameters.AddWithValue("@ci", txtCI.Text)
                .Parameters.AddWithValue("@nombre", txtNombre.Text)
                .Parameters.AddWithValue("@apellido", txtApellido.Text)
                .Parameters.AddWithValue("@cargo", cmbCargo.Text)
                .Parameters.AddWithValue("@grado", numGrado.Value.ToString())
                .Parameters.AddWithValue("@asignaturas", "Prueba")

            End With

            Try
                cmd.ExecuteNonQuery()
                conexion.Close()

                cargarDocentes()
                If btnAgregarDocente.Text.Equals("Agregar docente") Then
                    MessageBox.Show("Docente agregado correctamente", "Docente agregado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Else
                    MessageBox.Show("Información de docente actualizada correctamente", "Docente actualizado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If

                ' Deshabilita la edición de datos del docente.
                lblNuevoDocente.Text = "Editar docente"
            Catch ex As Exception
                If ex.ToString().Contains("Duplicate") Then
                    MessageBox.Show("Ya existe un docente con esa CI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

        If String.IsNullOrWhiteSpace(cmbCargo.Text) Then
            MessageBox.Show("Debe ingresar un cargo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return
        End If

        actualizarDB()
    End Sub

    Private Sub editarDocente(ByVal sender As System.Object, ByVal e As System.EventArgs)
        docentePreview.Enabled = True
        docentePreview = sender.Tag(0)
        docentePreview.Enabled = False
        lblNuevoDocente.Text = "Editar docente"
        btnCancelarEdicion.Visible = True
        btnAgregarDocente.Visible = True
        btnAgregarMateria.Visible = True
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
        cmbCargo.Enabled = habilitado
        cmbCargo.SelectedIndex = -1
        numGrado.Enabled = habilitado
        numGrado.Value = 0
    End Sub

    Private Sub habilitarAsignaturas(ByVal habilitadas As Boolean)
        lstAsignaturas.Enabled = habilitadas
        btnAgregarAsignatura.Enabled = habilitadas
        btnEliminarAsignatura.Enabled = habilitadas
        cmbArea.Enabled = habilitadas
        cmbOrientacion.Enabled = habilitadas
        cmbGrupo.Enabled = habilitadas
        numHsSemanales.Enabled = habilitadas
        btnAgregarMateria.Enabled = habilitadas
    End Sub

    Private Sub verDocente(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDocentePlantilla.Click
        docentePreview.Enabled = True
        docentePreview = sender
        docentePreview.Enabled = False
        previsualizarDocente(sender.Tag)
    End Sub

    Private Sub previsualizarDocente(ByVal ci As String)
        btnNuevoDocente.Visible = True
        btnAgregarDocente.Visible = False
        btnAgregarMateria.Visible = False
        btnCancelarEdicion.Visible = False

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
                .CommandText = "SELECT * FROM `docente` where ci=@ci;"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@ci", ciDocente)
            End With

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                txtCI.Text = reader("ci")
                txtNombre.Text = reader("nombre")
                txtApellido.Text = reader("apellido")
                numGrado.Value = Integer.Parse(reader("grado"))
                cmbCargo.SelectedIndex = cmbCargo.FindStringExact(reader("cargo"))
            End While
            reader.Close()
            conexion.Close()
        End Using
    End Sub

    Private Sub btnNuevoDocente_Click(sender As Object, e As EventArgs) Handles btnNuevoDocente.Click, btnCancelarEdicion.Click
        controlesHabilitados(True)
        lblNuevoDocente.Text = "Nuevo docente"
        btnNuevoDocente.Visible = False
        btnAgregarMateria.Visible = True
        btnAgregarDocente.Visible = True
        btnAgregarDocente.Text = "Agregar docente"
        btnCancelarEdicion.Visible = False
        docentePreview.Enabled = True
        docentePreview = New Button()
        habilitarAsignaturas(True)
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
        editarDocente(sender, Nothing)
    End Sub
End Class