<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHorariosExternos
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
        Me.lblHorario = New System.Windows.Forms.Label()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.btnAceptar = New System.Windows.Forms.PictureBox()
        Me.btnGuardarPdf = New System.Windows.Forms.PictureBox()
        Me.Grilla = New Minerva.frmVistaGrilla()
        Me.pnlAyudabtnGuardarPdf = New System.Windows.Forms.Panel()
        Me.lblCantidadUsuariosAprobacion = New System.Windows.Forms.Label()
        Me.pnlAyudabtnAceptar = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.btnAceptar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnGuardarPdf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAyudabtnGuardarPdf.SuspendLayout()
        Me.pnlAyudabtnAceptar.SuspendLayout()
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
        Me.cboGrupo.Font = New System.Drawing.Font("Corbel", 34.0!, System.Drawing.FontStyle.Bold)
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Items.AddRange(New Object() {"3 BG", "2 BG"})
        Me.cboGrupo.Location = New System.Drawing.Point(400, 8)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(213, 63)
        Me.cboGrupo.TabIndex = 4
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "pdf"
        Me.SaveFileDialog1.Filter = "Archivos PDF|*.pdf"
        Me.SaveFileDialog1.InitialDirectory = "Desktop"
        Me.SaveFileDialog1.RestoreDirectory = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.BackgroundImage = Global.Minerva.My.Resources.Resources.unfullscreen_normal
        Me.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAceptar.Location = New System.Drawing.Point(1166, 9)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(60, 60)
        Me.btnAceptar.TabIndex = 135
        Me.btnAceptar.TabStop = False
        '
        'btnGuardarPdf
        '
        Me.btnGuardarPdf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardarPdf.BackgroundImage = Global.Minerva.My.Resources.Resources.guardar_como_pdf_normal
        Me.btnGuardarPdf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnGuardarPdf.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardarPdf.Location = New System.Drawing.Point(1087, 9)
        Me.btnGuardarPdf.Name = "btnGuardarPdf"
        Me.btnGuardarPdf.Size = New System.Drawing.Size(60, 60)
        Me.btnGuardarPdf.TabIndex = 6
        Me.btnGuardarPdf.TabStop = False
        '
        'Grilla
        '
        Me.Grilla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grilla.AutoScroll = True
        Me.Grilla.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(38, 111)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.Size = New System.Drawing.Size(1240, 609)
        Me.Grilla.TabIndex = 2
        Me.Grilla.TabStop = False
        '
        'pnlAyudabtnGuardarPdf
        '
        Me.pnlAyudabtnGuardarPdf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAyudabtnGuardarPdf.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.pnlAyudabtnGuardarPdf.BackgroundImage = Global.Minerva.My.Resources.Resources.dialogo_arriba
        Me.pnlAyudabtnGuardarPdf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlAyudabtnGuardarPdf.Controls.Add(Me.lblCantidadUsuariosAprobacion)
        Me.pnlAyudabtnGuardarPdf.Location = New System.Drawing.Point(915, 75)
        Me.pnlAyudabtnGuardarPdf.Name = "pnlAyudabtnGuardarPdf"
        Me.pnlAyudabtnGuardarPdf.Size = New System.Drawing.Size(291, 100)
        Me.pnlAyudabtnGuardarPdf.TabIndex = 136
        Me.pnlAyudabtnGuardarPdf.Visible = False
        '
        'lblCantidadUsuariosAprobacion
        '
        Me.lblCantidadUsuariosAprobacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.lblCantidadUsuariosAprobacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lblCantidadUsuariosAprobacion.ForeColor = System.Drawing.Color.White
        Me.lblCantidadUsuariosAprobacion.Location = New System.Drawing.Point(8, 28)
        Me.lblCantidadUsuariosAprobacion.Name = "lblCantidadUsuariosAprobacion"
        Me.lblCantidadUsuariosAprobacion.Size = New System.Drawing.Size(278, 67)
        Me.lblCantidadUsuariosAprobacion.TabIndex = 0
        Me.lblCantidadUsuariosAprobacion.Text = "Guardar horarios (grilla) a archivo PDF"
        Me.lblCantidadUsuariosAprobacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlAyudabtnAceptar
        '
        Me.pnlAyudabtnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAyudabtnAceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.pnlAyudabtnAceptar.BackgroundImage = Global.Minerva.My.Resources.Resources.dialogo_arriba
        Me.pnlAyudabtnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlAyudabtnAceptar.Controls.Add(Me.Label1)
        Me.pnlAyudabtnAceptar.Location = New System.Drawing.Point(990, 75)
        Me.pnlAyudabtnAceptar.Name = "pnlAyudabtnAceptar"
        Me.pnlAyudabtnAceptar.Size = New System.Drawing.Size(291, 100)
        Me.pnlAyudabtnAceptar.TabIndex = 137
        Me.pnlAyudabtnAceptar.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(278, 67)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Salir de pantalla completa y volver a Minerva"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmHorariosExternos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1280, 720)
        Me.Controls.Add(Me.pnlAyudabtnAceptar)
        Me.Controls.Add(Me.pnlAyudabtnGuardarPdf)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnGuardarPdf)
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
        CType(Me.btnAceptar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnGuardarPdf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAyudabtnGuardarPdf.ResumeLayout(False)
        Me.pnlAyudabtnAceptar.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grilla As Minerva.frmVistaGrilla
    Friend WithEvents lblHorario As System.Windows.Forms.Label
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnGuardarPdf As System.Windows.Forms.PictureBox
    Friend WithEvents btnAceptar As System.Windows.Forms.PictureBox
    Friend WithEvents pnlAyudabtnGuardarPdf As System.Windows.Forms.Panel
    Friend WithEvents lblCantidadUsuariosAprobacion As System.Windows.Forms.Label
    Friend WithEvents pnlAyudabtnAceptar As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
