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
        Dim lblHorariosSemana As System.Windows.Forms.Label
        Dim lblTitulo As System.Windows.Forms.Label
        Me.pnlGrupos = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlGrupo = New System.Windows.Forms.Panel()
        Me.lblInfoGrupo = New System.Windows.Forms.Label()
        Me.btnEditarGrupo = New System.Windows.Forms.Button()
        Me.btnEliminarGrupo = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnNuevoGrupo = New System.Windows.Forms.Button()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.lblIDGrupo = New System.Windows.Forms.Label()
        Me.lblAccion = New System.Windows.Forms.Label()
        Me.lblSalon = New System.Windows.Forms.Label()
        Me.cmbSalon = New System.Windows.Forms.ComboBox()
        Me.cmbTurno = New System.Windows.Forms.ComboBox()
        Me.lblTurno = New System.Windows.Forms.Label()
        Me.lblCantAlumnos = New System.Windows.Forms.Label()
        Me.txtcantAlumnos = New System.Windows.Forms.TextBox()
        Me.txtIDGrupo = New System.Windows.Forms.TextBox()
        Me.cmbCurso = New System.Windows.Forms.ComboBox()
        Me.lblCurso = New System.Windows.Forms.Label()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.lblOrientacion = New System.Windows.Forms.Label()
        Me.pnlFondo = New System.Windows.Forms.Panel()
        Me.txtGrado = New System.Windows.Forms.TextBox()
        Me.lblGrado = New System.Windows.Forms.Label()
        lblHorariosSemana = New System.Windows.Forms.Label()
        lblTitulo = New System.Windows.Forms.Label()
        Me.pnlGrupos.SuspendLayout()
        Me.pnlGrupo.SuspendLayout()
        Me.pnlFondo.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHorariosSemana
        '
        lblHorariosSemana.AutoSize = True
        lblHorariosSemana.BackColor = System.Drawing.Color.Transparent
        lblHorariosSemana.Font = New System.Drawing.Font("Corbel", 28.0!, System.Drawing.FontStyle.Bold)
        lblHorariosSemana.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        lblHorariosSemana.Location = New System.Drawing.Point(59, 14)
        lblHorariosSemana.Name = "lblHorariosSemana"
        lblHorariosSemana.Size = New System.Drawing.Size(268, 46)
        lblHorariosSemana.TabIndex = 64
        lblHorariosSemana.Text = "Lista de grupos"
        '
        'lblTitulo
        '
        lblTitulo.AutoSize = True
        lblTitulo.Font = New System.Drawing.Font("Corbel", 28.0!, System.Drawing.FontStyle.Bold)
        lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        lblTitulo.Location = New System.Drawing.Point(17, 7)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New System.Drawing.Size(315, 46)
        lblTitulo.TabIndex = 63
        lblTitulo.Text = "Gestión de grupos"
        '
        'pnlGrupos
        '
        Me.pnlGrupos.AutoScroll = True
        Me.pnlGrupos.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.pnlGrupos.Controls.Add(Me.pnlGrupo)
        Me.pnlGrupos.Location = New System.Drawing.Point(38, 63)
        Me.pnlGrupos.Name = "pnlGrupos"
        Me.pnlGrupos.Size = New System.Drawing.Size(332, 406)
        Me.pnlGrupos.TabIndex = 74
        '
        'pnlGrupo
        '
        Me.pnlGrupo.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.pnlGrupo.Controls.Add(Me.lblInfoGrupo)
        Me.pnlGrupo.Controls.Add(Me.btnEditarGrupo)
        Me.pnlGrupo.Controls.Add(Me.btnEliminarGrupo)
        Me.pnlGrupo.Location = New System.Drawing.Point(3, 3)
        Me.pnlGrupo.Name = "pnlGrupo"
        Me.pnlGrupo.Size = New System.Drawing.Size(306, 180)
        Me.pnlGrupo.TabIndex = 2
        '
        'lblInfoGrupo
        '
        Me.lblInfoGrupo.Font = New System.Drawing.Font("Corbel", 14.0!)
        Me.lblInfoGrupo.ForeColor = System.Drawing.Color.White
        Me.lblInfoGrupo.Location = New System.Drawing.Point(1, 0)
        Me.lblInfoGrupo.Name = "lblInfoGrupo"
        Me.lblInfoGrupo.Size = New System.Drawing.Size(302, 148)
        Me.lblInfoGrupo.TabIndex = 5
        Me.lblInfoGrupo.Text = "1 BG" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Curso: Educación media tecnológica" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Orientación: Informática" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Salón: 17" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Tu" & _
    "rno: Tarde" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cant. Alumnos: 30" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblInfoGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnEditarGrupo
        '
        Me.btnEditarGrupo.Font = New System.Drawing.Font("Corbel", 10.0!)
        Me.btnEditarGrupo.Location = New System.Drawing.Point(119, 151)
        Me.btnEditarGrupo.Name = "btnEditarGrupo"
        Me.btnEditarGrupo.Size = New System.Drawing.Size(89, 23)
        Me.btnEditarGrupo.TabIndex = 1
        Me.btnEditarGrupo.Text = "Editar"
        Me.btnEditarGrupo.UseVisualStyleBackColor = True
        '
        'btnEliminarGrupo
        '
        Me.btnEliminarGrupo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnEliminarGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEliminarGrupo.Font = New System.Drawing.Font("Corbel", 10.0!)
        Me.btnEliminarGrupo.Location = New System.Drawing.Point(214, 151)
        Me.btnEliminarGrupo.Name = "btnEliminarGrupo"
        Me.btnEliminarGrupo.Size = New System.Drawing.Size(89, 23)
        Me.btnEliminarGrupo.TabIndex = 2
        Me.btnEliminarGrupo.Text = "Eliminar"
        Me.btnEliminarGrupo.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.AutoSize = True
        Me.btnCancelar.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnCancelar.Location = New System.Drawing.Point(454, 434)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(137, 29)
        Me.btnCancelar.TabIndex = 73
        Me.btnCancelar.Text = "Cancelar edición"
        Me.btnCancelar.UseVisualStyleBackColor = True
        Me.btnCancelar.Visible = False
        '
        'btnNuevoGrupo
        '
        Me.btnNuevoGrupo.AutoSize = True
        Me.btnNuevoGrupo.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnNuevoGrupo.Location = New System.Drawing.Point(360, 16)
        Me.btnNuevoGrupo.Name = "btnNuevoGrupo"
        Me.btnNuevoGrupo.Size = New System.Drawing.Size(140, 29)
        Me.btnNuevoGrupo.TabIndex = 71
        Me.btnNuevoGrupo.Text = "Nuevo grupo"
        Me.btnNuevoGrupo.UseVisualStyleBackColor = True
        Me.btnNuevoGrupo.Visible = False
        '
        'btnConfirmar
        '
        Me.btnConfirmar.AutoSize = True
        Me.btnConfirmar.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnConfirmar.Location = New System.Drawing.Point(454, 399)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(137, 29)
        Me.btnConfirmar.TabIndex = 72
        Me.btnConfirmar.Text = "Confirmar"
        Me.btnConfirmar.UseVisualStyleBackColor = True
        '
        'lblIDGrupo
        '
        Me.lblIDGrupo.AutoSize = True
        Me.lblIDGrupo.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblIDGrupo.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblIDGrupo.Location = New System.Drawing.Point(178, 138)
        Me.lblIDGrupo.Name = "lblIDGrupo"
        Me.lblIDGrupo.Size = New System.Drawing.Size(104, 29)
        Me.lblIDGrupo.TabIndex = 67
        Me.lblIDGrupo.Text = "ID Grupo"
        '
        'lblAccion
        '
        Me.lblAccion.Font = New System.Drawing.Font("Corbel", 20.0!)
        Me.lblAccion.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblAccion.Location = New System.Drawing.Point(17, 46)
        Me.lblAccion.Name = "lblAccion"
        Me.lblAccion.Size = New System.Drawing.Size(529, 74)
        Me.lblAccion.TabIndex = 65
        Me.lblAccion.Text = "Agregar grupo"
        '
        'lblSalon
        '
        Me.lblSalon.AutoSize = True
        Me.lblSalon.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblSalon.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblSalon.Location = New System.Drawing.Point(178, 230)
        Me.lblSalon.Name = "lblSalon"
        Me.lblSalon.Size = New System.Drawing.Size(71, 29)
        Me.lblSalon.TabIndex = 69
        Me.lblSalon.Text = "Salón"
        '
        'cmbSalon
        '
        Me.cmbSalon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSalon.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.cmbSalon.FormattingEnabled = True
        Me.cmbSalon.Items.AddRange(New Object() {"1", "2", "3", "4", "Biblioteca"})
        Me.cmbSalon.Location = New System.Drawing.Point(182, 262)
        Me.cmbSalon.Name = "cmbSalon"
        Me.cmbSalon.Size = New System.Drawing.Size(140, 37)
        Me.cmbSalon.TabIndex = 75
        '
        'cmbTurno
        '
        Me.cmbTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTurno.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.cmbTurno.FormattingEnabled = True
        Me.cmbTurno.Items.AddRange(New Object() {"Mañana", "Tarde"})
        Me.cmbTurno.Location = New System.Drawing.Point(25, 262)
        Me.cmbTurno.Name = "cmbTurno"
        Me.cmbTurno.Size = New System.Drawing.Size(97, 37)
        Me.cmbTurno.TabIndex = 77
        '
        'lblTurno
        '
        Me.lblTurno.AutoSize = True
        Me.lblTurno.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTurno.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblTurno.Location = New System.Drawing.Point(20, 230)
        Me.lblTurno.Name = "lblTurno"
        Me.lblTurno.Size = New System.Drawing.Size(72, 29)
        Me.lblTurno.TabIndex = 76
        Me.lblTurno.Text = "Turno"
        '
        'lblCantAlumnos
        '
        Me.lblCantAlumnos.AutoSize = True
        Me.lblCantAlumnos.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblCantAlumnos.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblCantAlumnos.Location = New System.Drawing.Point(18, 325)
        Me.lblCantAlumnos.Name = "lblCantAlumnos"
        Me.lblCantAlumnos.Size = New System.Drawing.Size(163, 29)
        Me.lblCantAlumnos.TabIndex = 78
        Me.lblCantAlumnos.Text = "Cant. Alumnos"
        '
        'txtcantAlumnos
        '
        Me.txtcantAlumnos.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.txtcantAlumnos.Location = New System.Drawing.Point(23, 357)
        Me.txtcantAlumnos.Name = "txtcantAlumnos"
        Me.txtcantAlumnos.Size = New System.Drawing.Size(68, 37)
        Me.txtcantAlumnos.TabIndex = 79
        Me.txtcantAlumnos.Text = "30"
        Me.txtcantAlumnos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIDGrupo
        '
        Me.txtIDGrupo.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.txtIDGrupo.Location = New System.Drawing.Point(182, 170)
        Me.txtIDGrupo.Name = "txtIDGrupo"
        Me.txtIDGrupo.Size = New System.Drawing.Size(90, 37)
        Me.txtIDGrupo.TabIndex = 80
        Me.txtIDGrupo.Text = "BG"
        Me.txtIDGrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbCurso
        '
        Me.cmbCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCurso.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.cmbCurso.FormattingEnabled = True
        Me.cmbCurso.Items.AddRange(New Object() {"EMT", "CBT"})
        Me.cmbCurso.Location = New System.Drawing.Point(371, 170)
        Me.cmbCurso.Name = "cmbCurso"
        Me.cmbCurso.Size = New System.Drawing.Size(140, 37)
        Me.cmbCurso.TabIndex = 82
        '
        'lblCurso
        '
        Me.lblCurso.AutoSize = True
        Me.lblCurso.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblCurso.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblCurso.Location = New System.Drawing.Point(366, 138)
        Me.lblCurso.Name = "lblCurso"
        Me.lblCurso.Size = New System.Drawing.Size(71, 29)
        Me.lblCurso.TabIndex = 81
        Me.lblCurso.Text = "Curso"
        '
        'ComboBox4
        '
        Me.ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox4.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Items.AddRange(New Object() {"Informática", "Turismo"})
        Me.ComboBox4.Location = New System.Drawing.Point(371, 262)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(140, 37)
        Me.ComboBox4.TabIndex = 84
        '
        'lblOrientacion
        '
        Me.lblOrientacion.AutoSize = True
        Me.lblOrientacion.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblOrientacion.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblOrientacion.Location = New System.Drawing.Point(366, 230)
        Me.lblOrientacion.Name = "lblOrientacion"
        Me.lblOrientacion.Size = New System.Drawing.Size(134, 29)
        Me.lblOrientacion.TabIndex = 83
        Me.lblOrientacion.Text = "Orientación"
        '
        'pnlFondo
        '
        Me.pnlFondo.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.pnlFondo.Controls.Add(lblHorariosSemana)
        Me.pnlFondo.Controls.Add(Me.pnlGrupos)
        Me.pnlFondo.Location = New System.Drawing.Point(618, -7)
        Me.pnlFondo.Name = "pnlFondo"
        Me.pnlFondo.Size = New System.Drawing.Size(386, 515)
        Me.pnlFondo.TabIndex = 85
        '
        'txtGrado
        '
        Me.txtGrado.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.txtGrado.Location = New System.Drawing.Point(23, 170)
        Me.txtGrado.Name = "txtGrado"
        Me.txtGrado.Size = New System.Drawing.Size(68, 37)
        Me.txtGrado.TabIndex = 87
        Me.txtGrado.Text = "1"
        Me.txtGrado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblGrado
        '
        Me.lblGrado.AutoSize = True
        Me.lblGrado.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblGrado.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblGrado.Location = New System.Drawing.Point(18, 138)
        Me.lblGrado.Name = "lblGrado"
        Me.lblGrado.Size = New System.Drawing.Size(75, 29)
        Me.lblGrado.TabIndex = 86
        Me.lblGrado.Text = "Grado"
        '
        'frmAdminGrupos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Controls.Add(Me.txtGrado)
        Me.Controls.Add(Me.lblGrado)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.lblOrientacion)
        Me.Controls.Add(Me.cmbCurso)
        Me.Controls.Add(Me.lblCurso)
        Me.Controls.Add(Me.txtIDGrupo)
        Me.Controls.Add(Me.txtcantAlumnos)
        Me.Controls.Add(Me.lblCantAlumnos)
        Me.Controls.Add(Me.cmbTurno)
        Me.Controls.Add(Me.lblTurno)
        Me.Controls.Add(Me.cmbSalon)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnNuevoGrupo)
        Me.Controls.Add(Me.btnConfirmar)
        Me.Controls.Add(Me.lblIDGrupo)
        Me.Controls.Add(lblTitulo)
        Me.Controls.Add(Me.lblAccion)
        Me.Controls.Add(Me.lblSalon)
        Me.Controls.Add(Me.pnlFondo)
        Me.Name = "frmAdminGrupos"
        Me.Size = New System.Drawing.Size(1004, 493)
        Me.pnlGrupos.ResumeLayout(False)
        Me.pnlGrupo.ResumeLayout(False)
        Me.pnlFondo.ResumeLayout(False)
        Me.pnlFondo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlGrupos As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnNuevoGrupo As System.Windows.Forms.Button
    Friend WithEvents btnConfirmar As System.Windows.Forms.Button
    Friend WithEvents lblIDGrupo As System.Windows.Forms.Label
    Friend WithEvents lblAccion As System.Windows.Forms.Label
    Friend WithEvents lblSalon As System.Windows.Forms.Label
    Friend WithEvents cmbSalon As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTurno As System.Windows.Forms.ComboBox
    Friend WithEvents lblTurno As System.Windows.Forms.Label
    Friend WithEvents lblCantAlumnos As System.Windows.Forms.Label
    Friend WithEvents txtcantAlumnos As System.Windows.Forms.TextBox
    Friend WithEvents txtIDGrupo As System.Windows.Forms.TextBox
    Friend WithEvents cmbCurso As System.Windows.Forms.ComboBox
    Friend WithEvents lblCurso As System.Windows.Forms.Label
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents lblOrientacion As System.Windows.Forms.Label
    Friend WithEvents pnlFondo As System.Windows.Forms.Panel
    Friend WithEvents txtGrado As System.Windows.Forms.TextBox
    Friend WithEvents lblGrado As System.Windows.Forms.Label
    Friend WithEvents pnlGrupo As System.Windows.Forms.Panel
    Friend WithEvents lblInfoGrupo As System.Windows.Forms.Label
    Friend WithEvents btnEditarGrupo As System.Windows.Forms.Button
    Friend WithEvents btnEliminarGrupo As System.Windows.Forms.Button

End Class
