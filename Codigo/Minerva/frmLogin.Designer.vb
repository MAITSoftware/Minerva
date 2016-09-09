<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.btnEntrar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblNombrePrograma = New System.Windows.Forms.Label()
        Me.pnlError = New System.Windows.Forms.Panel()
        Me.imgWarning = New System.Windows.Forms.PictureBox()
        Me.lblDatosInc = New System.Windows.Forms.Label()
        Me.timerAnimacion = New System.Windows.Forms.Timer(Me.components)
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtContraseña = New System.Windows.Forms.TextBox()
        Me.lblContraseña = New System.Windows.Forms.Label()
        Me.lblIngreseUsuario = New System.Windows.Forms.Label()
        Me.lblIngreseContraseña = New System.Windows.Forms.Label()
        Me.imgMinerva = New System.Windows.Forms.PictureBox()
        Me.pnlError.SuspendLayout()
        CType(Me.imgWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgMinerva, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.btnEntrar.TabIndex = 7
        Me.btnEntrar.Text = "Ingresar"
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
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'lblNombrePrograma
        '
        Me.lblNombrePrograma.Font = New System.Drawing.Font("Corbel", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblNombrePrograma.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblNombrePrograma.Location = New System.Drawing.Point(0, 116)
        Me.lblNombrePrograma.Name = "lblNombrePrograma"
        Me.lblNombrePrograma.Size = New System.Drawing.Size(369, 66)
        Me.lblNombrePrograma.TabIndex = 5
        Me.lblNombrePrograma.Text = "Ingresar a Minerva"
        Me.lblNombrePrograma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlError
        '
        Me.pnlError.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.pnlError.Controls.Add(Me.imgWarning)
        Me.pnlError.Controls.Add(Me.lblDatosInc)
        Me.pnlError.Location = New System.Drawing.Point(0, 349)
        Me.pnlError.Name = "pnlError"
        Me.pnlError.Size = New System.Drawing.Size(368, 30)
        Me.pnlError.TabIndex = 10
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
        Me.lblDatosInc.Text = "Datos incorrectos!"
        Me.lblDatosInc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'timerAnimacion
        '
        Me.timerAnimacion.Interval = 500
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Corbel", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblUsuario.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblUsuario.Location = New System.Drawing.Point(46, 195)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(105, 33)
        Me.lblUsuario.TabIndex = 11
        Me.lblUsuario.Text = "Usuario"
        '
        'txtUsuario
        '
        Me.txtUsuario.Font = New System.Drawing.Font("Corbel", 15.0!)
        Me.txtUsuario.Location = New System.Drawing.Point(52, 231)
        Me.txtUsuario.MaxLength = 8
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(267, 32)
        Me.txtUsuario.TabIndex = 12
        '
        'txtContraseña
        '
        Me.txtContraseña.Font = New System.Drawing.Font("Corbel", 15.0!)
        Me.txtContraseña.Location = New System.Drawing.Point(52, 302)
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.Size = New System.Drawing.Size(267, 32)
        Me.txtContraseña.TabIndex = 14
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
        Me.lblContraseña.TabIndex = 13
        Me.lblContraseña.Text = "Contraseña"
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
        Me.lblIngreseUsuario.TabIndex = 15
        Me.lblIngreseUsuario.Text = "Ingrese su usuario"
        Me.lblIngreseUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.lblIngreseContraseña.TabIndex = 16
        Me.lblIngreseContraseña.Text = "Ingrese su contraseña"
        Me.lblIngreseContraseña.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'imgMinerva
        '
        Me.imgMinerva.BackgroundImage = Global.Minerva.My.Resources.Resources.logoMinerva
        Me.imgMinerva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.imgMinerva.Location = New System.Drawing.Point(1, 12)
        Me.imgMinerva.Name = "imgMinerva"
        Me.imgMinerva.Size = New System.Drawing.Size(368, 120)
        Me.imgMinerva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgMinerva.TabIndex = 6
        Me.imgMinerva.TabStop = False
        '
        'frmLogin
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(371, 514)
        Me.Controls.Add(Me.lblIngreseContraseña)
        Me.Controls.Add(Me.lblIngreseUsuario)
        Me.Controls.Add(Me.txtContraseña)
        Me.Controls.Add(Me.lblContraseña)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.pnlError)
        Me.Controls.Add(Me.btnEntrar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.imgMinerva)
        Me.Controls.Add(Me.lblNombrePrograma)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Minerva · Ingresar"
        Me.pnlError.ResumeLayout(False)
        CType(Me.imgWarning, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgMinerva, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnEntrar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents imgMinerva As System.Windows.Forms.PictureBox
    Friend WithEvents lblNombrePrograma As System.Windows.Forms.Label
    Friend WithEvents pnlError As System.Windows.Forms.Panel
    Friend WithEvents imgWarning As System.Windows.Forms.PictureBox
    Friend WithEvents lblDatosInc As System.Windows.Forms.Label
    Friend WithEvents timerAnimacion As System.Windows.Forms.Timer
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtContraseña As System.Windows.Forms.TextBox
    Friend WithEvents lblContraseña As System.Windows.Forms.Label
    Friend WithEvents lblIngreseUsuario As System.Windows.Forms.Label
    Friend WithEvents lblIngreseContraseña As System.Windows.Forms.Label
End Class
