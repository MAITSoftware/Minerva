<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistro
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegistro))
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.pnlError = New System.Windows.Forms.Panel()
        Me.imgWarning = New System.Windows.Forms.PictureBox()
        Me.lblDatosInc = New System.Windows.Forms.Label()
        Me.btnEntrar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.timerAnimacion = New System.Windows.Forms.Timer(Me.components)
        Me.lblIngreseContraseña = New System.Windows.Forms.Label()
        Me.lblIngreseUsuario = New System.Windows.Forms.Label()
        Me.txtContraseña = New System.Windows.Forms.TextBox()
        Me.lblContraseña = New System.Windows.Forms.Label()
        Me.txtCi = New System.Windows.Forms.TextBox()
        Me.imgMinerva = New System.Windows.Forms.PictureBox()
        Me.lblNombrePrograma = New System.Windows.Forms.Label()
        Me.imgLogoMAITs = New System.Windows.Forms.PictureBox()
        Me.radAdscripto = New System.Windows.Forms.RadioButton()
        Me.radFuncionario = New System.Windows.Forms.RadioButton()
        Me.radAdministrador = New System.Windows.Forms.RadioButton()
        Me.pnlTipoUsuario = New System.Windows.Forms.Panel()
        Me.pnlError.SuspendLayout()
        CType(Me.imgWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgMinerva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogoMAITs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTipoUsuario.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Corbel", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblUsuario.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblUsuario.Location = New System.Drawing.Point(46, 195)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(184, 33)
        Me.lblUsuario.TabIndex = 22
        Me.lblUsuario.Text = "Nuevo usuario"
        '
        'pnlError
        '
        Me.pnlError.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.pnlError.Controls.Add(Me.imgWarning)
        Me.pnlError.Controls.Add(Me.lblDatosInc)
        Me.pnlError.Location = New System.Drawing.Point(0, 349)
        Me.pnlError.Name = "pnlError"
        Me.pnlError.Size = New System.Drawing.Size(368, 30)
        Me.pnlError.TabIndex = 21
        Me.pnlError.Visible = False
        '
        'imgWarning
        '
        Me.imgWarning.BackgroundImage = Global.Minerva.My.Resources.Resources.warningBlanco
        Me.imgWarning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.imgWarning.Location = New System.Drawing.Point(30, 1)
        Me.imgWarning.Name = "imgWarning"
        Me.imgWarning.Size = New System.Drawing.Size(28, 28)
        Me.imgWarning.TabIndex = 8
        Me.imgWarning.TabStop = False
        '
        'lblDatosInc
        '
        Me.lblDatosInc.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatosInc.ForeColor = System.Drawing.Color.White
        Me.lblDatosInc.Location = New System.Drawing.Point(0, 0)
        Me.lblDatosInc.Name = "lblDatosInc"
        Me.lblDatosInc.Size = New System.Drawing.Size(365, 30)
        Me.lblDatosInc.TabIndex = 7
        Me.lblDatosInc.Text = "El usuario ya existe!"
        Me.lblDatosInc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnEntrar
        '
        Me.btnEntrar.BackColor = System.Drawing.Color.Silver
        Me.btnEntrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEntrar.Enabled = False
        Me.btnEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEntrar.Font = New System.Drawing.Font("Corbel", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEntrar.Location = New System.Drawing.Point(74, 394)
        Me.btnEntrar.Name = "btnEntrar"
        Me.btnEntrar.Size = New System.Drawing.Size(222, 41)
        Me.btnEntrar.TabIndex = 2
        Me.btnEntrar.Text = "Confirmar"
        Me.btnEntrar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Silver
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Corbel", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(74, 455)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(222, 41)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'timerAnimacion
        '
        Me.timerAnimacion.Interval = 500
        '
        'lblIngreseContraseña
        '
        Me.lblIngreseContraseña.BackColor = System.Drawing.Color.White
        Me.lblIngreseContraseña.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lblIngreseContraseña.Font = New System.Drawing.Font("Corbel", 15.0!)
        Me.lblIngreseContraseña.ForeColor = System.Drawing.Color.DimGray
        Me.lblIngreseContraseña.Location = New System.Drawing.Point(64, 303)
        Me.lblIngreseContraseña.Name = "lblIngreseContraseña"
        Me.lblIngreseContraseña.Size = New System.Drawing.Size(256, 30)
        Me.lblIngreseContraseña.TabIndex = 27
        Me.lblIngreseContraseña.Text = "Ingrese su contraseña"
        Me.lblIngreseContraseña.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIngreseUsuario
        '
        Me.lblIngreseUsuario.BackColor = System.Drawing.Color.White
        Me.lblIngreseUsuario.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lblIngreseUsuario.Font = New System.Drawing.Font("Corbel", 15.0!)
        Me.lblIngreseUsuario.ForeColor = System.Drawing.Color.DimGray
        Me.lblIngreseUsuario.Location = New System.Drawing.Point(63, 232)
        Me.lblIngreseUsuario.Name = "lblIngreseUsuario"
        Me.lblIngreseUsuario.Size = New System.Drawing.Size(256, 30)
        Me.lblIngreseUsuario.TabIndex = 26
        Me.lblIngreseUsuario.Text = "Ingrese su CI"
        Me.lblIngreseUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtContraseña
        '
        Me.txtContraseña.Font = New System.Drawing.Font("Corbel", 15.0!)
        Me.txtContraseña.Location = New System.Drawing.Point(52, 302)
        Me.txtContraseña.MaxLength = 25
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.ShortcutsEnabled = False
        Me.txtContraseña.Size = New System.Drawing.Size(267, 32)
        Me.txtContraseña.TabIndex = 1
        Me.txtContraseña.UseSystemPasswordChar = True
        '
        'lblContraseña
        '
        Me.lblContraseña.AutoSize = True
        Me.lblContraseña.Font = New System.Drawing.Font("Corbel", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblContraseña.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblContraseña.Location = New System.Drawing.Point(46, 266)
        Me.lblContraseña.Name = "lblContraseña"
        Me.lblContraseña.Size = New System.Drawing.Size(148, 33)
        Me.lblContraseña.TabIndex = 24
        Me.lblContraseña.Text = "Contraseña"
        '
        'txtCi
        '
        Me.txtCi.Font = New System.Drawing.Font("Corbel", 15.0!)
        Me.txtCi.Location = New System.Drawing.Point(52, 231)
        Me.txtCi.MaxLength = 8
        Me.txtCi.Name = "txtCi"
        Me.txtCi.ShortcutsEnabled = False
        Me.txtCi.Size = New System.Drawing.Size(267, 32)
        Me.txtCi.TabIndex = 0
        '
        'imgMinerva
        '
        Me.imgMinerva.BackgroundImage = Global.Minerva.My.Resources.Resources.logoMinerva
        Me.imgMinerva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.imgMinerva.Location = New System.Drawing.Point(1, 12)
        Me.imgMinerva.Name = "imgMinerva"
        Me.imgMinerva.Size = New System.Drawing.Size(368, 120)
        Me.imgMinerva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgMinerva.TabIndex = 18
        Me.imgMinerva.TabStop = False
        '
        'lblNombrePrograma
        '
        Me.lblNombrePrograma.Font = New System.Drawing.Font("Corbel", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblNombrePrograma.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblNombrePrograma.Location = New System.Drawing.Point(1, 120)
        Me.lblNombrePrograma.Name = "lblNombrePrograma"
        Me.lblNombrePrograma.Size = New System.Drawing.Size(369, 62)
        Me.lblNombrePrograma.TabIndex = 28
        Me.lblNombrePrograma.Text = "Registro en Minerva"
        Me.lblNombrePrograma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'imgLogoMAITs
        '
        Me.imgLogoMAITs.BackgroundImage = Global.Minerva.My.Resources.Resources.logoMAITS
        Me.imgLogoMAITs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.imgLogoMAITs.Location = New System.Drawing.Point(282, 12)
        Me.imgLogoMAITs.Name = "imgLogoMAITs"
        Me.imgLogoMAITs.Size = New System.Drawing.Size(88, 59)
        Me.imgLogoMAITs.TabIndex = 127
        Me.imgLogoMAITs.TabStop = False
        '
        'radAdscripto
        '
        Me.radAdscripto.AutoSize = True
        Me.radAdscripto.Font = New System.Drawing.Font("Corbel", 10.0!, System.Drawing.FontStyle.Bold)
        Me.radAdscripto.ForeColor = System.Drawing.Color.PaleGreen
        Me.radAdscripto.Location = New System.Drawing.Point(0, 0)
        Me.radAdscripto.Name = "radAdscripto"
        Me.radAdscripto.Size = New System.Drawing.Size(84, 21)
        Me.radAdscripto.TabIndex = 128
        Me.radAdscripto.Text = "Adscripto"
        Me.radAdscripto.UseVisualStyleBackColor = True
        '
        'radFuncionario
        '
        Me.radFuncionario.AutoSize = True
        Me.radFuncionario.Checked = True
        Me.radFuncionario.Font = New System.Drawing.Font("Corbel", 10.0!, System.Drawing.FontStyle.Bold)
        Me.radFuncionario.ForeColor = System.Drawing.Color.PaleGreen
        Me.radFuncionario.Location = New System.Drawing.Point(87, 0)
        Me.radFuncionario.Name = "radFuncionario"
        Me.radFuncionario.Size = New System.Drawing.Size(97, 21)
        Me.radFuncionario.TabIndex = 129
        Me.radFuncionario.TabStop = True
        Me.radFuncionario.Text = "Funcionario"
        Me.radFuncionario.UseVisualStyleBackColor = True
        '
        'radAdministrador
        '
        Me.radAdministrador.AutoSize = True
        Me.radAdministrador.Font = New System.Drawing.Font("Corbel", 10.0!, System.Drawing.FontStyle.Bold)
        Me.radAdministrador.ForeColor = System.Drawing.Color.PaleGreen
        Me.radAdministrador.Location = New System.Drawing.Point(190, 0)
        Me.radAdministrador.Name = "radAdministrador"
        Me.radAdministrador.Size = New System.Drawing.Size(113, 21)
        Me.radAdministrador.TabIndex = 130
        Me.radAdministrador.Text = "Administrador"
        Me.radAdministrador.UseVisualStyleBackColor = True
        '
        'pnlTipoUsuario
        '
        Me.pnlTipoUsuario.Controls.Add(Me.radAdministrador)
        Me.pnlTipoUsuario.Controls.Add(Me.radFuncionario)
        Me.pnlTipoUsuario.Controls.Add(Me.radAdscripto)
        Me.pnlTipoUsuario.Location = New System.Drawing.Point(32, 175)
        Me.pnlTipoUsuario.Name = "pnlTipoUsuario"
        Me.pnlTipoUsuario.Size = New System.Drawing.Size(306, 23)
        Me.pnlTipoUsuario.TabIndex = 131
        '
        'frmRegistro
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(371, 514)
        Me.Controls.Add(Me.pnlTipoUsuario)
        Me.Controls.Add(Me.imgLogoMAITs)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.pnlError)
        Me.Controls.Add(Me.btnEntrar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.lblIngreseContraseña)
        Me.Controls.Add(Me.lblIngreseUsuario)
        Me.Controls.Add(Me.txtContraseña)
        Me.Controls.Add(Me.lblContraseña)
        Me.Controls.Add(Me.txtCi)
        Me.Controls.Add(Me.imgMinerva)
        Me.Controls.Add(Me.lblNombrePrograma)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRegistro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Minerva · Registro"
        Me.pnlError.ResumeLayout(False)
        CType(Me.imgWarning, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgMinerva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogoMAITs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTipoUsuario.ResumeLayout(False)
        Me.pnlTipoUsuario.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents pnlError As System.Windows.Forms.Panel
    Friend WithEvents imgWarning As System.Windows.Forms.PictureBox
    Friend WithEvents lblDatosInc As System.Windows.Forms.Label
    Friend WithEvents btnEntrar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents timerAnimacion As System.Windows.Forms.Timer
    Friend WithEvents lblIngreseContraseña As System.Windows.Forms.Label
    Friend WithEvents lblIngreseUsuario As System.Windows.Forms.Label
    Friend WithEvents txtContraseña As System.Windows.Forms.TextBox
    Friend WithEvents lblContraseña As System.Windows.Forms.Label
    Friend WithEvents txtCi As System.Windows.Forms.TextBox
    Friend WithEvents imgMinerva As System.Windows.Forms.PictureBox
    Friend WithEvents lblNombrePrograma As System.Windows.Forms.Label
    Friend WithEvents imgLogoMAITs As System.Windows.Forms.PictureBox
    Friend WithEvents radAdscripto As System.Windows.Forms.RadioButton
    Friend WithEvents radFuncionario As System.Windows.Forms.RadioButton
    Friend WithEvents radAdministrador As System.Windows.Forms.RadioButton
    Friend WithEvents pnlTipoUsuario As System.Windows.Forms.Panel
End Class
