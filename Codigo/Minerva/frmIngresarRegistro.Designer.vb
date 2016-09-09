<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIngresarRegistro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIngresarRegistro))
        Me.lblMinerva = New System.Windows.Forms.Label()
        Me.btnRegistro = New System.Windows.Forms.Button()
        Me.btnIngresar = New System.Windows.Forms.Button()
        Me.btnInvitado = New System.Windows.Forms.Button()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.imgLogoMAITs = New System.Windows.Forms.PictureBox()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogoMAITs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblMinerva
        '
        Me.lblMinerva.AutoSize = True
        Me.lblMinerva.Font = New System.Drawing.Font("Corbel", 60.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMinerva.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblMinerva.Location = New System.Drawing.Point(23, 231)
        Me.lblMinerva.Name = "lblMinerva"
        Me.lblMinerva.Size = New System.Drawing.Size(321, 97)
        Me.lblMinerva.TabIndex = 2
        Me.lblMinerva.Text = "Minerva"
        '
        'btnRegistro
        '
        Me.btnRegistro.BackColor = System.Drawing.Color.Silver
        Me.btnRegistro.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegistro.Font = New System.Drawing.Font("Corbel", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegistro.Location = New System.Drawing.Point(72, 389)
        Me.btnRegistro.Name = "btnRegistro"
        Me.btnRegistro.Size = New System.Drawing.Size(222, 41)
        Me.btnRegistro.TabIndex = 4
        Me.btnRegistro.Text = "Registrarse"
        Me.btnRegistro.UseVisualStyleBackColor = False
        '
        'btnIngresar
        '
        Me.btnIngresar.BackColor = System.Drawing.Color.Silver
        Me.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIngresar.Font = New System.Drawing.Font("Corbel", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngresar.Location = New System.Drawing.Point(72, 328)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(222, 41)
        Me.btnIngresar.TabIndex = 4
        Me.btnIngresar.Text = "Ingresar"
        Me.btnIngresar.UseVisualStyleBackColor = False
        '
        'btnInvitado
        '
        Me.btnInvitado.BackColor = System.Drawing.Color.Silver
        Me.btnInvitado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnInvitado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInvitado.Font = New System.Drawing.Font("Corbel", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInvitado.Location = New System.Drawing.Point(72, 451)
        Me.btnInvitado.Name = "btnInvitado"
        Me.btnInvitado.Size = New System.Drawing.Size(222, 41)
        Me.btnInvitado.TabIndex = 4
        Me.btnInvitado.Text = "Entrar como Invitado"
        Me.btnInvitado.UseVisualStyleBackColor = False
        '
        'imgLogo
        '
        Me.imgLogo.BackgroundImage = Global.Minerva.My.Resources.Resources.logoMinerva
        Me.imgLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.imgLogo.Location = New System.Drawing.Point(2, 12)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(368, 216)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgLogo.TabIndex = 3
        Me.imgLogo.TabStop = False
        '
        'imgLogoMAITs
        '
        Me.imgLogoMAITs.BackgroundImage = Global.Minerva.My.Resources.Resources.logoMAITS
        Me.imgLogoMAITs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.imgLogoMAITs.Location = New System.Drawing.Point(282, 12)
        Me.imgLogoMAITs.Name = "imgLogoMAITs"
        Me.imgLogoMAITs.Size = New System.Drawing.Size(88, 59)
        Me.imgLogoMAITs.TabIndex = 126
        Me.imgLogoMAITs.TabStop = False
        '
        'frmIngresarRegistro
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(371, 514)
        Me.Controls.Add(Me.imgLogoMAITs)
        Me.Controls.Add(Me.btnIngresar)
        Me.Controls.Add(Me.btnInvitado)
        Me.Controls.Add(Me.btnRegistro)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.lblMinerva)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIngresarRegistro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Minerva"
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogoMAITs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMinerva As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents btnRegistro As System.Windows.Forms.Button
    Friend WithEvents btnIngresar As System.Windows.Forms.Button
    Friend WithEvents btnInvitado As System.Windows.Forms.Button
    Friend WithEvents imgLogoMAITs As System.Windows.Forms.PictureBox
End Class
