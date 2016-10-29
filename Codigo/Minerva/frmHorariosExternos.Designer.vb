<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHorariosExternos
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
        Me.lblHorario = New System.Windows.Forms.Label()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.btnGuardarPdf = New System.Windows.Forms.PictureBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Grilla = New Minerva.frmVistaGrilla()
        CType(Me.btnGuardarPdf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHorario
        '
        Me.lblHorario.AutoSize = True
        Me.lblHorario.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.lblHorario.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblHorario.Font = New System.Drawing.Font("Corbel", 36.0!, System.Drawing.FontStyle.Bold)
        Me.lblHorario.ForeColor = System.Drawing.Color.White
        Me.lblHorario.Location = New System.Drawing.Point(0, 0)
        Me.lblHorario.Name = "lblHorario"
        Me.lblHorario.Padding = New System.Windows.Forms.Padding(0, 0, 0, 20)
        Me.lblHorario.Size = New System.Drawing.Size(410, 79)
        Me.lblHorario.TabIndex = 3
        Me.lblHorario.Text = "Horarios del grupo"
        '
        'cboGrupo
        '
        Me.cboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrupo.Font = New System.Drawing.Font("Corbel", 36.0!, System.Drawing.FontStyle.Bold)
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Items.AddRange(New Object() {"3 BG", "2 BG"})
        Me.cboGrupo.Location = New System.Drawing.Point(400, 0)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(213, 67)
        Me.cboGrupo.TabIndex = 4
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "pdf"
        Me.SaveFileDialog1.Filter = "Archivos PDF|*.pdf"
        Me.SaveFileDialog1.InitialDirectory = "Desktop"
        Me.SaveFileDialog1.RestoreDirectory = True
        '
        'btnGuardarPdf
        '
        Me.btnGuardarPdf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardarPdf.BackgroundImage = Global.Minerva.My.Resources.Resources.guardar_como_pdf_normal
        Me.btnGuardarPdf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnGuardarPdf.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardarPdf.Location = New System.Drawing.Point(1087, 10)
        Me.btnGuardarPdf.Name = "btnGuardarPdf"
        Me.btnGuardarPdf.Size = New System.Drawing.Size(61, 59)
        Me.btnGuardarPdf.TabIndex = 6
        Me.btnGuardarPdf.TabStop = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnAceptar.Location = New System.Drawing.Point(1154, 14)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(114, 50)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Volver a Minerva"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Grilla
        '
        Me.Grilla.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.Location = New System.Drawing.Point(0, 79)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.Size = New System.Drawing.Size(1280, 641)
        Me.Grilla.TabIndex = 2
        Me.Grilla.TabStop = False
        '
        'frmHorariosExternos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1280, 720)
        Me.Controls.Add(Me.btnGuardarPdf)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.cboGrupo)
        Me.Controls.Add(Me.Grilla)
        Me.Controls.Add(Me.lblHorario)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHorariosExternos"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmHorariosExternos"
        CType(Me.btnGuardarPdf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grilla As Minerva.frmVistaGrilla
    Friend WithEvents lblHorario As System.Windows.Forms.Label
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnGuardarPdf As System.Windows.Forms.PictureBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
End Class
