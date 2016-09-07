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
        lblTitulo = New System.Windows.Forms.Label()
        lblUsuarios = New System.Windows.Forms.Label()
        Me.pnlFondo.SuspendLayout()
        Me.pnlUsuarioPlantilla.SuspendLayout()
        Me.SuspendLayout()
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
        Me.btnUsuarioPlantilla.Font = New System.Drawing.Font("Corbel", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        'pnlUsuarios
        '
        Me.pnlUsuarios.AutoScroll = True
        Me.pnlUsuarios.Location = New System.Drawing.Point(21, 61)
        Me.pnlUsuarios.Name = "pnlUsuarios"
        Me.pnlUsuarios.Size = New System.Drawing.Size(337, 413)
        Me.pnlUsuarios.TabIndex = 33
        '
        'frmAdminUsuarios
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Controls.Add(Me.btnNuevoUsuario)
        Me.Controls.Add(Me.lblNuevoUsuario)
        Me.Controls.Add(lblTitulo)
        Me.Controls.Add(Me.pnlFondo)
        Me.Name = "frmAdminUsuarios"
        Me.Size = New System.Drawing.Size(1004, 493)
        Me.pnlFondo.ResumeLayout(False)
        Me.pnlFondo.PerformLayout()
        Me.pnlUsuarioPlantilla.ResumeLayout(False)
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

End Class
