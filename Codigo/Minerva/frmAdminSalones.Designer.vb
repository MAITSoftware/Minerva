<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminSalones
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
        Dim lblSalones As System.Windows.Forms.Label
        Dim lblTitulo As System.Windows.Forms.Label
        Me.lblNuevoSalon = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.txtIDSalon = New System.Windows.Forms.TextBox()
        Me.lblIDSalon = New System.Windows.Forms.Label()
        Me.cmbPlanta = New System.Windows.Forms.ComboBox()
        Me.lblPlanta = New System.Windows.Forms.Label()
        Me.lblSalonesAsignados = New System.Windows.Forms.Label()
        Me.lblTurno1 = New System.Windows.Forms.Label()
        Me.lblTurno3 = New System.Windows.Forms.Label()
        Me.lblTurno2 = New System.Windows.Forms.Label()
        Me.cmbTurno4 = New System.Windows.Forms.ComboBox()
        Me.lblTurno4 = New System.Windows.Forms.Label()
        Me.lblTurno5 = New System.Windows.Forms.Label()
        Me.txtComentarios = New System.Windows.Forms.TextBox()
        Me.lblComentarios = New System.Windows.Forms.Label()
        Me.btnCancelarEdicion = New System.Windows.Forms.Button()
        Me.pnlFondo = New System.Windows.Forms.Panel()
        Me.lblCantidadSalones = New System.Windows.Forms.Label()
        Me.pnlSalonPlantilla = New System.Windows.Forms.Panel()
        Me.btnSalonPlantilla = New System.Windows.Forms.Button()
        Me.btnEliminarPlantilla = New System.Windows.Forms.Button()
        Me.btnEditarPlantilla = New System.Windows.Forms.Button()
        Me.pnlSalones = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmbTurno1 = New System.Windows.Forms.ComboBox()
        Me.cmbTurno2 = New System.Windows.Forms.ComboBox()
        Me.cmbTurno5 = New System.Windows.Forms.ComboBox()
        Me.cmbTurno3 = New System.Windows.Forms.ComboBox()
        Me.btnNuevoSalon = New System.Windows.Forms.Button()
        Me.lblObligatorioID = New System.Windows.Forms.Label()
        Me.lblObligatorioPlanta = New System.Windows.Forms.Label()
        lblSalones = New System.Windows.Forms.Label()
        lblTitulo = New System.Windows.Forms.Label()
        Me.pnlFondo.SuspendLayout()
        Me.pnlSalonPlantilla.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSalones
        '
        lblSalones.AutoSize = True
        lblSalones.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        lblSalones.Font = New System.Drawing.Font("Corbel", 27.0!, System.Drawing.FontStyle.Bold)
        lblSalones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        lblSalones.Location = New System.Drawing.Point(13, 12)
        lblSalones.Name = "lblSalones"
        lblSalones.Size = New System.Drawing.Size(264, 44)
        lblSalones.TabIndex = 2
        lblSalones.Text = "Lista de salones"
        '
        'lblTitulo
        '
        lblTitulo.AutoSize = True
        lblTitulo.Font = New System.Drawing.Font("Corbel", 28.0!, System.Drawing.FontStyle.Bold)
        lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        lblTitulo.Location = New System.Drawing.Point(17, 12)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New System.Drawing.Size(325, 46)
        lblTitulo.TabIndex = 5
        lblTitulo.Text = "Gestión de salones"
        '
        'lblNuevoSalon
        '
        Me.lblNuevoSalon.AutoSize = True
        Me.lblNuevoSalon.BackColor = System.Drawing.Color.Transparent
        Me.lblNuevoSalon.Font = New System.Drawing.Font("Corbel", 28.0!)
        Me.lblNuevoSalon.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblNuevoSalon.Location = New System.Drawing.Point(17, 58)
        Me.lblNuevoSalon.Name = "lblNuevoSalon"
        Me.lblNuevoSalon.Size = New System.Drawing.Size(214, 46)
        Me.lblNuevoSalon.TabIndex = 29
        Me.lblNuevoSalon.Text = "Nuevo salón"
        '
        'btnAgregar
        '
        Me.btnAgregar.AutoSize = True
        Me.btnAgregar.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnAgregar.Location = New System.Drawing.Point(461, 410)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(154, 29)
        Me.btnAgregar.TabIndex = 4
        Me.btnAgregar.Text = "Agregar salón"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'txtIDSalon
        '
        Me.txtIDSalon.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.txtIDSalon.Location = New System.Drawing.Point(26, 161)
        Me.txtIDSalon.Name = "txtIDSalon"
        Me.txtIDSalon.Size = New System.Drawing.Size(114, 34)
        Me.txtIDSalon.TabIndex = 6
        Me.txtIDSalon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIDSalon
        '
        Me.lblIDSalon.AutoSize = True
        Me.lblIDSalon.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblIDSalon.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblIDSalon.Location = New System.Drawing.Point(21, 129)
        Me.lblIDSalon.Name = "lblIDSalon"
        Me.lblIDSalon.Size = New System.Drawing.Size(99, 29)
        Me.lblIDSalon.TabIndex = 7
        Me.lblIDSalon.Text = "ID Salón"
        '
        'cmbPlanta
        '
        Me.cmbPlanta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlanta.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.cmbPlanta.FormattingEnabled = True
        Me.cmbPlanta.Items.AddRange(New Object() {"Alta", "Baja", "Exterior"})
        Me.cmbPlanta.Location = New System.Drawing.Point(160, 161)
        Me.cmbPlanta.Name = "cmbPlanta"
        Me.cmbPlanta.Size = New System.Drawing.Size(121, 34)
        Me.cmbPlanta.TabIndex = 11
        '
        'lblPlanta
        '
        Me.lblPlanta.AutoSize = True
        Me.lblPlanta.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblPlanta.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblPlanta.Location = New System.Drawing.Point(155, 129)
        Me.lblPlanta.Name = "lblPlanta"
        Me.lblPlanta.Size = New System.Drawing.Size(79, 29)
        Me.lblPlanta.TabIndex = 12
        Me.lblPlanta.Text = "Planta"
        '
        'lblSalonesAsignados
        '
        Me.lblSalonesAsignados.AutoSize = True
        Me.lblSalonesAsignados.BackColor = System.Drawing.Color.Transparent
        Me.lblSalonesAsignados.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblSalonesAsignados.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblSalonesAsignados.Location = New System.Drawing.Point(294, 96)
        Me.lblSalonesAsignados.Name = "lblSalonesAsignados"
        Me.lblSalonesAsignados.Size = New System.Drawing.Size(126, 29)
        Me.lblSalonesAsignados.TabIndex = 16
        Me.lblSalonesAsignados.Text = "Asignado a"
        '
        'lblTurno1
        '
        Me.lblTurno1.AutoSize = True
        Me.lblTurno1.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTurno1.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblTurno1.Location = New System.Drawing.Point(314, 129)
        Me.lblTurno1.Name = "lblTurno1"
        Me.lblTurno1.Size = New System.Drawing.Size(89, 29)
        Me.lblTurno1.TabIndex = 17
        Me.lblTurno1.Text = "Turno 1"
        '
        'lblTurno3
        '
        Me.lblTurno3.AutoSize = True
        Me.lblTurno3.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTurno3.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblTurno3.Location = New System.Drawing.Point(314, 275)
        Me.lblTurno3.Name = "lblTurno3"
        Me.lblTurno3.Size = New System.Drawing.Size(89, 29)
        Me.lblTurno3.TabIndex = 19
        Me.lblTurno3.Text = "Turno 3"
        '
        'lblTurno2
        '
        Me.lblTurno2.AutoSize = True
        Me.lblTurno2.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTurno2.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblTurno2.Location = New System.Drawing.Point(314, 202)
        Me.lblTurno2.Name = "lblTurno2"
        Me.lblTurno2.Size = New System.Drawing.Size(89, 29)
        Me.lblTurno2.TabIndex = 21
        Me.lblTurno2.Text = "Turno 2"
        '
        'cmbTurno4
        '
        Me.cmbTurno4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTurno4.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.cmbTurno4.FormattingEnabled = True
        Me.cmbTurno4.Items.AddRange(New Object() {"Sin asignar"})
        Me.cmbTurno4.Location = New System.Drawing.Point(461, 161)
        Me.cmbTurno4.Name = "cmbTurno4"
        Me.cmbTurno4.Size = New System.Drawing.Size(121, 34)
        Me.cmbTurno4.TabIndex = 24
        '
        'lblTurno4
        '
        Me.lblTurno4.AutoSize = True
        Me.lblTurno4.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTurno4.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblTurno4.Location = New System.Drawing.Point(456, 129)
        Me.lblTurno4.Name = "lblTurno4"
        Me.lblTurno4.Size = New System.Drawing.Size(90, 29)
        Me.lblTurno4.TabIndex = 23
        Me.lblTurno4.Text = "Turno 4"
        '
        'lblTurno5
        '
        Me.lblTurno5.AutoSize = True
        Me.lblTurno5.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTurno5.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblTurno5.Location = New System.Drawing.Point(456, 202)
        Me.lblTurno5.Name = "lblTurno5"
        Me.lblTurno5.Size = New System.Drawing.Size(89, 29)
        Me.lblTurno5.TabIndex = 25
        Me.lblTurno5.Text = "Turno 5"
        '
        'txtComentarios
        '
        Me.txtComentarios.AcceptsReturn = True
        Me.txtComentarios.Location = New System.Drawing.Point(28, 277)
        Me.txtComentarios.MaxLength = 2000
        Me.txtComentarios.Multiline = True
        Me.txtComentarios.Name = "txtComentarios"
        Me.txtComentarios.Size = New System.Drawing.Size(256, 129)
        Me.txtComentarios.TabIndex = 27
        '
        'lblComentarios
        '
        Me.lblComentarios.AutoSize = True
        Me.lblComentarios.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblComentarios.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblComentarios.Location = New System.Drawing.Point(19, 245)
        Me.lblComentarios.Name = "lblComentarios"
        Me.lblComentarios.Size = New System.Drawing.Size(262, 29)
        Me.lblComentarios.TabIndex = 28
        Me.lblComentarios.Text = "Comentarios adicionales"
        '
        'btnCancelarEdicion
        '
        Me.btnCancelarEdicion.AutoSize = True
        Me.btnCancelarEdicion.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnCancelarEdicion.Location = New System.Drawing.Point(461, 445)
        Me.btnCancelarEdicion.Name = "btnCancelarEdicion"
        Me.btnCancelarEdicion.Size = New System.Drawing.Size(154, 29)
        Me.btnCancelarEdicion.TabIndex = 30
        Me.btnCancelarEdicion.Text = "Cancelar edición"
        Me.btnCancelarEdicion.UseVisualStyleBackColor = True
        Me.btnCancelarEdicion.Visible = False
        '
        'pnlFondo
        '
        Me.pnlFondo.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.pnlFondo.Controls.Add(Me.lblCantidadSalones)
        Me.pnlFondo.Controls.Add(Me.pnlSalonPlantilla)
        Me.pnlFondo.Controls.Add(Me.pnlSalones)
        Me.pnlFondo.Controls.Add(lblSalones)
        Me.pnlFondo.Location = New System.Drawing.Point(639, 0)
        Me.pnlFondo.Name = "pnlFondo"
        Me.pnlFondo.Size = New System.Drawing.Size(365, 501)
        Me.pnlFondo.TabIndex = 36
        '
        'lblCantidadSalones
        '
        Me.lblCantidadSalones.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lblCantidadSalones.Font = New System.Drawing.Font("Corbel", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblCantidadSalones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblCantidadSalones.Location = New System.Drawing.Point(269, 18)
        Me.lblCantidadSalones.Name = "lblCantidadSalones"
        Me.lblCantidadSalones.Size = New System.Drawing.Size(89, 40)
        Me.lblCantidadSalones.TabIndex = 34
        Me.lblCantidadSalones.Text = "(0)"
        '
        'pnlSalonPlantilla
        '
        Me.pnlSalonPlantilla.Controls.Add(Me.btnSalonPlantilla)
        Me.pnlSalonPlantilla.Controls.Add(Me.btnEliminarPlantilla)
        Me.pnlSalonPlantilla.Controls.Add(Me.btnEditarPlantilla)
        Me.pnlSalonPlantilla.Location = New System.Drawing.Point(0, 0)
        Me.pnlSalonPlantilla.Name = "pnlSalonPlantilla"
        Me.pnlSalonPlantilla.Size = New System.Drawing.Size(305, 56)
        Me.pnlSalonPlantilla.TabIndex = 0
        Me.pnlSalonPlantilla.Visible = False
        '
        'btnSalonPlantilla
        '
        Me.btnSalonPlantilla.BackColor = System.Drawing.SystemColors.GrayText
        Me.btnSalonPlantilla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalonPlantilla.FlatAppearance.BorderColor = System.Drawing.Color.Tomato
        Me.btnSalonPlantilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalonPlantilla.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.btnSalonPlantilla.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSalonPlantilla.Location = New System.Drawing.Point(0, 3)
        Me.btnSalonPlantilla.Name = "btnSalonPlantilla"
        Me.btnSalonPlantilla.Size = New System.Drawing.Size(207, 48)
        Me.btnSalonPlantilla.TabIndex = 0
        Me.btnSalonPlantilla.Text = "Template salón"
        Me.btnSalonPlantilla.UseVisualStyleBackColor = False
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
        'pnlSalones
        '
        Me.pnlSalones.AutoScroll = True
        Me.pnlSalones.Location = New System.Drawing.Point(21, 61)
        Me.pnlSalones.Name = "pnlSalones"
        Me.pnlSalones.Size = New System.Drawing.Size(337, 413)
        Me.pnlSalones.TabIndex = 33
        '
        'cmbTurno1
        '
        Me.cmbTurno1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTurno1.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.cmbTurno1.FormattingEnabled = True
        Me.cmbTurno1.Items.AddRange(New Object() {"Sin asignar"})
        Me.cmbTurno1.Location = New System.Drawing.Point(319, 161)
        Me.cmbTurno1.Name = "cmbTurno1"
        Me.cmbTurno1.Size = New System.Drawing.Size(121, 34)
        Me.cmbTurno1.TabIndex = 37
        '
        'cmbTurno2
        '
        Me.cmbTurno2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTurno2.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.cmbTurno2.FormattingEnabled = True
        Me.cmbTurno2.Items.AddRange(New Object() {"Sin asignar"})
        Me.cmbTurno2.Location = New System.Drawing.Point(319, 240)
        Me.cmbTurno2.Name = "cmbTurno2"
        Me.cmbTurno2.Size = New System.Drawing.Size(121, 34)
        Me.cmbTurno2.TabIndex = 39
        '
        'cmbTurno5
        '
        Me.cmbTurno5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTurno5.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.cmbTurno5.FormattingEnabled = True
        Me.cmbTurno5.Items.AddRange(New Object() {"Sin asignar"})
        Me.cmbTurno5.Location = New System.Drawing.Point(461, 239)
        Me.cmbTurno5.Name = "cmbTurno5"
        Me.cmbTurno5.Size = New System.Drawing.Size(121, 34)
        Me.cmbTurno5.TabIndex = 38
        '
        'cmbTurno3
        '
        Me.cmbTurno3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTurno3.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.cmbTurno3.FormattingEnabled = True
        Me.cmbTurno3.Items.AddRange(New Object() {"Sin asignar"})
        Me.cmbTurno3.Location = New System.Drawing.Point(319, 309)
        Me.cmbTurno3.Name = "cmbTurno3"
        Me.cmbTurno3.Size = New System.Drawing.Size(121, 34)
        Me.cmbTurno3.TabIndex = 40
        '
        'btnNuevoSalon
        '
        Me.btnNuevoSalon.AutoSize = True
        Me.btnNuevoSalon.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnNuevoSalon.Location = New System.Drawing.Point(378, 21)
        Me.btnNuevoSalon.Name = "btnNuevoSalon"
        Me.btnNuevoSalon.Size = New System.Drawing.Size(100, 29)
        Me.btnNuevoSalon.TabIndex = 34
        Me.btnNuevoSalon.Text = "Nuevo salón"
        Me.btnNuevoSalon.UseVisualStyleBackColor = True
        Me.btnNuevoSalon.Visible = False
        '
        'lblObligatorioID
        '
        Me.lblObligatorioID.BackColor = System.Drawing.Color.Transparent
        Me.lblObligatorioID.Cursor = System.Windows.Forms.Cursors.Help
        Me.lblObligatorioID.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblObligatorioID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblObligatorioID.Location = New System.Drawing.Point(122, 132)
        Me.lblObligatorioID.Name = "lblObligatorioID"
        Me.lblObligatorioID.Size = New System.Drawing.Size(23, 23)
        Me.lblObligatorioID.TabIndex = 41
        Me.lblObligatorioID.Text = "*"
        '
        'lblObligatorioPlanta
        '
        Me.lblObligatorioPlanta.BackColor = System.Drawing.Color.Transparent
        Me.lblObligatorioPlanta.Cursor = System.Windows.Forms.Cursors.Help
        Me.lblObligatorioPlanta.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblObligatorioPlanta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblObligatorioPlanta.Location = New System.Drawing.Point(261, 132)
        Me.lblObligatorioPlanta.Name = "lblObligatorioPlanta"
        Me.lblObligatorioPlanta.Size = New System.Drawing.Size(23, 23)
        Me.lblObligatorioPlanta.TabIndex = 42
        Me.lblObligatorioPlanta.Text = "*"
        '
        'frmAdminSalones
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Controls.Add(Me.lblSalonesAsignados)
        Me.Controls.Add(Me.lblObligatorioPlanta)
        Me.Controls.Add(Me.lblObligatorioID)
        Me.Controls.Add(Me.btnNuevoSalon)
        Me.Controls.Add(Me.cmbTurno3)
        Me.Controls.Add(Me.cmbTurno2)
        Me.Controls.Add(Me.cmbTurno5)
        Me.Controls.Add(Me.cmbTurno1)
        Me.Controls.Add(Me.btnCancelarEdicion)
        Me.Controls.Add(Me.lblNuevoSalon)
        Me.Controls.Add(Me.lblComentarios)
        Me.Controls.Add(Me.txtComentarios)
        Me.Controls.Add(Me.lblTurno5)
        Me.Controls.Add(Me.cmbTurno4)
        Me.Controls.Add(Me.lblTurno4)
        Me.Controls.Add(Me.lblTurno2)
        Me.Controls.Add(Me.lblTurno3)
        Me.Controls.Add(Me.lblTurno1)
        Me.Controls.Add(Me.lblPlanta)
        Me.Controls.Add(Me.cmbPlanta)
        Me.Controls.Add(Me.lblIDSalon)
        Me.Controls.Add(Me.txtIDSalon)
        Me.Controls.Add(lblTitulo)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.pnlFondo)
        Me.Name = "frmAdminSalones"
        Me.Size = New System.Drawing.Size(1004, 493)
        Me.pnlFondo.ResumeLayout(False)
        Me.pnlFondo.PerformLayout()
        Me.pnlSalonPlantilla.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtIDSalon As System.Windows.Forms.TextBox
    Friend WithEvents lblIDSalon As System.Windows.Forms.Label
    Friend WithEvents cmbPlanta As System.Windows.Forms.ComboBox
    Friend WithEvents lblPlanta As System.Windows.Forms.Label
    Friend WithEvents lblSalonesAsignados As System.Windows.Forms.Label
    Friend WithEvents lblTurno1 As System.Windows.Forms.Label
    Friend WithEvents lblTurno3 As System.Windows.Forms.Label
    Friend WithEvents lblTurno2 As System.Windows.Forms.Label
    Friend WithEvents cmbTurno4 As System.Windows.Forms.ComboBox
    Friend WithEvents lblTurno4 As System.Windows.Forms.Label
    Friend WithEvents lblTurno5 As System.Windows.Forms.Label
    Friend WithEvents txtComentarios As System.Windows.Forms.TextBox
    Friend WithEvents lblComentarios As System.Windows.Forms.Label
    Friend WithEvents btnCancelarEdicion As System.Windows.Forms.Button
    Friend WithEvents pnlFondo As System.Windows.Forms.Panel
    Friend WithEvents pnlSalones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cmbTurno1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTurno2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTurno5 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTurno3 As System.Windows.Forms.ComboBox
    Friend WithEvents pnlSalonPlantilla As System.Windows.Forms.Panel
    Friend WithEvents btnEliminarPlantilla As System.Windows.Forms.Button
    Friend WithEvents btnEditarPlantilla As System.Windows.Forms.Button
    Friend WithEvents btnNuevoSalon As System.Windows.Forms.Button
    Friend WithEvents lblNuevoSalon As System.Windows.Forms.Label
    Friend WithEvents btnSalonPlantilla As System.Windows.Forms.Button
    Friend WithEvents lblObligatorioID As System.Windows.Forms.Label
    Friend WithEvents lblObligatorioPlanta As System.Windows.Forms.Label
    Friend WithEvents lblCantidadSalones As System.Windows.Forms.Label

End Class
