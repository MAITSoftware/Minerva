<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVistaGrilla
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvMaterias = New System.Windows.Forms.DataGridView()
        Me.Hora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lunes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Martes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Miércoles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Jueves = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Viernes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sábado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvMaterias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvMaterias
        '
        Me.dgvMaterias.AllowUserToAddRows = False
        Me.dgvMaterias.AllowUserToDeleteRows = False
        Me.dgvMaterias.AllowUserToResizeColumns = False
        Me.dgvMaterias.AllowUserToResizeRows = False
        Me.dgvMaterias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.dgvMaterias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvMaterias.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.dgvMaterias.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvMaterias.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMaterias.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaterias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Hora, Me.Lunes, Me.Martes, Me.Miércoles, Me.Jueves, Me.Viernes, Me.Sábado})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMaterias.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMaterias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMaterias.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.dgvMaterias.Location = New System.Drawing.Point(0, 0)
        Me.dgvMaterias.MultiSelect = False
        Me.dgvMaterias.Name = "dgvMaterias"
        Me.dgvMaterias.ReadOnly = True
        Me.dgvMaterias.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvMaterias.RowHeadersVisible = False
        Me.dgvMaterias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMaterias.ShowCellErrors = False
        Me.dgvMaterias.ShowCellToolTips = False
        Me.dgvMaterias.ShowEditingIcon = False
        Me.dgvMaterias.ShowRowErrors = False
        Me.dgvMaterias.Size = New System.Drawing.Size(817, 377)
        Me.dgvMaterias.TabIndex = 0
        '
        'Hora
        '
        Me.Hora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Hora.HeaderText = "Hora de inicio"
        Me.Hora.Name = "Hora"
        Me.Hora.ReadOnly = True
        Me.Hora.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Hora.Width = 130
        '
        'Lunes
        '
        Me.Lunes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Lunes.HeaderText = "Lunes"
        Me.Lunes.Name = "Lunes"
        Me.Lunes.ReadOnly = True
        Me.Lunes.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Lunes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Lunes.Width = 59
        '
        'Martes
        '
        Me.Martes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Martes.HeaderText = "Martes"
        Me.Martes.Name = "Martes"
        Me.Martes.ReadOnly = True
        Me.Martes.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Martes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Martes.Width = 64
        '
        'Miércoles
        '
        Me.Miércoles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Miércoles.HeaderText = "Miércoles"
        Me.Miércoles.Name = "Miércoles"
        Me.Miércoles.ReadOnly = True
        Me.Miércoles.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Miércoles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Miércoles.Width = 82
        '
        'Jueves
        '
        Me.Jueves.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Jueves.HeaderText = "Jueves"
        Me.Jueves.Name = "Jueves"
        Me.Jueves.ReadOnly = True
        Me.Jueves.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Jueves.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Jueves.Width = 65
        '
        'Viernes
        '
        Me.Viernes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Viernes.HeaderText = "Viérnes"
        Me.Viernes.Name = "Viernes"
        Me.Viernes.ReadOnly = True
        Me.Viernes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Viernes.Width = 69
        '
        'Sábado
        '
        Me.Sábado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Sábado.HeaderText = "Sábado"
        Me.Sábado.Name = "Sábado"
        Me.Sábado.ReadOnly = True
        Me.Sábado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Sábado.Width = 71
        '
        'frmVistaGrilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Controls.Add(Me.dgvMaterias)
        Me.Name = "frmVistaGrilla"
        Me.Size = New System.Drawing.Size(817, 377)
        CType(Me.dgvMaterias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvMaterias As System.Windows.Forms.DataGridView
    Friend WithEvents Hora As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lunes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Martes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Miércoles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Jueves As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Viernes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sábado As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
