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
        Me.lblTurno2 = New System.Windows.Forms.Label()
        Me.lblTurno4 = New System.Windows.Forms.Label()
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
        Me.btnNuevoSalon = New System.Windows.Forms.Button()
        Me.imgLogoMAITs = New System.Windows.Forms.PictureBox()
        Me.lblSalonMatutino = New System.Windows.Forms.Label()
        Me.lblSalonVespertino = New System.Windows.Forms.Label()
        Me.lblSalonNocturno = New System.Windows.Forms.Label()
        lblSalones = New System.Windows.Forms.Label()
        lblTitulo = New System.Windows.Forms.Label()
        Me.pnlFondo.SuspendLayout()
        Me.pnlSalonPlantilla.SuspendLayout()
        CType(Me.imgLogoMAITs, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btnAgregar.TabIndex = 6
        Me.btnAgregar.Text = "Agregar salón"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'txtIDSalon
        '
        Me.txtIDSalon.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.txtIDSalon.Location = New System.Drawing.Point(26, 161)
        Me.txtIDSalon.MaxLength = 2
        Me.txtIDSalon.Name = "txtIDSalon"
        Me.txtIDSalon.ShortcutsEnabled = False
        Me.txtIDSalon.Size = New System.Drawing.Size(114, 34)
        Me.txtIDSalon.TabIndex = 0
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
        Me.cmbPlanta.TabIndex = 1
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
        Me.lblTurno1.Location = New System.Drawing.Point(314, 140)
        Me.lblTurno1.Name = "lblTurno1"
        Me.lblTurno1.Size = New System.Drawing.Size(132, 29)
        Me.lblTurno1.TabIndex = 17
        Me.lblTurno1.Text = "T. matutino"
        '
        'lblTurno2
        '
        Me.lblTurno2.AutoSize = True
        Me.lblTurno2.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTurno2.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblTurno2.Location = New System.Drawing.Point(314, 223)
        Me.lblTurno2.Name = "lblTurno2"
        Me.lblTurno2.Size = New System.Drawing.Size(130, 29)
        Me.lblTurno2.TabIndex = 21
        Me.lblTurno2.Text = "T. nocturno"
        '
        'lblTurno4
        '
        Me.lblTurno4.AutoSize = True
        Me.lblTurno4.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTurno4.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblTurno4.Location = New System.Drawing.Point(456, 140)
        Me.lblTurno4.Name = "lblTurno4"
        Me.lblTurno4.Size = New System.Drawing.Size(145, 29)
        Me.lblTurno4.TabIndex = 23
        Me.lblTurno4.Text = "T. vespertino"
        '
        'txtComentarios
        '
        Me.txtComentarios.AcceptsReturn = True
        Me.txtComentarios.Location = New System.Drawing.Point(28, 277)
        Me.txtComentarios.MaxLength = 2000
        Me.txtComentarios.Multiline = True
        Me.txtComentarios.Name = "txtComentarios"
        Me.txtComentarios.Size = New System.Drawing.Size(256, 129)
        Me.txtComentarios.TabIndex = 2
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
        Me.btnCancelarEdicion.TabIndex = 7
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
        'btnNuevoSalon
        '
        Me.btnNuevoSalon.AutoSize = True
        Me.btnNuevoSalon.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnNuevoSalon.Location = New System.Drawing.Point(378, 21)
        Me.btnNuevoSalon.Name = "btnNuevoSalon"
        Me.btnNuevoSalon.Size = New System.Drawing.Size(100, 29)
        Me.btnNuevoSalon.TabIndex = 8
        Me.btnNuevoSalon.Text = "Nuevo salón"
        Me.btnNuevoSalon.UseVisualStyleBackColor = True
        Me.btnNuevoSalon.Visible = False
        '
        'imgLogoMAITs
        '
        Me.imgLogoMAITs.BackgroundImage = Global.Minerva.My.Resources.Resources.logoMAITS
        Me.imgLogoMAITs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.imgLogoMAITs.Location = New System.Drawing.Point(512, 12)
        Me.imgLogoMAITs.Name = "imgLogoMAITs"
        Me.imgLogoMAITs.Size = New System.Drawing.Size(121, 62)
        Me.imgLogoMAITs.TabIndex = 124
        Me.imgLogoMAITs.TabStop = False
        '
        'lblSalonMatutino
        '
        Me.lblSalonMatutino.AutoSize = True
        Me.lblSalonMatutino.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblSalonMatutino.ForeColor = System.Drawing.Color.White
        Me.lblSalonMatutino.Location = New System.Drawing.Point(314, 169)
        Me.lblSalonMatutino.Name = "lblSalonMatutino"
        Me.lblSalonMatutino.Size = New System.Drawing.Size(125, 29)
        Me.lblSalonMatutino.TabIndex = 126
        Me.lblSalonMatutino.Text = "Sin asignar"
        '
        'lblSalonVespertino
        '
        Me.lblSalonVespertino.AutoSize = True
        Me.lblSalonVespertino.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblSalonVespertino.ForeColor = System.Drawing.Color.White
        Me.lblSalonVespertino.Location = New System.Drawing.Point(456, 169)
        Me.lblSalonVespertino.Name = "lblSalonVespertino"
        Me.lblSalonVespertino.Size = New System.Drawing.Size(125, 29)
        Me.lblSalonVespertino.TabIndex = 127
        Me.lblSalonVespertino.Text = "Sin asignar"
        '
        'lblSalonNocturno
        '
        Me.lblSalonNocturno.AutoSize = True
        Me.lblSalonNocturno.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblSalonNocturno.ForeColor = System.Drawing.Color.White
        Me.lblSalonNocturno.Location = New System.Drawing.Point(314, 252)
        Me.lblSalonNocturno.Name = "lblSalonNocturno"
        Me.lblSalonNocturno.Size = New System.Drawing.Size(125, 29)
        Me.lblSalonNocturno.TabIndex = 128
        Me.lblSalonNocturno.Text = "Sin asignar"
        '
        'frmAdminSalones
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Controls.Add(Me.lblSalonNocturno)
        Me.Controls.Add(Me.lblSalonVespertino)
        Me.Controls.Add(Me.lblSalonMatutino)
        Me.Controls.Add(Me.imgLogoMAITs)
        Me.Controls.Add(Me.lblSalonesAsignados)
        Me.Controls.Add(Me.btnNuevoSalon)
        Me.Controls.Add(Me.btnCancelarEdicion)
        Me.Controls.Add(Me.lblNuevoSalon)
        Me.Controls.Add(Me.lblComentarios)
        Me.Controls.Add(Me.txtComentarios)
        Me.Controls.Add(Me.lblTurno4)
        Me.Controls.Add(Me.lblTurno2)
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
        CType(Me.imgLogoMAITs, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblTurno2 As System.Windows.Forms.Label
    Friend WithEvents lblTurno4 As System.Windows.Forms.Label
    Friend WithEvents txtComentarios As System.Windows.Forms.TextBox
    Friend WithEvents lblComentarios As System.Windows.Forms.Label
    Friend WithEvents btnCancelarEdicion As System.Windows.Forms.Button
    Friend WithEvents pnlFondo As System.Windows.Forms.Panel
    Friend WithEvents pnlSalones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlSalonPlantilla As System.Windows.Forms.Panel
    Friend WithEvents btnEliminarPlantilla As System.Windows.Forms.Button
    Friend WithEvents btnEditarPlantilla As System.Windows.Forms.Button
    Friend WithEvents btnNuevoSalon As System.Windows.Forms.Button
    Friend WithEvents lblNuevoSalon As System.Windows.Forms.Label
    Friend WithEvents btnSalonPlantilla As System.Windows.Forms.Button
    Friend WithEvents imgLogoMAITs As System.Windows.Forms.PictureBox
    Friend WithEvents lblCantidadSalones As System.Windows.Forms.Label
    Friend WithEvents lblSalonMatutino As System.Windows.Forms.Label
    Friend WithEvents lblSalonVespertino As System.Windows.Forms.Label
    Friend WithEvents lblSalonNocturno As System.Windows.Forms.Label

End Class
