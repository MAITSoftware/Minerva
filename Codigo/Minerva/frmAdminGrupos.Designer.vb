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
        Me.cmbTurno = New System.Windows.Forms.ComboBox()
        Me.lblTurno = New System.Windows.Forms.Label()
        Me.txtIDGrupo = New System.Windows.Forms.TextBox()
        Me.lblCurso = New System.Windows.Forms.Label()
        Me.lblOrientacion = New System.Windows.Forms.Label()
        Me.lblTrayecto = New System.Windows.Forms.Label()
        Me.btnNuevoGrupo = New System.Windows.Forms.Button()
        Me.lblNuevoGrupo = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.pnlFondo = New System.Windows.Forms.Panel()
        Me.pnlGrupoPlantilla = New System.Windows.Forms.Panel()
        Me.btnEditarPlantilla = New System.Windows.Forms.Button()
        Me.btnEliminarPlantilla = New System.Windows.Forms.Button()
        Me.btnGrupoPlantilla = New System.Windows.Forms.Button()
        Me.lblCantidadGrupos = New System.Windows.Forms.Label()
        Me.pnlGrupos = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmbCurso = New System.Windows.Forms.ComboBox()
        Me.cmbOrientacion = New System.Windows.Forms.ComboBox()
        Me.chkDiscapacitado = New System.Windows.Forms.CheckBox()
        Me.lblSalon = New System.Windows.Forms.Label()
        Me.cmbGrado = New System.Windows.Forms.ComboBox()
        Me.lblIDGrupo = New System.Windows.Forms.Label()
        Me.lblAdscripto = New System.Windows.Forms.Label()
        Me.cmbAdscripto = New System.Windows.Forms.ComboBox()
        Me.imgLogoMAITs = New System.Windows.Forms.PictureBox()
        Me.cmbSalon = New System.Windows.Forms.ComboBox()
        Me.lblNoGrupoAsignado = New System.Windows.Forms.Label()
        Me.chkDistribuir = New System.Windows.Forms.CheckBox()
        lblTitulo = New System.Windows.Forms.Label()
        lblGrupos = New System.Windows.Forms.Label()
        Me.pnlFondo.SuspendLayout()
        Me.pnlGrupoPlantilla.SuspendLayout()
        CType(Me.imgLogoMAITs, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'cmbTurno
        '
        Me.cmbTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTurno.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.cmbTurno.FormattingEnabled = True
        Me.cmbTurno.Location = New System.Drawing.Point(476, 161)
        Me.cmbTurno.Name = "cmbTurno"
        Me.cmbTurno.Size = New System.Drawing.Size(116, 34)
        Me.cmbTurno.TabIndex = 3
        '
        'lblTurno
        '
        Me.lblTurno.AutoSize = True
        Me.lblTurno.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTurno.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblTurno.Location = New System.Drawing.Point(471, 129)
        Me.lblTurno.Name = "lblTurno"
        Me.lblTurno.Size = New System.Drawing.Size(72, 29)
        Me.lblTurno.TabIndex = 76
        Me.lblTurno.Text = "Turno"
        '
        'txtIDGrupo
        '
        Me.txtIDGrupo.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.txtIDGrupo.Location = New System.Drawing.Point(184, 253)
        Me.txtIDGrupo.MaxLength = 4
        Me.txtIDGrupo.Name = "txtIDGrupo"
        Me.txtIDGrupo.Size = New System.Drawing.Size(121, 34)
        Me.txtIDGrupo.TabIndex = 4
        Me.txtIDGrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCurso
        '
        Me.lblCurso.AutoSize = True
        Me.lblCurso.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblCurso.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblCurso.Location = New System.Drawing.Point(22, 129)
        Me.lblCurso.Name = "lblCurso"
        Me.lblCurso.Size = New System.Drawing.Size(71, 29)
        Me.lblCurso.TabIndex = 81
        Me.lblCurso.Text = "Curso"
        '
        'lblOrientacion
        '
        Me.lblOrientacion.AutoSize = True
        Me.lblOrientacion.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblOrientacion.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblOrientacion.Location = New System.Drawing.Point(179, 129)
        Me.lblOrientacion.Name = "lblOrientacion"
        Me.lblOrientacion.Size = New System.Drawing.Size(134, 29)
        Me.lblOrientacion.TabIndex = 83
        Me.lblOrientacion.Text = "Orientación"
        '
        'lblTrayecto
        '
        Me.lblTrayecto.AutoSize = True
        Me.lblTrayecto.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTrayecto.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblTrayecto.Location = New System.Drawing.Point(22, 221)
        Me.lblTrayecto.Name = "lblTrayecto"
        Me.lblTrayecto.Size = New System.Drawing.Size(75, 29)
        Me.lblTrayecto.TabIndex = 86
        Me.lblTrayecto.Text = "Grado"
        '
        'btnNuevoGrupo
        '
        Me.btnNuevoGrupo.AutoSize = True
        Me.btnNuevoGrupo.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnNuevoGrupo.Location = New System.Drawing.Point(338, 22)
        Me.btnNuevoGrupo.Name = "btnNuevoGrupo"
        Me.btnNuevoGrupo.Size = New System.Drawing.Size(170, 29)
        Me.btnNuevoGrupo.TabIndex = 7
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
        'btnAgregar
        '
        Me.btnAgregar.AutoSize = True
        Me.btnAgregar.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnAgregar.Location = New System.Drawing.Point(461, 410)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(154, 29)
        Me.btnAgregar.TabIndex = 6
        Me.btnAgregar.Text = "Agregar grupo"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'pnlFondo
        '
        Me.pnlFondo.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.pnlFondo.Controls.Add(Me.pnlGrupoPlantilla)
        Me.pnlFondo.Controls.Add(Me.lblCantidadGrupos)
        Me.pnlFondo.Controls.Add(Me.pnlGrupos)
        Me.pnlFondo.Controls.Add(lblGrupos)
        Me.pnlFondo.Location = New System.Drawing.Point(639, 0)
        Me.pnlFondo.Name = "pnlFondo"
        Me.pnlFondo.Size = New System.Drawing.Size(365, 501)
        Me.pnlFondo.TabIndex = 100
        '
        'pnlGrupoPlantilla
        '
        Me.pnlGrupoPlantilla.Controls.Add(Me.btnEditarPlantilla)
        Me.pnlGrupoPlantilla.Controls.Add(Me.btnEliminarPlantilla)
        Me.pnlGrupoPlantilla.Controls.Add(Me.btnGrupoPlantilla)
        Me.pnlGrupoPlantilla.Location = New System.Drawing.Point(0, 0)
        Me.pnlGrupoPlantilla.Name = "pnlGrupoPlantilla"
        Me.pnlGrupoPlantilla.Size = New System.Drawing.Size(305, 56)
        Me.pnlGrupoPlantilla.TabIndex = 0
        Me.pnlGrupoPlantilla.Visible = False
        '
        'btnEditarPlantilla
        '
        Me.btnEditarPlantilla.BackColor = System.Drawing.Color.SteelBlue
        Me.btnEditarPlantilla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditarPlantilla.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnEditarPlantilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditarPlantilla.Font = New System.Drawing.Font("Corbel", 10.0!)
        Me.btnEditarPlantilla.ForeColor = System.Drawing.Color.White
        Me.btnEditarPlantilla.Location = New System.Drawing.Point(210, 3)
        Me.btnEditarPlantilla.Name = "btnEditarPlantilla"
        Me.btnEditarPlantilla.Size = New System.Drawing.Size(89, 23)
        Me.btnEditarPlantilla.TabIndex = 3
        Me.btnEditarPlantilla.Text = "Editar"
        Me.btnEditarPlantilla.UseVisualStyleBackColor = False
        '
        'btnEliminarPlantilla
        '
        Me.btnEliminarPlantilla.BackColor = System.Drawing.Color.Firebrick
        Me.btnEliminarPlantilla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminarPlantilla.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnEliminarPlantilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminarPlantilla.Font = New System.Drawing.Font("Corbel", 10.0!)
        Me.btnEliminarPlantilla.ForeColor = System.Drawing.Color.White
        Me.btnEliminarPlantilla.Location = New System.Drawing.Point(210, 28)
        Me.btnEliminarPlantilla.Name = "btnEliminarPlantilla"
        Me.btnEliminarPlantilla.Size = New System.Drawing.Size(89, 23)
        Me.btnEliminarPlantilla.TabIndex = 2
        Me.btnEliminarPlantilla.Text = "Eliminar"
        Me.btnEliminarPlantilla.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminarPlantilla.UseVisualStyleBackColor = False
        '
        'btnGrupoPlantilla
        '
        Me.btnGrupoPlantilla.BackColor = System.Drawing.SystemColors.GrayText
        Me.btnGrupoPlantilla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGrupoPlantilla.FlatAppearance.BorderColor = System.Drawing.Color.Tomato
        Me.btnGrupoPlantilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrupoPlantilla.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnGrupoPlantilla.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnGrupoPlantilla.Location = New System.Drawing.Point(0, 3)
        Me.btnGrupoPlantilla.Margin = New System.Windows.Forms.Padding(0)
        Me.btnGrupoPlantilla.Name = "btnGrupoPlantilla"
        Me.btnGrupoPlantilla.Size = New System.Drawing.Size(207, 48)
        Me.btnGrupoPlantilla.TabIndex = 0
        Me.btnGrupoPlantilla.Text = "Template salón" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(vespertino)"
        Me.btnGrupoPlantilla.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGrupoPlantilla.UseVisualStyleBackColor = False
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
        'cmbCurso
        '
        Me.cmbCurso.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCurso.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.cmbCurso.FormattingEnabled = True
        Me.cmbCurso.Location = New System.Drawing.Point(27, 161)
        Me.cmbCurso.Name = "cmbCurso"
        Me.cmbCurso.Size = New System.Drawing.Size(140, 34)
        Me.cmbCurso.TabIndex = 0
        '
        'cmbOrientacion
        '
        Me.cmbOrientacion.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbOrientacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrientacion.Enabled = False
        Me.cmbOrientacion.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.cmbOrientacion.FormattingEnabled = True
        Me.cmbOrientacion.Location = New System.Drawing.Point(184, 161)
        Me.cmbOrientacion.Name = "cmbOrientacion"
        Me.cmbOrientacion.Size = New System.Drawing.Size(271, 34)
        Me.cmbOrientacion.TabIndex = 1
        '
        'chkDiscapacitado
        '
        Me.chkDiscapacitado.AutoSize = True
        Me.chkDiscapacitado.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.chkDiscapacitado.ForeColor = System.Drawing.Color.PaleGreen
        Me.chkDiscapacitado.Location = New System.Drawing.Point(27, 322)
        Me.chkDiscapacitado.Name = "chkDiscapacitado"
        Me.chkDiscapacitado.Size = New System.Drawing.Size(256, 33)
        Me.chkDiscapacitado.TabIndex = 5
        Me.chkDiscapacitado.Text = "Alumno discapacitado"
        Me.chkDiscapacitado.UseVisualStyleBackColor = True
        '
        'lblSalon
        '
        Me.lblSalon.AutoSize = True
        Me.lblSalon.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblSalon.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblSalon.Location = New System.Drawing.Point(20, 370)
        Me.lblSalon.Name = "lblSalon"
        Me.lblSalon.Size = New System.Drawing.Size(71, 29)
        Me.lblSalon.TabIndex = 124
        Me.lblSalon.Text = "Salón"
        '
        'cmbGrado
        '
        Me.cmbGrado.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrado.Enabled = False
        Me.cmbGrado.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.cmbGrado.FormattingEnabled = True
        Me.cmbGrado.Location = New System.Drawing.Point(27, 253)
        Me.cmbGrado.Name = "cmbGrado"
        Me.cmbGrado.Size = New System.Drawing.Size(140, 34)
        Me.cmbGrado.TabIndex = 2
        '
        'lblIDGrupo
        '
        Me.lblIDGrupo.AutoSize = True
        Me.lblIDGrupo.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblIDGrupo.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblIDGrupo.Location = New System.Drawing.Point(179, 221)
        Me.lblIDGrupo.Name = "lblIDGrupo"
        Me.lblIDGrupo.Size = New System.Drawing.Size(104, 29)
        Me.lblIDGrupo.TabIndex = 67
        Me.lblIDGrupo.Text = "ID Grupo"
        '
        'lblAdscripto
        '
        Me.lblAdscripto.AutoSize = True
        Me.lblAdscripto.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblAdscripto.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblAdscripto.Location = New System.Drawing.Point(348, 221)
        Me.lblAdscripto.Name = "lblAdscripto"
        Me.lblAdscripto.Size = New System.Drawing.Size(143, 29)
        Me.lblAdscripto.TabIndex = 126
        Me.lblAdscripto.Text = "Adscripto (a)"
        '
        'cmbAdscripto
        '
        Me.cmbAdscripto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAdscripto.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.cmbAdscripto.FormattingEnabled = True
        Me.cmbAdscripto.Location = New System.Drawing.Point(353, 253)
        Me.cmbAdscripto.Name = "cmbAdscripto"
        Me.cmbAdscripto.Size = New System.Drawing.Size(239, 34)
        Me.cmbAdscripto.TabIndex = 127
        '
        'imgLogoMAITs
        '
        Me.imgLogoMAITs.BackgroundImage = Global.Minerva.My.Resources.Resources.logoMAITS
        Me.imgLogoMAITs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.imgLogoMAITs.Location = New System.Drawing.Point(512, 12)
        Me.imgLogoMAITs.Name = "imgLogoMAITs"
        Me.imgLogoMAITs.Size = New System.Drawing.Size(121, 62)
        Me.imgLogoMAITs.TabIndex = 123
        Me.imgLogoMAITs.TabStop = False
        '
        'cmbSalon
        '
        Me.cmbSalon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSalon.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.cmbSalon.FormattingEnabled = True
        Me.cmbSalon.Items.AddRange(New Object() {"Sin asignar"})
        Me.cmbSalon.Location = New System.Drawing.Point(25, 410)
        Me.cmbSalon.Name = "cmbSalon"
        Me.cmbSalon.Size = New System.Drawing.Size(121, 34)
        Me.cmbSalon.TabIndex = 128
        '
        'lblNoGrupoAsignado
        '
        Me.lblNoGrupoAsignado.Font = New System.Drawing.Font("Corbel", 36.0!, System.Drawing.FontStyle.Bold)
        Me.lblNoGrupoAsignado.ForeColor = System.Drawing.Color.White
        Me.lblNoGrupoAsignado.Location = New System.Drawing.Point(0, 0)
        Me.lblNoGrupoAsignado.Name = "lblNoGrupoAsignado"
        Me.lblNoGrupoAsignado.Size = New System.Drawing.Size(1004, 493)
        Me.lblNoGrupoAsignado.TabIndex = 131
        Me.lblNoGrupoAsignado.Text = "Usted no tiene ningún grupo asignado"
        Me.lblNoGrupoAsignado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNoGrupoAsignado.Visible = False
        '
        'chkDistribuir
        '
        Me.chkDistribuir.Checked = True
        Me.chkDistribuir.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDistribuir.Font = New System.Drawing.Font("Corbel", 9.0!)
        Me.chkDistribuir.ForeColor = System.Drawing.Color.White
        Me.chkDistribuir.Location = New System.Drawing.Point(461, 370)
        Me.chkDistribuir.Name = "chkDistribuir"
        Me.chkDistribuir.Size = New System.Drawing.Size(154, 41)
        Me.chkDistribuir.TabIndex = 132
        Me.chkDistribuir.Text = "Distribución inicial de asignaturas"
        Me.chkDistribuir.UseVisualStyleBackColor = True
        '
        'frmAdminGrupos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Controls.Add(Me.lblNoGrupoAsignado)
        Me.Controls.Add(lblTitulo)
        Me.Controls.Add(Me.chkDistribuir)
        Me.Controls.Add(Me.cmbSalon)
        Me.Controls.Add(Me.cmbAdscripto)
        Me.Controls.Add(Me.lblAdscripto)
        Me.Controls.Add(Me.cmbGrado)
        Me.Controls.Add(Me.lblSalon)
        Me.Controls.Add(Me.imgLogoMAITs)
        Me.Controls.Add(Me.chkDiscapacitado)
        Me.Controls.Add(Me.cmbOrientacion)
        Me.Controls.Add(Me.cmbCurso)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnNuevoGrupo)
        Me.Controls.Add(Me.lblNuevoGrupo)
        Me.Controls.Add(Me.lblTrayecto)
        Me.Controls.Add(Me.lblOrientacion)
        Me.Controls.Add(Me.lblCurso)
        Me.Controls.Add(Me.txtIDGrupo)
        Me.Controls.Add(Me.cmbTurno)
        Me.Controls.Add(Me.lblTurno)
        Me.Controls.Add(Me.lblIDGrupo)
        Me.Controls.Add(Me.pnlFondo)
        Me.Name = "frmAdminGrupos"
        Me.Size = New System.Drawing.Size(1004, 493)
        Me.pnlFondo.ResumeLayout(False)
        Me.pnlFondo.PerformLayout()
        Me.pnlGrupoPlantilla.ResumeLayout(False)
        CType(Me.imgLogoMAITs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbTurno As System.Windows.Forms.ComboBox
    Friend WithEvents lblTurno As System.Windows.Forms.Label
    Friend WithEvents txtIDGrupo As System.Windows.Forms.TextBox
    Friend WithEvents lblCurso As System.Windows.Forms.Label
    Friend WithEvents lblOrientacion As System.Windows.Forms.Label
    Friend WithEvents lblTrayecto As System.Windows.Forms.Label
    Friend WithEvents btnNuevoGrupo As System.Windows.Forms.Button
    Friend WithEvents lblNuevoGrupo As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents pnlFondo As System.Windows.Forms.Panel
    Friend WithEvents lblCantidadGrupos As System.Windows.Forms.Label
    Friend WithEvents pnlGrupoPlantilla As System.Windows.Forms.Panel
    Friend WithEvents btnGrupoPlantilla As System.Windows.Forms.Button
    Friend WithEvents btnEliminarPlantilla As System.Windows.Forms.Button
    Friend WithEvents pnlGrupos As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cmbCurso As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOrientacion As System.Windows.Forms.ComboBox
    Friend WithEvents chkDiscapacitado As System.Windows.Forms.CheckBox
    Friend WithEvents imgLogoMAITs As System.Windows.Forms.PictureBox
    Friend WithEvents lblSalon As System.Windows.Forms.Label
    Friend WithEvents cmbGrado As System.Windows.Forms.ComboBox
    Friend WithEvents btnEditarPlantilla As System.Windows.Forms.Button
    Friend WithEvents lblIDGrupo As System.Windows.Forms.Label
    Friend WithEvents lblAdscripto As System.Windows.Forms.Label
    Friend WithEvents cmbAdscripto As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSalon As System.Windows.Forms.ComboBox
    Friend WithEvents lblNoGrupoAsignado As System.Windows.Forms.Label
    Friend WithEvents chkDistribuir As System.Windows.Forms.CheckBox

End Class
