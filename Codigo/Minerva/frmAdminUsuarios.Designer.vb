<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminUsuarios
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
        Dim lblUsuarios As System.Windows.Forms.Label
        Me.btnNuevoUsuario = New System.Windows.Forms.Button()
        Me.lblNuevoUsuario = New System.Windows.Forms.Label()
        Me.pnlFondo = New System.Windows.Forms.Panel()
        Me.pnlUsuarioPlantilla = New System.Windows.Forms.Panel()
        Me.btnUsuarioPlantilla = New System.Windows.Forms.Button()
        Me.btnEliminarPlantilla = New System.Windows.Forms.Button()
        Me.btnEditarPlantilla = New System.Windows.Forms.Button()
        Me.lblCantidadUsuarios = New System.Windows.Forms.Label()
        Me.pnlUsuarios = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblID = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.lblContraseña = New System.Windows.Forms.Label()
        Me.txtContraseña = New System.Windows.Forms.TextBox()
        Me.chkHabilitado = New System.Windows.Forms.CheckBox()
        Me.radFuncionario = New System.Windows.Forms.RadioButton()
        Me.radAdministrador = New System.Windows.Forms.RadioButton()
        Me.grpTipoCuenta = New System.Windows.Forms.GroupBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        lblTitulo = New System.Windows.Forms.Label()
        lblUsuarios = New System.Windows.Forms.Label()
        Me.pnlFondo.SuspendLayout()
        Me.pnlUsuarioPlantilla.SuspendLayout()
        Me.grpTipoCuenta.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        lblTitulo.AutoSize = True
        lblTitulo.Font = New System.Drawing.Font("Corbel", 28.0!, System.Drawing.FontStyle.Bold)
        lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        lblTitulo.Location = New System.Drawing.Point(17, 12)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New System.Drawing.Size(339, 46)
        lblTitulo.TabIndex = 108
        lblTitulo.Text = "Gestión de usuarios"
        '
        'lblUsuarios
        '
        lblUsuarios.AutoSize = True
        lblUsuarios.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        lblUsuarios.Font = New System.Drawing.Font("Corbel", 27.0!, System.Drawing.FontStyle.Bold)
        lblUsuarios.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        lblUsuarios.Location = New System.Drawing.Point(13, 12)
        lblUsuarios.Name = "lblUsuarios"
        lblUsuarios.Size = New System.Drawing.Size(279, 44)
        lblUsuarios.TabIndex = 2
        lblUsuarios.Text = "Lista de usuarios"
        '
        'btnNuevoUsuario
        '
        Me.btnNuevoUsuario.AutoSize = True
        Me.btnNuevoUsuario.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnNuevoUsuario.Location = New System.Drawing.Point(378, 21)
        Me.btnNuevoUsuario.Name = "btnNuevoUsuario"
        Me.btnNuevoUsuario.Size = New System.Drawing.Size(121, 29)
        Me.btnNuevoUsuario.TabIndex = 110
        Me.btnNuevoUsuario.Text = "Nuevo usuario"
        Me.btnNuevoUsuario.UseVisualStyleBackColor = True
        Me.btnNuevoUsuario.Visible = False
        '
        'lblNuevoUsuario
        '
        Me.lblNuevoUsuario.AutoSize = True
        Me.lblNuevoUsuario.BackColor = System.Drawing.Color.Transparent
        Me.lblNuevoUsuario.Font = New System.Drawing.Font("Corbel", 28.0!)
        Me.lblNuevoUsuario.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblNuevoUsuario.Location = New System.Drawing.Point(17, 58)
        Me.lblNuevoUsuario.Name = "lblNuevoUsuario"
        Me.lblNuevoUsuario.Size = New System.Drawing.Size(247, 46)
        Me.lblNuevoUsuario.TabIndex = 109
        Me.lblNuevoUsuario.Text = "Nuevo usuario"
        '
        'pnlFondo
        '
        Me.pnlFondo.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.pnlFondo.Controls.Add(Me.pnlUsuarioPlantilla)
        Me.pnlFondo.Controls.Add(Me.lblCantidadUsuarios)
        Me.pnlFondo.Controls.Add(lblUsuarios)
        Me.pnlFondo.Controls.Add(Me.pnlUsuarios)
        Me.pnlFondo.Location = New System.Drawing.Point(639, 0)
        Me.pnlFondo.Name = "pnlFondo"
        Me.pnlFondo.Size = New System.Drawing.Size(365, 501)
        Me.pnlFondo.TabIndex = 107
        '
        'pnlUsuarioPlantilla
        '
        Me.pnlUsuarioPlantilla.Controls.Add(Me.btnUsuarioPlantilla)
        Me.pnlUsuarioPlantilla.Controls.Add(Me.btnEliminarPlantilla)
        Me.pnlUsuarioPlantilla.Controls.Add(Me.btnEditarPlantilla)
        Me.pnlUsuarioPlantilla.Location = New System.Drawing.Point(0, 0)
        Me.pnlUsuarioPlantilla.Name = "pnlUsuarioPlantilla"
        Me.pnlUsuarioPlantilla.Size = New System.Drawing.Size(305, 56)
        Me.pnlUsuarioPlantilla.TabIndex = 0
        Me.pnlUsuarioPlantilla.Visible = False
        '
        'btnUsuarioPlantilla
        '
        Me.btnUsuarioPlantilla.BackColor = System.Drawing.SystemColors.GrayText
        Me.btnUsuarioPlantilla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUsuarioPlantilla.FlatAppearance.BorderColor = System.Drawing.Color.Tomato
        Me.btnUsuarioPlantilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUsuarioPlantilla.Font = New System.Drawing.Font("Corbel", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUsuarioPlantilla.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnUsuarioPlantilla.Location = New System.Drawing.Point(0, 3)
        Me.btnUsuarioPlantilla.Name = "btnUsuarioPlantilla"
        Me.btnUsuarioPlantilla.Size = New System.Drawing.Size(207, 48)
        Me.btnUsuarioPlantilla.TabIndex = 0
        Me.btnUsuarioPlantilla.Text = "Template usuario"
        Me.btnUsuarioPlantilla.UseVisualStyleBackColor = False
        '
        'btnEliminarPlantilla
        '
        Me.btnEliminarPlantilla.BackColor = System.Drawing.Color.Firebrick
        Me.btnEliminarPlantilla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminarPlantilla.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnEliminarPlantilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminarPlantilla.Font = New System.Drawing.Font("Corbel", 10.0!)
        Me.btnEliminarPlantilla.ForeColor = System.Drawing.Color.White
        Me.btnEliminarPlantilla.Location = New System.Drawing.Point(213, 28)
        Me.btnEliminarPlantilla.Name = "btnEliminarPlantilla"
        Me.btnEliminarPlantilla.Size = New System.Drawing.Size(89, 23)
        Me.btnEliminarPlantilla.TabIndex = 2
        Me.btnEliminarPlantilla.Text = "Eliminar"
        Me.btnEliminarPlantilla.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminarPlantilla.UseVisualStyleBackColor = False
        '
        'btnEditarPlantilla
        '
        Me.btnEditarPlantilla.BackColor = System.Drawing.Color.SteelBlue
        Me.btnEditarPlantilla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditarPlantilla.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnEditarPlantilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditarPlantilla.Font = New System.Drawing.Font("Corbel", 10.0!)
        Me.btnEditarPlantilla.ForeColor = System.Drawing.Color.White
        Me.btnEditarPlantilla.Location = New System.Drawing.Point(213, 3)
        Me.btnEditarPlantilla.Name = "btnEditarPlantilla"
        Me.btnEditarPlantilla.Size = New System.Drawing.Size(89, 23)
        Me.btnEditarPlantilla.TabIndex = 1
        Me.btnEditarPlantilla.Text = "Editar"
        Me.btnEditarPlantilla.UseVisualStyleBackColor = False
        '
        'lblCantidadUsuarios
        '
        Me.lblCantidadUsuarios.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lblCantidadUsuarios.Font = New System.Drawing.Font("Corbel", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblCantidadUsuarios.ForeColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lblCantidadUsuarios.Location = New System.Drawing.Point(292, 18)
        Me.lblCantidadUsuarios.Name = "lblCantidadUsuarios"
        Me.lblCantidadUsuarios.Size = New System.Drawing.Size(89, 40)
        Me.lblCantidadUsuarios.TabIndex = 34
        Me.lblCantidadUsuarios.Text = "(0)"
        '
        'pnlUsuarios
        '
        Me.pnlUsuarios.AutoScroll = True
        Me.pnlUsuarios.Location = New System.Drawing.Point(21, 61)
        Me.pnlUsuarios.Name = "pnlUsuarios"
        Me.pnlUsuarios.Size = New System.Drawing.Size(337, 413)
        Me.pnlUsuarios.TabIndex = 33
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblID.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblID.Location = New System.Drawing.Point(20, 134)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(176, 29)
        Me.lblID.TabIndex = 112
        Me.lblID.Text = "Nombre usuario"
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.txtID.Location = New System.Drawing.Point(25, 166)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(214, 34)
        Me.txtID.TabIndex = 111
        '
        'lblContraseña
        '
        Me.lblContraseña.AutoSize = True
        Me.lblContraseña.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblContraseña.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblContraseña.Location = New System.Drawing.Point(268, 134)
        Me.lblContraseña.Name = "lblContraseña"
        Me.lblContraseña.Size = New System.Drawing.Size(129, 29)
        Me.lblContraseña.TabIndex = 114
        Me.lblContraseña.Text = "Contraseña"
        '
        'txtContraseña
        '
        Me.txtContraseña.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.txtContraseña.Location = New System.Drawing.Point(273, 166)
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.Size = New System.Drawing.Size(214, 34)
        Me.txtContraseña.TabIndex = 113
        '
        'chkHabilitado
        '
        Me.chkHabilitado.AutoSize = True
        Me.chkHabilitado.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.chkHabilitado.ForeColor = System.Drawing.Color.PaleGreen
        Me.chkHabilitado.Location = New System.Drawing.Point(25, 269)
        Me.chkHabilitado.Name = "chkHabilitado"
        Me.chkHabilitado.Size = New System.Drawing.Size(190, 31)
        Me.chkHabilitado.TabIndex = 115
        Me.chkHabilitado.Text = "Acceso aprobado"
        Me.chkHabilitado.UseVisualStyleBackColor = True
        '
        'radFuncionario
        '
        Me.radFuncionario.AutoSize = True
        Me.radFuncionario.Checked = True
        Me.radFuncionario.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.radFuncionario.ForeColor = System.Drawing.Color.PaleGreen
        Me.radFuncionario.Location = New System.Drawing.Point(32, 38)
        Me.radFuncionario.Name = "radFuncionario"
        Me.radFuncionario.Size = New System.Drawing.Size(138, 31)
        Me.radFuncionario.TabIndex = 116
        Me.radFuncionario.TabStop = True
        Me.radFuncionario.Text = "Funcionario"
        Me.radFuncionario.UseVisualStyleBackColor = True
        '
        'radAdministrador
        '
        Me.radAdministrador.AutoSize = True
        Me.radAdministrador.Font = New System.Drawing.Font("Corbel", 16.0!)
        Me.radAdministrador.ForeColor = System.Drawing.Color.PaleGreen
        Me.radAdministrador.Location = New System.Drawing.Point(32, 75)
        Me.radAdministrador.Name = "radAdministrador"
        Me.radAdministrador.Size = New System.Drawing.Size(162, 31)
        Me.radAdministrador.TabIndex = 117
        Me.radAdministrador.Text = "Administrador"
        Me.radAdministrador.UseVisualStyleBackColor = True
        '
        'grpTipoCuenta
        '
        Me.grpTipoCuenta.Controls.Add(Me.radFuncionario)
        Me.grpTipoCuenta.Controls.Add(Me.radAdministrador)
        Me.grpTipoCuenta.Font = New System.Drawing.Font("Corbel", 18.0!, System.Drawing.FontStyle.Bold)
        Me.grpTipoCuenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.grpTipoCuenta.Location = New System.Drawing.Point(273, 224)
        Me.grpTipoCuenta.Name = "grpTipoCuenta"
        Me.grpTipoCuenta.Size = New System.Drawing.Size(273, 120)
        Me.grpTipoCuenta.TabIndex = 118
        Me.grpTipoCuenta.TabStop = False
        Me.grpTipoCuenta.Text = "Tipo de cuenta"
        '
        'btnAgregar
        '
        Me.btnAgregar.AutoSize = True
        Me.btnAgregar.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnAgregar.Location = New System.Drawing.Point(453, 391)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(146, 29)
        Me.btnAgregar.TabIndex = 119
        Me.btnAgregar.Text = "Agregar usuario"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.AutoSize = True
        Me.btnCancelar.Font = New System.Drawing.Font("Corbel", 12.0!)
        Me.btnCancelar.Location = New System.Drawing.Point(453, 426)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(146, 29)
        Me.btnCancelar.TabIndex = 120
        Me.btnCancelar.Text = "Cancelar edición"
        Me.btnCancelar.UseVisualStyleBackColor = True
        Me.btnCancelar.Visible = False
        '
        'frmAdminUsuarios
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.grpTipoCuenta)
        Me.Controls.Add(Me.chkHabilitado)
        Me.Controls.Add(Me.lblContraseña)
        Me.Controls.Add(Me.txtContraseña)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.btnNuevoUsuario)
        Me.Controls.Add(Me.lblNuevoUsuario)
        Me.Controls.Add(lblTitulo)
        Me.Controls.Add(Me.pnlFondo)
        Me.Name = "frmAdminUsuarios"
        Me.Size = New System.Drawing.Size(1004, 493)
        Me.pnlFondo.ResumeLayout(False)
        Me.pnlFondo.PerformLayout()
        Me.pnlUsuarioPlantilla.ResumeLayout(False)
        Me.grpTipoCuenta.ResumeLayout(False)
        Me.grpTipoCuenta.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnNuevoUsuario As System.Windows.Forms.Button
    Friend WithEvents lblNuevoUsuario As System.Windows.Forms.Label
    Friend WithEvents pnlFondo As System.Windows.Forms.Panel
    Friend WithEvents pnlUsuarioPlantilla As System.Windows.Forms.Panel
    Friend WithEvents btnUsuarioPlantilla As System.Windows.Forms.Button
    Friend WithEvents btnEliminarPlantilla As System.Windows.Forms.Button
    Friend WithEvents btnEditarPlantilla As System.Windows.Forms.Button
    Friend WithEvents lblCantidadUsuarios As System.Windows.Forms.Label
    Friend WithEvents pnlUsuarios As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents lblContraseña As System.Windows.Forms.Label
    Friend WithEvents txtContraseña As System.Windows.Forms.TextBox
    Friend WithEvents chkHabilitado As System.Windows.Forms.CheckBox
    Friend WithEvents radFuncionario As System.Windows.Forms.RadioButton
    Friend WithEvents radAdministrador As System.Windows.Forms.RadioButton
    Friend WithEvents grpTipoCuenta As System.Windows.Forms.GroupBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button

End Class
