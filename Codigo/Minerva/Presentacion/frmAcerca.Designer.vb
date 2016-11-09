<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAcerca
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAcerca))
        Me.logoMinerva = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblCorazon = New System.Windows.Forms.Label()
        Me.lblLogoEmpresa = New System.Windows.Forms.PictureBox()
        Me.btnVolver = New System.Windows.Forms.Button()
        CType(Me.logoMinerva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblLogoEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'logoMinerva
        '
        Me.logoMinerva.BackgroundImage = Global.Minerva.My.Resources.Resources.logoMinerva
        Me.logoMinerva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.logoMinerva.Location = New System.Drawing.Point(115, 12)
        Me.logoMinerva.Name = "logoMinerva"
        Me.logoMinerva.Size = New System.Drawing.Size(147, 134)
        Me.logoMinerva.TabIndex = 0
        Me.logoMinerva.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(13, 151)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(351, 87)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Minerva" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sistema de gestión de bedelía" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Hecho con      por MAITS Software"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCorazon
        '
        Me.lblCorazon.BackColor = System.Drawing.Color.Transparent
        Me.lblCorazon.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorazon.ForeColor = System.Drawing.Color.Red
        Me.lblCorazon.Location = New System.Drawing.Point(124, 208)
        Me.lblCorazon.Name = "lblCorazon"
        Me.lblCorazon.Size = New System.Drawing.Size(29, 30)
        Me.lblCorazon.TabIndex = 3
        Me.lblCorazon.Text = "♥"
        '
        'lblLogoEmpresa
        '
        Me.lblLogoEmpresa.BackgroundImage = Global.Minerva.My.Resources.Resources.logoMAITS
        Me.lblLogoEmpresa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.lblLogoEmpresa.Location = New System.Drawing.Point(115, 241)
        Me.lblLogoEmpresa.Name = "lblLogoEmpresa"
        Me.lblLogoEmpresa.Size = New System.Drawing.Size(147, 105)
        Me.lblLogoEmpresa.TabIndex = 4
        Me.lblLogoEmpresa.TabStop = False
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(314, 323)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(50, 23)
        Me.btnVolver.TabIndex = 5
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'frmAcerca
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(376, 364)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.lblLogoEmpresa)
        Me.Controls.Add(Me.lblCorazon)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.logoMinerva)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAcerca"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Acerca de Minerva"
        CType(Me.logoMinerva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblLogoEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents logoMinerva As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblCorazon As System.Windows.Forms.Label
    Friend WithEvents lblLogoEmpresa As System.Windows.Forms.PictureBox
    Friend WithEvents btnVolver As System.Windows.Forms.Button
End Class
