﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminDocentes
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Me.cmbGrupo = New System.Windows.Forms.ComboBox()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.btnAgregarAsignatura = New System.Windows.Forms.Button()
        Me.pnlFondo = New System.Windows.Forms.Panel()
        Me.pnlDocentePlantilla = New System.Windows.Forms.Panel()
        Me.btnDocentePlantilla = New System.Windows.Forms.Button()
        Me.btnEliminarPlantilla = New System.Windows.Forms.Button()
        Me.btnEditarPlantilla = New System.Windows.Forms.Button()
        Me.lblCantidadDocentes = New System.Windows.Forms.Label()
        Me.pnlDocentes = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnNuevoDocente = New System.Windows.Forms.Button()
        Me.lblNuevoDocente = New System.Windows.Forms.Label()
        Me.btnCancelarEdicion = New System.Windows.Forms.Button()
        Me.btnAgregarDocente = New System.Windows.Forms.Button()
        Me.numGradoArea = New System.Windows.Forms.NumericUpDown()
        Me.lstAsignaturas = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmbArea = New System.Windows.Forms.ComboBox()
        Me.cmbAsignatura = New System.Windows.Forms.ComboBox()
        Me.mnuEdicionDocente = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DatosDelDocenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsignaturasDelDocenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminarAsignatura = New System.Windows.Forms.PictureBox()
        Me.btnLimpiarAsignatura = New System.Windows.Forms.PictureBox()
        Me.numGrado = New System.Windows.Forms.NumericUpDown()
        Me.imgLogoMAITs = New System.Windows.Forms.PictureBox()
        Me.pnlAyudabtnEliminarAsignatura = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlAyudabtnAgregarAsignatura = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnHorariosDocente = New System.Windows.Forms.Button()
        lblDocentes = New System.Windows.Forms.Label()
        lblTitulo = New System.Windows.Forms.Label()
        Me.pnlFondo.SuspendLayout()
        Me.pnlDocentePlantilla.SuspendLayout()
        CType(Me.numGradoArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuEdicionDocente.SuspendLayout()
        CType(Me.btnEliminarAsignatura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnLimpiarAsignatura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGrado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogoMAITs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAyudabtnEliminarAsignatura.SuspendLayout()
        Me.pnlAyudabtnAgregarAsignatura.SuspendLayout()
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
        'lblCargo
        '
        Me.lblCargo.AutoSize = True
        Me.lblCargo.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblCargo.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblCargo.Location = New System.Drawing.Point(24, 188)
        Me.lblCargo.Name = "lblCargo"
        Me.lblCargo.Size = New System.Drawing.Size(156, 29)
        Me.lblCargo.TabIndex = 76
        Me.lblCargo.Text = "Grado general"
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
        Me.txtNombre.MaxLength = 25
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(111, 34)
        Me.txtNombre.TabIndex = 1
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
        Me.txtCI.MaxLength = 8
        Me.txtCI.Name = "txtCI"
        Me.txtCI.ShortcutsEnabled = False
        Me.txtCI.Size = New System.Drawing.Size(111, 34)
        Me.txtCI.TabIndex = 0
        '
        'lblHsSemanales
        '
        Me.lblHsSemanales.AutoSize = True
        Me.lblHsSemanales.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblHsSemanales.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblHsSemanales.Location = New System.Drawing.Point(478, 383)
        Me.lblHsSemanales.Name = "lblHsSemanales"
        Me.lblHsSemanales.Size = New System.Drawing.Size(92, 29)
        Me.lblHsSemanales.TabIndex = 88
        Me.lblHsSemanales.Text = "Gr. área"
        '
        'lblAsignatura
        '
        Me.lblAsignatura.AutoSize = True
        Me.lblAsignatura.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAsignatura.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblAsignatura.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblAsignatura.Location = New System.Drawing.Point(291, 383)
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
        Me.lblArea.Location = New System.Drawing.Point(424, 313)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Size = New System.Drawing.Size(61, 29)
        Me.lblArea.TabIndex = 84
        Me.lblArea.Text = "Área"
        '
        'txtApellido
        '
        Me.txtApellido.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.txtApellido.Location = New System.Drawing.Point(308, 142)
        Me.txtApellido.MaxLength = 25
        Me.txtApellido.Name = "txtApellido"
        Me.txtApellido.Size = New System.Drawing.Size(111, 34)
        Me.txtApellido.TabIndex = 2
        '
        'lblAsignaturas
        '
        Me.lblAsignaturas.AutoSize = True
        Me.lblAsignaturas.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblAsignaturas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblAsignaturas.Location = New System.Drawing.Point(21, 281)
        Me.lblAsignaturas.Name = "lblAsignaturas"
        Me.lblAsignaturas.Size = New System.Drawing.Size(234, 29)
        Me.lblAsignaturas.TabIndex = 79
        Me.lblAsignaturas.Text = "Asignaturas tomadas "
        '
        'cmbGrupo
        '
        Me.cmbGrupo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrupo.Enabled = False
        Me.cmbGrupo.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.Location = New System.Drawing.Point(295, 345)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(123, 27)
        Me.cmbGrupo.TabIndex = 7
        '
        'lblGrupo
        '
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblGrupo.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblGrupo.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblGrupo.Location = New System.Drawing.Point(291, 313)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(76, 29)
        Me.lblGrupo.TabIndex = 94
        Me.lblGrupo.Text = "Grupo"
        '
        'btnAgregarAsignatura
        '
        Me.btnAgregarAsignatura.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnAgregarAsignatura.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnAgregarAsignatura.Location = New System.Drawing.Point(448, 458)
        Me.btnAgregarAsignatura.Name = "btnAgregarAsignatura"
        Me.btnAgregarAsignatura.Size = New System.Drawing.Size(164, 29)
        Me.btnAgregarAsignatura.TabIndex = 11
        Me.btnAgregarAsignatura.Text = "Confirmar agregación"
        Me.btnAgregarAsignatura.UseVisualStyleBackColor = True
        Me.btnAgregarAsignatura.Visible = False
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
        Me.btnDocentePlantilla.TabStop = False
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
        Me.btnEliminarPlantilla.TabStop = False
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
        Me.btnEditarPlantilla.TabStop = False
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
        Me.btnNuevoDocente.TabIndex = 6
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
        'btnCancelarEdicion
        '
        Me.btnCancelarEdicion.AutoSize = True
        Me.btnCancelarEdicion.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnCancelarEdicion.Location = New System.Drawing.Point(462, 220)
        Me.btnCancelarEdicion.Name = "btnCancelarEdicion"
        Me.btnCancelarEdicion.Size = New System.Drawing.Size(154, 29)
        Me.btnCancelarEdicion.TabIndex = 5
        Me.btnCancelarEdicion.Text = "Cancelar edición"
        Me.btnCancelarEdicion.UseVisualStyleBackColor = True
        Me.btnCancelarEdicion.Visible = False
        '
        'btnAgregarDocente
        '
        Me.btnAgregarDocente.AutoSize = True
        Me.btnAgregarDocente.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnAgregarDocente.Location = New System.Drawing.Point(462, 164)
        Me.btnAgregarDocente.Name = "btnAgregarDocente"
        Me.btnAgregarDocente.Size = New System.Drawing.Size(154, 53)
        Me.btnAgregarDocente.TabIndex = 4
        Me.btnAgregarDocente.Text = "Agregar docente " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "y editar materias"
        Me.btnAgregarDocente.UseVisualStyleBackColor = True
        '
        'numGradoArea
        '
        Me.numGradoArea.Cursor = System.Windows.Forms.Cursors.Default
        Me.numGradoArea.Enabled = False
        Me.numGradoArea.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.numGradoArea.Location = New System.Drawing.Point(483, 415)
        Me.numGradoArea.Maximum = New Decimal(New Integer() {7, 0, 0, 0})
        Me.numGradoArea.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numGradoArea.Name = "numGradoArea"
        Me.numGradoArea.Size = New System.Drawing.Size(106, 27)
        Me.numGradoArea.TabIndex = 10
        Me.numGradoArea.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lstAsignaturas
        '
        Me.lstAsignaturas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader1})
        Me.lstAsignaturas.Enabled = False
        Me.lstAsignaturas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstAsignaturas.HideSelection = False
        Me.lstAsignaturas.Location = New System.Drawing.Point(25, 313)
        Me.lstAsignaturas.MultiSelect = False
        Me.lstAsignaturas.Name = "lstAsignaturas"
        Me.lstAsignaturas.Size = New System.Drawing.Size(238, 145)
        Me.lstAsignaturas.TabIndex = 12
        Me.lstAsignaturas.TabStop = False
        Me.lstAsignaturas.UseCompatibleStateImageBehavior = False
        Me.lstAsignaturas.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Asignatura"
        Me.ColumnHeader2.Width = 70
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Grupo"
        Me.ColumnHeader3.Width = 50
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "F. Asignación"
        Me.ColumnHeader1.Width = 80
        '
        'cmbArea
        '
        Me.cmbArea.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbArea.Enabled = False
        Me.cmbArea.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.cmbArea.FormattingEnabled = True
        Me.cmbArea.Location = New System.Drawing.Point(429, 345)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(183, 27)
        Me.cmbArea.TabIndex = 8
        '
        'cmbAsignatura
        '
        Me.cmbAsignatura.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbAsignatura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAsignatura.Enabled = False
        Me.cmbAsignatura.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.cmbAsignatura.FormattingEnabled = True
        Me.cmbAsignatura.Location = New System.Drawing.Point(295, 415)
        Me.cmbAsignatura.Name = "cmbAsignatura"
        Me.cmbAsignatura.Size = New System.Drawing.Size(182, 27)
        Me.cmbAsignatura.TabIndex = 9
        '
        'mnuEdicionDocente
        '
        Me.mnuEdicionDocente.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DatosDelDocenteToolStripMenuItem, Me.AsignaturasDelDocenteToolStripMenuItem})
        Me.mnuEdicionDocente.Name = "ContextMenuStrip1"
        Me.mnuEdicionDocente.Size = New System.Drawing.Size(202, 48)
        '
        'DatosDelDocenteToolStripMenuItem
        '
        Me.DatosDelDocenteToolStripMenuItem.Name = "DatosDelDocenteToolStripMenuItem"
        Me.DatosDelDocenteToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.DatosDelDocenteToolStripMenuItem.Text = "Datos del docente"
        '
        'AsignaturasDelDocenteToolStripMenuItem
        '
        Me.AsignaturasDelDocenteToolStripMenuItem.Name = "AsignaturasDelDocenteToolStripMenuItem"
        Me.AsignaturasDelDocenteToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.AsignaturasDelDocenteToolStripMenuItem.Text = "Asignaturas del docente"
        '
        'btnEliminarAsignatura
        '
        Me.btnEliminarAsignatura.BackColor = System.Drawing.Color.Transparent
        Me.btnEliminarAsignatura.BackgroundImage = Global.Minerva.My.Resources.Resources.borrar_normal
        Me.btnEliminarAsignatura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnEliminarAsignatura.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminarAsignatura.Enabled = False
        Me.btnEliminarAsignatura.Location = New System.Drawing.Point(263, 373)
        Me.btnEliminarAsignatura.Name = "btnEliminarAsignatura"
        Me.btnEliminarAsignatura.Size = New System.Drawing.Size(25, 25)
        Me.btnEliminarAsignatura.TabIndex = 120
        Me.btnEliminarAsignatura.TabStop = False
        Me.btnEliminarAsignatura.Visible = False
        '
        'btnLimpiarAsignatura
        '
        Me.btnLimpiarAsignatura.BackColor = System.Drawing.Color.Transparent
        Me.btnLimpiarAsignatura.BackgroundImage = Global.Minerva.My.Resources.Resources.agregar_normal
        Me.btnLimpiarAsignatura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnLimpiarAsignatura.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiarAsignatura.Enabled = False
        Me.btnLimpiarAsignatura.Location = New System.Drawing.Point(608, 376)
        Me.btnLimpiarAsignatura.Name = "btnLimpiarAsignatura"
        Me.btnLimpiarAsignatura.Size = New System.Drawing.Size(25, 25)
        Me.btnLimpiarAsignatura.TabIndex = 119
        Me.btnLimpiarAsignatura.TabStop = False
        Me.btnLimpiarAsignatura.Visible = False
        '
        'numGrado
        '
        Me.numGrado.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.numGrado.Location = New System.Drawing.Point(29, 220)
        Me.numGrado.Maximum = New Decimal(New Integer() {7, 0, 0, 0})
        Me.numGrado.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numGrado.Name = "numGrado"
        Me.numGrado.Size = New System.Drawing.Size(120, 34)
        Me.numGrado.TabIndex = 3
        Me.numGrado.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'imgLogoMAITs
        '
        Me.imgLogoMAITs.BackgroundImage = Global.Minerva.My.Resources.Resources.logoMAITS
        Me.imgLogoMAITs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.imgLogoMAITs.Location = New System.Drawing.Point(512, 12)
        Me.imgLogoMAITs.Name = "imgLogoMAITs"
        Me.imgLogoMAITs.Size = New System.Drawing.Size(121, 62)
        Me.imgLogoMAITs.TabIndex = 122
        Me.imgLogoMAITs.TabStop = False
        '
        'pnlAyudabtnEliminarAsignatura
        '
        Me.pnlAyudabtnEliminarAsignatura.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAyudabtnEliminarAsignatura.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.pnlAyudabtnEliminarAsignatura.BackgroundImage = Global.Minerva.My.Resources.Resources.dialogo_izquierda
        Me.pnlAyudabtnEliminarAsignatura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlAyudabtnEliminarAsignatura.Controls.Add(Me.Label1)
        Me.pnlAyudabtnEliminarAsignatura.Location = New System.Drawing.Point(290, 360)
        Me.pnlAyudabtnEliminarAsignatura.Name = "pnlAyudabtnEliminarAsignatura"
        Me.pnlAyudabtnEliminarAsignatura.Size = New System.Drawing.Size(246, 71)
        Me.pnlAyudabtnEliminarAsignatura.TabIndex = 132
        Me.pnlAyudabtnEliminarAsignatura.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(42, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 53)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Elimina la asignatura seleccionada"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlAyudabtnAgregarAsignatura
        '
        Me.pnlAyudabtnAgregarAsignatura.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAyudabtnAgregarAsignatura.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.pnlAyudabtnAgregarAsignatura.BackgroundImage = Global.Minerva.My.Resources.Resources.dialogo_derecha
        Me.pnlAyudabtnAgregarAsignatura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlAyudabtnAgregarAsignatura.Controls.Add(Me.Label2)
        Me.pnlAyudabtnAgregarAsignatura.Location = New System.Drawing.Point(357, 363)
        Me.pnlAyudabtnAgregarAsignatura.Name = "pnlAyudabtnAgregarAsignatura"
        Me.pnlAyudabtnAgregarAsignatura.Size = New System.Drawing.Size(246, 71)
        Me.pnlAyudabtnAgregarAsignatura.TabIndex = 133
        Me.pnlAyudabtnAgregarAsignatura.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(16, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(194, 53)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Limpia las selecciones de las listas"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnHorariosDocente
        '
        Me.btnHorariosDocente.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnHorariosDocente.Location = New System.Drawing.Point(492, 180)
        Me.btnHorariosDocente.Name = "btnHorariosDocente"
        Me.btnHorariosDocente.Size = New System.Drawing.Size(97, 56)
        Me.btnHorariosDocente.TabIndex = 134
        Me.btnHorariosDocente.Text = "Horarios del docente"
        Me.btnHorariosDocente.UseVisualStyleBackColor = True
        Me.btnHorariosDocente.Visible = False
        '
        'frmAdminDocentes
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Controls.Add(Me.btnHorariosDocente)
        Me.Controls.Add(Me.pnlAyudabtnAgregarAsignatura)
        Me.Controls.Add(Me.pnlAyudabtnEliminarAsignatura)
        Me.Controls.Add(Me.imgLogoMAITs)
        Me.Controls.Add(Me.numGrado)
        Me.Controls.Add(Me.lblAsignaturas)
        Me.Controls.Add(Me.numGradoArea)
        Me.Controls.Add(Me.cmbAsignatura)
        Me.Controls.Add(Me.btnEliminarAsignatura)
        Me.Controls.Add(Me.btnCancelarEdicion)
        Me.Controls.Add(Me.cmbArea)
        Me.Controls.Add(Me.btnAgregarDocente)
        Me.Controls.Add(Me.lstAsignaturas)
        Me.Controls.Add(Me.btnLimpiarAsignatura)
        Me.Controls.Add(Me.lblGrupo)
        Me.Controls.Add(Me.cmbGrupo)
        Me.Controls.Add(Me.lblArea)
        Me.Controls.Add(Me.lblAsignatura)
        Me.Controls.Add(Me.btnNuevoDocente)
        Me.Controls.Add(Me.lblHsSemanales)
        Me.Controls.Add(Me.lblNuevoDocente)
        Me.Controls.Add(Me.btnAgregarAsignatura)
        Me.Controls.Add(lblTitulo)
        Me.Controls.Add(Me.txtApellido)
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
        CType(Me.numGradoArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuEdicionDocente.ResumeLayout(False)
        CType(Me.btnEliminarAsignatura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnLimpiarAsignatura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGrado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogoMAITs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAyudabtnEliminarAsignatura.ResumeLayout(False)
        Me.pnlAyudabtnAgregarAsignatura.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents cmbGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents lblGrupo As System.Windows.Forms.Label
    Friend WithEvents btnAgregarAsignatura As System.Windows.Forms.Button
    Friend WithEvents pnlFondo As System.Windows.Forms.Panel
    Friend WithEvents lblCantidadDocentes As System.Windows.Forms.Label
    Friend WithEvents pnlDocentePlantilla As System.Windows.Forms.Panel
    Friend WithEvents btnDocentePlantilla As System.Windows.Forms.Button
    Friend WithEvents btnEliminarPlantilla As System.Windows.Forms.Button
    Friend WithEvents btnEditarPlantilla As System.Windows.Forms.Button
    Friend WithEvents pnlDocentes As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnNuevoDocente As System.Windows.Forms.Button
    Friend WithEvents lblNuevoDocente As System.Windows.Forms.Label
    Friend WithEvents btnCancelarEdicion As System.Windows.Forms.Button
    Friend WithEvents btnAgregarDocente As System.Windows.Forms.Button
    Friend WithEvents numGradoArea As System.Windows.Forms.NumericUpDown
    Friend WithEvents lstAsignaturas As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmbArea As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAsignatura As System.Windows.Forms.ComboBox
    Friend WithEvents btnLimpiarAsignatura As System.Windows.Forms.PictureBox
    Friend WithEvents btnEliminarAsignatura As System.Windows.Forms.PictureBox
    Friend WithEvents mnuEdicionDocente As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DatosDelDocenteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsignaturasDelDocenteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents numGrado As System.Windows.Forms.NumericUpDown
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents imgLogoMAITs As System.Windows.Forms.PictureBox
    Friend WithEvents pnlAyudabtnEliminarAsignatura As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlAyudabtnAgregarAsignatura As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnHorariosDocente As System.Windows.Forms.Button

End Class
