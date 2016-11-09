<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim lblHorariosSemana As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.pnlInfoCurso = New System.Windows.Forms.Panel()
        Me.lblSeleccioneGrupo2 = New System.Windows.Forms.Label()
        Me.pnlDatosGrupo = New System.Windows.Forms.Panel()
        Me.lblValorTipoAdscripto = New System.Windows.Forms.Label()
        Me.lblAdscripto = New System.Windows.Forms.Label()
        Me.lblValorTipoGrado = New System.Windows.Forms.Label()
        Me.lblCurso = New System.Windows.Forms.Label()
        Me.lblGrado = New System.Windows.Forms.Label()
        Me.lblValorTipoSalon = New System.Windows.Forms.Label()
        Me.lblTurno = New System.Windows.Forms.Label()
        Me.lblValorTipoTurno = New System.Windows.Forms.Label()
        Me.lblSalon = New System.Windows.Forms.Label()
        Me.lblValorTipoCurso = New System.Windows.Forms.Label()
        Me.lblInfoCurso = New System.Windows.Forms.Label()
        Me.pnlMaterias = New System.Windows.Forms.Panel()
        Me.tblMaterias = New System.Windows.Forms.TableLayoutPanel()
        Me.lblProfesores = New System.Windows.Forms.Label()
        Me.lblNomGrupo = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.alertaAprobacion = New System.Windows.Forms.PictureBox()
        Me.imgLogoUsuario = New System.Windows.Forms.PictureBox()
        Me.imgLogoInvitado = New System.Windows.Forms.PictureBox()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.imgLogoMAITs = New System.Windows.Forms.PictureBox()
        Me.pnlSeparador = New System.Windows.Forms.Panel()
        Me.pnlBordeSeparador = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnAdministrar = New System.Windows.Forms.Button()
        Me.pnlFiltro = New System.Windows.Forms.Panel()
        Me.btnFiltrar = New System.Windows.Forms.PictureBox()
        Me.btnRecargar = New System.Windows.Forms.PictureBox()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.lblSeleccioneGrupo = New System.Windows.Forms.Label()
        Me.TimerBtnRefrescar = New System.Windows.Forms.Timer(Me.components)
        Me.pnlHorarios = New System.Windows.Forms.Panel()
        Me.tblDias = New System.Windows.Forms.TableLayoutPanel()
        Me.Lunes = New Minerva.frmDia()
        Me.Martes = New Minerva.frmDia()
        Me.Miércoles = New Minerva.frmDia()
        Me.Sábado = New Minerva.frmDia()
        Me.Jueves = New Minerva.frmDia()
        Me.Viernes = New Minerva.frmDia()
        Me.pnlBotonesHorarios = New System.Windows.Forms.Panel()
        Me.btnGuardarPdf = New System.Windows.Forms.PictureBox()
        Me.btnRefrescarHorarios = New System.Windows.Forms.PictureBox()
        Me.btnVistaDias = New System.Windows.Forms.PictureBox()
        Me.btnVistaSemana = New System.Windows.Forms.PictureBox()
        Me.btnFullscreen = New System.Windows.Forms.PictureBox()
        Me.Grilla = New Minerva.frmVistaGrilla()
        Me.cmsFiltrado = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.pnlAyudabtnVistaSemana = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlAyudabtnVistaDias = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlAyudabtnRefrescarHorarios = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlAyudabtnFullscreen = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlAyudabtnGuardarPdf = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlAyudabtnRecargar = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlAyudaalertaAprobacion = New System.Windows.Forms.Panel()
        Me.lblCantidadUsuariosAprobacion = New System.Windows.Forms.Label()
        Me.pnlAyudabtnFiltrar = New System.Windows.Forms.Panel()
        Me.lblFiltrado = New System.Windows.Forms.Label()
        lblHorariosSemana = New System.Windows.Forms.Label()
        Me.pnlInfoCurso.SuspendLayout()
        Me.pnlDatosGrupo.SuspendLayout()
        Me.pnlMaterias.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        CType(Me.alertaAprobacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogoUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogoInvitado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogoMAITs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFiltro.SuspendLayout()
        CType(Me.btnFiltrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRecargar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHorarios.SuspendLayout()
        Me.tblDias.SuspendLayout()
        Me.pnlBotonesHorarios.SuspendLayout()
        CType(Me.btnGuardarPdf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRefrescarHorarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnVistaDias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnVistaSemana, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnFullscreen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAyudabtnVistaSemana.SuspendLayout()
        Me.pnlAyudabtnVistaDias.SuspendLayout()
        Me.pnlAyudabtnRefrescarHorarios.SuspendLayout()
        Me.pnlAyudabtnFullscreen.SuspendLayout()
        Me.pnlAyudabtnGuardarPdf.SuspendLayout()
        Me.pnlAyudabtnRecargar.SuspendLayout()
        Me.pnlAyudaalertaAprobacion.SuspendLayout()
        Me.pnlAyudabtnFiltrar.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHorariosSemana
        '
        lblHorariosSemana.AutoSize = True
        lblHorariosSemana.Font = New System.Drawing.Font("Corbel", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblHorariosSemana.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        lblHorariosSemana.Location = New System.Drawing.Point(24, 1)
        lblHorariosSemana.Name = "lblHorariosSemana"
        lblHorariosSemana.Size = New System.Drawing.Size(486, 59)
        lblHorariosSemana.TabIndex = 9
        lblHorariosSemana.Text = "Horarios de la semana"
        '
        'pnlInfoCurso
        '
        Me.pnlInfoCurso.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pnlInfoCurso.Controls.Add(Me.lblSeleccioneGrupo2)
        Me.pnlInfoCurso.Controls.Add(Me.pnlDatosGrupo)
        Me.pnlInfoCurso.Controls.Add(Me.lblInfoCurso)
        Me.pnlInfoCurso.Controls.Add(Me.pnlMaterias)
        Me.pnlInfoCurso.Controls.Add(Me.lblProfesores)
        Me.pnlInfoCurso.Controls.Add(Me.lblNomGrupo)
        Me.pnlInfoCurso.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlInfoCurso.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.pnlInfoCurso.Location = New System.Drawing.Point(964, 0)
        Me.pnlInfoCurso.Name = "pnlInfoCurso"
        Me.pnlInfoCurso.Size = New System.Drawing.Size(300, 681)
        Me.pnlInfoCurso.TabIndex = 0
        '
        'lblSeleccioneGrupo2
        '
        Me.lblSeleccioneGrupo2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSeleccioneGrupo2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.lblSeleccioneGrupo2.Font = New System.Drawing.Font("Corbel", 28.0!, System.Drawing.FontStyle.Bold)
        Me.lblSeleccioneGrupo2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblSeleccioneGrupo2.Location = New System.Drawing.Point(-2, 52)
        Me.lblSeleccioneGrupo2.Name = "lblSeleccioneGrupo2"
        Me.lblSeleccioneGrupo2.Size = New System.Drawing.Size(300, 681)
        Me.lblSeleccioneGrupo2.TabIndex = 12
        Me.lblSeleccioneGrupo2.Text = "No disponible" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblSeleccioneGrupo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosGrupo
        '
        Me.pnlDatosGrupo.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pnlDatosGrupo.Controls.Add(Me.lblValorTipoAdscripto)
        Me.pnlDatosGrupo.Controls.Add(Me.lblAdscripto)
        Me.pnlDatosGrupo.Controls.Add(Me.lblValorTipoGrado)
        Me.pnlDatosGrupo.Controls.Add(Me.lblCurso)
        Me.pnlDatosGrupo.Controls.Add(Me.lblGrado)
        Me.pnlDatosGrupo.Controls.Add(Me.lblValorTipoSalon)
        Me.pnlDatosGrupo.Controls.Add(Me.lblTurno)
        Me.pnlDatosGrupo.Controls.Add(Me.lblValorTipoTurno)
        Me.pnlDatosGrupo.Controls.Add(Me.lblSalon)
        Me.pnlDatosGrupo.Controls.Add(Me.lblValorTipoCurso)
        Me.pnlDatosGrupo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDatosGrupo.Location = New System.Drawing.Point(0, 524)
        Me.pnlDatosGrupo.Name = "pnlDatosGrupo"
        Me.pnlDatosGrupo.Size = New System.Drawing.Size(300, 157)
        Me.pnlDatosGrupo.TabIndex = 13
        '
        'lblValorTipoAdscripto
        '
        Me.lblValorTipoAdscripto.AutoSize = True
        Me.lblValorTipoAdscripto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorTipoAdscripto.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblValorTipoAdscripto.Location = New System.Drawing.Point(151, 127)
        Me.lblValorTipoAdscripto.Name = "lblValorTipoAdscripto"
        Me.lblValorTipoAdscripto.Size = New System.Drawing.Size(79, 20)
        Me.lblValorTipoAdscripto.TabIndex = 13
        Me.lblValorTipoAdscripto.Text = "Sin definir"
        '
        'lblAdscripto
        '
        Me.lblAdscripto.AutoSize = True
        Me.lblAdscripto.Font = New System.Drawing.Font("Candara", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdscripto.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblAdscripto.Location = New System.Drawing.Point(24, 125)
        Me.lblAdscripto.Name = "lblAdscripto"
        Me.lblAdscripto.Size = New System.Drawing.Size(121, 23)
        Me.lblAdscripto.TabIndex = 12
        Me.lblAdscripto.Text = "Adscripto (a):"
        '
        'lblValorTipoGrado
        '
        Me.lblValorTipoGrado.AutoSize = True
        Me.lblValorTipoGrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorTipoGrado.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblValorTipoGrado.Location = New System.Drawing.Point(92, 40)
        Me.lblValorTipoGrado.Name = "lblValorTipoGrado"
        Me.lblValorTipoGrado.Size = New System.Drawing.Size(104, 20)
        Me.lblValorTipoGrado.TabIndex = 7
        Me.lblValorTipoGrado.Text = "No disponible"
        '
        'lblCurso
        '
        Me.lblCurso.AutoSize = True
        Me.lblCurso.Font = New System.Drawing.Font("Candara", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurso.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblCurso.Location = New System.Drawing.Point(24, 10)
        Me.lblCurso.Name = "lblCurso"
        Me.lblCurso.Size = New System.Drawing.Size(62, 23)
        Me.lblCurso.TabIndex = 5
        Me.lblCurso.Text = "Curso:"
        '
        'lblGrado
        '
        Me.lblGrado.AutoSize = True
        Me.lblGrado.Font = New System.Drawing.Font("Candara", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrado.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblGrado.Location = New System.Drawing.Point(24, 39)
        Me.lblGrado.Name = "lblGrado"
        Me.lblGrado.Size = New System.Drawing.Size(64, 23)
        Me.lblGrado.TabIndex = 8
        Me.lblGrado.Text = "Grado:"
        '
        'lblValorTipoSalon
        '
        Me.lblValorTipoSalon.AutoSize = True
        Me.lblValorTipoSalon.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorTipoSalon.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblValorTipoSalon.Location = New System.Drawing.Point(166, 98)
        Me.lblValorTipoSalon.Name = "lblValorTipoSalon"
        Me.lblValorTipoSalon.Size = New System.Drawing.Size(88, 20)
        Me.lblValorTipoSalon.TabIndex = 11
        Me.lblValorTipoSalon.Text = "Sin asignar"
        '
        'lblTurno
        '
        Me.lblTurno.AutoSize = True
        Me.lblTurno.Font = New System.Drawing.Font("Candara", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurno.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblTurno.Location = New System.Drawing.Point(24, 68)
        Me.lblTurno.Name = "lblTurno"
        Me.lblTurno.Size = New System.Drawing.Size(62, 23)
        Me.lblTurno.TabIndex = 9
        Me.lblTurno.Text = "Turno:"
        '
        'lblValorTipoTurno
        '
        Me.lblValorTipoTurno.AutoSize = True
        Me.lblValorTipoTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorTipoTurno.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblValorTipoTurno.Location = New System.Drawing.Point(92, 70)
        Me.lblValorTipoTurno.Name = "lblValorTipoTurno"
        Me.lblValorTipoTurno.Size = New System.Drawing.Size(104, 20)
        Me.lblValorTipoTurno.TabIndex = 6
        Me.lblValorTipoTurno.Text = "No disponible"
        '
        'lblSalon
        '
        Me.lblSalon.AutoSize = True
        Me.lblSalon.Font = New System.Drawing.Font("Candara", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalon.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblSalon.Location = New System.Drawing.Point(24, 97)
        Me.lblSalon.Name = "lblSalon"
        Me.lblSalon.Size = New System.Drawing.Size(136, 23)
        Me.lblSalon.TabIndex = 10
        Me.lblSalon.Text = "Salón asignado:"
        '
        'lblValorTipoCurso
        '
        Me.lblValorTipoCurso.AutoSize = True
        Me.lblValorTipoCurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorTipoCurso.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblValorTipoCurso.Location = New System.Drawing.Point(92, 11)
        Me.lblValorTipoCurso.Name = "lblValorTipoCurso"
        Me.lblValorTipoCurso.Size = New System.Drawing.Size(104, 20)
        Me.lblValorTipoCurso.TabIndex = 6
        Me.lblValorTipoCurso.Text = "No disponible"
        '
        'lblInfoCurso
        '
        Me.lblInfoCurso.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblInfoCurso.Font = New System.Drawing.Font("Corbel", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoCurso.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblInfoCurso.Location = New System.Drawing.Point(0, 0)
        Me.lblInfoCurso.Name = "lblInfoCurso"
        Me.lblInfoCurso.Size = New System.Drawing.Size(300, 40)
        Me.lblInfoCurso.TabIndex = 0
        Me.lblInfoCurso.Text = "Información del grupo"
        Me.lblInfoCurso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlMaterias
        '
        Me.pnlMaterias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMaterias.AutoScroll = True
        Me.pnlMaterias.Controls.Add(Me.tblMaterias)
        Me.pnlMaterias.Location = New System.Drawing.Point(2, 178)
        Me.pnlMaterias.Name = "pnlMaterias"
        Me.pnlMaterias.Size = New System.Drawing.Size(297, 340)
        Me.pnlMaterias.TabIndex = 4
        '
        'tblMaterias
        '
        Me.tblMaterias.AutoSize = True
        Me.tblMaterias.ColumnCount = 1
        Me.tblMaterias.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblMaterias.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblMaterias.Location = New System.Drawing.Point(0, 0)
        Me.tblMaterias.Name = "tblMaterias"
        Me.tblMaterias.RowCount = 1
        Me.tblMaterias.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.tblMaterias.Size = New System.Drawing.Size(297, 1)
        Me.tblMaterias.TabIndex = 0
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
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.alertaAprobacion)
        Me.pnlHeader.Controls.Add(Me.imgLogoUsuario)
        Me.pnlHeader.Controls.Add(Me.imgLogoInvitado)
        Me.pnlHeader.Controls.Add(Me.lblUsuario)
        Me.pnlHeader.Controls.Add(Me.imgLogoMAITs)
        Me.pnlHeader.Controls.Add(Me.pnlSeparador)
        Me.pnlHeader.Controls.Add(Me.pnlBordeSeparador)
        Me.pnlHeader.Controls.Add(Me.btnSalir)
        Me.pnlHeader.Controls.Add(Me.btnAdministrar)
        Me.pnlHeader.Controls.Add(Me.pnlFiltro)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(964, 185)
        Me.pnlHeader.TabIndex = 0
        '
        'alertaAprobacion
        '
        Me.alertaAprobacion.BackgroundImage = CType(resources.GetObject("alertaAprobacion.BackgroundImage"), System.Drawing.Image)
        Me.alertaAprobacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.alertaAprobacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.alertaAprobacion.Location = New System.Drawing.Point(143, 53)
        Me.alertaAprobacion.Name = "alertaAprobacion"
        Me.alertaAprobacion.Size = New System.Drawing.Size(50, 50)
        Me.alertaAprobacion.TabIndex = 130
        Me.alertaAprobacion.TabStop = False
        Me.alertaAprobacion.Visible = False
        '
        'imgLogoUsuario
        '
        Me.imgLogoUsuario.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.imgLogoUsuario.BackgroundImage = Global.Minerva.My.Resources.Resources.logoMinerva
        Me.imgLogoUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.imgLogoUsuario.Cursor = System.Windows.Forms.Cursors.Hand
        Me.imgLogoUsuario.Location = New System.Drawing.Point(66, 14)
        Me.imgLogoUsuario.Name = "imgLogoUsuario"
        Me.imgLogoUsuario.Size = New System.Drawing.Size(75, 89)
        Me.imgLogoUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgLogoUsuario.TabIndex = 130
        Me.imgLogoUsuario.TabStop = False
        Me.imgLogoUsuario.Visible = False
        '
        'imgLogoInvitado
        '
        Me.imgLogoInvitado.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.imgLogoInvitado.BackgroundImage = Global.Minerva.My.Resources.Resources.logoMinerva
        Me.imgLogoInvitado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.imgLogoInvitado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.imgLogoInvitado.Location = New System.Drawing.Point(54, 3)
        Me.imgLogoInvitado.Name = "imgLogoInvitado"
        Me.imgLogoInvitado.Size = New System.Drawing.Size(103, 125)
        Me.imgLogoInvitado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgLogoInvitado.TabIndex = 2
        Me.imgLogoInvitado.TabStop = False
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.BackColor = System.Drawing.Color.Transparent
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
        Me.imgLogoMAITs.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogoMAITs.Location = New System.Drawing.Point(813, 0)
        Me.imgLogoMAITs.Margin = New System.Windows.Forms.Padding(10)
        Me.imgLogoMAITs.Name = "imgLogoMAITs"
        Me.imgLogoMAITs.Padding = New System.Windows.Forms.Padding(10)
        Me.imgLogoMAITs.Size = New System.Drawing.Size(145, 185)
        Me.imgLogoMAITs.TabIndex = 127
        Me.imgLogoMAITs.TabStop = False
        '
        'pnlSeparador
        '
        Me.pnlSeparador.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSeparador.Location = New System.Drawing.Point(958, 0)
        Me.pnlSeparador.Name = "pnlSeparador"
        Me.pnlSeparador.Size = New System.Drawing.Size(4, 185)
        Me.pnlSeparador.TabIndex = 131
        '
        'pnlBordeSeparador
        '
        Me.pnlBordeSeparador.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.pnlBordeSeparador.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBordeSeparador.Location = New System.Drawing.Point(962, 0)
        Me.pnlBordeSeparador.Name = "pnlBordeSeparador"
        Me.pnlBordeSeparador.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlBordeSeparador.Size = New System.Drawing.Size(2, 185)
        Me.pnlBordeSeparador.TabIndex = 130
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
        'pnlFiltro
        '
        Me.pnlFiltro.AutoSize = True
        Me.pnlFiltro.Controls.Add(Me.btnFiltrar)
        Me.pnlFiltro.Controls.Add(Me.btnRecargar)
        Me.pnlFiltro.Controls.Add(Me.lblGrupo)
        Me.pnlFiltro.Controls.Add(Me.cboGrupo)
        Me.pnlFiltro.Cursor = System.Windows.Forms.Cursors.Default
        Me.pnlFiltro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFiltro.Location = New System.Drawing.Point(0, 0)
        Me.pnlFiltro.Name = "pnlFiltro"
        Me.pnlFiltro.Size = New System.Drawing.Size(964, 185)
        Me.pnlFiltro.TabIndex = 132
        '
        'btnFiltrar
        '
        Me.btnFiltrar.BackgroundImage = Global.Minerva.My.Resources.Resources.filtrar_normal
        Me.btnFiltrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFiltrar.Location = New System.Drawing.Point(324, 44)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(25, 25)
        Me.btnFiltrar.TabIndex = 130
        Me.btnFiltrar.TabStop = False
        '
        'btnRecargar
        '
        Me.btnRecargar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnRecargar.BackgroundImage = Global.Minerva.My.Resources.Resources.refrescar_normal
        Me.btnRecargar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRecargar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRecargar.Location = New System.Drawing.Point(761, 44)
        Me.btnRecargar.Name = "btnRecargar"
        Me.btnRecargar.Size = New System.Drawing.Size(25, 25)
        Me.btnRecargar.TabIndex = 129
        Me.btnRecargar.TabStop = False
        '
        'lblGrupo
        '
        Me.lblGrupo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGrupo.Font = New System.Drawing.Font("Candara", 23.75!, System.Drawing.FontStyle.Bold)
        Me.lblGrupo.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblGrupo.Location = New System.Drawing.Point(324, 37)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(462, 39)
        Me.lblGrupo.TabIndex = 3
        Me.lblGrupo.Text = "Grupo"
        Me.lblGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboGrupo
        '
        Me.cboGrupo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboGrupo.CausesValidation = False
        Me.cboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Items.AddRange(New Object() {"Elija un grupo"})
        Me.cboGrupo.Location = New System.Drawing.Point(324, 78)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(462, 28)
        Me.cboGrupo.TabIndex = 2
        '
        'lblSeleccioneGrupo
        '
        Me.lblSeleccioneGrupo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSeleccioneGrupo.Font = New System.Drawing.Font("Corbel", 36.0!, System.Drawing.FontStyle.Bold)
        Me.lblSeleccioneGrupo.ForeColor = System.Drawing.Color.White
        Me.lblSeleccioneGrupo.Location = New System.Drawing.Point(0, 0)
        Me.lblSeleccioneGrupo.Name = "lblSeleccioneGrupo"
        Me.lblSeleccioneGrupo.Size = New System.Drawing.Size(964, 494)
        Me.lblSeleccioneGrupo.TabIndex = 10
        Me.lblSeleccioneGrupo.Text = "Para visualizar los horarios," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "debe escoger un grupo"
        Me.lblSeleccioneGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimerBtnRefrescar
        '
        Me.TimerBtnRefrescar.Interval = 1000
        '
        'pnlHorarios
        '
        Me.pnlHorarios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlHorarios.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.pnlHorarios.Controls.Add(Me.lblSeleccioneGrupo)
        Me.pnlHorarios.Controls.Add(Me.tblDias)
        Me.pnlHorarios.Controls.Add(Me.pnlBotonesHorarios)
        Me.pnlHorarios.Controls.Add(lblHorariosSemana)
        Me.pnlHorarios.Controls.Add(Me.Grilla)
        Me.pnlHorarios.Location = New System.Drawing.Point(0, 185)
        Me.pnlHorarios.Name = "pnlHorarios"
        Me.pnlHorarios.Size = New System.Drawing.Size(964, 494)
        Me.pnlHorarios.TabIndex = 135
        '
        'tblDias
        '
        Me.tblDias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblDias.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.tblDias.ColumnCount = 5
        Me.tblDias.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25!))
        Me.tblDias.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.125!))
        Me.tblDias.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25!))
        Me.tblDias.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.125!))
        Me.tblDias.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25!))
        Me.tblDias.Controls.Add(Me.Lunes, 0, 0)
        Me.tblDias.Controls.Add(Me.Martes, 2, 0)
        Me.tblDias.Controls.Add(Me.Miércoles, 4, 0)
        Me.tblDias.Controls.Add(Me.Sábado, 4, 2)
        Me.tblDias.Controls.Add(Me.Jueves, 0, 2)
        Me.tblDias.Controls.Add(Me.Viernes, 2, 2)
        Me.tblDias.Location = New System.Drawing.Point(34, 66)
        Me.tblDias.Name = "tblDias"
        Me.tblDias.RowCount = 4
        Me.tblDias.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.875!))
        Me.tblDias.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.125!))
        Me.tblDias.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.875!))
        Me.tblDias.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.125!))
        Me.tblDias.Size = New System.Drawing.Size(924, 428)
        Me.tblDias.TabIndex = 136
        '
        'Lunes
        '
        Me.Lunes.AutoScroll = True
        Me.Lunes.AutoSize = True
        Me.Lunes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Lunes.BackColor = System.Drawing.Color.Transparent
        Me.Lunes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lunes.Location = New System.Drawing.Point(3, 3)
        Me.Lunes.Name = "Lunes"
        Me.Lunes.Size = New System.Drawing.Size(282, 194)
        Me.Lunes.TabIndex = 5
        Me.Lunes.TabStop = False
        '
        'Martes
        '
        Me.Martes.AutoSize = True
        Me.Martes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Martes.BackColor = System.Drawing.Color.Transparent
        Me.Martes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Martes.Location = New System.Drawing.Point(319, 3)
        Me.Martes.Name = "Martes"
        Me.Martes.Size = New System.Drawing.Size(282, 194)
        Me.Martes.TabIndex = 4
        Me.Martes.TabStop = False
        '
        'Miércoles
        '
        Me.Miércoles.AutoSize = True
        Me.Miércoles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Miércoles.BackColor = System.Drawing.Color.Transparent
        Me.Miércoles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Miércoles.Location = New System.Drawing.Point(635, 3)
        Me.Miércoles.Name = "Miércoles"
        Me.Miércoles.Size = New System.Drawing.Size(286, 194)
        Me.Miércoles.TabIndex = 3
        Me.Miércoles.TabStop = False
        '
        'Sábado
        '
        Me.Sábado.AutoSize = True
        Me.Sábado.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Sábado.BackColor = System.Drawing.Color.Transparent
        Me.Sábado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Sábado.Location = New System.Drawing.Point(635, 216)
        Me.Sábado.Name = "Sábado"
        Me.Sábado.Size = New System.Drawing.Size(286, 194)
        Me.Sábado.TabIndex = 8
        Me.Sábado.TabStop = False
        '
        'Jueves
        '
        Me.Jueves.AutoSize = True
        Me.Jueves.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Jueves.BackColor = System.Drawing.Color.Transparent
        Me.Jueves.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Jueves.Location = New System.Drawing.Point(3, 216)
        Me.Jueves.Name = "Jueves"
        Me.Jueves.Size = New System.Drawing.Size(282, 194)
        Me.Jueves.TabIndex = 6
        Me.Jueves.TabStop = False
        '
        'Viernes
        '
        Me.Viernes.AutoSize = True
        Me.Viernes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Viernes.BackColor = System.Drawing.Color.Transparent
        Me.Viernes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Viernes.Location = New System.Drawing.Point(319, 216)
        Me.Viernes.Name = "Viernes"
        Me.Viernes.Size = New System.Drawing.Size(282, 194)
        Me.Viernes.TabIndex = 7
        Me.Viernes.TabStop = False
        '
        'pnlBotonesHorarios
        '
        Me.pnlBotonesHorarios.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBotonesHorarios.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.pnlBotonesHorarios.Controls.Add(Me.btnGuardarPdf)
        Me.pnlBotonesHorarios.Controls.Add(Me.btnRefrescarHorarios)
        Me.pnlBotonesHorarios.Controls.Add(Me.btnVistaDias)
        Me.pnlBotonesHorarios.Controls.Add(Me.btnVistaSemana)
        Me.pnlBotonesHorarios.Controls.Add(Me.btnFullscreen)
        Me.pnlBotonesHorarios.Location = New System.Drawing.Point(693, 0)
        Me.pnlBotonesHorarios.Name = "pnlBotonesHorarios"
        Me.pnlBotonesHorarios.Size = New System.Drawing.Size(265, 59)
        Me.pnlBotonesHorarios.TabIndex = 135
        '
        'btnGuardarPdf
        '
        Me.btnGuardarPdf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardarPdf.BackgroundImage = Global.Minerva.My.Resources.Resources.guardar_como_pdf_normal
        Me.btnGuardarPdf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnGuardarPdf.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardarPdf.Location = New System.Drawing.Point(40, 8)
        Me.btnGuardarPdf.Name = "btnGuardarPdf"
        Me.btnGuardarPdf.Size = New System.Drawing.Size(53, 45)
        Me.btnGuardarPdf.TabIndex = 135
        Me.btnGuardarPdf.TabStop = False
        Me.btnGuardarPdf.Visible = False
        '
        'btnRefrescarHorarios
        '
        Me.btnRefrescarHorarios.BackgroundImage = Global.Minerva.My.Resources.Resources.refrescar_normal
        Me.btnRefrescarHorarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRefrescarHorarios.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefrescarHorarios.Location = New System.Drawing.Point(135, 18)
        Me.btnRefrescarHorarios.Name = "btnRefrescarHorarios"
        Me.btnRefrescarHorarios.Size = New System.Drawing.Size(25, 25)
        Me.btnRefrescarHorarios.TabIndex = 130
        Me.btnRefrescarHorarios.TabStop = False
        '
        'btnVistaDias
        '
        Me.btnVistaDias.BackgroundImage = Global.Minerva.My.Resources.Resources.dia_seleccionado
        Me.btnVistaDias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVistaDias.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVistaDias.Enabled = False
        Me.btnVistaDias.Location = New System.Drawing.Point(166, 8)
        Me.btnVistaDias.Name = "btnVistaDias"
        Me.btnVistaDias.Size = New System.Drawing.Size(45, 45)
        Me.btnVistaDias.TabIndex = 131
        Me.btnVistaDias.TabStop = False
        '
        'btnVistaSemana
        '
        Me.btnVistaSemana.BackgroundImage = Global.Minerva.My.Resources.Resources.semana_normal
        Me.btnVistaSemana.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVistaSemana.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVistaSemana.Location = New System.Drawing.Point(217, 8)
        Me.btnVistaSemana.Name = "btnVistaSemana"
        Me.btnVistaSemana.Size = New System.Drawing.Size(45, 45)
        Me.btnVistaSemana.TabIndex = 132
        Me.btnVistaSemana.TabStop = False
        '
        'btnFullscreen
        '
        Me.btnFullscreen.BackgroundImage = Global.Minerva.My.Resources.Resources.fullscreen_normal
        Me.btnFullscreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFullscreen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFullscreen.Location = New System.Drawing.Point(99, 15)
        Me.btnFullscreen.Name = "btnFullscreen"
        Me.btnFullscreen.Size = New System.Drawing.Size(30, 30)
        Me.btnFullscreen.TabIndex = 134
        Me.btnFullscreen.TabStop = False
        Me.btnFullscreen.Visible = False
        '
        'Grilla
        '
        Me.Grilla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grilla.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Grilla.Location = New System.Drawing.Point(37, 65)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.Size = New System.Drawing.Size(923, 422)
        Me.Grilla.TabIndex = 133
        Me.Grilla.TabStop = False
        Me.Grilla.Visible = False
        '
        'cmsFiltrado
        '
        Me.cmsFiltrado.Name = "ContextMenuStrip1"
        Me.cmsFiltrado.Size = New System.Drawing.Size(61, 4)
        '
        'pnlAyudabtnVistaSemana
        '
        Me.pnlAyudabtnVistaSemana.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAyudabtnVistaSemana.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pnlAyudabtnVistaSemana.BackgroundImage = CType(resources.GetObject("pnlAyudabtnVistaSemana.BackgroundImage"), System.Drawing.Image)
        Me.pnlAyudabtnVistaSemana.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlAyudabtnVistaSemana.Controls.Add(Me.Label6)
        Me.pnlAyudabtnVistaSemana.Location = New System.Drawing.Point(780, 102)
        Me.pnlAyudabtnVistaSemana.Name = "pnlAyudabtnVistaSemana"
        Me.pnlAyudabtnVistaSemana.Size = New System.Drawing.Size(218, 79)
        Me.pnlAyudabtnVistaSemana.TabIndex = 140
        Me.pnlAyudabtnVistaSemana.Visible = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(33, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(163, 54)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Ver como semana (lista)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlAyudabtnVistaDias
        '
        Me.pnlAyudabtnVistaDias.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAyudabtnVistaDias.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pnlAyudabtnVistaDias.BackgroundImage = CType(resources.GetObject("pnlAyudabtnVistaDias.BackgroundImage"), System.Drawing.Image)
        Me.pnlAyudabtnVistaDias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlAyudabtnVistaDias.Controls.Add(Me.Label5)
        Me.pnlAyudabtnVistaDias.Location = New System.Drawing.Point(730, 102)
        Me.pnlAyudabtnVistaDias.Name = "pnlAyudabtnVistaDias"
        Me.pnlAyudabtnVistaDias.Size = New System.Drawing.Size(218, 79)
        Me.pnlAyudabtnVistaDias.TabIndex = 139
        Me.pnlAyudabtnVistaDias.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(33, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(163, 54)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Ver como días (individuales)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlAyudabtnRefrescarHorarios
        '
        Me.pnlAyudabtnRefrescarHorarios.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAyudabtnRefrescarHorarios.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pnlAyudabtnRefrescarHorarios.BackgroundImage = CType(resources.GetObject("pnlAyudabtnRefrescarHorarios.BackgroundImage"), System.Drawing.Image)
        Me.pnlAyudabtnRefrescarHorarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlAyudabtnRefrescarHorarios.Controls.Add(Me.Label4)
        Me.pnlAyudabtnRefrescarHorarios.Location = New System.Drawing.Point(690, 102)
        Me.pnlAyudabtnRefrescarHorarios.Name = "pnlAyudabtnRefrescarHorarios"
        Me.pnlAyudabtnRefrescarHorarios.Size = New System.Drawing.Size(218, 79)
        Me.pnlAyudabtnRefrescarHorarios.TabIndex = 138
        Me.pnlAyudabtnRefrescarHorarios.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(33, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(163, 54)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Actualiza la lista de horarios"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlAyudabtnFullscreen
        '
        Me.pnlAyudabtnFullscreen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAyudabtnFullscreen.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pnlAyudabtnFullscreen.BackgroundImage = CType(resources.GetObject("pnlAyudabtnFullscreen.BackgroundImage"), System.Drawing.Image)
        Me.pnlAyudabtnFullscreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlAyudabtnFullscreen.Controls.Add(Me.Label3)
        Me.pnlAyudabtnFullscreen.Location = New System.Drawing.Point(655, 102)
        Me.pnlAyudabtnFullscreen.Name = "pnlAyudabtnFullscreen"
        Me.pnlAyudabtnFullscreen.Size = New System.Drawing.Size(218, 79)
        Me.pnlAyudabtnFullscreen.TabIndex = 137
        Me.pnlAyudabtnFullscreen.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(33, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(163, 54)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Ver grilla en pantalla completa"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlAyudabtnGuardarPdf
        '
        Me.pnlAyudabtnGuardarPdf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAyudabtnGuardarPdf.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pnlAyudabtnGuardarPdf.BackgroundImage = CType(resources.GetObject("pnlAyudabtnGuardarPdf.BackgroundImage"), System.Drawing.Image)
        Me.pnlAyudabtnGuardarPdf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlAyudabtnGuardarPdf.Controls.Add(Me.Label2)
        Me.pnlAyudabtnGuardarPdf.Location = New System.Drawing.Point(604, 102)
        Me.pnlAyudabtnGuardarPdf.Name = "pnlAyudabtnGuardarPdf"
        Me.pnlAyudabtnGuardarPdf.Size = New System.Drawing.Size(218, 79)
        Me.pnlAyudabtnGuardarPdf.TabIndex = 136
        Me.pnlAyudabtnGuardarPdf.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(33, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 54)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Guardar horarios (grilla) a archivo PDF"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlAyudabtnRecargar
        '
        Me.pnlAyudabtnRecargar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAyudabtnRecargar.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pnlAyudabtnRecargar.BackgroundImage = Global.Minerva.My.Resources.Resources.dialogo_izquierda
        Me.pnlAyudabtnRecargar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlAyudabtnRecargar.Controls.Add(Me.Label1)
        Me.pnlAyudabtnRecargar.Location = New System.Drawing.Point(788, 25)
        Me.pnlAyudabtnRecargar.Name = "pnlAyudabtnRecargar"
        Me.pnlAyudabtnRecargar.Size = New System.Drawing.Size(246, 71)
        Me.pnlAyudabtnRecargar.TabIndex = 131
        Me.pnlAyudabtnRecargar.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(42, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 53)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Recarga la lista de grupos"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlAyudaalertaAprobacion
        '
        Me.pnlAyudaalertaAprobacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pnlAyudaalertaAprobacion.BackgroundImage = Global.Minerva.My.Resources.Resources.dialogo_izquierda
        Me.pnlAyudaalertaAprobacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlAyudaalertaAprobacion.Controls.Add(Me.lblCantidadUsuariosAprobacion)
        Me.pnlAyudaalertaAprobacion.Location = New System.Drawing.Point(195, 39)
        Me.pnlAyudaalertaAprobacion.Name = "pnlAyudaalertaAprobacion"
        Me.pnlAyudaalertaAprobacion.Size = New System.Drawing.Size(291, 100)
        Me.pnlAyudaalertaAprobacion.TabIndex = 130
        Me.pnlAyudaalertaAprobacion.Visible = False
        '
        'lblCantidadUsuariosAprobacion
        '
        Me.lblCantidadUsuariosAprobacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.lblCantidadUsuariosAprobacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lblCantidadUsuariosAprobacion.ForeColor = System.Drawing.Color.White
        Me.lblCantidadUsuariosAprobacion.Location = New System.Drawing.Point(47, 5)
        Me.lblCantidadUsuariosAprobacion.Name = "lblCantidadUsuariosAprobacion"
        Me.lblCantidadUsuariosAprobacion.Size = New System.Drawing.Size(233, 90)
        Me.lblCantidadUsuariosAprobacion.TabIndex = 0
        Me.lblCantidadUsuariosAprobacion.Text = "0 usuario están esperando la aprobación de un administrador para poder ingresar."
        Me.lblCantidadUsuariosAprobacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlAyudabtnFiltrar
        '
        Me.pnlAyudabtnFiltrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pnlAyudabtnFiltrar.BackgroundImage = Global.Minerva.My.Resources.Resources.dialogo_derecha
        Me.pnlAyudabtnFiltrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlAyudabtnFiltrar.Controls.Add(Me.lblFiltrado)
        Me.pnlAyudabtnFiltrar.Location = New System.Drawing.Point(73, 32)
        Me.pnlAyudabtnFiltrar.Name = "pnlAyudabtnFiltrar"
        Me.pnlAyudabtnFiltrar.Size = New System.Drawing.Size(249, 73)
        Me.pnlAyudabtnFiltrar.TabIndex = 131
        Me.pnlAyudabtnFiltrar.Visible = False
        '
        'lblFiltrado
        '
        Me.lblFiltrado.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.lblFiltrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lblFiltrado.ForeColor = System.Drawing.Color.White
        Me.lblFiltrado.Location = New System.Drawing.Point(3, 7)
        Me.lblFiltrado.Name = "lblFiltrado"
        Me.lblFiltrado.Size = New System.Drawing.Size(209, 57)
        Me.lblFiltrado.TabIndex = 0
        Me.lblFiltrado.Text = "Filtrado de grupos (inactivo)"
        Me.lblFiltrado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1264, 681)
        Me.Controls.Add(Me.pnlAyudaalertaAprobacion)
        Me.Controls.Add(Me.pnlAyudabtnFiltrar)
        Me.Controls.Add(Me.pnlAyudabtnVistaSemana)
        Me.Controls.Add(Me.pnlAyudabtnVistaDias)
        Me.Controls.Add(Me.pnlAyudabtnRefrescarHorarios)
        Me.Controls.Add(Me.pnlAyudabtnFullscreen)
        Me.Controls.Add(Me.pnlAyudabtnGuardarPdf)
        Me.Controls.Add(Me.pnlAyudabtnRecargar)
        Me.Controls.Add(Me.pnlHorarios)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlInfoCurso)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Minerva"
        Me.pnlInfoCurso.ResumeLayout(False)
        Me.pnlInfoCurso.PerformLayout()
        Me.pnlDatosGrupo.ResumeLayout(False)
        Me.pnlDatosGrupo.PerformLayout()
        Me.pnlMaterias.ResumeLayout(False)
        Me.pnlMaterias.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.alertaAprobacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogoUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogoInvitado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogoMAITs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFiltro.ResumeLayout(False)
        CType(Me.btnFiltrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRecargar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHorarios.ResumeLayout(False)
        Me.pnlHorarios.PerformLayout()
        Me.tblDias.ResumeLayout(False)
        Me.tblDias.PerformLayout()
        Me.pnlBotonesHorarios.ResumeLayout(False)
        CType(Me.btnGuardarPdf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRefrescarHorarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnVistaDias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnVistaSemana, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnFullscreen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAyudabtnVistaSemana.ResumeLayout(False)
        Me.pnlAyudabtnVistaDias.ResumeLayout(False)
        Me.pnlAyudabtnRefrescarHorarios.ResumeLayout(False)
        Me.pnlAyudabtnFullscreen.ResumeLayout(False)
        Me.pnlAyudabtnGuardarPdf.ResumeLayout(False)
        Me.pnlAyudabtnRecargar.ResumeLayout(False)
        Me.pnlAyudaalertaAprobacion.ResumeLayout(False)
        Me.pnlAyudabtnFiltrar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlInfoCurso As System.Windows.Forms.Panel
    Friend WithEvents lblProfesores As System.Windows.Forms.Label
    Friend WithEvents lblInfoCurso As System.Windows.Forms.Label
    Friend WithEvents lblTurno As System.Windows.Forms.Label
    Friend WithEvents lblCurso As System.Windows.Forms.Label
    Friend WithEvents lblValorTipoSalon As System.Windows.Forms.Label
    Friend WithEvents lblValorTipoTurno As System.Windows.Forms.Label
    Friend WithEvents lblSalon As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblValorTipoCurso As System.Windows.Forms.Label
    Friend WithEvents lblGrado As System.Windows.Forms.Label
    Friend WithEvents lblNomGrupo As System.Windows.Forms.Label
    Friend WithEvents imgLogoInvitado As System.Windows.Forms.PictureBox
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents lblGrupo As System.Windows.Forms.Label
    Friend WithEvents pnlMaterias As System.Windows.Forms.Panel
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
    Friend WithEvents lblValorTipoGrado As System.Windows.Forms.Label
    Friend WithEvents btnRecargar As System.Windows.Forms.PictureBox
    Friend WithEvents btnRefrescarHorarios As System.Windows.Forms.PictureBox
    Friend WithEvents TimerBtnRefrescar As System.Windows.Forms.Timer
    Friend WithEvents tblMaterias As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnVistaDias As System.Windows.Forms.PictureBox
    Friend WithEvents btnVistaSemana As System.Windows.Forms.PictureBox
    Friend WithEvents Grilla As Minerva.frmVistaGrilla
    Friend WithEvents btnFullscreen As System.Windows.Forms.PictureBox
    Friend WithEvents pnlBordeSeparador As System.Windows.Forms.Panel
    Friend WithEvents pnlSeparador As System.Windows.Forms.Panel
    Friend WithEvents pnlFiltro As System.Windows.Forms.Panel
    Friend WithEvents pnlHorarios As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosGrupo As System.Windows.Forms.Panel
    Friend WithEvents pnlBotonesHorarios As System.Windows.Forms.Panel
    Friend WithEvents tblDias As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnGuardarPdf As System.Windows.Forms.PictureBox
    Friend WithEvents lblValorTipoAdscripto As System.Windows.Forms.Label
    Friend WithEvents lblAdscripto As System.Windows.Forms.Label
    Friend WithEvents alertaAprobacion As System.Windows.Forms.PictureBox
    Friend WithEvents imgLogoUsuario As System.Windows.Forms.PictureBox
    Friend WithEvents pnlAyudaalertaAprobacion As System.Windows.Forms.Panel
    Friend WithEvents lblCantidadUsuariosAprobacion As System.Windows.Forms.Label
    Friend WithEvents pnlAyudabtnRecargar As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlAyudabtnGuardarPdf As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlAyudabtnFullscreen As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlAyudabtnRefrescarHorarios As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlAyudabtnVistaDias As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnlAyudabtnVistaSemana As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmsFiltrado As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btnFiltrar As System.Windows.Forms.PictureBox
    Friend WithEvents pnlAyudabtnFiltrar As System.Windows.Forms.Panel
    Friend WithEvents lblFiltrado As System.Windows.Forms.Label

End Class
