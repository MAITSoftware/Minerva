﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim lblHorariosSemana As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.pnlInfoCurso = New System.Windows.Forms.Panel()
        Me.lblInfoCurso = New System.Windows.Forms.Label()
        Me.lblSeleccioneGrupo2 = New System.Windows.Forms.Label()
        Me.pnlMaterias = New System.Windows.Forms.Panel()
        Me.lblNomMateria = New System.Windows.Forms.Label()
        Me.lblNomProfesor = New System.Windows.Forms.Label()
        Me.lblValorSalon = New System.Windows.Forms.Label()
        Me.lblValorCantAlumnos = New System.Windows.Forms.Label()
        Me.lblValorTurno = New System.Windows.Forms.Label()
        Me.lblValorGrado = New System.Windows.Forms.Label()
        Me.lblValorTipo = New System.Windows.Forms.Label()
        Me.lblValorAdscripto = New System.Windows.Forms.Label()
        Me.lblSalon = New System.Windows.Forms.Label()
        Me.lblCantAlumnos = New System.Windows.Forms.Label()
        Me.lblTurno = New System.Windows.Forms.Label()
        Me.lblAdscripto = New System.Windows.Forms.Label()
        Me.lblGrado = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.lblProfesores = New System.Windows.Forms.Label()
        Me.lblNomGrupo = New System.Windows.Forms.Label()
        Me.pnlFiltro = New System.Windows.Forms.Panel()
        Me.btnAdministrar = New System.Windows.Forms.Button()
        Me.chkTurno = New System.Windows.Forms.CheckBox()
        Me.chkGrado = New System.Windows.Forms.CheckBox()
        Me.chkCurso = New System.Windows.Forms.CheckBox()
        Me.cboTurno = New System.Windows.Forms.ComboBox()
        Me.cboGrado = New System.Windows.Forms.ComboBox()
        Me.cboCurso = New System.Windows.Forms.ComboBox()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.lblFiltrado = New System.Windows.Forms.Label()
        Me.pnlSeparador = New System.Windows.Forms.Panel()
        Me.lblSeleccioneGrupo = New System.Windows.Forms.Label()
        Me.timerAnimacion = New System.Windows.Forms.Timer(Me.components)
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Sábado = New Minerva.frmDia()
        Me.Viernes = New Minerva.frmDia()
        Me.Jueves = New Minerva.frmDia()
        Me.Miércoles = New Minerva.frmDia()
        Me.Martes = New Minerva.frmDia()
        Me.Lunes = New Minerva.frmDia()
        lblHorariosSemana = New System.Windows.Forms.Label()
        Me.pnlInfoCurso.SuspendLayout()
        Me.pnlMaterias.SuspendLayout()
        Me.pnlFiltro.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHorariosSemana
        '
        lblHorariosSemana.AutoSize = True
        lblHorariosSemana.Font = New System.Drawing.Font("Corbel", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblHorariosSemana.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        lblHorariosSemana.Location = New System.Drawing.Point(24, 177)
        lblHorariosSemana.Name = "lblHorariosSemana"
        lblHorariosSemana.Size = New System.Drawing.Size(486, 59)
        lblHorariosSemana.TabIndex = 1
        lblHorariosSemana.Text = "Horarios de la semana"
        '
        'pnlInfoCurso
        '
        Me.pnlInfoCurso.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pnlInfoCurso.Controls.Add(Me.lblInfoCurso)
        Me.pnlInfoCurso.Controls.Add(Me.lblSeleccioneGrupo2)
        Me.pnlInfoCurso.Controls.Add(Me.pnlMaterias)
        Me.pnlInfoCurso.Controls.Add(Me.lblValorSalon)
        Me.pnlInfoCurso.Controls.Add(Me.lblValorCantAlumnos)
        Me.pnlInfoCurso.Controls.Add(Me.lblValorTurno)
        Me.pnlInfoCurso.Controls.Add(Me.lblValorGrado)
        Me.pnlInfoCurso.Controls.Add(Me.lblValorTipo)
        Me.pnlInfoCurso.Controls.Add(Me.lblValorAdscripto)
        Me.pnlInfoCurso.Controls.Add(Me.lblSalon)
        Me.pnlInfoCurso.Controls.Add(Me.lblCantAlumnos)
        Me.pnlInfoCurso.Controls.Add(Me.lblTurno)
        Me.pnlInfoCurso.Controls.Add(Me.lblAdscripto)
        Me.pnlInfoCurso.Controls.Add(Me.lblGrado)
        Me.pnlInfoCurso.Controls.Add(Me.lblTipo)
        Me.pnlInfoCurso.Controls.Add(Me.lblProfesores)
        Me.pnlInfoCurso.Controls.Add(Me.lblNomGrupo)
        Me.pnlInfoCurso.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.pnlInfoCurso.Location = New System.Drawing.Point(965, -1)
        Me.pnlInfoCurso.Name = "pnlInfoCurso"
        Me.pnlInfoCurso.Size = New System.Drawing.Size(300, 686)
        Me.pnlInfoCurso.TabIndex = 0
        '
        'lblInfoCurso
        '
        Me.lblInfoCurso.Font = New System.Drawing.Font("Corbel", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoCurso.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblInfoCurso.Location = New System.Drawing.Point(-1, 11)
        Me.lblInfoCurso.Name = "lblInfoCurso"
        Me.lblInfoCurso.Size = New System.Drawing.Size(300, 40)
        Me.lblInfoCurso.TabIndex = 1
        Me.lblInfoCurso.Text = "Información del curso" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblInfoCurso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSeleccioneGrupo2
        '
        Me.lblSeleccioneGrupo2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.lblSeleccioneGrupo2.Font = New System.Drawing.Font("Corbel", 28.0!, System.Drawing.FontStyle.Bold)
        Me.lblSeleccioneGrupo2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblSeleccioneGrupo2.Location = New System.Drawing.Point(3, 1)
        Me.lblSeleccioneGrupo2.Name = "lblSeleccioneGrupo2"
        Me.lblSeleccioneGrupo2.Size = New System.Drawing.Size(297, 721)
        Me.lblSeleccioneGrupo2.TabIndex = 21
        Me.lblSeleccioneGrupo2.Text = "No disponible" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblSeleccioneGrupo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlMaterias
        '
        Me.pnlMaterias.AutoScroll = True
        Me.pnlMaterias.Controls.Add(Me.lblNomMateria)
        Me.pnlMaterias.Controls.Add(Me.lblNomProfesor)
        Me.pnlMaterias.Location = New System.Drawing.Point(2, 178)
        Me.pnlMaterias.Name = "pnlMaterias"
        Me.pnlMaterias.Size = New System.Drawing.Size(297, 172)
        Me.pnlMaterias.TabIndex = 10
        '
        'lblNomMateria
        '
        Me.lblNomMateria.AutoSize = True
        Me.lblNomMateria.Font = New System.Drawing.Font("Candara", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomMateria.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNomMateria.Location = New System.Drawing.Point(14, 10)
        Me.lblNomMateria.Name = "lblNomMateria"
        Me.lblNomMateria.Size = New System.Drawing.Size(111, 23)
        Me.lblNomMateria.TabIndex = 1
        Me.lblNomMateria.Text = "Matemática:"
        '
        'lblNomProfesor
        '
        Me.lblNomProfesor.AutoSize = True
        Me.lblNomProfesor.Font = New System.Drawing.Font("Nirmala UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomProfesor.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblNomProfesor.Location = New System.Drawing.Point(131, 11)
        Me.lblNomProfesor.Name = "lblNomProfesor"
        Me.lblNomProfesor.Size = New System.Drawing.Size(107, 21)
        Me.lblNomProfesor.TabIndex = 1
        Me.lblNomProfesor.Text = "Santiago Vigo"
        '
        'lblValorSalon
        '
        Me.lblValorSalon.AutoSize = True
        Me.lblValorSalon.Font = New System.Drawing.Font("Nirmala UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorSalon.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblValorSalon.Location = New System.Drawing.Point(159, 530)
        Me.lblValorSalon.Name = "lblValorSalon"
        Me.lblValorSalon.Size = New System.Drawing.Size(28, 21)
        Me.lblValorSalon.TabIndex = 6
        Me.lblValorSalon.Text = "17"
        '
        'lblValorCantAlumnos
        '
        Me.lblValorCantAlumnos.AutoSize = True
        Me.lblValorCantAlumnos.Font = New System.Drawing.Font("Nirmala UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorCantAlumnos.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblValorCantAlumnos.Location = New System.Drawing.Point(206, 498)
        Me.lblValorCantAlumnos.Name = "lblValorCantAlumnos"
        Me.lblValorCantAlumnos.Size = New System.Drawing.Size(28, 21)
        Me.lblValorCantAlumnos.TabIndex = 6
        Me.lblValorCantAlumnos.Text = "24"
        '
        'lblValorTurno
        '
        Me.lblValorTurno.AutoSize = True
        Me.lblValorTurno.Font = New System.Drawing.Font("Nirmala UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorTurno.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblValorTurno.Location = New System.Drawing.Point(85, 465)
        Me.lblValorTurno.Name = "lblValorTurno"
        Me.lblValorTurno.Size = New System.Drawing.Size(77, 21)
        Me.lblValorTurno.TabIndex = 6
        Me.lblValorTurno.Text = "Matutino "
        '
        'lblValorGrado
        '
        Me.lblValorGrado.AutoSize = True
        Me.lblValorGrado.Font = New System.Drawing.Font("Nirmala UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorGrado.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblValorGrado.Location = New System.Drawing.Point(87, 401)
        Me.lblValorGrado.Name = "lblValorGrado"
        Me.lblValorGrado.Size = New System.Drawing.Size(19, 21)
        Me.lblValorGrado.TabIndex = 6
        Me.lblValorGrado.Text = "3"
        '
        'lblValorTipo
        '
        Me.lblValorTipo.AutoSize = True
        Me.lblValorTipo.Font = New System.Drawing.Font("Nirmala UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorTipo.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblValorTipo.Location = New System.Drawing.Point(147, 369)
        Me.lblValorTipo.Name = "lblValorTipo"
        Me.lblValorTipo.Size = New System.Drawing.Size(91, 21)
        Me.lblValorTipo.TabIndex = 6
        Me.lblValorTipo.Text = "Bachillerato"
        '
        'lblValorAdscripto
        '
        Me.lblValorAdscripto.AutoSize = True
        Me.lblValorAdscripto.Font = New System.Drawing.Font("Nirmala UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorAdscripto.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblValorAdscripto.Location = New System.Drawing.Point(174, 432)
        Me.lblValorAdscripto.Name = "lblValorAdscripto"
        Me.lblValorAdscripto.Size = New System.Drawing.Size(112, 21)
        Me.lblValorAdscripto.TabIndex = 6
        Me.lblValorAdscripto.Text = "Gabriela asdsd"
        '
        'lblSalon
        '
        Me.lblSalon.AutoSize = True
        Me.lblSalon.Font = New System.Drawing.Font("Candara", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalon.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblSalon.Location = New System.Drawing.Point(17, 528)
        Me.lblSalon.Name = "lblSalon"
        Me.lblSalon.Size = New System.Drawing.Size(136, 23)
        Me.lblSalon.TabIndex = 1
        Me.lblSalon.Text = "Salón asignado:"
        '
        'lblCantAlumnos
        '
        Me.lblCantAlumnos.AutoSize = True
        Me.lblCantAlumnos.Font = New System.Drawing.Font("Candara", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantAlumnos.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblCantAlumnos.Location = New System.Drawing.Point(17, 496)
        Me.lblCantAlumnos.Name = "lblCantAlumnos"
        Me.lblCantAlumnos.Size = New System.Drawing.Size(183, 23)
        Me.lblCantAlumnos.TabIndex = 1
        Me.lblCantAlumnos.Text = "Cantidad de alumnos:"
        '
        'lblTurno
        '
        Me.lblTurno.AutoSize = True
        Me.lblTurno.Font = New System.Drawing.Font("Candara", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurno.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblTurno.Location = New System.Drawing.Point(17, 463)
        Me.lblTurno.Name = "lblTurno"
        Me.lblTurno.Size = New System.Drawing.Size(62, 23)
        Me.lblTurno.TabIndex = 1
        Me.lblTurno.Text = "Turno:"
        '
        'lblAdscripto
        '
        Me.lblAdscripto.AutoSize = True
        Me.lblAdscripto.Font = New System.Drawing.Font("Candara", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdscripto.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblAdscripto.Location = New System.Drawing.Point(17, 431)
        Me.lblAdscripto.Name = "lblAdscripto"
        Me.lblAdscripto.Size = New System.Drawing.Size(156, 23)
        Me.lblAdscripto.TabIndex = 1
        Me.lblAdscripto.Text = "Adscripto a cargo:"
        '
        'lblGrado
        '
        Me.lblGrado.AutoSize = True
        Me.lblGrado.Font = New System.Drawing.Font("Candara", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrado.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblGrado.Location = New System.Drawing.Point(17, 399)
        Me.lblGrado.Name = "lblGrado"
        Me.lblGrado.Size = New System.Drawing.Size(64, 23)
        Me.lblGrado.TabIndex = 1
        Me.lblGrado.Text = "Grado:"
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Candara", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblTipo.Location = New System.Drawing.Point(17, 367)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(124, 23)
        Me.lblTipo.TabIndex = 1
        Me.lblTipo.Text = "Tipo de curso:"
        '
        'lblProfesores
        '
        Me.lblProfesores.AutoSize = True
        Me.lblProfesores.Font = New System.Drawing.Font("Candara", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProfesores.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblProfesores.Location = New System.Drawing.Point(17, 143)
        Me.lblProfesores.Name = "lblProfesores"
        Me.lblProfesores.Size = New System.Drawing.Size(188, 23)
        Me.lblProfesores.TabIndex = 1
        Me.lblProfesores.Text = "Materias y profesores"
        '
        'lblNomGrupo
        '
        Me.lblNomGrupo.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomGrupo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblNomGrupo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblNomGrupo.Location = New System.Drawing.Point(0, 46)
        Me.lblNomGrupo.Name = "lblNomGrupo"
        Me.lblNomGrupo.Size = New System.Drawing.Size(300, 76)
        Me.lblNomGrupo.TabIndex = 1
        Me.lblNomGrupo.Text = "Grupo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3ero BG"
        Me.lblNomGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlFiltro
        '
        Me.pnlFiltro.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pnlFiltro.Controls.Add(Me.btnSalir)
        Me.pnlFiltro.Controls.Add(Me.btnAdministrar)
        Me.pnlFiltro.Controls.Add(Me.chkTurno)
        Me.pnlFiltro.Controls.Add(Me.imgLogo)
        Me.pnlFiltro.Controls.Add(Me.chkGrado)
        Me.pnlFiltro.Controls.Add(Me.chkCurso)
        Me.pnlFiltro.Controls.Add(Me.cboTurno)
        Me.pnlFiltro.Controls.Add(Me.cboGrado)
        Me.pnlFiltro.Controls.Add(Me.cboCurso)
        Me.pnlFiltro.Controls.Add(Me.cboGrupo)
        Me.pnlFiltro.Controls.Add(Me.lblGrupo)
        Me.pnlFiltro.Controls.Add(Me.lblFiltrado)
        Me.pnlFiltro.Location = New System.Drawing.Point(-5, -1)
        Me.pnlFiltro.Name = "pnlFiltro"
        Me.pnlFiltro.Size = New System.Drawing.Size(970, 175)
        Me.pnlFiltro.TabIndex = 1
        '
        'btnAdministrar
        '
        Me.btnAdministrar.BackColor = System.Drawing.Color.Silver
        Me.btnAdministrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdministrar.Font = New System.Drawing.Font("Corbel", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdministrar.Location = New System.Drawing.Point(17, 104)
        Me.btnAdministrar.Name = "btnAdministrar"
        Me.btnAdministrar.Size = New System.Drawing.Size(176, 28)
        Me.btnAdministrar.TabIndex = 5
        Me.btnAdministrar.Text = "Administrar"
        Me.btnAdministrar.UseVisualStyleBackColor = False
        Me.btnAdministrar.Visible = False
        '
        'chkTurno
        '
        Me.chkTurno.AutoSize = True
        Me.chkTurno.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkTurno.Font = New System.Drawing.Font("Candara", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTurno.ForeColor = System.Drawing.Color.PaleGreen
        Me.chkTurno.Location = New System.Drawing.Point(502, 130)
        Me.chkTurno.Name = "chkTurno"
        Me.chkTurno.Size = New System.Drawing.Size(76, 27)
        Me.chkTurno.TabIndex = 1
        Me.chkTurno.Text = "Turno"
        Me.chkTurno.UseVisualStyleBackColor = True
        '
        'chkGrado
        '
        Me.chkGrado.AutoSize = True
        Me.chkGrado.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkGrado.Font = New System.Drawing.Font("Candara", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkGrado.ForeColor = System.Drawing.Color.PaleGreen
        Me.chkGrado.Location = New System.Drawing.Point(502, 92)
        Me.chkGrado.Name = "chkGrado"
        Me.chkGrado.Size = New System.Drawing.Size(78, 27)
        Me.chkGrado.TabIndex = 1
        Me.chkGrado.Text = "Grado"
        Me.chkGrado.UseVisualStyleBackColor = True
        '
        'chkCurso
        '
        Me.chkCurso.AutoSize = True
        Me.chkCurso.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkCurso.Font = New System.Drawing.Font("Candara", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCurso.ForeColor = System.Drawing.Color.PaleGreen
        Me.chkCurso.Location = New System.Drawing.Point(502, 54)
        Me.chkCurso.Name = "chkCurso"
        Me.chkCurso.Size = New System.Drawing.Size(138, 27)
        Me.chkCurso.TabIndex = 1
        Me.chkCurso.Text = "Tipo de curso"
        Me.chkCurso.UseVisualStyleBackColor = True
        '
        'cboTurno
        '
        Me.cboTurno.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTurno.Enabled = False
        Me.cboTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTurno.FormattingEnabled = True
        Me.cboTurno.Items.AddRange(New Object() {"Matutino", "Vespertino", "Intermedio", "Nocturno"})
        Me.cboTurno.Location = New System.Drawing.Point(656, 130)
        Me.cboTurno.Name = "cboTurno"
        Me.cboTurno.Size = New System.Drawing.Size(161, 26)
        Me.cboTurno.TabIndex = 0
        '
        'cboGrado
        '
        Me.cboGrado.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrado.Enabled = False
        Me.cboGrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrado.FormattingEnabled = True
        Me.cboGrado.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboGrado.Location = New System.Drawing.Point(656, 92)
        Me.cboGrado.Name = "cboGrado"
        Me.cboGrado.Size = New System.Drawing.Size(161, 26)
        Me.cboGrado.TabIndex = 0
        '
        'cboCurso
        '
        Me.cboCurso.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCurso.Enabled = False
        Me.cboCurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCurso.FormattingEnabled = True
        Me.cboCurso.Items.AddRange(New Object() {"Ciclo Básico", "Bachillerato", "Rumbo"})
        Me.cboCurso.Location = New System.Drawing.Point(656, 54)
        Me.cboCurso.Name = "cboCurso"
        Me.cboCurso.Size = New System.Drawing.Size(161, 26)
        Me.cboCurso.TabIndex = 0
        '
        'cboGrupo
        '
        Me.cboGrupo.CausesValidation = False
        Me.cboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Items.AddRange(New Object() {"1ero BG", "1ero BH", "1ero XD", "2do BG", "3ero BG"})
        Me.cboGrupo.Location = New System.Drawing.Point(228, 85)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(168, 28)
        Me.cboGrupo.TabIndex = 0
        '
        'lblGrupo
        '
        Me.lblGrupo.Font = New System.Drawing.Font("Candara", 23.75!, System.Drawing.FontStyle.Bold)
        Me.lblGrupo.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblGrupo.Location = New System.Drawing.Point(228, 43)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(168, 39)
        Me.lblGrupo.TabIndex = 1
        Me.lblGrupo.Text = "➤ Grupo"
        Me.lblGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFiltrado
        '
        Me.lblFiltrado.AutoSize = True
        Me.lblFiltrado.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFiltrado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblFiltrado.Location = New System.Drawing.Point(459, 14)
        Me.lblFiltrado.Name = "lblFiltrado"
        Me.lblFiltrado.Size = New System.Drawing.Size(196, 29)
        Me.lblFiltrado.TabIndex = 1
        Me.lblFiltrado.Text = "Filtrar grupos por:"
        '
        'pnlSeparador
        '
        Me.pnlSeparador.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.pnlSeparador.Location = New System.Drawing.Point(963, 0)
        Me.pnlSeparador.Name = "pnlSeparador"
        Me.pnlSeparador.Size = New System.Drawing.Size(2, 175)
        Me.pnlSeparador.TabIndex = 13
        '
        'lblSeleccioneGrupo
        '
        Me.lblSeleccioneGrupo.Font = New System.Drawing.Font("Corbel", 36.0!, System.Drawing.FontStyle.Bold)
        Me.lblSeleccioneGrupo.ForeColor = System.Drawing.Color.White
        Me.lblSeleccioneGrupo.Location = New System.Drawing.Point(-5, 177)
        Me.lblSeleccioneGrupo.Name = "lblSeleccioneGrupo"
        Me.lblSeleccioneGrupo.Size = New System.Drawing.Size(970, 508)
        Me.lblSeleccioneGrupo.TabIndex = 20
        Me.lblSeleccioneGrupo.Text = "Para visualizar los horarios," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "debe escoger un grupo"
        Me.lblSeleccioneGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'timerAnimacion
        '
        Me.timerAnimacion.Interval = 500
        '
        'imgLogo
        '
        Me.imgLogo.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.imgLogo.BackgroundImage = Global.Minerva.My.Resources.Resources.logoMinerva
        Me.imgLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.imgLogo.Location = New System.Drawing.Point(54, -1)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(103, 133)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgLogo.TabIndex = 2
        Me.imgLogo.TabStop = False
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.Silver
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Corbel", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(17, 138)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(176, 28)
        Me.btnSalir.TabIndex = 6
        Me.btnSalir.Text = "Cerrar sesión"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'Sábado
        '
        Me.Sábado.BackColor = System.Drawing.Color.Transparent
        Me.Sábado.Location = New System.Drawing.Point(667, 462)
        Me.Sábado.Name = "Sábado"
        Me.Sábado.Size = New System.Drawing.Size(256, 210)
        Me.Sábado.TabIndex = 32
        '
        'Viernes
        '
        Me.Viernes.BackColor = System.Drawing.Color.Transparent
        Me.Viernes.Location = New System.Drawing.Point(365, 462)
        Me.Viernes.Name = "Viernes"
        Me.Viernes.Size = New System.Drawing.Size(256, 210)
        Me.Viernes.TabIndex = 31
        '
        'Jueves
        '
        Me.Jueves.BackColor = System.Drawing.Color.Transparent
        Me.Jueves.Location = New System.Drawing.Point(63, 462)
        Me.Jueves.Name = "Jueves"
        Me.Jueves.Size = New System.Drawing.Size(256, 210)
        Me.Jueves.TabIndex = 30
        '
        'Miércoles
        '
        Me.Miércoles.BackColor = System.Drawing.Color.Transparent
        Me.Miércoles.Location = New System.Drawing.Point(667, 243)
        Me.Miércoles.Name = "Miércoles"
        Me.Miércoles.Size = New System.Drawing.Size(256, 210)
        Me.Miércoles.TabIndex = 29
        '
        'Martes
        '
        Me.Martes.BackColor = System.Drawing.Color.Transparent
        Me.Martes.Location = New System.Drawing.Point(365, 243)
        Me.Martes.Name = "Martes"
        Me.Martes.Size = New System.Drawing.Size(256, 210)
        Me.Martes.TabIndex = 28
        '
        'Lunes
        '
        Me.Lunes.BackColor = System.Drawing.Color.Transparent
        Me.Lunes.Location = New System.Drawing.Point(63, 243)
        Me.Lunes.Name = "Lunes"
        Me.Lunes.Size = New System.Drawing.Size(256, 210)
        Me.Lunes.TabIndex = 27
        '
        'frmMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1264, 681)
        Me.Controls.Add(Me.lblSeleccioneGrupo)
        Me.Controls.Add(Me.Sábado)
        Me.Controls.Add(Me.Viernes)
        Me.Controls.Add(Me.Jueves)
        Me.Controls.Add(Me.Miércoles)
        Me.Controls.Add(Me.Martes)
        Me.Controls.Add(Me.Lunes)
        Me.Controls.Add(lblHorariosSemana)
        Me.Controls.Add(Me.pnlSeparador)
        Me.Controls.Add(Me.pnlFiltro)
        Me.Controls.Add(Me.pnlInfoCurso)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Minerva"
        Me.pnlInfoCurso.ResumeLayout(False)
        Me.pnlInfoCurso.PerformLayout()
        Me.pnlMaterias.ResumeLayout(False)
        Me.pnlMaterias.PerformLayout()
        Me.pnlFiltro.ResumeLayout(False)
        Me.pnlFiltro.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlInfoCurso As System.Windows.Forms.Panel
    Friend WithEvents lblNomMateria As System.Windows.Forms.Label
    Friend WithEvents lblProfesores As System.Windows.Forms.Label
    Friend WithEvents lblInfoCurso As System.Windows.Forms.Label
    Friend WithEvents lblValorAdscripto As System.Windows.Forms.Label
    Friend WithEvents lblCantAlumnos As System.Windows.Forms.Label
    Friend WithEvents lblTurno As System.Windows.Forms.Label
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents lblValorSalon As System.Windows.Forms.Label
    Friend WithEvents lblValorCantAlumnos As System.Windows.Forms.Label
    Friend WithEvents lblValorTurno As System.Windows.Forms.Label
    Friend WithEvents lblSalon As System.Windows.Forms.Label
    Friend WithEvents pnlFiltro As System.Windows.Forms.Panel
    Friend WithEvents lblValorGrado As System.Windows.Forms.Label
    Friend WithEvents lblValorTipo As System.Windows.Forms.Label
    Friend WithEvents lblAdscripto As System.Windows.Forms.Label
    Friend WithEvents lblGrado As System.Windows.Forms.Label
    Friend WithEvents lblNomGrupo As System.Windows.Forms.Label
    Friend WithEvents lblNomProfesor As System.Windows.Forms.Label
    Friend WithEvents cboCurso As System.Windows.Forms.ComboBox
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents chkTurno As System.Windows.Forms.CheckBox
    Friend WithEvents chkGrado As System.Windows.Forms.CheckBox
    Friend WithEvents chkCurso As System.Windows.Forms.CheckBox
    Friend WithEvents cboGrado As System.Windows.Forms.ComboBox
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents cboTurno As System.Windows.Forms.ComboBox
    Friend WithEvents lblGrupo As System.Windows.Forms.Label
    Friend WithEvents lblFiltrado As System.Windows.Forms.Label
    Friend WithEvents pnlMaterias As System.Windows.Forms.Panel
    Friend WithEvents pnlSeparador As System.Windows.Forms.Panel
    Friend WithEvents lblSeleccioneGrupo As System.Windows.Forms.Label
    Friend WithEvents lblSeleccioneGrupo2 As System.Windows.Forms.Label
    Friend WithEvents timerAnimacion As System.Windows.Forms.Timer
    Friend WithEvents Lunes As Minerva.frmDia
    Friend WithEvents Martes As Minerva.frmDia
    Friend WithEvents Miércoles As Minerva.frmDia
    Friend WithEvents Jueves As Minerva.frmDia
    Friend WithEvents Viernes As Minerva.frmDia
    Friend WithEvents Sábado As Minerva.frmDia
    Friend WithEvents btnAdministrar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button

End Class