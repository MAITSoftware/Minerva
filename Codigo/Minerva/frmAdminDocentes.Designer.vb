<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminDocentes
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
        Dim lblAccion As System.Windows.Forms.Label
        Dim lblTitulo As System.Windows.Forms.Label
        Me.pnlFondo = New System.Windows.Forms.Panel()
        Me.pnlProfesores = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlProfesor = New System.Windows.Forms.Panel()
        Me.lblNomProfesor = New System.Windows.Forms.Label()
        Me.btnEliminarProfesor = New System.Windows.Forms.Button()
        Me.btnEditarProfesor = New System.Windows.Forms.Button()
        Me.txtCargo = New System.Windows.Forms.ComboBox()
        Me.lblCargo = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblApellido = New System.Windows.Forms.Label()
        Me.lblCi = New System.Windows.Forms.Label()
        Me.txtCI = New System.Windows.Forms.TextBox()
        Me.txtNomMateria = New System.Windows.Forms.TextBox()
        Me.lblHsSemanales = New System.Windows.Forms.Label()
        Me.txtHsSemanales = New System.Windows.Forms.TextBox()
        Me.lblOrientacion = New System.Windows.Forms.Label()
        Me.lblArea = New System.Windows.Forms.Label()
        Me.txtArea = New System.Windows.Forms.TextBox()
        Me.lblNomMateria = New System.Windows.Forms.Label()
        Me.txtApellido = New System.Windows.Forms.TextBox()
        Me.lblAsignaturas = New System.Windows.Forms.Label()
        Me.txtOrientacion = New System.Windows.Forms.TextBox()
        Me.lblGrado = New System.Windows.Forms.Label()
        Me.txtGrado = New System.Windows.Forms.TextBox()
        Me.cmbGrupo = New System.Windows.Forms.ComboBox()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.lstAsignaturas = New System.Windows.Forms.ListBox()
        Me.btnEliminarAsignatura = New System.Windows.Forms.Button()
        Me.btnRegistro = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardarCambios = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        lblHorariosSemana = New System.Windows.Forms.Label()
        lblAccion = New System.Windows.Forms.Label()
        lblTitulo = New System.Windows.Forms.Label()
        Me.pnlFondo.SuspendLayout()
        Me.pnlProfesores.SuspendLayout()
        Me.pnlProfesor.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHorariosSemana
        '
        lblHorariosSemana.AutoSize = True
        lblHorariosSemana.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        lblHorariosSemana.Font = New System.Drawing.Font("Corbel", 28.0!, System.Drawing.FontStyle.Bold)
        lblHorariosSemana.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        lblHorariosSemana.Location = New System.Drawing.Point(23, 30)
        lblHorariosSemana.Name = "lblHorariosSemana"
        lblHorariosSemana.Size = New System.Drawing.Size(326, 46)
        lblHorariosSemana.TabIndex = 37
        lblHorariosSemana.Text = "Lista de profesores"
        '
        'lblAccion
        '
        lblAccion.AutoSize = True
        lblAccion.Font = New System.Drawing.Font("Corbel", 24.0!)
        lblAccion.ForeColor = System.Drawing.Color.PaleGreen
        lblAccion.Location = New System.Drawing.Point(17, 58)
        lblAccion.Name = "lblAccion"
        lblAccion.Size = New System.Drawing.Size(239, 39)
        lblAccion.TabIndex = 47
        lblAccion.Text = "Agregar docente"
        '
        'lblTitulo
        '
        lblTitulo.AutoSize = True
        lblTitulo.Font = New System.Drawing.Font("Corbel", 28.0!, System.Drawing.FontStyle.Bold)
        lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        lblTitulo.Location = New System.Drawing.Point(17, 12)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New System.Drawing.Size(350, 46)
        lblTitulo.TabIndex = 46
        lblTitulo.Text = "Gestión de docentes"
        '
        'pnlFondo
        '
        Me.pnlFondo.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.pnlFondo.Controls.Add(Me.pnlProfesores)
        Me.pnlFondo.Controls.Add(lblHorariosSemana)
        Me.pnlFondo.Location = New System.Drawing.Point(643, 0)
        Me.pnlFondo.Name = "pnlFondo"
        Me.pnlFondo.Size = New System.Drawing.Size(358, 493)
        Me.pnlFondo.TabIndex = 45
        '
        'pnlProfesores
        '
        Me.pnlProfesores.AutoScroll = True
        Me.pnlProfesores.Controls.Add(Me.pnlProfesor)
        Me.pnlProfesores.Location = New System.Drawing.Point(31, 79)
        Me.pnlProfesores.Name = "pnlProfesores"
        Me.pnlProfesores.Size = New System.Drawing.Size(306, 374)
        Me.pnlProfesores.TabIndex = 38
        '
        'pnlProfesor
        '
        Me.pnlProfesor.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.pnlProfesor.Controls.Add(Me.lblNomProfesor)
        Me.pnlProfesor.Controls.Add(Me.btnEliminarProfesor)
        Me.pnlProfesor.Controls.Add(Me.btnEditarProfesor)
        Me.pnlProfesor.Location = New System.Drawing.Point(3, 3)
        Me.pnlProfesor.Name = "pnlProfesor"
        Me.pnlProfesor.Size = New System.Drawing.Size(266, 56)
        Me.pnlProfesor.TabIndex = 0
        '
        'lblNomProfesor
        '
        Me.lblNomProfesor.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.lblNomProfesor.ForeColor = System.Drawing.Color.White
        Me.lblNomProfesor.Location = New System.Drawing.Point(3, 3)
        Me.lblNomProfesor.Name = "lblNomProfesor"
        Me.lblNomProfesor.Size = New System.Drawing.Size(171, 50)
        Me.lblNomProfesor.TabIndex = 3
        Me.lblNomProfesor.Text = "Profesor 1"
        Me.lblNomProfesor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnEliminarProfesor
        '
        Me.btnEliminarProfesor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnEliminarProfesor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEliminarProfesor.Font = New System.Drawing.Font("Corbel", 10.0!)
        Me.btnEliminarProfesor.Location = New System.Drawing.Point(174, 30)
        Me.btnEliminarProfesor.Name = "btnEliminarProfesor"
        Me.btnEliminarProfesor.Size = New System.Drawing.Size(89, 23)
        Me.btnEliminarProfesor.TabIndex = 2
        Me.btnEliminarProfesor.Text = "Eliminar"
        Me.btnEliminarProfesor.UseVisualStyleBackColor = False
        '
        'btnEditarProfesor
        '
        Me.btnEditarProfesor.Font = New System.Drawing.Font("Corbel", 10.0!)
        Me.btnEditarProfesor.Location = New System.Drawing.Point(174, 3)
        Me.btnEditarProfesor.Name = "btnEditarProfesor"
        Me.btnEditarProfesor.Size = New System.Drawing.Size(89, 23)
        Me.btnEditarProfesor.TabIndex = 1
        Me.btnEditarProfesor.Text = "Editar"
        Me.btnEditarProfesor.UseVisualStyleBackColor = True
        '
        'txtCargo
        '
        Me.txtCargo.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.txtCargo.FormattingEnabled = True
        Me.txtCargo.Items.AddRange(New Object() {"Cargo 1", "Cargo 2"})
        Me.txtCargo.Location = New System.Drawing.Point(29, 227)
        Me.txtCargo.Name = "txtCargo"
        Me.txtCargo.Size = New System.Drawing.Size(121, 37)
        Me.txtCargo.TabIndex = 77
        '
        'lblCargo
        '
        Me.lblCargo.AutoSize = True
        Me.lblCargo.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblCargo.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblCargo.Location = New System.Drawing.Point(32, 195)
        Me.lblCargo.Name = "lblCargo"
        Me.lblCargo.Size = New System.Drawing.Size(73, 29)
        Me.lblCargo.TabIndex = 76
        Me.lblCargo.Text = "Cargo"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblNombre.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblNombre.Location = New System.Drawing.Point(157, 110)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(96, 29)
        Me.lblNombre.TabIndex = 75
        Me.lblNombre.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.txtNombre.Location = New System.Drawing.Point(162, 142)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(111, 37)
        Me.txtNombre.TabIndex = 74
        Me.txtNombre.Text = "Ignacio"
        Me.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblApellido
        '
        Me.lblApellido.AutoSize = True
        Me.lblApellido.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblApellido.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblApellido.Location = New System.Drawing.Point(285, 110)
        Me.lblApellido.Name = "lblApellido"
        Me.lblApellido.Size = New System.Drawing.Size(98, 29)
        Me.lblApellido.TabIndex = 73
        Me.lblApellido.Text = "Apellido"
        '
        'lblCi
        '
        Me.lblCi.AutoSize = True
        Me.lblCi.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblCi.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblCi.Location = New System.Drawing.Point(32, 110)
        Me.lblCi.Name = "lblCi"
        Me.lblCi.Size = New System.Drawing.Size(34, 29)
        Me.lblCi.TabIndex = 71
        Me.lblCi.Text = "CI"
        '
        'txtCI
        '
        Me.txtCI.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.txtCI.Location = New System.Drawing.Point(32, 142)
        Me.txtCI.Name = "txtCI"
        Me.txtCI.Size = New System.Drawing.Size(111, 37)
        Me.txtCI.TabIndex = 70
        Me.txtCI.Text = "51199852"
        Me.txtCI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNomMateria
        '
        Me.txtNomMateria.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.txtNomMateria.Location = New System.Drawing.Point(290, 227)
        Me.txtNomMateria.Name = "txtNomMateria"
        Me.txtNomMateria.Size = New System.Drawing.Size(99, 37)
        Me.txtNomMateria.TabIndex = 78
        Me.txtNomMateria.Text = "15"
        Me.txtNomMateria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblHsSemanales
        '
        Me.lblHsSemanales.AutoSize = True
        Me.lblHsSemanales.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblHsSemanales.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblHsSemanales.Location = New System.Drawing.Point(447, 377)
        Me.lblHsSemanales.Name = "lblHsSemanales"
        Me.lblHsSemanales.Size = New System.Drawing.Size(162, 29)
        Me.lblHsSemanales.TabIndex = 88
        Me.lblHsSemanales.Text = "Hs. Semanales"
        '
        'txtHsSemanales
        '
        Me.txtHsSemanales.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.txtHsSemanales.Location = New System.Drawing.Point(452, 409)
        Me.txtHsSemanales.Name = "txtHsSemanales"
        Me.txtHsSemanales.Size = New System.Drawing.Size(99, 37)
        Me.txtHsSemanales.TabIndex = 87
        Me.txtHsSemanales.Text = "15"
        Me.txtHsSemanales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOrientacion
        '
        Me.lblOrientacion.AutoSize = True
        Me.lblOrientacion.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblOrientacion.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblOrientacion.Location = New System.Drawing.Point(447, 296)
        Me.lblOrientacion.Name = "lblOrientacion"
        Me.lblOrientacion.Size = New System.Drawing.Size(134, 29)
        Me.lblOrientacion.TabIndex = 86
        Me.lblOrientacion.Text = "Orientación"
        '
        'lblArea
        '
        Me.lblArea.AutoSize = True
        Me.lblArea.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblArea.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblArea.Location = New System.Drawing.Point(285, 296)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Size = New System.Drawing.Size(61, 29)
        Me.lblArea.TabIndex = 84
        Me.lblArea.Text = "Área"
        '
        'txtArea
        '
        Me.txtArea.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.txtArea.Location = New System.Drawing.Point(290, 328)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.Size = New System.Drawing.Size(121, 37)
        Me.txtArea.TabIndex = 83
        Me.txtArea.Text = "15"
        Me.txtArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNomMateria
        '
        Me.lblNomMateria.AutoSize = True
        Me.lblNomMateria.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblNomMateria.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblNomMateria.Location = New System.Drawing.Point(285, 204)
        Me.lblNomMateria.Name = "lblNomMateria"
        Me.lblNomMateria.Size = New System.Drawing.Size(147, 29)
        Me.lblNomMateria.TabIndex = 82
        Me.lblNomMateria.Text = "Nom Materia"
        '
        'txtApellido
        '
        Me.txtApellido.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.txtApellido.Location = New System.Drawing.Point(290, 142)
        Me.txtApellido.Name = "txtApellido"
        Me.txtApellido.Size = New System.Drawing.Size(111, 37)
        Me.txtApellido.TabIndex = 81
        Me.txtApellido.Text = "Rodríguez"
        Me.txtApellido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAsignaturas
        '
        Me.lblAsignaturas.AutoSize = True
        Me.lblAsignaturas.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblAsignaturas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblAsignaturas.Location = New System.Drawing.Point(24, 278)
        Me.lblAsignaturas.Name = "lblAsignaturas"
        Me.lblAsignaturas.Size = New System.Drawing.Size(229, 29)
        Me.lblAsignaturas.TabIndex = 79
        Me.lblAsignaturas.Text = "Asignaturas tomadas"
        '
        'txtOrientacion
        '
        Me.txtOrientacion.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.txtOrientacion.Location = New System.Drawing.Point(452, 328)
        Me.txtOrientacion.Name = "txtOrientacion"
        Me.txtOrientacion.Size = New System.Drawing.Size(99, 37)
        Me.txtOrientacion.TabIndex = 89
        Me.txtOrientacion.Text = "15"
        Me.txtOrientacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblGrado
        '
        Me.lblGrado.AutoSize = True
        Me.lblGrado.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblGrado.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblGrado.Location = New System.Drawing.Point(178, 195)
        Me.lblGrado.Name = "lblGrado"
        Me.lblGrado.Size = New System.Drawing.Size(75, 29)
        Me.lblGrado.TabIndex = 90
        Me.lblGrado.Text = "Grado"
        '
        'txtGrado
        '
        Me.txtGrado.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.txtGrado.Location = New System.Drawing.Point(174, 227)
        Me.txtGrado.Name = "txtGrado"
        Me.txtGrado.Size = New System.Drawing.Size(99, 37)
        Me.txtGrado.TabIndex = 91
        Me.txtGrado.Text = "1"
        Me.txtGrado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbGrupo
        '
        Me.cmbGrupo.Font = New System.Drawing.Font("Corbel", 18.0!)
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.Items.AddRange(New Object() {"Alta", "Baja"})
        Me.cmbGrupo.Location = New System.Drawing.Point(290, 409)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(121, 37)
        Me.cmbGrupo.TabIndex = 95
        '
        'lblGrupo
        '
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblGrupo.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblGrupo.Location = New System.Drawing.Point(285, 377)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(76, 29)
        Me.lblGrupo.TabIndex = 94
        Me.lblGrupo.Text = "Grupo"
        '
        'lstAsignaturas
        '
        Me.lstAsignaturas.FormattingEnabled = True
        Me.lstAsignaturas.Items.AddRange(New Object() {"Area Orientación Grupo Carga", "1       2                    3BG      2hs", "1       2                    3BG      2hs", "1       2                    3BG      2hs", "1       2                    3BG      2hs"})
        Me.lstAsignaturas.Location = New System.Drawing.Point(29, 311)
        Me.lstAsignaturas.Name = "lstAsignaturas"
        Me.lstAsignaturas.Size = New System.Drawing.Size(158, 121)
        Me.lstAsignaturas.TabIndex = 96
        '
        'btnEliminarAsignatura
        '
        Me.btnEliminarAsignatura.Location = New System.Drawing.Point(29, 450)
        Me.btnEliminarAsignatura.Name = "btnEliminarAsignatura"
        Me.btnEliminarAsignatura.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminarAsignatura.TabIndex = 97
        Me.btnEliminarAsignatura.Text = "Eliminar"
        Me.btnEliminarAsignatura.UseVisualStyleBackColor = True
        '
        'btnRegistro
        '
        Me.btnRegistro.Location = New System.Drawing.Point(373, 21)
        Me.btnRegistro.Name = "btnRegistro"
        Me.btnRegistro.Size = New System.Drawing.Size(136, 32)
        Me.btnRegistro.TabIndex = 98
        Me.btnRegistro.Text = "Registrar nuevo docente"
        Me.btnRegistro.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(504, 207)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(112, 31)
        Me.btnCancelar.TabIndex = 100
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardarCambios
        '
        Me.btnGuardarCambios.Location = New System.Drawing.Point(504, 168)
        Me.btnGuardarCambios.Name = "btnGuardarCambios"
        Me.btnGuardarCambios.Size = New System.Drawing.Size(112, 33)
        Me.btnGuardarCambios.TabIndex = 101
        Me.btnGuardarCambios.Text = "Guardar cambios"
        Me.btnGuardarCambios.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(541, 452)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 102
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'frmAdminDocentes
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnGuardarCambios)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnRegistro)
        Me.Controls.Add(Me.btnEliminarAsignatura)
        Me.Controls.Add(Me.lstAsignaturas)
        Me.Controls.Add(Me.cmbGrupo)
        Me.Controls.Add(Me.lblGrupo)
        Me.Controls.Add(Me.txtGrado)
        Me.Controls.Add(Me.lblGrado)
        Me.Controls.Add(Me.txtOrientacion)
        Me.Controls.Add(Me.lblHsSemanales)
        Me.Controls.Add(Me.txtHsSemanales)
        Me.Controls.Add(Me.lblOrientacion)
        Me.Controls.Add(Me.lblArea)
        Me.Controls.Add(Me.txtArea)
        Me.Controls.Add(Me.lblNomMateria)
        Me.Controls.Add(Me.txtApellido)
        Me.Controls.Add(Me.lblAsignaturas)
        Me.Controls.Add(Me.txtNomMateria)
        Me.Controls.Add(Me.txtCargo)
        Me.Controls.Add(Me.lblCargo)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.lblApellido)
        Me.Controls.Add(Me.lblCi)
        Me.Controls.Add(Me.txtCI)
        Me.Controls.Add(lblAccion)
        Me.Controls.Add(lblTitulo)
        Me.Controls.Add(Me.pnlFondo)
        Me.Name = "frmAdminDocentes"
        Me.Size = New System.Drawing.Size(1004, 493)
        Me.pnlFondo.ResumeLayout(False)
        Me.pnlFondo.PerformLayout()
        Me.pnlProfesores.ResumeLayout(False)
        Me.pnlProfesor.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlFondo As System.Windows.Forms.Panel
    Friend WithEvents txtCargo As System.Windows.Forms.ComboBox
    Friend WithEvents lblCargo As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblApellido As System.Windows.Forms.Label
    Friend WithEvents lblCi As System.Windows.Forms.Label
    Friend WithEvents txtCI As System.Windows.Forms.TextBox
    Friend WithEvents txtNomMateria As System.Windows.Forms.TextBox
    Friend WithEvents lblHsSemanales As System.Windows.Forms.Label
    Friend WithEvents txtHsSemanales As System.Windows.Forms.TextBox
    Friend WithEvents lblOrientacion As System.Windows.Forms.Label
    Friend WithEvents lblArea As System.Windows.Forms.Label
    Friend WithEvents txtArea As System.Windows.Forms.TextBox
    Friend WithEvents lblNomMateria As System.Windows.Forms.Label
    Friend WithEvents txtApellido As System.Windows.Forms.TextBox
    Friend WithEvents lblAsignaturas As System.Windows.Forms.Label
    Friend WithEvents txtOrientacion As System.Windows.Forms.TextBox
    Friend WithEvents lblGrado As System.Windows.Forms.Label
    Friend WithEvents txtGrado As System.Windows.Forms.TextBox
    Friend WithEvents cmbGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents lblGrupo As System.Windows.Forms.Label
    Friend WithEvents lstAsignaturas As System.Windows.Forms.ListBox
    Friend WithEvents btnEliminarAsignatura As System.Windows.Forms.Button
    Friend WithEvents pnlProfesores As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlProfesor As System.Windows.Forms.Panel
    Friend WithEvents lblNomProfesor As System.Windows.Forms.Label
    Friend WithEvents btnEliminarProfesor As System.Windows.Forms.Button
    Friend WithEvents btnEditarProfesor As System.Windows.Forms.Button
    Friend WithEvents btnRegistro As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardarCambios As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button

End Class
