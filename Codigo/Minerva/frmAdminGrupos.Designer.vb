<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminGrupos
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
        Dim lblTitulo As System.Windows.Forms.Label
        Dim lblGrupos As System.Windows.Forms.Label
        Me.lblIDGrupo = New System.Windows.Forms.Label()
        Me.lblSalon = New System.Windows.Forms.Label()
        Me.cmbSalon = New System.Windows.Forms.ComboBox()
        Me.cmbTurno = New System.Windows.Forms.ComboBox()
        Me.lblTurno = New System.Windows.Forms.Label()
        Me.lblCantAlumnos = New System.Windows.Forms.Label()
        Me.txtIDGrupo = New System.Windows.Forms.TextBox()
        Me.cmbCurso = New System.Windows.Forms.ComboBox()
        Me.lblCurso = New System.Windows.Forms.Label()
        Me.cmbOrientacion = New System.Windows.Forms.ComboBox()
        Me.lblOrientacion = New System.Windows.Forms.Label()
        Me.lblGrado = New System.Windows.Forms.Label()
        Me.numGrado = New System.Windows.Forms.NumericUpDown()
        Me.lblObligatorio1 = New System.Windows.Forms.Label()
        Me.lblObligatorio3 = New System.Windows.Forms.Label()
        Me.lblObligatorio5 = New System.Windows.Forms.Label()
        Me.lblObligatorio4 = New System.Windows.Forms.Label()
        Me.lblObligatorio6 = New System.Windows.Forms.Label()
        Me.lblObligatorio2 = New System.Windows.Forms.Label()
        Me.numAlumnos = New System.Windows.Forms.NumericUpDown()
        Me.btnNuevoGrupo = New System.Windows.Forms.Button()
        Me.lblNuevoGrupo = New System.Windows.Forms.Label()
        Me.btnCancelarEdicion = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.pnlFondo = New System.Windows.Forms.Panel()
        Me.lblCantidadGrupos = New System.Windows.Forms.Label()
        Me.pnlGrupos = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlGrupoPlantilla = New System.Windows.Forms.Panel()
        Me.btnGrupoPlantilla = New System.Windows.Forms.Button()
        Me.btnEliminarPlantilla = New System.Windows.Forms.Button()
        Me.btnEditarPlantilla = New System.Windows.Forms.Button()
        Me.lblObligatorio7 = New System.Windows.Forms.Label()
        Me.txtIDDB = New System.Windows.Forms.TextBox()
        Me.lblIDDB = New System.Windows.Forms.Label()
        lblTitulo = New System.Windows.Forms.Label()
        lblGrupos = New System.Windows.Forms.Label()
        CType(Me.numGrado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAlumnos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFondo.SuspendLayout()
        Me.pnlGrupoPlantilla.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        lblTitulo.AutoSize = True
        lblTitulo.Font = New System.Drawing.Font("Corbel", 28.0!, System.Drawing.FontStyle.Bold)
        lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        lblTitulo.Location = New System.Drawing.Point(17, 12)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New System.Drawing.Size(315, 46)
        lblTitulo.TabIndex = 95
        lblTitulo.Text = "Gestión de grupos"
        '
        'lblGrupos
        '
        lblGrupos.AutoSize = True
        lblGrupos.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        lblGrupos.Font = New System.Drawing.Font("Corbel", 27.0!, System.Drawing.FontStyle.Bold)
        lblGrupos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        lblGrupos.Location = New System.Drawing.Point(13, 12)
        lblGrupos.Name = "lblGrupos"
        lblGrupos.Size = New System.Drawing.Size(256, 44)
        lblGrupos.TabIndex = 2
        lblGrupos.Text = "Lista de grupos"
        '
        'lblIDGrupo
        '
        Me.lblIDGrupo.AutoSize = True
        Me.lblIDGrupo.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblIDGrupo.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblIDGrupo.Location = New System.Drawing.Point(179, 129)
        Me.lblIDGrupo.Name = "lblIDGrupo"
        Me.lblIDGrupo.Size = New System.Drawing.Size(104, 29)
        Me.lblIDGrupo.TabIndex = 67
        Me.lblIDGrupo.Text = "ID Grupo"
        '
        'lblSalon
        '
        Me.lblSalon.AutoSize = True
        Me.lblSalon.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblSalon.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblSalon.Location = New System.Drawing.Point(180, 221)
        Me.lblSalon.Name = "lblSalon"
        Me.lblSalon.Size = New System.Drawing.Size(71, 29)
        Me.lblSalon.TabIndex = 69
        Me.lblSalon.Text = "Salón"
        '
        'cmbSalon
        '
        Me.cmbSalon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSalon.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.cmbSalon.FormattingEnabled = True
        Me.cmbSalon.Items.AddRange(New Object() {"Sin asignar"})
        Me.cmbSalon.Location = New System.Drawing.Point(184, 253)
        Me.cmbSalon.Name = "cmbSalon"
        Me.cmbSalon.Size = New System.Drawing.Size(140, 34)
        Me.cmbSalon.TabIndex = 75
        '
        'cmbTurno
        '
        Me.cmbTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTurno.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.cmbTurno.FormattingEnabled = True
        Me.cmbTurno.Items.AddRange(New Object() {"N. Turno 1", "N. Turno 2", "N. Turno 3", "N. Turno 4", "N. Turno 5"})
        Me.cmbTurno.Location = New System.Drawing.Point(25, 253)
        Me.cmbTurno.Name = "cmbTurno"
        Me.cmbTurno.Size = New System.Drawing.Size(116, 34)
        Me.cmbTurno.TabIndex = 77
        '
        'lblTurno
        '
        Me.lblTurno.AutoSize = True
        Me.lblTurno.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTurno.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblTurno.Location = New System.Drawing.Point(20, 221)
        Me.lblTurno.Name = "lblTurno"
        Me.lblTurno.Size = New System.Drawing.Size(72, 29)
        Me.lblTurno.TabIndex = 76
        Me.lblTurno.Text = "Turno"
        '
        'lblCantAlumnos
        '
        Me.lblCantAlumnos.AutoSize = True
        Me.lblCantAlumnos.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblCantAlumnos.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblCantAlumnos.Location = New System.Drawing.Point(20, 316)
        Me.lblCantAlumnos.Name = "lblCantAlumnos"
        Me.lblCantAlumnos.Size = New System.Drawing.Size(163, 29)
        Me.lblCantAlumnos.TabIndex = 78
        Me.lblCantAlumnos.Text = "Cant. Alumnos"
        '
        'txtIDGrupo
        '
        Me.txtIDGrupo.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.txtIDGrupo.Location = New System.Drawing.Point(184, 161)
        Me.txtIDGrupo.Name = "txtIDGrupo"
        Me.txtIDGrupo.Size = New System.Drawing.Size(121, 34)
        Me.txtIDGrupo.TabIndex = 80
        Me.txtIDGrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbCurso
        '
        Me.cmbCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCurso.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.cmbCurso.FormattingEnabled = True
        Me.cmbCurso.Items.AddRange(New Object() {"Curso 1", "Curso 2"})
        Me.cmbCurso.Location = New System.Drawing.Point(373, 161)
        Me.cmbCurso.Name = "cmbCurso"
        Me.cmbCurso.Size = New System.Drawing.Size(140, 34)
        Me.cmbCurso.TabIndex = 82
        '
        'lblCurso
        '
        Me.lblCurso.AutoSize = True
        Me.lblCurso.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblCurso.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblCurso.Location = New System.Drawing.Point(368, 129)
        Me.lblCurso.Name = "lblCurso"
        Me.lblCurso.Size = New System.Drawing.Size(71, 29)
        Me.lblCurso.TabIndex = 81
        Me.lblCurso.Text = "Curso"
        '
        'cmbOrientacion
        '
        Me.cmbOrientacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrientacion.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.cmbOrientacion.FormattingEnabled = True
        Me.cmbOrientacion.Items.AddRange(New Object() {"Orientación 1", "Orientación 2"})
        Me.cmbOrientacion.Location = New System.Drawing.Point(373, 253)
        Me.cmbOrientacion.Name = "cmbOrientacion"
        Me.cmbOrientacion.Size = New System.Drawing.Size(140, 34)
        Me.cmbOrientacion.TabIndex = 84
        '
        'lblOrientacion
        '
        Me.lblOrientacion.AutoSize = True
        Me.lblOrientacion.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblOrientacion.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblOrientacion.Location = New System.Drawing.Point(368, 221)
        Me.lblOrientacion.Name = "lblOrientacion"
        Me.lblOrientacion.Size = New System.Drawing.Size(134, 29)
        Me.lblOrientacion.TabIndex = 83
        Me.lblOrientacion.Text = "Orientación"
        '
        'lblGrado
        '
        Me.lblGrado.AutoSize = True
        Me.lblGrado.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblGrado.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblGrado.Location = New System.Drawing.Point(20, 129)
        Me.lblGrado.Name = "lblGrado"
        Me.lblGrado.Size = New System.Drawing.Size(75, 29)
        Me.lblGrado.TabIndex = 86
        Me.lblGrado.Text = "Grado"
        '
        'numGrado
        '
        Me.numGrado.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.numGrado.Location = New System.Drawing.Point(27, 162)
        Me.numGrado.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.numGrado.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numGrado.Name = "numGrado"
        Me.numGrado.Size = New System.Drawing.Size(120, 34)
        Me.numGrado.TabIndex = 87
        Me.numGrado.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblObligatorio1
        '
        Me.lblObligatorio1.BackColor = System.Drawing.Color.Transparent
        Me.lblObligatorio1.Cursor = System.Windows.Forms.Cursors.Help
        Me.lblObligatorio1.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblObligatorio1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblObligatorio1.Location = New System.Drawing.Point(124, 132)
        Me.lblObligatorio1.Name = "lblObligatorio1"
        Me.lblObligatorio1.Size = New System.Drawing.Size(23, 23)
        Me.lblObligatorio1.TabIndex = 88
        Me.lblObligatorio1.Text = "*"
        '
        'lblObligatorio3
        '
        Me.lblObligatorio3.BackColor = System.Drawing.Color.Transparent
        Me.lblObligatorio3.Cursor = System.Windows.Forms.Cursors.Help
        Me.lblObligatorio3.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblObligatorio3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblObligatorio3.Location = New System.Drawing.Point(285, 132)
        Me.lblObligatorio3.Name = "lblObligatorio3"
        Me.lblObligatorio3.Size = New System.Drawing.Size(23, 23)
        Me.lblObligatorio3.TabIndex = 89
        Me.lblObligatorio3.Text = "*"
        '
        'lblObligatorio5
        '
        Me.lblObligatorio5.BackColor = System.Drawing.Color.Transparent
        Me.lblObligatorio5.Cursor = System.Windows.Forms.Cursors.Help
        Me.lblObligatorio5.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblObligatorio5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblObligatorio5.Location = New System.Drawing.Point(490, 132)
        Me.lblObligatorio5.Name = "lblObligatorio5"
        Me.lblObligatorio5.Size = New System.Drawing.Size(23, 23)
        Me.lblObligatorio5.TabIndex = 90
        Me.lblObligatorio5.Text = "*"
        '
        'lblObligatorio4
        '
        Me.lblObligatorio4.BackColor = System.Drawing.Color.Transparent
        Me.lblObligatorio4.Cursor = System.Windows.Forms.Cursors.Help
        Me.lblObligatorio4.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblObligatorio4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblObligatorio4.Location = New System.Drawing.Point(301, 224)
        Me.lblObligatorio4.Name = "lblObligatorio4"
        Me.lblObligatorio4.Size = New System.Drawing.Size(23, 23)
        Me.lblObligatorio4.TabIndex = 91
        Me.lblObligatorio4.Text = "*"
        '
        'lblObligatorio6
        '
        Me.lblObligatorio6.BackColor = System.Drawing.Color.Transparent
        Me.lblObligatorio6.Cursor = System.Windows.Forms.Cursors.Help
        Me.lblObligatorio6.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblObligatorio6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblObligatorio6.Location = New System.Drawing.Point(499, 224)
        Me.lblObligatorio6.Name = "lblObligatorio6"
        Me.lblObligatorio6.Size = New System.Drawing.Size(23, 23)
        Me.lblObligatorio6.TabIndex = 92
        Me.lblObligatorio6.Text = "*"
        '
        'lblObligatorio2
        '
        Me.lblObligatorio2.BackColor = System.Drawing.Color.Transparent
        Me.lblObligatorio2.Cursor = System.Windows.Forms.Cursors.Help
        Me.lblObligatorio2.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblObligatorio2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblObligatorio2.Location = New System.Drawing.Point(124, 227)
        Me.lblObligatorio2.Name = "lblObligatorio2"
        Me.lblObligatorio2.Size = New System.Drawing.Size(23, 23)
        Me.lblObligatorio2.TabIndex = 93
        Me.lblObligatorio2.Text = "*"
        '
        'numAlumnos
        '
        Me.numAlumnos.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.numAlumnos.Location = New System.Drawing.Point(27, 348)
        Me.numAlumnos.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.numAlumnos.Name = "numAlumnos"
        Me.numAlumnos.Size = New System.Drawing.Size(120, 34)
        Me.numAlumnos.TabIndex = 94
        '
        'btnNuevoGrupo
        '
        Me.btnNuevoGrupo.AutoSize = True
        Me.btnNuevoGrupo.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnNuevoGrupo.Location = New System.Drawing.Point(378, 21)
        Me.btnNuevoGrupo.Name = "btnNuevoGrupo"
        Me.btnNuevoGrupo.Size = New System.Drawing.Size(105, 29)
        Me.btnNuevoGrupo.TabIndex = 97
        Me.btnNuevoGrupo.Text = "Nuevo grupo"
        Me.btnNuevoGrupo.UseVisualStyleBackColor = True
        Me.btnNuevoGrupo.Visible = False
        '
        'lblNuevoGrupo
        '
        Me.lblNuevoGrupo.AutoSize = True
        Me.lblNuevoGrupo.BackColor = System.Drawing.Color.Transparent
        Me.lblNuevoGrupo.Font = New System.Drawing.Font("Corbel", 28.0!)
        Me.lblNuevoGrupo.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblNuevoGrupo.Location = New System.Drawing.Point(17, 58)
        Me.lblNuevoGrupo.Name = "lblNuevoGrupo"
        Me.lblNuevoGrupo.Size = New System.Drawing.Size(224, 46)
        Me.lblNuevoGrupo.TabIndex = 96
        Me.lblNuevoGrupo.Text = "Nuevo grupo"
        '
        'btnCancelarEdicion
        '
        Me.btnCancelarEdicion.AutoSize = True
        Me.btnCancelarEdicion.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnCancelarEdicion.Location = New System.Drawing.Point(461, 445)
        Me.btnCancelarEdicion.Name = "btnCancelarEdicion"
        Me.btnCancelarEdicion.Size = New System.Drawing.Size(154, 29)
        Me.btnCancelarEdicion.TabIndex = 99
        Me.btnCancelarEdicion.Text = "Cancelar edición"
        Me.btnCancelarEdicion.UseVisualStyleBackColor = True
        Me.btnCancelarEdicion.Visible = False
        '
        'btnAgregar
        '
        Me.btnAgregar.AutoSize = True
        Me.btnAgregar.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnAgregar.Location = New System.Drawing.Point(461, 410)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(154, 29)
        Me.btnAgregar.TabIndex = 98
        Me.btnAgregar.Text = "Agregar salón"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'pnlFondo
        '
        Me.pnlFondo.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.pnlFondo.Controls.Add(Me.lblCantidadGrupos)
        Me.pnlFondo.Controls.Add(Me.pnlGrupos)
        Me.pnlFondo.Controls.Add(lblGrupos)
        Me.pnlFondo.Controls.Add(Me.pnlGrupoPlantilla)
        Me.pnlFondo.Location = New System.Drawing.Point(639, 0)
        Me.pnlFondo.Name = "pnlFondo"
        Me.pnlFondo.Size = New System.Drawing.Size(365, 501)
        Me.pnlFondo.TabIndex = 100
        '
        'lblCantidadGrupos
        '
        Me.lblCantidadGrupos.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lblCantidadGrupos.Font = New System.Drawing.Font("Corbel", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblCantidadGrupos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblCantidadGrupos.Location = New System.Drawing.Point(269, 18)
        Me.lblCantidadGrupos.Name = "lblCantidadGrupos"
        Me.lblCantidadGrupos.Size = New System.Drawing.Size(89, 40)
        Me.lblCantidadGrupos.TabIndex = 34
        Me.lblCantidadGrupos.Text = "(0)"
        '
        'pnlGrupos
        '
        Me.pnlGrupos.AutoScroll = True
        Me.pnlGrupos.Location = New System.Drawing.Point(21, 61)
        Me.pnlGrupos.Name = "pnlGrupos"
        Me.pnlGrupos.Size = New System.Drawing.Size(337, 413)
        Me.pnlGrupos.TabIndex = 33
        '
        'pnlGrupoPlantilla
        '
        Me.pnlGrupoPlantilla.Controls.Add(Me.btnGrupoPlantilla)
        Me.pnlGrupoPlantilla.Controls.Add(Me.btnEliminarPlantilla)
        Me.pnlGrupoPlantilla.Controls.Add(Me.btnEditarPlantilla)
        Me.pnlGrupoPlantilla.Location = New System.Drawing.Point(0, 0)
        Me.pnlGrupoPlantilla.Name = "pnlGrupoPlantilla"
        Me.pnlGrupoPlantilla.Size = New System.Drawing.Size(305, 56)
        Me.pnlGrupoPlantilla.TabIndex = 0
        Me.pnlGrupoPlantilla.Visible = False
        '
        'btnGrupoPlantilla
        '
        Me.btnGrupoPlantilla.BackColor = System.Drawing.SystemColors.GrayText
        Me.btnGrupoPlantilla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGrupoPlantilla.FlatAppearance.BorderColor = System.Drawing.Color.Tomato
        Me.btnGrupoPlantilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrupoPlantilla.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.btnGrupoPlantilla.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnGrupoPlantilla.Location = New System.Drawing.Point(0, 3)
        Me.btnGrupoPlantilla.Name = "btnGrupoPlantilla"
        Me.btnGrupoPlantilla.Size = New System.Drawing.Size(207, 48)
        Me.btnGrupoPlantilla.TabIndex = 0
        Me.btnGrupoPlantilla.Text = "Template salón"
        Me.btnGrupoPlantilla.UseVisualStyleBackColor = False
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
        'lblObligatorio7
        '
        Me.lblObligatorio7.BackColor = System.Drawing.Color.Transparent
        Me.lblObligatorio7.Cursor = System.Windows.Forms.Cursors.Help
        Me.lblObligatorio7.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblObligatorio7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblObligatorio7.Location = New System.Drawing.Point(288, 319)
        Me.lblObligatorio7.Name = "lblObligatorio7"
        Me.lblObligatorio7.Size = New System.Drawing.Size(23, 23)
        Me.lblObligatorio7.TabIndex = 103
        Me.lblObligatorio7.Text = "*"
        '
        'txtIDDB
        '
        Me.txtIDDB.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.txtIDDB.Location = New System.Drawing.Point(188, 348)
        Me.txtIDDB.Name = "txtIDDB"
        Me.txtIDDB.Size = New System.Drawing.Size(121, 34)
        Me.txtIDDB.TabIndex = 102
        Me.txtIDDB.Text = "id db"
        Me.txtIDDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIDDB
        '
        Me.lblIDDB.AutoSize = True
        Me.lblIDDB.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblIDDB.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblIDDB.Location = New System.Drawing.Point(182, 316)
        Me.lblIDDB.Name = "lblIDDB"
        Me.lblIDDB.Size = New System.Drawing.Size(101, 29)
        Me.lblIDDB.TabIndex = 101
        Me.lblIDDB.Text = "ID Único"
        '
        'frmAdminGrupos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Controls.Add(Me.lblObligatorio7)
        Me.Controls.Add(Me.txtIDDB)
        Me.Controls.Add(Me.lblIDDB)
        Me.Controls.Add(Me.btnCancelarEdicion)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnNuevoGrupo)
        Me.Controls.Add(Me.lblNuevoGrupo)
        Me.Controls.Add(lblTitulo)
        Me.Controls.Add(Me.numAlumnos)
        Me.Controls.Add(Me.lblObligatorio2)
        Me.Controls.Add(Me.lblObligatorio6)
        Me.Controls.Add(Me.lblObligatorio4)
        Me.Controls.Add(Me.lblObligatorio5)
        Me.Controls.Add(Me.lblObligatorio3)
        Me.Controls.Add(Me.lblObligatorio1)
        Me.Controls.Add(Me.numGrado)
        Me.Controls.Add(Me.lblGrado)
        Me.Controls.Add(Me.cmbOrientacion)
        Me.Controls.Add(Me.lblOrientacion)
        Me.Controls.Add(Me.cmbCurso)
        Me.Controls.Add(Me.lblCurso)
        Me.Controls.Add(Me.txtIDGrupo)
        Me.Controls.Add(Me.lblCantAlumnos)
        Me.Controls.Add(Me.cmbTurno)
        Me.Controls.Add(Me.lblTurno)
        Me.Controls.Add(Me.cmbSalon)
        Me.Controls.Add(Me.lblIDGrupo)
        Me.Controls.Add(Me.lblSalon)
        Me.Controls.Add(Me.pnlFondo)
        Me.Name = "frmAdminGrupos"
        Me.Size = New System.Drawing.Size(1004, 493)
        CType(Me.numGrado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAlumnos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFondo.ResumeLayout(False)
        Me.pnlFondo.PerformLayout()
        Me.pnlGrupoPlantilla.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblIDGrupo As System.Windows.Forms.Label
    Friend WithEvents lblSalon As System.Windows.Forms.Label
    Friend WithEvents cmbSalon As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTurno As System.Windows.Forms.ComboBox
    Friend WithEvents lblTurno As System.Windows.Forms.Label
    Friend WithEvents lblCantAlumnos As System.Windows.Forms.Label
    Friend WithEvents txtIDGrupo As System.Windows.Forms.TextBox
    Friend WithEvents cmbCurso As System.Windows.Forms.ComboBox
    Friend WithEvents lblCurso As System.Windows.Forms.Label
    Friend WithEvents cmbOrientacion As System.Windows.Forms.ComboBox
    Friend WithEvents lblOrientacion As System.Windows.Forms.Label
    Friend WithEvents lblGrado As System.Windows.Forms.Label
    Friend WithEvents numGrado As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblObligatorio1 As System.Windows.Forms.Label
    Friend WithEvents lblObligatorio3 As System.Windows.Forms.Label
    Friend WithEvents lblObligatorio5 As System.Windows.Forms.Label
    Friend WithEvents lblObligatorio4 As System.Windows.Forms.Label
    Friend WithEvents lblObligatorio6 As System.Windows.Forms.Label
    Friend WithEvents lblObligatorio2 As System.Windows.Forms.Label
    Friend WithEvents numAlumnos As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnNuevoGrupo As System.Windows.Forms.Button
    Friend WithEvents lblNuevoGrupo As System.Windows.Forms.Label
    Friend WithEvents btnCancelarEdicion As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents pnlFondo As System.Windows.Forms.Panel
    Friend WithEvents lblCantidadGrupos As System.Windows.Forms.Label
    Friend WithEvents pnlGrupoPlantilla As System.Windows.Forms.Panel
    Friend WithEvents btnGrupoPlantilla As System.Windows.Forms.Button
    Friend WithEvents btnEliminarPlantilla As System.Windows.Forms.Button
    Friend WithEvents btnEditarPlantilla As System.Windows.Forms.Button
    Friend WithEvents pnlGrupos As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblObligatorio7 As System.Windows.Forms.Label
    Friend WithEvents txtIDDB As System.Windows.Forms.TextBox
    Friend WithEvents lblIDDB As System.Windows.Forms.Label

End Class
