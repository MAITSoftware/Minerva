<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminDocentes
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim lblDocentes As System.Windows.Forms.Label
        Dim lblTitulo As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdminDocentes))
        Me.cmbCargo = New System.Windows.Forms.ComboBox()
        Me.lblCargo = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblApellido = New System.Windows.Forms.Label()
        Me.lblCi = New System.Windows.Forms.Label()
        Me.txtCI = New System.Windows.Forms.TextBox()
        Me.lblHsSemanales = New System.Windows.Forms.Label()
        Me.lblAsignatura = New System.Windows.Forms.Label()
        Me.lblArea = New System.Windows.Forms.Label()
        Me.txtApellido = New System.Windows.Forms.TextBox()
        Me.lblAsignaturas = New System.Windows.Forms.Label()
        Me.lblGrado = New System.Windows.Forms.Label()
        Me.cmbGrupo = New System.Windows.Forms.ComboBox()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.btnAgregarMateria = New System.Windows.Forms.Button()
        Me.pnlFondo = New System.Windows.Forms.Panel()
        Me.pnlDocentePlantilla = New System.Windows.Forms.Panel()
        Me.btnDocentePlantilla = New System.Windows.Forms.Button()
        Me.btnEliminarPlantilla = New System.Windows.Forms.Button()
        Me.btnEditarPlantilla = New System.Windows.Forms.Button()
        Me.lblCantidadDocentes = New System.Windows.Forms.Label()
        Me.pnlDocentes = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnNuevoDocente = New System.Windows.Forms.Button()
        Me.lblNuevoDocente = New System.Windows.Forms.Label()
        Me.lblObligatorio1 = New System.Windows.Forms.Label()
        Me.lblObligatorio2 = New System.Windows.Forms.Label()
        Me.lblObligatorio3 = New System.Windows.Forms.Label()
        Me.lblObligatorio4 = New System.Windows.Forms.Label()
        Me.lblObligatorio5 = New System.Windows.Forms.Label()
        Me.btnCancelarEdicion = New System.Windows.Forms.Button()
        Me.btnAgregarDocente = New System.Windows.Forms.Button()
        Me.numGrado = New System.Windows.Forms.NumericUpDown()
        Me.numHsSemanales = New System.Windows.Forms.NumericUpDown()
        Me.lstAsignaturas = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmbArea = New System.Windows.Forms.ComboBox()
        Me.cmbOrientacion = New System.Windows.Forms.ComboBox()
        Me.btnEliminarAsignatura = New System.Windows.Forms.PictureBox()
        Me.btnAgregarAsignatura = New System.Windows.Forms.PictureBox()
        Me.mnuEdicionDocente = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DatosDelDocenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MateriasDelDocenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        lblDocentes = New System.Windows.Forms.Label()
        lblTitulo = New System.Windows.Forms.Label()
        Me.pnlFondo.SuspendLayout()
        Me.pnlDocentePlantilla.SuspendLayout()
        CType(Me.numGrado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHsSemanales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEliminarAsignatura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAgregarAsignatura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuEdicionDocente.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblDocentes
        '
        lblDocentes.AutoSize = True
        lblDocentes.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        lblDocentes.Font = New System.Drawing.Font("Corbel", 27.0!, System.Drawing.FontStyle.Bold)
        lblDocentes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        lblDocentes.Location = New System.Drawing.Point(13, 12)
        lblDocentes.Name = "lblDocentes"
        lblDocentes.Size = New System.Drawing.Size(289, 44)
        lblDocentes.TabIndex = 2
        lblDocentes.Text = "Lista de docentes"
        '
        'lblTitulo
        '
        lblTitulo.AutoSize = True
        lblTitulo.Font = New System.Drawing.Font("Corbel", 28.0!, System.Drawing.FontStyle.Bold)
        lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        lblTitulo.Location = New System.Drawing.Point(17, 12)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New System.Drawing.Size(350, 46)
        lblTitulo.TabIndex = 104
        lblTitulo.Text = "Gestión de docentes"
        '
        'cmbCargo
        '
        Me.cmbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCargo.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.cmbCargo.FormattingEnabled = True
        Me.cmbCargo.Items.AddRange(New Object() {"Cargo 1", "Cargo 2"})
        Me.cmbCargo.Location = New System.Drawing.Point(29, 220)
        Me.cmbCargo.Name = "cmbCargo"
        Me.cmbCargo.Size = New System.Drawing.Size(121, 34)
        Me.cmbCargo.TabIndex = 77
        '
        'lblCargo
        '
        Me.lblCargo.AutoSize = True
        Me.lblCargo.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblCargo.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblCargo.Location = New System.Drawing.Point(24, 188)
        Me.lblCargo.Name = "lblCargo"
        Me.lblCargo.Size = New System.Drawing.Size(73, 29)
        Me.lblCargo.TabIndex = 76
        Me.lblCargo.Text = "Cargo"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblNombre.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblNombre.Location = New System.Drawing.Point(169, 110)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(96, 29)
        Me.lblNombre.TabIndex = 75
        Me.lblNombre.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.txtNombre.Location = New System.Drawing.Point(174, 142)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(111, 34)
        Me.txtNombre.TabIndex = 74
        '
        'lblApellido
        '
        Me.lblApellido.AutoSize = True
        Me.lblApellido.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblApellido.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblApellido.Location = New System.Drawing.Point(303, 110)
        Me.lblApellido.Name = "lblApellido"
        Me.lblApellido.Size = New System.Drawing.Size(98, 29)
        Me.lblApellido.TabIndex = 73
        Me.lblApellido.Text = "Apellido"
        '
        'lblCi
        '
        Me.lblCi.AutoSize = True
        Me.lblCi.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblCi.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblCi.Location = New System.Drawing.Point(27, 110)
        Me.lblCi.Name = "lblCi"
        Me.lblCi.Size = New System.Drawing.Size(34, 29)
        Me.lblCi.TabIndex = 71
        Me.lblCi.Text = "CI"
        '
        'txtCI
        '
        Me.txtCI.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.txtCI.Location = New System.Drawing.Point(32, 142)
        Me.txtCI.Name = "txtCI"
        Me.txtCI.Size = New System.Drawing.Size(111, 34)
        Me.txtCI.TabIndex = 70
        '
        'lblHsSemanales
        '
        Me.lblHsSemanales.AutoSize = True
        Me.lblHsSemanales.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblHsSemanales.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblHsSemanales.Location = New System.Drawing.Point(435, 376)
        Me.lblHsSemanales.Name = "lblHsSemanales"
        Me.lblHsSemanales.Size = New System.Drawing.Size(162, 29)
        Me.lblHsSemanales.TabIndex = 88
        Me.lblHsSemanales.Text = "Hs. Semanales"
        '
        'lblAsignatura
        '
        Me.lblAsignatura.AutoSize = True
        Me.lblAsignatura.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAsignatura.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblAsignatura.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblAsignatura.Location = New System.Drawing.Point(435, 297)
        Me.lblAsignatura.Name = "lblAsignatura"
        Me.lblAsignatura.Size = New System.Drawing.Size(125, 29)
        Me.lblAsignatura.TabIndex = 86
        Me.lblAsignatura.Text = "Asignatura"
        '
        'lblArea
        '
        Me.lblArea.AutoSize = True
        Me.lblArea.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblArea.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblArea.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblArea.Location = New System.Drawing.Point(285, 297)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Size = New System.Drawing.Size(61, 29)
        Me.lblArea.TabIndex = 84
        Me.lblArea.Text = "Área"
        '
        'txtApellido
        '
        Me.txtApellido.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.txtApellido.Location = New System.Drawing.Point(308, 142)
        Me.txtApellido.Name = "txtApellido"
        Me.txtApellido.Size = New System.Drawing.Size(111, 34)
        Me.txtApellido.TabIndex = 81
        '
        'lblAsignaturas
        '
        Me.lblAsignaturas.AutoSize = True
        Me.lblAsignaturas.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblAsignaturas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblAsignaturas.Location = New System.Drawing.Point(21, 281)
        Me.lblAsignaturas.Name = "lblAsignaturas"
        Me.lblAsignaturas.Size = New System.Drawing.Size(229, 29)
        Me.lblAsignaturas.TabIndex = 79
        Me.lblAsignaturas.Text = "Asignaturas tomadas"
        '
        'lblGrado
        '
        Me.lblGrado.AutoSize = True
        Me.lblGrado.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblGrado.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblGrado.Location = New System.Drawing.Point(169, 188)
        Me.lblGrado.Name = "lblGrado"
        Me.lblGrado.Size = New System.Drawing.Size(75, 29)
        Me.lblGrado.TabIndex = 90
        Me.lblGrado.Text = "Grado"
        '
        'cmbGrupo
        '
        Me.cmbGrupo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbGrupo.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.Items.AddRange(New Object() {"2ºBG", "3ºBG"})
        Me.cmbGrupo.Location = New System.Drawing.Point(290, 407)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(121, 34)
        Me.cmbGrupo.TabIndex = 95
        '
        'lblGrupo
        '
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblGrupo.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblGrupo.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblGrupo.Location = New System.Drawing.Point(285, 376)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(76, 29)
        Me.lblGrupo.TabIndex = 94
        Me.lblGrupo.Text = "Grupo"
        '
        'btnAgregarMateria
        '
        Me.btnAgregarMateria.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnAgregarMateria.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnAgregarMateria.Location = New System.Drawing.Point(461, 453)
        Me.btnAgregarMateria.Name = "btnAgregarMateria"
        Me.btnAgregarMateria.Size = New System.Drawing.Size(132, 29)
        Me.btnAgregarMateria.TabIndex = 102
        Me.btnAgregarMateria.Text = "Agregar materia"
        Me.btnAgregarMateria.UseVisualStyleBackColor = True
        '
        'pnlFondo
        '
        Me.pnlFondo.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.pnlFondo.Controls.Add(Me.pnlDocentePlantilla)
        Me.pnlFondo.Controls.Add(Me.lblCantidadDocentes)
        Me.pnlFondo.Controls.Add(lblDocentes)
        Me.pnlFondo.Controls.Add(Me.pnlDocentes)
        Me.pnlFondo.Location = New System.Drawing.Point(639, 0)
        Me.pnlFondo.Name = "pnlFondo"
        Me.pnlFondo.Size = New System.Drawing.Size(365, 501)
        Me.pnlFondo.TabIndex = 103
        '
        'pnlDocentePlantilla
        '
        Me.pnlDocentePlantilla.Controls.Add(Me.btnDocentePlantilla)
        Me.pnlDocentePlantilla.Controls.Add(Me.btnEliminarPlantilla)
        Me.pnlDocentePlantilla.Controls.Add(Me.btnEditarPlantilla)
        Me.pnlDocentePlantilla.Location = New System.Drawing.Point(0, 0)
        Me.pnlDocentePlantilla.Name = "pnlDocentePlantilla"
        Me.pnlDocentePlantilla.Size = New System.Drawing.Size(305, 56)
        Me.pnlDocentePlantilla.TabIndex = 0
        Me.pnlDocentePlantilla.Visible = False
        '
        'btnDocentePlantilla
        '
        Me.btnDocentePlantilla.BackColor = System.Drawing.SystemColors.GrayText
        Me.btnDocentePlantilla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDocentePlantilla.FlatAppearance.BorderColor = System.Drawing.Color.Tomato
        Me.btnDocentePlantilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDocentePlantilla.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnDocentePlantilla.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnDocentePlantilla.Location = New System.Drawing.Point(0, 3)
        Me.btnDocentePlantilla.Name = "btnDocentePlantilla"
        Me.btnDocentePlantilla.Size = New System.Drawing.Size(207, 48)
        Me.btnDocentePlantilla.TabIndex = 0
        Me.btnDocentePlantilla.Text = "Template docente"
        Me.btnDocentePlantilla.UseVisualStyleBackColor = False
        '
        'btnEliminarPlantilla
        '
        Me.btnEliminarPlantilla.BackColor = System.Drawing.Color.Firebrick
        Me.btnEliminarPlantilla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminarPlantilla.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnEliminarPlantilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminarPlantilla.Font = New System.Drawing.Font("Corbel", 10.0!)
        Me.btnEliminarPlantilla.ForeColor = System.Drawing.Color.White
        Me.btnEliminarPlantilla.Location = New System.Drawing.Point(213, 28)
        Me.btnEliminarPlantilla.Name = "btnEliminarPlantilla"
        Me.btnEliminarPlantilla.Size = New System.Drawing.Size(89, 23)
        Me.btnEliminarPlantilla.TabIndex = 2
        Me.btnEliminarPlantilla.Text = "Eliminar"
        Me.btnEliminarPlantilla.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminarPlantilla.UseVisualStyleBackColor = False
        '
        'btnEditarPlantilla
        '
        Me.btnEditarPlantilla.BackColor = System.Drawing.Color.SteelBlue
        Me.btnEditarPlantilla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditarPlantilla.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnEditarPlantilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditarPlantilla.Font = New System.Drawing.Font("Corbel", 10.0!)
        Me.btnEditarPlantilla.ForeColor = System.Drawing.Color.White
        Me.btnEditarPlantilla.Location = New System.Drawing.Point(213, 3)
        Me.btnEditarPlantilla.Name = "btnEditarPlantilla"
        Me.btnEditarPlantilla.Size = New System.Drawing.Size(89, 23)
        Me.btnEditarPlantilla.TabIndex = 1
        Me.btnEditarPlantilla.Text = "Editar"
        Me.btnEditarPlantilla.UseVisualStyleBackColor = False
        '
        'lblCantidadDocentes
        '
        Me.lblCantidadDocentes.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lblCantidadDocentes.Font = New System.Drawing.Font("Corbel", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblCantidadDocentes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblCantidadDocentes.Location = New System.Drawing.Point(292, 18)
        Me.lblCantidadDocentes.Name = "lblCantidadDocentes"
        Me.lblCantidadDocentes.Size = New System.Drawing.Size(89, 40)
        Me.lblCantidadDocentes.TabIndex = 34
        Me.lblCantidadDocentes.Text = "(0)"
        '
        'pnlDocentes
        '
        Me.pnlDocentes.AutoScroll = True
        Me.pnlDocentes.Location = New System.Drawing.Point(21, 61)
        Me.pnlDocentes.Name = "pnlDocentes"
        Me.pnlDocentes.Size = New System.Drawing.Size(337, 413)
        Me.pnlDocentes.TabIndex = 33
        '
        'btnNuevoDocente
        '
        Me.btnNuevoDocente.AutoSize = True
        Me.btnNuevoDocente.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnNuevoDocente.Location = New System.Drawing.Point(378, 21)
        Me.btnNuevoDocente.Name = "btnNuevoDocente"
        Me.btnNuevoDocente.Size = New System.Drawing.Size(121, 29)
        Me.btnNuevoDocente.TabIndex = 106
        Me.btnNuevoDocente.Text = "Nuevo docente"
        Me.btnNuevoDocente.UseVisualStyleBackColor = True
        Me.btnNuevoDocente.Visible = False
        '
        'lblNuevoDocente
        '
        Me.lblNuevoDocente.AutoSize = True
        Me.lblNuevoDocente.BackColor = System.Drawing.Color.Transparent
        Me.lblNuevoDocente.Font = New System.Drawing.Font("Corbel", 28.0!)
        Me.lblNuevoDocente.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblNuevoDocente.Location = New System.Drawing.Point(17, 58)
        Me.lblNuevoDocente.Name = "lblNuevoDocente"
        Me.lblNuevoDocente.Size = New System.Drawing.Size(259, 46)
        Me.lblNuevoDocente.TabIndex = 105
        Me.lblNuevoDocente.Text = "Nuevo docente"
        '
        'lblObligatorio1
        '
        Me.lblObligatorio1.BackColor = System.Drawing.Color.Transparent
        Me.lblObligatorio1.Cursor = System.Windows.Forms.Cursors.Help
        Me.lblObligatorio1.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblObligatorio1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblObligatorio1.Location = New System.Drawing.Point(120, 113)
        Me.lblObligatorio1.Name = "lblObligatorio1"
        Me.lblObligatorio1.Size = New System.Drawing.Size(23, 23)
        Me.lblObligatorio1.TabIndex = 107
        Me.lblObligatorio1.Text = "*"
        '
        'lblObligatorio2
        '
        Me.lblObligatorio2.BackColor = System.Drawing.Color.Transparent
        Me.lblObligatorio2.Cursor = System.Windows.Forms.Cursors.Help
        Me.lblObligatorio2.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblObligatorio2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblObligatorio2.Location = New System.Drawing.Point(271, 113)
        Me.lblObligatorio2.Name = "lblObligatorio2"
        Me.lblObligatorio2.Size = New System.Drawing.Size(23, 23)
        Me.lblObligatorio2.TabIndex = 108
        Me.lblObligatorio2.Text = "*"
        '
        'lblObligatorio3
        '
        Me.lblObligatorio3.BackColor = System.Drawing.Color.Transparent
        Me.lblObligatorio3.Cursor = System.Windows.Forms.Cursors.Help
        Me.lblObligatorio3.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblObligatorio3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblObligatorio3.Location = New System.Drawing.Point(396, 113)
        Me.lblObligatorio3.Name = "lblObligatorio3"
        Me.lblObligatorio3.Size = New System.Drawing.Size(23, 23)
        Me.lblObligatorio3.TabIndex = 109
        Me.lblObligatorio3.Text = "*"
        '
        'lblObligatorio4
        '
        Me.lblObligatorio4.BackColor = System.Drawing.Color.Transparent
        Me.lblObligatorio4.Cursor = System.Windows.Forms.Cursors.Help
        Me.lblObligatorio4.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblObligatorio4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblObligatorio4.Location = New System.Drawing.Point(127, 191)
        Me.lblObligatorio4.Name = "lblObligatorio4"
        Me.lblObligatorio4.Size = New System.Drawing.Size(23, 23)
        Me.lblObligatorio4.TabIndex = 110
        Me.lblObligatorio4.Text = "*"
        '
        'lblObligatorio5
        '
        Me.lblObligatorio5.BackColor = System.Drawing.Color.Transparent
        Me.lblObligatorio5.Cursor = System.Windows.Forms.Cursors.Help
        Me.lblObligatorio5.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblObligatorio5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblObligatorio5.Location = New System.Drawing.Point(253, 191)
        Me.lblObligatorio5.Name = "lblObligatorio5"
        Me.lblObligatorio5.Size = New System.Drawing.Size(23, 23)
        Me.lblObligatorio5.TabIndex = 111
        Me.lblObligatorio5.Text = "*"
        '
        'btnCancelarEdicion
        '
        Me.btnCancelarEdicion.AutoSize = True
        Me.btnCancelarEdicion.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnCancelarEdicion.Location = New System.Drawing.Point(462, 220)
        Me.btnCancelarEdicion.Name = "btnCancelarEdicion"
        Me.btnCancelarEdicion.Size = New System.Drawing.Size(154, 29)
        Me.btnCancelarEdicion.TabIndex = 113
        Me.btnCancelarEdicion.Text = "Cancelar edición"
        Me.btnCancelarEdicion.UseVisualStyleBackColor = True
        Me.btnCancelarEdicion.Visible = False
        '
        'btnAgregarDocente
        '
        Me.btnAgregarDocente.AutoSize = True
        Me.btnAgregarDocente.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnAgregarDocente.Location = New System.Drawing.Point(462, 174)
        Me.btnAgregarDocente.Name = "btnAgregarDocente"
        Me.btnAgregarDocente.Size = New System.Drawing.Size(154, 29)
        Me.btnAgregarDocente.TabIndex = 112
        Me.btnAgregarDocente.Text = "Agregar docente"
        Me.btnAgregarDocente.UseVisualStyleBackColor = True
        '
        'numGrado
        '
        Me.numGrado.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.numGrado.Location = New System.Drawing.Point(174, 220)
        Me.numGrado.Name = "numGrado"
        Me.numGrado.Size = New System.Drawing.Size(99, 34)
        Me.numGrado.TabIndex = 114
        '
        'numHsSemanales
        '
        Me.numHsSemanales.Cursor = System.Windows.Forms.Cursors.Default
        Me.numHsSemanales.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.numHsSemanales.Location = New System.Drawing.Point(440, 407)
        Me.numHsSemanales.Name = "numHsSemanales"
        Me.numHsSemanales.Size = New System.Drawing.Size(106, 34)
        Me.numHsSemanales.TabIndex = 115
        '
        'lstAsignaturas
        '
        Me.lstAsignaturas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lstAsignaturas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstAsignaturas.Location = New System.Drawing.Point(29, 313)
        Me.lstAsignaturas.Name = "lstAsignaturas"
        Me.lstAsignaturas.Size = New System.Drawing.Size(219, 145)
        Me.lstAsignaturas.TabIndex = 116
        Me.lstAsignaturas.UseCompatibleStateImageBehavior = False
        Me.lstAsignaturas.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Área"
        Me.ColumnHeader1.Width = 40
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Asignatura"
        Me.ColumnHeader2.Width = 70
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Grupo"
        Me.ColumnHeader3.Width = 45
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Horas"
        '
        'cmbArea
        '
        Me.cmbArea.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbArea.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.cmbArea.FormattingEnabled = True
        Me.cmbArea.Items.AddRange(New Object() {"1 - Caca", "2 - Caca"})
        Me.cmbArea.Location = New System.Drawing.Point(290, 329)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(121, 34)
        Me.cmbArea.TabIndex = 117
        '
        'cmbOrientacion
        '
        Me.cmbOrientacion.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbOrientacion.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.cmbOrientacion.FormattingEnabled = True
        Me.cmbOrientacion.Items.AddRange(New Object() {"123 - Caca", "493 - Hola"})
        Me.cmbOrientacion.Location = New System.Drawing.Point(440, 329)
        Me.cmbOrientacion.Name = "cmbOrientacion"
        Me.cmbOrientacion.Size = New System.Drawing.Size(121, 34)
        Me.cmbOrientacion.TabIndex = 118
        '
        'btnEliminarAsignatura
        '
        Me.btnEliminarAsignatura.BackColor = System.Drawing.Color.Transparent
        Me.btnEliminarAsignatura.BackgroundImage = Global.Minerva.My.Resources.Resources.borrar_normal
        Me.btnEliminarAsignatura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnEliminarAsignatura.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnEliminarAsignatura.Enabled = False
        Me.btnEliminarAsignatura.Location = New System.Drawing.Point(254, 387)
        Me.btnEliminarAsignatura.Name = "btnEliminarAsignatura"
        Me.btnEliminarAsignatura.Size = New System.Drawing.Size(25, 25)
        Me.btnEliminarAsignatura.TabIndex = 120
        Me.btnEliminarAsignatura.TabStop = False
        '
        'btnAgregarAsignatura
        '
        Me.btnAgregarAsignatura.BackColor = System.Drawing.Color.Transparent
        Me.btnAgregarAsignatura.BackgroundImage = CType(resources.GetObject("btnAgregarAsignatura.BackgroundImage"), System.Drawing.Image)
        Me.btnAgregarAsignatura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAgregarAsignatura.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregarAsignatura.Location = New System.Drawing.Point(254, 356)
        Me.btnAgregarAsignatura.Name = "btnAgregarAsignatura"
        Me.btnAgregarAsignatura.Size = New System.Drawing.Size(25, 25)
        Me.btnAgregarAsignatura.TabIndex = 119
        Me.btnAgregarAsignatura.TabStop = False
        '
        'mnuEdicionDocente
        '
        Me.mnuEdicionDocente.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DatosDelDocenteToolStripMenuItem, Me.MateriasDelDocenteToolStripMenuItem})
        Me.mnuEdicionDocente.Name = "ContextMenuStrip1"
        Me.mnuEdicionDocente.Size = New System.Drawing.Size(202, 48)
        '
        'DatosDelDocenteToolStripMenuItem
        '
        Me.DatosDelDocenteToolStripMenuItem.Name = "DatosDelDocenteToolStripMenuItem"
        Me.DatosDelDocenteToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.DatosDelDocenteToolStripMenuItem.Text = "Datos del docente"
        '
        'MateriasDelDocenteToolStripMenuItem
        '
        Me.MateriasDelDocenteToolStripMenuItem.Name = "MateriasDelDocenteToolStripMenuItem"
        Me.MateriasDelDocenteToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.MateriasDelDocenteToolStripMenuItem.Text = "Asignaturas del docente"
        '
        'frmAdminDocentes
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Controls.Add(Me.lblAsignaturas)
        Me.Controls.Add(Me.numHsSemanales)
        Me.Controls.Add(Me.cmbOrientacion)
        Me.Controls.Add(Me.numGrado)
        Me.Controls.Add(Me.btnEliminarAsignatura)
        Me.Controls.Add(Me.btnCancelarEdicion)
        Me.Controls.Add(Me.cmbArea)
        Me.Controls.Add(Me.btnAgregarDocente)
        Me.Controls.Add(Me.lstAsignaturas)
        Me.Controls.Add(Me.lblObligatorio5)
        Me.Controls.Add(Me.btnAgregarAsignatura)
        Me.Controls.Add(Me.lblObligatorio4)
        Me.Controls.Add(Me.lblGrupo)
        Me.Controls.Add(Me.lblObligatorio3)
        Me.Controls.Add(Me.cmbGrupo)
        Me.Controls.Add(Me.lblObligatorio2)
        Me.Controls.Add(Me.lblArea)
        Me.Controls.Add(Me.lblObligatorio1)
        Me.Controls.Add(Me.lblAsignatura)
        Me.Controls.Add(Me.btnNuevoDocente)
        Me.Controls.Add(Me.lblHsSemanales)
        Me.Controls.Add(Me.lblNuevoDocente)
        Me.Controls.Add(Me.btnAgregarMateria)
        Me.Controls.Add(lblTitulo)
        Me.Controls.Add(Me.lblGrado)
        Me.Controls.Add(Me.txtApellido)
        Me.Controls.Add(Me.cmbCargo)
        Me.Controls.Add(Me.lblCargo)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.lblApellido)
        Me.Controls.Add(Me.lblCi)
        Me.Controls.Add(Me.txtCI)
        Me.Controls.Add(Me.pnlFondo)
        Me.Name = "frmAdminDocentes"
        Me.Size = New System.Drawing.Size(1004, 493)
        Me.pnlFondo.ResumeLayout(False)
        Me.pnlFondo.PerformLayout()
        Me.pnlDocentePlantilla.ResumeLayout(False)
        CType(Me.numGrado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHsSemanales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEliminarAsignatura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAgregarAsignatura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuEdicionDocente.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbCargo As System.Windows.Forms.ComboBox
    Friend WithEvents lblCargo As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblApellido As System.Windows.Forms.Label
    Friend WithEvents lblCi As System.Windows.Forms.Label
    Friend WithEvents txtCI As System.Windows.Forms.TextBox
    Friend WithEvents lblHsSemanales As System.Windows.Forms.Label
    Friend WithEvents lblAsignatura As System.Windows.Forms.Label
    Friend WithEvents lblArea As System.Windows.Forms.Label
    Friend WithEvents txtApellido As System.Windows.Forms.TextBox
    Friend WithEvents lblAsignaturas As System.Windows.Forms.Label
    Friend WithEvents lblGrado As System.Windows.Forms.Label
    Friend WithEvents cmbGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents lblGrupo As System.Windows.Forms.Label
    Friend WithEvents btnAgregarMateria As System.Windows.Forms.Button
    Friend WithEvents pnlFondo As System.Windows.Forms.Panel
    Friend WithEvents lblCantidadDocentes As System.Windows.Forms.Label
    Friend WithEvents pnlDocentePlantilla As System.Windows.Forms.Panel
    Friend WithEvents btnDocentePlantilla As System.Windows.Forms.Button
    Friend WithEvents btnEliminarPlantilla As System.Windows.Forms.Button
    Friend WithEvents btnEditarPlantilla As System.Windows.Forms.Button
    Friend WithEvents pnlDocentes As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnNuevoDocente As System.Windows.Forms.Button
    Friend WithEvents lblNuevoDocente As System.Windows.Forms.Label
    Friend WithEvents lblObligatorio1 As System.Windows.Forms.Label
    Friend WithEvents lblObligatorio2 As System.Windows.Forms.Label
    Friend WithEvents lblObligatorio3 As System.Windows.Forms.Label
    Friend WithEvents lblObligatorio4 As System.Windows.Forms.Label
    Friend WithEvents lblObligatorio5 As System.Windows.Forms.Label
    Friend WithEvents btnCancelarEdicion As System.Windows.Forms.Button
    Friend WithEvents btnAgregarDocente As System.Windows.Forms.Button
    Friend WithEvents numGrado As System.Windows.Forms.NumericUpDown
    Friend WithEvents numHsSemanales As System.Windows.Forms.NumericUpDown
    Friend WithEvents lstAsignaturas As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmbArea As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOrientacion As System.Windows.Forms.ComboBox
    Friend WithEvents btnAgregarAsignatura As System.Windows.Forms.PictureBox
    Friend WithEvents btnEliminarAsignatura As System.Windows.Forms.PictureBox
    Friend WithEvents mnuEdicionDocente As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DatosDelDocenteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MateriasDelDocenteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
