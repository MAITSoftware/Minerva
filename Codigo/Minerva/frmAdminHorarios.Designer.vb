<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminHorarios
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
        Me.lblHora1 = New System.Windows.Forms.Label()
        Me.lblTituloDias = New System.Windows.Forms.Label()
        Me.lblLunes = New System.Windows.Forms.Label()
        Me.lblMartes = New System.Windows.Forms.Label()
        Me.lblMiercoles = New System.Windows.Forms.Label()
        Me.lblJueves = New System.Windows.Forms.Label()
        Me.lblViernes = New System.Windows.Forms.Label()
        Me.lblSabado = New System.Windows.Forms.Label()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.cmbGrupo = New System.Windows.Forms.ComboBox()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblHOra2 = New System.Windows.Forms.Label()
        Me.lblHora4 = New System.Windows.Forms.Label()
        Me.lblHora3 = New System.Windows.Forms.Label()
        Me.lblHora6 = New System.Windows.Forms.Label()
        Me.lblHora5 = New System.Windows.Forms.Label()
        lblTitulo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        lblTitulo.AutoSize = True
        lblTitulo.Font = New System.Drawing.Font("Corbel", 28.0!, System.Drawing.FontStyle.Bold)
        lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        lblTitulo.Location = New System.Drawing.Point(16, 12)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New System.Drawing.Size(336, 46)
        lblTitulo.TabIndex = 48
        lblTitulo.Text = "Gestión de horarios"
        '
        'lblHora1
        '
        Me.lblHora1.AutoSize = True
        Me.lblHora1.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.lblHora1.ForeColor = System.Drawing.Color.White
        Me.lblHora1.Location = New System.Drawing.Point(132, 97)
        Me.lblHora1.Name = "lblHora1"
        Me.lblHora1.Size = New System.Drawing.Size(78, 29)
        Me.lblHora1.TabIndex = 57
        Me.lblHora1.Text = "Hora 1"
        '
        'lblTituloDias
        '
        Me.lblTituloDias.AutoSize = True
        Me.lblTituloDias.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.lblTituloDias.ForeColor = System.Drawing.Color.White
        Me.lblTituloDias.Location = New System.Drawing.Point(19, 97)
        Me.lblTituloDias.Name = "lblTituloDias"
        Me.lblTituloDias.Size = New System.Drawing.Size(57, 29)
        Me.lblTituloDias.TabIndex = 63
        Me.lblTituloDias.Text = "Días"
        '
        'lblLunes
        '
        Me.lblLunes.AutoSize = True
        Me.lblLunes.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.lblLunes.ForeColor = System.Drawing.Color.White
        Me.lblLunes.Location = New System.Drawing.Point(19, 132)
        Me.lblLunes.Name = "lblLunes"
        Me.lblLunes.Size = New System.Drawing.Size(73, 29)
        Me.lblLunes.TabIndex = 64
        Me.lblLunes.Text = "Lunes"
        '
        'lblMartes
        '
        Me.lblMartes.AutoSize = True
        Me.lblMartes.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.lblMartes.ForeColor = System.Drawing.Color.White
        Me.lblMartes.Location = New System.Drawing.Point(19, 173)
        Me.lblMartes.Name = "lblMartes"
        Me.lblMartes.Size = New System.Drawing.Size(83, 29)
        Me.lblMartes.TabIndex = 70
        Me.lblMartes.Text = "Martes"
        '
        'lblMiercoles
        '
        Me.lblMiercoles.AutoSize = True
        Me.lblMiercoles.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.lblMiercoles.ForeColor = System.Drawing.Color.White
        Me.lblMiercoles.Location = New System.Drawing.Point(19, 214)
        Me.lblMiercoles.Name = "lblMiercoles"
        Me.lblMiercoles.Size = New System.Drawing.Size(111, 29)
        Me.lblMiercoles.TabIndex = 76
        Me.lblMiercoles.Text = "Miércoles"
        '
        'lblJueves
        '
        Me.lblJueves.AutoSize = True
        Me.lblJueves.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.lblJueves.ForeColor = System.Drawing.Color.White
        Me.lblJueves.Location = New System.Drawing.Point(19, 255)
        Me.lblJueves.Name = "lblJueves"
        Me.lblJueves.Size = New System.Drawing.Size(79, 29)
        Me.lblJueves.TabIndex = 82
        Me.lblJueves.Text = "Jueves"
        '
        'lblViernes
        '
        Me.lblViernes.AutoSize = True
        Me.lblViernes.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.lblViernes.ForeColor = System.Drawing.Color.White
        Me.lblViernes.Location = New System.Drawing.Point(19, 296)
        Me.lblViernes.Name = "lblViernes"
        Me.lblViernes.Size = New System.Drawing.Size(89, 29)
        Me.lblViernes.TabIndex = 88
        Me.lblViernes.Text = "Viernes"
        '
        'lblSabado
        '
        Me.lblSabado.AutoSize = True
        Me.lblSabado.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.lblSabado.ForeColor = System.Drawing.Color.White
        Me.lblSabado.Location = New System.Drawing.Point(19, 337)
        Me.lblSabado.Name = "lblSabado"
        Me.lblSabado.Size = New System.Drawing.Size(89, 29)
        Me.lblSabado.TabIndex = 94
        Me.lblSabado.Text = "Sábado"
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(690, 31)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(142, 23)
        Me.btnGenerar.TabIndex = 95
        Me.btnGenerar.Text = "Generar horarios"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'cmbGrupo
        '
        Me.cmbGrupo.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.Items.AddRange(New Object() {"Grupo 1", "Grupo 2"})
        Me.cmbGrupo.Location = New System.Drawing.Point(480, 21)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(121, 37)
        Me.cmbGrupo.TabIndex = 97
        '
        'lblGrupo
        '
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblGrupo.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblGrupo.Location = New System.Drawing.Point(398, 24)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(76, 29)
        Me.lblGrupo.TabIndex = 96
        Me.lblGrupo.Text = "Grupo"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(845, 440)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(143, 41)
        Me.Button2.TabIndex = 98
        Me.Button2.Text = "Confirmar cambios"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lblHOra2
        '
        Me.lblHOra2.AutoSize = True
        Me.lblHOra2.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.lblHOra2.ForeColor = System.Drawing.Color.White
        Me.lblHOra2.Location = New System.Drawing.Point(274, 97)
        Me.lblHOra2.Name = "lblHOra2"
        Me.lblHOra2.Size = New System.Drawing.Size(79, 29)
        Me.lblHOra2.TabIndex = 100
        Me.lblHOra2.Text = "Hora 2"
        '
        'lblHora4
        '
        Me.lblHora4.AutoSize = True
        Me.lblHora4.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.lblHora4.ForeColor = System.Drawing.Color.White
        Me.lblHora4.Location = New System.Drawing.Point(560, 97)
        Me.lblHora4.Name = "lblHora4"
        Me.lblHora4.Size = New System.Drawing.Size(79, 29)
        Me.lblHora4.TabIndex = 114
        Me.lblHora4.Text = "Hora 4"
        '
        'lblHora3
        '
        Me.lblHora3.AutoSize = True
        Me.lblHora3.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.lblHora3.ForeColor = System.Drawing.Color.White
        Me.lblHora3.Location = New System.Drawing.Point(418, 97)
        Me.lblHora3.Name = "lblHora3"
        Me.lblHora3.Size = New System.Drawing.Size(78, 29)
        Me.lblHora3.TabIndex = 107
        Me.lblHora3.Text = "Hora 3"
        '
        'lblHora6
        '
        Me.lblHora6.AutoSize = True
        Me.lblHora6.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.lblHora6.ForeColor = System.Drawing.Color.White
        Me.lblHora6.Location = New System.Drawing.Point(840, 97)
        Me.lblHora6.Name = "lblHora6"
        Me.lblHora6.Size = New System.Drawing.Size(80, 29)
        Me.lblHora6.TabIndex = 128
        Me.lblHora6.Text = "Hora 6"
        '
        'lblHora5
        '
        Me.lblHora5.AutoSize = True
        Me.lblHora5.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.lblHora5.ForeColor = System.Drawing.Color.White
        Me.lblHora5.Location = New System.Drawing.Point(698, 97)
        Me.lblHora5.Name = "lblHora5"
        Me.lblHora5.Size = New System.Drawing.Size(79, 29)
        Me.lblHora5.TabIndex = 121
        Me.lblHora5.Text = "Hora 5"
        '
        'frmAdminHorarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Controls.Add(Me.lblHora6)
        Me.Controls.Add(Me.lblHora5)
        Me.Controls.Add(Me.lblHora4)
        Me.Controls.Add(Me.lblHora3)
        Me.Controls.Add(Me.lblHOra2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.cmbGrupo)
        Me.Controls.Add(Me.lblGrupo)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.lblSabado)
        Me.Controls.Add(Me.lblViernes)
        Me.Controls.Add(Me.lblJueves)
        Me.Controls.Add(Me.lblMiercoles)
        Me.Controls.Add(Me.lblMartes)
        Me.Controls.Add(Me.lblLunes)
        Me.Controls.Add(Me.lblTituloDias)
        Me.Controls.Add(Me.lblHora1)
        Me.Controls.Add(lblTitulo)
        Me.Name = "frmAdminHorarios"
        Me.Size = New System.Drawing.Size(1004, 493)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblHora1 As System.Windows.Forms.Label
    Friend WithEvents lblTituloDias As System.Windows.Forms.Label
    Friend WithEvents lblLunes As System.Windows.Forms.Label
    Friend WithEvents lblMartes As System.Windows.Forms.Label
    Friend WithEvents lblMiercoles As System.Windows.Forms.Label
    Friend WithEvents lblJueves As System.Windows.Forms.Label
    Friend WithEvents lblViernes As System.Windows.Forms.Label
    Friend WithEvents lblSabado As System.Windows.Forms.Label
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents cmbGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents lblGrupo As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lblHOra2 As System.Windows.Forms.Label
    Friend WithEvents lblHora4 As System.Windows.Forms.Label
    Friend WithEvents lblHora3 As System.Windows.Forms.Label
    Friend WithEvents lblHora6 As System.Windows.Forms.Label
    Friend WithEvents lblHora5 As System.Windows.Forms.Label

End Class
