<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDia
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.lblNoHayHoras = New System.Windows.Forms.Label()
        Me.pnlDias = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDia = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblNoHayHoras
        '
        Me.lblNoHayHoras.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNoHayHoras.BackColor = System.Drawing.Color.Transparent
        Me.lblNoHayHoras.Font = New System.Drawing.Font("Corbel", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblNoHayHoras.ForeColor = System.Drawing.Color.White
        Me.lblNoHayHoras.Location = New System.Drawing.Point(3, 35)
        Me.lblNoHayHoras.Margin = New System.Windows.Forms.Padding(0)
        Me.lblNoHayHoras.Name = "lblNoHayHoras"
        Me.lblNoHayHoras.Size = New System.Drawing.Size(250, 176)
        Me.lblNoHayHoras.TabIndex = 28
        Me.lblNoHayHoras.Text = "No hay" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "horarios" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "asignados"
        Me.lblNoHayHoras.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDias
        '
        Me.pnlDias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDias.AutoScroll = True
        Me.pnlDias.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlDias.ColumnCount = 2
        Me.pnlDias.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlDias.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlDias.Location = New System.Drawing.Point(2, 35)
        Me.pnlDias.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlDias.Name = "pnlDias"
        Me.pnlDias.RowCount = 1
        Me.pnlDias.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 173.0!))
        Me.pnlDias.Size = New System.Drawing.Size(250, 173)
        Me.pnlDias.TabIndex = 29
        '
        'lblDia
        '
        Me.lblDia.AutoSize = True
        Me.lblDia.Font = New System.Drawing.Font("Corbel", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDia.ForeColor = System.Drawing.Color.PaleGreen
        Me.lblDia.Location = New System.Drawing.Point(-5, 0)
        Me.lblDia.Name = "lblDia"
        Me.lblDia.Size = New System.Drawing.Size(90, 36)
        Me.lblDia.TabIndex = 27
        Me.lblDia.Text = "Lunes"
        '
        'frmDia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.lblNoHayHoras)
        Me.Controls.Add(Me.pnlDias)
        Me.Controls.Add(Me.lblDia)
        Me.Name = "frmDia"
        Me.Size = New System.Drawing.Size(256, 210)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNoHayHoras As System.Windows.Forms.Label
    Friend WithEvents pnlDias As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblDia As System.Windows.Forms.Label

End Class
