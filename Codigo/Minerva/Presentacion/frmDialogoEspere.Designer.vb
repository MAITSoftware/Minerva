<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDialogoEspere
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
        Me.lblComprobando = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblComprobando
        '
        Me.lblComprobando.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblComprobando.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComprobando.Location = New System.Drawing.Point(0, 0)
        Me.lblComprobando.Name = "lblComprobando"
        Me.lblComprobando.Size = New System.Drawing.Size(200, 109)
        Me.lblComprobando.TabIndex = 0
        Me.lblComprobando.Text = "Comprobando conexión" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "con el servidor"
        Me.lblComprobando.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmDialogoEspere
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(200, 109)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblComprobando)
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmDialogoEspere"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Espere por favor"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblComprobando As System.Windows.Forms.Label
End Class
