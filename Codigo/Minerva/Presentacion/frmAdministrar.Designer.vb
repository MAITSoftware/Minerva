<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdministrar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdministrar))
        Me.btnSalones = New System.Windows.Forms.Button()
        Me.btnGrupos = New System.Windows.Forms.Button()
        Me.pnlPestañas = New System.Windows.Forms.Panel()
        Me.pnlBorde = New System.Windows.Forms.Panel()
        Me.btnHorarios = New System.Windows.Forms.Button()
        Me.btnDocentes = New System.Windows.Forms.Button()
        Me.btnUsuarios = New System.Windows.Forms.Button()
        Me.pnlBorde1 = New System.Windows.Forms.Panel()
        Me.pnlBorde2 = New System.Windows.Forms.Panel()
        Me.pnlBorde3 = New System.Windows.Forms.Panel()
        Me.sfdBackupSQL = New System.Windows.Forms.SaveFileDialog()
        Me.pnlAyudabtnBackup = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBackup = New System.Windows.Forms.PictureBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.pnlPestañas.SuspendLayout()
        Me.pnlAyudabtnBackup.SuspendLayout()
        CType(Me.btnBackup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSalones
        '
        Me.btnSalones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnSalones.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.btnSalones.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalones.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnSalones.FlatAppearance.BorderSize = 2
        Me.btnSalones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.btnSalones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.btnSalones.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalones.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.btnSalones.ForeColor = System.Drawing.Color.White
        Me.btnSalones.Location = New System.Drawing.Point(5, -2)
        Me.btnSalones.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSalones.Name = "btnSalones"
        Me.btnSalones.Size = New System.Drawing.Size(135, 44)
        Me.btnSalones.TabIndex = 1
        Me.btnSalones.TabStop = False
        Me.btnSalones.Text = "Salones"
        Me.btnSalones.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalones.UseVisualStyleBackColor = False
        Me.btnSalones.Visible = False
        '
        'btnGrupos
        '
        Me.btnGrupos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnGrupos.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.btnGrupos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGrupos.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnGrupos.FlatAppearance.BorderSize = 2
        Me.btnGrupos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.btnGrupos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.btnGrupos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrupos.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.btnGrupos.ForeColor = System.Drawing.Color.White
        Me.btnGrupos.Location = New System.Drawing.Point(142, 6)
        Me.btnGrupos.Margin = New System.Windows.Forms.Padding(0)
        Me.btnGrupos.Name = "btnGrupos"
        Me.btnGrupos.Size = New System.Drawing.Size(135, 44)
        Me.btnGrupos.TabIndex = 3
        Me.btnGrupos.TabStop = False
        Me.btnGrupos.Text = "Grupos"
        Me.btnGrupos.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGrupos.UseVisualStyleBackColor = False
        Me.btnGrupos.Visible = False
        '
        'pnlPestañas
        '
        Me.pnlPestañas.Controls.Add(Me.pnlBorde)
        Me.pnlPestañas.Controls.Add(Me.btnHorarios)
        Me.pnlPestañas.Controls.Add(Me.btnDocentes)
        Me.pnlPestañas.Controls.Add(Me.btnGrupos)
        Me.pnlPestañas.Controls.Add(Me.btnSalones)
        Me.pnlPestañas.Controls.Add(Me.btnUsuarios)
        Me.pnlPestañas.Location = New System.Drawing.Point(0, 0)
        Me.pnlPestañas.Name = "pnlPestañas"
        Me.pnlPestañas.Size = New System.Drawing.Size(1200, 50)
        Me.pnlPestañas.TabIndex = 4
        '
        'pnlBorde
        '
        Me.pnlBorde.BackColor = System.Drawing.Color.PaleGreen
        Me.pnlBorde.Location = New System.Drawing.Point(0, 40)
        Me.pnlBorde.Name = "pnlBorde"
        Me.pnlBorde.Size = New System.Drawing.Size(1007, 2)
        Me.pnlBorde.TabIndex = 5
        '
        'btnHorarios
        '
        Me.btnHorarios.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnHorarios.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.btnHorarios.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHorarios.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnHorarios.FlatAppearance.BorderSize = 2
        Me.btnHorarios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.btnHorarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.btnHorarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHorarios.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.btnHorarios.ForeColor = System.Drawing.Color.White
        Me.btnHorarios.Location = New System.Drawing.Point(418, 6)
        Me.btnHorarios.Margin = New System.Windows.Forms.Padding(0)
        Me.btnHorarios.Name = "btnHorarios"
        Me.btnHorarios.Size = New System.Drawing.Size(135, 44)
        Me.btnHorarios.TabIndex = 5
        Me.btnHorarios.TabStop = False
        Me.btnHorarios.Text = "Horarios"
        Me.btnHorarios.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnHorarios.UseVisualStyleBackColor = False
        Me.btnHorarios.Visible = False
        '
        'btnDocentes
        '
        Me.btnDocentes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnDocentes.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.btnDocentes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDocentes.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnDocentes.FlatAppearance.BorderSize = 2
        Me.btnDocentes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.btnDocentes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.btnDocentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDocentes.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.btnDocentes.ForeColor = System.Drawing.Color.White
        Me.btnDocentes.Location = New System.Drawing.Point(280, 6)
        Me.btnDocentes.Margin = New System.Windows.Forms.Padding(0)
        Me.btnDocentes.Name = "btnDocentes"
        Me.btnDocentes.Size = New System.Drawing.Size(135, 44)
        Me.btnDocentes.TabIndex = 4
        Me.btnDocentes.TabStop = False
        Me.btnDocentes.Text = "Docentes"
        Me.btnDocentes.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDocentes.UseVisualStyleBackColor = False
        Me.btnDocentes.Visible = False
        '
        'btnUsuarios
        '
        Me.btnUsuarios.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnUsuarios.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.btnUsuarios.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUsuarios.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnUsuarios.FlatAppearance.BorderSize = 2
        Me.btnUsuarios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.btnUsuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUsuarios.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.btnUsuarios.ForeColor = System.Drawing.Color.White
        Me.btnUsuarios.Location = New System.Drawing.Point(557, 6)
        Me.btnUsuarios.Margin = New System.Windows.Forms.Padding(0)
        Me.btnUsuarios.Name = "btnUsuarios"
        Me.btnUsuarios.Size = New System.Drawing.Size(135, 44)
        Me.btnUsuarios.TabIndex = 6
        Me.btnUsuarios.TabStop = False
        Me.btnUsuarios.Text = "Usuarios"
        Me.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUsuarios.UseVisualStyleBackColor = False
        Me.btnUsuarios.Visible = False
        '
        'pnlBorde1
        '
        Me.pnlBorde1.BackColor = System.Drawing.Color.PaleGreen
        Me.pnlBorde1.Location = New System.Drawing.Point(1005, 41)
        Me.pnlBorde1.Name = "pnlBorde1"
        Me.pnlBorde1.Size = New System.Drawing.Size(3, 504)
        Me.pnlBorde1.TabIndex = 6
        '
        'pnlBorde2
        '
        Me.pnlBorde2.BackColor = System.Drawing.Color.PaleGreen
        Me.pnlBorde2.Location = New System.Drawing.Point(0, 40)
        Me.pnlBorde2.Name = "pnlBorde2"
        Me.pnlBorde2.Size = New System.Drawing.Size(2, 500)
        Me.pnlBorde2.TabIndex = 7
        '
        'pnlBorde3
        '
        Me.pnlBorde3.BackColor = System.Drawing.Color.PaleGreen
        Me.pnlBorde3.Location = New System.Drawing.Point(0, 535)
        Me.pnlBorde3.Name = "pnlBorde3"
        Me.pnlBorde3.Size = New System.Drawing.Size(1007, 2)
        Me.pnlBorde3.TabIndex = 8
        '
        'sfdBackupSQL
        '
        Me.sfdBackupSQL.Filter = "Archivos SQL|*.sql|Todos los archivos|*.*"
        '
        'pnlAyudabtnBackup
        '
        Me.pnlAyudabtnBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAyudabtnBackup.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.pnlAyudabtnBackup.BackgroundImage = CType(resources.GetObject("pnlAyudabtnBackup.BackgroundImage"), System.Drawing.Image)
        Me.pnlAyudabtnBackup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlAyudabtnBackup.Controls.Add(Me.Label2)
        Me.pnlAyudabtnBackup.Location = New System.Drawing.Point(793, 44)
        Me.pnlAyudabtnBackup.Name = "pnlAyudabtnBackup"
        Me.pnlAyudabtnBackup.Size = New System.Drawing.Size(218, 79)
        Me.pnlAyudabtnBackup.TabIndex = 137
        Me.pnlAyudabtnBackup.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(11, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(196, 46)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Respaldar base de datos a archivo SQL"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBackup
        '
        Me.btnBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBackup.BackgroundImage = Global.Minerva.My.Resources.Resources.guardar_sql_normal
        Me.btnBackup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBackup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBackup.Location = New System.Drawing.Point(966, 3)
        Me.btnBackup.Name = "btnBackup"
        Me.btnBackup.Size = New System.Drawing.Size(35, 35)
        Me.btnBackup.TabIndex = 9
        Me.btnBackup.TabStop = False
        Me.btnBackup.Visible = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(850, 4)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(95, 34)
        Me.btnLimpiar.TabIndex = 138
        Me.btnLimpiar.Text = "Limpiar DB" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(No hace nada)"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        Me.btnLimpiar.Visible = False
        '
        'frmAdministrar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1008, 537)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.pnlAyudabtnBackup)
        Me.Controls.Add(Me.btnBackup)
        Me.Controls.Add(Me.pnlBorde3)
        Me.Controls.Add(Me.pnlBorde2)
        Me.Controls.Add(Me.pnlBorde1)
        Me.Controls.Add(Me.pnlPestañas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAdministrar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Minerva · Administración"
        Me.pnlPestañas.ResumeLayout(False)
        Me.pnlAyudabtnBackup.ResumeLayout(False)
        CType(Me.btnBackup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSalones As System.Windows.Forms.Button
    Friend WithEvents btnGrupos As System.Windows.Forms.Button
    Friend WithEvents pnlPestañas As System.Windows.Forms.Panel
    Friend WithEvents btnHorarios As System.Windows.Forms.Button
    Friend WithEvents btnDocentes As System.Windows.Forms.Button
    Friend WithEvents pnlBorde As System.Windows.Forms.Panel
    Friend WithEvents pnlBorde1 As System.Windows.Forms.Panel
    Friend WithEvents pnlBorde2 As System.Windows.Forms.Panel
    Friend WithEvents pnlBorde3 As System.Windows.Forms.Panel
    Friend WithEvents btnUsuarios As System.Windows.Forms.Button
    Friend WithEvents sfdBackupSQL As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnBackup As System.Windows.Forms.PictureBox
    Friend WithEvents pnlAyudabtnBackup As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
End Class
