<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.lblValorTipoGrado = New System.Windows.Forms.Label()
        Me.pnlMaterias = New System.Windows.Forms.Panel()
        Me.lblNomProfesor = New System.Windows.Forms.Label()
        Me.lblNomMateria = New System.Windows.Forms.Label()
        Me.lblValorTipoSalon = New System.Windows.Forms.Label()
        Me.lblValorTipoTurno = New System.Windows.Forms.Label()
        Me.lblValorTipoCurso = New System.Windows.Forms.Label()
        Me.lblSalon = New System.Windows.Forms.Label()
        Me.lblTurno = New System.Windows.Forms.Label()
        Me.lblGrado = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.lblProfesores = New System.Windows.Forms.Label()
        Me.lblNomGrupo = New System.Windows.Forms.Label()
        Me.lblSeleccioneGrupo2 = New System.Windows.Forms.Label()
        Me.pnlFiltro = New System.Windows.Forms.Panel()
        Me.btnRecargar = New System.Windows.Forms.PictureBox()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.imgLogoMAITs = New System.Windows.Forms.PictureBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnAdministrar = New System.Windows.Forms.Button()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.pnlSeparador = New System.Windows.Forms.Panel()
        Me.lblSeleccioneGrupo = New System.Windows.Forms.Label()
        Me.timerDatosUsuario = New System.Windows.Forms.Timer(Me.components)
        Me.btnRefrescarHorarios = New System.Windows.Forms.PictureBox()
        Me.timerbtnrefrescar = New System.Windows.Forms.Timer(Me.components)
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
        CType(Me.btnRecargar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogoMAITs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRefrescarHorarios, System.ComponentModel.ISupportInitialize).BeginInit()
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
        lblHorariosSemana.TabIndex = 9
        lblHorariosSemana.Text = "Horarios de la semana"
        '
        'pnlInfoCurso
        '
        Me.pnlInfoCurso.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pnlInfoCurso.Controls.Add(Me.lblInfoCurso)
        Me.pnlInfoCurso.Controls.Add(Me.lblValorTipoGrado)
        Me.pnlInfoCurso.Controls.Add(Me.pnlMaterias)
        Me.pnlInfoCurso.Controls.Add(Me.lblValorTipoSalon)
        Me.pnlInfoCurso.Controls.Add(Me.lblValorTipoTurno)
        Me.pnlInfoCurso.Controls.Add(Me.lblValorTipoCurso)
        Me.pnlInfoCurso.Controls.Add(Me.lblSalon)
        Me.pnlInfoCurso.Controls.Add(Me.lblTurno)
        Me.pnlInfoCurso.Controls.Add(Me.lblGrado)
        Me.pnlInfoCurso.Controls.Add(Me.lblTipo)
        Me.pnlInfoCurso.Controls.Add(Me.lblProfesores)
        Me.pnlInfoCurso.Controls.Add(Me.lblNomGrupo)
        Me.pnlInfoCurso.Controls.Add(Me.lblSeleccioneGrupo2)
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
        Me.lblInfoCurso.TabIndex = 0
        Me.lblInfoCurso.Text = "Información del grupo"
        Me.lblInfoCurso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblValorTipoGrado
        '
        Me.lblValorTipoGrado.AutoSize = True
        Me.lblValorTipoGrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorTipoGrado.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblValorTipoGrado.Location = New System.Drawing.Point(85, 397)
        Me.lblValorTipoGrado.Name = "lblValorTipoGrado"
        Me.lblValorTipoGrado.Size = New System.Drawing.Size(104, 20)
        Me.lblValorTipoGrado.TabIndex = 7
        Me.lblValorTipoGrado.Text = "No disponible"
        '
        'pnlMaterias
        '
        Me.pnlMaterias.AutoScroll = True
        Me.pnlMaterias.Controls.Add(Me.lblNomProfesor)
        Me.pnlMaterias.Controls.Add(Me.lblNomMateria)
        Me.pnlMaterias.Location = New System.Drawing.Point(2, 178)
        Me.pnlMaterias.Name = "pnlMaterias"
        Me.pnlMaterias.Size = New System.Drawing.Size(297, 172)
        Me.pnlMaterias.TabIndex = 4
        '
        'lblNomProfesor
        '
        Me.lblNomProfesor.AutoSize = True
        Me.lblNomProfesor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lblNomProfesor.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblNomProfesor.Location = New System.Drawing.Point(178, -18)
        Me.lblNomProfesor.Name = "lblNomProfesor"
        Me.lblNomProfesor.Size = New System.Drawing.Size(0, 20)
        Me.lblNomProfesor.TabIndex = 1
        '
        'lblNomMateria
        '
        Me.lblNomMateria.AutoSize = True
        Me.lblNomMateria.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lblNomMateria.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNomMateria.Location = New System.Drawing.Point(5, -18)
        Me.lblNomMateria.Name = "lblNomMateria"
        Me.lblNomMateria.Size = New System.Drawing.Size(96, 20)
        Me.lblNomMateria.TabIndex = 0
        Me.lblNomMateria.Text = "Matemática:"
        '
        'lblValorTipoSalon
        '
        Me.lblValorTipoSalon.AutoSize = True
        Me.lblValorTipoSalon.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorTipoSalon.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblValorTipoSalon.Location = New System.Drawing.Point(159, 455)
        Me.lblValorTipoSalon.Name = "lblValorTipoSalon"
        Me.lblValorTipoSalon.Size = New System.Drawing.Size(88, 20)
        Me.lblValorTipoSalon.TabIndex = 11
        Me.lblValorTipoSalon.Text = "Sin asignar"
        '
        'lblValorTipoTurno
        '
        Me.lblValorTipoTurno.AutoSize = True
        Me.lblValorTipoTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorTipoTurno.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblValorTipoTurno.Location = New System.Drawing.Point(85, 426)
        Me.lblValorTipoTurno.Name = "lblValorTipoTurno"
        Me.lblValorTipoTurno.Size = New System.Drawing.Size(104, 20)
        Me.lblValorTipoTurno.TabIndex = 6
        Me.lblValorTipoTurno.Text = "No disponible"
        '
        'lblValorTipoCurso
        '
        Me.lblValorTipoCurso.AutoSize = True
        Me.lblValorTipoCurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorTipoCurso.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblValorTipoCurso.Location = New System.Drawing.Point(85, 368)
        Me.lblValorTipoCurso.Name = "lblValorTipoCurso"
        Me.lblValorTipoCurso.Size = New System.Drawing.Size(104, 20)
        Me.lblValorTipoCurso.TabIndex = 6
        Me.lblValorTipoCurso.Text = "No disponible"
        '
        'lblSalon
        '
        Me.lblSalon.AutoSize = True
        Me.lblSalon.Font = New System.Drawing.Font("Candara", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalon.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblSalon.Location = New System.Drawing.Point(17, 454)
        Me.lblSalon.Name = "lblSalon"
        Me.lblSalon.Size = New System.Drawing.Size(136, 23)
        Me.lblSalon.TabIndex = 10
        Me.lblSalon.Text = "Salón asignado:"
        '
        'lblTurno
        '
        Me.lblTurno.AutoSize = True
        Me.lblTurno.Font = New System.Drawing.Font("Candara", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurno.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblTurno.Location = New System.Drawing.Point(17, 425)
        Me.lblTurno.Name = "lblTurno"
        Me.lblTurno.Size = New System.Drawing.Size(62, 23)
        Me.lblTurno.TabIndex = 9
        Me.lblTurno.Text = "Turno:"
        '
        'lblGrado
        '
        Me.lblGrado.AutoSize = True
        Me.lblGrado.Font = New System.Drawing.Font("Candara", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrado.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblGrado.Location = New System.Drawing.Point(17, 396)
        Me.lblGrado.Name = "lblGrado"
        Me.lblGrado.Size = New System.Drawing.Size(64, 23)
        Me.lblGrado.TabIndex = 8
        Me.lblGrado.Text = "Grado:"
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Candara", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblTipo.Location = New System.Drawing.Point(17, 367)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(62, 23)
        Me.lblTipo.TabIndex = 5
        Me.lblTipo.Text = "Curso:"
        '
        'lblProfesores
        '
        Me.lblProfesores.AutoSize = True
        Me.lblProfesores.Font = New System.Drawing.Font("Candara", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProfesores.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblProfesores.Location = New System.Drawing.Point(17, 143)
        Me.lblProfesores.Name = "lblProfesores"
        Me.lblProfesores.Size = New System.Drawing.Size(188, 23)
        Me.lblProfesores.TabIndex = 3
        Me.lblProfesores.Text = "Materias y profesores"
        '
        'lblNomGrupo
        '
        Me.lblNomGrupo.Font = New System.Drawing.Font("Verdana", 30.25!, System.Drawing.FontStyle.Bold)
        Me.lblNomGrupo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblNomGrupo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblNomGrupo.Location = New System.Drawing.Point(0, 52)
        Me.lblNomGrupo.Name = "lblNomGrupo"
        Me.lblNomGrupo.Size = New System.Drawing.Size(300, 76)
        Me.lblNomGrupo.TabIndex = 1
        Me.lblNomGrupo.Text = "X XX"
        Me.lblNomGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSeleccioneGrupo2
        '
        Me.lblSeleccioneGrupo2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.lblSeleccioneGrupo2.Font = New System.Drawing.Font("Corbel", 28.0!, System.Drawing.FontStyle.Bold)
        Me.lblSeleccioneGrupo2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblSeleccioneGrupo2.Location = New System.Drawing.Point(-2, 52)
        Me.lblSeleccioneGrupo2.Name = "lblSeleccioneGrupo2"
        Me.lblSeleccioneGrupo2.Size = New System.Drawing.Size(302, 670)
        Me.lblSeleccioneGrupo2.TabIndex = 12
        Me.lblSeleccioneGrupo2.Text = "No disponible" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblSeleccioneGrupo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlFiltro
        '
        Me.pnlFiltro.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pnlFiltro.Controls.Add(Me.btnRecargar)
        Me.pnlFiltro.Controls.Add(Me.lblUsuario)
        Me.pnlFiltro.Controls.Add(Me.imgLogoMAITs)
        Me.pnlFiltro.Controls.Add(Me.btnSalir)
        Me.pnlFiltro.Controls.Add(Me.btnAdministrar)
        Me.pnlFiltro.Controls.Add(Me.imgLogo)
        Me.pnlFiltro.Controls.Add(Me.cboGrupo)
        Me.pnlFiltro.Controls.Add(Me.lblGrupo)
        Me.pnlFiltro.Location = New System.Drawing.Point(-5, -1)
        Me.pnlFiltro.Name = "pnlFiltro"
        Me.pnlFiltro.Size = New System.Drawing.Size(970, 175)
        Me.pnlFiltro.TabIndex = 0
        '
        'btnRecargar
        '
        Me.btnRecargar.BackgroundImage = Global.Minerva.My.Resources.Resources.refrescar_normal
        Me.btnRecargar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRecargar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRecargar.Location = New System.Drawing.Point(643, 53)
        Me.btnRecargar.Name = "btnRecargar"
        Me.btnRecargar.Size = New System.Drawing.Size(25, 25)
        Me.btnRecargar.TabIndex = 129
        Me.btnRecargar.TabStop = False
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Corbel", 15.0!)
        Me.lblUsuario.ForeColor = System.Drawing.Color.White
        Me.lblUsuario.Location = New System.Drawing.Point(199, 138)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(183, 24)
        Me.lblUsuario.TabIndex = 0
        Me.lblUsuario.Text = "Bienvenido invitado."
        '
        'imgLogoMAITs
        '
        Me.imgLogoMAITs.BackgroundImage = Global.Minerva.My.Resources.Resources.logoMAITS
        Me.imgLogoMAITs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.imgLogoMAITs.Location = New System.Drawing.Point(817, 35)
        Me.imgLogoMAITs.Name = "imgLogoMAITs"
        Me.imgLogoMAITs.Size = New System.Drawing.Size(145, 97)
        Me.imgLogoMAITs.TabIndex = 127
        Me.imgLogoMAITs.TabStop = False
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.Silver
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Corbel", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(17, 138)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(176, 28)
        Me.btnSalir.TabIndex = 1
        Me.btnSalir.Text = "Cerrar sesión"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnAdministrar
        '
        Me.btnAdministrar.BackColor = System.Drawing.Color.Silver
        Me.btnAdministrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdministrar.Font = New System.Drawing.Font("Corbel", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdministrar.Location = New System.Drawing.Point(17, 104)
        Me.btnAdministrar.Name = "btnAdministrar"
        Me.btnAdministrar.Size = New System.Drawing.Size(176, 28)
        Me.btnAdministrar.TabIndex = 0
        Me.btnAdministrar.Text = "Administrar"
        Me.btnAdministrar.UseVisualStyleBackColor = False
        Me.btnAdministrar.Visible = False
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
        'cboGrupo
        '
        Me.cboGrupo.CausesValidation = False
        Me.cboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Items.AddRange(New Object() {"Elija un grupo"})
        Me.cboGrupo.Location = New System.Drawing.Point(351, 88)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(317, 28)
        Me.cboGrupo.TabIndex = 2
        '
        'lblGrupo
        '
        Me.lblGrupo.Font = New System.Drawing.Font("Candara", 23.75!, System.Drawing.FontStyle.Bold)
        Me.lblGrupo.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblGrupo.Location = New System.Drawing.Point(351, 46)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(317, 39)
        Me.lblGrupo.TabIndex = 3
        Me.lblGrupo.Text = "Grupo"
        Me.lblGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlSeparador
        '
        Me.pnlSeparador.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.pnlSeparador.Location = New System.Drawing.Point(963, 0)
        Me.pnlSeparador.Name = "pnlSeparador"
        Me.pnlSeparador.Size = New System.Drawing.Size(2, 175)
        Me.pnlSeparador.TabIndex = 2
        '
        'lblSeleccioneGrupo
        '
        Me.lblSeleccioneGrupo.Font = New System.Drawing.Font("Corbel", 36.0!, System.Drawing.FontStyle.Bold)
        Me.lblSeleccioneGrupo.ForeColor = System.Drawing.Color.White
        Me.lblSeleccioneGrupo.Location = New System.Drawing.Point(-5, 177)
        Me.lblSeleccioneGrupo.Name = "lblSeleccioneGrupo"
        Me.lblSeleccioneGrupo.Size = New System.Drawing.Size(970, 508)
        Me.lblSeleccioneGrupo.TabIndex = 10
        Me.lblSeleccioneGrupo.Text = "Para visualizar los horarios," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "debe escoger un grupo"
        Me.lblSeleccioneGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'timerDatosUsuario
        '
        Me.timerDatosUsuario.Interval = 300
        '
        'btnRefrescarHorarios
        '
        Me.btnRefrescarHorarios.BackgroundImage = Global.Minerva.My.Resources.Resources.refrescar_normal
        Me.btnRefrescarHorarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRefrescarHorarios.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefrescarHorarios.Location = New System.Drawing.Point(898, 194)
        Me.btnRefrescarHorarios.Name = "btnRefrescarHorarios"
        Me.btnRefrescarHorarios.Size = New System.Drawing.Size(25, 25)
        Me.btnRefrescarHorarios.TabIndex = 130
        Me.btnRefrescarHorarios.TabStop = False
        '
        'timerbtnrefrescar
        '
        Me.timerbtnrefrescar.Interval = 1000
        '
        'Sábado
        '
        Me.Sábado.BackColor = System.Drawing.Color.Transparent
        Me.Sábado.Location = New System.Drawing.Point(667, 462)
        Me.Sábado.Name = "Sábado"
        Me.Sábado.Size = New System.Drawing.Size(256, 210)
        Me.Sábado.TabIndex = 8
        Me.Sábado.TabStop = False
        '
        'Viernes
        '
        Me.Viernes.BackColor = System.Drawing.Color.Transparent
        Me.Viernes.Location = New System.Drawing.Point(365, 462)
        Me.Viernes.Name = "Viernes"
        Me.Viernes.Size = New System.Drawing.Size(256, 210)
        Me.Viernes.TabIndex = 7
        Me.Viernes.TabStop = False
        '
        'Jueves
        '
        Me.Jueves.BackColor = System.Drawing.Color.Transparent
        Me.Jueves.Location = New System.Drawing.Point(63, 462)
        Me.Jueves.Name = "Jueves"
        Me.Jueves.Size = New System.Drawing.Size(256, 210)
        Me.Jueves.TabIndex = 6
        Me.Jueves.TabStop = False
        '
        'Miércoles
        '
        Me.Miércoles.BackColor = System.Drawing.Color.Transparent
        Me.Miércoles.Location = New System.Drawing.Point(667, 243)
        Me.Miércoles.Name = "Miércoles"
        Me.Miércoles.Size = New System.Drawing.Size(256, 210)
        Me.Miércoles.TabIndex = 3
        Me.Miércoles.TabStop = False
        '
        'Martes
        '
        Me.Martes.BackColor = System.Drawing.Color.Transparent
        Me.Martes.Location = New System.Drawing.Point(365, 243)
        Me.Martes.Name = "Martes"
        Me.Martes.Size = New System.Drawing.Size(256, 210)
        Me.Martes.TabIndex = 4
        Me.Martes.TabStop = False
        '
        'Lunes
        '
        Me.Lunes.BackColor = System.Drawing.Color.Transparent
        Me.Lunes.Location = New System.Drawing.Point(63, 243)
        Me.Lunes.Name = "Lunes"
        Me.Lunes.Size = New System.Drawing.Size(256, 210)
        Me.Lunes.TabIndex = 5
        Me.Lunes.TabStop = False
        '
        'frmMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1264, 681)
        Me.Controls.Add(Me.btnRefrescarHorarios)
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
        Me.Controls.Add(Me.lblSeleccioneGrupo)
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
        CType(Me.btnRecargar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogoMAITs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRefrescarHorarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlInfoCurso As System.Windows.Forms.Panel
    Friend WithEvents lblNomMateria As System.Windows.Forms.Label
    Friend WithEvents lblProfesores As System.Windows.Forms.Label
    Friend WithEvents lblInfoCurso As System.Windows.Forms.Label
    Friend WithEvents lblTurno As System.Windows.Forms.Label
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents lblValorTipoSalon As System.Windows.Forms.Label
    Friend WithEvents lblValorTipoTurno As System.Windows.Forms.Label
    Friend WithEvents lblSalon As System.Windows.Forms.Label
    Friend WithEvents pnlFiltro As System.Windows.Forms.Panel
    Friend WithEvents lblValorTipoCurso As System.Windows.Forms.Label
    Friend WithEvents lblGrado As System.Windows.Forms.Label
    Friend WithEvents lblNomGrupo As System.Windows.Forms.Label
    Friend WithEvents lblNomProfesor As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents lblGrupo As System.Windows.Forms.Label
    Friend WithEvents pnlMaterias As System.Windows.Forms.Panel
    Friend WithEvents pnlSeparador As System.Windows.Forms.Panel
    Friend WithEvents lblSeleccioneGrupo As System.Windows.Forms.Label
    Friend WithEvents lblSeleccioneGrupo2 As System.Windows.Forms.Label
    Friend WithEvents Lunes As Minerva.frmDia
    Friend WithEvents Martes As Minerva.frmDia
    Friend WithEvents Miércoles As Minerva.frmDia
    Friend WithEvents Jueves As Minerva.frmDia
    Friend WithEvents Viernes As Minerva.frmDia
    Friend WithEvents Sábado As Minerva.frmDia
    Friend WithEvents btnAdministrar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents imgLogoMAITs As System.Windows.Forms.PictureBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents timerDatosUsuario As System.Windows.Forms.Timer
    Friend WithEvents lblValorTipoGrado As System.Windows.Forms.Label
    Friend WithEvents btnRecargar As System.Windows.Forms.PictureBox
    Friend WithEvents btnRefrescarHorarios As System.Windows.Forms.PictureBox
    Friend WithEvents timerbtnrefrescar As System.Windows.Forms.Timer

End Class
